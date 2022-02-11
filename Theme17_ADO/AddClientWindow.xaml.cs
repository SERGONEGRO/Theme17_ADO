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
using System.Windows.Shapes;
using System.Data;

namespace Theme17_ADO
{
    /// <summary>
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public AddClientWindow() { InitializeComponent(); }

        public AddClientWindow(DataRow row) : this()
        {
            //cancelBtn.Click += delegate { this.DialogResult = false; };
            //okBtn.Click += delegate
            //{
            //    row["WorkerName"] = txtWorkerName.Text;
            //    row["IdBoss"] = txtIdBoss.Text;
            //    row["idDescription"] = txtDescription.Text;
            //    this.DialogResult = !false;
            //};

        }
    }
}
