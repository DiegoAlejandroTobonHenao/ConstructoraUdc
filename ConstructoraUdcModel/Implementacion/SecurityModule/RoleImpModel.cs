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
    public class RoleImpModel
    {

        
        public int RecordCreation(RoleDbModel dbModel)
        {
            ///<summary>
            ///Se agrega un registro a roles
            ///</summary>
            ///<param name = "DbModel">Representa un objeto con la informacion Rol
            ///</param>
            ///<returns>Entero con la Respuesta: 1. Ok , 2. Ko, 3, Ya existe</returns>
            using (ConstructoraUdcDBEntities db = new ConstructoraUdcDBEntities() )
            {
                try
                {
                  
                    if(db.SEC_Role.Where(x => x.name.ToUpper().Equals(dbModel.Name.ToUpper())).Count() > 0)
                    {
                        return 3;
                    }
                    RoleModelMapper mapper = new RoleModelMapper();
                    SEC_Role record = mapper.MapperT2T1(dbModel);

                    db.SEC_Role.Add(record);
                    db.SaveChanges();

                    return 1;
                }
                catch(Exception e)
                {
                    return 2;

                }
            }
            
        }

        public int RecordUpdate(RoleDbModel dbModel)
        {
            using (ConstructoraUdcDBEntities db = new ConstructoraUdcDBEntities())
            {
                try
                {
                    var record = db.SEC_Role.Where(x => x.id == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }

                    record.name = dbModel.Name;
                    record.removed = dbModel.Removed;

                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public int RecordRemove(RoleDbModel dbModel)
        {
            using (ConstructoraUdcDBEntities db = new ConstructoraUdcDBEntities())
            {
                try
                {
                    var record = db.SEC_Role.Where(x => x.id == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }

                    db.SEC_Role.Remove(record);

                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public IEnumerable<RoleDbModel> RecordList(string filter)
        { 
             using (ConstructoraUdcDBEntities db = new ConstructoraUdcDBEntities())
              {
                    var listaLinq = from role in db.SEC_Role
                                    where !role.removed && role.name.ToUpper().Contains(filter.ToUpper())
                                    select role;
                    RoleModelMapper mapper = new RoleModelMapper();
                    var listaFinal = mapper.MapperT1T2(listaLinq);
                    return listaFinal;
              }
         }

    }


}
