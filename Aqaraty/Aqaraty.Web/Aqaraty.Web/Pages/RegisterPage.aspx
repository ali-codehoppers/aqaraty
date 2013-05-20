<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Blank.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Aqaraty.Web.Pages.RegisterPage" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
<div class="row">
            <div id="registerError"><span style="color:Red;font-weight:bold"></span>
            
            </div>
         </div>
         <div class="row">
            <div class="col1">
                Office Name
            </div>
            <div class="col2">
                <asp:TextBox runat="server" ID="OfficeText" CssClass="fieldbox"></asp:TextBox>
            </div>
            <div class="col3">
                <asp:RequiredFieldValidator runat="server" ID="reqOfficeText" ControlToValidate="OfficeText" ValidationGroup="RegisterGroup" Display="Dynamic" ErrorMessage="* Office is required." style="color:Red;font-weight:bold"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col1">
                Email
            </div>
            <div class="col2">
                <asp:TextBox runat="server" ID="RegisterEmailText" CssClass="fieldbox"></asp:TextBox>
            </div>
            <div class="col3">
                <asp:RequiredFieldValidator runat="server" ID="RequiredEmailText" ControlToValidate="RegisterEmailText" ValidationGroup="RegisterGroup" Display="Dynamic" ErrorMessage="* Email is required." style="color:Red;font-weight:bold"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col1">
                Password
            </div>
            <div class="col2">
                <asp:TextBox runat="server" ID="RegisterPasswordText" CssClass="fieldbox" TextMode="Password"></asp:TextBox>
            </div>
            <div class="col3">
                <asp:RequiredFieldValidator runat="server" ID="RequiredPasswordText" ControlToValidate="RegisterPasswordText" ValidationGroup="RegisterGroup" Display="Dynamic" ErrorMessage="* Password is required." style="color:Red;font-weight:bold"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col1">
                
            </div>
            <div class="col2">
                 <recaptcha:RecaptchaControl
                    ID="recaptcha"
                    runat="server"
                    PublicKey="6LckBuESAAAAAOnxkrX5Qj2sq_IebPRHgMqukTQQ"
                    PrivateKey="6LckBuESAAAAABEWhYBUE5oB6e_5qzPknBcpoJnZ"/>
            </div>
            <div class="col3">
                <asp:Label Visible=false ID="lblResult" runat="server" style="color:Red;font-weight:bold"/>
            </div>
        </div>
         <div class="row">
            <div class="col1">
                <asp:Button runat="server" ID="RegisterDivButton" ValidationGroup="RegisterGroup" Text="Register" onclick="RegisterDivButton_Click" OnClientClick="checkRegister()"/>
            </div>
            <div class="col2">
                
            </div>
            <div class="col3">
            </div>
        </div>
</div>
<script type="text/javascript">
    function checkRegister() {
        if (Page_ClientValidate("RegisterGroup")) {
            return true;
        }
        return false;
    }
    $(document).ready(function () {
        $("#<%=RegisterEmailText.ClientID %>").blur(function () {
            var data = "email=" + $("#<%=RegisterEmailText.ClientID %>").val();
            if ($("#<%=RegisterEmailText.ClientID %>").val().trim() != "") {
                $.ajax({
                    type: "Get",
                    contentType: "text/html",
                    url: "http://localhost:17625/AqaratyService.svc/IsEmailExist?" + data,
                    async: false,
                    success: function (data) {
                        if (data.trim() == "false") {
                            $("#registerError span").html("Email already exists.");
                        }
                    }, error: function (jqXHR, textStatus, errorThrown) {
                        // log the error to the console
                        alert("error" + errorThrown);
                        //alert(err.Message);
                    }

                });
            }
        });
    });
</script>
</asp:Content>
