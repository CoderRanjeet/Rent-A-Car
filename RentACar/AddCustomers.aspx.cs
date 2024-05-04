using RentACar.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentACar
{
    public partial class AddCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void BtnSubmit_ServerClick(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                CustomerMaster CM = new CustomerMaster();
                CM.Cust_Name = txtName.Value;
                CM.Email = txtemail.Value;
                CM.Mobile_No = txtMobileNo.Value;
                CM.Password = txtpassword.Value;
                CM.Address = txtAddress.Value;
                CM.CreatedDate = DateTime.Now;
                CM.IsActive = true;
                CM.Add();

                Clear();
               
            }
        }
        protected void BtnReset_ServerClick(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txtAddress.Value = "";
            txtcpassword.Value = "";
            txtemail.Value = "";
            txtMobileNo.Value = "";
            txtName.Value = "";
            txtpassword.Value = "";
        }

        public bool ValidateFields()
        {
            bool msg = true;

            if (string.IsNullOrEmpty(txtAddress.Value))
            {

            }
            if (string.IsNullOrEmpty(txtcpassword.Value))
            {

            }
            if (string.IsNullOrEmpty(txtemail.Value))
            {

            }
            if (string.IsNullOrEmpty(txtMobileNo.Value))
            {

            }
            if (string.IsNullOrEmpty(txtName.Value))
            {

            }
            if (string.IsNullOrEmpty(txtpassword.Value))
            {

            }
            if (txtpassword.Value != txtcpassword.Value)
            {

            }
           
            return msg;
        }
    }
}