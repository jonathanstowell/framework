namespace ThreeBytes.ProjectHollywood.Messages.Team
{
    public interface IRenamedTeamEmployeeJobTitleExternalEventMessage : ITeamEmployeeExternalEventBase
    {
        string NewJobTitle { get; set; }
        string RenamedBy { get; set; }
    }
}
