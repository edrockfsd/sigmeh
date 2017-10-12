<%@ Page Title="CADASTRO DE TIPO DE EQUIPAMENTO" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EquipamentoTipoMan.aspx.cs" Inherits="Sigmeh.View.EquipamentoTipoMan" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script>
            function RowDblClick(sender, eventArgs) {
                editedRow = eventArgs.get_itemIndexHierarchical();
                $find("<%= grdTipoEquipamento.ClientID %>").get_masterTableView().editItem(editedRow);
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxPanel ID="ajaxpanelGeral" runat="server" LoadingPanelID="ajaxLoadingPanelGeral">
        <!-- Controle de notificação -->
        <telerik:RadNotification ID="ntfGeral" runat="server">
        </telerik:RadNotification>
        <!-- Controle de notificação -->
        <section class="featured">
            <hgroup class="title">
                <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                    <h1><%: Title %></h1>
                </telerik:RadCodeBlock>
            </hgroup>
            <telerik:RadPanelBar runat="server" ID="pnbFiltro">
                <Items>
                    <telerik:RadPanelItem Text="Pesquisa Avançada" Expanded="false" Visible="false">
                        <Items>
                            <telerik:RadPanelItem CssClass="dataBox">
                                <ItemTemplate>
                                    <telerik:RadFilter runat="server" ID="ftrEquipamento" FilterContainerID="grdCriticidade" ShowApplyButton="true" Culture="pt-BR"></telerik:RadFilter>
                                </ItemTemplate>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelItem>
                </Items>
            </telerik:RadPanelBar>
            <br />
            <telerik:RadGrid ID="grdTipoEquipamento" runat="server" AutoGenerateColumns="false" Width="50%"
                OnNeedDataSource="grdTipoEquipamento_NeedDataSource"
                OnInsertCommand="grdTipoEquipamento_InsertCommand"
                OnUpdateCommand="grdTipoEquipamento_UpdateCommand"
                OnDeleteCommand="grdTipoEquipamento_DeleteCommand">
                <ClientSettings EnableRowHoverStyle="true">
                    <ClientEvents OnRowDblClick="RowDblClick" />
                </ClientSettings>
                <MasterTableView DataKeyNames="EquipamentoTipoID" EditMode="PopUp" CommandItemDisplay="Top">
                    <Columns>
                        <telerik:GridEditCommandColumn UniqueName="Edit" ButtonType="ImageButton" HeaderText="Alterar" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="4%" ItemStyle-Width="4%">
                        </telerik:GridEditCommandColumn>
                        <telerik:GridButtonColumn ConfirmText="Confirmar a exclusão do registro?" ConfirmDialogType="RadWindow" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="4%" ItemStyle-Width="4%"
                            ConfirmTitle="Delete" HeaderText="Excluir" ButtonType="ImageButton" ImageUrl="Images/btn_delete.gif"
                            CommandName="Delete" Text="Excluir" UniqueName="DeleteColumn">
                        </telerik:GridButtonColumn>                        
                        <telerik:GridBoundColumn DataField="Descricao" UniqueName="colDescricao" HeaderText="Descrição" HeaderStyle-HorizontalAlign="Center" ColumnValidationSettings-EnableRequiredFieldValidation="true" ColumnValidationSettings-RequiredFieldValidator-ErrorMessage="*" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Observacao" UniqueName="colObservacao" HeaderText="Observação" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                    </Columns>
                    <EditFormSettings PopUpSettings-Modal="true">
                        <PopUpSettings Height="250px" Width="700px" />
                    </EditFormSettings>
                </MasterTableView>
            </telerik:RadGrid>
        </section>
    </telerik:RadAjaxPanel>
    <telerik:RadAjaxLoadingPanel ID="ajaxLoadingPanelGeral" runat="server"></telerik:RadAjaxLoadingPanel>
</asp:Content>
