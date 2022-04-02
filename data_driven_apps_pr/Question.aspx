<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="data_driven_apps_pr.Question" %>

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
                    
                    <asp:Label runat="server" CssClass="questionTitle">Please choose your gender</asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC3300" />
                    
                    <br />
                    <div class="form-floating mb-3">
                        <asp:RadioButtonList ID="radioButtonList1" runat="server">
                            <asp:ListItem Value="M">Male</asp:ListItem>
                            <asp:ListItem Value="F">Female</asp:ListItem>
                            <asp:ListItem Value="X">Indeterminate/Intersex/Unspecified</asp:ListItem>
                        </asp:RadioButtonList>
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
