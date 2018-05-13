using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApplesOrdering.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace ApplesOrdering.DAL
{
    public class UserInfoDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        private const string SQL_SaveNewUser = "insert into userInfo values(@firstName, @lastName, @email, @password, null, 'false', 'false', 'false')";
        private const string SQL_CheckEmail = "select count(*) from userInfo where email = @email";
        private const string SQL_SelectUserByEmail = "select * from userInfo where email = @email";
        private const string SQL_SelectUserById = "select * from userInfo where id = @id";



        public bool SaveNewUser(UserInfoModel user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_SaveNewUser, conn);
                    cmd.Parameters.AddWithValue("@firstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", user.LastName);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    int rowsAffectedOne = cmd.ExecuteNonQuery();
                    return rowsAffectedOne > 0;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

        }

        public bool CheckAvailability(string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_CheckEmail, conn);
                    cmd.Parameters.AddWithValue("@email", email);
                    int count = cmd.ExecuteNonQuery();
                    return count == 0;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public UserInfoModel SelectUserByEmail(string email)
        {
            UserInfoModel user = new UserInfoModel();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_SelectUserByEmail, conn);
                    cmd.Parameters.AddWithValue("@email", email);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        user.Email = Convert.ToString(reader["email"]);
                        user.FirstName = Convert.ToString(reader["firstName"]);
                        user.Id = Convert.ToInt32(reader["id"]);
                        user.IsAdmin = Convert.ToBoolean(reader["isAdmin"]);
                        user.IsBakery = Convert.ToBoolean(reader["isBakery"]);
                        user.IsDeli = Convert.ToBoolean(reader["isDeli"]);
                        user.LastName = Convert.ToString(reader["lastName"]);
                        user.Password = Convert.ToString(reader["password"]);
                    }
                    return user;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public UserInfoModel SelectUserById(int id)
        {
            try
            {
                UserInfoModel user = new UserInfoModel();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_SelectUserById, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        user.Email = Convert.ToString(reader["email"]);
                        user.FirstName = Convert.ToString(reader["firstName"]);
                        user.Id = Convert.ToInt32(reader["id"]);
                        user.IsAdmin = Convert.ToBoolean(reader["isAdmin"]);
                        user.LastName = Convert.ToString(reader["lastName"]);
                        user.Password = Convert.ToString(reader["password"]);
                    }
                    return user;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}