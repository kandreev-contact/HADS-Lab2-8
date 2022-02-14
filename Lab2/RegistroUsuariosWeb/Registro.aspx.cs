using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Data.SqlClient;

namespace RegistroUsuariosWeb
{
    public partial class Registro : System.Web.UI.Page
    {
        // ???
        private SqlConnection connection = new SqlConnection();
        private SqlCommand sqlCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            divSend.Visible = false;
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            long id = RandomIdentifier();
            String email = EmailTBR.Text;
            String name = NameTB.Text;
            String surname = SurnameTB.Text;
            String password = PasswordTBR.Text;
            String role = RoleSelectRBL.SelectedValue;

            #region Validation Password
            if (PasswordTBR.Text.Length >= 6)
                PassLengthValidator.IsValid = true;
            else
                PassLengthValidator.IsValid = false;
            #endregion

            #region Password Validation
            if (PasswordTBR.Text.Equals(PasswordTBRR.Text))
            {
                PasswordsEValidators.IsValid = true;
                // insert user databaseConnection
                sendEmail(email, id);
                divSend.Visible = true;
            }
            else
            {
                PasswordsEValidators.IsValid = false;
                divSend.Visible = false;
            }
            #endregion

        }

        private long RandomIdentifier()
        {
            double rId;
            Random rnd = new Random();
            rId = rnd.NextDouble();
            rId = Math.Round((rId) * 9000000) + 1000000;

            return (long)rId;
        }

        private void sendEmail(String email, long id)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.ehu.eus");

                //// Message content
                mail.From = new MailAddress("kandreev001@ikasle.ehu.eus");
                mail.To.Add(email);
                mail.Subject = "Confirmar tu email! HADS22-12";
                mail.Body = $"Para confirmar tu email pulsa aqui: https://localhost:44386/Confirmar.aspx?email={email}&numconf={id}";
                //// Message content

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("kandreev001@ikasle.ehu.eus", "HADS22-12");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                // MessageBox.Show("Email Send!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void databaseConnection()
        { // Register the user in database mot confirmed [SQL Query]
            try
            {
                connection.ConnectionString = ""; // Azure db
                connection.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR DE CONEXION" + e.ToString());
            }
            MessageBox.Show("CONEXION OK");
        }

    }
}