using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Security.Utilities.Abstract;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.ProjectHollywood.Thespian.Management.Entities;
using ThreeBytes.ProjectHollywood.Thespian.Management.Frontend.Command;
using ThreeBytes.ProjectHollywood.Thespian.Management.Frontend.PreCommands;
using ThreeBytes.ProjectHollywood.Thespian.Management.Service.Abstract;
using ThreeBytes.SignalR.CurrentlyViewing.Entities.Abstract;
using ThreeBytes.SignalR.CurrentlyViewing.Service.Abstract;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "ThespianManager" })]
    public class ThespianManagementController : StatelessSessionController
    {
        private readonly IThespianManagementThespianService service;
        private readonly IProvideCurrentUserDetails currentUserDetails;
        private readonly ICurrentlyViewingUserService currentlyViewingUserService;

        private readonly Func<CreateThespianPreCommand> createActorPreCommandAccessor;
        private readonly Func<DeleteThespianPreCommand> deletedActorPreCommandAccessor;
        private readonly Func<RenameThespianPreCommand> renameThespianPreCommandAccessor;
        private readonly Func<UpdateThespianProfileImagePreCommand> updateThespianProfileImagePreCommandAccessor;
        private Func<PersistImageCommand> persistImageCommandAccessor;

        public ThespianManagementController(IThespianManagementThespianService service, Func<CreateThespianPreCommand> createActorPreCommandAccessor, Func<DeleteThespianPreCommand> deletedActorPreCommandAccessor, Func<RenameThespianPreCommand> renameThespianPreCommandAccessor, ICurrentlyViewingUserService currentlyViewingUserService, IProvideCurrentUserDetails currentUserDetails , Func<PersistImageCommand> persistImageCommandAccessor, Func<UpdateThespianProfileImagePreCommand> updateThespianProfileImagePreCommandAccessor)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
            this.createActorPreCommandAccessor = createActorPreCommandAccessor;
            this.deletedActorPreCommandAccessor = deletedActorPreCommandAccessor;
            this.renameThespianPreCommandAccessor = renameThespianPreCommandAccessor;
            this.currentlyViewingUserService = currentlyViewingUserService;
            this.currentUserDetails = currentUserDetails;
            this.persistImageCommandAccessor = persistImageCommandAccessor;
            this.updateThespianProfileImagePreCommandAccessor = updateThespianProfileImagePreCommandAccessor;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(ThespianManagementThespian thespian)
        {
            var createActorPreCommand = createActorPreCommandAccessor();

            createActorPreCommand.FirstName = thespian.FirstName;
            createActorPreCommand.LastName = thespian.LastName;
            createActorPreCommand.ProfileImageLocation = thespian.ProfileImageLocation;
            createActorPreCommand.ProfileThumbnailImageLocation = thespian.ProfileThumbnailImageLocation;
            createActorPreCommand.Email = thespian.Email;
            createActorPreCommand.DateOfBirth = thespian.DateOfBirth;
            createActorPreCommand.Gender = thespian.Gender;
            createActorPreCommand.Location = thespian.Location;
            createActorPreCommand.Height = thespian.Height;
            createActorPreCommand.Weight = thespian.Weight;
            createActorPreCommand.PlayingAge = thespian.PlayingAge;
            createActorPreCommand.EyeColour = thespian.EyeColour;
            createActorPreCommand.HairLength = thespian.HairLength;
            createActorPreCommand.Summary = thespian.Summary;
            createActorPreCommand.Twitter = thespian.Twitter;
            createActorPreCommand.Facebook = thespian.Facebook;
            createActorPreCommand.Spotlight = thespian.Spotlight;
            createActorPreCommand.Imdb = thespian.Imdb;
            createActorPreCommand.ThespianType = thespian.ThespianType;
            createActorPreCommand.CreatedBy = currentUserDetails.Username;

            createActorPreCommand.Execute();

            return Json(createActorPreCommand.Results);
        }
        
        [HttpGet]
        public ActionResult Edit()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Rename(Guid id, string firstName, string lastName)
        {
            var renameThespianPreCommand = renameThespianPreCommandAccessor();

            renameThespianPreCommand.Id = id;
            renameThespianPreCommand.FirstName = firstName;
            renameThespianPreCommand.LastName = lastName;
            renameThespianPreCommand.RenamedBy = currentUserDetails.Username;

            renameThespianPreCommand.Execute();

            return Json(renameThespianPreCommand.Results);
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            var deletedActorPreCommand = deletedActorPreCommandAccessor();

            deletedActorPreCommand.Id = id;
            deletedActorPreCommand.DeletedBy = currentUserDetails.Username;
            deletedActorPreCommand.Execute();

            return Json(deletedActorPreCommand.Results);
        }

        [HttpPost]
        public ActionResult UpdateProfileImage(Guid id, string profileImageLocation, string profileThumbnailImageLocation)
        {
            var updateThespianEmployeeProfileImagePreCommand = updateThespianProfileImagePreCommandAccessor();

            updateThespianEmployeeProfileImagePreCommand.Id = id;
            updateThespianEmployeeProfileImagePreCommand.NewProfileImageLocation = profileImageLocation;
            updateThespianEmployeeProfileImagePreCommand.NewProfileThumbnailImageLocation = profileThumbnailImageLocation;
            updateThespianEmployeeProfileImagePreCommand.UpdatedBy = currentUserDetails.Username;

            updateThespianEmployeeProfileImagePreCommand.Execute();

            return Json(updateThespianEmployeeProfileImagePreCommand.Results);
        }

        [HttpGet]
        public ActionResult GetThespianForUpdateOrDelete(Guid id)
        {
            ThespianManagementThespian thespian = service.GetById(id);
            IList<ICurrentlyViewingUser> currentlyViewingUsers = currentlyViewingUserService.GetCurrentlyViewingUsers<ThespianManagementThespian>(id);
            return Json(new { Thespian = thespian, CurrentlyViewingUsers = currentlyViewingUsers }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ThespianProfileImage()
        {
            var cmd = persistImageCommandAccessor();

            cmd.Image = Request.Files[0];
            cmd.Execute();

            return Json(new { Result = cmd.Results, cmd.Identifier, cmd.Filename, cmd.ThumbnailName });
        }
    }
}
