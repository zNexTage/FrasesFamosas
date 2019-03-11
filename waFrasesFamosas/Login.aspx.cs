using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using waFrasesFamosas.Class;
using waFrasesFamosas.DAL;
namespace waFrasesFamosas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            clsUsuario Usuario = new clsUsuario();
            Usuario.Email = Request.Form["login"];
            Usuario.Senha = Request.Form["senha"];
            if (Usuario.Email == "" || Usuario.Senha == "")
            {
                Response.Write("<script>alert('Preencha todos os campos');window.location.href='Login.aspx'</script>");
            }
            else
            {
                var x = DALUsuario.Logar(Usuario);
                if (x.Id != 0)
                {
                    Session["Id"] = x.Id;                    
                    Response.Redirect("Pages/Default.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Usuário não encontrado, verifique as credenciais digitadas!!');window.location.href='Login.aspx'</script>");
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "", "modalMessage('Aviso', 'Usuário não encontrado, verifique as credenciais digitadas!!');", true);
                }
            }
        }
    }
}