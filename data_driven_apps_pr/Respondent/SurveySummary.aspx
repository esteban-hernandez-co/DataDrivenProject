<%@ Page Title="Survey Summary" Language="C#" MasterPageFile="~/Webiste.Master" AutoEventWireup="true" CodeBehind="SurveySummary.aspx.cs" Inherits="data_driven_apps_pr.Respondent.SurveySummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label runat="server" ID="lblSurverySummaryTitle" class="surveySummaryTitle" Text="Survey Summary"></asp:Label>
        <asp:PlaceHolder ID="infoAnswers" runat="server"></asp:PlaceHolder>

        <p><b>
            You can participate in this survey anonymously or register your personal information.

           </b>
        </p> 
        <div class="anonymous">
            <div class="anonymous__title">
                Taking the survey anonymously?
            </div>
        </div>
        <div >
            <asp:RadioButton ID="anonymous_yes" runat="server" Text="Yes" GroupName="anonymous" Checked="true" />
            <asp:RadioButton ID="anonymous_no" runat="server" Text="No" GroupName="anonymous"/>        
        </div>
        <div>
            <asp:Button class="btn btn-lg btn-secondary" ID="ButtonNext" runat="server" Text="Next" OnClick="ButtonNext_Click" />
        </div>
    </div>
</asp:Content>
