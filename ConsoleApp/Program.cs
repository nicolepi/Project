using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Addresses;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {


            var phone = new Phone
            {
                EntryId = 1,
                Number = "1234567",
                Type = 0
            };

            using (var db = new AddressContext())
            {
                db.Phones.Add(phone);
                db.SaveChanges();
            }


        }

        public class AddressContext : DbContext
        {
            public DbSet<Email> Emails { get; set; }
            public DbSet<Entry> Entries { get; set; }
            public DbSet<Phone> Phones { get; set; }
    }

    }
}
