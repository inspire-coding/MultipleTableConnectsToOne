using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Tutorial
    {
        public long Id { get; set; }
        public long PostId { get; set; }
        public long? Price { get; set; }
        public string Currency { get; set; }

        public virtual Post Post { get; set; }
    }
}
