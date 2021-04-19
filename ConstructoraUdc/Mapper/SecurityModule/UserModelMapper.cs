using ConstructoraUdc.Mapper.SecurityModule;
using ConstructoraUdc.Models.SecurityModule;
using ConstructoraUdcController.DTO.SecurityModule;
using ConstructoraUdcModel.DbModel.SecurityModule;
using ConstructoraUdcModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdc.Mappers.SecurityModule
{
    public class UserModelMapper : GeneralMapper<UserDTO, UserModel>
    {
        public override UserModel MapperT1T2(UserDTO input)
        {
           
            RoleModelMapper roleMapper = new RoleModelMapper();
            return new UserModel()
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

        public override IEnumerable<UserModel> MapperT1T2(IEnumerable<UserDTO> input)
        {
            foreach(var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override UserDTO MapperT2T1(UserModel input)
        {
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
                removed = input.Removed,
                removed_date = (DateTime)input.RemovedDate,
                create_date = (DateTime)input.CreateDate,
                remove_user_id = (int)input.RemovedUserId,
                create_user_id = (int)input.CreateUserId,
                update_user_id = (int)input.UpdateUserId
               */
            };
        }

        public override IEnumerable<UserDTO> MapperT2T1(IEnumerable<UserModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
