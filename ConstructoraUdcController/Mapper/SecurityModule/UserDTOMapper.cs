using ConstructoraUdcController.DTO.SecurityModule;
using ConstructoraUdcModel.DbModel.SecurityModule;
using ConstructoraUdcModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdcController.Mappers.SecurityModule
{
    public class UserDTOMapper : GeneralMapper<UserDbModel, UserDTO>
    {
        public override UserDTO MapperT1T2(UserDbModel input)
        {
           
            RoleDTOMapper roleMapper = new RoleDTOMapper();
            return new UserDTO()
            {
                Id = input.Id,
                Name = input.Name,
                LastName = input.LastName,
                Document = input.Document,
                Phone = input.Phone,
                Email = input.Email,
                PasswordUser = input.PasswordUser,
                CityId = input.CityId,
                /*
                Removed = input.removed,
                RemovedDate = (DateTime)input.removed_date,
                CreateDate = (DateTime)input.create_date,
                RemovedUserId = (int)input.remove_user_id,
                CreateUserId = (int)input.create_user_id,
                UpdateUserId = (int)input.update_user_id,
                */
                Roles = roleMapper.MapperT1T2(input.Roles),
                Token = input.Token

            };
        }

        public override IEnumerable<UserDTO> MapperT1T2(IEnumerable<UserDbModel> input)
        {
            foreach(var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override UserDbModel MapperT2T1(UserDTO input)
        {
            return new UserDbModel()
            {
                Id = input.Id,
                Name = input.Name,
                LastName = input.LastName,
                Document = input.Document,
                Phone = input.Phone,
                Email = input.Email,
                PasswordUser = input.PasswordUser,
                CityId = input.CityId,
               
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

        public override IEnumerable<UserDbModel> MapperT2T1(IEnumerable<UserDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
