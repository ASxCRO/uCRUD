using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uCRUD.Shared
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "Maximalno 16 znakova")]
        public string Ime { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "Maximalno 16 znakova")]
        public string Prezime { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Maximalno 30 znakova")]
        public string Mjesto { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Maximalno 30 znakova")]
        public string Adresa { get; set; }

        [Required]
        [MinLength(11, ErrorMessage = "Minimalno 11 znakova")]
        [MaxLength(11, ErrorMessage = "Maximalno 11 znakova")]
        public string OIB { get; set; }

        [Required]
        [Phone(ErrorMessage = "Unesite ispravni broj telefona")]
        public string Telefon { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Unesite ispravnu email adresu")]
        public string Mail { get; set; }
    }
}
