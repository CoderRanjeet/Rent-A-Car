using RentACar.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentACar
{
    public partial class AddCars : System.Web.UI.Page
    {
        public enum MessageType { success, danger, info, warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            if (ValidateFields())
            {
                try
                {
                    CarMaster CM = new CarMaster();
                    CM.Car_Title = txtCarTitle.Value;
                    CM.Car_Description = txtCarDesc.Value;
                    CM.Price = Convert.ToDecimal(txtPrice.Value);
                    CM.Brand = ddlBrand.SelectedItem.Text;
                    CM.Car_Color = txtCarColor.Value;
                    CM.CreatedDate = DateTime.Now;
                    CM.Fuel_Type = ddlFuelType.SelectedValue;
                    CM.Is_Active = true;
                    CM.Model_Year = Convert.ToInt32(txtModelYear.Value);
                    CM.Seating_Capacity = txtSeatingType.Value;

                    var filename = (txtCarImg1.PostedFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/"), filename);
                    txtCarImg1.PostedFile.SaveAs(path);
                    var image = "Images/" + filename;
                    CM.Car_img1 = image;

                    var filename1 = (txtCarImg2.PostedFile.FileName);
                    var path1 = Path.Combine(Server.MapPath("~/Images/"), filename1);
                    txtCarImg2.PostedFile.SaveAs(path1);
                    var image1 = "Images/" + filename1;
                    CM.Car_img2 = image1;

                    var filename2 = (txtCarImg3.PostedFile.FileName);
                    var path2 = Path.Combine(Server.MapPath("~/Images/"), filename2);
                    txtCarImg3.PostedFile.SaveAs(path2);
                    var image2 = "Images/" + filename2;
                    CM.Car_img3 = image2;

                    CM.Add();
                    ShowMessage("Nice?", "Data Added Successfully", MessageType.success);
                    Clear();
                    
                }
                catch(Exception Ex)
                {
                    ShowMessage("Oops?", Ex.Message, MessageType.info);
                }
            }
        }
        protected void ShowMessage(string Title, string message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "AlertMessage('" + Title + "','" + message + "','" + type + "');", true);
        }
        protected void BtnReset_ServerClick(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txtCarColor.Value = "";
            txtCarDesc.Value = "";
            //txtCarImg1.Value = "";
            //txtCarImg2.Value = "";
            txtCarTitle.Value = "";
            txtModelYear.Value = "";
            txtPrice.Value = "";
            txtSeatingType.Value = "";
            ddlBrand.SelectedValue = "";
            ddlFuelType.SelectedValue = "0";
        }
        public bool ValidateFields()
        {
            bool msg = true;

            if (string.IsNullOrEmpty(txtCarTitle.Value))
            {
                msg = false;
                ShowMessage("oops?", "Please Enter Car Name", MessageType.info);
                return msg;
            }
            if (string.IsNullOrEmpty(txtCarColor.Value))
            {
                msg = false;
                ShowMessage("oops?", "Please Enter Car Color", MessageType.info);
                return msg;
            }
            if (string.IsNullOrEmpty(txtCarDesc.Value))
            {
                msg = false;
                ShowMessage("oops?", "Please Enter Car Description", MessageType.info);
                return msg;
            }
            if (string.IsNullOrEmpty(txtModelYear.Value))
            {
                msg = false;
                ShowMessage("oops?", "Please Enter Model Year", MessageType.info);
                return msg;

            }
            if (string.IsNullOrEmpty(txtPrice.Value))
            {
                msg = false;
                ShowMessage("oops?", "Please Enter Price", MessageType.info);
                return msg;
            }
            if (string.IsNullOrEmpty(txtSeatingType.Value))
            {
                msg = false;
                ShowMessage("oops?", "Please Enter Seating Type", MessageType.info);
                return msg;
            }
            if (string.IsNullOrEmpty(ddlBrand.SelectedValue))
            {
                msg = false;
                ShowMessage("oops?", "Please Select Brand", MessageType.info);
                return msg;
            }
            if (string.IsNullOrEmpty(ddlFuelType.SelectedValue))
            {
                msg = false;
                ShowMessage("oops?", "Please Select Fuel Type", MessageType.info);
                return msg;
            }
          
            return msg;
        }

       
    }
}