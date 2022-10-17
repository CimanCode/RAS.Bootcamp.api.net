using System;
using System.Collections.Generic;

namespace RAS.Bootcamp.api.net.Datas.Entities
{
    public partial class Penjual
    {

        public int IdPenjual { get; set; }
        public int IdUser { get; set; }
        public string? NamaToko { get; set; }
        public string? Alamat { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<Barang> Barangs { get; set; }
    }
}
