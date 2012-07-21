using ThreeBytes.Core.Foursquare.Entities.Abstract;

namespace ThreeBytes.Core.Foursquare.Entities.Concrete
{
    public class FoursquareUserProfile : IFoursquareUserProfile
    {
        public string Identifier { get; set; }
        public string FacebookIdentifier { get; set; }
        public string Username { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
