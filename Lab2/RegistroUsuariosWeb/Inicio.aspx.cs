using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroUsuariosWeb
{
    public partial class Inicio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divSend.Visible = false;
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            // Check if in database
            // true -> goto home page
            // false -> show error message
        }

        protected void RegistroLB_Click(object sender, EventArgs e)
        {

        }

        protected void CambiarPassLB_Click(object sender, EventArgs e)
        {

        }
    }
}