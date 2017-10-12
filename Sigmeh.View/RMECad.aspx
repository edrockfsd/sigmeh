<%@ Page Title="REGISTRO DE MANUTENÇÃO DE EQUIPAMENTO (R.M.E)" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RMECad.aspx.cs" Inherits="Sigmeh.View.RMECad" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function conditionalPostback(sender, args) {
                if (args.get_eventTarget() == "<%= btnEnviar.UniqueID %>") {
                    args.set_enableAjax(false);
                }
            }
            //<![CDATA[

            function validationFailed(radAsyncUpload, args) {
                var $row = $(args.get_row());
                var erorMessage = getErrorMessage(radAsyncUpload, args);
                var span = createError(erorMessage);
                //$row.addClass("ruError");
                $row.append(span);
            }

            function getErrorMessage(sender, args) {
                var fileExtention = args.get_fileName().substring(args.get_fileName().lastIndexOf('.') + 1, args.get_fileName().length);
                if (args.get_fileName().lastIndexOf('.') != -1) {//this checks if the extension is correct
                    if (sender.get_allowedFileExtensions().indexOf(fileExtention) == -1) {
                        return ("Este tipo de arquivo não é permitido.");
                    }
                    else {                     
                        return ("Este arquivo excedeu o limite permitido de 1 mb.");
                    }
                }
                else {
                    return ("Extensão de arquivo inválida.");
                }
            }

            function createError(erorMessage) {
                var input = '<br/><span style="color:red;">' + erorMessage + ' </span>';
                return input;
            }
            //]]>


            function onRequestStart(ajaxManager, eventArgs) {
                if (eventArgs.EventTarget.indexOf("btnCalibracaoUpload") != -1) {
                    eventArgs.EnableAjax = false;
                }
            }

            var lastClickedItem = null;
            var clickCalledAfterRadprompt = false;
            var clickCalledAfterRadconfirm = false;
            function onClientItemClicking(sender, args) {
                if (args.get_item().get_text() == "Salvar") {
                    var hdnEquipamentoID = document.getElementById("<%= hdnEquipamentoID.ClientID %>");
                    if (hdnEquipamentoID.value != null && hdnEquipamentoID.value != "") {
                        var comboItem = $find("<%= ddlStatus.ClientID %>").get_selectedItem();
                        if (comboItem != null) {
                            if (comboItem._text == "Finalizado") {
                                if (!clickCalledAfterRadconfirm) {
                                    args.set_cancel(true);
                                    lastClickedItem = args.get_item();
                                    radconfirm("Após finalizar um registro de manutenção, não será mais possível alterá-lo.<br />Deseja continuar?", confirmCallbackFunction, 500, 230);
                                }
                            }
                        }
                    }
                }

            }
            function confirmCallbackFunction(args) {
                if (args) {
                    clickCalledAfterRadconfirm = true;
                    lastClickedItem.click();
                }
                else
                    clickCalledAfterRadconfirm = false;
                lastClickedItem = null;
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <table width="100%">
        <tr>
            <td>
                <telerik:RadMenu ID="menu" runat="server" OnItemClick="menu_ItemClick" OnPreRender="menu_PreRender" OnClientItemClicking="onClientItemClicking">
                    <Items>
                        <telerik:RadMenuItem runat="server" Text="Arquivo">
                            <Items>
                                <telerik:RadMenuItem runat="server" Text="Novo" NavigateUrl="RMECad.aspx" ImageUrl="~/Images/btn_file_new.png" Value="novo">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem runat="server" Text="Listar" NavigateUrl="RMELis.aspx" ImageUrl="~/Images/btn_folder_open.png" Value="listar">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem runat="server" Text="Salvar" ImageUrl="~/Images/btn_save.png" Value="salvar">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem runat="server" Text="Salvar Como" ImageUrl="~/Images/btn_save_as.png" Value="salvar_como">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem runat="server" Text="Excluir" ImageUrl="~/Images/btn_delete.png" Value="excluir">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem runat="server" Text="Imprimir" ImageUrl="~/Images/btn_printer.png" Value="imprimir" OnClientClick="confirmAspButton(this); return false;">
                                </telerik:RadMenuItem>
                            </Items>
                        </telerik:RadMenuItem>                        
                    </Items>
                </telerik:RadMenu>
            </td>
            <td style="text-align:right;">
                <asp:Image ID="imgLock" runat="server" ImageUrl="~/Images/lock.png" Visible="false" />
            </td>
        </tr>
    </table>
        </div>
    <telerik:RadAjaxPanel ID="ajaxpanelGeral" runat="server" LoadingPanelID="ajaxLoadingPanelGeral" ClientEvents-OnRequestStart="onRequestStart">
        <!-- Controle de notificação -->
        <telerik:RadNotification ID="ntfGeral" runat="server">
        </telerik:RadNotification>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true" Width="500px" Height="300px" CssClass="zindexH">
        </telerik:RadWindowManager>
        <!-- Controle de notificação -->        
        <section class="featured">
            <asp:Panel runat="server" ID="pnlMsgRmeAberta" BackColor="#ccff66" Visible="false">
                <h1>Existe um registro de manutenção aberto para este equipamento. É necessário finalizar este registro para poder abrir um novo registro de manutenção.<br />
                    Para acessar o registro aberto <asp:HyperLink ID="lnkRMEAberta" runat="server" Text="CLIQUE AQUI"></asp:HyperLink>
                </h1>
            </asp:Panel>
            <ul>
                <div class="dataBox">
                    <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                        <hgroup class="title">
                            <h1><%: Title %></h1>
                        </hgroup>
                    </telerik:RadCodeBlock>
                    <table>
                        <tr>
                            <td colspan="4" style="text-align: right;">
                                <asp:Label runat="server" ID="lblTituloIdentificador" Text="Identificador:" CssClass="sysLabel" />
                                <asp:Label runat="server" ID="lblIdentificador" CssClass="sysLabel" Font-Bold="true" />
                                &nbsp;</td>

                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblEquipamento" Text="Equipamento:" CssClass="sysLabel" Font-Bold="true" />
                            </td>
                            <td>
                                <telerik:RadComboBox runat="server" ID="ddlEquipamento" OnItemsRequested="ddlEquipamento_ItemsRequested" OnSelectedIndexChanged="ddlEquipamento_SelectedIndexChanged" Width="300px"
                                    AutoPostBack="True" ShowToggleImage="false" MarkFirstMatch="True" EnableLoadOnDemand="True" ShowMoreResultsBox="true" EmptyMessage="* Selecione *"
                                    EnableVirtualScrolling="true" ItemsPerRequest="20" CausesValidation="false">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="rfvEquipamento" runat="server" ControlToValidate="ddlEquipamento" CssClass="Validator" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                                <telerik:RadTextBox runat="server" ID="txtEquipamento" Width="300px" Enabled="false" Visible="false"></telerik:RadTextBox>
                                <asp:HiddenField ID="hdnEquipamentoID" runat="server" />
                            </td>
                            <td colspan="2" rowspan="4" style="vertical-align: top;">
                                <div class="dataBoxMini">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="font-weight: bold;">N° de Série:</td>
                                            <td>
                                                <asp:Label ID="lblNoSerie" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td style="font-weight: bold;">Acessórios:</td>
                                            <td>
                                                <asp:Label ID="lblAcessorios" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-weight: bold;">Patrimônio:</td>
                                            <td>
                                                <asp:Label ID="lblPatrimonio" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td style="font-weight: bold;">Descrição:</td>
                                            <td>
                                                <asp:Label ID="lblDescricao" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-weight: bold;">Localização 1:</td>
                                            <td>
                                                <asp:Label ID="lblLocalizacao" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td style="font-weight: bold;">Marca/Modelo:</td>
                                            <td>
                                                <asp:Label ID="lblModelo" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-weight: bold;">Tag:</td>
                                            <td>
                                                <asp:Label ID="lblTag" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td colspan="2" rowspan="2" style="vertical-align: top; text-align: left;">
                                                <telerik:RadBarcode ID="brcGuid" runat="server" Height="40px" Text="12345" VerticalTextPositionPercentage="0" Width="150px"></telerik:RadBarcode>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td></td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblEmpresaVinculada" Text="Empresa Vinculada:" CssClass="sysLabel" />
                            </td>
                            <td>
                                <telerik:RadTextBox runat="server" ID="txtEmpresaVinculada" Width="300px" Enabled="false"></telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblEquipamentoTipo" Text="Tipo de Equipamento:" CssClass="sysLabel" />
                            </td>
                            <td>
                                <telerik:RadTextBox runat="server" ID="txtEquipamentoTipo" Width="300px" Enabled="false"></telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblManutencaoTipo" Text="Tipo de Manutenção:" CssClass="sysLabel" />
                            </td>
                            <td>
                                <telerik:RadComboBox runat="server" ID="ddlManutencaoTipo" Width="300px" OnSelectedIndexChanged="ddlManutencaoTipo_SelectedIndexChanged" AutoPostBack="true" CausesValidation="false">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="rfvManutencaoTipo" runat="server" ControlToValidate="ddlManutencaoTipo" CssClass="Validator" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblStatus" Text="Status:" CssClass="sysLabel" />
                            </td>
                            <td>
                                <telerik:RadComboBox ID="ddlStatus" runat="server" Width="300px" EmptyMessage="* Selecione *">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="rvfStatus" runat="server" ControlToValidate="ddlStatus" CssClass="Validator" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblDataRealizacao" Text="Data de realização:" CssClass="sysLabel" />
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="txtDataRealizacao" runat="server" MinDate="1900-01-01" Culture="PT-BR" Width="150px">
                                    <Calendar ID="cldDataRealizacao" RangeMinDate="1900-01-01" runat="server">
                                    </Calendar>
                                </telerik:RadDatePicker>
                                <asp:RequiredFieldValidator ID="rfvDataRealizacao" runat="server" ControlToValidate="txtDataRealizacao" CssClass="Validator" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblExecutor" Text="Executor:" CssClass="sysLabel" />
                            </td>
                            <td>
                                <telerik:RadComboBox ID="ddlExecutor" runat="server" AutoPostBack="True" EnableLoadOnDemand="True" EnableVirtualScrolling="true" ItemsPerRequest="20" MarkFirstMatch="True"
                                    OnItemsRequested="ddlExecutor_ItemsRequested" ShowMoreResultsBox="true" ShowToggleImage="false" Width="300px" EmptyMessage="* Selecione *" CausesValidation="false">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="rfvExecutor" runat="server" ControlToValidate="ddlExecutor" CssClass="Validator" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblAprovador" Text="Aprovador:" CssClass="sysLabel" />
                            </td>
                            <td>
                                <telerik:RadComboBox ID="ddlAprovador" runat="server" AutoPostBack="True" EnableLoadOnDemand="True" EnableVirtualScrolling="true" ItemsPerRequest="20"
                                    MarkFirstMatch="True" OnItemsRequested="ddlAprovador_ItemsRequested" ShowMoreResultsBox="true" ShowToggleImage="false" Width="300px" EmptyMessage="* Selecione *" CausesValidation="false">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="rfvAprovador" runat="server" ControlToValidate="ddlAprovador" CssClass="Validator" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblRelatorioTecnico" Text="Relatório Técnico:" CssClass="sysLabel" />
                            </td>
                            <td colspan="3">
                                <telerik:RadTextBox runat="server" ID="txtRelatorioTecnico" TextMode="MultiLine" Height="100px" Width="900px" MaxLength="500"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="rfvRelatorioTecnico" runat="server" ControlToValidate="txtRelatorioTecnico" CssClass="Validator" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblTituloManCorretiva" Text="Man. corretiva:" CssClass="sysLabel" Font-Bold="true" Visible="false" />
                            </td>
                            <td colspan="3"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblDefeito" Text="Defeito Constatado:" CssClass="sysLabel" Visible="false" />
                            </td>
                            <td colspan="3">
                                <telerik:RadTextBox runat="server" ID="txtDefeito" TextMode="MultiLine" Height="100px" Width="900px" Visible="false" MaxLength="500"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="rfvDefeito" runat="server" ControlToValidate="txtDefeito" CssClass="Validator" Display="Dynamic" ErrorMessage="*" Visible="false"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblCarregarArquivo" Text="Carregar Arquivo:" CssClass="sysLabel" Visible="false" /></td>
                            <td>
                                <asp:Label ID="lblMsgUpl" Text="* Somente 1 arquivo: 2 mb (limite) || ** Somente arquivos jpg, jpeg e png são permitidos." runat="server" Style="font-size: 11px; color: red;" Visible="false"></asp:Label><br />
                                <br />

                                <telerik:RadAsyncUpload runat="server" ID="uplImagens"
                                    CssClass="VisibilityHidden" OnFileUploaded="uplImagens_FileUploaded" PostbackTriggers="btnEnviar" Skin="Metro" MaxFileSize="2097152" UploadedFilesRendering="BelowFileInput">
                                </telerik:RadAsyncUpload>
                                <br />
                                <br />
                                <telerik:RadButton ID="btnEnviar" runat="server" Text="Enviar arquivo" CausesValidation="false" Visible="false" Skin="Metro">
                                    <Icon PrimaryIconCssClass="rbUpload" PrimaryIconLeft="4" PrimaryIconTop="3"></Icon>
                                </telerik:RadButton>
                                <asp:ImageButton ID="btnCalibracaoUpload" runat="server" Visible="false" Width="100px" Height="100px" OnClick="btnCalibracaoUpload_Click" ToolTip="Clique para fazer download do arquivo" />
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;">
                                <asp:Label runat="server" ID="lblPecas" Text="Peças:" CssClass="sysLabel" Visible="true" /></td>
                            <td colspan="3">
                                <telerik:RadGrid ID="grdItemManutencao" runat="server" AllowSorting="True" AutoGenerateColumns="False" Width="100%"
                                    OnNeedDataSource="grdItemManutencao_NeedDataSource"
                                    OnInsertCommand="grdItemManutencao_InsertCommand"
                                    OnUpdateCommand="grdItemManutencao_UpdateCommand"
                                    OnDeleteCommand="grdItemManutencao_DeleteCommand"
                                    ShowFooter="True" EnableLinqExpressions="False" CellSpacing="0" GridLines="None">
                                    <ExportSettings>
                                        <Pdf PageWidth="">
                                        </Pdf>
                                    </ExportSettings>
                                    <MasterTableView CommandItemDisplay="Top" DataKeyNames="ItemManutencaoID" EditMode="InPlace" ShowGroupFooter="true">
                                        <Columns>
                                            <telerik:GridEditCommandColumn ButtonType="ImageButton" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="4%" HeaderText="Alterar" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%" UniqueName="Edit">
                                                <HeaderStyle HorizontalAlign="Center" Width="4%" />
                                                <ItemStyle HorizontalAlign="Center" Width="4%" />
                                            </telerik:GridEditCommandColumn>
                                            <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmDialogType="RadWindow" ConfirmText="Confirmar a exclusão do registro?" ConfirmTitle="Delete" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="4%" HeaderText="Excluir" ImageUrl="Images/btn_delete.gif" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%" Text="Excluir" UniqueName="DeleteColumn">
                                                <HeaderStyle HorizontalAlign="Center" Width="4%" />
                                                <ItemStyle HorizontalAlign="Center" Width="4%" />
                                            </telerik:GridButtonColumn>
                                            <telerik:GridBoundColumn ColumnEditorID="txtDescricao" ColumnValidationSettings-EnableRequiredFieldValidation="true" ColumnValidationSettings-RequiredFieldValidator-ErrorMessage="*" DataField="Descricao" HeaderStyle-HorizontalAlign="Center" HeaderText="Descrição" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" UniqueName="colDescricao">
                                                <ColumnValidationSettings EnableRequiredFieldValidation="True">
                                                    <RequiredFieldValidator ErrorMessage="*"></RequiredFieldValidator>
                                                </ColumnValidationSettings>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Lote" HeaderStyle-HorizontalAlign="Center" HeaderText="Lote" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" UniqueName="colLote">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NumeroSerie" HeaderStyle-HorizontalAlign="Center" HeaderText="Nro. de Série" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" UniqueName="colNumeroSerie">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridNumericColumn ColumnValidationSettings-EnableRequiredFieldValidation="true" ColumnValidationSettings-RequiredFieldValidator-ErrorMessage="*" DataField="Quantidade" DataFormatString="{0:0}" DecimalDigits="0" HeaderStyle-HorizontalAlign="Center" HeaderText="Quantidade" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" UniqueName="colQuantidade">
                                                <ColumnValidationSettings EnableRequiredFieldValidation="True">
                                                    <RequiredFieldValidator ErrorMessage="*"></RequiredFieldValidator>
                                                </ColumnValidationSettings>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                            </telerik:GridNumericColumn>
                                            <telerik:GridNumericColumn DataField="Custo" DataFormatString="R$ {0:0.00}" HeaderStyle-HorizontalAlign="Center" HeaderText="Custo Unitário" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Top" UniqueName="colCusto">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                            </telerik:GridNumericColumn>
                                            <telerik:GridCalculatedColumn Aggregate="Sum" DataFields="Quantidade, Custo" DataFormatString="R$ {0:0.00}" DataType="System.Double" Expression="{0}*{1}" FooterText="Total : " HeaderStyle-HorizontalAlign="Center" HeaderText="Total" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Top" UniqueName="colCustoTotal">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                            </telerik:GridCalculatedColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                    </table>
                </div>
            </ul>
        </section>
    </telerik:RadAjaxPanel>
    <telerik:RadAjaxLoadingPanel ID="ajaxLoadingPanelGeral" runat="server"></telerik:RadAjaxLoadingPanel>
</asp:Content>
