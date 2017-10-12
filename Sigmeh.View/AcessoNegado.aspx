<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AcessoNegado.aspx.cs" Inherits="Sigmeh.View.AcessoNegado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <section class="featured">
        <ul>
            <h1 style="color: red;">Acesso Negado</h1>
            <h3>Você não tem permissão para acessar a área solicitada.</h3>
            <br />
            <h3>Se isso ocorreu de forma inesperada, por favor, entre em contato com o administrador do sistema.</h3>
        </ul>
    </section>
</asp:Content>
