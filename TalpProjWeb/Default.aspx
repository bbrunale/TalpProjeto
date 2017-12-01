<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TalpProjWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>WalletMan</h1>
        <p class="lead">Gerencie seus gastos, lucros e cumpra metas! </p>
        <p><a href="about" class="btn btn-primary btn-lg">Saber mais!</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Entradas</h2>
            <p>
                Gerencie suas entradas!
            </p>
            <p>
                <a class="btn btn-primary btn-lg" href="Entradas">Gerenciar &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Metas</h2>
            <p>
                Gerencie suas Metas!
            </p>
            <p>
                <a class="btn btn-primary btn-lg" href="Metas">Gerenciar &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
