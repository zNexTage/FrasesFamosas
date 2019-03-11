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
        public static string  FullPath;
        protected void Page_Load(object sender, EventArgs e)
        {
            FullPath = Server.MapPath("~/IMAGENS/AUTORES/");
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
                autor.Foto = imgFile;
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
        [WebMethod]
        public static clsAutor SelecionarPeloId(int Id)
        {
            return Autores.SelecionarPeloId(Id);
        }
       

        protected void btAlteracoes_Click(object sender, EventArgs e)
        {
            try
            {
                clsAutor obj = new clsAutor();
                obj.Id = Convert.ToInt32(Request.Form["txtEditId"]);
                obj.Nome = Request.Form["txtEditNome"];
                obj.Origem = Request.Form["txtEditOrigem"];
                string caminhoServer = Server.MapPath("~/IMAGENS/AUTORES/");
                string imgName = Path.GetFileName(editFoto.PostedFile.FileName);
                obj.Foto = Path.Combine(caminhoServer, imgName);
                editFoto.SaveAs(obj.Foto);
                obj.Foto = imgName;
                Autores dalAut = new Autores();
                dalAut.Atualizar(obj);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Atualização Realizada Com Sucesso');window.location.href='Autor.aspx';", true);
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Não foi possivel atualizar!!!');window.location.href='Autor.aspx';", true);
            }
        }
        [WebMethod]
        public static void RemoverAutor(int Id)
        {
            Autores.SelecionarPeloId(Id);
            clsAutor autor = new clsAutor();
            string deleteFile = Path.Combine(Autor.FullPath + clsAutor.pathForDelete);
            File.Delete(deleteFile);
            Autores.RemoverAutor(Id);

        }
        
    }
}