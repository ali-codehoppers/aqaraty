using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Aqaraty.Data;
using System.IO;
using Aqaraty.Data.DAO;
using Aqaraty.Web.Service.Object;
using System.Web;
using Aqaraty.Data.Utilities;
using System.ServiceModel.Channels;

namespace Aqaraty.Web.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AqaratyService" in code, svc and config file together.
    public class AqaratyService : IAqaratyService
    {
        public ReturnObject IsEmailExist(UserRequest Object)
        {
            try
            {
                bool isExist = false;
                if (UserDAO.GetUserByEmail(Object.email) != null)
                {
                    isExist = true;
                }
                ReturnObject rObj = new ReturnObject(isExist, "البريد الإلكتروني موجود بالفعل", "");
                return rObj;
            }
            catch (Exception ex) {
                ReturnObject rObj = new ReturnObject(false, ex.Message, "");
                return rObj;
            }
        }
        public ReturnObject IsLoginUser(UserRequest Object) {
            bool isExist = false;
            string message = "";
            try
            {
                byte[] passwordText = GenericUtility.CreateSHAHash(Object.password);
                string id = UserDAO.GetUserIDByUNamePass(Object.email, passwordText);
                string sessionId = "";
                OperationContext context = OperationContext.Current;
                MessageProperties messageProperties = context.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpointProperty = messageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            
                if (id != null)
                {
                    sessionId = UserDAO.InsertSession(id, Object.remember, endpointProperty.Address, System.Web.Configuration.WebConfigurationManager.AppSettings["SessionTime"].ToString());
                    isExist = true;
                    message = "مستخدم تسجيل الدخول بنجاح";
                }
                else {
                    isExist = false;
                    message = "البريد الإلكتروني غير صحيح أو كلمة المرور";
                }
                ReturnObject rObj = new ReturnObject(isExist, message, sessionId);
                return rObj;
            }catch(Exception ex){
                ReturnObject rObj = new ReturnObject(false, ex.Message , "");
                return rObj;
            }
        }
        public ReturnObject ForgotPassword(UserRequest Object) {
            bool isExist = true;
            string message = "";
            try
            {
                User user = UserDAO.GetUserAndResetChangePassword(Object.email);
                if (user != null)
                {
                    string code = HttpUtility.UrlEncode(Convert.ToBase64String(GenericUtility.CreateSHAHash(user.ChangePasswordCode)));
                    EmailUtility.SendPasswordEmail(Object.email, "عقاراتي - تغيير كلمة المرور", "http://94.236.98.81/Aqaraty/ChangePassword.aspx?userId=" + user.UserID + "&code=" + code);
                    message = "البريد الالكتروني ارسال لتغيير كلمة المرور";
                }
                else
                {
                    isExist = false;
                    message = "عنوان البريد الإلكتروني غير صحيح";
                }
                ReturnObject rObj = new ReturnObject(isExist, message, "");
                return rObj;
            }catch(Exception ex){
                ReturnObject rObj = new ReturnObject(false, ex.Message , "");
                return rObj;
            }
        }
        public ReturnObject CheckCaptcha(UserRequest Object)
        {
            try
            {
                OperationContext context = OperationContext.Current;
                MessageProperties messageProperties = context.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpointProperty = messageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;


                Recaptcha.RecaptchaValidator captchaValidtor = new Recaptcha.RecaptchaValidator
                {
                    PrivateKey = System.Web.Configuration.WebConfigurationManager.AppSettings["PRIVATE_KEY"].ToString(),
                    RemoteIP = endpointProperty.Address,
                    Challenge = Object.challenge,
                    Response = Object.response
                };

                Recaptcha.RecaptchaResponse recaptchaResponse = captchaValidtor.Validate();
                ReturnObject rObj = new ReturnObject(recaptchaResponse.IsValid, recaptchaResponse.ErrorMessage, "");
                return rObj;
            }
            catch (Exception ex) {
                ReturnObject rObj = new ReturnObject(false, ex.Message, "");
                return rObj;
            }
        }
        public ReturnObject RegisterUser(UserRequest Object) {
            bool isExist = false;
            string message = "";
            try
            {
                User user = UserDAO.InsertUser(Object.email, Object.password, Object.office);
                if (user != null)
                {
                    string code = HttpUtility.UrlEncode(Convert.ToBase64String(GenericUtility.CreateSHAHash(user.VerificationCode)));
                    EmailUtility.SendVerifiyCodeEmail(Object.email, "عقاراتي - التحقق من الحساب", "http://94.236.98.81/Aqaraty/AccountVerification.aspx?userId=" + user.UserID + "&code=" + code);
                    message = "مسجل بنجاح - البريد الإلكتروني المرسلة للتحقق منها";
                    isExist = true;
                }
                else {
                    isExist = false;
                    message = "فشل تسجيل";
                }
                ReturnObject rObj = new ReturnObject(isExist, message, "");
                return rObj;
            }
            catch (Exception ex)
            {
                ReturnObject rObj = new ReturnObject(false, ex.Message, "");
                return rObj;
            }
        }
        public ReturnObject VerificationCodeEmail(UserRequest Object)
        {
            bool isExist = false;
            string message = "";
            try
            {
                User user = UserDAO.GetUserByID(Object.id);
                if (user != null)
                {
                    string code = HttpUtility.UrlEncode(Convert.ToBase64String(GenericUtility.CreateSHAHash(user.VerificationCode)));
                    EmailUtility.SendVerifiyCodeEmail(user.Email, "عقاراتي - التحقق من الحساب", "http://94.236.98.81/Aqaraty/AccountVerification.aspx?userId=" + user.UserID + "&code=" + code);
                    message = "مسجل بنجاح - البريد الإلكتروني المرسلة للتحقق منها";
                    isExist = true;
                }
                else
                {
                    isExist = false;
                    message = "فشل تسجيل";
                }
                ReturnObject rObj = new ReturnObject(isExist, message, "");
                return rObj;
            }
            catch (Exception ex)
            {
                ReturnObject rObj = new ReturnObject(false, ex.Message, "");
                return rObj;
            }
        }
    }
}
