using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RentACar.DAL
{
    public class BookingMaster
    { 
       public int? BookingId  {get;set;}
       public int? CarId      {get;set;}
       public int? CustomerId {get;set;}
       public decimal? Price      {get;set;}
       public decimal? TotalPrice {get;set;}
       public int? ExtraHours {get;set;}
       public int? TotalHours {get;set;}
       public DateTime? BookingDate{get;set;}
       public DateTime? BookingLastDate { get; set; }
       public bool? IsActice { get; set; }
       public string BookingStatus { get; set; }
       public string LicenseNumber { get; set; }
       public DateTime? CreatedDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public void Add()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"insert into [BookingMaster]
                                      (        
                                      [CarId]       
                                    , [CustomerId] 
                                    , [Price]           
                                    , [TotalPrice]           
                                    , [ExtraHours]      
                                    , [TotalHours]
                                    , [BookingDate]  
                                    , [BookingLastDate]   
                                    , [IsActice]     
                                    , [BookingStatus]    
                                    , [LicenseNumber]   
                                    , [CreatedDate]    
                                       )
                                       values
                                        (                 
                                       @CarId       
                                      ,@CustomerId
                                      ,@Price           
                                      ,@TotalPrice    
                                      ,@ExtraHours
                                      ,@TotalHours    
                                      ,@BookingDate   
                                      ,@BookingLastDate     
                                      ,@IsActice      
                                      ,@BookingStatus      
                                      ,@LicenseNumber   
                                      ,@CreatedDate   
                                       );";
                    Sql += "select scope_identity();";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@CarId", SqlDbType.Int).Value = CarId == null ? (Object)DBNull.Value : CarId;
                        cmd.Parameters.Add("@CustomerId", SqlDbType.Int).Value = CustomerId == null ? (Object)DBNull.Value : CustomerId;
                        cmd.Parameters.Add("@Price", SqlDbType.Decimal, 8).Value = Price == null ? (Object)DBNull.Value : Price;
                        cmd.Parameters.Add("@TotalPrice", SqlDbType.Decimal, 8).Value = TotalPrice == null ? (Object)DBNull.Value : TotalPrice;
                        cmd.Parameters.Add("@ExtraHours", SqlDbType.Int).Value = ExtraHours == null ? (Object)DBNull.Value : ExtraHours;
                        cmd.Parameters.Add("@TotalHours", SqlDbType.Int).Value = TotalHours == null ? (Object)DBNull.Value : TotalHours;
                        cmd.Parameters.Add("@BookingDate", SqlDbType.DateTime, 8).Value = BookingDate == null ? (Object)DBNull.Value : BookingDate;
                        cmd.Parameters.Add("@BookingLastDate", SqlDbType.DateTime, 8).Value = BookingLastDate == null ? (Object)DBNull.Value : BookingLastDate;
                        cmd.Parameters.Add("@IsActice", SqlDbType.Bit).Value = IsActice;
                        cmd.Parameters.Add("@BookingStatus", SqlDbType.VarChar, 50).Value = BookingStatus == null ? (Object)DBNull.Value : BookingStatus;
                        cmd.Parameters.Add("@LicenseNumber", SqlDbType.VarChar,50).Value = LicenseNumber == null ? (Object)DBNull.Value : LicenseNumber;
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = CreatedDate == null ? (Object)DBNull.Value : CreatedDate;
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

        public static DataTable GetBookings()
        {
            DataTable Dt = new DataTable();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"SELECT
                                BM.BookingId, BM.CreatedDate,BM.BookingDate,BM.ReturnDate,BM.BookingStatus,BM.Price,BM.TotalPrice,BM.TotalHours,BM.LicenseNumber,CMM.Car_Title,CM.Cust_Name
                               FROM BookingMaster BM
                               JOIN CustomerMaster CM
                                 ON BM.CustomerId = CM.Cust_Id
                               JOIN CarMaster CMM
                                 ON BM.CarId = CMM.CarId;";

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

        public static DataTable GetOldBookings()
        {
            DataTable Dt = new DataTable();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"SELECT BM.BookingId, BM.BookingDate,BM.BookingStatus , BM.Price,bm.TotalPrice,BM.TotalHours,CMM.Car_Title,CM.Cust_Name
                               FROM BookingMaster BM
                               JOIN CustomerMaster CM
                                 ON BM.CustomerId = CM.Cust_Id
                               JOIN CarMaster CMM
                                 ON BM.CarId = CMM.CarId where BM.BookingStatus='Returned';";

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

        public static int MonthBookingRecords()
        {
            int records = 0;
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"SELECT COUNT(*) AS RecordCount
                                   FROM BookingMaster
                                   WHERE MONTH(BookingDate) = MONTH(GETDATE())
                                    AND YEAR(BookingDate) = YEAR(GETDATE());";

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

        public static int TotalBookingRecords()
        {
            int records = 0;
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"SELECT COUNT(*) AS RecordCount
                                   FROM BookingMaster;";

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

        public static BookingMaster GetBookedInfo(string CarId,string date)
        {
            BookingMaster BM = new BookingMaster();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    //string Sql = @"select [IsBooked] from [BookingMaster] where [CarId]=@CarId 
                    //                 and [BookingDate]=@Bookingdate";

                    string Sql = @"SELECT [BookingStatus] FROM [BookingMaster] 
                                   WHERE [CarId] = @CarId
                                   AND CONVERT(datetime, [BookingLastDate], 105) >= @Bookingdate
                                   AND CONVERT(datetime, [BookingDate], 105) <= @Bookingdate";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@CarId", SqlDbType.Int, 8).Value = CarId;
                        cmd.Parameters.Add("@BookingDate", SqlDbType.NVarChar,50).Value = date;
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (Rd.Read())
                            {
                                BM.BookingStatus = Rd["BookingStatus"] == DBNull.Value ? null : Rd["BookingStatus"].ToString();
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

        public void Update()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"update [BookingMaster] SET
                                      [BookingStatus]=@BookingStatus,
                                      [ReturnDate]=@ReturnDate
                                       where BookingId =@BookingId";


                    //Sql += "select scope_identity();";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@BookingStatus", SqlDbType.NVarChar, 50).Value = BookingStatus == null ? (Object)DBNull.Value : BookingStatus;
                        cmd.Parameters.Add("@ReturnDate", SqlDbType.DateTime, 8).Value = ReturnDate == null ? (Object)DBNull.Value : ReturnDate;
                        cmd.Parameters.Add("@BookingId", SqlDbType.BigInt, 8).Value = BookingId;

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

        public static DataTable GetBookings(string Email)
        {
            DataTable Dt = new DataTable();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"SELECT
                                BM.BookingId, BM.CreatedDate,BM.BookingStatus,BM.Price,BM.TotalPrice,BM.TotalHours,
                                BM.LicenseNumber,CMM.Car_Title,CM.Cust_Name,CM.Email
                               FROM BookingMaster BM
                               JOIN CustomerMaster CM
                                 ON BM.CustomerId = CM.Cust_Id
                               JOIN CarMaster CMM
                                 ON BM.CarId = CMM.CarId
                               where [Email]=@Email";

                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = Email;
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

        public static BookingMaster GetBookingStatus(int BookId)
        {
            BookingMaster BM = new BookingMaster();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"select [BookingStatus] from [bookingmaster] where [BookingId]=@BookingId";

                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@BookingId", SqlDbType.Int, 8).Value = BookId;
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (Rd.Read())
                            {
                                BM.BookingStatus = Rd["BookingStatus"] == DBNull.Value ? null : Rd["BookingStatus"].ToString();
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
    }
}