<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question2.aspx.cs" Inherits="data_driven_apps_pr.Question2" %>
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
                <div class="col"></div>
                
                <div class="col alert alert-secondary align-content-center">
                    <div class="mb-2">
                        <asp:Label runat="server" CssClass="questionTitle">Do you have use any of these banks? (You can select up to 4)</asp:Label>
                    </div>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC3300" />
                    
                    <br />
                    <div class="form-floating mb-3">
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
                    <div class="text-end">
                        <asp:Button ID="loginButton" runat="server" class="btn btn-primary" Text="Next" />
                    </div>
                
                    
                    
                </div>
                <div class="col"></div>
              </div>

        </div>
    </form>
</body>
</html>
