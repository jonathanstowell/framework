using System.Collections.Generic;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.List.Entities;
using ThreeBytes.ProjectHollywood.Thespian.List.Entities.Enums;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Service.Abstract
{
    public interface IThespianListThespianService : IKeyedGenericService<ThespianListThespian>
    {
        IList<ThespianListThespian> GetAllThespiansOfType(ThespianType type);
        IList<ThespianListThespian> GetAllThespiansOfTypeWithSurnameBetweenAK(ThespianType type);
        IList<ThespianListThespian> GetAllThespiansOfTypeWithSurnameBetweenLZ(ThespianType type);
        IList<ThespianListThespian> GetAllThespiansOfTypeOfGender(ThespianType type, Gender gender);
        IList<ThespianListThespian> GetAllThespiansOfTypeOfGenderWithSurnameBetweenAK(ThespianType type, Gender gender);
        IList<ThespianListThespian> GetAllThespiansOfTypeOfGenderWithSurnameBetweenLZ(ThespianType type, Gender gender);
    }
}
