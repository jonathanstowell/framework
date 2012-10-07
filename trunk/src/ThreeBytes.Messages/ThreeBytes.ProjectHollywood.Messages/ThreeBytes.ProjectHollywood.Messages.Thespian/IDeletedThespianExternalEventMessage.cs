namespace ThreeBytes.ProjectHollywood.Messages.Thespian
{
    public interface IDeletedThespianExternalEventMessage : IThespianExternalEventBase
    {
        string DeletedBy { get; set; }
    }
}
