namespace ThreeBytes.ProjectHollywood.Messages.ExternalEvents
{
    public interface IDeletedTeamEmployeeExternalEventMessage : ITeamEmployeeExternalEventBase
    {
        string DeletedBy { get; set; }
    }
}
