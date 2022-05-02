<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/StaffMaster.Master" AutoEventWireup="true" CodeBehind="Respondents.aspx.cs" Inherits="data_driven_apps_pr.Staff.Respondents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="header">
        <h1 class="title">Respondents</h1>
    </div>
        <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound">
        </asp:GridView>
</asp:Content>
