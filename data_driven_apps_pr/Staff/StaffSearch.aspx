<%@ Page Title="Search" Language="C#" MasterPageFile="~/Staff/StaffMaster.Master" AutoEventWireup="true" CodeBehind="StaffSearch.aspx.cs" EnableViewState="true" Inherits="data_driven_apps_pr.StaffSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type = "text/javascript">
        function getAnswerControl(control) {
            var pageUrl = '<%=ResolveUrl("~/Staff/StaffSearch.aspx")%>'
            if (control !== undefined) {
                let valQuestion = control.value;
                let rowId = $("#" + control.id).parent().parent().data("row-id");

                if (valQuestion !== "") {
                    var jqxhr = $.ajax({
                        type: "POST",
                        url: pageUrl + '/GetAnswerControl',
                        data: '{questionId:  '+ valQuestion +'  , questionRowId: ' + rowId +'  }',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data, textStatus, jqXHR) { answerControlAppend(data, rowId); },
                        failure: function (response) {
                            alert(response.d);
                        }
                    });
                }
            }
        }
        function newQuestionRow() {
            prevId = $("#addButtonDiv").prev().children().last().data("row-id");
            var divQuestions = document.getElementById("questionControls");
            var idDiv = prevId+1;
            //div Row
            newDivRow = document.createElement("div");
            newDivRow.setAttribute("data-row-id", idDiv);
            newDivRow.setAttribute("class", "row mb-1");
            
            //div Col 1
            newDivCol1 = document.createElement("div");
            newDivCol1.setAttribute("class", "col-1");
            
            //select or / and
            pt = document.createElement("select");
            pt.setAttribute("id", "andOr" + idDiv);
            pt.setAttribute("name", "andOr" + idDiv);
            pt.setAttribute("class", "form-select form-select-sm");

            var optionAnd = document.createElement("option");
            optionAnd.setAttribute("value", "and");
            var textOptionAnd = document.createTextNode("And");
            optionAnd.appendChild(textOptionAnd);
            pt.appendChild(optionAnd);

            var optionOr = document.createElement("option");
            optionOr.setAttribute("value", "or");
            var textOptionOr = document.createTextNode("Or");
            optionOr.appendChild(textOptionOr);
            pt.appendChild(optionOr);
                        
            newDivCol1.appendChild(pt);
            newDivRow.appendChild(newDivCol1);

            //div Col 2
            newDivCol2 = document.createElement("div");
            newDivCol2.setAttribute("id", "questionControlDiv"+idDiv);
            newDivCol2.setAttribute("class", "col-5");

            //question Control
            qst = document.createElement("select");
            qst.setAttribute("id", "question" + idDiv);
            qst.setAttribute("name", "question" + idDiv);
            qst.setAttribute("required", "required");
            qst.setAttribute("class", "form-select form-select-sm");

            newDivCol2.appendChild(qst);

            newDivRow.appendChild(newDivCol2);

            //div Col 3
            newDivCol3 = document.createElement("div");
            newDivCol3.setAttribute("id", "answerControlDiv" + idDiv);
            newDivCol3.setAttribute("class", "col-5");
                        
            newDivRow.appendChild(newDivCol3);

            //div Col 4
            newDivCol4 = document.createElement("div");
            newDivCol4.setAttribute("class", "col-1");

            newDivRow.appendChild(newDivCol4);

            divQuestions.appendChild(newDivRow);

            //listener
            $("#question" + idDiv).change(function () {
                getAnswerControl(this);
            });


            var pageUrl = '<%=ResolveUrl("~/Staff/StaffSearch.aspx")%>'
            var jqxhr = $.ajax({
                type: "POST",
                url: pageUrl + '/GetQuestionControl',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data, textStatus, jqXHR) { OnQuestionsPopulated(data, $("#question" + idDiv)); },
                failure: function (response) {
                    alert(response.d);
                }
            });
            
        }
        function OnQuestionsPopulated(response, control) {
            PopulateControl(response.d, control);
        }
        function answerControlAppend(response, rowId) {
            //answerControl exists?
            var answerElem = document.getElementById("answer" + rowId);
            if (answerElem == undefined) {
                if (response == null) {
                    pt = document.createElement("input");
                    pt.setAttribute("id", "answer" + rowId);
                    pt.setAttribute("name", "answer" + rowId);
                    pt.setAttribute("type", "text");
                    pt.setAttribute("class", "form-control form-control-sm");
                } else {

                    pt = document.createElement("select");
                    pt.setAttribute("id", "answer" + rowId);
                    pt.setAttribute("name", "answer" + rowId);
                    pt.setAttribute("required", "required");
                    pt.setAttribute("class", "form-select");
                }
                var divRow = document.getElementById("answerControlDiv" + rowId);
                divRow.appendChild(pt);
            }

            PopulateControl(response.d, $("#answer"+rowId));
        }
        function removeLastItem(control) {
            let row = $("#" + control.id).parent().parent();
            let rowId = $("#" + control.id).parent().parent().data("row-id");
            row.remove();
        }
        function PopulateControl(list, control) {
            if (list.length > 0) {
                control.removeAttr("disabled");
                control.empty().append('<option selected="selected" value="0">Please select</option>');
                $.each(list, function () {
                    control.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            }
            else {
                control.empty().append('<option selected="selected" value="0">Not available<option>');
            }
            $('.form-select').select2();
        }

        $('form').submit(function () {
            return validateForm();
        });

        function validateForm() {

            let empty_elems = [];
            fieldEmptyNumber = 0;
            $("select, input:text, textarea").each(function () {

                // Check if the element is empty
                if ($(this).val().length < 1 || $(this).val() == 0) {
                    // Access the empty element
                    $(this).css(
                        "border", "1px red dotted"
                    );
                    // Add the elements to the list
                    empty_elems += "<li>" +
                        ($(this).get(0).tagName) + "</li>";
                    fieldEmptyNumber++;
                }
                else {
                    // Access the non-empty element
                    $(this).css(
                        "border", ""
                    );
                }
            });
            $("#message").html(empty_elems);
           

            return (fieldEmptyNumber < 1);
            
            
        }



    </script>

    <div class="container-fluid">
                <div class="col align-content-center">
                    <div class="header">
                        <h1 class="title">Search</h1>
                    </div>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC3300" />
                    <div id="message" style="color: #CC3300;"></div>
                    <div id="questionControls">

                    
                        <div class="row mb-1" data-row-id="1">
                            <div class="col-1"> </div>
                            <div id="questionControlDiv1" class="col-5">
                                <asp:DropDownList class="form-select form-select-sm"  ID="question1" runat="server" onChange="getAnswerControl(this)" >
                                    <asp:ListItem Text="Name" Value="name"></asp:ListItem>
                                    <asp:ListItem Text="LastName" Value="lastname"></asp:ListItem>
                                    <asp:ListItem Text="Email" Value="email"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="question1" runat="server" ErrorMessage="This Field is required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                            </div>
                            <div id="answerControlDiv1" class="col-5">
                                <asp:TextBox ID="answerControl" runat="server" CssClass="form-control form-control-sm" ></asp:TextBox>

                            </div>
                            <div class="col-1"> </div>
                        </div>

                        <div class="row mb-1" data-row-id="2">
                            <div class="col-1">
                                <asp:DropDownList class="form-select form-select-sm" ID="andOr2" runat="server">
                                    <asp:ListItem Value="and">And</asp:ListItem>
                                    <asp:ListItem Value="or">Or</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="questionControlDiv2" class="col-5">
                                <asp:DropDownList class="form-select form-select-sm"  ID="question2" runat="server" onChange="getAnswerControl(this)" >
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="questionValidator1" ControlToValidate="question2" runat="server" ErrorMessage="This Field is required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                            </div>
                            <div id="answerControlDiv2" class="col-5">
                                <asp:PlaceHolder ID="placeHolderAnswer2" runat="server"></asp:PlaceHolder>

                            </div>
                            <div class="col-1"> </div>
                        </div>

                        <asp:PlaceHolder ID="placeHolderFields" runat="server"></asp:PlaceHolder>
                    </div>
                    
                    <div class="row mb-1" id="addButtonDiv">
                        <div class="col-1">
                            &nbsp;
                        </div>
                        <div class="col-5">
                            &nbsp;
                        </div>
                        <div class="col-5">
                            &nbsp;
                        </div>
                        <div class="col-1">
                            <input type="button" class="btn btn-outline-primary" onclick="newQuestionRow()" value="Add" />
                        </div>
                    </div>
                    <asp:Button ID="SearchButton" runat="server" class="btn btn-primary" Text="Search" OnClick="SearchButton_Click" />
                    <asp:DataGrid ID="DataGridResult" runat="server" />     
                </div>
                
              </div>
</asp:Content>



        
            
            

        