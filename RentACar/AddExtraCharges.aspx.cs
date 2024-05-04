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
    public partial class AddExtraCharges : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = CostMaster.GetCharges();
                RptCharges.DataSource = dt;
                RptCharges.DataBind();
            }
        }

        protected void BtnSubmit_ServerClick(object sender, EventArgs e)
        {
            CostMaster CM = new CostMaster();
            CM.Customer_Name = txtCustName.Value;
            CM.Booking_No = txtBookingNo.Value;
            CM.Charges = Convert.ToDecimal(txtCharges.Value);
            CM.Description = txtDescription.Value;
            CM.Issue_Type = ddlIssueType.SelectedValue;
            CM.IsActive = true;
            CM.CreatedDate = DateTime.Now;
            CM.Add();
            if(CM.CostId > 0)
            {
                Clear();
            }
        }

        protected void BtnReset_ServerClick(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txtBookingNo.Value = "";
            txtCharges.Value = "";
            txtCustName.Value = "";
            txtDescription.Value = "";
        }
    }
}