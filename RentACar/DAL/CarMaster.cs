using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RentACar.DAL
{
    public class CarMaster
    {
       public int CarId           {get;set;}
       public string Car_Title       {get;set;}
       public string Car_Description {get;set;}
       public decimal? Price           {get;set;}
       public string Brand           {get;set;}
       public int? Model_Year      {get;set;}
       public string Seating_Capacity {get;set;}
       public string Fuel_Type      {get;set;}
       public string Car_img1        {get;set;}
       public string Car_img2        {get;set;}
       public string Car_img3        {get;set;}
       public string Car_Color       {get;set;}
       public DateTime? CreatedDate     {get;set;}
       public bool Is_Active { get; set; }


        public void Add()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"insert into [CarMaster]
                                      (        
                                      [Car_Title]       
                                    , [Car_Description] 
                                    , [Price]           
                                    , [Brand]           
                                    , [Model_Year]      
                                    , [Seating_Capacity]
                                    , [Fuel_Type]       
                                    , [Car_img1]        
                                    , [Car_img2]        
                                    , [Car_img3]        
                                    , [Car_Color]       
                                    , [CreatedDate]     
                                    , [Is_Active]       
                                       )
                                       values
                                        (                 
                                       @Car_Title       
                                      ,@Car_Description
                                      ,@Price           
                                      ,@Brand           
                                      ,@Model_Year     
                                      ,@Seating_Capacity
                                      ,@Fuel_Type      
                                      ,@Car_img1       
                                      ,@Car_img2      
                                      ,@Car_img3        
                                      ,@Car_Color       
                                      ,@CreatedDate     
                                      ,@Is_Active                                           
                                       );";
                    Sql += "select scope_identity();";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@Car_Title", SqlDbType.NVarChar, 50).Value = Car_Title == null ? (Object)DBNull.Value : Car_Title;
                        cmd.Parameters.Add("@Car_Description", SqlDbType.NVarChar, 150).Value = Car_Description == null ? (Object)DBNull.Value : Car_Description;
                        cmd.Parameters.Add("@Price", SqlDbType.Decimal, 8).Value = Price == null ? (Object)DBNull.Value : Price;
                        cmd.Parameters.Add("@Brand", SqlDbType.NVarChar, 50).Value = Brand == null ? (Object)DBNull.Value : Brand;
                        cmd.Parameters.Add("@Model_Year", SqlDbType.Int).Value = Model_Year == null ? (Object)DBNull.Value : Model_Year;
                        cmd.Parameters.Add("@Seating_Capacity", SqlDbType.Int).Value = Seating_Capacity == null ? (Object)DBNull.Value : Seating_Capacity;
                        cmd.Parameters.Add("@Fuel_Type", SqlDbType.NVarChar, 50).Value = Fuel_Type == null ? (Object)DBNull.Value : Fuel_Type;
                        cmd.Parameters.Add("@Car_img1", SqlDbType.NVarChar, 50).Value = Car_img1 == null ? (Object)DBNull.Value : Car_img1;
                        cmd.Parameters.Add("@Car_img2", SqlDbType.NVarChar, 50).Value = Car_img2 == null ? (Object)DBNull.Value : Car_img2;
                        cmd.Parameters.Add("@Car_img3", SqlDbType.NVarChar, 50).Value = Car_img3 == null ? (Object)DBNull.Value : Car_img3;
                        cmd.Parameters.Add("@Car_Color", SqlDbType.NVarChar, 50).Value = Car_Color == null ? (Object)DBNull.Value : Car_Color;
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = CreatedDate == null ? (Object)DBNull.Value : CreatedDate;
                        cmd.Parameters.Add("@Is_Active", SqlDbType.Bit).Value = Is_Active;
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

        public static CarMaster GetCarInfo(string CarId)
        {
            CarMaster CM = new CarMaster();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"select * from [CarMaster] where [CarId]=@CarId";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@CarId", SqlDbType.Int, 8).Value = CarId;
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (Rd.Read())
                            {
                                CM.Car_Title = Rd["Car_Title"] == DBNull.Value ? null : Rd["Car_Title"].ToString();
                                CM.Brand = Rd["Brand"] == DBNull.Value ? null : Rd["Brand"].ToString();
                                CM.Car_Description = Rd["Car_Description"] == DBNull.Value ? null : Rd["Car_Description"].ToString();
                                CM.Car_Color = Rd["Car_Color"] == DBNull.Value ? null : Rd["Car_Color"].ToString();
                                CM.Car_img1 = Rd["Car_img1"] == DBNull.Value ? null : Rd["Car_img1"].ToString();
                                CM.Car_img2 = Rd["Car_img2"] == DBNull.Value ? null : Rd["Car_img2"].ToString();
                                CM.Car_img3 = Rd["Car_img3"] == DBNull.Value ? null : Rd["Car_img3"].ToString();
                                CM.Fuel_Type = Rd["Fuel_Type"] == DBNull.Value ? null : Rd["Fuel_Type"].ToString();
                                CM.Model_Year = Convert.ToInt32(Rd["Model_Year"]);
                                CM.Price =Convert.ToDecimal(Rd["Price"]);
                                CM.Seating_Capacity = Rd["Seating_Capacity"] == DBNull.Value ? null : Rd["Seating_Capacity"].ToString();
                                
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
            return CM;
        }

        public static DataTable GetCars()
        {
            DataTable Dt = new DataTable();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"select * from [CarMaster]";

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


        public static DataTable GetCarsDetails(string brand)
        {
            DataTable Dt = new DataTable();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"select * from [CarMaster] where [Brand]=@Brand";

                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@Brand", SqlDbType.NVarChar, 50).Value = brand == null ? (Object)DBNull.Value : brand;

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

        public static CarMaster GetCarPrice(string car)
        {
            CarMaster CM = new CarMaster();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"select * from [CarMaster] where [Car_Title]=@Car_Title";

                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@Car_Title", SqlDbType.NVarChar, 50).Value = car;

                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (Rd.Read())
                            {
                                CM.Price = Convert.ToDecimal(Rd["Price"]);
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
            return CM;
        }

        public bool Delete(int Id)
        {
            bool IsDelete = false;
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"delete [CarMaster] where [CarId]=@CarId";

                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@CarId", SqlDbType.Int, 4).Value = Id;

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

        public static int TotalCarRecords()
        {
            int records = 0;
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"SELECT COUNT(*) AS RecordCount
                                   FROM CarMaster;";

                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if(Rd.Read())
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
                    string Sql = @"update [CarMaster]
                                         SET
                                      [Car_Title]       =@Car_Title       
                                    , [Car_Description] =@Car_Description
                                    , [Price]           =@Price           
                                    , [Brand]           =@Brand           
                                    , [Model_Year]      =@Model_Year     
                                    , [Seating_Capacity]=@Seating_Capacity
                                    , [Fuel_Type]       =@Fuel_Type      
                                    , [Car_img1]        =@Car_img1       
                                    , [Car_img2]        =@Car_img2      
                                    , [Car_img3]        =@Car_img3        
                                    , [Car_Color]       =@Car_Color       
                                      where CarId =@CarId";

                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@CarId", SqlDbType.Int).Value = CarId;
                        cmd.Parameters.Add("@Car_Title", SqlDbType.NVarChar, 50).Value = Car_Title == null ? (Object)DBNull.Value : Car_Title;
                        cmd.Parameters.Add("@Car_Description", SqlDbType.NVarChar, 150).Value = Car_Description == null ? (Object)DBNull.Value : Car_Description;
                        cmd.Parameters.Add("@Price", SqlDbType.Decimal, 8).Value = Price == null ? (Object)DBNull.Value : Price;
                        cmd.Parameters.Add("@Brand", SqlDbType.NVarChar, 50).Value = Brand == null ? (Object)DBNull.Value : Brand;
                        cmd.Parameters.Add("@Model_Year", SqlDbType.Int).Value = Model_Year == null ? (Object)DBNull.Value : Model_Year;
                        cmd.Parameters.Add("@Seating_Capacity", SqlDbType.Int).Value = Seating_Capacity == null ? (Object)DBNull.Value : Seating_Capacity;
                        cmd.Parameters.Add("@Fuel_Type", SqlDbType.NVarChar, 50).Value = Fuel_Type == null ? (Object)DBNull.Value : Fuel_Type;
                        cmd.Parameters.Add("@Car_img1", SqlDbType.NVarChar, 50).Value = Car_img1 == null ? (Object)DBNull.Value : Car_img1;
                        cmd.Parameters.Add("@Car_img2", SqlDbType.NVarChar, 50).Value = Car_img2 == null ? (Object)DBNull.Value : Car_img2;
                        cmd.Parameters.Add("@Car_img3", SqlDbType.NVarChar, 50).Value = Car_img3 == null ? (Object)DBNull.Value : Car_img3;
                        cmd.Parameters.Add("@Car_Color", SqlDbType.NVarChar, 50).Value = Car_Color == null ? (Object)DBNull.Value : Car_Color;

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