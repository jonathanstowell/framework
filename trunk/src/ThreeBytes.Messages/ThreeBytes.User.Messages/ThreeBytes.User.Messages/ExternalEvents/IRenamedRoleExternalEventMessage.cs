namespace ThreeBytes.User.Messages.ExternalEvents
{
    public interface IRenamedRoleExternalEventMessage : IRoleExternalEventBase
    {
        string NewName { get; set; }
    }
}
