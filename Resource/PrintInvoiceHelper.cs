using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace LTTQ_DoAn.Resource
{
    public class InvoiceServiceItem
    {
        public string TenDichVu { get; set; }
        public decimal GiaTien { get; set; }
    }

    public class InvoiceMedicineItem
    {
        public int STT { get; set; }
        public string TenThuoc { get; set; }
        public decimal DonGia { get; set; }
        public double SoLuong { get; set; }
        public decimal ThanhTien { get; set; }
    }

    public class InvoicePrintData
    {
        public string TenPhongMach { get; set; } = "PHONG MACH DA KHOA";
        public string DiaChi { get; set; } = "";
        public string SoDienThoai { get; set; } = "";
        
        public string MaHoaDon { get; set; }
        public string NgayLap { get; set; }
        
        public string TenBenhNhan { get; set; }
        public string MaBenhNhan { get; set; }
        
        public List<InvoiceServiceItem> DichVuList { get; set; } = new List<InvoiceServiceItem>();
        public List<InvoiceMedicineItem> ThuocList { get; set; } = new List<InvoiceMedicineItem>();
        
        public decimal TongTien { get; set; }
        public decimal GiamGia { get; set; }
        public decimal ThanhTien { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
    }

    public static class PrintInvoiceHelper
    {
        public static void PrintInvoice(InvoicePrintData data)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                FlowDocument doc = CreateInvoiceDocument(data);
                doc.PageHeight = printDialog.PrintableAreaHeight;
                doc.PageWidth = printDialog.PrintableAreaWidth;
                doc.PagePadding = new Thickness(50);
                doc.ColumnGap = 0;
                doc.ColumnWidth = printDialog.PrintableAreaWidth;

                IDocumentPaginatorSource idpSource = doc;
                printDialog.PrintDocument(idpSource.DocumentPaginator, "Hoa don - " + data.MaHoaDon);
            }
        }

        private static FlowDocument CreateInvoiceDocument(InvoicePrintData data)
        {
            FlowDocument doc = new FlowDocument();
            doc.FontFamily = new FontFamily("Times New Roman");
            doc.FontSize = 12;

            Paragraph header = new Paragraph();
            header.TextAlignment = TextAlignment.Center;
            header.Inlines.Add(new Bold(new Run(data.TenPhongMach + "\n")) { FontSize = 16 });
            if (!string.IsNullOrEmpty(data.DiaChi))
                header.Inlines.Add(new Run("Dia chi: " + data.DiaChi + "\n") { FontSize = 10 });
            if (!string.IsNullOrEmpty(data.SoDienThoai))
                header.Inlines.Add(new Run("Dien thoai: " + data.SoDienThoai + "\n") { FontSize = 10 });
            doc.Blocks.Add(header);

            Paragraph title = new Paragraph(new Bold(new Run("HOA DON")));
            title.FontSize = 18;
            title.TextAlignment = TextAlignment.Center;
            title.Margin = new Thickness(0, 10, 0, 10);
            doc.Blocks.Add(title);

            Paragraph invoiceInfo = new Paragraph();
            invoiceInfo.Inlines.Add(new Run("Ma hoa don: " + data.MaHoaDon));
            invoiceInfo.Inlines.Add(new Run("     Ngay lap: " + data.NgayLap));
            invoiceInfo.TextAlignment = TextAlignment.Right;
            doc.Blocks.Add(invoiceInfo);

            Paragraph patientInfo = new Paragraph();
            patientInfo.Inlines.Add(new Bold(new Run("THONG TIN BENH NHAN\n")));
            patientInfo.Inlines.Add(new Run("Ho ten: " + data.TenBenhNhan + "\n"));
            if (!string.IsNullOrEmpty(data.MaBenhNhan))
                patientInfo.Inlines.Add(new Run("Ma benh nhan: " + data.MaBenhNhan + "\n"));
            patientInfo.Margin = new Thickness(0, 10, 0, 10);
            doc.Blocks.Add(patientInfo);

            Paragraph serviceTitle = new Paragraph(new Bold(new Run("DICH VU")));
            serviceTitle.Margin = new Thickness(0, 0, 0, 5);
            doc.Blocks.Add(serviceTitle);

            if (data.DichVuList != null && data.DichVuList.Count > 0)
            {
                Table serviceTable = new Table();
                serviceTable.CellSpacing = 0;
                serviceTable.BorderBrush = Brushes.Black;
                serviceTable.BorderThickness = new Thickness(1);

                serviceTable.Columns.Add(new TableColumn() { Width = new GridLength(300) });
                serviceTable.Columns.Add(new TableColumn() { Width = new GridLength(150) });

                TableRowGroup serviceRowGroup = new TableRowGroup();

                TableRow serviceHeaderRow = new TableRow();
                serviceHeaderRow.Background = Brushes.LightGray;
                serviceHeaderRow.Cells.Add(CreateCell("Ten dich vu", true));
                serviceHeaderRow.Cells.Add(CreateCell("Gia tien", true));
                serviceRowGroup.Rows.Add(serviceHeaderRow);

                foreach (var item in data.DichVuList)
                {
                    TableRow row = new TableRow();
                    row.Cells.Add(CreateCell(item.TenDichVu, false));
                    row.Cells.Add(CreateCell(item.GiaTien.ToString("N0") + " VND", false));
                    serviceRowGroup.Rows.Add(row);
                }

                serviceTable.RowGroups.Add(serviceRowGroup);
                doc.Blocks.Add(serviceTable);
            }

            Paragraph medicineTitle = new Paragraph(new Bold(new Run("THUOC")));
            medicineTitle.Margin = new Thickness(0, 15, 0, 5);
            doc.Blocks.Add(medicineTitle);

            if (data.ThuocList != null && data.ThuocList.Count > 0)
            {
                Table medicineTable = new Table();
                medicineTable.CellSpacing = 0;
                medicineTable.BorderBrush = Brushes.Black;
                medicineTable.BorderThickness = new Thickness(1);

                medicineTable.Columns.Add(new TableColumn() { Width = new GridLength(40) });
                medicineTable.Columns.Add(new TableColumn() { Width = new GridLength(200) });
                medicineTable.Columns.Add(new TableColumn() { Width = new GridLength(100) });
                medicineTable.Columns.Add(new TableColumn() { Width = new GridLength(80) });
                medicineTable.Columns.Add(new TableColumn() { Width = new GridLength(150) });

                TableRowGroup medicineRowGroup = new TableRowGroup();

                TableRow medicineHeaderRow = new TableRow();
                medicineHeaderRow.Background = Brushes.LightGray;
                medicineHeaderRow.Cells.Add(CreateCell("STT", true));
                medicineHeaderRow.Cells.Add(CreateCell("Ten thuoc", true));
                medicineHeaderRow.Cells.Add(CreateCell("Don gia", true));
                medicineHeaderRow.Cells.Add(CreateCell("SL", true));
                medicineHeaderRow.Cells.Add(CreateCell("Thanh tien", true));
                medicineRowGroup.Rows.Add(medicineHeaderRow);

                foreach (var item in data.ThuocList)
                {
                    TableRow row = new TableRow();
                    row.Cells.Add(CreateCell(item.STT.ToString(), false));
                    row.Cells.Add(CreateCell(item.TenThuoc, false));
                    row.Cells.Add(CreateCell(item.DonGia.ToString("N0") + " VND", false));
                    row.Cells.Add(CreateCell(item.SoLuong.ToString(), false));
                    row.Cells.Add(CreateCell(item.ThanhTien.ToString("N0") + " VND", false));
                    medicineRowGroup.Rows.Add(row);
                }

                medicineTable.RowGroups.Add(medicineRowGroup);
                doc.Blocks.Add(medicineTable);
            }

            Paragraph summary = new Paragraph();
            summary.Margin = new Thickness(0, 15, 0, 0);
            summary.TextAlignment = TextAlignment.Right;
            summary.Inlines.Add(new Run("Tong tien: " + data.TongTien.ToString("N0") + " VND\n"));
            if (data.GiamGia > 0)
                summary.Inlines.Add(new Run("Giam gia: " + data.GiamGia.ToString("N0") + " VND\n"));
            summary.Inlines.Add(new Bold(new Run("Thanh tien: " + data.ThanhTien.ToString("N0") + " VND\n")));
            summary.Inlines.Add(new Run("Phuong thuc thanh toan: " + data.PhuongThucThanhToan + "\n"));
            summary.Inlines.Add(new Run("Trang thai: " + data.TrangThai));
            doc.Blocks.Add(summary);

            if (!string.IsNullOrEmpty(data.GhiChu))
            {
                Paragraph notes = new Paragraph();
                notes.Inlines.Add(new Bold(new Run("Ghi chu: ")));
                notes.Inlines.Add(new Run(data.GhiChu));
                notes.Margin = new Thickness(0, 10, 0, 0);
                doc.Blocks.Add(notes);
            }

            Paragraph footer = new Paragraph();
            footer.TextAlignment = TextAlignment.Center;
            footer.Margin = new Thickness(0, 30, 0, 0);
            footer.Inlines.Add(new Run("Cam on quy khach da su dung dich vu!"));
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
