<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/StaffMaster.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="data_driven_apps_pr.Staff.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main_container_search">
        <div class="survey__card">
            <div class="header">
                <h1 class="title">Search</h1>
            </div>
            <div class="container-fluid">
                <div class="name__search__area">
                    <div class="column">
                        <h3>First name</h3>
                        <asp:TextBox CssClass="form-control" ID="TextBoxFirstName" runat="server" Placeholder="Search" />
                    </div>
                    <div class="column">
                        <h3>Last name</h3>
                        <asp:TextBox CssClass="form-control" ID="TextBoxLastName" runat="server" Placeholder="Search" />
                    </div>
                </div>
                <div class="age__range__area">
                    <h3>Age range</h3>
                    <asp:PlaceHolder ID="PlaceHolderAgeRange" runat="server" />
                </div>
                <div class="state__gender__area">
                    <div class="column">
                        <h3>State</h3>
                        <asp:PlaceHolder ID="PlaceHolderState" runat="server" />
                    </div>
                    <div class="column">
                        <h3>Gender</h3>
                        <asp:PlaceHolder ID="PlaceHolderGender" runat="server" />
                    </div>
                </div>
                <div class="suburb__postcode__area">
                    <div class="column">
                        <h3>Home suburb</h3>
                        <asp:TextBox CssClass="form-control" ID="TextBoxSuburb" runat="server" Placeholder="Search" />
                    </div>
                    <div class="column">
                        <h3>Home Postcode</h3>
                        <asp:TextBox CssClass="form-control" ID="TextBoxPostcode" runat="server" Placeholder="Search" />
                    </div>
                </div>
                <div class="bank__area">
                    <div class="column">
                        <h3>Banks used</h3>
                        <asp:PlaceHolder ID="PlaceHolderBank" runat="server" />
                    </div>
                    <div class="column">
                        <h3>Banks services</h3>
                        <asp:PlaceHolder ID="PlaceHolderBankService" runat="server" />
                    </div>
                </div>
                <div class="bank__area">
                    <div class="column">
                        <h3>Newspaper read</h3>
                        <asp:PlaceHolder ID="PlaceHolderNewspaper" runat="server" />
                    </div>
                    <div class="column">
                        <h3>Newspaper Sections</h3>
                        <asp:PlaceHolder ID="PlaceHolderNewspaperSections" runat="server" />
                    </div>
                </div>
                <div class="bank__area last__search__area">
                    <div class="column">
                        <h3>Newspaper Sports</h3>
                        <asp:PlaceHolder ID="PlaceHolderNewspaperSports" runat="server" />
                    </div>
                    <div class="column">
                        <h3>Newspaper Travels</h3>
                        <asp:PlaceHolder ID="PlaceHolderNewspaperTravels" runat="server" />
                    </div>
                </div>
                <asp:Button ID="ButtonSearch" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="ButtonSearch_Click" />
            </div>
        </div>

        <div class="survey__card">
            <div class="result__area">
                <h3>Research result</h3>
                <asp:DataGrid ID="DataGridResult" runat="server" />                
                <asp:DataGrid ID="resultSearch" runat="server" />
                <h3>Every result</h3>
                <asp:DataGrid ID="everyEntries" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
