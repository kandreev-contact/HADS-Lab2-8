<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="RegistroUsuariosWeb.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inicio</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="bottom" style="float: left; width: auto">
            <asp:Label ID="Label1" runat="server" Text="E-mail:" Font-Size="Larger"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Label" Font-Size="Larger">Password:</asp:Label>
        </div>
        <div class="bottom" style="float: none; width: auto">
            <asp:TextBox ID="EmailTB" runat="server" Height="31px"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="PassTB" runat="server" Height="31px"></asp:TextBox>
        </div>
        <br />
        <div class="bottom" style="float: none; width: auto">
            <asp:Button ID="Login" runat="server" Text="Login" Height="56px" Width="96px" />
        </div>
        <div class="bottom" style="float: none; width: auto">
            <asp:HyperLink ID="RegistroHL" runat="server">Quiero Registrarme</asp:HyperLink>
            <br />
            <asp:HyperLink ID="CambiarPassHL" runat="server">Cambiar Contraseña</asp:HyperLink>
        </div>
    </form>
</body>
</html>
