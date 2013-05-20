using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Aqaraty.Web.Service.Object
{
    [DataContract]
    public class ReturnObject
    {
        [DataMember]
        private bool IsError { set; get; }
        [DataMember]
        private string ErrorDescription { set; get; }
        [DataMember]
        private string Data { set; get; }

        public ReturnObject(bool IsError, string ErrorDescription, string Data)
        {
            this.IsError = IsError;
            this.ErrorDescription = ErrorDescription;
            this.Data = Data;
        }
    }
}