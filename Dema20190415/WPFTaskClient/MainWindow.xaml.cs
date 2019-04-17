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
using TasksLib;
using System.IO;
using System.Configuration;

namespace WPFTaskClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ToDoManager todomng = new ToDoManager();
        string filePath;

        public MainWindow()
        {
            InitializeComponent();
            filePath = ConfigurationManager.AppSettings["filePath"];
        }

        private void InfoButto_Click(object sender, RoutedEventArgs e)
        {
            infoLabel.Content = infoText.Text;
        }

        private void NewTaskButton_Click(object sender, RoutedEventArgs e)
        {
            TaskDialog taskDialog = new TaskDialog();
            bool? wynikDialog = taskDialog.ShowDialog();
            if (wynikDialog.Value)
            {
                todomng.AddTask(taskDialog.titleBox.Text,
                    taskDialog.dueDatePicker.SelectedDate.Value);
            }
            taskList.ItemsSource = todomng.TaskList().Select(t => t.Title);
        }

        private void ListaZadanBtn_Click(object sender, RoutedEventArgs e)
        {
            string info = "";
            foreach (var item in todomng.TaskList())
            {
                info += item.ItemInfo() + System.Environment.NewLine;
            }
            MessageBox.Show(info, "Lista zadan", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllLines(filePath, todomng.UncompletedTasks());
            
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            string info = File.ReadAllText(filePath);
            MessageBox.Show(info);
        }
    }
}
