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
namespace Addresses
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static AddressesEntities DB = new AddressesEntities();
        public static int CurEmail;        
        public static CType? CurrenCType; //business/friend/null=all
        public static Email[] SelectedEmails;
        public static int current = 0;
        public MainWindow()
        {
            InitializeComponent();
            Display();
        }

        /// <summary>
        /// look up phone number by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Entry[] Lookup(string name)
        {
            var t =
                from e
                in DB.Entries
                where e.Name.Contains(name)
                select e;

            
                  Entry[] ents = t.ToArray<Entry>();
            if (ents.Length != 0)
            {
                return ents;
            }
            else
            {
                return null;
            }
            

        }

        /// <summary>
        /// display all the entries
        /// </summary>
        public void Display()
        {
            var selected = CurrenCType != null ?
                DB.Entries.Where(en => en.ContactType == (int)CurrenCType).OrderBy(en => en.Name) :
                DB.Entries;
           
            Entry e = selected.ToArray()[current];        

            tbName.Text = e.Name;
            tbAddress.Text = e.Address;
            tbCSZ.Text = e.CSZ;
            tbPhone.Text = e.Phone;
            


            SelectedEmails = e.Emails.ToArray();
            tbEmail.Text = CurEmail < SelectedEmails.Length ? SelectedEmails[CurEmail].EmailAddress : SelectedEmails[SelectedEmails.Length-1].EmailAddress;
            

            CType type = (CType)e.ContactType;
            tbContactType.Text = type.ToString();


        }
              

        /// <summary>
        /// button to go to start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            current = 0;
            CurEmail = 0;
            switch (CurrenCType)
            {
                case CType.Business:
                    Display();
                    break;
                case CType.Friend:
                    Display();
                    break;
                default:
                    Display();
                    break;
            }           
            
        }


        /// <summary>
        /// button to go to end
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, RoutedEventArgs e)
        {
            CurEmail = 0;
            current = DB.Entries.ToArray().Count() - 1;
            if (CurrenCType != null)
            {
                var selected = DB.Entries.Where(K => K.ContactType == (int) CurrenCType);
                current = selected.ToArray().Count() - 1;
            }
           


            switch (CurrenCType)
            {
                case CType.Business:                    
                    Display();
                    break;
                case CType.Friend:
                    Display();
                    break;
                default:
                    Display();
                    break;
            }
                 
            
        }

        /// <summary>
        /// button to go to prev
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            CurEmail = 0;
            if(current >0)
            {
                current -= 1;
            }
            switch (CurrenCType)
            {
                case CType.Business:
                    Display();
                    break;
                case CType.Friend:
                    Display();
                    break;
                default:
                    Display();
                    break;
            }

        }

        /// <summary>
        /// button to go to next
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            CurEmail = 0;
            var selected = from en in DB.Entries select en;
            if (CurrenCType != null)
            {
                selected = DB.Entries.Where(K => K.ContactType == (int)CurrenCType);

            }
            if (current < selected.ToArray().Count() - 1)
            {
                current += 1;
            }
            
            switch (CurrenCType)
            {
                case CType.Business:
                    Display( );
                    break;
                case CType.Friend:
                    Display( );
                    break;
                default:
                    Display();
                    break;
            }

        }

        /// <summary>
        /// search button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Entry[] result = Lookup(searchBox.Text) ?? null;
            string msg = "";
            if (result != null)
            {
                foreach (Entry t in result)
                    msg += $"{t.Name}'s phone number is: {t.Phone}.\n";
            }
            MessageBox.Show(msg);

        }

        /// <summary>
        /// radio button to select all contacts 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioAll_Checked(object sender, RoutedEventArgs e)
        {
            current = 0;
            CurEmail = 0;
            CurrenCType = null;
            Display();
        }

        /// <summary>
        /// friend radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="k"></param>
        private void RadioButton_Checked(object sender, RoutedEventArgs k)
        {
            current = 0;
            CurrenCType = CType.Friend;
            Display();
            CurEmail = 0;
        }

        /// <summary>
        /// business radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="K"></param>
        private void radioBusiness_Checked(object sender, RoutedEventArgs K)
        {
            current = 0;
            CurrenCType = CType.Business;
            Display();
            CurEmail = 0;
        }

        private void btnEmailNext_Click(object sender, RoutedEventArgs e)
        {
            CurEmail++;
            Display();
        }

        private void AddEmail_Click(object sender, RoutedEventArgs e)
        {
            EmailAddressForm win2 = new EmailAddressForm();
            win2.Show();
            this.Close();
        }
    }
}
