using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroUsuariosWeb.Alumnos
{
    /// <summary>
    /// SE TIENE QUE CORREEGIR TRABAJANDO CON DATASET
    /// *********************************************
    /// 
    /// USAR SESSION (DATASET) - TRABAJO OFFLINE CON UNA BD
    /// PERO  SE DEVUELVE DATATABLE
    /// 
    /// </summary>
    public partial class InstanciarTarea : System.Web.UI.Page
    {
        private static String email;
        private static String codTarea;
        private static String he;
        private static String indexGV; // Para agregar a la tabla

        BusinessLogicLayer.BusinessLogic bll;

        protected void Page_Load(object sender, EventArgs e)
        {
            feedbackTareaL.Visible = false;
            bll = new BusinessLogicLayer.BusinessLogic();
            if (!Page.IsPostBack)
            {
                email = Session["email"].ToString();
                codTarea = Request.QueryString["codTarea"];
                he = Request.QueryString["he"];
                indexGV = Request.QueryString["indexGV"];

                usuarioTB.Text = email;
                tareaTB.Text = codTarea;
                horasETB.Text = he;

                // Ini GridView
                gridView();
            }
        }

        protected void tareasButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./VerTareasEstudiante.aspx");
        }

        protected void cerrarSesionButton_Click(object sender, EventArgs e)
        {
            Session.Abandon();

            Response.Redirect("../Inicio.aspx"); // Msg to confirm exit
        }

        protected void instanciarTareaButton_Click(object sender, EventArgs e)
        {
            // Codigo DataAccess update table
            String hr = horasRTB.Text;

            if (!hr.Equals(""))
            {
                feedbackTareaL.Visible = true;
                int hrc = int.Parse(hr);
                if (bll.updateTareasEstudiante(email, codTarea, he, hrc))
                {
                    // Se ha insertado
                    feedbackTareaL.ForeColor = System.Drawing.Color.Green;
                    feedbackTareaL.Text = "La tarea se ha creado!";

                    // Update GridView

                    gridView();
                }
                else
                {
                    // error
                    feedbackTareaL.ForeColor = System.Drawing.Color.Red;
                    feedbackTareaL.Text = "No se ha creado la tarea!";

                }
            }
            else
            {
                // ..
            }

        }


        private void gridView()
        {
            DataTable dt = bll.getTareasEstudiante(email);
            tareasIGV.DataSource = dt;
            tareasIGV.DataBind();
        }

    }
}
