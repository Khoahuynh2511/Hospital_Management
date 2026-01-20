using System.Windows;

namespace LTTQ_DoAn.View
{
    public partial class AddToQueue : Window
    {
        public AddToQueue()
        {
            InitializeComponent();
        }

        private void Button_Minimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
