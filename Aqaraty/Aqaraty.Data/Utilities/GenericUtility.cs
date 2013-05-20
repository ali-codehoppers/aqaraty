using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Security.Cryptography;

namespace Aqaraty.Data.Utilities
{
    public static class GenericUtility
    {
        public static void SetSuccessMessage(Control root,string message,string subType)
        {
            SetMessage(root,"Error",subType, "", false);
            SetMessage(root,"Success",subType, message, true);
        }
        public static void SetErrorMessage(Control root, string message,string subType)
        {
            SetMessage(root,"Success",subType, "", false);
            SetMessage(root,"Error",subType, message, true);
        }
        private static void SetMessage(Control root,string type,string subType, string message, bool visible)
        {
            Panel panel = (Panel)FindControl(root, subType + type + "Panel");
            Label label = (Label)FindControl(root, subType + type + "Message");
            if (panel != null && label != null)
            {
                panel.Visible = visible;
                label.Text = message;
            }
        }
        private static Control FindControl(Control root, string controlId)
        {

            if (root != null)
            {
                if (root.ID == controlId)
                {
                    return root;
                }
                foreach (Control control in root.Controls)
                {
                    Control foundControl = FindControl(control, controlId);
                    if (foundControl != null)
                        return foundControl;
                }
            }
            return null;
        }
        public static byte[] CreateSHAHash(string Phrase)
        {
            SHA512Managed HashTool = new SHA512Managed();
            Byte[] PhraseAsByte = System.Text.Encoding.UTF8.GetBytes(string.Concat(Phrase));
            Byte[] EncryptedBytes = HashTool.ComputeHash(PhraseAsByte);
            HashTool.Clear();
            return EncryptedBytes;
        }
    }
}
