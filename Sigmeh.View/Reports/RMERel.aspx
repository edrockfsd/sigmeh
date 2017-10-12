<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RMERel.aspx.cs" Inherits="Sigmeh.View.Reports.RMERel" %>



<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=7.2.14.127, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
                <telerik:ReportViewer ID="ReportViewer1" runat="server" Height="600px" Width="100%">            
                <typereportsource typename="Sigmeh.View.Reports.rptRME, Sigmeh.View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"></typereportsource>                    
                </telerik:ReportViewer>
            </td>
        </tr>
    </table>
</asp:Content>
