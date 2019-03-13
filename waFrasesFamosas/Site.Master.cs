using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace waFrasesFamosas
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Session["Id"]) == 0 )
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}