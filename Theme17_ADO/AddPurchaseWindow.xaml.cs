using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Theme17_ADO
{
    /// <summary>
    /// Логика взаимодействия для AddPurchaseWindow.xaml
    /// </summary>
    public partial class AddPurchaseWindow : Window
    {
        public AddPurchaseWindow() {InitializeComponent();}

        public AddPurchaseWindow(DataSet ds) : this()
        {
            DataTable clients = ds.Tables[0];
            DataTable purchases = ds.Tables[1];

            var query =
                from client in clients.AsEnumerable()
                select new
                {
                    Client = client.Field<string>("Name") + " " +
                             client.Field<string>("Surname") + " " +
                             client.Field<string>("Lastname")
                };
            //List clientList = clients.;
            //cbClient.DataContext = clients;
            //cbClient.DataContext = query.ToList();



            cancelBtn.Click += delegate { this.DialogResult = false; };
            okBtn.Click += delegate
            {
                //DataRow row = null;
                //row["Email"] = cbClient.SelectedItem.ToString();
                //row["ProductID"] = txtProductId.Text;
                //row["ProductName"] = txtProductName.Text;

                //purchases.Rows.Add(row);
                
                //this.DialogResult = !false;
                MessageBox.Show(cbClient.SelectedItem.ToString());
            };
        }
    }
}
