using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace waFrasesFamosas.Class
{
    public class clsFrase
    {
        public int Id { get; set; }
        public string Frase { get; set; }
        public string FKAutor { get; set; }
        public string FKCategoria { get; set; }
    }
}