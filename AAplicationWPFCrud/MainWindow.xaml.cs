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

namespace AAplicationWPFCrud
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        wpfCRUDEntities _db = new wpfCRUDEntities();
        public static DataGrid datagrid;

        public MainWindow()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            myDataGrid.ItemsSource = _db.member.ToList();
            datagrid = myDataGrid;
        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            InsertPage Ipage = new InsertPage();
            Ipage.ShowDialog();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int idMember = (myDataGrid.SelectedItem as member).Id;
            UpdatePage Ipage = new UpdatePage(idMember);
            Ipage.ShowDialog();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as member).Id;
            var deleteMember = _db.member.Where(m => m.Id == id).Single();
            _db.member.Remove(deleteMember);
            _db.SaveChanges();
            myDataGrid.ItemsSource = _db.member.ToList();
        }
    }
}
