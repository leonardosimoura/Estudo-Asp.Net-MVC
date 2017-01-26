using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCViews.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Usuário é necessário.")]
        [StringLength(500,MinimumLength = 5, ErrorMessage = "Usuário deve ter de {0} e {1} caracteres ")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Senha é necessária.")]
        [StringLength(50,ErrorMessage = "Senha deve ter de {0} e {1} caracteres ",MinimumLength =5)]
        [Remote("RemoteValidation", "Home")]
        // No WebConfig
        //<appSettings>
        //  <add key = "ClientValidationEnabled" value="true" />
        //  <add key = "UnobtrusiveJavaScriptEnabled" value="true" />
        //</appSettings>

        public string Senha { get; set; }
    }
}