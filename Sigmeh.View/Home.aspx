<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Sigmeh.View.Home" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>
    <telerik:RadTileList runat="server" ID="RadTileList1" Width="1300px" Height="500px" TileRows="3"
        SelectionMode="Multiple" EnableDragAndDrop="true">
        <Groups>
            <telerik:TileGroup>
                <telerik:RadImageAndTextTile Shape="Wide" NavigateUrl="RMECad.aspx"
                    ImageUrl="Images/page.new.png"                    
                    BackColor="#00b37d" Title-Text="Cadastro de registro de manutenção de equipamento (R.M.E)">
                </telerik:RadImageAndTextTile>                
                <telerik:RadImageAndTextTile Shape="Wide" NavigateUrl="EquipamentoCad.aspx"
                    ImageUrl="Images/monitor.add.png"                    
                    BackColor="#25a0da" Title-Text="Cadastro de equipamentos">
                </telerik:RadImageAndTextTile>                
                <telerik:RadImageAndTextTile ImageUrl="Images/section.expand.all.png" Title-Text="Cadastro Tipo de Equipamento"
                    Shape="Wide" 
                    BackColor="#07a9bc">                    
                </telerik:RadImageAndTextTile>
                <telerik:RadImageAndTextTile Shape="Wide" NavigateUrl="EntidadeCad.aspx"
                    ImageUrl="Images/medical.pulse.png"                    
                    BackColor="#b53e60" Title-Text="Cadastro de Hospitais">
                </telerik:RadImageAndTextTile>
                <telerik:RadImageAndTextTile Shape="Wide" NavigateUrl="EntidadeCad.aspx"
                    ImageUrl="Images/people.png"                    
                    BackColor="#007ac0" Title-Text="Cadastro de Funcionários">
                </telerik:RadImageAndTextTile>
                <telerik:RadImageAndTextTile Shape="Wide" NavigateUrl="EntidadeCad.aspx"
                    ImageUrl="Images/people.profile.png"                    
                    BackColor="#f8b617" Title-Text="Cadastro de Usuários">
                </telerik:RadImageAndTextTile>
            </telerik:TileGroup>

             <telerik:TileGroup>
                    <telerik:RadIconTile Name="Impressão" NavigateUrl="Dashboard.aspx"
                         Shape="Wide" ImageUrl="Images/printer.blank.png" BackColor="#c83c21">
                         <Title Text="Impressão de R.M.E indidual"></Title>
                    </telerik:RadIconTile>
                    <telerik:RadIconTile Name="Relaório" NavigateUrl="Dashboard.aspx"
                         Shape="Square" ImageUrl="Images/paper.png" BackColor="#03953f">
                         <Title Text="Relatório de R.M.E"></Title>                         
                    </telerik:RadIconTile>
                    <telerik:RadIconTile Name="Parâmetros" NavigateUrl="Dashboard.aspx"
                         Shape="Square" ImageUrl="Images/box.layered.png">
                         <Title Text="Parâmetros do sistema"></Title>
                    </telerik:RadIconTile>
                    <telerik:RadIconTile Name="Ajuda" NavigateUrl="Dashboard.aspx"
                         Shape="Wide" ImageUrl="Images/question.png" BackColor="#a2316e">
                         <Title Text="Ajuda"></Title>
                    </telerik:RadIconTile>                    
               </telerik:TileGroup>
        </Groups>
    </telerik:RadTileList>
</asp:Content>
