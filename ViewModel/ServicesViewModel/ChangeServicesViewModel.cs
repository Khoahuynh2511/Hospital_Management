using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using LTTQ_DoAn.Model;
using LTTQ_DoAn.Repositories;
using Json.Net;
using LTTQ_DoAn.View;
using RestSharp;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.Net.NetworkInformation;
using System.Net;

namespace LTTQ_DoAn.ViewModel
{
    public class ChangeServicesViewModel : BaseViewModel
    {
        private DICHVU dichvu;
        private BitmapImage image;
        private string image_url;
        QUANLYBENHVIENEntities _db = new QUANLYBENHVIENEntities();

        public ICommand CancelCommand { get; }
        public ICommand ConfirmChangeCommand { get; }
        public ICommand AddImageCommand { get; }

        public DICHVU Dichvu
        {
            get => dichvu; set
            {
                dichvu = value;
                OnPropertyChanged(nameof(Dichvu));
            }
        }

        public BitmapImage Image
        {
            get => image; set
            {
                image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
        public string Image_url
        {
            get => image_url; set
            {
                image_url = value;
                OnPropertyChanged(nameof(Image_url));
            }
        }
        private void update()
        {
            DICHVU updateDichvu = (from m in _db.DICHVU
                                       where m.MADICHVU == Dichvu.MADICHVU
                                       select m).Single();
            updateDichvu.TENDICHVU = Dichvu.TENDICHVU;
            updateDichvu.GIATIEN = Dichvu.GIATIEN;
            updateDichvu.PICTURE = Image_url;
            _db.SaveChanges();
        }
        public ChangeServicesViewModel()
        {
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand, CanExecuteCancelCommand);
            ConfirmChangeCommand = new ViewModelCommand(ExecuteChangeCommand, CanExecuteChangeCommand);
            AddImageCommand = new ViewModelCommand(ExecuteAddImageCommand, CanExecuteAddImageCommand);

        }
        public ChangeServicesViewModel(DICHVU SelectedDichVu)
        {
            Dichvu = SelectedDichVu;
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand, CanExecuteCancelCommand);
            ConfirmChangeCommand = new ViewModelCommand(ExecuteChangeCommand, CanExecuteChangeCommand);
            AddImageCommand = new ViewModelCommand(ExecuteAddImageCommand, CanExecuteAddImageCommand);
            
            if (Dichvu != null && string.IsNullOrEmpty(Dichvu.PICTURE))
            {
                Image_url = GetAutoMedicalImage();
                try
                {
                    Image = new BitmapImage(new Uri(Image_url));
                }
                catch { }
            }
        }
        private bool CanExecuteAddImageCommand(object? obj)
        {
            return true; //ko điều kiện
        }
        private void postImage(string path)
        {
            var client = new RestClient("http://3.25.245.200");
            var request = new RestRequest("photo/item");
            request.AddFile("image", path);
            var response = client.Post(request);
            var content = response.Content;
            ImageResponse jsonResponse = JsonNet.Deserialize<ImageResponse>(content);
            string data = jsonResponse.url.ToString();
            Image_url = data;
        }

        private string GetAutoMedicalImage()
        {
            try
            {
                string searchTerm = "medical";
                if (!string.IsNullOrEmpty(Dichvu?.TENDICHVU))
                {
                    string tenDichVu = Dichvu.TENDICHVU.ToLower();
                    if (tenDichVu.Contains("khám") || tenDichVu.Contains("kham"))
                    {
                        searchTerm = "medical examination";
                    }
                    else if (tenDichVu.Contains("xét nghiệm") || tenDichVu.Contains("xet nghiem"))
                    {
                        searchTerm = "medical test";
                    }
                    else if (tenDichVu.Contains("siêu âm") || tenDichVu.Contains("sieu am"))
                    {
                        searchTerm = "ultrasound";
                    }
                    else if (tenDichVu.Contains("x-quang") || tenDichVu.Contains("x quang"))
                    {
                        searchTerm = "xray";
                    }
                    else if (tenDichVu.Contains("phẫu thuật") || tenDichVu.Contains("phau thuat"))
                    {
                        searchTerm = "surgery";
                    }
                }
                
                return "https://picsum.photos/400/300?random=" + DateTime.Now.Ticks;
            }
            catch
            {
                return "https://picsum.photos/400/300";
            }
        }
        private void ExecuteAddImageCommand(object? obj)
        {
            try
            {
                string autoImageUrl = GetAutoMedicalImage();
                Image_url = autoImageUrl;
                Image = new BitmapImage(new Uri(autoImageUrl));
                new MessageBoxCustom("Thông báo", "Đã tự động tải ảnh y khoa", MessageType.Success, MessageButtons.OK).ShowDialog();
            }
            catch (Exception e)
            {
                new MessageBoxCustom("Lỗi", "Không thể tải ảnh: " + e.Message, MessageType.Error, MessageButtons.OK).ShowDialog();
            }
        }
        private bool CanExecuteCancelCommand(object? obj)
        {
            return true; //ko điều kiện
        }
        private void ExecuteCancelCommand(object? obj)
        {
            Application.Current.MainWindow.Close();
        }
        private bool CanExecuteChangeCommand(object? obj)
        {
            return true; //dk: thay đổi xong không trùng với khoa đã có
        }
        private void ExecuteChangeCommand(object? obj)
        {
            try
            {
                update();
                //MessageBox.Show("Sửa thông tin y sĩ thành công!");
                new MessageBoxCustom("Thành công", "Sửa thông tin dịch vụ thành công!", MessageType.Success, MessageButtons.OK).ShowDialog();
                Application.Current.MainWindow.Close(); // sau khi thêm sẽ đóng cửa sổ

            }
            catch (Exception err)
            {
                new MessageBoxCustom("Lỗi", err.Message, MessageType.Error, MessageButtons.OKCancel).ShowDialog();
                //MessageBox.Show(err.Message);
                Application.Current.MainWindow.Close(); // sau khi thêm sẽ đóng cửa sổ
            }
        }
    }
}
