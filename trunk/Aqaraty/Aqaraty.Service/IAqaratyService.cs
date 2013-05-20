using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.IO;
using Aqaraty.Service.Object;

namespace Aqaraty.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAqaratyService" in both code and config file together.
    [ServiceContract(Name = "Aqaraty.Service", Namespace = "")]
    public interface IAqaratyService
    {
        [WebInvoke(Method = "POST" , RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "IsEmailExist")]
        [OperationContract]
        ReturnObject IsEmailExist(UserRequest Object);
    }
}
