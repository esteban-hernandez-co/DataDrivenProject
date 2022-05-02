<%@ Page Title="Login" Language="C#" MasterPageFile="~/Webiste.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="data_driven_apps_pr.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC3300" />
    <asp:Label ID="messages" runat="server" Text=""></asp:Label>
    <div class="row">
        <div class="col-md-3">

        </div>
        <div class="col-md-6 col-12">
            <div class="form-floating mb-3">
                <asp:TextBox type="text"  runat="server" class="form-control" ID="username" placeholder="Username"></asp:TextBox>
                <label for="username">Username</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server" ControlToValidate="username" ErrorMessage="Username is required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
            </div>
            <div class="form-floating mb-3">
                <asp:TextBox type="password"  runat="server" class="form-control" ID="password" placeholder="Password"></asp:TextBox>
                <label for="password">Password</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ControlToValidate="password" ErrorMessage="Password is required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Button ID="loginButton" runat="server" class="btn btn-primary" Text="Login" OnClick="loginButton_Click" />
            </div>
            <br />
            <div>
                <asp:LinkButton runat="server" Text="Forgot Password?"></asp:LinkButton>
            </div>
        </div>
    
        <div class="col-md-3">

        </div>
    </div>
</asp:Content>




    