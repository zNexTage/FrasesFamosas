using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace waFrasesFamosas.Class
{
    public class clsUsuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool ChecarEmail { get; set; }
    }
}