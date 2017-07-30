using System.ComponentModel.DataAnnotations;

namespace Addresses
{
    using System;
    using System.Collections.Generic;

    public class Phone
    {
        [Key]
        public int Id { get; set; }
        public int EntryId { get; set; }
        public string Number { get; set; }
        public int Type { get; set; }

        public virtual Entry Entry { get; set; }

    }

    

}