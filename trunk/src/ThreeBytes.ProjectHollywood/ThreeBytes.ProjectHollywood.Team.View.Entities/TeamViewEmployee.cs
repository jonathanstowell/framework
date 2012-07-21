using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.ProjectHollywood.Team.View.Entities
{
    [Serializable]
    public class TeamViewEmployee : HistoricBusinessObject<TeamViewEmployee>, IHistoricBusinessObject<TeamViewEmployee>
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string JobTitle { get; set; }
        public virtual string ProfileImageLocation { get; set; }
        public virtual string ProfileThumbnailImageLocation { get; set; }
        public virtual string Summary { get; set; }

        public TeamViewEmployee()
        {}

        public TeamViewEmployee(TeamViewEmployee employee)
        {
            ItemId = employee.ItemId;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            JobTitle = employee.JobTitle;
            Summary = employee.Summary;
            CreatedBy = employee.CreatedBy;
        }
    }
}
