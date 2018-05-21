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
        private string addOrderBakery_SQL = "insert into bakeryOrder values (@orderName, @phoneNumber, GETDATE(), @pickUpTime, @userInfoId, @size, @dough, @icing, @messageInfo, @borderTrim, @kitNumber, @kitName, 1, @storeId);";
        private string addOrderDeli_SQL = "insert into deliOrder values ('@orderName','@phoneNumber', GETDATE(), @pickUpTime, @userInfoId, @numberOfPieces, 1, @storeId);";
        private string getAllDeliOrders_SQL = "select * from deliOrder;";
        private string getAllBakeryOrders_SQL = "select * from bakeryOrder;";
        private string getDeliOrderById = "select * from deliOrder where id = @id;";
       

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

        public bool SaveBakeryOrder(BakeryOrderModel order)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand(addOrderBakery_SQL, conn);
                    cmd.Parameters.AddWithValue("@orderName", order.OrderName);
                    cmd.Parameters.AddWithValue("@phoneNumber", order.PhoneNumber);
                    cmd.Parameters.AddWithValue("@pickUpTime", order.PickupTime);
                    cmd.Parameters.AddWithValue("@userInfoId", order.UserInfoId);
                    cmd.Parameters.AddWithValue("@size", order.Size);
                    cmd.Parameters.AddWithValue("@dough", order.Dough);
                    cmd.Parameters.AddWithValue("@icing", order.Icing);
                    cmd.Parameters.AddWithValue("@messageInfo", order.MessageInfo);
                    cmd.Parameters.AddWithValue("@borderTrim", order.BorderTrim);
                    cmd.Parameters.AddWithValue("@kitNumber", order.KitNumber);
                    cmd.Parameters.AddWithValue("@kitName", order.Kitname);
                    cmd.Parameters.AddWithValue("@storeId", order.StoreId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public bool SaveDeliOrder(DeliOrderModel order)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand(addOrderDeli_SQL, conn);
                    cmd.Parameters.AddWithValue("@orderName", order.OrderName);
                    cmd.Parameters.AddWithValue("@phoneNumber", order.PhoneNumber);
                    cmd.Parameters.AddWithValue("@pickUpTime", order.PickUpTime);
                    cmd.Parameters.AddWithValue("@userInfoId", order.UserInfoId);
                    cmd.Parameters.AddWithValue("@numberOfPieces", order.NumberOfPieces);
                    cmd.Parameters.AddWithValue("@storeId", order.StoreId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public List<BakeryOrderModel> GetAllBakeryOrders()
        {
            List<BakeryOrderModel> orders = new List<BakeryOrderModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getAllBakeryOrders_SQL, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        BakeryOrderModel order = new BakeryOrderModel();

                        order.Dough = Convert.ToString(reader["dough"]);
                        order.BorderTrim = Convert.ToString(reader["borderTrim"]);
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

                        orders.Add(order);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return orders;
        }

        public List<DeliOrderModel> GetAllDeliOrders()
        {
            List<DeliOrderModel> orders = new List<DeliOrderModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getAllDeliOrders_SQL, conn);
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

                        orders.Add(order);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return orders;
        }


    }
}