using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aqaraty.Data;
using Aqaraty.Data.Utilities;
using System.Text;
using Aqaraty.Data.DAO;
using System.Drawing;

namespace Aqaraty.Web.Common
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            recaptcha.Validate();
            Session session = null;
            if (Request.Cookies["SessionID"]!= null && Request.Cookies["SessionID"].Value!=null)
                session = UserDAO.GetSessionByID(Request.Cookies["SessionID"].Value);
            if (session != null)
            {
                bfrLoginPanel.Visible = false;
                afrLoginPanel.Visible = true;
                OfficeLabel.Text=session.User.OfficeName;
            }
            else {
                bfrLoginPanel.Visible = true;
                afrLoginPanel.Visible = false;
            }
        }
        /*protected void ForgetButton_Click(object sender, EventArgs e)
        {
            try {
                User user = UserDAO.GetUserByEmail(usernameText.Text);
                if (user != null)
                {
                    string code = HttpUtility.UrlEncode(Convert.ToBase64String(GenericUtility.CreateSHAHash(user.VerificationCode)));
                    EmailUtility.SendPasswordEmail(usernameText.Text, "Change Password - Aqaraty", "http://94.236.98.81/Aqaraty/ChangePassword.aspx?userId=" + user.UserID + "&code=" + code);
                    GenericUtility.SetSuccessMessage(this.Page.Master, "Email send for change password.","Login");
                }
            }catch (Exception ex) {
                GenericUtility.SetErrorMessage(this.Page.Master, "Error : " + ex.Message, "Login");
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>$(document).ready(function () {$(\"#loginDiv\").dialog(\"open\");});</script>");
        }
        protected void LoginDivButton_Click(object sender, EventArgs e)
        {
            byte[] passwordText = GenericUtility.CreateSHAHash(PasswordText.Text);
            string id = UserDAO.GetUserIDByUNamePass(usernameText.Text, passwordText);
            if (id != null)
            {
                bfrLoginPanel.Visible = false;
                afrLoginPanel.Visible = true;
                string sessionId = UserDAO.InsertSession(id, LoginRememberCheck.Checked,"", System.Web.Configuration.WebConfigurationManager.AppSettings["SessionTime"].ToString());
                HttpCookie SessionCookies = new HttpCookie("SessionID",sessionId);
                SessionCookies.Expires=DateTime.Now.AddYears(1);
                Response.Cookies.Add(SessionCookies);
                SuccessPanel.Visible = false;
                ErrorPanel.Visible = false;
                Response.Redirect("~/Default.aspx");
            }
            else {
                GenericUtility.SetErrorMessage(this.Page.Master, "Invalid Login.", "Login");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>$(document).ready(function () {$(\"#loginDiv\").dialog(\"open\");});</script>");
            }
        }
        protected void RegisterDivButton_Click(object sender, EventArgs e)
        {
            if (!recaptcha.IsValid)
            {
                lblResult.Visible = true;
                lblResult1.Visible = true;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>$(document).ready(function () {$(\"#registerDiv\").dialog(\"open\");});</script>");
            }
            else
            {
                lblResult1.Visible = false;
                lblResult.Visible = false;
            }
            if (Page.IsValid && recaptcha.IsValid)
            {
                try
                {
                    User user=UserDAO.InsertUser(RegisterEmailText.Text, RegisterPasswordText.Text, OfficeText.Text);
                    if (user != null)
                    {
                        string code = HttpUtility.UrlEncode(Convert.ToBase64String(GenericUtility.CreateSHAHash(user.VerificationCode)));
                        EmailUtility.SendPasswordEmail(RegisterEmailText.Text, "Account Verification - Aqaraty", "http://94.236.98.81/Aqaraty/AccountVerification.aspx?userId=" + user.UserID + "&code=" + code);
                        GenericUtility.SetSuccessMessage(this.Page.Master, "User successfully registered.","Register");
                        
                        RegisterEmailText.Text = "";
                        RegisterPasswordText.Text = "";
                        OfficeText.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    GenericUtility.SetErrorMessage(this.Page.Master, "Error :" + ex.Message, "Register");
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>$(document).ready(function () {$(\"#registerDiv\").dialog(\"open\");});</script>");
            }

        }*/
        protected void logoutButton_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["SessionID"] != null && Request.Cookies["SessionID"].Value != null) {
                UserDAO.DeleteSessionBySessionId(Request.Cookies["SessionID"].Value);
            }
            Response.Cookies["SessionID"].Expires = DateTime.Now.AddDays(-1d);
            Response.Redirect("~/Default.aspx");
        }
    }
}