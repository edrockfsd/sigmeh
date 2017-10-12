<%@ Page Title="Listagem de Entidades" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EntidadeLis.aspx.cs" Inherits="Sigmeh.View.EntidadeLis" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script src="Scripts/jquery-1.7.1.min.js"></script>
        <script>
            $(document).ready(function () {
                setpager();
            });

            function setpager() {
                var id = "<%=grdEntidade.ClientID%>";
                $("#" + id + " .rgPagerCell:first").find('div').not(".rgInfoPart").css('display', 'none');
                $("#" + id + " .rgPagerCell:last").find('.rgInfoPart').css('display', 'none');
            }

            function OnRowDblClick(sender, eventArgs) {
                var index = eventArgs.get_itemIndexHierarchical();
                sender.get_masterTableView().fireCommand("RowDblClick", index);
            }
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <section class="featured">
        <hgroup class="title">
            <h1>
                <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                    <%: Title %>
                </telerik:RadCodeBlock>

            </h1>
        </hgroup>

        <telerik:RadPanelBar runat="server" ID="pnbFiltro" Visible="false">
            <Items>
                <telerik:RadPanelItem Text="Pesquisa Avançada" Expanded="false">
                    <Items>
                        <telerik:RadPanelItem CssClass="dataBox">
                            <ItemTemplate>
                                <telerik:RadFilter runat="server" ID="ftrEntidade" FilterContainerID="grdEntidade" ShowApplyButton="true" Culture="pt-BR"></telerik:RadFilter>
                            </ItemTemplate>
                        </telerik:RadPanelItem>
                    </Items>
                </telerik:RadPanelItem>
            </Items>
        </telerik:RadPanelBar>
        <br />
        <telerik:RadGrid ID="grdEntidade" runat="server" AutoGenerateColumns="false" OnNeedDataSource="grdEntidade_NeedDataSource" OnItemCommand="grdEntidade_ItemCommand">
            <ClientSettings EnableRowHoverStyle="true" ClientEvents-OnRowDblClick="OnRowDblClick"/>
            <MasterTableView DataKeyNames="EntidadeID" AllowFilteringByColumn="True" CommandItemSettings-ShowRefreshButton="true" CommandItemSettings-RefreshText="Atualizar" CommandItemDisplay="Top" CommandItemSettings-ShowAddNewRecordButton="false">
                <Columns>
                    <telerik:GridBoundColumn DataField="Nome" UniqueName="colNome" HeaderText="Nome/R. Social" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Apelido" UniqueName="colApelido" HeaderText="Apelido/Fantasia" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TipoPessoa" UniqueName="colTipoPessoa" HeaderText="Pessoa Tipo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CPF_CNPJ" UniqueName="colCPF_CNPJ" HeaderText="CPF/CNPJ" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Telefone" UniqueName="colTelefone" HeaderText="Telefone" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Canal" UniqueName="colCanal" HeaderText="Canal Com." HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"></telerik:GridBoundColumn>
                    <telerik:GridImageColumn DataImageUrlFields="EntidadeTipo" DataAlternateTextField="EntidadeTipo" DataImageUrlFormatString="Images/{0}_icon.png" UniqueName="colTipoEntidade" HeaderText="Tipo Entidade" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="center" ImageHeight="32px" ImageWidth="32px"></telerik:GridImageColumn>
                </Columns>
            </MasterTableView>
            <PagerStyle AlwaysVisible="true" Position="TopAndBottom" />
        </telerik:RadGrid>
    </section>
</asp:Content>
