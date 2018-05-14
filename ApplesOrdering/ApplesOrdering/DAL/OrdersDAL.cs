using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApplesOrdering.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace ApplesOrdering.DAL
{
    public class OrdersDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        private string getBakeryOrdersForStore_SQL = "select * from bakeryOrder where storeId = @storeId;";
        private string getDeliOrdersForStore_SQL = "select * from deliOrder where storeId = @storeId;";

        public List<BakeryOrderModel> GetAllBakeryOrdersForStore(int storeId)
        {
            List<BakeryOrderModel> output = new List<BakeryOrderModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getBakeryOrdersForStore_SQL, conn);
                    cmd.Parameters.AddWithValue("@storeId", storeId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        BakeryOrderModel order = new BakeryOrderModel();

                        order.BorderTrim = Convert.ToString(reader["borderTrim"]);
                        order.Dough = Convert.ToString(reader["dough"]);
                        order.Icing = Convert.ToString(reader["icing"]);
                        order.Id = Convert.ToInt32(reader["id"]);
                        order.IsActive = Convert.ToBoolean(reader["isActive"]);
                        order.Kitname = Convert.ToString(reader["kitName"]);
                        order.KitNumber = Convert.ToInt32(reader["kitNumber"]);
                        order.MessageInfo = Convert.ToString(reader["messageInfo"]);
                        order.PhoneNumber = Convert.ToString(reader["phoneNumber"]);
                        order.OrderName = Convert.ToString(reader["orderName"]);
                        order.OrderTime = Convert.ToDateTime(reader["orderTime"]);
                        order.PickupTime = Convert.ToDateTime(reader["pickUpTime"]);
                        order.Size = Convert.ToString(reader["size"]);
                        order.StoreId = Convert.ToInt32(reader["storeId"]);
                        order.UserInfoId = Convert.ToInt32(reader["userInfoId"]);

                        output.Add(order);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return output;
        }

        public List<DeliOrderModel> GetAllDeliOrdersForStore(int storeId)
        {
            List<DeliOrderModel> output = new List<DeliOrderModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getDeliOrdersForStore_SQL, conn);
                    cmd.Parameters.AddWithValue("@storeId", storeId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DeliOrderModel order = new DeliOrderModel();

                        order.Id = Convert.ToInt32(reader["id"]);
                        order.IsActive = Convert.ToBoolean(reader["isActive"]);
                        order.NumberOfPieces = Convert.ToInt32(reader["numberOfPieces"]);
                        order.OrderName = Convert.ToString(reader["orderName"]);
                        order.PhoneNumber = Convert.ToString(reader["phoneNumber"]);
                        order.OrderTime = Convert.ToDateTime(reader["orderTime"]);
                        order.PickUpTime = Convert.ToDateTime(reader["pickUpTime"]);
                        order.StoreId = Convert.ToInt32(reader["storeId"]);
                        order.UserInfoId = Convert.ToInt32(reader["userInfoId"]);

                        output.Add(order);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return output;
        }

    }
}