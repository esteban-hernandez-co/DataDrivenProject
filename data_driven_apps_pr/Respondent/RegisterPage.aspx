<%@ Page Title="" Language="C#" MasterPageFile="~/Webiste.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="data_driven_apps_pr.Respondent.RegisterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC3300" />
        <div class="mb-3 text-start">
          <asp:Label ID="lblFirstName" class="form-label" runat="server" Text="First Name"></asp:Label>
          <asp:TextBox class="form-control" ID="txtFirstName"  runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Name is required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
        </div>
        <div class="mb-3 text-start">
          <asp:Label ID="lblLastName" class="form-label" runat="server" Text="Last Name"></asp:Label>
          <asp:TextBox class="form-control" ID="txtLastName"  runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName" ErrorMessage="Lastame is required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
        </div>
        <div class="mb-3 text-start">
          <asp:Label ID="lblDob" class="form-label" runat="server" Text="DOB"></asp:Label>
          <asp:TextBox ID="txtDob" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDob" ErrorMessage="DOB is required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
        </div>
        <div class="mb-3 text-start">
          <asp:Label ID="lblPhone" class="form-label" runat="server" Text="Phone Number"></asp:Label>
          <asp:TextBox ID="txtPhone" class="form-control" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone Number is required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
        </div>
        <div class="mb-3 text-start">
          <asp:Label ID="Label1" class="form-label" runat="server" Text="Email"></asp:Label>
          <asp:TextBox ID="txtEmail" class="form-control" runat="server" TextMode="Email"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
        </div>
        <div class="mb-3 text-start">
          <asp:Button ID="btnRegister" class="btn btn-primary" runat="server" Text="Register" OnClick="BtnRegister_Click" />&nbsp; 
          <asp:Button ID="btnCancel" class="btn btn-secondary" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
        </div>
        
        
    </div>
</asp:Content>
