using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Security.Utilities.Abstract;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.ProjectHollywood.Team.Management.Entities;
using ThreeBytes.ProjectHollywood.Team.Management.Frontend.PreCommands;
using ThreeBytes.ProjectHollywood.Team.Management.Service.Abstract;
using ThreeBytes.SignalR.CurrentlyViewing.Entities.Abstract;
using ThreeBytes.SignalR.CurrentlyViewing.Service.Abstract;

namespace ThreeBytes.ProjectHollywood.Team.Management.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "TeamManager" })]
    public class TeamManagementController : StatelessSessionController
    {
        private readonly ITeamManagementEmployeeService service;
        private readonly IProvideCurrentUserDetails currentUserDetails;
        private readonly ICurrentlyViewingUserService currentlyViewingUserService;

        private readonly Func<CreateTeamEmployeePreCommand> createTeamEmployeePreCommandAccessor;
        private readonly Func<DeleteTeamEmployeePreCommand> deleteTeamEmployeePreCommandAccessor;
        private readonly Func<RenameTeamEmployeePreCommand> renameTeamEmployeePreCommandAccessor;
        private readonly Func<RenameJobTitlePreCommand> renameJobTitlePreCommandAccessor;
        private readonly Func<UpdateSummaryPreCommand> updateSummaryPreCommandAccessor;
        private readonly Func<UpdateTeamEmployeeProfileImagePreCommand> updateTeamEmployeeProfileImagePreCommandAccessor;

        public TeamManagementController(ITeamManagementEmployeeService service, Func<CreateTeamEmployeePreCommand> createTeamEmployeePreCommandAccessor, Func<DeleteTeamEmployeePreCommand> deleteTeamEmployeePreCommandAccessor, Func<RenameTeamEmployeePreCommand> renameTeamEmployeePreCommandAccessor, Func<RenameJobTitlePreCommand> renameJobTitlePreCommandAccessor, Func<UpdateSummaryPreCommand> updateSummaryPreCommandAccessor, ICurrentlyViewingUserService currentlyViewingUserService, IProvideCurrentUserDetails currentUserDetails, Func<UpdateTeamEmployeeProfileImagePreCommand> updateTeamEmployeeProfileImagePreCommandAccessor)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;

            this.createTeamEmployeePreCommandAccessor = createTeamEmployeePreCommandAccessor;
            this.deleteTeamEmployeePreCommandAccessor = deleteTeamEmployeePreCommandAccessor;
            this.renameTeamEmployeePreCommandAccessor = renameTeamEmployeePreCommandAccessor;
            this.renameJobTitlePreCommandAccessor = renameJobTitlePreCommandAccessor;
            this.updateSummaryPreCommandAccessor = updateSummaryPreCommandAccessor;
            this.currentlyViewingUserService = currentlyViewingUserService;
            this.currentUserDetails = currentUserDetails;
            this.updateTeamEmployeeProfileImagePreCommandAccessor = updateTeamEmployeeProfileImagePreCommandAccessor;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(TeamManagementEmployee employee)
        {
            var createTeamEmployeePreCommand = createTeamEmployeePreCommandAccessor();

            createTeamEmployeePreCommand.FirstName = employee.FirstName;
            createTeamEmployeePreCommand.LastName = employee.LastName;
            createTeamEmployeePreCommand.JobTitle = employee.JobTitle;
            createTeamEmployeePreCommand.ProfileImageLocation = employee.ProfileImageLocation;
            createTeamEmployeePreCommand.ProfileThumbnailImageLocation = employee.ProfileThumbnailImageLocation;
            createTeamEmployeePreCommand.Summary = employee.Summary;
            createTeamEmployeePreCommand.CreatedBy = currentUserDetails.Username;

            createTeamEmployeePreCommand.Execute();

            return Json(createTeamEmployeePreCommand.Results);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Rename(Guid id, string firstName, string lastName)
        {
            var renameTeamEmployeePreCommand = renameTeamEmployeePreCommandAccessor();

            renameTeamEmployeePreCommand.Id = id;
            renameTeamEmployeePreCommand.NewFirstName = firstName;
            renameTeamEmployeePreCommand.NewLastName = lastName;
            renameTeamEmployeePreCommand.RenamedBy = currentUserDetails.Username;

            renameTeamEmployeePreCommand.Execute();

            return Json(renameTeamEmployeePreCommand.Results);
        }

        [HttpPost]
        public ActionResult RenameJobTitle(Guid id, string jobTitle)
        {
            var renameJobTitlePreCommand = renameJobTitlePreCommandAccessor();

            renameJobTitlePreCommand.Id = id;
            renameJobTitlePreCommand.NewJobTitle = jobTitle;
            renameJobTitlePreCommand.RenamedBy = currentUserDetails.Username;

            renameJobTitlePreCommand.Execute();

            return Json(renameJobTitlePreCommand.Results);
        }

        [HttpPost]
        public ActionResult UpdateSummary(Guid id, string summary)
        {
            var updateSummaryPreCommand = updateSummaryPreCommandAccessor();

            updateSummaryPreCommand.Id = id;
            updateSummaryPreCommand.NewSummary = summary;
            updateSummaryPreCommand.UpdatedBy = currentUserDetails.Username;

            updateSummaryPreCommand.Execute();

            return Json(updateSummaryPreCommand.Results);
        }

        [HttpPost]
        public ActionResult UpdateProfileImage(Guid id, string profileImageLocation, string profileThumbnailImageLocation)
        {
            var updateTeamEmployeeProfileImagePreCommand = updateTeamEmployeeProfileImagePreCommandAccessor();

            updateTeamEmployeeProfileImagePreCommand.Id = id;
            updateTeamEmployeeProfileImagePreCommand.NewProfileImageLocation = profileImageLocation;
            updateTeamEmployeeProfileImagePreCommand.NewProfileThumbnailImageLocation = profileThumbnailImageLocation;
            updateTeamEmployeeProfileImagePreCommand.UpdatedBy = currentUserDetails.Username;

            updateTeamEmployeeProfileImagePreCommand.Execute();

            return Json(updateTeamEmployeeProfileImagePreCommand.Results);
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            var deleteTeamEmployeePreCommand = deleteTeamEmployeePreCommandAccessor();

            deleteTeamEmployeePreCommand.Id = id;
            deleteTeamEmployeePreCommand.DeletedBy = currentUserDetails.Username;
            deleteTeamEmployeePreCommand.Execute();

            return Json(deleteTeamEmployeePreCommand.Results);
        }

        [HttpGet]
        public ActionResult GetTeamEmployeeForUpdateOrDelete(Guid id)
        {
            TeamManagementEmployee employee = service.GetById(id);
            IList<ICurrentlyViewingUser> currentlyViewingUsers = currentlyViewingUserService.GetCurrentlyViewingUsers<TeamManagementEmployee>(id);
            return Json(new { Employee = employee, CurrentlyViewingUsers = currentlyViewingUsers }, JsonRequestBehavior.AllowGet);
        }
    }
}
