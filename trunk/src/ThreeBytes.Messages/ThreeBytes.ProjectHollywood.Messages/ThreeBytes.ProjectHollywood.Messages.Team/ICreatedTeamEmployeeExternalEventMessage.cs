namespace ThreeBytes.ProjectHollywood.Messages.Team
{
    public interface ICreatedTeamEmployeeExternalEventMessage : ITeamEmployeeExternalEventBase
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string JobTitle { get; set; }
        string Summary { get; set; }
        string CreatedBy { get; set; }
    }
}
