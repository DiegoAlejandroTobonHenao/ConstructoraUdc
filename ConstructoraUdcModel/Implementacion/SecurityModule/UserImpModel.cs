using ConstructoraUdcModel.DbModel.SecurityModule;
using ConstructoraUdcModel.Mappers.SecurityModule;
using ConstructoraUdcModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdcModel.Implementacion.SecurityModule
{
    public class UserImpModel
    {

        
        public int RecordCreation(UserDbModel dbModel)
        {
            ///<summary>
            ///Se agrega un registro a Users
            ///</summary>
            ///<param name = "DbModel">Representa un objeto con la informacion Rol
            ///</param>
            ///<returns>Entero con la Respuesta: 1. Ok , 2. Ko, 3, Ya existe</returns>
            using (RoleImpController db = new RoleImpController() )
            {
                try
                {
                    UserModelMapper mapper = new UserModelMapper();
                    SEC_User record = mapper.MapperT2T1(dbModel);

                    record.create_date = dbModel.CurrentDate;
                    record.create_user_id = dbModel.UserInSession;
                    db.SEC_User.Add(record);
                    db.SaveChanges();

                    return 1;
                }
                catch 
                {
                    return 2;

                }
            }
            
        }

        public int RecordUpdate(UserDbModel dbModel)
        {
            using (RoleImpController db = new RoleImpController())
            {
                try
                {
                    var record = db.SEC_User.Where(x => x.id == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    record.name = dbModel.Name;
                    record.last_name = dbModel.LastName;
                    record.document = dbModel.Document;
                    record.phone = dbModel.Phone;
                    record.email = dbModel.Email;
                    record.password_user = dbModel.PasswordUser;
                    record.city_id = dbModel.CityId;
                    record.update_user_id = dbModel.UserInSession;
                    record.update_date = dbModel.CurrentDate;
                    /*
                    record.removed = dbModel.Removed;
                    record.removed_date = (DateTime)dbModel.RemovedDate;
                    record.create_date = (DateTime)dbModel.CreateDate;
                    record.remove_user_id = (int)dbModel.RemovedUserId;
                    record.create_user_id = (int)dbModel.CreateUserId;
                    record.update_user_id = (int)dbModel.UpdateUserId;
                    */

                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public int RecordRemove(UserDbModel dbModel)
        {
            using (RoleImpController db = new RoleImpController())
            {
                try
                {
                    var record = db.SEC_User.Where(x => x.id == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }

                    //db.SEC_User.Remove(record);
                    record.removed = true;
                    record.removed_date = dbModel.CurrentDate;
                    record.remove_user_id = dbModel.UserInSession;
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public IEnumerable<UserDbModel> RecordList(string filter)
        { 
             using (RoleImpController db = new RoleImpController())
              {
                    var listaLinq = from User in db.SEC_User
                                    where !User.removed && User.name.ToUpper().Contains(filter.ToUpper())
                                    select User;
                    UserModelMapper mapper = new UserModelMapper();
                    var listaFinal = mapper.MapperT1T2(listaLinq);
                    return listaFinal;
              }
         }
        public int ChangePassword(string currentPassword, string newPassword, int userId, out string email)
        {
            email = string.Empty;
            using (RoleImpController db = new RoleImpController())
            {
                try
                {
                    var user = db.SEC_User.Where(x => x.id == userId && x.password_user.Equals(currentPassword)).FirstOrDefault();
                    if (user == null)
                    {
                        return 3;
                    }
                    user.password_user = newPassword;
                    db.SaveChanges();
                    email = user.email;
                    return 1;
                }
                catch
                {
                    return 2;
                }

            }
        }
        public int PasswordReset(string email, string newPassword)
        {
            
            using (RoleImpController db = new RoleImpController())
            {
                try
                {
                    var user = db.SEC_User.Where(x => x.email.Equals(email)).FirstOrDefault();
                    if (user == null)
                    {
                        return 3;
                    }
                    user.password_user = newPassword;
                    db.SaveChanges();
                    email = user.email;
                    return 1;
                }catch
                {
                    return 2;
                }
                
            }
        }

        public UserDbModel Login(UserDbModel dbModel)
        {
            using (RoleImpController db = new RoleImpController())
            {
                var login = (from user in db.SEC_User
                            where user.email.ToUpper().Equals(dbModel.Email.ToUpper()) && user.password_user.Equals(dbModel.PasswordUser)
                            select user).FirstOrDefault();

                if(login == null)
                {
                    return null;
                }
                var date = dbModel.CurrentDate;
                SEC_Session session = new SEC_Session()
                {
                    user_id = login.id,
                    login_date = date,
                    token_status = true,
                    token = this.GetToken(string.Concat(login.id, date)),
                    ip_adress = this.GetIpAdress()
                };
                db.SEC_Session.Add(session);
                db.SaveChanges();
                UserModelMapper mapper = new UserModelMapper();
                return mapper.MapperT1T2(login);
            }
                
        }

        private string GetToken(string key)
        {
            int HashCode = key.GetHashCode();
            return HashCode.ToString();
        }

        private string GetIpAdress()
        {
            string hostName = Dns.GetHostName();
            Console.WriteLine(hostName);
            // get the ip
            string myIp = Dns.GetHostEntry(hostName).AddressList[0].ToString();
            return myIp;
        }



    }


}
