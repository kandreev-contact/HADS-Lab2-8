using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroUsuariosWeb.Profesorado
{
    public partial class HorasMediasAsig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void tareasButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Profesor.aspx");
        }

        protected void estadisticaButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Profesor.aspx");
        }

        protected void cerrarSesionButton_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../Inicio.aspx");
        }

        protected void xmldocButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./ImportarXMLDocument.aspx");
        }

        protected void exportarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Exportar.aspx");
        }
    }
}