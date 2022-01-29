using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uCRUD.Shared
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Mjesto { get; set; }
        public string Adresa { get; set; }
        public string OIB { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
    }
}
