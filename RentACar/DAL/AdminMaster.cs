using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RentACar.DAL
{
    public class AdminMaster
    {
        public int? Adm_Id { get; set; }
        public string Admin_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile_No { get; set; }
        public string Address { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Boolean? IsActive { get; set; }


        public void Add()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"insert into [AdminMaster]
                                      (        
                                       [Admin_Name]       
                                      ,[Email] 
                                      ,[Password]           
                                      ,[Mobile_No]           
                                      ,[Address]  
                                      ,[CreatedDate]     
                                      ,[IsActive]       
                                       )
                                       values
                                        (                 
                                       @Admin_Name       
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
                        cmd.Parameters.Add("@Admin_Name", SqlDbType.VarChar, 50).Value = Admin_Name == null ? (Object)DBNull.Value : Admin_Name;
                        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = Email == null ? (Object)DBNull.Value : Email;
                        cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = Password == null ? (Object)DBNull.Value : Password;
                        cmd.Parameters.Add("@Mobile_No", SqlDbType.VarChar, 50).Value = Mobile_No == null ? (Object)DBNull.Value : Mobile_No;
                        cmd.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = Address == null ? (Object)DBNull.Value : Address;
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = CreatedDate == null ? (Object)DBNull.Value : CreatedDate;
                        cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = IsActive;
                        cmd.ExecuteNonQuery();
                        Con.Close();
                    }
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
        }
        public static AdminMaster ValidateUser(string email)
        {
            AdminMaster TblApt = new AdminMaster();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"select Admin_Name,Email,Password from [AdminMaster] where [Email]=@email";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = email;
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (Rd.Read())
                            {
                                TblApt.Password = Rd["Password"] == DBNull.Value ? null : Rd["Password"].ToString();
                                TblApt.Email = Rd["Email"] == DBNull.Value ? null : Rd["Email"].ToString();
                                TblApt.Admin_Name = Rd["Admin_Name"] == DBNull.Value ? null : Rd["Admin_Name"].ToString();
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
            return TblApt;
        }

    }
}