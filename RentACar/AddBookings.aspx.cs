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
    public partial class AddBookings : System.Web.UI.Page
    {
        public enum MessageType { success, danger, info, warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtBookDate.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");

                DataTable dt = BrandMaster.GetBrands();
                ddlBrand.DataSource = dt;
                ddlBrand.DataTextField = "BrandName";
                ddlBrand.DataValueField = "BrandId";
                ddlBrand.DataBind();
                ddlBrand.Items.Insert(0, new ListItem("-- Select Brand --", string.Empty));
            }
        }

        protected void BtnSubmit_ServerClick(object sender, EventArgs e)
        {
            string checkDate = txtBookDate.Value;
            string CarId = (ddlCars.SelectedValue);

            BookingMaster mb = BookingMaster.GetBookedInfo(CarId, checkDate);
            if (mb.BookingStatus == "Booked" || mb.BookingStatus == "Rented Out")
            {
                ShowMessage("oops?", "this Car already Booked by Another Person", MessageType.info);
                //lblMsg.Text = "oops? this Car already Booked by Another Person";
            }
            else
            {
                if (ValidateFields())
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
                        BM.CarId = Convert.ToInt32(ddlCars.SelectedValue);
                        BM.CustomerId = CM.Cust_Id;
                        BM.IsActice = true;
                        BM.BookingStatus = "Booked";
                        BM.Price = Convert.ToDecimal(txtprice.Value);
                        BM.TotalHours = Convert.ToInt32(ddlHours.SelectedValue);
                        BM.TotalPrice = Convert.ToDecimal(txtTotalAmt.Value);
                        BM.LicenseNumber = txtLicenseNo.Text;
                        BM.BookingLastDate = Convert.ToDateTime(txtBookDate.Value).AddDays(Convert.ToInt32(ddlHours.SelectedValue));
                        BM.CreatedDate = DateTime.Now;
                        BM.Add();

                        ShowMessage("Nice?", "Your Booking Successful", MessageType.success);

                        Clear();
                    }
                    Clear();
                }
            }
        }
        protected void ShowMessage(string Title, string message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "AlertMessage('" + Title + "','" + message + "','" + type + "');", true);
        }
        protected void ddlHours_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Price = txtprice.Value;
            var hours = ddlHours.SelectedValue;
            if (Price != "" && hours != null)
            {
                txtTotalAmt.Value = (Convert.ToDecimal(Price) * Convert.ToDecimal(hours)).ToString();
                ShowMessage("Nice?", "Your Total Bill is +'" + txtTotalAmt.Value, MessageType.success);
            }
        }
        protected void BtnReset_ServerClick(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            ddlBrand.SelectedValue = "";
            txtEmail.Value = "";
            ddlCars.SelectedValue = "";
            txtFullAddress.Value = "";
            txtFullName.Value = "";
            txtAltMobileNo.Text = "";
            txtprice.Value = "";
            txtBookDate.Value = "";
            ddlHours.SelectedValue = "0";
            txtTotalAmt.Value= "";
            txtLicenseNo.Text = "";
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
            if (ddlHours.SelectedValue == "0" || ddlHours.SelectedValue == "")
            {
                msg = false;
                ShowMessage("oops?", "Please Select Days for Booking a Car", MessageType.info);
                return msg;
            }
            if (string.IsNullOrEmpty(txtLicenseNo.Text))
            {
                msg = false;
                ShowMessage("oops?", "Please enter License number", MessageType.info);
                return msg;
            }
            if (/*string.IsNullOrEmpty(txtCarName.Value) ||*/ string.IsNullOrEmpty(txtBookDate.Value))
            {
                msg = false;
                ShowMessage("oops?", "Something is Wrong , Go to home and book Again", MessageType.info);
                return msg;
            }

            return msg;
        }

        protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Brand = ddlBrand.SelectedItem.Text;
            if (ddlBrand.SelectedValue != "0")
            {
                DataTable dt = CarMaster.GetCarsDetails(Brand);
                ddlCars.DataSource = dt;
                ddlCars.DataTextField = "Car_Title";
                ddlCars.DataValueField = "CarId";
                ddlCars.DataBind();
                ddlCars.Items.Insert(0, new ListItem("-- Select Car --", string.Empty));
            }
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            divupi.Visible = true;
            CheckBox2.Checked = false;
            divpaymentcard.Visible = false;
        }

        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
           // lblAmount.Text = lblTotalAmt.Text;
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

        protected void ddlCars_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Brand = ddlCars.SelectedItem.Text;
            if (ddlBrand.SelectedValue != "0")
            {
                CarMaster dt = CarMaster.GetCarPrice(Brand);
                if(dt != null)
                {
                    txtprice.Value = dt.Price.ToString();
                }
            }
        }
    }
}