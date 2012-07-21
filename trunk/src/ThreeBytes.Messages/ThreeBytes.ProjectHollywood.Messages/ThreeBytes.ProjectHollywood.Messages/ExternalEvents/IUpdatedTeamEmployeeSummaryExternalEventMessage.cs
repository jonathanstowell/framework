namespace ThreeBytes.ProjectHollywood.Messages.ExternalEvents
{
    public interface IUpdatedTeamEmployeeSummaryExternalEventMessage : ITeamEmployeeExternalEventBase
    {
        string NewSummary { get; set; }
        string UpdatedBy { get; set; }
    }
}
