namespace ThreeBytes.Core.Facebook.Entities.Abstract
{
    public interface IFacebookUserProfile
    {
        string Identifier { get; set; }
        string Username { get; set; }
        string Email { get; set; }
        string Token { get; set; }
    }
}
