<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CamboarPasswordE.aspx.cs" Inherits="RegistroUsuariosWeb.CamboarPasswordE" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignIn Page</title>
    <link rel="stylesheet" type="text/css" href="./css/CommonStyle.css" />
    <link rel="stylesheet" type="text/css" href="./css/cpasswordStyle.css" />
    <link rel="stylesheet" type="text/css" href="./css/cpasswordEStyle.css" />
</head>

<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="header">
                <h1>Lboratorio2-3 HADS-2022</h1>
            </div>

            <div class="loginBox">
                <h1>Cambiar Contraseña</h1>
                <div id="divSend" class="informationDiv" runat="server">
                    <p id="textDivError" runat="server">Datos incorrectos!</p>
                    <div class="infoDIV" runat="server">
                    </div>
                </div>

                <table>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label1" runat="server" Text="E-mail de usuario:"></asp:Label>
                            <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="EmailTBC" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="EmailTBC" class="boxesT" runat="server" TextMode="Email"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="bottomRows" rowspan="2">
                            <asp:Button ID="RestartPassButton" runat="server" Text="Resetear Contraseña" OnClick="RestartPassButton_Click" />
                        </td>

                    </tr>

                </table>
            </div>

            <div class="backgroundBody">
                <img src="./imgs/upvb.jpeg" />
            </div>

            <div class="logo">
                <img src="./imgs/logo.png" />
            </div>

            <div class="footer">
            </div>
        </div>
    </form>
</body>
</html>
