<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Erro.aspx.cs" Inherits="Sigmeh.View.Erro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <section class="featured">
        <ul>
            <h1 style="color: red;">Ocorreu um erro.</h1>
            <h3>Um erro inesperado ocorreu no sistema.</h3>
            <br />
            <h3>O administrador já foi notificado.</h3>
            <a href="Home.aspx"><h3>Retornar a página inicial</h3></a>
        </ul>
    </section>
</asp:Content>
