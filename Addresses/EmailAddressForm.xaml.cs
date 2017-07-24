using System;
using System.Collections.Generic;
using System.Data;
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

namespace Addresses
{
    /// <summary>
    /// Interaction logic for EmailAddressForm.xaml
    /// </summary>
    public partial class EmailAddressForm : Window
    {
        
        public EmailAddressForm()
        {
            InitializeComponent();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            var entry = MainWindow.DB.Entries.ToArray()[MainWindow.current];
            Email en = new Email { ID = entry.Id, EmailAddress = addEmailTextBox.Text};
            MainWindow.DB.Emails.Add(en);
            MainWindow.DB.SaveChanges(); //need to save change so database will get updated 
            MainWindow win2 = new MainWindow();
            win2.Show();
            this.Close();

        }
    }
}
