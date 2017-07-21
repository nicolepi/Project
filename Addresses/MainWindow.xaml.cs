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
        public Entries AddressList = new Entries();
        
        public CType? CurrenCType;

        public int current = 0;
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
                in AddressList
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
            Entry e = AddressList[current];
            tbName.Text = e.Name;
            tbAddress.Text = e.Address;
            tbCSZ.Text = e.CSZ;
            tbPhone.Text = e.Phone;
            tbEmail.Text = e.Email;
            tbContactType.Text = e.ContactType.ToString();
        }

        /// <summary>
        /// display entries in a certain type
        /// </summary>
        /// <param name="type"></param>
        public void Display(CType type)
        {

            var selected = AddressList.Where(en => en.ContactType == type);
            Entry[] sorted = selected.ToArray();                   
            Entry e = sorted[current];
            tbName.Text = e.Name;
            tbAddress.Text = e.Address;
            tbCSZ.Text = e.CSZ;
            tbPhone.Text = e.Phone;
            tbEmail.Text = e.Email;
            tbContactType.Text = e.ContactType.ToString();
        }

        /// <summary>
        /// button to go to start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            current = 0;
            switch (CurrenCType)
            {
                case CType.Business:
                    Display(CType.Business);
                    break;
                case CType.Friend:
                    Display(CType.Friend);
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
            current = AddressList.ToArray().Count() - 1;
            if (CurrenCType != null)
            {
                var selected = AddressList.Where(K => K.ContactType == CurrenCType);
                current = selected.ToArray().Count() - 1;
            }
           


            switch (CurrenCType)
            {
                case CType.Business:                    
                    Display(CType.Business);
                    break;
                case CType.Friend:
                    Display(CType.Friend);
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
            if(current >0)
            {
                current -= 1;
            }
            switch (CurrenCType)
            {
                case CType.Business:
                    Display(CType.Business);
                    break;
                case CType.Friend:
                    Display(CType.Friend);
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
            var selected = from en in AddressList select en;
            if (CurrenCType != null)
            {
                selected = AddressList.Where(K => K.ContactType == CurrenCType);

            }
            if (current < selected.ToArray().Count() - 1)
            {
                current += 1;
            }
            
            switch (CurrenCType)
            {
                case CType.Business:
                    Display(CType.Business);
                    break;
                case CType.Friend:
                    Display(CType.Friend);
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
            Display(CType.Friend);
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
            Display(CType.Business);
        }
    }
}
