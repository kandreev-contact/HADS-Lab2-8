<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="RegistroUsuariosWeb.Registro" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Page</title>
    <link rel="stylesheet" type="text/css" href="./css/CommonStyle.css" />
    <link rel="stylesheet" type="text/css" href="./css/registroStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="header">
                <h1>Lboratorio2-3 HADS-2022</h1>
            </div>

            <div class="loginBox">
                <h1>Sign Up</h1>

                <div id="divSend" class="informationDiv" runat="server">
                    <p>Se ha enviado a tu email!</p>
                    <div class="infoDIV">
                    </div>
                </div>

                <table>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label1" runat="server" Text="E-Mail de usuario:"></asp:Label>
                            <asp:RequiredFieldValidator ID="EmailRFieldValidator" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="EmailTBR">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="EmailTBR" class="boxesT" runat="server" TextMode="Email"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:RegularExpressionValidator ID="EmailRExpressionValidator" runat="server" ErrorMessage="E-mail no valido!" ForeColor="Red" ControlToValidate="EmailTBR" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label4" runat="server" Text="Nombre y Apellido:"></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="NameTB" class="boxesNAA" runat="server" TextMode="SingleLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="NameRFieldValidator" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="NameTB">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="SurnameTB" class="boxesNAA" runat="server" TextMode="SingleLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="SurnameRFieldValidator" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="SurnameTB">*</asp:RequiredFieldValidator>

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
                            <asp:RequiredFieldValidator ID="PasswordRFieldValidator" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="PasswordTBR">*</asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="PassLengthValidator" runat="server" ErrorMessage="Minimo 6 caracteres" ClientValidationFunction="PassLengthValidator" ControlToValidate="PasswordTBR" ForeColor="Red"></asp:CustomValidator>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="PasswordTBR" class="boxesT" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label3" runat="server" Text="Repite la contraseña:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RPasswordRFieldValidator" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="PasswordTBRR">*</asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="PasswordsEValidators" runat="server" ErrorMessage="Password doesn't match!" ForeColor="Red" ControlToValidate="PasswordTBRR"></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="PasswordTBRR" class="boxesT" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: right">
                            <asp:RequiredFieldValidator ID="RadioRFieldValidator" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="RoleSelectRBL">*</asp:RequiredFieldValidator>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="bottomRows">
                            <asp:Button ID="RegisterButton" runat="server" Text="Registrarse" OnClick="RegisterButton_Click" />
                        </td>
                        <td class="bottomRowsL">
                            <asp:RadioButtonList ID="RoleSelectRBL" runat="server">
                                <asp:ListItem Text="Estudiante" Value="1" />
                                <asp:ListItem Text="Profesor" Value="2" />
                            </asp:RadioButtonList>
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
