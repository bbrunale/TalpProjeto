<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="TalpProjWeb.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Entre em contato conosco!</h2>
    <h3>Nós ajude a melhorar! Mande criticas e recomendações, ambas serão muito bem vindas!</h3>
    <p>
        Envia E-mail</p>
    <p>
        Nome:</p>
    <p>
        <asp:TextBox ID="TxtNome" runat="server"></asp:TextBox>
    </p>
    <p>
        E-mail:</p>
    <p>
        <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
    </p>
    <p>
        Assunto:</p>
    <p>
        <asp:TextBox ID="TxtAssunto" runat="server"></asp:TextBox>
    </p>
    <p>
        Corpo:</p>
    <p>
        <asp:TextBox ID="TxtCorpo" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="BtnEnviaEmail" runat="server" Text="Enviar" OnClick="BtnEnviaEmail_Click"/>
    </p>
</asp:Content>
