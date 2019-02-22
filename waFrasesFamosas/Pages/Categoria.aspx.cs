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
    public partial class Categoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static void InserirCategoria(string Nome)
        {
            DALCategoria.Inserir(Nome);
        }
        [WebMethod]
        public static List<clsCategoria> ListarCategorias()
        {
            return DALCategoria.ListarCategorias();
        }
        [WebMethod]
        public static clsCategoria SelecionarCategoriaID(int Id)
        {
            return DALCategoria.ListarPorID(Id);
        }
        [WebMethod]
        public static void AtualizarCategoria(int Id, string Nome)
        {
            DALCategoria.Alterar(Id, Nome);
        }
        [WebMethod]
        public static void RemoverCategoria(int Id)
        {
            DALCategoria.Deletar(Id);
        }

    }
}