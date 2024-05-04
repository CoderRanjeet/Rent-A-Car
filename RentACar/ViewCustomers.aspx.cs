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
    public partial class ViewCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCustomers();
            }
        }

        public void GetCustomers()
        {
            DataTable dt = CustomerMaster.GetCustomers();
            RptCustomers.DataSource = dt;
            RptCustomers.DataBind();
        }
    }
}