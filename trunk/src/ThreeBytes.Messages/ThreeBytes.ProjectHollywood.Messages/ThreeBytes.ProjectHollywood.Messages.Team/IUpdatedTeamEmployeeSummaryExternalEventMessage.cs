namespace ThreeBytes.ProjectHollywood.Messages.Team
{
    public interface IUpdatedTeamEmployeeSummaryExternalEventMessage : ITeamEmployeeExternalEventBase
    {
        string NewSummary { get; set; }
        string UpdatedBy { get; set; }
    }
}
