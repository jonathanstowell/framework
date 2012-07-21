namespace ThreeBytes.User.Messages.ExternalEvents
{
    public interface ICreatedRoleExternalEventMessage : IRoleExternalEventBase
    {
        string Name { get; set; }
    }
}
