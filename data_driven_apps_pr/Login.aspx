<%@ Page Title="Login" Language="C#" MasterPageFile="~/Webiste.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="data_driven_apps_pr.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC3300" />
                
    <div class="form-floating mb-3">
        <asp:TextBox type="text"  runat="server" class="form-control" id="username" placeholder="Username"></asp:TextBox>
        <label for="username">Username</label>
    </div>
    <div class="form-floating mb-3">
        <asp:TextBox type="password"  runat="server" class="form-control" id="password" placeholder="Password"></asp:TextBox>
        <label for="password">Password</label>
    </div>
                
    <asp:Button ID="loginButton" runat="server" class="btn btn-primary" Text="Login" />
    <asp:LinkButton runat="server" Text="Forgot Password?"></asp:LinkButton>
</asp:Content>




    