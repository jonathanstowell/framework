namespace ThreeBytes.Core.Twitter.Entities.Abstract
{
    public interface ITwitterUserProfile
    {
        string Identifier { get; set; }
        string Username { get; set; }
        string Token { get; set; }
        string TokenSecret { get; set; }
    }
}
