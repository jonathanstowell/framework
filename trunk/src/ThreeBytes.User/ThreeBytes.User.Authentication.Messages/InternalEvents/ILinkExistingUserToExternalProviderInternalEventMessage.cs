using ThreeBytes.User.Messages.ExternalEvents;

namespace ThreeBytes.User.Authentication.Messages.InternalEvents
{
    public interface ILinkExistingUserToExternalProviderInternalEventMessage : ILinkExistingUserToExternalProviderExternalEventMessage
    {
        string Token { get; set; }
        string TokenSecret { get; set; }
    }
}