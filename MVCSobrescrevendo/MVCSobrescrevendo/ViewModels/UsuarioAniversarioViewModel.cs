using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSobrescrevendo.ViewModels
{
    public class UsuarioAniversarioViewModel
    {
        [Display(Name = "Usuário")]
        public string Usuario { get; set; }

        [Display(Name = "Data Aniversário")]
        [DisplayFormat(DataFormatString = "{0:d}")] // dd/MM/yyyy
        public DateTime DataAniversario { get; set; }

        [Display(Name = "Enviar Notificação")]
        public bool EnviarNotificacao { get; set; }
        public SelectList EnviarNotificacaoList { get; set; }
    }
}