<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="data_driven_apps_pr.Login" %>

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
                    

                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC3300" />
                
                    <div class="form-floating mb-3">
                        <asp:TextBox type="text"  runat="server" class="form-control" id="username" placeholder="Username"></asp:TextBox>
                        <label for="username">Username</label>
                    </div>
                    <div class="form-floating mb-3">
                        <asp:TextBox type="password"  runat="server" class="form-control" id="password" placeholder="Password"></asp:TextBox>
                        <label for="password">Password</label>
                    </div>
                
                    <asp:Button ID="loginButton" runat="server" class="btn btn-primary" Text="Login" />
                    <asp:LinkButton runat="server" Text="Forgot Password?"></asp:LinkButton>
                </div>
                <div class="col"></div>
              </div>

        </div>
    </form>
</body>
</html>
