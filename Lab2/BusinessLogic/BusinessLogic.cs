using BusinessLogic;
using System;
using System.Net.Mail;
using System.Windows;

using DataAccessLayer;
using EntityLayer;

namespace BusinessLogicLayer
{
    public class BusinessLogic : IBLGeneral
    {

        private DataAccessLayer.GeneralDAO generalDAO;
        private DataAccessLayer.UserDAO userDAO;

        public BusinessLogic()
        {
            this.generalDAO = new GeneralDAO();
            this.userDAO = new UserDAO(generalDAO.getConnection());
        }

        public int generateNumConfirmation()
        {
            double rId;
            Random rnd = new Random();
            rId = rnd.NextDouble();
            rId = Math.Round((rId) * 9000000) + 1000000;

            return (int)rId;
        }

        public int generateNumPass()
        {
            throw new NotImplementedException();
        }

        public bool registerUser(string email, string password, string name, string surname, string role, int numConfirmation)
        {
            generalDAO.openConection();
            if (userDAO.checkUserRegister(email))
            {
                // Register User
                User user = new User(email, password, name, surname, role, numConfirmation);
                userDAO.registerUser(user);
                generalDAO.closeConnection();
                return true;
            }
            else
            {
                generalDAO.closeConnection();
                return false;
            }
        }

        public bool login(string email, string password)
        {

            generalDAO.openConection();
            if (userDAO.checkLogin(email, password))
            {
                generalDAO.closeConnection();
                return true;
            }
            else
            {
                generalDAO.closeConnection();
                return false;
            }
        }

        public void sendEmailRegister(string email, int id)
        {
            String server = "smtp.ehu.eus";
            String from = "kandreev001@ikasle.ehu.eus";
            String nCredE = "kandreev001@ikasle.ehu.eus";
            String nCredP = "HADS22-12";
            String subject = "Confirmar tu email! HADS22-12";
            String body = $"Para confirmar tu email pulsa aqui: https://localhost:44386/Confirmar.aspx?email={email}&numconf={id}";

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(server);

                //// Message content
                mail.From = new MailAddress(from);
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = body;
                //// Message content

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(nCredE, nCredP);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception("Mailing error! " + ex.ToString());
            }
        }

        public void sendEmailChangePassword(string email)
        {
            throw new NotImplementedException();
        }

        public bool confirmUser(string email, int id)
        {
            generalDAO.openConection();
            if (userDAO.checkUserRegister(email, id))
            {
                // set confirmation to true
                userDAO.confrimUser(email);
                generalDAO.closeConnection();
                return true;
            }
            else
            {
                generalDAO.closeConnection();
                return false;
            }
        }

        public bool checkConfirmed(string email)
        {
            generalDAO.openConection();
            if (userDAO.checkConfirmed(email))
            {
                generalDAO.closeConnection();
                return true;
            }
            else
            {
                generalDAO.closeConnection();
                return false;
            }
        }
    }
}
