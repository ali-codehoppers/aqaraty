using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.IO;
using Aqaraty.Web.Service.Object;

namespace Aqaraty.Web.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAqaratyService" in both code and config file together.
    [ServiceContract(Name = "Aqaraty.Service", Namespace = "")]
    public interface IAqaratyService
    {
        [WebInvoke(Method = "POST" , RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "IsEmailExist")]
        [OperationContract]
        ReturnObject IsEmailExist(UserRequest Object);
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "IsLoginUser")]
        [OperationContract]
        ReturnObject IsLoginUser(UserRequest Object);
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ForgotPassword")]
        [OperationContract]
        ReturnObject ForgotPassword(UserRequest Object);
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "CheckCaptcha")]
        [OperationContract]
        ReturnObject CheckCaptcha(UserRequest Object);
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "RegisterUser")]
        [OperationContract]
        ReturnObject RegisterUser(UserRequest Object);
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "VerificationCodeEmail")]
        [OperationContract]
        ReturnObject VerificationCodeEmail(UserRequest Object);
    }
}
