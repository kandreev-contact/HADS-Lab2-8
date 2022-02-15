using Azure;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataAccessLayer
{
    public class UserDAO : IUserOperations
    {
        private SqlCommand sqlCommand;
        private SqlConnection sqlConnection;

        public UserDAO(SqlConnection sqlc)
        {
            this.sqlConnection = sqlc;
        }


        public void registerUser(User user)
        {
            try
            {
                string insertQuery = "insert into Usuarios(email,nombre,apellidos,numconfir,confirmado,tipo,pass,codpass) values (@email,@name,@surname,@numConfirmation,@confirmation,@role,@password,@codpass)";

                sqlCommand = new SqlCommand(insertQuery, this.sqlConnection);

                sqlCommand.Parameters.AddWithValue("@email", user.getEmail());
                sqlCommand.Parameters.AddWithValue("@password", user.getPassword());
                sqlCommand.Parameters.AddWithValue("@name", user.getName());
                sqlCommand.Parameters.AddWithValue("@surname", user.getSurname());
                sqlCommand.Parameters.AddWithValue("@role", user.getRole());
                sqlCommand.Parameters.AddWithValue("@confirmation", user.getConfirmed());
                sqlCommand.Parameters.AddWithValue("@numConfirmation", user.getNumConfirmation());
                sqlCommand.Parameters.AddWithValue("@codpass", user.getCodPass());
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Database Query error! " + ex.ToString());
            }
        }

        public bool checkUserRegister(string email)
        {
            try
            {
                string selectQuery = "select count(*) from Usuarios where email=@email";

                sqlCommand = new SqlCommand(selectQuery, this.sqlConnection);

                sqlCommand.Parameters.AddWithValue("@email", email);

                int rowsAffected = Convert.ToInt32(sqlCommand.ExecuteScalar());

                if (rowsAffected == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database Query error! " + ex.ToString());
            }
        }

        public bool checkUserRegister(string email, int numconf)
        {
            try
            {
                string selectQuery = "select count(*) from Usuarios where email=@email and numconfir=@numconf";

                sqlCommand = new SqlCommand(selectQuery, this.sqlConnection);

                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@numconf", numconf);

                int rowsAffected = Convert.ToInt32(sqlCommand.ExecuteScalar());

                if (rowsAffected == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database Query error! " + ex.ToString());
            }
        }

        public void confrimUser(string email)
        {
            try
            {
                string selectQuery = "update Usuarios set confirmado=@confirmation where email=@email";

                sqlCommand = new SqlCommand(selectQuery, this.sqlConnection);

                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@confirmation", true);

                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Database Query error! " + ex.ToString());
            }
        }

        public bool checkConfirmed(string email)
        {
            try
            {
                string selectQuery = "select count(*) from Usuarios where email=@email and confirmado=@conf";

                sqlCommand = new SqlCommand(selectQuery, this.sqlConnection);

                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@conf", true);

                int rowsAffected = Convert.ToInt32(sqlCommand.ExecuteScalar());

                if (rowsAffected == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database Query error! " + ex.ToString());
            }
        }

        public bool checkLogin(string email, string password)
        {
            try
            {
                string selectQuery = "select count(*) from Usuarios where email=@email and pass=@password";

                sqlCommand = new SqlCommand(selectQuery, this.sqlConnection);

                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@password", password);

                int rowsAffected = Convert.ToInt32(sqlCommand.ExecuteScalar());

                if (rowsAffected == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database Query error! " + ex.ToString());
            }
        }
    }
}
