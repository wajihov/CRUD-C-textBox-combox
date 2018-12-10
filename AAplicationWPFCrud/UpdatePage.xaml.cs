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

namespace AAplicationWPFCrud
{
    /// <summary>
    /// Logique d'interaction pour UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Window
    {
        wpfCRUDEntities _db = new wpfCRUDEntities();
        int id;
        public UpdatePage(int id_member)
        {
            InitializeComponent();
            id = id_member;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            member updateMemeber = (from m in _db.member
                                   where m.Id == id
                                   select m).Single();
            updateMemeber.name = textBoxName.Text;
            updateMemeber.Gender = comboBoxGender.Text;
            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.member.ToList();
            this.Hide();
        }
    }
}
