namespace ThreeBytes.User.Authentication.Messages.InternalEvents
{
    public interface IResetPasswordConfirmedInternalEventMessage : IAuthenticationUserEventBase
    {
        string Username { get; set; }
        string Email { get; set; }
        string NewPassword { get; set; }
        string NewConfirmPassword { get; set; }
    }
}
