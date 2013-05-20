using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aqaraty.Data.DAO;
using Aqaraty.Data.Utilities;

namespace Aqaraty.Web
{
    public partial class AccountVerification1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["code"] != null && Request["userId"] != null)
            {
                if (UserDAO.GetUserVerifiedByIDnCode(Request["userId"], Request["code"], true))
                {
                    GenericUtility.SetSuccessMessage(this.Page.Master, "مستخدم التحقق بنجاح", "");
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}