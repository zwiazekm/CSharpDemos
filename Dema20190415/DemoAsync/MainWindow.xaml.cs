using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace DemoAsync
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
            //Task t = new Task(LongRunTask);
            //t.Start();
            //Task task1 = new Task(() => LongRunTask());
            var task1 = Task.Run(() => LongRunTask());
            //wykonuj

            Task[] tasks = new Task[3]
            {
                Task.Run(() => LongRunTask()),
                Task.Run(() => LongRunTask()),
                Task.Run(() => LongRunTask())
                };

            Task.WaitAll(tasks);
        }

        private void LongRunTask()
        {
            MessageBox.Show("rozpoczynam");
            Thread.Sleep(10000);
            MessageBox.Show("Koniec liczenia");
        }

        public string LongRunTask2()
        {
            Thread.Sleep(5000);
            return "Skonczone";
        }

        public async Task<string> GetData()
        {
            Task<string> task1 = Task.Run<string>(() => LongRunTask2());
            return await task1;
        }

        private async void Button1_Click(object sender, RoutedEventArgs e)
        {
            Task<string> task1 = Task.Run<string>(() => LongRunTask2());
            txtInfo.Text = await task1;
            MessageBox.Show("Skończył");
        }

        private async void Button2_Click(object sender, RoutedEventArgs e)
        {
            string info = await GetData();
            txtInfo.Text = info;
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                txtInfo.Dispatcher.BeginInvoke(
                    new Action(() => {
                        txtInfo.Text = "Początek";
                    }));
                Thread.Sleep(2000);
                //txtInfo.Text = "Koniec";
            });
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;

            var task1 = Task.Run(() =>
            {
                Thread.Sleep(2000);
                doWork(ct);
            }, ct);

            cts.Cancel();
            try
            {

            }
            catch (AggregateException ae)
            {

                throw;
            }
        }


        private void doWork(CancellationToken token)
        {
            Thread.Sleep(400);
            token.ThrowIfCancellationRequested();
        }
    }
}
