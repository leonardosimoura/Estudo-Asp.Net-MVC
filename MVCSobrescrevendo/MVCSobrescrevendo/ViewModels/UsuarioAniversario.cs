using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSobrescrevendo.ViewModels
{
    public class UsuarioAniversario
    {
        [Display(Name = "Usuário")]
        public string Usuario { get; set; }
        [Display(Name = "Data Aniversário")]
        [DisplayFormat(DataFormatString = "{0:d}")] // dd/MM/yyyy
        public DateTime DataAniversario { get; set; }
    }
}