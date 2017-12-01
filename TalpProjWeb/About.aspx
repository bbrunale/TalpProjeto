<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TalpProjWeb.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Sobre nós!</h2>
    <h3>Esse é um site que  que visa auxiliar o usuario a manter suas metas financeiras permitindo que ele de entrada nos mais diversos
        dados e os gerencie!
    </h3>
    <p>Para mais duvidas ou recomendacoes va em Contato e mande um email para nos!</p>
    <asp:Button ID="BtnContato" runat="server" Text="Contato" OnClick="BtnContato_Click" />
</asp:Content>
