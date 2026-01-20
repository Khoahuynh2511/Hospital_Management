using LTTQ_DoAn.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LTTQ_DoAn.Repositories
{
    public class QueueRepository
    {
        private readonly string _connectionString;

        public QueueRepository()
        {
            _connectionString = "data source=(localdb)\\MSSQLLocalDB;initial catalog=QUANLYBENHVIEN;integrated security=True;MultipleActiveResultSets=True";
        }

        public List<QueueItemModel> GetTodayQueue()
        {
            var result = new List<QueueItemModel>();
            
            string sql = @"
                SELECT h.MAHANGDOI, h.SUB_ID, h.MABENHNHAN, h.SOTHUTU, 
                       h.THOIGIANDANGKY, h.TRANGTHAI, h.GHICHU,
                       b.SUB_ID AS PatientSubId, b.HOTEN
                FROM HANGDOI h
                LEFT JOIN BENHNHAN b ON h.MABENHNHAN = b.MABENHNHAN
                WHERE CAST(h.THOIGIANDANGKY AS DATE) = CAST(GETDATE() AS DATE)
                ORDER BY h.SOTHUTU";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new QueueItemModel
                            {
                                MaHangDoi = reader.GetInt32(0),
                                SubId = reader.IsDBNull(1) ? null : reader.GetString(1),
                                MaBenhNhan = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
                                SoThuTu = reader.GetInt32(3),
                                ThoiGianDangKy = reader.IsDBNull(4) ? DateTime.Now : reader.GetDateTime(4),
                                TrangThai = reader.IsDBNull(5) ? "Cho kham" : reader.GetString(5),
                                GhiChu = reader.IsDBNull(6) ? null : reader.GetString(6),
                                MaBenhNhanDisplay = reader.IsDBNull(7) ? "N/A" : reader.GetString(7),
                                TenBenhNhan = reader.IsDBNull(8) ? "N/A" : reader.GetString(8),
                                SoDienThoai = "N/A"
                            });
                        }
                    }
                }
            }

            return result;
        }

        public int GetNextQueueNumber()
        {
            string sql = @"
                SELECT ISNULL(MAX(SOTHUTU), 0) + 1 
                FROM HANGDOI 
                WHERE CAST(THOIGIANDANGKY AS DATE) = CAST(GETDATE() AS DATE)";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public int AddToQueue(int patientId, int queueNumber)
        {
            string sql = @"
                INSERT INTO HANGDOI (MABENHNHAN, SOTHUTU, THOIGIANDANGKY, TRANGTHAI)
                VALUES (@PatientId, @QueueNumber, GETDATE(), N'Cho kham');
                SELECT SCOPE_IDENTITY();";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientId", patientId);
                    cmd.Parameters.AddWithValue("@QueueNumber", queueNumber);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void UpdateStatus(int queueId, string status)
        {
            string sql = "UPDATE HANGDOI SET TRANGTHAI = @Status WHERE MAHANGDOI = @QueueId";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@QueueId", queueId);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteFromQueue(int queueId)
        {
            string sql = "DELETE FROM HANGDOI WHERE MAHANGDOI = @QueueId";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@QueueId", queueId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool IsPatientInQueue(int patientId)
        {
            string sql = @"
                SELECT COUNT(*) FROM HANGDOI 
                WHERE MABENHNHAN = @PatientId 
                AND TRANGTHAI IN (N'Cho kham', N'Dang kham')
                AND CAST(THOIGIANDANGKY AS DATE) = CAST(GETDATE() AS DATE)";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientId", patientId);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        public string GetQueueSubId(int queueId)
        {
            string sql = "SELECT SUB_ID FROM HANGDOI WHERE MAHANGDOI = @QueueId";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@QueueId", queueId);
                    var result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
        }
    }
}
