<%@ Page Title="Survey" Language="C#" MasterPageFile="~/Webiste.Master" AutoEventWireup="true" CodeBehind="Survey.aspx.cs" Inherits="data_driven_apps_pr.Survey" %>
<%@ MasterType VirtualPath="~/Webiste.Master" %>  
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h6><strong>Your IP Address : </strong><asp:Label ID="lblIPAd" CssClass="label label-info" runat="server" Text="Label"></asp:Label></h6>  
        <h6><strong>Time : </strong><asp:Label ID="lblDate" CssClass="label label-info" runat="server" Text="Label"></asp:Label></h6>  

        <asp:Label ID="lblQuestion" runat="server" Text=""></asp:Label>
        <br />
        <div id="cardQuestion" class="card">
            <div class="card-body">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC3300" />
                <asp:PlaceHolder ID="placeHolderErrors" runat="server"></asp:PlaceHolder>
                

                <div class="card-title mb-5">
                    <h4><asp:Label ID="lblQuestionTitle" runat="server" Text="Question"></asp:Label></h4>
                    <h6><asp:Label ID="lblQuestionOption" runat="server" Text="Question Option"></asp:Label></h6>
                </div>
                
                <p class="card-text">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="This Field is required"></asp:RequiredFieldValidator>
                
                <asp:Panel ID="panelQuestionOptions" runat="server">
                    
                </asp:Panel>
                
                <asp:Label ID="lblNextQuestion" runat="server" Text="Next Question" Font-Size="Smaller"></asp:Label>
          </div>
          <div class="card-footer text-muted">
            <asp:Button class="btn btn-lg btn-secondary text-end"  ID="btnNext" runat="server" Text="Next" OnClick="BtnNext_Click"></asp:Button>
          </div>
        </div>  
    </div>
</strong>
</asp:Content>
