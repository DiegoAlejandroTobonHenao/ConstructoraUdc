using ConstructoraUdcModel.DbModel.SecurityModule;
using ConstructoraUdcModel.Mappers.SecurityModule;
using ConstructoraUdcModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
            using (ConstructoraUdcDBEntities db = new ConstructoraUdcDBEntities() )
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
            using (ConstructoraUdcDBEntities db = new ConstructoraUdcDBEntities())
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
            using (ConstructoraUdcDBEntities db = new ConstructoraUdcDBEntities())
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
             using (ConstructoraUdcDBEntities db = new ConstructoraUdcDBEntities())
              {
                    var listaLinq = from User in db.SEC_User
                                    where !User.removed && User.name.ToUpper().Contains(filter.ToUpper())
                                    select User;
                    UserModelMapper mapper = new UserModelMapper();
                    var listaFinal = mapper.MapperT1T2(listaLinq);
                    return listaFinal;
              }
         }

    }


}
