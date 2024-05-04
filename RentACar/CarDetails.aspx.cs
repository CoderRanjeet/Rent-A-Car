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
    public partial class CarDetails : System.Web.UI.Page
    {
        public enum MessageType { success, danger, info, warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime tomorrow = DateTime.Now.AddDays(1);
                txtBookDate.Attributes["min"] = tomorrow.ToString("yyyy-MM-dd");

                string CarId = Request.QueryString["id"];
                CarMaster edit = CarMaster.GetCarInfo(CarId);
                if (edit != null && edit.Car_Title !=null)
                {
                    lblCarColor.InnerText = edit.Car_Color.ToString();
                    lblDescription.InnerText = edit.Car_Description.ToString();
                    lblCarName.InnerText = edit.Car_Title;
                    lblModelYear.InnerText = edit.Model_Year.ToString();
                    //txtprice.Value = edit.Price.ToString();
                    lblSeatingCapacity.InnerText = edit.Seating_Capacity;
                    lblBrand.InnerText = edit.Brand;
                    lblFuelType.InnerText = edit.Fuel_Type;

                    img1.ImageUrl = edit.Car_img1.ToString();
                    img2.ImageUrl = edit.Car_img2.ToString();
                    img3.ImageUrl = edit.Car_img3.ToString();

                    Session["CarId"] = CarId;
                }

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

        protected void BtnBooking_ServerClick(object sender, EventArgs e)
        {
            string CarId =  Session["CarId"].ToString();
            string checkDate = txtBookDate.Value;

            BookingMaster mb = BookingMaster.GetBookedInfo(CarId,checkDate);

            if (mb.BookingStatus == "Booked" || mb.BookingStatus == "Rented Out")
            {
                ShowMessage("oops?", "this Car already Booked by Another Person", MessageType.info);
                //lblMsg.Text = "oops? this Car already Booked by Another Person";
            }
            else
            {
                //lblMsg.Text = "Congrats ? this Car Available for Booking.";
                Response.Redirect(string.Format("~/CarBooking.aspx?id={0}&Bookdate={1}", CarId, checkDate));
               // Response.Redirect("CarBooking.aspx?id=" + CarId);
            }
        }


        protected void ShowMessage(string Title, string message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "AlertMessage('" + Title + "','" + message + "','" + type + "');", true);
        }
    }
}