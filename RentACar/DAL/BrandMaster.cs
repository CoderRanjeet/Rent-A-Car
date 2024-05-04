using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RentACar.DAL
{
    public class BrandMaster
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public DateTime? CreatedDate { get; set; }

        public void Add()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"insert into [BrandMaster]
                                      (
                                       [BrandName]                     
                                     , [CreatedDate]
                                       )
                                       values
                                        (
                                       @BrandName                                                                          
                                     , @CreatedDate                                
                                       );";
                    Sql += "select scope_identity();";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@BrandName", SqlDbType.NVarChar, 50).Value = BrandName == null ? (Object)DBNull.Value : BrandName;
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = CreatedDate == null ? (Object)DBNull.Value : CreatedDate;
                        cmd.ExecuteNonQuery();
                        Con.Close();
                    }
                }
            }
            catch (Exception Ex)
            {
                // throw new Exception(Ex.Message);
                var msg = Ex.Message;
            }
        }

        
        public static BrandMaster GetBrand(int BrandId)
        {
            BrandMaster BM = new BrandMaster();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"select * from [BrandMaster] where [BrandId]=@BrandId";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@BrandId", SqlDbType.Int,8).Value = BrandId;
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (Rd.Read())
                            {
                                BM.BrandName = Rd["BrandName"] == DBNull.Value ? null : Rd["BrandName"].ToString();
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
            return BM;
        }

        public static DataTable GetBrands()
        {
            DataTable Dt = new DataTable();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"select * from [BrandMaster]";

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

        public bool Delete(int BookId)
        {
            bool IsDelete = false;
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"delete [BrandMaster] where [BrandId]=@BrandId";

                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@BrandId", SqlDbType.Int,4).Value = BookId;

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

        public void Update()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"update [BrandMaster]
                                         SET
                                      [BrandName]=@BrandName
                              where BrandId =@BrandId";

                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@BrandName", SqlDbType.NVarChar, 50).Value = BrandName == null ? (Object)DBNull.Value : BrandName;
                        cmd.Parameters.Add("@BrandId", SqlDbType.Int,4).Value = BrandId;

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