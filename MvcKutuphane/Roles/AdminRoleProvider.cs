using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Roles
{
    //Rollerle ilgil işlemler için class içinde RoleProvider'dan miras alıp  rolleri ayarladım
    public class AdminRoleProvider : RoleProvider
    {

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
        //kullanıcı yetkisini çekme  (Alma)
        public override string[] GetRolesForUser(string username)
        {
            DbMvcKutuphaneEntities1 db=new DbMvcKutuphaneEntities1();
            var sorgu = db.Admin.FirstOrDefault(p => p.Kulladi == username);
            return new string[] { sorgu.Yetki};
        }

        public override string[] GetUsersInRole(string roleName)
        {

            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}