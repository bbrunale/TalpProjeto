<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginTeste.aspx.cs" Inherits="TalpProjWeb.LoginTeste" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <title>WalletMan</title>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css">

    <link rel='stylesheet prefetch' href='https://fonts.googleapis.com/css?family=Roboto:400,100,300,500,700,900|RobotoDraft:400,100,300,500,700,900'>
    <link rel='stylesheet prefetch' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css'>

    <link rel="stylesheet" href="css/style.css">
</head>
<body>
    <form id="form1" runat="server">
        <!-- Mixins-->
        <!-- Pen Title-->
        <div class="pen-title">
            <h1>WalletMan</h1>
            <span>Pen <i class='fa fa-code'></i>by <a href='http://andytran.me'>Andy Tran</a></span>
        </div>
        <div class="container">
            <div class="card"></div>
            <div class="card">
                <h1 class="title">Login</h1>
                
                    <div class="input-container">
                        <input type="text" id="txtEmail" name="txtEmail" required="required" runat="server" />
                        <label for="txtId">Email</label>
                        <div class="bar"></div>
                    </div>
                    <div class="input-container">
                        <input type="password" id="txtSenha" name="txtSenha" required="required" runat="server" />
                        <label for="txtSenha">Senha</label>
                        <div class="bar"></div>
                    </div>
                    <div class="button-container">
                        <button runat="server" onserverclick="EnviarLogin"><span>Enviar</span></button>
                    </div>
                    <div class="footer"><a href="#">Esqueceu a senha?</a></div>
                
            </div>
            <div class="card alt">
                <div class="toggle"></div>
                <h1 class="title">Cadastrar
     
                    <div class="close"></div>
                </h1>
                
                    <div class="input-container">
                        <input type="text" id="txtNomeCad" name="txtNomeCad" required="required" runat="server" />
                        <label for="txtNomeCad">Nome</label>
                        <div class="bar"></div>
                    </div>
                    <div class="input-container">
                        <input type="text" id="txtEmailCad" name="txtEmailCad" required="required" runat="server" />
                        <label for="txtEmailCad">Email</label>
                        <div class="bar"></div>
                    </div>
                    <div class="input-container">
                        <input type="password" id="txtSenhaCad" name="txtSenhaCad" runat="server" required="required" />
                        <label for="txtSenhaCad">Senha</label>
                        <div class="bar"></div>
                    </div>
                    <div class="input-container">
                        <input type="password" id="txtSenha2Cad" runat="server" name="txtSenha2Cad" required="required" />
                        <label for="txtSenha2Cad">Confirmar senha</label>
                        <div class="bar"></div>
                    </div>

                    <div class="button-container">
                        <button onserverclick="EnviarCadastra" runat="server"><span>Prosseguir</span></button>
                    </div>
                
            </div>
        </div>
        <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>

        <script src="js/index.js"></script>

    </form>
</body>
</html>
