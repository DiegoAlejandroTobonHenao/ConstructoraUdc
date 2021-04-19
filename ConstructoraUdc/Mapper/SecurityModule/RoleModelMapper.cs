using ConstructoraUdcController.DTO.SecurityModule;
using ConstructoraUdcModel.DbModel.SecurityModule;
using ConstructoraUdcModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstructoraUdc.Models.SecurityModule;
using ConstructoraUdc.Mappers;

namespace ConstructoraUdc.Mapper.SecurityModule
{
    public class RoleModelMapper : GeneralMapper<RoleDTO, RoleModel>
    {
        public override RoleModel MapperT1T2(RoleDTO input)
        {
            return new RoleModel()
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                Removed = input.Removed
            };
        }

        public override IEnumerable<RoleModel> MapperT1T2(IEnumerable<RoleDTO> input)
        {
            foreach(var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override RoleDTO MapperT2T1(RoleModel input)
        {
            return new RoleDTO()
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                Removed = input.Removed
            };
        }

        public override IEnumerable<RoleDTO> MapperT2T1(IEnumerable<RoleModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
