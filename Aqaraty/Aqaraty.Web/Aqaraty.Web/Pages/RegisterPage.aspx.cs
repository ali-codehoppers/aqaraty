using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aqaraty.Data.DAO;
using System.Drawing;

namespace Aqaraty.Web.Pages
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            recaptcha.Validate();
            
        }
        protected void RegisterDivButton_Click(object sender, EventArgs e)
        {
            if (!recaptcha.IsValid){
                lblResult.Text = "Incorrect Captcha";
                lblResult.Visible = true;
            }else {
                lblResult.Visible = false;
            }
            if (Page.IsValid && recaptcha.IsValid)
            {
                UserDAO.InsertUser(RegisterEmailText.Text, RegisterPasswordText.Text, OfficeText.Text);
            }
            
        }
    }
}