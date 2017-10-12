<%@ Page Title="CADASTRO DE ENTIDADE" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EntidadeCad.aspx.cs" Inherits="Sigmeh.View.EntidadeCad" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link href="Content/themes/metro/jquery-ui-1.10.3.custom.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.9.1.js"></script>
    <script src="Scripts/jquery-ui-1.10.3.custom.min.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            $(function () {
                $("#accordion").accordion({
                    collapsible: true
                });
            });

            $("#notaccordion").addClass("ui-accordion ui-accordion-icons ui-widget ui-helper-reset")
        .find("h3")
          .addClass("ui-accordion-header ui-helper-reset ui-state-default ui-corner-top ui-corner-bottom")
          .hover(function () { $(this).toggleClass("ui-state-hover"); })
          .prepend('<span class="ui-icon ui-icon-triangle-1-e"></span>')
          .click(function () {
              $(this)
                .toggleClass("ui-accordion-header-active ui-state-active ui-state-default ui-corner-bottom")
                .find("> .ui-icon").toggleClass("ui-icon-triangle-1-e ui-icon-triangle-1-s").end()
                .next().toggleClass("ui-accordion-content-active").slideToggle();
              return false;
          })
          .next()
            .addClass("ui-accordion-content  ui-helper-reset ui-widget-content ui-corner-bottom")
            .hide();
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadAjaxPanel ID="ajaxpanelGeral" runat="server" LoadingPanelID="ajaxLoadingPanelGeral">
        <asp:HiddenField runat="server" ID="hdnIsEntidadeValida" Value="false"/>        
        <!-- Controle de notificação -->
        <telerik:RadNotification ID="ntfGeral" runat="server">
        </telerik:RadNotification>
        <!-- Controle de notificação -->
        <div>
            <telerik:RadMenu ID="menu" runat="server" OnItemClick="menu_ItemClick" ValidationGroup="grpBase">
                <Items>
                    <telerik:RadMenuItem runat="server" Text="Arquivo">
                        <Items>
                            <telerik:RadMenuItem runat="server" Text="Novo" ImageUrl="~/Images/btn_file_new.png" Value="novo">
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem runat="server" Text="Listar" ImageUrl="~/Images/btn_folder_open.png" Value="listar">
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem runat="server" Text="Salvar" ImageUrl="~/Images/btn_save.png" Value="salvar">
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem runat="server" Text="Salvar Como" ImageUrl="~/Images/btn_save_as.png" Value="salvar_como" Visible="false">
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem runat="server" Text="Imprimir" ImageUrl="~/Images/btn_printer.png" Value="imprimir" Visible="false">
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
                        <h1>
                            <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                                <%: Title %>
                            </telerik:RadCodeBlock>

                        </h1>
                    </hgroup>

                    <div>
                        <h3>DADOS GERAIS</h3>
                        <div>
                            <div class="dataBoxMiddle">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblTipoPessoa" Text="Tipo Pessoa:" CssClass="sysLabel" />
                                        </td>
                                        <td>
                                            <telerik:RadButton ID="rbtPessoaFisica" runat="server" ToggleType="Radio" ButtonType="ToggleButton"
                                                Checked="true" GroupName="Radios" AutoPostBack="true" OnClick="rbtPessoaFisica_Click" Value="PF">
                                                <ToggleStates>
                                                    <telerik:RadButtonToggleState Text="Física"></telerik:RadButtonToggleState>
                                                    <telerik:RadButtonToggleState Text="Física"></telerik:RadButtonToggleState>
                                                </ToggleStates>
                                            </telerik:RadButton>
                                            <telerik:RadButton ID="rbtPessoaJuridica" runat="server" ToggleType="Radio" ButtonType="ToggleButton"
                                                GroupName="Radios" AutoPostBack="true" OnClick="rbtPessoaJuridica_Click" Value="PJ">
                                                <ToggleStates>
                                                    <telerik:RadButtonToggleState Text="Jurídica"></telerik:RadButtonToggleState>
                                                    <telerik:RadButtonToggleState Text="Jurídica"></telerik:RadButtonToggleState>
                                                </ToggleStates>
                                            </telerik:RadButton>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblTipoEntidade" Text="Tipo Entidade:" CssClass="sysLabel" />
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="ddlTipoEntidade" runat="server" Width="300px"
                                                ClientIDMode="Static" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblNome" Text="Nome:" CssClass="sysLabel" />
                                            <asp:Label runat="server" ID="lblRazaoSocial" Text="Razão Social:" CssClass="sysLabel" Visible="false" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox runat="server" ID="txtNome" Width="300px"></telerik:RadTextBox>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvNome"
                                                ValidationGroup="grpBase" CssClass="Validator" runat="server" ErrorMessage="*"
                                                ControlToValidate="txtNome"></asp:RequiredFieldValidator>
                                            <telerik:RadTextBox runat="server" ID="txtRazaoSocial" Width="300px" Visible="false"></telerik:RadTextBox>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvRazaoSocial"
                                                ValidationGroup="grpBase" CssClass="Validator" runat="server" ErrorMessage="*"
                                                ControlToValidate="txtRazaoSocial"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblApelido" Text="Apelido:" CssClass="sysLabel" />
                                            <asp:Label runat="server" ID="lblFantasia" Text="Fantasia:" CssClass="sysLabel" Visible="false" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox runat="server" ID="txtApelido" Width="300px"></telerik:RadTextBox>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvApelido"
                                                ValidationGroup="grpBase" CssClass="Validator" runat="server" ErrorMessage="*"
                                                ControlToValidate="txtApelido"></asp:RequiredFieldValidator>
                                            <telerik:RadTextBox runat="server" ID="txtFantasia" Width="300px" Visible="false"></telerik:RadTextBox>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvFantasia"
                                                ValidationGroup="grpBase" CssClass="Validator" runat="server" ErrorMessage="*"
                                                ControlToValidate="txtFantasia"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCPF" runat="server" CssClass="sysLabel" Text="C.P.F:" />
                                            <asp:Label ID="lblCNPJ" runat="server" CssClass="sysLabel" Text="C.N.P.J:" Visible="false" />
                                        </td>
                                        <td>
                                            <telerik:RadMaskedTextBox ID="txtCPF" runat="server" ClientIDMode="Static" Mask="###.###.###-##" MaxLength="20" Width="200px" />
                                            <telerik:RadMaskedTextBox ID="txtCNPJ" runat="server" ClientIDMode="Static" Mask="##.###.###/####-##" MaxLength="20" Visible="false" Width="200px">
                                            </telerik:RadMaskedTextBox>
                                            <asp:RequiredFieldValidator ID="rfvCPF" runat="server" ControlToValidate="txtCPF" CssClass="Validator" Display="Dynamic" ErrorMessage="*" ValidationGroup="grpBase"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ID="rfvCNPJ" runat="server" ControlToValidate="txtCNPJ" CssClass="Validator" Display="Dynamic" ErrorMessage="*" ValidationGroup="grpBase"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:RegularExpressionValidator ID="revCPF" runat="server" ControlToValidate="txtCPF" CssClass="Validator" Display="Dynamic" ErrorMessage="Formato é ###.###.###-##" ValidationExpression="(^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$)" ValidationGroup="grpBase">
                                            </asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator ID="revCNPJ" runat="server" ControlToValidate="txtCNPJ" CssClass="Validator" Display="Dynamic" ErrorMessage="Formato é ##.###.###/####-##" ValidationExpression="(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)" ValidationGroup="grpBase">
                                            </asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblObs" runat="server" CssClass="sysLabel" Text="Obs:" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtObservacao" MaxLength="400" runat="server" Width="300px" Height="70px" TextMode="MultiLine"
                                                ClientIDMode="Static" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblDataNascimento" runat="server" CssClass="sysLabel" Text="Data de Nascimento:" />
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="txtDataNascimento" runat="server" Culture="PT-BR" MinDate="1900-01-01" Width="170px">
                                                <Calendar ID="cldDataNascimento" runat="server" RangeMinDate="1900-01-01">
                                                </Calendar>
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblInativa" runat="server" CssClass="sysLabel" Text="Inativa:" />
                                            <telerik:RadButton ID="chkIsInativo" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="false">                                                
                                            </telerik:RadButton>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <h3>TELEFONES</h3>
                        <telerik:RadGrid ID="grdTelefone" runat="server" AllowSorting="true" AutoGenerateColumns="false" Width="80%"
                            OnNeedDataSource="grdTelefone_NeedDataSource"
                            OnBatchEditCommand="grdTelefone_BatchEditCommand">
                            <MasterTableView DataKeyNames="TelefoneID" EditMode="Batch" BatchEditingSettings-OpenEditingEvent="DblClick" CommandItemDisplay="Top">
                                <Columns>
                                    <telerik:GridMaskedColumn DataField="DDD" UniqueName="colDDD" HeaderText="DDD" MaxLength="2" Mask="##" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ColumnValidationSettings EnableRequiredFieldValidation="true">
                                            <RequiredFieldValidator ForeColor="Red" Text="*" Display="Dynamic">
                                            </RequiredFieldValidator>
                                        </ColumnValidationSettings>
                                    </telerik:GridMaskedColumn>
                                    <telerik:GridMaskedColumn DataField="Numero" UniqueName="colNumero" HeaderText="Número" MaxLength="9" Mask="########" HeaderStyle-Width="30%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ColumnValidationSettings EnableRequiredFieldValidation="true">
                                            <RequiredFieldValidator ForeColor="Red" Text="*" Display="Dynamic">
                                            </RequiredFieldValidator>
                                        </ColumnValidationSettings>
                                    </telerik:GridMaskedColumn>
                                    <telerik:GridTemplateColumn DataField="TelefoneTipoID" UniqueName="colTipo" HeaderText="Tipo" HeaderStyle-Width="30%">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTipo" Text='<%# Eval("TipoDescricao") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadDropDownList runat="server" ID="ddlTipoTelefone" DataValueField="TelefoneTipoID" DataTextField="Descricao" DataSourceID="dsTelefoneTipo">
                                            </telerik:RadDropDownList>
                                            </ColumnValidationSettings>
                                        </columnvalidationsettings>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridCheckBoxColumn DataField="IsPrincipal" HeaderText="Telefone Principal" SortExpression="IsPrincipal"
                                        UniqueName="colIsPrincipal" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center">
                                    </telerik:GridCheckBoxColumn>
                                    <telerik:GridButtonColumn ConfirmText="Confirmar a exclusão do registro?" ConfirmDialogType="RadWindow" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                        ConfirmTitle="Delete" HeaderText="Excluir" ButtonType="ImageButton" ImageUrl="Images/btn_delete.gif" ItemStyle-Width="16px" ItemStyle-Height="16px"
                                        CommandName="Delete" Text="Excluir" UniqueName="DeleteColumn">
                                    </telerik:GridButtonColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                        <h3>CANAIS DE COMUNICAÇÃO</h3>
                        <telerik:RadGrid ID="grdCanaisComunicacao" runat="server" AllowSorting="true" AutoGenerateColumns="false" Width="80%"
                            OnNeedDataSource="grdCanaisComunicacao_NeedDataSource"
                            OnBatchEditCommand="grdCanaisComunicacao_BatchEditCommand">
                            <MasterTableView DataKeyNames="CanalComunicacaoID" EditMode="Batch" BatchEditingSettings-OpenEditingEvent="DblClick" CommandItemDisplay="Top">
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Descricao" UniqueName="colDescricao" HeaderText="Descrição" HeaderStyle-Width="30%">
                                        <ColumnValidationSettings EnableRequiredFieldValidation="true">
                                            <RequiredFieldValidator ForeColor="Red" Text="*" Display="Dynamic">
                                            </RequiredFieldValidator>
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn DataField="CanalComunicacaoTipoID" UniqueName="colTipo" HeaderText="Tipo" HeaderStyle-Width="30%">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTipo" Text='<%# Eval("TipoDescricao") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadDropDownList runat="server" ID="ddlTipoCanal" DataValueField="CanalComunicacaoTipoID" DataTextField="Descricao" DataSourceID="dsCanalComunicacaoTipo">
                                            </telerik:RadDropDownList>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridCheckBoxColumn DataField="IsPrincipal" HeaderText="Canal Principal" SortExpression="IsPrincipal"
                                        UniqueName="colIsPrincipal" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center">
                                    </telerik:GridCheckBoxColumn>
                                    <telerik:GridButtonColumn ConfirmText="Confirmar a exclusão do registro?" ConfirmDialogType="RadWindow" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                        ConfirmTitle="Delete" HeaderText="Excluir" ButtonType="ImageButton" ImageUrl="Images/btn_delete.gif" ItemStyle-Width="16px" ItemStyle-Height="16px"
                                        CommandName="Delete" Text="Excluir" UniqueName="DeleteColumn">
                                    </telerik:GridButtonColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                        <h3>ENDEREÇO</h3>
                        <telerik:RadGrid ID="grdEndereco" runat="server" AllowSorting="true" AutoGenerateColumns="false" Width="100%"
                            OnNeedDataSource="grdEndereco_NeedDataSource"
                            OnInsertCommand="grdEndereco_InsertCommand"
                            OnUpdateCommand="grdEndereco_UpdateCommand"
                            OnDeleteCommand="grdEndereco_DeleteCommand"
                            OnItemDataBound="grdEndereco_ItemDataBound">
                            <MasterTableView DataKeyNames="EnderecoID" EditMode="InPlace" CommandItemDisplay="Top">
                                <Columns>
                                    <telerik:GridEditCommandColumn UniqueName="Edit" ButtonType="ImageButton" HeaderText="Alterar" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="4%" ItemStyle-Width="4%">
                                    </telerik:GridEditCommandColumn>
                                    <telerik:GridButtonColumn ConfirmText="Confirmar a exclusão do registro?" ConfirmDialogType="RadWindow" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="4%" ItemStyle-Width="4%"
                                        ConfirmTitle="Delete" HeaderText="Excluir" ButtonType="ImageButton" ImageUrl="Images/btn_delete.gif"
                                        CommandName="Delete" Text="Excluir" UniqueName="DeleteColumn">
                                    </telerik:GridButtonColumn>
                                    <telerik:GridTemplateColumn DataField="CEP" UniqueName="colCEP" HeaderText="C.E.P" HeaderStyle-Width="10%" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCEP" Text='<%# Eval("CEP") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <telerik:RadMaskedTextBox runat="server" ID="txtCEP" Mask="#####-###" Text='<%# Eval("CEP") %>' Width="80px"></telerik:RadMaskedTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton runat="server" ID="btnPesquisarCEP" ImageUrl="~/Images/btn_search.png" Width="20px" OnClick="btnPesquisarCEP_Click" ValidationGroup="pesquisaCEP" />
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvCEP"
                                                            CssClass="Validator" runat="server" ErrorMessage="*"
                                                            ControlToValidate="txtCEP"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Logradouro" UniqueName="colLogradouro" HeaderText="Logradouro" HeaderStyle-Width="19%" ItemStyle-Width="19%">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblLogradouro" Text='<%# Eval("Logradouro") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <telerik:RadTextBox runat="server" ID="txtLogradouro" Text='<%# Eval("Logradouro") %>'></telerik:RadTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvLogradouro"
                                                            CssClass="Validator" runat="server" ErrorMessage="*"
                                                            ControlToValidate="txtLogradouro"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Numero" UniqueName="colNumero" HeaderText="N°" HeaderStyle-Width="4%" ItemStyle-Width="4%">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblNumero" Text='<%# Eval("Numero") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <telerik:RadMaskedTextBox runat="server" ID="txtNumero" Text='<%# Eval("Numero") %>' Mask="#########" Width="50px"></telerik:RadMaskedTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvNumero"
                                                            CssClass="Validator" runat="server" ErrorMessage="*"
                                                            ControlToValidate="txtNumero"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Complemento" UniqueName="colComplemento" HeaderText="Complemento" HeaderStyle-Width="9%" ItemStyle-Width="9%">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblComplemento" Text='<%# Eval("Complemento") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadTextBox runat="server" ID="txtComplemento" Text='<%# Eval("Complemento") %>'></telerik:RadTextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Bairro" UniqueName="colBairro" HeaderText="Bairro" HeaderStyle-Width="16%">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblBairro" Text='<%# Eval("Bairro") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <telerik:RadTextBox runat="server" ID="txtBairro" Text='<%# Eval("Bairro") %>'></telerik:RadTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvBairro"
                                                            CssClass="Validator" runat="server" ErrorMessage="*"
                                                            ControlToValidate="txtBairro"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Cidade" UniqueName="colCidade" HeaderText="Cidade" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="16%">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCidadeNome" Text='<%# Eval("CidadeNome") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>                                            
                                            <telerik:RadTextBox runat="server" ID="txtCidadeNome" Text='<%# Eval("CidadeNome") %>' ReadOnly="true"></telerik:RadTextBox>
                                            <asp:HiddenField runat="server" ID="hdnCidadeID" Value='<%# Eval("CidadeID") %>' />
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="UF" UniqueName="colEstado" HeaderText="UF" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="4%">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblUF" Text='<%# Eval("UF") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadTextBox runat="server" ID="txtUF" Text='<%# Eval("UF") %>' Width="50px" ReadOnly="true"></telerik:RadTextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="colEnderecoTipo" HeaderText="Tipo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="9%">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblEnderecoTipo" Text='<%# Eval("TipoDescricao") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadComboBox runat="server" ID="ddlEnderecoTipo"></telerik:RadComboBox>
                                            <asp:HiddenField runat="server" ID="hdnEnderecoTipoID" Value='<%# Eval("EnderecoTipoID") %>' />
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridCheckBoxColumn DataField="IsPrincipal" UniqueName="colIsPrincipal" HeaderText="Principal" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="4%" ItemStyle-Width="4%"></telerik:GridCheckBoxColumn>                                    
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>

                </div>
            </ul>
        </section>

        <asp:SqlDataSource ID="dsCanalComunicacaoTipo" runat="server" ConnectionString="<%$ ConnectionStrings:SigmehConnection%>"
            SelectCommand="Select CanalComunicacaoTipoID, Descricao from CanalComunicacaoTipo"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dsTelefoneTipo" runat="server" ConnectionString="<%$ ConnectionStrings:SigmehConnection%>"
            SelectCommand="Select TelefoneTipoID, Descricao from TelefoneTipo"></asp:SqlDataSource>
    </telerik:RadAjaxPanel>
    <telerik:RadAjaxLoadingPanel ID="ajaxLoadingPanelGeral" runat="server"></telerik:RadAjaxLoadingPanel>
</asp:Content>
