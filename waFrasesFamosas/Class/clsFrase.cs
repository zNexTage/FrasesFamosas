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
        public int FKAutor { get; set; }
        public int FKCategoria { get; set; }
        public string getAutorName { get; set; }
        public string getCategoriaName { get; set; }
    }
}