<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Estudiante.aspx.cs" Inherits="RegistroUsuariosWeb.Alumnos.Estudiante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Entrada Alumno</title>
    <link rel="stylesheet" type="text/css" href="../css/CommonStyle.css" />
    <link rel="stylesheet" type="text/css" href="../css/alumnoStyle.css" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="container">
            <div class="headerLeft">
                <table id="FunctionsAlumno">
                    <tr>
                        <td>
                            <asp:Button class="functionsButtons" ID="tareasButton" runat="server" Text="Ver Tareas" OnClick="tareasButton_Click" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button class="functionsButtons" ID="cerrarSesionButton" runat="server" Text="Cerrar Sesion" OnClick="cerrarSesionButton_Click" /></td>
                    </tr>
                </table>
            </div>
            <div class="header">
                <h1>Entrada Alumno</h1>
            </div>

            <div class="loginBox">
                <h1 id="headerConfirmation" runat="server">Gestion Web de Tareas-Dedicacion</h1>
                <p id="HelloMsg" runat="server">Bienvenido de nuevo</p>
            </div>


            <div class="backgroundBody">
                <img src="../imgs/upvb.jpeg" />
            </div>

            <div class="logo">
                <img src="../imgs/logo.png" />
            </div>

            <div class="footer">
            </div>
        </div>
    </form>
</body>
</html>
