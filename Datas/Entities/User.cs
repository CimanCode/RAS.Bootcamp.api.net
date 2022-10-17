using System;
using System.Collections.Generic;

namespace RAS.Bootcamp.api.net.Datas.Entities
{
    public partial class User
    {
        public User()
        {
            Pembelies = new HashSet<Pembely>();
            Penjuals = new HashSet<Penjual>();
        }

        public int IdUser { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int NoHandPhone { get; set; }
        public string? Tipe { get; set; }

        public virtual ICollection<Pembely> Pembelies { get; set; }
        public virtual ICollection<Penjual> Penjuals { get; set; }
    }
}
