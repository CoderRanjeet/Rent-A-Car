using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RentACar.DAL
{
    public class CustomerMaster
    {
       public int? Cust_Id     {get;set;}
       public string Cust_Name   {get;set;}
       public string Email       {get;set;}
       public string Password    {get;set;}
       public string Mobile_No   {get;set;}
       public string Address     {get;set;}
       public DateTime? CreatedDate { get; set; }
       public Boolean? IsActive    { get; set; }


        public void Add()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"insert into [CustomerMaster]
                                      (        
                                       [Cust_Name]       
                                      ,[Email] 
                                      ,[Password]           
                                      ,[Mobile_No]           
                                      ,[Address]  
                                      ,[CreatedDate]     
                                      ,[IsActive]       
                                       )
                                       values
                                        (                 
                                       @Cust_Name       
                                      ,@Email
                                      ,@Password           
                                      ,@Mobile_No           
                                      ,@Address                                        
                                      ,@CreatedDate     
                                      ,@IsActive                                           
                                       );";
                    Sql += "select scope_identity();";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@Cust_Name", SqlDbType.VarChar, 50).Value = Cust_Name == null ? (Object)DBNull.Value : Cust_Name;
                        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = Email == null ? (Object)DBNull.Value : Email;
                        cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = Password == null ? (Object)DBNull.Value : Password;
                        cmd.Parameters.Add("@Mobile_No", SqlDbType.VarChar, 50).Value = Mobile_No == null ? (Object)DBNull.Value : Mobile_No;
                        cmd.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = Address == null ? (Object)DBNull.Value : Address;                      
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = CreatedDate == null ? (Object)DBNull.Value : CreatedDate;
                        cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = IsActive;
                        Cust_Id = Convert.ToInt32(cmd.ExecuteScalar());
                        Con.Close();
                    }
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
        }

        public static CustomerMaster GetCustomer(int CustomerId)
        {
            CustomerMaster CME = new CustomerMaster();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"select * from [CustomerMaster] where [Cust_Id]=@Cust_Id";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@Cust_Id", SqlDbType.Int, 8).Value = CustomerId;
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (Rd.Read())
                            {
                                CME.Cust_Name = Rd["Cust_Name"] == DBNull.Value ? null : Rd["Cust_Name"].ToString();
                                CME.Address = Rd["Address"] == DBNull.Value ? null : Rd["Address"].ToString();
                                CME.Email = Rd["Email"] == DBNull.Value ? null : Rd["Email"].ToString();
                                CME.Mobile_No = Rd["Mobile_No"] == DBNull.Value ? null : Rd["Mobile_No"].ToString();
                                
                            }
                        }
                    }
                    Con.Close();
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
            return CME;
        }

        public static DataTable GetCustomers()
        {
            DataTable Dt = new DataTable();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"select * from [CustomerMaster]";

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

        public bool Delete(int CustomerId)
        {
            bool IsDelete = false;
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"delete [CustomerMaster] where [Cust_Id]=@Cust_Id";

                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@Cust_Id", SqlDbType.Int, 4).Value = CustomerId;

                        int Msg = cmd.ExecuteNonQuery();
                        if (Msg > 0)
                        {
                            IsDelete = true;
                        }
                        else
                        {
                            IsDelete = false;
                        }
                    }
                    Con.Close();
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
            return IsDelete;
        }

        public static int TotalCustomerRecords()
        {
            int records = 0;
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"SELECT COUNT(*) AS RecordCount
                                   FROM CustomerMaster;";

                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (Rd.Read())
                                records = Convert.ToInt32(Rd["RecordCount"]);
                        }
                    }
                    Con.Close();
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
            return records;
        }

        public void Update()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"update [CustomerMaster]
                                         SET
                                      [Cust_Name]=@Cust_Name,
                                      [Email]=@Email
                                      [Mobile_No]=@Mobile_No
                                      [Address]=@Address
                                      where Cust_Id =@Cust_Id";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@Cust_Name", SqlDbType.VarChar, 50).Value = Cust_Name == null ? (Object)DBNull.Value : Cust_Name;
                        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = Email == null ? (Object)DBNull.Value : Email;
                        cmd.Parameters.Add("@Mobile_No", SqlDbType.VarChar, 50).Value = Mobile_No == null ? (Object)DBNull.Value : Mobile_No;
                        cmd.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = Address == null ? (Object)DBNull.Value : Address;
                        cmd.Parameters.Add("@Cust_Id", SqlDbType.Int, 4).Value = Cust_Id;

                        int msg = Convert.ToInt32(cmd.ExecuteScalar());
                        Con.Close();
                    }
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
        }

    }
}