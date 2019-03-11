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
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static bool ChecarEmail(clsUsuario Usuario)
        {
            return DALUsuario.ChecarEmail(Usuario);
        }
        [WebMethod]
        public static void CadastrarUsuario(clsUsuario Usuario)
        {           
            DALUsuario.Inserir(Usuario);
        }
        [WebMethod]
        public static List<clsUsuario> SelecionarUsuarios()
        {
            return DALUsuario.Listar();
        }
        [WebMethod]
        public static clsUsuario SelecionarUsuarioPeloID(clsUsuario Usuario)
        {
            return DALUsuario.ListarPorID(Usuario);
        }
        [WebMethod]
        public static void AtualizarUsuario(clsUsuario Usuario)
        {
            DALUsuario.AtualizarUsuario(Usuario);
        }
        [WebMethod]
        public static void RemoverUsuario(clsUsuario Usuario)
        {
            DALUsuario.RemoverUsuario(Usuario);
        }

    }
}