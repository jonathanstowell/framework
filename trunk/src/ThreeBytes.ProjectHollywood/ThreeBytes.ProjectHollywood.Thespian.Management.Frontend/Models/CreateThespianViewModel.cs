using ThreeBytes.ProjectHollywood.Thespian.Management.Entities;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Frontend.Models
{
    public class CreateThespianViewModel
    {
        public ThespianManagementThespian Thespian { get; set; }

        public CreateThespianViewModel()
        {
            Thespian = new ThespianManagementThespian();
        }
    }
}
