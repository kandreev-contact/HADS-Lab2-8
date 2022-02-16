using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroUsuariosWeb
{
    public partial class CamboarPasswordE : System.Web.UI.Page
    {
        // emviar al email la clave aleatoria de 6 digitos al email
        private BusinessLogicLayer.BusinessLogic bll;

        protected void Page_Load(object sender, EventArgs e)
        {
            divSend.Visible = false;
            bll = new BusinessLogicLayer.BusinessLogic();
        }

        protected void RestartPassButton_Click(object sender, EventArgs e)
        {
            String email = EmailTBC.Text;

            // check email
            if (bll.checkUserRegistered(email))
            {
                int passId = bll.generateNumPass();
                bll.changeUserCodePass(email, codpass: passId);
                bll.sendEmailChangePassword(email, passId);
                textDivError.InnerText = "Se ha enviado a tu email el codigo!";
                divSend.Visible = true;
            }
            else
            {
                textDivError.InnerText = "Datos incorrectos!";
                divSend.Visible = true;
            }
        }
    }
}