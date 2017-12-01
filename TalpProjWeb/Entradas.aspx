<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Entradas.aspx.cs" Inherits="TalpProjWeb.Entradas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Entradas</h1>
    <br />
    <h3>Gerencie aqui suas entradas!</h3>
    <p />
    <p />

    <asp:Label ID="LblTipoOpEnt" runat="server" Text="Tipo de operacao:"></asp:Label>
    <asp:DropDownList ID="DdlTipoOpEnt" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DdlTipoOpEnt_SelectedIndexChanged">
        <asp:ListItem Text="Adcionar" Value="add" Selected="True"></asp:ListItem>
        <asp:ListItem Text="Pesquisar" Value="pes"></asp:ListItem>
    </asp:DropDownList>

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
    <asp:Label ID="LblTipoPesEnt" runat="server" Text="Pesquisar por:" Visible="false"></asp:Label>
    <asp:DropDownList ID="DdlTipoPesEnt" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DdlTipoPesEnt_SelectedIndexChanged">
        <asp:ListItem Text="Todos" Value="all" Selected="True"></asp:ListItem>
        <asp:ListItem Text="Nome" Value="nome"></asp:ListItem>
        <asp:ListItem Text="Tipo" Value="tipo"></asp:ListItem>
    </asp:DropDownList>

    <p />

    <p />

    <asp:RequiredFieldValidator runat="server" ControlToValidate="TbNomeEnt" ErrorMessage="Nome Invalido!"></asp:RequiredFieldValidator>
    <br />
    &nbsp;<asp:Label ID="LblNomeEnt" runat="server" Text="Nome: "></asp:Label>
    <asp:TextBox ID="TbNomeEnt" runat="server"></asp:TextBox>


    &nbsp;<asp:Label ID="LblCatEnt" runat="server" Text="Categoria:"></asp:Label>
    <asp:DropDownList ID="DdlCatEnt" runat="server">
        <asp:ListItem Text="Despesa" Value="1" Selected="True" />
        <asp:ListItem Text="Lucro" Value="2" />
    </asp:DropDownList>
    <br />

    <asp:Panel ID="PnlAddEnt" runat="server">

        <asp:RequiredFieldValidator runat="server" ControlToValidate="TbValorEnt" ErrorMessage="Valor Invalido!"></asp:RequiredFieldValidator>
        <asp:RangeValidator MinimumValue="0" MaximumValue="999999999" runat="server" ControlToValidate="TbValorEnt" ErrorMessage="Valor Invalido!"></asp:RangeValidator>
        <br />
        <asp:Label ID="LblValorEnt" runat="server" Text="Valor: "></asp:Label>
        &nbsp;<asp:TextBox ID="TbValorEnt" runat="server"></asp:TextBox>


        <asp:Label ID="LblDescEnt" runat="server" Text="Descrição: "></asp:Label>
        <asp:TextBox ID="TbDescEnt" runat="server"></asp:TextBox>

        &nbsp;<asp:Label ID="LblParcEnt" runat="server" Text="N°Parcelas: "></asp:Label>
        <asp:TextBox ID="TbParcEnt" runat="server"></asp:TextBox>
        <br />


        <asp:Label ID="LblCalEnt" runat="server" Text="Data:"></asp:Label><br />
        <asp:Calendar ID="CalEnt" runat="server" Width="404px" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="178px" NextPrevFormat="FullMonth" TitleFormat="Month">
            <DayHeaderStyle Font-Bold="True" Font-Size="7pt" BackColor="#CCCCCC" ForeColor="#333333" Height="10pt" />
            <DayStyle Width="14%" />
            <NextPrevStyle Font-Size="8pt" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
            <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
            <TodayDayStyle BackColor="#CCCC99" />
        </asp:Calendar>

    </asp:Panel>

    <p />
    <p />
    <asp:Button ID="BtnEnviar" runat="server" Text="Enviar" OnClick="BtnEnviar_Click" />

    <asp:GridView ID="GridEnt" runat="server" OnDataBound="GridEnt_DataBound" AutoGenerateColumns="False" Width="100%" OnRowCommand="GridEnt_RowCommand"
        CellPadding="3" GridLines="Vertical" AllowPaging="True" PageSize="5" ShowFooter ="True"
        OnRowEditing="GridEnt_RowEditing" OnRowUpdating="GridEnt_RowUpdating" OnRowCancelingEdit="GridEnt_RowCancelingEdit"
        OnPageIndexChanging="GridEnt_PageIndexChanging" AutoGenerateEditButton="True" DataKeyNames="IdEntrada" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black">

        <AlternatingRowStyle BackColor="#CCCCCC" />
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />

        <Columns>

            <asp:BoundField DataField="IdEntrada" HeaderText="Id" Visible="false" />
            <asp:BoundField DataField="NomeEntrada" HeaderText="Nome" />
            <asp:BoundField DataField="ValorEntrada" HeaderText="Valor" />

            <asp:TemplateField HeaderText="Categoria">
                <ItemTemplate>
                    <asp:Label Text='<%#Bind("NomeCat")%>' ID="lblGridCat" runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="DdlGridCatEnt" runat="server">
                        <asp:ListItem Text="Despesa" Value="1" Selected="True" />
                        <asp:ListItem Text="Lucro" Value="2" />
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Data">
                <ItemTemplate>
                    <asp:Label Text='<%#Bind("DataEntrada")%>' ID="lblGridCal" runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Calendar ID="CalGridEnt" SelectedDate='<%#Bind("DataEntrada")%>' runat="server" Width="404px" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="178px" NextPrevFormat="FullMonth" TitleFormat="Month">
                        <DayHeaderStyle Font-Bold="True" Font-Size="7pt" BackColor="#CCCCCC" ForeColor="#333333" Height="10pt" />
                        <DayStyle Width="14%" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                        <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                        <TodayDayStyle BackColor="#CCCC99" />
                    </asp:Calendar>
                </EditItemTemplate>
            </asp:TemplateField>
            
            <asp:BoundField DataField="DescEntrada" HeaderText="Descricao" />
            <asp:ButtonField ButtonType="Button" Text="Excluir" CommandName="Excluir" />
        </Columns>

        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />

    </asp:GridView>
    <p>
        <asp:Button ID="BtnVoltarEnt" runat="server" Text="Voltar" OnClick="BtnVoltarEnt_Click" />
    </p>
</asp:Content>
