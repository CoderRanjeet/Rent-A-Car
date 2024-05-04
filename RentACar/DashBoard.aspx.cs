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
    public partial class DashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCars();
                GetBookings();
                GetCustomers();
                lblTotalCars.Text = CarMaster.TotalCarRecords().ToString();
                lblAllCustomers.Text = CustomerMaster.TotalCustomerRecords().ToString();
                lblAllBookings.Text = BookingMaster.TotalBookingRecords().ToString();
                lblMonthBookings.Text = BookingMaster.MonthBookingRecords().ToString();
            }
        }
        public void GetCars()
        {
            DataTable dt = CarMaster.GetCars();
            if (dt.Rows.Count > 0)
            {
                dt = dt.AsEnumerable().Take(5).CopyToDataTable();
                RptCars.DataSource = dt;
                RptCars.DataBind();
            }
            else
            {
                Response.Write("No Record Found.");
            }
        }

        public void GetBookings()
        {
            DataTable dt = BookingMaster.GetBookings();
            if (dt.Rows.Count > 0)
            {
                dt = dt.AsEnumerable().Take(5).CopyToDataTable();
                RptBookings.DataSource = dt;
                RptBookings.DataBind();
            }
            else
            {
                Response.Write("No Record Found.");
            }
        }

        public void GetCustomers()
        {
            DataTable dt = CustomerMaster.GetCustomers();
            if (dt.Rows.Count > 0)
            {
                dt = dt.AsEnumerable().Take(5).CopyToDataTable();
                RptCustomers.DataSource = dt;
                RptCustomers.DataBind();
            }
            else
            {
                Response.Write("No Record Found.");
            }
           
        }

        protected void SeeCustomers_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ViewCustomers.aspx");
        }

        protected void SeeBookings_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ManageBookings.aspx");
        }

        protected void SeeCars_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ViewCars.aspx");
        }
    }
}