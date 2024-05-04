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
    public partial class RentedCars : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetBookings();
            }
        }
        public void GetBookings()
        {
            DataTable dt = BookingMaster.GetOldBookings();
            if (dt.Rows.Count > 0)
            {
                RptOldBookings.DataSource = dt;
                RptOldBookings.DataBind();
            }
            else
            {
                Response.Write("No Record Found.");
            }
        }
    }
}