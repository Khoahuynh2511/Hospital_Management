using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace LTTQ_DoAn.Resource
{
    public class PrescriptionItem
    {
        public int STT { get; set; }
        public string TenThuoc { get; set; }
        public string SoLuong { get; set; }
        public string DonVi { get; set; }
        public string LieuDung { get; set; }
    }

    public class PrescriptionPrintData
    {
        public string TenPhongMach { get; set; } = "PHONG MACH DA KHOA";
        public string DiaChi { get; set; } = "";
        public string SoDienThoai { get; set; } = "";
        
        public string MaDonThuoc { get; set; }
        public string NgayKeDon { get; set; }
        
        public string TenBenhNhan { get; set; }
        public string NamSinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi_BN { get; set; }
        public string SoDienThoai_BN { get; set; }
        
        public string ChuanDoan { get; set; }
        public string GhiChu { get; set; }
        public string TenBacSi { get; set; }
        
        public List<PrescriptionItem> DanhSachThuoc { get; set; } = new List<PrescriptionItem>();
    }

    public static class PrintPrescriptionHelper
    {
        public static void PrintPrescription(PrescriptionPrintData data)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                FlowDocument doc = CreatePrescriptionDocument(data);
                doc.PageHeight = printDialog.PrintableAreaHeight;
                doc.PageWidth = printDialog.PrintableAreaWidth;
                doc.PagePadding = new Thickness(50);
                doc.ColumnGap = 0;
                doc.ColumnWidth = printDialog.PrintableAreaWidth;

                IDocumentPaginatorSource idpSource = doc;
                printDialog.PrintDocument(idpSource.DocumentPaginator, "Toa thuoc - " + data.MaDonThuoc);
            }
        }

        private static FlowDocument CreatePrescriptionDocument(PrescriptionPrintData data)
        {
            FlowDocument doc = new FlowDocument();
            doc.FontFamily = new FontFamily("Times New Roman");
            doc.FontSize = 12;

            // Header
            Paragraph header = new Paragraph();
            header.TextAlignment = TextAlignment.Center;
            header.Inlines.Add(new Bold(new Run(data.TenPhongMach + "\n")) { FontSize = 16 });
            if (!string.IsNullOrEmpty(data.DiaChi))
                header.Inlines.Add(new Run("Dia chi: " + data.DiaChi + "\n") { FontSize = 10 });
            if (!string.IsNullOrEmpty(data.SoDienThoai))
                header.Inlines.Add(new Run("Dien thoai: " + data.SoDienThoai + "\n") { FontSize = 10 });
            doc.Blocks.Add(header);

            // Title
            Paragraph title = new Paragraph(new Bold(new Run("TOA THUOC")));
            title.FontSize = 18;
            title.TextAlignment = TextAlignment.Center;
            title.Margin = new Thickness(0, 10, 0, 10);
            doc.Blocks.Add(title);

            // Prescription info
            Paragraph prescInfo = new Paragraph();
            prescInfo.Inlines.Add(new Run("Ma don thuoc: " + data.MaDonThuoc));
            prescInfo.Inlines.Add(new Run("     Ngay: " + data.NgayKeDon));
            prescInfo.TextAlignment = TextAlignment.Right;
            doc.Blocks.Add(prescInfo);

            // Patient info
            Paragraph patientInfo = new Paragraph();
            patientInfo.Inlines.Add(new Bold(new Run("THONG TIN BENH NHAN\n")));
            patientInfo.Inlines.Add(new Run("Ho ten: " + data.TenBenhNhan + "\n"));
            
            string genderAge = "";
            if (!string.IsNullOrEmpty(data.NamSinh))
                genderAge += "Nam sinh: " + data.NamSinh;
            if (!string.IsNullOrEmpty(data.GioiTinh))
                genderAge += "     Gioi tinh: " + data.GioiTinh;
            if (!string.IsNullOrEmpty(genderAge))
                patientInfo.Inlines.Add(new Run(genderAge + "\n"));
            
            if (!string.IsNullOrEmpty(data.DiaChi_BN))
                patientInfo.Inlines.Add(new Run("Dia chi: " + data.DiaChi_BN + "\n"));
            if (!string.IsNullOrEmpty(data.SoDienThoai_BN))
                patientInfo.Inlines.Add(new Run("So dien thoai: " + data.SoDienThoai_BN + "\n"));
            
            patientInfo.Margin = new Thickness(0, 10, 0, 10);
            doc.Blocks.Add(patientInfo);

            // Diagnosis
            if (!string.IsNullOrEmpty(data.ChuanDoan))
            {
                Paragraph diagnosis = new Paragraph();
                diagnosis.Inlines.Add(new Bold(new Run("Chan doan: ")));
                diagnosis.Inlines.Add(new Run(data.ChuanDoan));
                diagnosis.Margin = new Thickness(0, 0, 0, 10);
                doc.Blocks.Add(diagnosis);
            }

            // Medicine table
            Table table = new Table();
            table.CellSpacing = 0;
            table.BorderBrush = Brushes.Black;
            table.BorderThickness = new Thickness(1);

            // Columns
            table.Columns.Add(new TableColumn() { Width = new GridLength(40) });  // STT
            table.Columns.Add(new TableColumn() { Width = new GridLength(200) }); // Ten thuoc
            table.Columns.Add(new TableColumn() { Width = new GridLength(60) });  // So luong
            table.Columns.Add(new TableColumn() { Width = new GridLength(60) });  // Don vi
            table.Columns.Add(new TableColumn() { Width = new GridLength(150) }); // Lieu dung

            TableRowGroup rowGroup = new TableRowGroup();

            // Header row
            TableRow headerRow = new TableRow();
            headerRow.Background = Brushes.LightGray;
            headerRow.Cells.Add(CreateCell("STT", true));
            headerRow.Cells.Add(CreateCell("Ten thuoc", true));
            headerRow.Cells.Add(CreateCell("SL", true));
            headerRow.Cells.Add(CreateCell("DVT", true));
            headerRow.Cells.Add(CreateCell("Lieu dung", true));
            rowGroup.Rows.Add(headerRow);

            // Data rows
            foreach (var item in data.DanhSachThuoc)
            {
                TableRow row = new TableRow();
                row.Cells.Add(CreateCell(item.STT.ToString(), false));
                row.Cells.Add(CreateCell(item.TenThuoc, false));
                row.Cells.Add(CreateCell(item.SoLuong, false));
                row.Cells.Add(CreateCell(item.DonVi, false));
                row.Cells.Add(CreateCell(item.LieuDung, false));
                rowGroup.Rows.Add(row);
            }

            table.RowGroups.Add(rowGroup);
            doc.Blocks.Add(table);

            // Notes
            if (!string.IsNullOrEmpty(data.GhiChu))
            {
                Paragraph notes = new Paragraph();
                notes.Inlines.Add(new Bold(new Run("Ghi chu: ")));
                notes.Inlines.Add(new Run(data.GhiChu));
                notes.Margin = new Thickness(0, 10, 0, 0);
                doc.Blocks.Add(notes);
            }

            // Footer - Signature
            Paragraph footer = new Paragraph();
            footer.TextAlignment = TextAlignment.Right;
            footer.Margin = new Thickness(0, 30, 50, 0);
            footer.Inlines.Add(new Bold(new Run("Nguoi ke don\n\n\n\n")));
            footer.Inlines.Add(new Run("............................"));
            doc.Blocks.Add(footer);

            return doc;
        }

        private static TableCell CreateCell(string text, bool isHeader)
        {
            TableCell cell = new TableCell(new Paragraph(new Run(text)));
            cell.BorderBrush = Brushes.Black;
            cell.BorderThickness = new Thickness(0.5);
            cell.Padding = new Thickness(5);
            if (isHeader)
            {
                cell.FontWeight = FontWeights.Bold;
                cell.TextAlignment = TextAlignment.Center;
            }
            return cell;
        }
    }
}
