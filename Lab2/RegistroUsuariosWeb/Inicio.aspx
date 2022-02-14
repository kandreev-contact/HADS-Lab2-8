<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="RegistroUsuariosWeb.Inicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignIn Page</title>
    <link rel="stylesheet" type="text/css" href="./css/CommonStyle.css" />
    <link rel="stylesheet" type="text/css" href="./css/inicioStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="header">
                <h1>Lboratorio2-3 HADS-2022</h1>
            </div>

            <div class="loginBox">
                <h1>Sign In</h1>

                <div id="divSend" class="informationDiv" runat="server">
                    <p>Datos incorrectos!</p>
                    <div class="infoDIV" runat="server">
                    </div>
                </div>

                <table>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label1" runat="server" Text="E-Mail de usuario:"></asp:Label>
                            <asp:RequiredFieldValidator ID="EmailRFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="EmailTB" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="EmailTB" class="boxesT" runat="server" TextMode="Email"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label2" runat="server" Text="Contraseña:"></asp:Label>
                            <asp:RequiredFieldValidator ID="PasswordRFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="PasswordTB" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="PasswordTB" class="boxesT" runat="server" TextMode="Password"></asp:TextBox>
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
                        <td colspan="2">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="bottomRows" rowspan="2">
                            <asp:Button ID="LoginButton" runat="server" Text="Acceder" OnClick="LoginButton_Click" />
                        </td>
                        <td class="bottomRowsL">
                            <asp:LinkButton ID="RegistroLB" runat="server" OnClick="RegistroLB_Click" CausesValidation="False" PostBackUrl="~/Registro.aspx">Registratse</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td class="bottomRowsL">
                            <asp:LinkButton ID="CambiarPassLB" runat="server" OnClick="CambiarPassLB_Click" CausesValidation="False" PostBackUrl="~/CamboarPasswordE.aspx">Cambiar Password</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>

            <div class="informationBox">
                <h1>Diseño de la aplicación web
                    <br />
                    para registro de usuarios  </h1>
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
