using System.Collections.Generic;
using NHibernate.Criterion;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.Thespian.List.Data.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.List.Data.Abstract.Infrastructure;
using ThreeBytes.ProjectHollywood.Thespian.List.Entities;
using ThreeBytes.ProjectHollywood.Thespian.List.Entities.Enums;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Data.Concrete
{
    public class ThespianListThespianRepository : KeyedGenericRepository<ThespianListThespian>, IThespianListThespianRepository
    {
        public ThespianListThespianRepository(IThespianListDatabaseFactory databaseFactory, IThespianListUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public IList<ThespianListThespian> GetAllThespiansOfType(ThespianType type)
        {
            return Session.QueryOver<ThespianListThespian>()
                .Where(x => x.ThespianType == type || x.ThespianType == ThespianType.ArtistCreative)
                .OrderBy(x => x.LastName).Asc
                .ThenBy(x => x.FirstName).Asc
                .List();
        }

        public IList<ThespianListThespian> GetAllThespiansOfTypeWithSurnameBetweenAK(ThespianType type)
        {
            return Session.QueryOver<ThespianListThespian>()
                .Where(x => x.ThespianType == type || x.ThespianType == ThespianType.ArtistCreative)
                .And(x => x.LastName.IsInsensitiveLike("a", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("b", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("c", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("d", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("e", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("f", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("g", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("h", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("i", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("j", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("k", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("l", MatchMode.Start))
                .OrderBy(x => x.LastName).Asc
                .ThenBy(x => x.FirstName).Asc
                .List();
        }

        public IList<ThespianListThespian> GetAllThespiansOfTypeWithSurnameBetweenLZ(ThespianType type)
        {
            return Session.QueryOver<ThespianListThespian>()
                .Where(x => x.ThespianType == type || x.ThespianType == ThespianType.ArtistCreative)
                .And(x => x.LastName.IsInsensitiveLike("l", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("m", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("n", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("o", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("p", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("q", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("r", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("s", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("t", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("u", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("v", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("w", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("x", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("y", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("z", MatchMode.Start))
                .OrderBy(x => x.LastName).Asc
                .ThenBy(x => x.FirstName).Asc
                .List();
        }

        public IList<ThespianListThespian> GetAllThespiansOfTypeOfGender(ThespianType type, Gender gender)
        {
            return Session.QueryOver<ThespianListThespian>()
                .Where(x => x.ThespianType == type || x.ThespianType == ThespianType.ArtistCreative)
                .And(x => x.Gender == gender)
                .OrderBy(x => x.LastName).Asc
                .ThenBy(x => x.FirstName).Asc
                .List();
        }

        public IList<ThespianListThespian> GetAllThespiansOfTypeOfGenderWithSurnameBetweenAK(ThespianType type, Gender gender)
        {
            return Session.QueryOver<ThespianListThespian>()
                .Where(x => x.ThespianType == type || x.ThespianType == ThespianType.ArtistCreative)
                .And(x => x.Gender == gender)
                .And(x => x.LastName.IsInsensitiveLike("a", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("b", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("c", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("d", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("e", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("f", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("g", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("h", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("i", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("j", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("k", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("l", MatchMode.Start))
                .OrderBy(x => x.LastName).Asc
                .ThenBy(x => x.FirstName).Asc
                .List();
        }

        public IList<ThespianListThespian> GetAllThespiansOfTypeOfGenderWithSurnameBetweenLZ(ThespianType type, Gender gender)
        {
            return Session.QueryOver<ThespianListThespian>()
                .Where(x => x.ThespianType == type || x.ThespianType == ThespianType.ArtistCreative)
                .And(x => x.Gender == gender)
                .And(x => x.LastName.IsInsensitiveLike("l", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("m", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("n", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("o", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("p", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("q", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("r", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("s", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("t", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("u", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("v", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("w", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("x", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("y", MatchMode.Start) ||
                    x.LastName.IsInsensitiveLike("z", MatchMode.Start))
                .OrderBy(x => x.LastName).Asc
                .ThenBy(x => x.FirstName).Asc
                .List();
        }
    }
}