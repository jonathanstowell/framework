using System;
using System.Collections.Generic;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.ProjectHollywood.Thespian.List.Data.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.List.Entities;
using ThreeBytes.ProjectHollywood.Thespian.List.Entities.Enums;
using ThreeBytes.ProjectHollywood.Thespian.List.Service.Abstract;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Service.Concrete
{
    public class ThespianListThespianService : KeyedGenericService<ThespianListThespian>, IThespianListThespianService
    {
        protected new readonly IThespianListThespianRepository Repository;

        public ThespianListThespianService(IThespianListThespianRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public IList<ThespianListThespian> GetAllThespiansOfType(ThespianType type)
        {
            return Repository.GetAllThespiansOfType(type);
        }

        public IList<ThespianListThespian> GetAllThespiansOfTypeWithSurnameBetweenAK(ThespianType type)
        {
            return Repository.GetAllThespiansOfTypeWithSurnameBetweenAK(type);
        }

        public IList<ThespianListThespian> GetAllThespiansOfTypeWithSurnameBetweenLZ(ThespianType type)
        {
            return Repository.GetAllThespiansOfTypeWithSurnameBetweenLZ(type);
        }

        public IList<ThespianListThespian> GetAllThespiansOfTypeOfGender(ThespianType type, Gender gender)
        {
            return Repository.GetAllThespiansOfTypeOfGender(type, gender);
        }

        public IList<ThespianListThespian> GetAllThespiansOfTypeOfGenderWithSurnameBetweenAK(ThespianType type, Gender gender)
        {
            return Repository.GetAllThespiansOfTypeOfGenderWithSurnameBetweenAK(type, gender);
        }

        public IList<ThespianListThespian> GetAllThespiansOfTypeOfGenderWithSurnameBetweenLZ(ThespianType type, Gender gender)
        {
            return Repository.GetAllThespiansOfTypeOfGenderWithSurnameBetweenLZ(type, gender);
        }
    }
}
