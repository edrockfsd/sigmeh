<%@ Page Title="CADASTRO DE EQUIPAMENTO" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EquipamentoCad.aspx.cs" Inherits="Sigmeh.View.EquipamentoCad" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadAjaxPanel ID="ajaxpanelGeral" runat="server" LoadingPanelID="ajaxLoadingPanelGeral">
        <!-- Controle de notificação -->
        <telerik:RadNotification ID="ntfGeral" runat="server">
        </telerik:RadNotification>
        <!-- Controle de notificação -->
        <telerik:RadWindow ID="winExclusao" runat="server" Width="500px" Height="360px" Modal="true">
            <ContentTemplate>
                Os seguintes registros de manunteção de equipamento estão vinculados a este equipamento:<br />
                <br />
                <asp:BulletedList ID="bltRME" runat="server" BulletStyle="Numbered" DisplayMode="LinkButton" Font-Size="X-Large" ForeColor="Red" OnClick="bltRME_Click">
                </asp:BulletedList>
                <br />
                <br />
                Para excluir o equipamento, primeiramente é necessário desvincular o equipamento destes registros de manutenção, ou excluí-los.
            </ContentTemplate>
        </telerik:RadWindow>
        <div>
            <telerik:RadMenu ID="menu" runat="server" OnItemClick="menu_ItemClick" ValidationGroup="grpBase" OnPreRender="menu_PreRender">
                <Items>
                    <telerik:RadMenuItem runat="server" Text="Arquivo">
                        <Items>
                            <telerik:RadMenuItem runat="server" Text="Novo" ImageUrl="~/Images/btn_file_new.png" Value="novo">
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem runat="server" Text="Listar" ImageUrl="~/Images/btn_folder_open.png" Value="listar">
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem runat="server" Text="Salvar" ImageUrl="~/Images/btn_save.png" Value="salvar" ValidationGroup="grpBase">
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem runat="server" Text="Salvar Como" ImageUrl="~/Images/btn_save_as.png" Value="salvar_como">
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem runat="server" Text="Excluir" ImageUrl="~/Images/btn_delete.png" Value="excluir">
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem runat="server" Text="Imprimir" ImageUrl="~/Images/btn_printer.png" Value="imprimir">
                            </telerik:RadMenuItem>
                        </Items>
                    </telerik:RadMenuItem>
                    <telerik:RadMenuItem runat="server" Text="" IsSeparator="true">
                    </telerik:RadMenuItem>
                    <telerik:RadMenuItem runat="server" Text="Sistema">
                        <Items>
                            <telerik:RadMenuItem runat="server" Text="Ajuda" ImageUrl="~/Images/btn_help.png">
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem runat="server" Text="Sair" ImageUrl="~/Images/btn_quit.png">
                            </telerik:RadMenuItem>
                        </Items>
                    </telerik:RadMenuItem>
                </Items>
            </telerik:RadMenu>
        </div>
        <br />
        <br />
        <br />
        <section class="featured">
            <ul>
                <div class="dataBox">
                    <hgroup class="title">
                        <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                            <h1><%: Title %></h1>
                        </telerik:RadCodeBlock>
                    </hgroup>
                    <table>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblEmpresaVinculada" Text="Empresa Vinculada:" CssClass="sysLabel" />
                            </td>
                            <td>
                                <telerik:RadComboBox ID="ddlEmpresaVinculada" runat="server" AutoPostBack="True" EnableLoadOnDemand="True" EnableVirtualScrolling="true" ItemsPerRequest="20" MarkFirstMatch="True" OnItemsRequested="ddlEmpresaVinculada_ItemsRequested" ShowMoreResultsBox="true" ShowToggleImage="false" Width="300px" EmptyMessage="* Selecione *">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="rfvEmpresaVinculada" runat="server" ControlToValidate="ddlEmpresaVinculada" CssClass="Validator" Display="Dynamic" ErrorMessage="*" ValidationGroup="grpBase"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblEquipamentoTipo" Text="Tipo:" CssClass="sysLabel" />
                            </td>
                            <td>
                                <telerik:RadComboBox ID="ddlEquipamentoTipo" runat="server" AutoPostBack="True" EnableLoadOnDemand="True" EnableVirtualScrolling="true" ItemsPerRequest="20" MarkFirstMatch="True" OnItemsRequested="ddlEquipamentoTipo_ItemsRequested" ShowMoreResultsBox="true" ShowToggleImage="false" Width="300px" EmptyMessage="* Selecione *">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="rfvEquipamentoTipo" runat="server" ControlToValidate="ddlEquipamentoTipo" CssClass="Validator" Display="Dynamic" ErrorMessage="*" ValidationGroup="grpBase"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblNoSerie" runat="server" CssClass="sysLabel" Text="N° de Série:" />
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtNoSerie" runat="server" MaxLength="50" Width="300px">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="rfvNoSerie" runat="server" ControlToValidate="txtNoSerie" CssClass="Validator" Display="Dynamic" ErrorMessage="*" ValidationGroup="grpBase"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblMarcaModelo" runat="server" CssClass="sysLabel" Text="Marca/Modelo:" />
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtMarcaModelo" runat="server" MaxLength="50" Width="300px">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="rfvMarcaModelo" runat="server" ControlToValidate="txtMarcaModelo" CssClass="Validator" Display="Dynamic" ErrorMessage="*" ValidationGroup="grpBase"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblPatrimonio" Text="Patrimônio:" CssClass="sysLabel" />
                            </td>
                            <td>
                                <telerik:RadTextBox runat="server" ID="txtPatrimonio" Width="300px" MaxLength="50"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvPatrimonio"
                                    ValidationGroup="grpBase" CssClass="Validator" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtPatrimonio"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblTag" Text="Tag:" CssClass="sysLabel" />
                            </td>
                            <td>
                                <telerik:RadTextBox runat="server" ID="txtTag" Width="300px" MaxLength="50"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvTag"
                                    ValidationGroup="grpBase" CssClass="Validator" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtTag"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblLocalizacao" Text="Localização 1:" CssClass="sysLabel" />
                            </td>
                            <td>
                                <telerik:RadTextBox runat="server" ID="txtLocalizacao" Width="300px" MaxLength="50"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvLocalizacao"
                                    ValidationGroup="grpBase" CssClass="Validator" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtLocalizacao"></asp:RequiredFieldValidator>
                            </td>
                            <td rowspan="4" style="vertical-align: top;">
                                <asp:Label runat="server" ID="lblAcessorios" Text="Acessórios:" CssClass="sysLabel" />
                                <br />
                                <br />
                                <br />
                                <br />
                                <asp:Label ID="lblInativa" runat="server" CssClass="sysLabel" Text="Inativo:" />
                                <telerik:RadButton ID="chkIsInativo" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="false">
                                </telerik:RadButton>
                            </td>
                            <td rowspan="4" style="vertical-align: top;">
                                <telerik:RadTextBox runat="server" ID="txtAcessorios" Height="65px" TextMode="MultiLine" Width="300px" MaxLength="50"></telerik:RadTextBox>


                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblDescricao" Text="Descrição:" CssClass="sysLabel" />
                            </td>
                            <td>
                                <telerik:RadTextBox runat="server" ID="txtDescricao" Height="65px" TextMode="MultiLine" Width="300px" Wrap="true" MaxLength="50"></telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="sysLabel">Intervalo de manutenção:</span>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="ddlPeriodicidade" runat="server" Width="300px" EmptyMessage="* Selecione *" AutoPostBack="true" OnSelectedIndexChanged="ddlPeriodicidade_SelectedIndexChanged">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="rvfPeriodicidade" runat="server" ControlToValidate="ddlPeriodicidade" CssClass="Validator" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                                <telerik:RadNumericTextBox runat="server" ID="txtPeriodicidadeDias" Width="60px" NumberFormat-DecimalDigits="0"
                                    NumberFormat-GroupSeparator="" Visible="false">
                                </telerik:RadNumericTextBox> <asp:Label ID="lblDias" runat="server" Visible="false" class="sysLabel">dias</asp:Label>
                            </td>                            
                        </tr>
                        <tr>
                            <td><span class="sysLabel">Intervalo de calibração:</span></td>
                            <td>
                                <telerik:RadComboBox ID="ddlPeriodicidadeCalibracao" runat="server" EmptyMessage="* Selecione *" Width="300px">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="rvfPeriodicidadeCalibracao" runat="server" ControlToValidate="ddlPeriodicidadeCalibracao" CssClass="Validator" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </div>
                <div>
                    <asp:Label ID="lblRME" runat="server" Visible="false" class="sysLabel">Registros de manutenção do equipamento</asp:Label>                    
                    <telerik:RadGrid ID="grdRME" runat="server" AutoGenerateColumns="false" OnItemCommand="grdRME_ItemCommand" OnNeedDataSource="grdRME_NeedDataSource" OnItemDataBound="grdRME_ItemDataBound">
                        <ClientSettings EnableRowHoverStyle="true" Selecting-AllowRowSelect="true" />
                        <MasterTableView DataKeyNames="RegistroManutencaoID">
                            <Columns>
                                <telerik:GridBoundColumn DataField="Executor" UniqueName="colExecutor" HeaderText="Executor" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Aprovador" UniqueName="colAprovador" HeaderText="Aprovador" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="OrdemServico" UniqueName="colOrdemServico" HeaderText="O.S" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ManutencaoTipo" UniqueName="colManutencaoTipo" HeaderText="Manutencao" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DataRealizacao" UniqueName="colDataRealizacao" HeaderText="Executada em:" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RelatorioDescricao" UniqueName="colRelatorioDescricao" HeaderText="Relatório Desc." HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DefeitoDescricao" UniqueName="colDefeitoDescricao" HeaderText="Defeito Desc." HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"></telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </ul>
        </section>
    </telerik:RadAjaxPanel>
    <telerik:RadAjaxLoadingPanel ID="ajaxLoadingPanelGeral" runat="server"></telerik:RadAjaxLoadingPanel>
</asp:Content>
