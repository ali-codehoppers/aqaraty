using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aqaraty.Data.DAO;
using Aqaraty.Data;
using Aqaraty.Data.Utilities;

namespace Aqaraty.Web
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["code"] != null && Request["userId"] != null)
            {
                if (UserDAO.GetUserVerifiedByIDnCode(Request["userId"], Request["code"], false))
                {

                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            if (Request["code"] != null && Request["userId"] != null) {
                User user = UserDAO.GetUserByID(Request["userId"]);
                if (user != null)
                {
                    UserDAO.UpdateUserPassword(user,ChangePasswordText.Text);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>$(document).ready(function () {alert('تغيير كلمة المرور بنجاح');window.location='Default.aspx'});</script>");
                }
                //Response.Redirect("~/Default.aspx");
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}