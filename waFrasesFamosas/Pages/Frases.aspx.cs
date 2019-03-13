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
            try
            {
                if (Session["Id"] != null)
                {

                }
            }
            catch
            {
                Response.Redirect("~/Login.aspx");
            }
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
        [WebMethod]
        public static void InserirFrase(string Frase, int FKAutor, int FKCategoria)
        {
             DALFrases.InserirFrase(Frase, FKAutor, FKCategoria);
        }
        [WebMethod]
        public static List<clsFrase> SelecionarFrases()
        {
            return DALFrases.SelecionarFrases();
        }
        [WebMethod]
        public static clsFrase SelecionarPeloId(int Id)
        {
            return DALFrases.SelecionarPeloId(Id);
        }
        [WebMethod]
        public static void AtualizarFrase(int Id, string Frase, string FKAutor, string FKCategoria)
        {
            DALFrases.AtualizarFrase(Id, Frase, FKAutor, FKCategoria);
        }
        [WebMethod]
        public static void RemoverFrase(int Id)
        {
            DALFrases.RemoverFrase(Id);
        }
    }
}