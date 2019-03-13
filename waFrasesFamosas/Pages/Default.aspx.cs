using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using waFrasesFamosas.Class;
using waFrasesFamosas.DAL;
namespace waFrasesFamosas
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Id"] != null)
                {
                    if (Convert.ToInt32(Session["TIPO_USUARIO"]) == 0)
                    {

                        clsUsuario Usuario = new clsUsuario();
                        Usuario.Id = Convert.ToInt32(Session["Id"]);
                        Usuario = DALUsuario.ListarPorID(Usuario);
                        lblNomeUsuario.Text = Usuario.Nome;
                    }
                }
            }
            catch
            {
                Response.Redirect("~/Login.aspx");
            }

        }

    }
}