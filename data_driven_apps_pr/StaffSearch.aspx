<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffSearch.aspx.cs" Inherits="data_driven_apps_pr.StaffSearch" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
    <link href="css/app.css" rel="stylesheet"/>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
               <div class="col"></div>
               <div class="col">
                   <asp:Label runat="server" CssClass="title">AIT Resarch</asp:Label>
               </div>
               <div class="col"></div>
           </div>
            <div class="row">
                
                
                <div class="col alert alert-secondary align-content-center">
                    

                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC3300" />
                
                    <div class="row mb-1">
                        <div class="col-1"> </div>
                        <div class="col-5">
                            <asp:DropDownList class="form-select form-select-sm"  ID="dropdownList1" runat="server">
                                <asp:ListItem>Gender</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div class="col-5">
                            <asp:DropDownList class="form-select form-select-sm" ID="dropdownList2" runat="server">
                                <asp:ListItem Value="M">Male</asp:ListItem>
                                <asp:ListItem Value="F">Female</asp:ListItem>
                                <asp:ListItem Value="X">Indeterminate/Intersex/Unspecified</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div class="col-1"> </div>
                    </div>
                    <div class="row mb-1">
                        <div class="col-1">
                            <asp:DropDownList class="form-select form-select-sm" ID="dropdownList3" runat="server">
                                <asp:ListItem Value="M">And</asp:ListItem>
                                <asp:ListItem Value="F">Or</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-5">
                            
                            <asp:DropDownList class="form-select form-select-sm" ID="dropdownList4" runat="server">
                                <asp:ListItem Value="F">Bank</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div class="col-5">
                            <div class="form-check">
                                <asp:CheckBoxList ID="radioButtonList1" runat="server">
                                    <asp:ListItem Value="M">Australia and New Zealand Banking Group (ANZ)</asp:ListItem>
                                    <asp:ListItem Value="F">Commonwealth</asp:ListItem>
                                    <asp:ListItem Value="X">Westpac</asp:ListItem>
                                    <asp:ListItem Value="N">National Australian Bank (NAB)</asp:ListItem>
                                    <asp:ListItem Value="N">Bendigo Bank</asp:ListItem>
                                    <asp:ListItem Value="N">Macquarie Bank</asp:ListItem>
                                    <asp:ListItem Value="N">Bank of Queensland</asp:ListItem>
                                    <asp:ListItem Value="N">Bankwest</asp:ListItem>
                            
                                 </asp:CheckBoxList>
                            </div>

                        </div>
                        <div class="col-1"></div>
                    </div>
                    <div class="row mb-1">
                        <div class="col-1">
                            <asp:DropDownList class="form-select form-select-sm" ID="dropdownList6" runat="server">
                                
                                <asp:ListItem Value="F">Or</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-5">
                            
                            <asp:DropDownList ID="dropdownList7" class="form-select form-select-sm" runat="server">
                                <asp:ListItem Value="F">Email</asp:ListItem>
                            </asp:DropDownList></div>
                        <div class="col-5">
                            <asp:TextBox type="text"  runat="server" class="form-control form-control-sm" id="password" placeholder="Email"></asp:TextBox>

                        </div>
                        <div class="col-1">
                            <asp:Button ID="Button1" runat="server" class="btn btn-outline-primary" Text="Add" />

                        </div>
                    </div>
                    
                
                    <asp:Button ID="loginButton" runat="server" class="btn btn-primary" Text="Search" />
                    
                </div>
                
              </div>

        </div>
    </form>
</body>
</html>
