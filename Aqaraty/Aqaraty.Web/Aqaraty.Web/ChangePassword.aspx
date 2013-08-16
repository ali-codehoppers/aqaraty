<%@ Page Title="" Language="C#" MasterPageFile="~/Common/MainMaster.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="Aqaraty.Web.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
<asp:Panel runat="server" ID="ChangePasswordPanel">
    <div id="changePassDiv">
        <div class="row">
            <div class="col1">
                <span>كلمة المرور</span>
            </div>
            <div class="col2">
                <asp:TextBox runat="server" ID="ChangePasswordText" TextMode="Password" CssClas="fieldbox"></asp:TextBox>
            </div>
            <div class="col3">
                <asp:RequiredFieldValidator ValidationGroup="ChangePasswordGroup" runat="server" ID="RequiredChangePasswordText" ControlToValidate="ChangePasswordText"
                    Display="Dynamic" ErrorMessage="<a class='tooltip' title='مطلوب كلمة المرور'><img src='Images/error.png'/></a>"
                    Style="color: Red; font-weight: bold"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ValidationGroup="ChangePasswordGroup" ID="ChangePasswordValidator" runat="server" ControlToValidate="ChangePasswordText"
                    Display="Dynamic" ErrorMessage="<a class='tooltip' title='يجب أن تكون كلمة أكبر من أو يساوي 4 حرف'><img src='Images/error.png'/></a>"
                    Style="color: Red; font-weight: bold" ValidationExpression=".{4}.*" />
                <span style="margin-right: 10px; display: block; width: 75%; float: left;">
                <asp:RequiredFieldValidator runat="server" ID="RequiredChangePasswordText1" ControlToValidate="ChangePasswordText"
                    ValidationGroup="ChangePasswordGroup" Display="Dynamic" ErrorMessage="سقطة : مطلوب كلمة المرور"
                    Style="color: Red; font-weight: bold"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="ChangePasswordValidator1" runat="server" ControlToValidate="ChangePasswordText"
                    Display="Dynamic" ValidationGroup="ChangePasswordGroup" ErrorMessage="سقطة : يجب أن تكون كلمة أكبر من أو يساوي 4 حرف"
                    Style="color: Red; font-weight: bold" ValidationExpression=".{4}.*" />
                </span>
            </div>
            <div class="col4">
            </div>
        </div>
        <div class="row">
            <div class="col1">
                <span>تأكيد كلمة المرور</span>

            </div>
            <div class="col2">
                <asp:TextBox runat="server" ID="ChangeConfirmPasswordText" TextMode="Password" CssClas="fieldbox"></asp:TextBox>
            </div>
            <div class="col3">
                <asp:RequiredFieldValidator ValidationGroup="ChangePasswordGroup" runat="server" ID="RequiredConfirmPassword" ControlToValidate="ChangeConfirmPasswordText"
                    Display="Dynamic" ErrorMessage="<a class='tooltip' title='تأكيد كلمة المرور المطلوبة'><img src='Images/error.png'/></a>"
                    Style="color: Red; font-weight: bold"></asp:RequiredFieldValidator>
                <asp:CompareValidator ValidationGroup="ChangePasswordGroup" ID="comparePasswords" runat="server" ControlToCompare="ChangePasswordText"
                    ControlToValidate="ChangeConfirmPasswordText" ErrorMessage="<a class='tooltip' title='كلمة المرور لا تتطابق'><img src='Images/error.png'/></a>"
                    Display="Dynamic" />
                                    <span style="margin-right: 10px; display: block; width: 75%; float: left;">
                    <asp:RequiredFieldValidator runat="server" ID="RequiredConfirmPassword1" ControlToValidate="ChangeConfirmPasswordText"
                    ValidationGroup="ChangePasswordGroup" Display="Dynamic" ErrorMessage="سقطة : تأكيد كلمة المرور المطلوبة"
                    Style="color: Red; font-weight: bold"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="comparePasswords1" runat="server" ControlToCompare="ChangePasswordText"
                    ValidationGroup="ChangePasswordGroup" ControlToValidate="ChangeConfirmPasswordText"
                    ErrorMessage="سقطة : كلمة المرور لا تتطابق" Style="color: Red; font-weight: bold"
                    Display="Dynamic" />
                </span>
            </div>
            <div class="col4">
            </div>
        </div>
        <div style="float:right">
            <asp:Button runat="server" CssClass="buttonClass" ValidationGroup="ChangePasswordGroup" ID="ChangePasswordButton" Text="Submit" OnClick="ChangePasswordButton_Click" />
        </div>
    </div>
    </asp:Panel>
</asp:Content>
