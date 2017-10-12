<%@ Page Title="Listagem de Equipamentos" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EquipamentoLis.aspx.cs" Inherits="Sigmeh.View.EquipamentoLis" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .rbl input[type="radio"] {
            margin-left: 20px;
            margin-right: 20px;
        }
    </style>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script src="Scripts/jquery-1.7.1.min.js"></script>
        <script>
            $(document).ready(function () {
                setpager();
            });

            function setpager() {
                var id = "<%=grdEquipamento.ClientID%>";
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
    <telerik:RadAjaxPanel ID="ajaxpanelGeral" runat="server" LoadingPanelID="ajaxLoadingPanelGeral">
        <!-- Controle de notificação -->
        <telerik:RadNotification ID="ntfGeral" runat="server">
        </telerik:RadNotification>
        <!-- Controle de notificação -->

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
                                    <telerik:RadFilter runat="server" ID="ftrEquipamento" FilterContainerID="grdEquipamento" ShowApplyButton="true" Culture="pt-BR"></telerik:RadFilter>
                                </ItemTemplate>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelItem>
                </Items>
            </telerik:RadPanelBar>
            <asp:RadioButtonList ID="rblFiltroStatusSaida" runat="server" OnSelectedIndexChanged="rblFiltroStatusSaida_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatLayout="Table" AutoPostBack="true" CssClass="rbl">
                <asp:ListItem Text="Todos" Value="todos" Selected="True"></asp:ListItem>
                <asp:ListItem Text="30 dias" Value="30"></asp:ListItem>
                <asp:ListItem Text="15 dias" Value="15"></asp:ListItem>
                <asp:ListItem Text="7 dias" Value="7"></asp:ListItem>
                <asp:ListItem Text="Atrasados" Value="-1"></asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <telerik:RadGrid ID="grdEquipamento" runat="server" AutoGenerateColumns="false" OnItemCommand="grdEquipamento_ItemCommand" OnNeedDataSource="grdEquipamento_NeedDataSource" AllowPaging="true" PageSize="20" AllowMultiRowSelection="true"
                OnItemDataBound="grdEquipamento_ItemDataBound" ShowGroupPanel="true" AllowSorting="true">
                <ClientSettings EnableRowHoverStyle="true" ClientEvents-OnRowDblClick="OnRowDblClick" />
                <MasterTableView DataKeyNames="EquipamentoID" AllowFilteringByColumn="True" CommandItemSettings-ShowRefreshButton="true" CommandItemSettings-RefreshText="Atualizar" CommandItemDisplay="Top" CommandItemSettings-ShowAddNewRecordButton="false"
                    ShowGroupFooter="true" EnableGroupsExpandAll="true">
                    <Columns>
                        <telerik:GridBoundColumn DataField="NumeroSerie" UniqueName="colNumeroSerie" HeaderText="Numero de Série" HeaderStyle-HorizontalAlign="Center" Aggregate="Count" FooterAggregateFormatString="Quantidade: {0}"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Tag" UniqueName="colTag" HeaderText="Tag" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Patrimonio" UniqueName="colPatrimonio" HeaderText="Patrimônio" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Marca_Modelo" UniqueName="colMarcaModelo" HeaderText="Marca/Modelo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Localizacao" UniqueName="colLocalizacao" HeaderText="Localização 1" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ProxPreventiva" UniqueName="colProxPreventiva" HeaderText="Prox. Preventiva (Dias)" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ProxCalibracao" UniqueName="colProxCalibracao" HeaderText="Prox. Calibração (Dias)" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
                <PagerStyle AlwaysVisible="true" Position="TopAndBottom" />
                <ClientSettings ReorderColumnsOnClient="True" AllowDragToGroup="True" AllowColumnsReorder="True">
                    <Selecting AllowRowSelect="True"></Selecting>
                    <Resizing AllowRowResize="True" AllowColumnResize="True" EnableRealTimeResize="True"
                        ResizeGridOnColumnResize="False"></Resizing>
                </ClientSettings>
                <GroupingSettings ShowUnGroupButton="true" GroupSplitDisplayFormat="Mostrando {0} de {1} itens." GroupContinuesFormatString=" Grupo continua na próxima página" GroupContinuedFormatString="... continuação do grupo da página anterior. " UnGroupButtonTooltip="Desagrupar" 
                    UnGroupTooltip="Desagrupar"></GroupingSettings>
                <GroupPanel Text="Arraste aqui os campos que você deseja agrupar"></GroupPanel>
            </telerik:RadGrid>
        </section>
    </telerik:RadAjaxPanel>
    <telerik:RadAjaxLoadingPanel ID="ajaxLoadingPanelGeral" runat="server"></telerik:RadAjaxLoadingPanel>    
</asp:Content>
