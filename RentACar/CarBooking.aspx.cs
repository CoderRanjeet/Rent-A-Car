using RentACar.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentACar
{
    public partial class CarBooking : System.Web.UI.Page
    {
        public enum MessageType { success, danger, info, warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Id = Request.QueryString["id"];
                DateTime BookingDate = Convert.ToDateTime(Request.QueryString["Bookdate"]);

                string CarId = Request.QueryString["id"];
                CarMaster edit = CarMaster.GetCarInfo(CarId);
                if (edit != null && edit.Car_Title != null)
                {
                    lblCarColor.InnerText = edit.Car_Color.ToString();
                    lblDescription.InnerText = edit.Car_Description.ToString();
                    lblCarName.InnerText = edit.Car_Title;
                    lblModelYear.InnerText = edit.Model_Year.ToString();
                    lblPrice.InnerText = edit.Price.ToString();
                    txtprice.Value = edit.Price.ToString();
                    lblSeatingCapacity.InnerText = edit.Seating_Capacity;
                    lblBrand.InnerText = edit.Brand;
                    lblFuelType.InnerText = edit.Fuel_Type;
                    txtCarName.Value = edit.Car_Title;

                    string formattedDate = BookingDate.ToString("yyyy-MM-dd hh:mm:ss");
                    txtBookDate.Value = formattedDate;

                    img1.ImageUrl = edit.Car_img1.ToString();

                    Session["CarId"] = CarId;
                }
                else
                {
                    Response.Redirect("~/Home.aspx");
                }

            }
        }

        protected void ddlHours_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Price = txtprice.Value;
            var hours = ddlHours.SelectedValue;
            if(Price !="" && hours != null)
            {
                lblTotalAmt.Text = (Convert.ToDecimal(Price) * Convert.ToDecimal(hours)).ToString();
                ShowMessage("Nice?", "Your Total Bill is +'" + lblTotalAmt.Text, MessageType.success);
            }
        }
        protected void ShowMessage(string Title, string message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "AlertMessage('" + Title + "','" + message + "','" + type + "');", true);
        }
        protected void BtnReserve_ServerClick(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                try
                {
                    CustomerMaster CM = new CustomerMaster();
                    CM.Cust_Name = txtFullName.Value;
                    CM.Email = txtEmail.Value;
                    CM.Mobile_No = txtAltMobileNo.Text;
                    CM.Password = "";
                    CM.Address = txtFullAddress.Value;
                    CM.CreatedDate = DateTime.Now;
                    CM.IsActive = true;
                    CM.Add();

                    if (CM.Cust_Id > 0)
                    {
                        BookingMaster BM = new BookingMaster();
                        BM.BookingDate = Convert.ToDateTime(txtBookDate.Value);
                        BM.CarId = Convert.ToInt32(Session["CarId"]);
                        BM.CustomerId = CM.Cust_Id;
                        BM.IsActice = true;
                        BM.BookingStatus = "Booked";
                        BM.Price = Convert.ToDecimal(txtprice.Value);
                        BM.TotalHours = Convert.ToInt32(ddlHours.SelectedValue);
                        BM.TotalPrice = Convert.ToDecimal(lblTotalAmt.Text);
                        BM.LicenseNumber = txtLicenseNo.Text;
                        BM.BookingLastDate = Convert.ToDateTime(txtBookDate.Value).AddDays(Convert.ToInt32(ddlHours.SelectedValue));
                        BM.CreatedDate = DateTime.Now;
                        BM.Add();

                        ShowMessage("Nice?", "Your Booking Successful", MessageType.success);

                        //Response.Redirect("~/Home.aspx");

                        Clear();
                    }
                }
                catch (Exception Ex)
                {
                    ShowMessage("Oops?", Ex.Message, MessageType.danger);
                }
            }
        }

        public void Clear()
        {
            txtCarName.Value = "";
            txtEmail.Value = "";
            //txtExtraHours.Text = "";
            txtFullAddress.Value = "";
            txtFullName.Value = "";
            txtAltMobileNo.Text = "";
            txtprice.Value = "";
            txtBookDate.Value = "";
            ddlHours.SelectedValue = "0";
            lblTotalAmt.Text = "";
            txtLicenseNo.Text = "";
            CheckBox1.Checked = false;
            //txtAddress.Value = "";
            //txtcpassword.Value = "";
            //txtemail.Value = "";
            //txtMobileNo.Value = "";
            //txtName.Value = "";
            //txtpassword.Value = "";
        }

        public bool ValidateFields()
        {
            bool msg = true;

            if (string.IsNullOrEmpty(txtFullName.Value))
            {
                 msg = false;
                ShowMessage("oops?", "Please Enter Name", MessageType.info);
                return msg;
            }
            if (string.IsNullOrEmpty(txtFullAddress.Value))
            {
                msg = false;
                ShowMessage("oops?", "Please Enter Address", MessageType.info);
                return msg;
            }
            if (string.IsNullOrEmpty(txtEmail.Value))
            {
                msg = false;
                ShowMessage("oops?", "Please Enter Email", MessageType.info);
                return msg;
            }
            
            if (string.IsNullOrEmpty(txtAltMobileNo.Text))
            {
                msg = false;
                ShowMessage("oops?", "Please Enter Mobile Number", MessageType.info);
                return msg;
            }
            if (ddlHours.SelectedValue == "0" ||  ddlHours.SelectedValue == "")
            {
                msg = false;
                ShowMessage("oops?", "Please Select Hours for Booking a Car", MessageType.info);
                return msg;
            }
            if (string.IsNullOrEmpty(txtLicenseNo.Text))
            {
                msg = false;
                ShowMessage("oops?", "Please enter License number", MessageType.info);
                return msg;
            }
            if (string.IsNullOrEmpty(txtCarName.Value) || string.IsNullOrEmpty(txtBookDate.Value))
            {
                msg = false;
                ShowMessage("oops?", "Something is Wrong , Go to home and book Again", MessageType.info);
                return msg;
            }

            return msg;
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            divupi.Visible = true;
            CheckBox2.Checked = false;
            divpaymentcard.Visible = false;
        }

        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            lblAmount.Text = lblTotalAmt.Text;
            divpaymentcard.Visible = true;
            divupi.Visible = false;
            CheckBox3.Checked = false;
        }

        protected void BtnUpiPayment_ServerClick(object sender, EventArgs e)
        {
            ShowMessage("oops?", "UPI option Available soon.....", MessageType.info);
            CheckBox2.Checked = false;
            divupi.Visible = false;
        }

        protected void BtnCardPayment_ServerClick(object sender, EventArgs e)
        {
            ShowMessage("oops?", "Credit card/ Debit card payment option Available soon.....", MessageType.info);
            CheckBox3.Checked = false;
            divpaymentcard.Visible = false;
        }
    }
}