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
using System.Data;
using System.Data.SqlClient;

namespace DemoDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string cnnStr = @"Data Source=.\SQLEXPRESS;" +
                "Initial Catalog=Persons;Integrated Security=True";
        PersonsEntities db = new PersonsEntities();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            SqlConnection cnnSql = new SqlConnection(cnnStr);
            string cmdStr = "INSERT dbo.People (FirstName, LastName, Age) " +
                            "VALUES('Testus', 'Testowicz', 43)";
            SqlCommand cmdSql = new SqlCommand(cmdStr, cnnSql);
            cnnSql.Open();
            cmdSql.ExecuteNonQuery();
            cnnSql.Close();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cnnSql = new SqlConnection(cnnStr);
            string cmdStr = "select * FROM People";
            SqlCommand cmdSql = new SqlCommand(cmdStr, cnnSql);
            cnnSql.Open();
            SqlDataReader dr = cmdSql.ExecuteReader();
            string wynik = "";
            while (dr.Read())
            {
                wynik += $"ID: {dr["PersonID"]}, {dr["FirstName"]} " +
                    $"{dr["LastName"]}, Age: {dr["Age"]}" + 
                    System.Environment.NewLine;
            }
            dr.Close();
            cnnSql.Close();
            MessageBox.Show(wynik);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cnnSql = new SqlConnection(cnnStr);
            string cmdStr = "select * FROM People";
            DataSet ds = new DataSet();
            SqlDataAdapter daSql = new SqlDataAdapter(cmdStr, cnnSql);
            SqlCommandBuilder cmdBuild = new SqlCommandBuilder();
            cmdBuild.DataAdapter = daSql;
            //daSql.SelectCommand = new SqlCommand(cmdStr, cnnSql);
            daSql.UpdateCommand = cmdBuild.GetUpdateCommand();
            daSql.InsertCommand = cmdBuild.GetInsertCommand();
            daSql.DeleteCommand = cmdBuild.GetDeleteCommand();

            daSql.Fill(ds, "People");
            string name = ds.Tables["People"].Rows[1]["LastName"].ToString();
            MessageBox.Show(name);
            string wynik = "";
            for (int i = 0; i < ds.Tables["People"].Rows.Count; i++)
            {
                wynik += $"{ds.Tables["People"].Rows[i]["FirstName"]} " +
                    $"{ds.Tables["People"].Rows[i]["LastName"]}";
            }

            ds.Tables["People"].Rows[2]["LastName"] = "Nowak";
            
            daSql.Update(ds, "People");
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            
            string wynik = "";
            foreach (var item in db.People)
            {
                wynik += $"ID: {item.PersonID}, {item.FirstName}" +
                    $" {item.LastName}, Age: {item.Age}";
            }
            MessageBox.Show(wynik);


        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            var wynik = from p in db.People
                        where p.Age >= 40
                        select p;

            string info = "";
            foreach (var item in wynik)
            {
                info += $"{item.FirstName} {item.LastName}" 
                    + System.Environment.NewLine;
            }
            MessageBox.Show(info);
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            //Nowy rekord
            Person newPerson = new Person()
            {
                PersonID = 100,
                FirstName = "Jerzy",
                LastName = "Nowacki",
                Age = 19
            };
            db.People.Add(newPerson);

            //Aktualizacja
            var personToUpdate = (from p in db.People
                                 where p.PersonID == 2
                                 select p).Single();
            personToUpdate.FirstName = "Krzysztoff";

            db.SaveChanges();
            MessageBox.Show("Zrobione");
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            PhotoContext photosDb = new PhotoContext();

            Photo newPhoto = new Photo()
            {
                Title = "Photo 1",
                DateTaken = DateTime.Now.AddDays(-30),
            };

            photosDb.Photos.Add(newPhoto);

            photosDb.SaveChanges();
            MessageBox.Show("Koniec");
        }
    }
}
