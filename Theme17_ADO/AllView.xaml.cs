using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для AllView.xaml
    /// </summary>
    public partial class AllView : Window
    {
        public AllView() { InitializeComponent(); }
        public AllView(DataSet ds) : this()
        {
            DataTable clients = ds.Tables[0];
            DataTable purchases = ds.Tables[1];
            var query =
                from client in clients.AsEnumerable()
                join purchase in purchases.AsEnumerable()
                on client.Field<string>("Email") equals
                    purchase.Field<string>("Email")
                select new
                {
                    ClientID = client.Field<int>("id"),
                    ClientName = client.Field<string>("Name"),
                    ClientSurName = client.Field<string>("Surname"),
                    ClientLastName = client.Field<string>("Lastname"),
                    ClientPhone = client.Field<string>("Phone"),
                    ClientMail = client.Field<string>("Email"),
                    PurchaseId = purchase.Field<int>("ID"),
                    ProductId = purchase.Field<string>("ProductID"),
                    ProductName = purchase.Field<string>("ProductName")
                };

            //            clients.Merge(purchases, true, MissingSchemaAction.Add);
            //            SqlDataAdapter da = new SqlDataAdapter();

            //            var sql = @"SELECT 
            //Clients.id as 'ID клиента',
            //Clients.Name as 'Имя',
            //Clients.SurName as 'Фамилия',
            //Clients.LastName as 'Отчество',
            //Clients.Phone as 'Телефон',
            //Clients.Email as 'email',
            //Purchases.ProductId as 'ID товара',
            //Purchases.ProductName as 'Название товара'
            //FROM  Clients, Purchases
            //WHERE Clients.Email = Purchases.Email
            //Order By Clients.Id";
            //            da.SelectCommand = new SqlCommand(sql);
            //            da.Fill(clients);

            //            gridAllView.DataContext = clients.DefaultView;
            gridAllView.DataContext = query.ToList();

         
        }
    }
}
