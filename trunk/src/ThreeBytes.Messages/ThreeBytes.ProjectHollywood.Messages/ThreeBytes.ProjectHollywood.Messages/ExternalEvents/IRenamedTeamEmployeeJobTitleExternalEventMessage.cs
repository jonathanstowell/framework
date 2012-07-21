namespace ThreeBytes.ProjectHollywood.Messages.ExternalEvents
{
    public interface IRenamedTeamEmployeeJobTitleExternalEventMessage : ITeamEmployeeExternalEventBase
    {
        string NewJobTitle { get; set; }
        string RenamedBy { get; set; }
    }
}
