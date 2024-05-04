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
    public partial class ManageBookings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetBookings();
            }
        }
        public void GetBookings()
        {
            DataTable dt = BookingMaster.GetBookings();
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


        protected void RptBooking_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                int BookId = Convert.ToInt32(e.CommandArgument.ToString());
                DropDownList selectList = e.Item.FindControl("ddlstatus") as DropDownList;
                var status = selectList.SelectedItem.Text;
                if(selectList.SelectedValue == "0")
                {
                    Response.Write("<script language='javascript'>alert('Please Select Status');</" + "script>");
                }
                else
                {
                    BookingMaster BM = new BookingMaster();
                    if(status == "Returned")
                    {
                        BM.ReturnDate = DateTime.Now;
                    }
                    BM.BookingStatus = status;
                    BM.BookingId = BookId;
                    BM.Update();
                    GetBookings();
                }

            }
        }
    }
}