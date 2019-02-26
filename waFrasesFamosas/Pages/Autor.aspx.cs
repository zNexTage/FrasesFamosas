using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using waFrasesFamosas.Class;
using waFrasesFamosas.DAL;
namespace waFrasesFamosas.Pages
{
    public partial class Autor : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

            clsAutor autor = new clsAutor();
            autor.Nome = Request.Form["txtNome"];
            autor.Origem = Request.Form["txtOrigem"];
            if (autor.Nome == "" || autor.Origem == "" || fileFoto.HasFile == false)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "modalMessage('Aviso', 'Preencha todos os campos!!');", true);

            }
            else if (fileFoto.HasFile == true || autor.Nome != "" || autor.Origem != "")
            {
                string caminhoServer = Server.MapPath("~/IMAGENS/AUTORES/");
                string imgFile = Path.GetFileName(fileFoto.PostedFile.FileName);
                string caminho = Path.Combine(caminhoServer, imgFile);
                fileFoto.SaveAs(caminho);
                autor.Foto = "../IMAGENS/AUTORES/" + imgFile;
                Autores autores = new Autores();
                autores.Inserir(autor);
                autor.Nome = "";
                autor.Origem = "";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Cadastro Realizado');window.location.href='Autor.aspx';", true);
                

            }

        }

        [WebMethod]
        public static List<clsAutor> SelecionarAutores()
        {
            return Autores.SelecionarAutores();
        }


    }
}