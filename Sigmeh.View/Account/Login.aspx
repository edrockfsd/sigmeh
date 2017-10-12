<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Sigmeh.View.Account.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Área de acesso</title>
    <link href="~/Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" defaultfocus="UserName">
    <div style="text-align:center;">
            <hgroup class="title">
                <p class="site-title"><a href="~/">SIGMEH</a></p>
            </hgroup>
             <h2>Use suas credenciais para acessar o sistema</h2>
                <asp:Login ID="pnlLogin" runat="server" ViewStateMode="Disabled" RenderOuterTable="false">
                    <LayoutTemplate>
                        <p class="validation-summary-errors">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                        <fieldset>
                            <legend>Log in Form</legend>
                            <ol>
                                <li>
                                    <asp:Label ID="Label1" runat="server" AssociatedControlID="UserName">Login</asp:Label>
                                    <asp:TextBox runat="server" ID="UserName" /><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="* Campo obrigatório" />
                                </li>
                                <li>
                                    <asp:Label ID="Label2" runat="server" AssociatedControlID="Password">Senha</asp:Label>
                                    <asp:TextBox runat="server" ID="Password" TextMode="Password" /><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="* Campo obrigatório" />
                                </li>
                                <li>
                                    <asp:CheckBox runat="server" ID="RememberMe" />
                                    <asp:Label ID="Label3" runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">Lembrar-me?</asp:Label>
                                </li>
                            </ol>
                            <asp:Button ID="btnLogin" runat="server" CommandName="Login" Text="Log in" OnClick="btnLogin_Click"/>
                        </fieldset>
                    </LayoutTemplate>
                </asp:Login>
        </div>
    </form>
</body>
</html>
