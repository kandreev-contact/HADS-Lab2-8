using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;

namespace RegistroUsuariosWeb.Profesorado
{
    public partial class InsertarTarea : System.Web.UI.Page
    {
        BusinessLogicLayer.BusinessLogic bll;

        protected void Page_Load(object sender, EventArgs e)
        {
            bll = new BusinessLogicLayer.BusinessLogic();
            feedbackTareaL.Visible = false;
        }

        protected void tareasButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./GestionarTareas.aspx");
        }

        protected void cerrarSesionButton_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("../Inicio.aspx");
        }

        protected void insertarTareaButton_Click(object sender, EventArgs e)
        {
            //Obtener Datos
            String codigo = codigoTB.Text;
            String descripcion = descripcionTA.Text;
            Asignatura asignatura = new Asignatura();
            asignatura.setCodigo(asignaturaDDL.SelectedValue);
            int hEstimadas = int.Parse(hestimadasTB.Text);
            String tipoTarea = typeSubjectDDl.SelectedValue;
            bool explotacion = false;

            TareaGenerica tg = new TareaGenerica(codigo, descripcion, hEstimadas, explotacion, tipoTarea, asignatura);

            feedbackTareaL.Visible = true;
            // Insertar tarea en la base de datos
            if (bll.registerTarea(tg))
            {
                // Se ha insertado
                feedbackTareaL.ForeColor = System.Drawing.Color.Green;
                feedbackTareaL.Text = "La tarea se ha creado!";

            }
            else
            {
                // error
                feedbackTareaL.ForeColor = System.Drawing.Color.Red;
                feedbackTareaL.Text = "No se ha creado la tarea!";

            }

        }

        protected void estadisticaButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./EstadisticasEstudiante.aspx");
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