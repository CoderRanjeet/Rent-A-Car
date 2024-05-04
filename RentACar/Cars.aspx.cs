using RentACar.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentACar
{
    public partial class Cars : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCars();
            }
        }
        public void GetCars()
        {
            DataTable dt = CarMaster.GetCars();
            if (dt.Rows.Count > 0)
            {
                RptCars.DataSource = dt;
                RptCars.DataBind();
            }
            else
            {
                Response.Write("No Record Found.");
            }
        }

        protected void RptCars_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Book")
            {
                var Id = Convert.ToInt32(e.CommandArgument);
                if (Id != 0)
                {
                    Response.Redirect("CarDetails.aspx?id=" + Id);
                }
            }
        }
    }
}