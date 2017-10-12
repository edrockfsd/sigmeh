<%@ Page Title="Listagem de Registro de Manutenção de Equipamento" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RMELis.aspx.cs" Inherits="Sigmeh.View.RMELis" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script src="Scripts/jquery-1.7.1.min.js"></script>
        <script>
            $(document).ready(function () {
                setpager();
            });

            function setpager() {
                var id = "<%=grdRME.ClientID%>";
                $("#" + id + " .rgPagerCell:first").find('div').not(".rgInfoPart").css('display', 'none');
                $("#" + id + " .rgPagerCell:last").find('.rgInfoPart').css('display', 'none');
            }

            function OnRowDblClick(sender, eventArgs)
            {
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
        <div>
            <telerik:RadMenu ID="menu" runat="server" OnItemClick="menu_ItemClick">
                <Items>
                    <telerik:RadMenuItem runat="server" Text="Arquivo">
                        <Items>
                            <telerik:RadMenuItem runat="server" Text="Relatório" ImageUrl="~/Images/btn_printer.png" Value="imprimir">
                            </telerik:RadMenuItem>
                        </Items>
                    </telerik:RadMenuItem>
                </Items>
            </telerik:RadMenu>
        </div>
        <section class="featured"><br />
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
                                    <telerik:RadFilter runat="server" ID="ftrRME" FilterContainerID="grdRME" ShowApplyButton="true" Culture="pt-BR"></telerik:RadFilter>
                                </ItemTemplate>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelItem>
                </Items>
            </telerik:RadPanelBar>
            <br />
            <telerik:RadGrid ID="grdRME" runat="server" AutoGenerateColumns="false" OnItemCommand="grdRME_ItemCommand" OnNeedDataSource="grdRME_NeedDataSource" OnItemDataBound="grdRME_ItemDataBound" AllowPaging="true" PageSize="20" 
                AllowMultiRowSelection="true" ShowGroupPanel="true" AllowSorting="true">
                <ClientSettings EnableRowHoverStyle="true" Selecting-AllowRowSelect="true" ClientEvents-OnRowDblClick="OnRowDblClick"/>
                <MasterTableView DataKeyNames="RegistroManutencaoID" AllowFilteringByColumn="True" CommandItemSettings-ShowRefreshButton="true" CommandItemSettings-RefreshText="Atualizar" CommandItemDisplay="Top" CommandItemSettings-ShowAddNewRecordButton="false"
                    ShowGroupFooter="true" EnableGroupsExpandAll="true">
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="colCheck" ItemStyle-HorizontalAlign="Center">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn DataField="RegistroManutencaoID" DataFormatString="{0:0000}" UniqueName="colIdentificador" HeaderText="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Aggregate="Count" FooterAggregateFormatString="Quantidade: {0}"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EquipamentoNumeroSerie" UniqueName="colEquipamentoNumeroSerie" HeaderText="Equipamento" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Executor" UniqueName="colExecutor" HeaderText="Executor" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Aprovador" UniqueName="colAprovador" HeaderText="Aprovador" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"></telerik:GridBoundColumn>                        
                        <telerik:GridBoundColumn DataField="ManutencaoTipo" UniqueName="colManutencaoTipo" HeaderText="Manutencao" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="DataRealizacao" UniqueName="colDataRealizacao" HeaderText="Executada em" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="RelatorioDescricao" UniqueName="colRelatorioDescricao" HeaderText="Relatório" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"></telerik:GridBoundColumn>                        
                        <telerik:GridBoundColumn DataField="DefeitoDescricao" UniqueName="colDefeitoDescricao" HeaderText="Defeito" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"></telerik:GridBoundColumn>                        
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
