using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentACar
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["name"] != null)
                {
                    lblAdmin.InnerText = Session["name"].ToString();
                    lblAdminName.InnerText = Session["name"].ToString();
                }
            }
        }

        protected void BtnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLogin.aspx");
        }
    }
}