<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Metas.aspx.cs" Inherits="TalpProjWeb.Metas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Metas</h1>
    <br />
    <h3>Gerencie aqui suas metas!</h3>
    <p />
    <p />
    <br />
    <asp:RequiredFieldValidator runat="server" ControlToValidate="TbValorMeta" ErrorMessage="Valor Invalido!"></asp:RequiredFieldValidator>
    <asp:RangeValidator MinimumValue="0" MaximumValue="999999999" runat="server" ControlToValidate="TbValorMeta" ErrorMessage="Valor Invalido!"></asp:RangeValidator>
    <br />
    <asp:Label ID="LblValorMeta" runat="server" Text="Valor: "></asp:Label>
    <asp:TextBox ID="TbValorMeta" runat="server"></asp:TextBox>


    <asp:Label ID="LblDescMeta" runat="server" Text="Descrição: "></asp:Label>
    <asp:TextBox ID="TbDescMeta" runat="server"></asp:TextBox>
    <br />
    <p />

    <asp:Label ID="LblCalMeta" runat="server" Text="Data:"></asp:Label><br />
    <asp:Calendar ID="CalMeta" runat="server" Width="404px" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="178px" NextPrevFormat="FullMonth" TitleFormat="Month">
        <DayHeaderStyle Font-Bold="True" Font-Size="7pt" BackColor="#CCCCCC" ForeColor="#333333" Height="10pt" />
        <DayStyle Width="14%" />
        <NextPrevStyle Font-Size="8pt" ForeColor="White" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
        <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
        <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
        <TodayDayStyle BackColor="#CCCC99" />
    </asp:Calendar>
    <p />

    <asp:Button ID="BtnEnviaMeta" runat="server" Text="Adcionar" OnClick="BtnEnviaMeta_Click" />
    <p />

    &nbsp;<p />

    <asp:GridView ID="GridMetas" runat="server" AutoGenerateColumns="False" Width="100%"
        CellPadding="3" GridLines="Vertical" AllowPaging="True" ShowFooter="true" OnDataBound="GridMetas_DataBound"
        OnPageIndexChanging="GridMetas_PageIndexChanging" AutoGenerateEditButton="True" DataKeyNames="IdMeta"
        OnRowEditing="GridMetas_RowEditing" OnRowUpdating="GridMetas_RowUpdating" OnRowCancelingEdit="GridMetas_RowCancelingEdit"
        OnRowCommand="GridMetas_RowCommand" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black">

        <AlternatingRowStyle BackColor="#CCCCCC" />
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />

        <Columns>
            <asp:BoundField DataField="IdMeta" HeaderText="Id" Visible="false" />
            <asp:BoundField DataField="DescMeta" HeaderText="Descrição" />
            <asp:BoundField DataField="ValorMeta" HeaderText="Valor" />

            <asp:TemplateField HeaderText="Data">
                <ItemTemplate>
                    <asp:Label Text='<%#Bind("DataMeta")%>' ID="lblGridCal" runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Calendar ID="CalGridMeta" SelectedDate='<%#Bind("DataMeta")%>' runat="server" Width="404px" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="178px" NextPrevFormat="FullMonth" TitleFormat="Month">
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
        <asp:Button ID="BtnVoltarMetas" runat="server" Text="Voltar" OnClick="BtnVoltarMetas_Click" />
    </p>
</asp:Content>
