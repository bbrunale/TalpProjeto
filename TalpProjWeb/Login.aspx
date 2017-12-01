<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TalpProjWeb.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>Material Login Form</title>

        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css">

        <link rel='stylesheet prefetch' href='https://fonts.googleapis.com/css?family=Roboto:400,100,300,500,700,900|RobotoDraft:400,100,300,500,700,900'>
        <link rel='stylesheet prefetch' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css'>

        <link rel="stylesheet" href="css/style.css">
    </head>

    <body>

        <!-- Mixins-->
        <!-- Pen Title-->
        <div class="pen-title">
            <h1>Material Login Form</h1>
            <span>Pen <i class='fa fa-code'></i>by <a href='http://andytran.me'>Andy Tran</a></span>
        </div>
        <div class="container">
            <div class="card"></div>
            <div class="card">
                <h1 class="title">Login</h1>
                <form>
                    <div class="input-container">
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" ErrorMessage="E-mail Invalido!"></asp:RequiredFieldValidator>
                        <input type="text" id="txtEmail" name="txtEmail" required="required" runat="server" />
                        <label for="txtId">Id do Usuario</label>
                        <div class="bar"></div>
                    </div>
                    <div class="input-container">
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtSenha" ErrorMessage="Senha Invalida!"></asp:RequiredFieldValidator>
                        <input type="password" id="txtSenha" name="txtSenha" required="required" runat="server" />
                        <label for="txtSenha">Senha</label>
                        <div class="bar"></div>
                    </div>
                    <div class="button-container">
                        <button runat="server" onserverclick="EnviarLogin"><span>Enviar</span></button>
                    </div>
                    <div class="footer"><a href="#">Esqueceu a senha?</a></div>
                </form>
            </div>
            <div class="card alt">
                <div class="toggle"></div>
                <h1 class="title">Cadastrar
     
                    <div class="close"></div>
                </h1>
                <form runat="server" >
                    <div class="input-container">
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtSenha2Cad" ErrorMessage="Nome Invalido!"></asp:RequiredFieldValidator>
                        <input type="text" id="txtNomeCad" name="txtNomeCad" required="required" runat="server" />
                        <label for="txtNomeCad">Nome</label>
                        <div class="bar"></div>
                    </div>
                    <div class="input-container">
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtSenha2Cad" ErrorMessage="E-mail Invalido!"></asp:RequiredFieldValidator>
                        <input type="text" id="txtEmailCad" name="txtEmailCad" required="required" runat="server" />
                        <label for="txtEmailCad">Email</label>
                        <div class="bar"></div>
                    </div>
                    <div class="input-container">
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtSenhaCad" ErrorMessage="Senha Invalida!"></asp:RequiredFieldValidator>
                        <input type="password" id="txtSenhaCad" name="txtSenhaCad" runat="server" required="required" />
                        <label for="txtSenhaCad">Senha</label>
                        <div class="bar"></div>
                    </div>
                    <div class="input-container">
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtSenha2Cad" ErrorMessage="Senha Invalida!"></asp:RequiredFieldValidator>
                        <input type="password" id="txtSenha2Cad" runat="server" name="txtSenha2Cad" required="required" />
                        <label for="txtSenha2Cad">Confirmar senha</label>
                        <div class="bar"></div>
                    </div>

                    <div class="button-container">
                        <button onserverclick="EnviarCadastra" runat="server"><span>Next</span></button>
                    </div>
                </form>
            </div>
        </div>
        <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>

        <script src="js/index.js"></script>

    </body>
    </html>



</asp:Content>
