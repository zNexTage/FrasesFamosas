using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using waFrasesFamosas.Class;
using waFrasesFamosas.DAL;
namespace waFrasesFamosas.Pages
{
    public partial class Frases : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<clsAutor> SelecionarAutores()
        {
            return Autores.SelecionarAutores();
        }
        [WebMethod]
        public static List<clsCategoria> SelecionarCategorias()
        {
            return DALCategoria.ListarCategorias();
        }
    }
}