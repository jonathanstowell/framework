using System;
using System.Collections.Generic;
using ThreeBytes.Core.Enum.Extensions;
using ThreeBytes.ProjectHollywood.Thespian.View.Entities;
using ThreeBytes.ProjectHollywood.Thespian.View.Entities.Enums;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Frontend.Models
{
    public class ThespianDetailsViewModel
    {
        private Gender gender { get; set; }
        private EyeColour eyeColour { get; set; }
        private HairLength hairLength { get; set; }
        private ThespianType thespianType { get; set; }

        public Guid Id { get; set; }
        public Guid ItemId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImageLocation { get; set; }
        public string ProfileThumbnailImageLocation { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public int? PlayingAge { get; set; }
        public string Summary { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Spotlight { get; set; }
        public string Imdb { get; set; }

        public string Gender
        {
            get
            {
                return gender.ToStringUsingConverter<Gender>();
            }
        }
        public string EyeColour
        {
            get
            {
                return eyeColour.ToStringUsingConverter<EyeColour>();
            }
        }
        public string HairLength
        {
            get
            {
                return hairLength.ToStringUsingConverter<HairLength>();
            }
        }
        public string ThespianType
        {
            get
            {
                return thespianType.ToStringUsingConverter<ThespianType>();
            }
        }

        public IList<ThespianViewThespian> History { get; set; }
        public string Operation { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public string LastModifiedBy { get; set; }

        public ThespianDetailsViewModel()
        {}

        public ThespianDetailsViewModel(ThespianViewThespian thespian)
        {
            gender = thespian.Gender;
            eyeColour = thespian.EyeColour;
            hairLength = thespian.HairLength;
            thespianType = thespian.ThespianType;

            Id = thespian.Id;
            ItemId = thespian.ItemId;

            FirstName = thespian.FirstName;
            LastName = thespian.LastName;
            ProfileImageLocation = thespian.ProfileImageLocation;
            ProfileThumbnailImageLocation = thespian.ProfileThumbnailImageLocation;
            DateOfBirth = thespian.DateOfBirth;
            Email = thespian.Email;
            Location = thespian.Location;
            Height = thespian.Height;
            Weight = thespian.Weight;
            PlayingAge = thespian.PlayingAge;
            Summary = thespian.Summary;
            Twitter = thespian.Twitter;
            Facebook = thespian.Facebook;
            Spotlight = thespian.Spotlight;
            Imdb = thespian.Imdb;

            History = thespian.History;

            CreationDateTime = thespian.CreationDateTime;
            CreatedBy = thespian.CreatedBy;
            LastModifiedDateTime = thespian.LastModifiedDateTime;
            LastModifiedBy = thespian.LastModifiedBy;
        }
    }
}
