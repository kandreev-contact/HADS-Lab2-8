using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        private static String indexGV; // Para agregar a la tabla, puede que no hace falta

        BusinessLogicLayer.BusinessLogic bll;

        protected void Page_Load(object sender, EventArgs e)
        {

            feedbackTareaL.Visible = false;
            bll = new BusinessLogicLayer.BusinessLogic();
            bool firstTime = !Page.IsPostBack;

            if (firstTime)
            {
                email = Session["email"].ToString();
                codTarea = Request.QueryString["codTarea"];
                he = Request.QueryString["he"];
                indexGV = Request.QueryString["indexGV"];

                usuarioTB.Text = email;
                tareaTB.Text = codTarea;
                horasETB.Text = he;

                // Init GridView, solo un acceso a la BD
                SqlDataAdapter adapter;
                DataTable dt;
                (dt, adapter) = bll.getTareasEstudiante(email);

                updateGrid(dt);

                Session["table"] = dt;
                Session["adapter"] = adapter;
            }
            else
            {
                DataTable dt = (DataTable)Session["table"];
                SqlDataAdapter adapter = (SqlDataAdapter)Session["adapter"];
                updateGrid(dt);
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
            String hr = horasRTB.Text;
            // Obtain the datatable
            DataTable dt = (DataTable)Session["table"];

            if (!hr.Equals(""))
            {
                feedbackTareaL.Visible = true;
                int hrc = int.Parse(hr);

                // Add new Row
                bool notChanged;
                (dt, notChanged) = addNewRow(dt, hrc);
                if (notChanged)
                {
                    feedbackTareaL.ForeColor = System.Drawing.Color.Red;
                    feedbackTareaL.Text = "No se ha creado la tarea!";
                    dt.RejectChanges();
                    updateGrid(dt);
                    return;
                }

                // Save changes
                saveChanges(dt);
            }
            else
            {
                // error en las horas reales
            }

        }


        private void updateGrid(DataTable dt)
        {
            DataTable dtCopy = dt.Copy();
            dtCopy.Columns.Remove("email"); // Remove email column 
            tareasIGV.DataSource = dtCopy; // Updated datatable
            tareasIGV.DataBind();
        }

        private (DataTable, bool) addNewRow(DataTable dt, int hrc)
        {
            bool hasErrors = false;

            DataRow dr = dt.NewRow();
            dr["email"] = email;
            dr["codTarea"] = codTarea;
            dr["hEstimadas"] = he;
            dr["hReales"] = hrc;

            foreach (DataRow row in dt.Rows)
            {
                // check if same codTarea
                if (row["codTarea"].Equals(codTarea))
                {
                    hasErrors = true;
                    break;
                }
            }

            if (hasErrors)
            {
                return (dt, hasErrors);
            }
            else
            {
                dt.Rows.Add(dr);
            }

            return (dt, hasErrors);
        }

        private void saveChanges(DataTable dt)
        {

            // Update the database
            SqlDataAdapter adapter = (SqlDataAdapter)Session["adapter"];
            adapter.Update(dt);
            dt.AcceptChanges();

            feedbackTareaL.ForeColor = System.Drawing.Color.Green;
            feedbackTareaL.Text = "La tarea se ha creado!";

            // Remove the Column from the DT
            // dt.Columns.Remove("email");
            updateGrid(dt);

        }

    }
}
