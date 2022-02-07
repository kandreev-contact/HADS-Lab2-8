<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="RegistroUsuariosWeb.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inicio</title>
    <link rel="stylesheet" href="InicioStyle.css" />
</head>
<body>
    <form id="form1" runat="server">

        <table>
            <tr>
                <td id="headingTable" colspan="2">
                    <h1>Register</h1>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="E-Mail:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="EmailTB" runat="server"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td><asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
                </td>
                <td><asp:TextBox ID="PasswordTB" runat="server"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td rowspan="2">
                    <asp:Button ID="LoginButton" runat="server" Text="Login" />
                </td>
                <td>
                    <asp:LinkButton ID="RegistroLB" runat="server">Registratse</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td><asp:LinkButton ID="CambiarPassLB" runat="server">Cambiar Pass</asp:LinkButton>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
