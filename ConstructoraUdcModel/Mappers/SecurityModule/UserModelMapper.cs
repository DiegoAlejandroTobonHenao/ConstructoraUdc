using ConstructoraUdcModel.DbModel.SecurityModule;
using ConstructoraUdcModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdcModel.Mappers.SecurityModule
{
    class UserModelMapper : GeneralMapper<SEC_User, UserDbModel>
    {
        public override UserDbModel MapperT1T2(SEC_User input)
        {
            var roles = input.SEC_User_Role.Select(x => x.SEC_Role);
            RoleModelMapper roleMapper = new RoleModelMapper();
            return new UserDbModel()
            {
                Id = input.id,
                Name = input.name,
                LastName = input.last_name,
                Document = input.document,
                Phone = input.phone,
                Email = input.email,
                PasswordUser = input.password_user,
                CityId = input.city_id,
                /*
                Removed = input.removed,
                RemovedDate = (DateTime)input.removed_date,
                CreateDate = (DateTime)input.create_date,
                RemovedUserId = (int)input.remove_user_id,
                CreateUserId = (int)input.create_user_id,
                UpdateUserId = (int)input.update_user_id,
                */
                Roles = roleMapper.MapperT1T2(roles)
            };
        }

        public override IEnumerable<UserDbModel> MapperT1T2(IEnumerable<SEC_User> input)
        {
            foreach(var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override SEC_User MapperT2T1(UserDbModel input)
        {
            return new SEC_User()
            {
                id = input.Id,
                name = input.Name,
                last_name = input.LastName,
                document = input.Document,
                phone = input.Phone,
                email = input.Email,
                password_user = input.PasswordUser,
                city_id = input.CityId,
               
               /*
                removed = input.Removed,
                removed_date = (DateTime)input.RemovedDate,
                create_date = (DateTime)input.CreateDate,
                remove_user_id = (int)input.RemovedUserId,
                create_user_id = (int)input.CreateUserId,
                update_user_id = (int)input.UpdateUserId
               */
            };
        }

        public override IEnumerable<SEC_User> MapperT2T1(IEnumerable<UserDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
