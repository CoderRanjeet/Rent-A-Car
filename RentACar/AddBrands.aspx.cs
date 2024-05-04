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
    public partial class AddBrands : System.Web.UI.Page
    {
        public enum MessageType { success, danger, info, warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetBrands();
            }
        }

        protected void BtnSubmit_ServerClick(object sender, EventArgs e)
        {
            if(Session["Id"] != null)
            {
                int Id = Convert.ToInt32(Session["Id"]);

                BrandMaster BMP = new BrandMaster
                {
                    BrandId = Id,
                    BrandName = txtBrand.Value,
                    CreatedDate = DateTime.Now
                };
                BMP.Update();
                GetBrands();
                Clear();
                ShowMessage("Nice?", "Data Updated Successfully", MessageType.success);
                BtnSubmit.InnerText = "Submit";
                Session["Id"] = null;
                Session.Remove("Id");
            }
            else
            {
                BrandMaster BM = new BrandMaster
                {
                    BrandName = txtBrand.Value,
                    CreatedDate = DateTime.Now
                };
                BM.Add();
                ShowMessage("Nice?", "Data Added Successfully", MessageType.success);
                Clear();
                GetBrands();
            }
        }

        protected void BtnReset_ServerClick(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txtBrand.Value = "";
        }
        protected void ShowMessage(string Title, string message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "AlertMessage('" + Title + "','" + message + "','" + type + "');", true);
        }
        protected void RptBrands_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                var Id = Convert.ToInt32(e.CommandArgument);
                if (Id != 0)
                {
                    BrandMaster edit = BrandMaster.GetBrand(Id);
                    if (edit != null)
                    {
                        txtBrand.Value = edit.BrandName.ToString();
                        BtnSubmit.InnerText = "Update";
                          Session["Id"] = Id;
                    }
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
                        GetBrands();
                    }
                }
            }
        }

        public void GetBrands()
        {
            DataTable dt = BrandMaster.GetBrands();
            RptBrands.DataSource = dt;
            RptBrands.DataBind();
        }
    }
}