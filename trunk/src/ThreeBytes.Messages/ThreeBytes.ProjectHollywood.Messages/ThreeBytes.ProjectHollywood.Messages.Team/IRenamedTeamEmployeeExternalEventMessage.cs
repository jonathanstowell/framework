namespace ThreeBytes.ProjectHollywood.Messages.Team
{
    public interface IRenamedTeamEmployeeExternalEventMessage : ITeamEmployeeExternalEventBase
    {
        string NewFirstName { get; set; }
        string NewLastName { get; set; }
        string RenamedBy { get; set; }
    }
}
