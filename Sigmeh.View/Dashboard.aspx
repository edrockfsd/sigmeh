<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Sigmeh.View.Dashboard" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>
    <span style="font-size:15pt; font-weight:bold;">Para sair</span>
    <telerik:RadTileList runat="server" ID="tllSaida" TileRows="1" AutoPostBack="true"
        SelectionMode="None" EnableDragAndDrop="false" OnTileClick="tllSaida_TileClick">
        <Groups>
            <telerik:TileGroup>
                <telerik:RadContentTemplateTile Shape="Wide"
                    Badge-ImageUrl="Images/timer.alert.png" Name="atrasados"
                    BackColor="Red" Title-Text="Atrasados">
                    <ContentTemplate>
                        <div style="padding: 5px 0px 0px 5px;">
                            <table style="text-align: left; font-size: 12pt; font-weight: bold; width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Image ID="imgPreventiva" runat="server" Width="20px" ImageUrl="~/Images/magnify.back.png" ToolTip="Manutenção Preventica" />&nbsp;<asp:Label runat="server" ID="lblAtrasadosPreventiva" Text="0"></asp:Label>
                                    </td>
                                    <td rowspan="3" style="font-size: 50pt; text-align: right;"><asp:Label runat="server" ID="lblAtrasadosTotal" Text="0"></asp:Label></td>
                                </tr>                                
                                <tr>
                                    <td>
                                        <asp:Image ID="imgCalibracao" runat="server" Width="20px" ImageUrl="~/Images/crosshair.png" ToolTip="Calibração" />&nbsp;<asp:Label runat="server" ID="lblAtrasadosCalibracao" Text="0"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </telerik:RadContentTemplateTile>
                <telerik:RadContentTemplateTile Shape="Wide"
                    Badge-ImageUrl="Images/timer.1.png" Name="sete_dias"
                    BackColor="Orange" Title-Text="7 dias">
                    <ContentTemplate>
                        <div style="padding: 5px 0px 0px 5px;">
                            <table style="text-align: left; font-size: 12pt; font-weight: bold; width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Image ID="Image1" runat="server" Width="20px" ImageUrl="~/Images/magnify.back.png" ToolTip="Manutenção Preventiva" />&nbsp;<asp:Label runat="server" ID="lbl7DiasPreventiva" Text="0"></asp:Label>
                                    </td>
                                    <td rowspan="3" style="font-size: 50pt; text-align: right;"><asp:Label runat="server" ID="lbl7DiasTotal" Text="0"></asp:Label></td>
                                </tr>                                
                                <tr>
                                    <td>
                                        <asp:Image ID="Image3" runat="server" Width="20px" ImageUrl="~/Images/crosshair.png" ToolTip="Calibração" />&nbsp;<asp:Label runat="server" ID="lbl7DiasCalibracao" Text="0"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </telerik:RadContentTemplateTile>
                <telerik:RadContentTemplateTile Shape="Wide"
                    Badge-ImageUrl="Images/timer.2.png" Name="quinze_dias"
                    BackColor="Green" Title-Text="15 dias">
                    <ContentTemplate>
                        <div style="padding: 5px 0px 0px 5px;">
                            <table style="text-align: left; font-size: 12pt; font-weight: bold; width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Image ID="Image4" runat="server" Width="20px" ImageUrl="~/Images/magnify.back.png" ToolTip="Manutenção Preventiva" />&nbsp;<asp:Label runat="server" ID="lbl15DiasPreventiva" Text="0"></asp:Label>
                                    </td>
                                    <td rowspan="3" style="font-size: 50pt; text-align: right;"><asp:Label runat="server" ID="lbl15DiasTotal" Text="0"></asp:Label></td>
                                </tr>                                
                                <tr>
                                    <td>
                                        <asp:Image ID="Image6" runat="server" Width="20px" ImageUrl="~/Images/crosshair.png" ToolTip="Calibração" />&nbsp;<asp:Label runat="server" ID="lbl15DiasCalibracao" Text="0"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </telerik:RadContentTemplateTile>
                <telerik:RadContentTemplateTile Shape="Wide"
                    Badge-ImageUrl="Images/timer.3.png" Name="trinta_dias"
                    BackColor="Blue" Title-Text="30 dias">
                    <ContentTemplate>
                        <div style="padding: 5px 0px 0px 5px;">
                            <table style="text-align: left; font-size: 12pt; font-weight: bold; width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Image ID="Image7" runat="server" Width="20px" ImageUrl="~/Images/magnify.back.png" ToolTip="Manutenção Preventiva" />&nbsp;<asp:Label runat="server" ID="lbl30DiasPreventiva" Text="0"></asp:Label>
                                    </td>
                                    <td rowspan="3" style="font-size: 50pt; text-align: right;"><asp:Label runat="server" ID="lbl30DiasTotal" Text="0"></asp:Label></td>
                                </tr>                                
                                <tr>
                                    <td>
                                        <asp:Image ID="Image9" runat="server" Width="20px" ImageUrl="~/Images/crosshair.png" ToolTip="Calibração" />&nbsp;<asp:Label runat="server" ID="lbl30DiasCalibracao" Text="0"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </telerik:RadContentTemplateTile>
            </telerik:TileGroup>
        </Groups>
    </telerik:RadTileList>
    <span style="font-size:15pt; font-weight:bold;">Para entrar</span>
    <telerik:RadTileList runat="server" ID="tllEntrada" TileRows="1"
        SelectionMode="None" EnableDragAndDrop="false">
        <Groups>
            <telerik:TileGroup>
                <telerik:RadContentTemplateTile Shape="Wide" NavigateUrl="EquipamentoLis.aspx"
                    Badge-ImageUrl="Images/timer.stop.png"
                    BackColor="Gray" Title-Text="Aguardando Manutenção">
                    <ContentTemplate>
                        <div style="padding: 5px 0px 0px 5px; width: 100%; font-size: 50pt; text-align: center; font-weight: bold;">
                            <asp:Label ID="lblAguardandoManutencao" runat="server" Text=""></asp:Label>
                        </div>
                    </ContentTemplate>
                </telerik:RadContentTemplateTile>
                <telerik:RadContentTemplateTile Shape="Wide" NavigateUrl="EquipamentoLis.aspx"
                    Badge-ImageUrl="Images/timer.play.png"
                    BackColor="CornflowerBlue" Title-Text="Em Manutenção">
                    <ContentTemplate>
                        <div style="padding: 5px 0px 0px 5px; width: 100%; font-size: 50pt; text-align: center; font-weight: bold;">
                            <asp:Label ID="lblEmManutencao" runat="server" Text=""></asp:Label>
                        </div>
                    </ContentTemplate>
                </telerik:RadContentTemplateTile>
                
                <telerik:RadContentTemplateTile Shape="Wide" NavigateUrl="EquipamentoLis.aspx"
                    Badge-ImageUrl="Images/timer.pause.png"
                    BackColor="YellowGreen" Title-Text="Aguardando peças">
                    <ContentTemplate>
                        <div style="padding: 5px 0px 0px 5px; width: 100%; font-size: 50pt; text-align: center; font-weight: bold;">
                            <asp:Label ID="lblAguardandoPecas" runat="server" Text=""></asp:Label>
                        </div>
                    </ContentTemplate>
                </telerik:RadContentTemplateTile>                
            </telerik:TileGroup>
        </Groups>
    </telerik:RadTileList>
    <br />
    <span style="font-size:15pt; font-weight:bold;">Gráficos</span>
    <telerik:RadHtmlChart runat="server" ID="chrQtdeManutencaoMensalPorTipo" Width="1600px" Height="500px">
               <PlotArea>
                    <Series>
                         <telerik:ColumnSeries DataFieldY="Preventiva" Name="Preventiva">
                              <TooltipsAppearance Visible="false"></TooltipsAppearance>
                         </telerik:ColumnSeries>
                         <telerik:ColumnSeries DataFieldY="Corretiva" Name="Corretiva">
                              <TooltipsAppearance Visible="false"></TooltipsAppearance>
                         </telerik:ColumnSeries>
                        <telerik:ColumnSeries DataFieldY="Calibracao" Name="Calibração">
                              <TooltipsAppearance Visible="false"></TooltipsAppearance>
                         </telerik:ColumnSeries>
                    </Series>
                    <XAxis DataLabelsField="Mes">
                         <LabelsAppearance></LabelsAppearance>
                         <MajorGridLines Visible="false"></MajorGridLines>
                         <MinorGridLines Visible="false"></MinorGridLines>
                    </XAxis>
                    <YAxis>
                         <TitleAppearance Text="Quantidade"></TitleAppearance>
                         <MinorGridLines Visible="false"></MinorGridLines>
                    </YAxis>
               </PlotArea>
               <ChartTitle Text="Manutenções por mês (Quantidade)">
               </ChartTitle>
          </telerik:RadHtmlChart>

    <telerik:RadHtmlChart runat="server" ID="chrCustoManutencaoMensalPorTipo" Width="1600px" Height="500px">
               <PlotArea>
                    <Series>
                         <telerik:ColumnSeries DataFieldY="Preventiva" Name="Preventiva">
                              <TooltipsAppearance Visible="false"></TooltipsAppearance>
                         </telerik:ColumnSeries>
                         <telerik:ColumnSeries DataFieldY="Corretiva" Name="Corretiva">
                              <TooltipsAppearance Visible="false"></TooltipsAppearance>
                         </telerik:ColumnSeries>
                        <telerik:ColumnSeries DataFieldY="Calibracao" Name="Calibração">
                              <TooltipsAppearance Visible="false"></TooltipsAppearance>
                         </telerik:ColumnSeries>
                    </Series>
                    <XAxis DataLabelsField="Mes">
                         <LabelsAppearance></LabelsAppearance>
                         <MajorGridLines Visible="false"></MajorGridLines>
                         <MinorGridLines Visible="false"></MinorGridLines>
                    </XAxis>
                    <YAxis>
                         <TitleAppearance Text="Quantidade"></TitleAppearance>
                         <MinorGridLines Visible="false"></MinorGridLines>
                    </YAxis>
               </PlotArea>
               <ChartTitle Text="Manutenções por mês (Custo)">
               </ChartTitle>
          </telerik:RadHtmlChart>
</asp:Content>
