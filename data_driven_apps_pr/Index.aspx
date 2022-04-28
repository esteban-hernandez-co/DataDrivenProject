<%@ Page Title="Welcome to AIT Research" Language="C#" MasterPageFile="~/Webiste.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="data_driven_apps_pr.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mb-5 loginLink">
        <asp:LinkButton runat="server" Text="Log in" OnClick="Unnamed1_Click"></asp:LinkButton>
    </div>
    <div>
        <div class="row mb-5">
            <div class="col align-items-end titleStartSurvey">
                    AIT Research (AITR) is a market research company that allows people from the general 
                public to register their personal details, buying habits etc. with AITR and then sends these 
                respondents to market research jobs, based on the needs of AITR’s clients.  <br />

            </div>
        </div>
        
        <div class="row mb-5">
            &nbsp;
        </div>
        <div class="row">
            <div class="col align-items-end">
                <asp:Button ID="btnStartSurvey" class="btn btn-success" Text="Start Survey" runat="server" OnClick="btnStartSurvey_Click"  />
            </div>

        </div>
        
    </div>
</asp:Content>
