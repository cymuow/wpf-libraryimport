using System.Windows;
using System.Windows.Input;

namespace WpfLibraryImport.Views
{
    /// <summary>
    /// CustomMessageBox.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        public CustomMessageBox(string message, FrameworkElement icon = null)
        {
            InitializeComponent();
            txtMessage.Text = message;
            if (icon is not null)
            {
                iconContainer.Content = icon;
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true; // ShowDialog()가 true를 반환함
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false; // ShowDialog()가 false를 반환함
            this.Close();
        }

        private void TitleBar_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove(); // 창 이동
            }
        }
    }
}
