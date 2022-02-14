<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarPassword.aspx.cs" Inherits="RegistroUsuariosWeb.CambiarPass" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignIn Page</title>
    <link rel="stylesheet" type="text/css" href="./css/CommonStyle.css" />
    <link rel="stylesheet" type="text/css" href="./css/cpasswordStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="header">
                <h1>Lboratorio2-3 HADS-2022</h1>
            </div>

            <div class="loginBox">
                <h1>Cambiar Contraseña</h1>
                <div class="informationDiv">
                    <p>Introduce el codigo enviado a tu email!</p>
                    <div class="infoDIV">
                    </div>
                </div>

                <table>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label3" runat="server" Text="Codigo:"></asp:Label>
                            <asp:RequiredFieldValidator ID="CodeRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="CodeTBC" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="CodeTBC" class="boxesT" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label1" runat="server" Text="Contraseña nueva:"></asp:Label>
                            <asp:RequiredFieldValidator ID="PassRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="PasswordTBC" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="PasswordTBC" class="boxesT" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label2" runat="server" Text="Repite la contraseña:"></asp:Label>
                            <asp:RequiredFieldValidator ID="PassRRequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="PasswordTBCC" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="PasswordTBCC" class="boxesT" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                        </td>
                    </tr>

                    <tr>
                        <td class="bottomRows" rowspan="2">
                            <asp:Button ID="CambiarPassButton" runat="server" Text="Cambiar Contraseña" OnClick="CambiarPassButton_Click" />
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
