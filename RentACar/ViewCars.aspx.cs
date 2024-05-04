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
    public partial class ViewCars : System.Web.UI.Page
    {
        public enum MessageType { success, danger, info, warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCars();
            }
        }

        public void GetCars()
        {
            DataTable dt = CarMaster.GetCars();
            if(dt.Rows.Count > 0)
            {
                RptCars.DataSource = dt;
                RptCars.DataBind();
            }
            else
            {
                Response.Write("No Record Found.");
            }
        }
        protected void ShowMessage(string Title, string message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "AlertMessage('" + Title + "','" + message + "','" + type + "');", true);
        }
        protected void RptCars_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                var Id = Convert.ToInt32(e.CommandArgument);
                if (Id != 0)
                {
                    Response.Redirect("EditCar.aspx?id=" + Id);
                }
            }
            else if (e.CommandName == "Delete")
            {
                var Id = Convert.ToInt32(e.CommandArgument);

                if (Id != 0)
                {
                    BrandMaster del = new BrandMaster();
                    bool IsDeleted = del.Delete(Id);
                    if (IsDeleted)
                    {
                        //Response.Write("<script>alert('Deleted SuccessFully.');</script>");
                        ShowMessage("Awsome?", "Deleted SuccessFully.", MessageType.success);
                        GetCars();
                    }
                }
            }
        }
    }
}