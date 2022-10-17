using System;
using System.Collections.Generic;

namespace RAS.Bootcamp.api.net.Datas.Entities
{
    public partial class RequestBarang
    {
        public int Code { get; set; }
        public string Nama { get; set; }
        public string Description { get; set; }
        public decimal Harga { get; set; }
        public int Stok { get; set; }
        public int IdPenjual { get; set; }

    }
}