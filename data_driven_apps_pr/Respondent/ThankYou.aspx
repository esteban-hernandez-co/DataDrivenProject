﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Webiste.Master" AutoEventWireup="true" CodeBehind="ThankYou.aspx.cs" Inherits="data_driven_apps_pr.Respondent.ThankYou" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Thank you</h1>
    <br />
    <div>
        <asp:Button class="btn btn-lg btn-secondary" ID="ButtonSendMeHome" runat="server" Text="Home" OnClick="ButtonSendMeHome_Click" />
    </div>
</asp:Content>
