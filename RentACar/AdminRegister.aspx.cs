using RentACar.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentACar
{
    public partial class AdminRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

       
        protected void BtnCreate_ServerClick(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                AdminMaster CM = new AdminMaster();
                CM.Admin_Name = txtName.Value;
                CM.Email = txtEmail.Value;
                CM.Mobile_No = txtMobileNo.Value;
                CM.Password = txtPassword.Value;
                CM.Address = txtAddress.Value;
                CM.CreatedDate = DateTime.Now;
                CM.IsActive = true;
                CM.Add();

                Clear();

            }
        }

        public void Clear()
        {
            txtAddress.Value = "";
            txtPassword.Value = "";
            txtEmail.Value = "";
            txtMobileNo.Value = "";
            txtName.Value = "";
            
        }

        public bool ValidateFields()
        {
            bool msg = true;

            if (string.IsNullOrEmpty(txtAddress.Value))
            {

            }
           
            if (string.IsNullOrEmpty(txtEmail.Value))
            {

            }
            if (string.IsNullOrEmpty(txtMobileNo.Value))
            {

            }
            if (string.IsNullOrEmpty(txtName.Value))
            {

            }
            if (string.IsNullOrEmpty(txtPassword.Value))
            {

            }
            
            return msg;
        }
    }
}