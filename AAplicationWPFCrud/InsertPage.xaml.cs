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
    /// Logique d'interaction pour InsertPage.xaml
    /// </summary>
    public partial class InsertPage : Window
    {
        wpfCRUDEntities _db = new wpfCRUDEntities();

        public InsertPage()
        {
            InitializeComponent();
        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            member newMember = new member()
            {
                name = textBoxName.Text,
                Gender = comboBoxGender.Text
            };
            _db.member.Add(newMember);
            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.member.ToList();
            this.Hide();
        }
    }
}
