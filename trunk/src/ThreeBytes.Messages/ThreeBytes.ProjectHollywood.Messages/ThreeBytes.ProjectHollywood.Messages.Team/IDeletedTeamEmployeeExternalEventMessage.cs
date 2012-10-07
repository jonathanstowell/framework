namespace ThreeBytes.ProjectHollywood.Messages.Team
{
    public interface IDeletedTeamEmployeeExternalEventMessage : ITeamEmployeeExternalEventBase
    {
        string DeletedBy { get; set; }
    }
}
