using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RentACar.DAL
{
    public class CostMaster
    {
        public int? CostId { get; set; }
        public string Customer_Name { get; set; }
        public string Booking_No { get; set; }
        public string Issue_Type { get; set; }
        public decimal? Charges { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Boolean? IsActive { get; set; }


        public void Add()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"insert into [CostMaster]
                                      (        
                                       [Customer_Name]       
                                      ,[Booking_No] 
                                      ,[Issue_Type]           
                                      ,[Charges]           
                                      ,[Description]  
                                      ,[CreatedDate]     
                                      ,[IsActive]       
                                       )
                                       values
                                        (                 
                                       @Customer_Name       
                                      ,@Booking_No
                                      ,@Issue_Type           
                                      ,@Charges           
                                      ,@Description                                        
                                      ,@CreatedDate     
                                      ,@IsActive                                           
                                       );";
                    Sql += "select scope_identity();";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@Customer_Name", SqlDbType.VarChar, 50).Value = Customer_Name == null ? (Object)DBNull.Value : Customer_Name;
                        cmd.Parameters.Add("@Booking_No", SqlDbType.VarChar, 50).Value = Booking_No == null ? (Object)DBNull.Value : Booking_No;
                        cmd.Parameters.Add("@Issue_Type", SqlDbType.VarChar, 50).Value = Issue_Type == null ? (Object)DBNull.Value : Issue_Type;
                        cmd.Parameters.Add("@Charges", SqlDbType.Decimal,8).Value = Charges == null ? (Object)DBNull.Value : Charges;
                        cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Description == null ? (Object)DBNull.Value : Description;
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = CreatedDate == null ? (Object)DBNull.Value : CreatedDate;
                        cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = IsActive;
                        CostId = Convert.ToInt32(cmd.ExecuteScalar());
                        Con.Close();
                    }
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
        }

        public static DataTable GetCharges()
        {
            DataTable Dt = new DataTable();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"select * from [CostMaster]";

                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            Dt.Load(Rd);
                        }
                    }
                    Con.Close();
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
            return Dt;
        }

    }
}