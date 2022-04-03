using System.Configuration;
using System.Collections.Specialized;
using Azure;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;

namespace DataAccessLayer
{
    public class UserDAO : IUserDAO
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
                string insertQuery = "insert into Usuario(email,nombre,apellidos,numconfir,confirmado,tipo,pass,codpass) values (@email,@name,@surname,@numConfirmation,@confirmation,@role,@password,@codpass)";

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


        public bool checkExistingUser(string email)
        {
            try
            {
                string selectQuery = "select count(*) from Usuario where email=@email";

                sqlCommand = new SqlCommand(selectQuery, this.sqlConnection);

                sqlCommand.Parameters.AddWithValue("@email", email);

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


        public bool checkUserToConfirm(string email, int numconf)
        {
            try
            {
                string selectQuery = "select count(*) from Usuario where email=@email and numconfir=@numconf";

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
                string updateQuery = "update Usuario set confirmado=@confirmation where email=@email";

                sqlCommand = new SqlCommand(updateQuery, this.sqlConnection);

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
                string selectQuery = "select count(*) from Usuario where email=@email and confirmado=@conf";

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
            { // Ahora con la contraseña encriptada
                string selectQuery = "select count(*) from Usuario where email=@email and pass=@password";

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

        public void setUserPassCodeChanged(String email, int codPass)
        {
            try
            {
                string updateQuery = "update Usuario set codpass=@codPass where email=@email";

                sqlCommand = new SqlCommand(updateQuery, this.sqlConnection);

                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@codPass", codPass);

                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Database Query error! " + ex.ToString());
            }
        }

        public bool checkUserCodePass(string email, int codPass)
        {
            try
            {
                string selectQuery = "select count(*) from Usuario where email=@email and codpass=@codPass";

                sqlCommand = new SqlCommand(selectQuery, this.sqlConnection);

                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@codPass", codPass);

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

        public void changeUserPassword(string email, String newPassword)
        {
            try
            {
                string updateQuery = "update Usuario set pass=@newPass where email=@email";

                sqlCommand = new SqlCommand(updateQuery, this.sqlConnection);

                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@newPass", newPassword);

                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Database Query error! " + ex.ToString());
            }
        }

        public bool checkUserPassword(String email, string newPassword)
        {
            try
            {
                string selectQuery = "select count(*) from Usuario where email=@email and pass=@newPassword";

                sqlCommand = new SqlCommand(selectQuery, this.sqlConnection);

                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@newPassword", newPassword);

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

        public User getUser(string email, string password)
        {

            User user = new User();
            try
            {
                string selectQuery = "select email,nombre,apellidos,tipo from Usuario where email=@email and pass=@pass";

                sqlCommand = new SqlCommand(selectQuery, this.sqlConnection);

                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@pass", password);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.setEmail(reader["email"].ToString());
                        user.setName(reader["nombre"].ToString());
                        user.setSurname(reader["apellidos"].ToString());
                        user.setRole(reader["tipo"].ToString());
                    }
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Database Query error! " + ex.ToString());
            }
        }



        public bool checkExistingTarea(TareaGenerica tarea)
        {
            try
            {
                string selectQuery = "select count(*) from TareaGenerica where codigo=@codigo";

                sqlCommand = new SqlCommand(selectQuery, this.sqlConnection);

                sqlCommand.Parameters.AddWithValue("@codigo", tarea.getCodigo());

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

        public void registerTarea(TareaGenerica tarea)
        {

            try
            {
                string insertQuery = "insert into TareaGenerica(codigo,descripcion,codAsig,hEstimadas,explotacion,tipoTarea) values (@codigo,@descripcion,@codAsig,@hEstimadas,@explotacion,@tipoTarea)";

                sqlCommand = new SqlCommand(insertQuery, this.sqlConnection);

                sqlCommand.Parameters.AddWithValue("@codigo", tarea.getCodigo());
                sqlCommand.Parameters.AddWithValue("@descripcion", tarea.getDescription());
                sqlCommand.Parameters.AddWithValue("@codAsig", tarea.getCodAsignatura());
                sqlCommand.Parameters.AddWithValue("@hEstimadas", tarea.getHEstimadas());
                sqlCommand.Parameters.AddWithValue("@explotacion", tarea.getExplotacion());
                sqlCommand.Parameters.AddWithValue("@tipoTarea", tarea.getTipoTarea());
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Database Query error! " + ex.ToString());
            }
        }

        public DataSet getSubjects(string alumno)
        {
            try
            {
                #region selectQuery
                string selectQuery = "select codigoAsig from GrupoClase inner join EstudianteGrupo on " +
                    "EstudianteGrupo.grupo=GrupoClase.codigo where email=@email";

                sqlCommand = new SqlCommand(selectQuery, this.sqlConnection);
                sqlCommand.Parameters.AddWithValue("@email", alumno);
                #endregion

                #region DataAdapter
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlCommand;
                #endregion

                #region DataSet
                DataSet ds = new DataSet();
                da.Fill(ds);
                #endregion

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Database Query error! " + ex.ToString());
            }

        }

        public DataSet getTareasGenericas(string alumno)
        {
            try
            {
                #region selectQuery
                string selectQuery = "select distinct TareaGenerica.codigo,TareaGenerica.codAsig,TareaGenerica.descripcion,TareaGenerica.hEstimadas,TareaGenerica.tipoTarea " +
                   "from TareaGenerica " +
                   " inner join (GrupoClase inner join EstudianteGrupo on EstudianteGrupo.grupo=GrupoClase.codigo) on TareaGenerica.codAsig=GrupoClase.codigoAsig " +
                   "where EstudianteGrupo.email=@email and  TareaGenerica.explotacion=1 and " +
                   "not exists ( select EstudianteTarea.codTarea from EstudianteTarea where TareaGenerica.codigo=EstudianteTarea.codTarea)";

                sqlCommand = new SqlCommand(selectQuery, this.sqlConnection);
                sqlCommand.Parameters.AddWithValue("@email", alumno);
                #endregion

                #region DataAdapter
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlCommand;
                #endregion

                #region CommandBuilder
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                #endregion

                #region DataSet
                DataSet ds = new DataSet();
                da.Fill(ds);
                #endregion

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Database Query error! " + ex.ToString());
            }
        }


        public DataTable getTareasGenericas(string alumno, string codAsig)
        {
            try
            {
                #region selectQuery
                string selectQuery = "select distinct TareaGenerica.codigo,TareaGenerica.descripcion,TareaGenerica.hEstimadas,TareaGenerica.tipoTarea " +
                   "from TareaGenerica " +
                   " inner join (GrupoClase inner join EstudianteGrupo on EstudianteGrupo.grupo=GrupoClase.codigo) on TareaGenerica.codAsig=GrupoClase.codigoAsig " +
                   "where EstudianteGrupo.email=@email and TareaGenerica.codAsig=@codAsig and  TareaGenerica.explotacion=1 and " +
                   "not exists ( select EstudianteTarea.codTarea from EstudianteTarea where TareaGenerica.codigo=EstudianteTarea.codTarea)";

                sqlCommand = new SqlCommand(selectQuery, this.sqlConnection);
                sqlCommand.Parameters.AddWithValue("@email", alumno);
                sqlCommand.Parameters.AddWithValue("@codAsig", codAsig);
                #endregion

                #region DataAdapter
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlCommand;
                #endregion

                #region CommandBuilder
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                #endregion

                #region DataSet
                DataSet ds = new DataSet();
                da.Fill(ds);
                #endregion

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Database Query error! " + ex.ToString());
            }
        }

        public (DataTable, SqlDataAdapter) getTareasEstudiante(string email)
        {
            try
            {
                #region selectQuery
                string selectQuery = "select EstudianteTarea.email,EstudianteTarea.codTarea,EstudianteTarea.hEstimadas,EstudianteTarea.hReales from EstudianteTarea where email=@email";

                sqlCommand = new SqlCommand(selectQuery, this.sqlConnection);
                sqlCommand.Parameters.AddWithValue("@email", email);
                #endregion

                #region DataAdapter
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlCommand;
                #endregion

                #region CommandBuilder
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                #endregion

                #region DataSet
                DataSet ds = new DataSet();
                da.Fill(ds);
                #endregion

                return (ds.Tables[0], da);
            }
            catch (Exception ex)
            {
                throw new Exception("Database Query error! " + ex.ToString());
            }
        }

        public void updateTareasEstudiante(string email, string codTarea, string he, int hrc) // Corregir acceptar EstudianteTarea entity
        {
            try
            {
                string insertQuery = "insert into EstudianteTarea(email,codTarea,hEstimadas,hReales) values (@email,@codTarea,@he,@hr)";

                sqlCommand = new SqlCommand(insertQuery, this.sqlConnection);

                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@codTarea", codTarea);
                sqlCommand.Parameters.AddWithValue("@he", he);
                sqlCommand.Parameters.AddWithValue("@hr", hrc);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Database Query error! " + ex.ToString());
            }
        }

        public bool checkExistingTareaEstudiante(string codTarea)
        {
            try
            {
                //string selectQuery = "select count(*) from EstudianteTarea where codTarea=@codigoTarea";

                sqlCommand = new SqlCommand("getTareas", this.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@codigoTarea", codTarea);

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

        public (DataTable, SqlDataAdapter) getTareasGenericas()
        {
            try
            {
                #region selectQuery
                //string selectQuery = "select TareaGenerica.codigo,TareaGenerica.descripcion,TareaGenerica.codAsig,TareaGenerica.hEstimadas,TareaGenerica.explotacion,TareaGenerica.tipoTarea from TareaGenerica";
                string selectQuery = "select * from TareaGenerica";

                sqlCommand = new SqlCommand(selectQuery, this.sqlConnection);
                #endregion

                #region DataAdapter
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlCommand;
                #endregion

                #region CommandBuilder
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                #endregion

                #region DataSet
                DataSet ds = new DataSet();
                da.Fill(ds);
                #endregion

                return (ds.Tables[0], da);
            }
            catch (Exception ex)
            {
                throw new Exception("Database Query error! " + ex.ToString());
            }
        }

        public DataTable getTareasGenericasAsig(string codAsig)
        {
            try
            {
                #region selectQuery
                string selectQuery = "select * from TareaGenerica where TareaGenerica.codAsig=@codAsig";

                sqlCommand = new SqlCommand(selectQuery, this.sqlConnection);
                sqlCommand.Parameters.AddWithValue("@codAsig", codAsig);
                #endregion

                #region DataAdapter
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlCommand;
                #endregion

                #region CommandBuilder
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                #endregion

                #region DataSet
                DataSet ds = new DataSet();
                da.Fill(ds);
                #endregion

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Database Query error! " + ex.ToString());
            }
        }

        public DataSet getSubjectsProfe(string email)
        {

            try
            {
                #region selectQuery
                string selectQuery = "SELECT GrupoClase.codigoAsig FROM GrupoClase INNER JOIN ProfesorGrupo ON GrupoClase.codigo = ProfesorGrupo.codigoGrupo WHERE (ProfesorGrupo.email = @email)";

                sqlCommand = new SqlCommand(selectQuery, this.sqlConnection);
                sqlCommand.Parameters.AddWithValue("@email", email);
                #endregion

                #region DataAdapter
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlCommand;
                #endregion

                #region DataSet
                DataSet ds = new DataSet();
                da.Fill(ds);
                #endregion

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Database Query error! " + ex.ToString());
            }
        }


        public DataTable getTareasGenericasAsig()
        {
            try
            {
                #region selectQuery
                string selectQuery = "select * from TareaGenerica";

                sqlCommand = new SqlCommand(selectQuery, this.sqlConnection);
                #endregion

                #region DataAdapter
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlCommand;
                #endregion

                #region CommandBuilder
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                #endregion

                #region DataSet
                DataSet ds = new DataSet();
                ds.DataSetName = "tareas";
                da.Fill(ds);
                #endregion

                return (ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw new Exception("Database Query error! " + ex.ToString());
            }
        }
    }
}
