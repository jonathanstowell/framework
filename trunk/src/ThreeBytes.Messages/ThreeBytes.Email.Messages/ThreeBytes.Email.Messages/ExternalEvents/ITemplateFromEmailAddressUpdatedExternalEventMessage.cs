namespace ThreeBytes.Email.Messages.ExternalEvents
{
    public interface ITemplateFromEmailAddressUpdatedExternalEventMessage : ITemplateBaseExternalEventMessage
    {
        string From { get; set; }
    }
}
