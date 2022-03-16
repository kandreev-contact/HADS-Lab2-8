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
        private static String indexGV; // Para agregar a la tabla, puede que no hace falta

        BusinessLogicLayer.BusinessLogic bll;

        protected void Page_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();

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
                DataTable dt = bll.getTareasEstudiante(email);

                updateGrid(dt);

                Session["table"] = dt;
            }
            else
            {
                DataTable dt = (DataTable)Session["table"];
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
            // Codigo DataAccess update table
            String hr = horasRTB.Text;
            DataTable dt = (DataTable)Session["table"];

            if (!hr.Equals(""))
            {
                feedbackTareaL.Visible = true;
                int hrc = int.Parse(hr);

                DataRow dr = dt.NewRow();
                dr["codTarea"] = codTarea;
                dr["hEstimadas"] = he;
                dr["hReales"] = hrc;

                dt.Rows.Add(dr);

                //updateGrid(dt); // Problema que pasa con el Email ???

                // DataTable cambios con email
                dt.Columns.Add("email", typeof(String)).SetOrdinal(0);
                foreach (DataRow row in dt.Rows)
                {
                    //need to set value to NewColumn column
                    row["email"] = email;   // or set it to some other value
                }

                // save changes

                // adapter = Session("adapter");
                // adapter.Update(ds,"TE");
                // ds.AcceptChanges();

                if (dt.HasErrors)
                {
                    feedbackTareaL.ForeColor = System.Drawing.Color.Red;
                    feedbackTareaL.Text = "No se ha creado la tarea!";
                    dt.RejectChanges();
                    updateGrid(dt);
                }
                else
                {
                    dt.AcceptChanges();

                    // Registrar la tarea en el adaptador
                    feedbackTareaL.ForeColor = System.Drawing.Color.Green;
                    feedbackTareaL.Text = "La tarea se ha creado!";

                    dt.Columns.Remove("email");// eleminar la columna email antes de visualizar
                    updateGrid(dt);
                }


                // Se borra
                //if (bll.updateTareasEstudiante(email, codTarea, he, hrc)) // Insertarlo en el DataTable y no directamente en la BD
                //{
                //    // SI Todo es correcto hacer cambios en la BD Update y Accept Changes
                //    // Se ha insertado

                //    feedbackTareaL.ForeColor = System.Drawing.Color.Green;
                //    feedbackTareaL.Text = "La tarea se ha creado!";
                //}
                //else
                //{
                //    // error
                //    feedbackTareaL.ForeColor = System.Drawing.Color.Red;
                //    feedbackTareaL.Text = "No se ha creado la tarea!";
                //}
            }
            else
            {
                // error en las horas reales
            }

        }


        private void updateGrid(DataTable dt)
        {
            tareasIGV.DataSource = dt;
            tareasIGV.DataBind();
        }

    }
}
