using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Web;
using Aqaraty.Data.Utilities;

namespace Aqaraty.Data.DAO
{
    public static class UserDAO
    {
        public static User GetUserByEmail(string email) {
            User user = (from u in GenericDAO.DatabaseContext.Users where u.Email == email select u).FirstOrDefault();
            return user;
        }
        public static User GetUserByID(string userId)
        {
            User user = (from u in GenericDAO.DatabaseContext.Users where u.UserID == userId select u).FirstOrDefault();
            return user;
        }
        public static string GetUserIDByUNamePass(string usernameText, byte[] passwordText)
        {
            User user = (from u in GenericDAO.DatabaseContext.Users where (u.Email == usernameText) && (u.Password == passwordText) && (u.Verified==true) select u).FirstOrDefault();
            if (user != null)
            {
                return user.UserID;
            }
            return null;
        }
        public static User InsertUser(string email,string password,string office) {
            User user = new User
            {
                UserID=Guid.NewGuid().ToString(),
                Email = email,
                Password = GenericUtility.CreateSHAHash(password),
                CreationDate = DateTime.Now,
                VerificationCode = Guid.NewGuid().ToString(),
                OfficeName = office,
                Verified = false
            };
            GenericDAO.DatabaseContext.Users.AddObject(user);
            GenericDAO.DatabaseContext.SaveChanges();
            return user;
        }
        public static string InsertSession(string userId,bool remember,string clientip,string time) {
            DateTime endTime=DateTime.Now;
            if(remember){
                endTime=endTime.AddYears(1);
            }else{
                endTime=endTime.AddMinutes(Int32.Parse(time));
            }
            Session session = new Session {
                ID = Guid.NewGuid().ToString(),
                UserID = userId,
                StartTime=DateTime.Now,
                LastActivityTime=DateTime.Now,
                EndTime = endTime,
                IP = clientip

            };
            GenericDAO.DatabaseContext.Sessions.AddObject(session);
            GenericDAO.DatabaseContext.SaveChanges();
            return session.ID;
        }
        public static Session GetSessionByID(string sessionId)
        {
            Session session = (from s in GenericDAO.DatabaseContext.Sessions where s.ID == sessionId select s).FirstOrDefault();
            if (session != null && DateTime.Now.CompareTo(session.EndTime)>0) {
                return null;
            }
            return session;
        }
        public static bool GetUserVerifiedByIDnCode(string userId,string code,bool update) {
            User user = (from u in GenericDAO.DatabaseContext.Users where u.UserID == userId select u).FirstOrDefault();
            if (user != null) {
                string verfiyCode = HttpUtility.UrlEncode(Convert.ToBase64String(GenericUtility.CreateSHAHash(user.VerificationCode)));
                if (verfiyCode.Equals(HttpUtility.UrlEncode(code)))
                {
                    if (update)
                    {
                        user.Verified = true;
                        GenericDAO.DatabaseContext.SaveChanges();
                    }
                    else { 
                        
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        public static void UpdateUserPassword(User user,string password) {
            user.Password = GenericUtility.CreateSHAHash(password);
            GenericDAO.DatabaseContext.SaveChanges();
        }
        public static void DeleteSessionBySessionId(string sessionId) {
            Session session = (from s in GenericDAO.DatabaseContext.Sessions where s.ID == sessionId select s).FirstOrDefault();
            GenericDAO.DatabaseContext.Sessions.DeleteObject(session);
            GenericDAO.DatabaseContext.SaveChanges();
        }
    }
}
