using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// La capa de entidades contendra todos los objetos necesarios (P.e: Usuarios, Asignaturas, etc.)
/// </summary>
namespace EntityLayer
{
    public class User
    {
        private String emailKey;
        private String password;
        private String name, surname;
        private String role;
        private int numConfirmation;
        private int codPass;
        private bool confirmed;

        public User(String email, String password, String name, String surname, String role, int numConfirmation)
        {
            this.emailKey = email;
            this.name = name;
            this.surname = surname;
            this.password = password;
            this.role = role;
            this.numConfirmation = numConfirmation;
            this.confirmed = false;
            this.codPass = 0;
        }

        /// <summary>
        /// Constructor vacio.
        /// </summary>
        public User()
        {

        }

        public void setConfirmed(bool b)
        {
            this.confirmed = b;
        }
        public bool getConfirmed()
        {
            return this.confirmed;
        }

        public void setEmail(String s)
        {
            this.emailKey = s;
        }
        public String getEmail()
        {
            return this.emailKey;
        }

        public void setName(String n)
        {
            this.name = n;
        }
        public String getName()
        {
            return this.name;
        }

        public void setSurname(String s)
        {
            this.surname = s;
        }
        public String getSurname()
        {
            return this.surname;
        }

        public void setRole(String s)
        {
            this.role = s;
        }
        public String getRole()
        {
            return this.role;
        }

        public void setPassword(String s)
        {
            this.password = s;
        }
        public String getPassword()
        {
            return this.password;
        }

        public void setNumConfirmation(int s)
        {
            this.numConfirmation = s;
        }
        public int getNumConfirmation()
        {
            return this.numConfirmation;
        }
        public void setCodPass(int s)
        {
            this.codPass = s;
        }
        public int getCodPass()
        {
            return this.codPass;
        }
    }
}
