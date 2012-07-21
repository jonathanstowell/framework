namespace ThreeBytes.Core.Foursquare.Entities.Abstract
{
    public interface IFoursquareUserProfile
    {
        string Identifier { get; set; }
        string FacebookIdentifier { get; set; }
        string Username { get; set; }
        string Forename { get; set; }
        string Surname { get; set; }
        string Email { get; set; }
        string Token { get; set; }
    }
}
