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
using Aqaraty.Service.Object;
using System.Web;

namespace Aqaraty.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AqaratyService" in code, svc and config file together.
    public class AqaratyService : IAqaratyService
    {
        public ReturnObject IsEmailExist(UserRequest Object)
        {
            bool isExist = false;
            if(UserDAO.GetUserByEmail(Object.email)!=null){
                isExist=true;
            }
            ReturnObject rObj = new ReturnObject(isExist,"Email Existence", "");
            return rObj;
        }
    }
}
