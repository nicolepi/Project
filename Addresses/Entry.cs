using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addresses
{
    public class Entry
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string CSZ { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public CType ContactType { get; set; }

        public Entry()
        {

        }

        public Entry(string name, string address, string csz, string phone, string email, CType contactType)
        {
            this.Name = name;
            this.Address = address;
            this.CSZ = csz;
            this.Phone = phone;
            this.Email = email;
            this.ContactType = contactType;
        }
    }

    public class Entries : List<Entry>
    {
        public Entries()
        {
            string[] names = { "Bob Anderson", "Bill Henderson", "Charlie Jones", "David King", "Bob Lincoln", "Sam Peterson", "David Roberts", "John Smith", "Steve Thompson", "Bill Williams" };
            string[] addresses = { "101 Main St", "528 W 32nd", "2938 N 39th St", "2349 E 83rd St", "200 Belmont Pl", "39434 W Smithson Rd", "861 Jones Way NE", "9483 349th St W", "333 33rd W", "1601 Pennsylvania Ave" };
            string[] cszs = { "Belmont, NC 93849", "San Francisco, CA 28348", "New York, NY 39483", "Seattle, WA 93849", "Bothell, WA 93833", "Kirkland, WA 93322", "Fargo, ND 33293", "New Orleans, LA 22393", "Miami, FL 11928", "Providence, RI 29384" };
            string[] phones = { "234-304-3290", "403-203-2956", "550-203-3948", "222-309-3093", "854-394-2293", "276-376-2273", "210-204-3948", "345-339-3904", "206-394-4488", "425-394-3933" };
            string[] emails = { "bob@anderson.com", "bill@henderson.com", "charlie@jones.com", "david@king.com", "bob@lincoln.com", "sam@peterson.com", "david@roberts.com", "john@smith.com", "steve@thompson.com", "bill@williams.com" };
            CType[] contactType =
            {
                CType.Business, CType.Friend, CType.Friend, CType.Friend, CType.Friend,
                CType.Friend, CType.Friend, CType.Friend, CType.Business, CType.Business
            };
            for (int i = 0; i < 10; i++)
            {
                Entry e = new Entry(names[i], addresses[i], cszs[i], phones[i], emails[i], contactType[i]);
                Add(e);
            }
        }
        

    }

    public enum CType
    {
        Friend,
        Business
    }

}
