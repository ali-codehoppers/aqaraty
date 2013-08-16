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
                if (UserDAO.GetChangePasswordVerifiedByIDnCode(Request["userId"], Request["code"], false))
                {
                    ChangePasswordPanel.Visible = true;
                }
                else
                {
                    ChangePasswordPanel.Visible = false;
                    GenericUtility.SetErrorMessage(this.Page.Master, "كود التأكيد غير صالحة", "");
                }
            }
            else
            {
                ChangePasswordPanel.Visible = false;
                GenericUtility.SetErrorMessage(this.Page.Master, "كود التأكيد غير صالحة", "");
            }
        }

        protected void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            if (Request["code"] != null && Request["userId"] != null) {
                User user = UserDAO.GetUserByID(Request["userId"]);
                if (user != null)
                {
                    if (UserDAO.UpdateUserPassword(user, ChangePasswordText.Text)){
                        GenericUtility.SetSuccessMessage(this.Page.Master, ".تغيير كلمة المرور بنجاح .<a href='Default.aspx'>اضغط هنا للصفحة الرئيسية</a> ", "");
                    }else{
                        GenericUtility.SetErrorMessage(this.Page.Master, "تغيير كلمة المرور غير ناجحة", "");
                    }
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>$(document).ready(function () {alert('تغيير كلمة المرور بنجاح');window.location='Default.aspx'});</script>");
                }
                //Response.Redirect("~/Default.aspx");
            }
            else
            {
                GenericUtility.SetErrorMessage(this.Page.Master, "كود التأكيد غير صالحة", "");
            }
        }
    }
}