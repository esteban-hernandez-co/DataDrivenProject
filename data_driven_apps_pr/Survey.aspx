<%@ Page Title="Survey" Language="C#" MasterPageFile="~/Webiste.Master" AutoEventWireup="true" CodeBehind="Survey.aspx.cs" Inherits="data_driven_apps_pr.Survey" %>
<%@ MasterType VirtualPath="~/Webiste.Master" %>  
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h6><strong>Your IP Address : </strong></h6>  
        <h6><strong>Method 1 : </strong><asp:Label ID="lblIPAddress" CssClass="label label-primary" runat="server" Text="Label"></asp:Label>   
            <strong>Method 2 : </strong><asp:Label ID="lblIPAdd" CssClass="label label-info" runat="server" Text="Label"></asp:Label>  
        <strong>Method : </strong><asp:Label ID="lblIPAd" CssClass="label label-info" runat="server" Text="Label"></asp:Label></h6>  
        <h6><strong>Time : </strong><asp:Label ID="lblDate" CssClass="label label-info" runat="server" Text="Label"></asp:Label></h6>  

        <asp:Label ID="lblQuestion" runat="server" Text=""></asp:Label>
        <br />
        <div class="card">
            <div class="card-body">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC3300" />
                <asp:PlaceHolder ID="placeHolderErrors" runat="server"></asp:PlaceHolder>

                <h4 class="card-title"><asp:Label ID="lblQuestionTitle" runat="server" Text="Question"></asp:Label></h4>
                <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
                
                <asp:PlaceHolder ID="placeHolderQuestionOptions"  runat="server"></asp:PlaceHolder>
                
                
          </div>
          <div class="card-footer text-muted">
            <asp:Button class="btn btn-lg btn-secondary text-end"  ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click"></asp:Button>
          </div>
        </div>  
    </div>
</asp:Content>
