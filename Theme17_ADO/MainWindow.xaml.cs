using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace Theme17_ADO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataSet ds = new DataSet();
        SqlConnection conSQL;
        SqlDataAdapter daSQL;
        DataTable dtSQL;
        DataRowView rowSQL;

        OleDbConnection conMDB;
        OleDbDataAdapter daMDB;
        DataTable dtMDB;
        DataRowView rowOleDb;

        string connectionStringMDB = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\User\\source\\repos\\Theme17_ADO\\Theme17_ADO\\Theme17_Access.mdb";
        //string connectionStringMDB = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Negro\\Source\\Repos\\SERGONEGRO\\Theme17_ADO\\Theme17_ADO\\Theme17_Access.mdb";

        public MainWindow() { InitializeComponent(); Preparing(); }

        private async void Preparing()
        {
            /****SQL****/
            #region Init
            tbLOG.Text = "";
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "Theme17_ADO"
                //InitialCatalog = "dbo"

            };
            conSQL = new SqlConnection(connectionStringBuilder.ConnectionString);
            dtSQL = new DataTable();
            daSQL = new SqlDataAdapter();
            //tbLOG.Text += "Соединение с базой SQL успешно";

            #endregion

            #region select

            var sql = @"SELECT * FROM Clients Order By clients.Id";
            daSQL.SelectCommand = new SqlCommand(sql, conSQL);

            #endregion

            #region insert

            sql = @"INSERT INTO Clients (Name,  Surname,  Lastname, Phone, Email) 
                                 VALUES (@Name,  @Surname,  @Lastname, @Phone, @Email); 
                     SET @id = @@IDENTITY;";
            
            daSQL.InsertCommand = new SqlCommand(sql, conSQL);

            daSQL.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "id").Direction = ParameterDirection.Output;
            daSQL.InsertCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 20, "Name");
            daSQL.InsertCommand.Parameters.Add("@Surname", SqlDbType.NVarChar, 20, "Surname");
            daSQL.InsertCommand.Parameters.Add("@Lastname", SqlDbType.NVarChar, 20, "Lastname");
            daSQL.InsertCommand.Parameters.Add("@Phone", SqlDbType.NVarChar, 15, "Phone");
            daSQL.InsertCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 50, "Email");

            #endregion

            #region update

            sql = @"UPDATE Clients SET 
                           Name = @Name,
                           SurName = @SurName,
                           LastName = @LastName,
                           Phone = @Phone,
                           Email = @Email
                    WHERE id = @id";

            daSQL.UpdateCommand = new SqlCommand(sql, conSQL);
            daSQL.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id").SourceVersion = DataRowVersion.Original;
            daSQL.UpdateCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 20, "Name");
            daSQL.UpdateCommand.Parameters.Add("@Surname", SqlDbType.NVarChar, 20, "Surname");
            daSQL.UpdateCommand.Parameters.Add("@Lastname", SqlDbType.NVarChar, 20, "Lastname");
            daSQL.UpdateCommand.Parameters.Add("@Phone", SqlDbType.NVarChar, 15, "Phone");
            daSQL.UpdateCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 50, "Email");

            #endregion

            #region delete

            sql = "DELETE FROM Clients WHERE id = @id";

            daSQL.DeleteCommand = new SqlCommand(sql, conSQL);
            daSQL.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id");

            #endregion

            
            daSQL.Fill(dtSQL);
            ds.Tables.Add(dtSQL);
            gvClients.DataContext = dtSQL.DefaultView;


            /**--------------MDB-----------------**/
            #region Init
            var connectionSBMDB = new OleDbConnectionStringBuilder(connectionStringMDB);
            conMDB = new OleDbConnection(connectionSBMDB.ConnectionString);
            dtMDB = new DataTable();
            daMDB = new OleDbDataAdapter();
            #endregion

            #region select

            var sqlMDB = @"SELECT * FROM Purchases Order By Purchases.Id Desc";
            daMDB.SelectCommand = new OleDbCommand(sqlMDB, conMDB);
            #endregion

            daMDB.Fill(dtMDB);
            ds.Tables.Add(dtMDB);
            gvPurchases.ItemsSource = ds.Tables[1].DefaultView;   //отображение таблицы покупок
        }

        #region SQL
        /// <summary>
        /// Начало редактирования 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GVCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            rowSQL = (DataRowView)gvClients.SelectedItem;
            rowSQL.BeginEdit();
        }

        /// <summary>
        /// Редактирование записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GVCurrentCellChanged(object sender, EventArgs e)
        {
            if (rowSQL == null) return;
            rowSQL.EndEdit();
            daSQL.Update(dtSQL);
        }

        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemDeleteClick(object sender, RoutedEventArgs e)
        {
            rowSQL = (DataRowView)gvClients.SelectedItem;
            rowSQL.Row.Delete();
            daSQL.Update(dtSQL);
        }

        /// <summary>
        /// Добавление записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemAddClick(object sender, RoutedEventArgs e)
        {
            DataRow r = dtSQL.NewRow();
            AddClientWindow add = new AddClientWindow(r);
            add.ShowDialog();

            if (add.DialogResult.Value)
            {
                dtSQL.Rows.Add(r);
                daSQL.Update(dtSQL);
            }
        }
        #endregion

        private void AllViewShow(object sender, RoutedEventArgs e)
        {
            new AllView(ds).ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddPurchaseWindow AddPurchaseWnd = new AddPurchaseWindow(ds);
            AddPurchaseWnd.ShowDialog();

            if (AddPurchaseWnd.DialogResult.Value)
            {
                //dtSQL.Rows.Add(r);
                //daSQL.Update(dtSQL);
            }
        }
    }
}