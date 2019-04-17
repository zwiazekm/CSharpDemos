using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WCFClient.PhotoService;

namespace WCFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PhotosClient service = new PhotosClient();
            Photo newPhoto = new Photo()
            {
                Title = "Photo WCF 1",
                DateTaken = DateTime.Now.AddDays(-3)
            };
            service.SetPhoto(newPhoto);

            Photo myPhoto = service.GetPhoto(2);
            MessageBox.Show(myPhoto.Title);

            string info = "";
            foreach (var item in service.PhotoList())
            {
                info += $"{ item.Title}" + System.Environment.NewLine;
            }
            MessageBox.Show(info);
        }
    }
}
