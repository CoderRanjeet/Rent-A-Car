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
    public partial class CustBookingData : System.Web.UI.Page
    {
        public enum MessageType { success, danger, info, warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
        protected void ShowMessage(string Title, string message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "AlertMessage('" + Title + "','" + message + "','" + type + "');", true);
        }
        protected void RptBooking_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                string[] arguments = e.CommandArgument.ToString().Split(',');
                int BookId = Convert.ToInt32(arguments[0]);
                DateTime BookingDate = Convert.ToDateTime(arguments[1]);

                TimeSpan Time = DateTime.Now - BookingDate;

                var tt = Time.TotalHours;
                if(tt >= 24 && tt != 0)
                {
                    ShowMessage("oops?", "Booking Date is more than 24 hrs", MessageType.info);
                }
                else
                {
                    BookingMaster BM1 = BookingMaster.GetBookingStatus(BookId);
                    if(BM1.BookingStatus != "Booked")
                    {
                        ShowMessage("oops?", "Your booking status is '"+ BM1.BookingStatus + "'. you can change status until status is Booked.", MessageType.info);
                    }
                    else
                    {
                        BookingMaster BM = new BookingMaster();
                        BM.BookingStatus = "Cancel";
                        BM.BookingId = BookId;
                        BM.Update();
                        var email = txtemail.Value;
                        GetData(email);
                    }
                }
            }
        }

        protected void BtnGetData_Click(object sender, EventArgs e)
        {
            var email = txtemail.Value;
            GetData(email);
        }
        public void GetData(string email)
        {
            DataTable dt = BookingMaster.GetBookings(email);
            if (dt.Rows.Count > 0)
            {
                RptBooking.DataSource = dt;
                RptBooking.DataBind();
            }
            else
            {
                Response.Write("No Record Found.");
            }
        }
    }
}