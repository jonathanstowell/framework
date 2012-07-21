namespace ThreeBytes.Core.Email.Abstract
{
    public interface IEmailMessage
    {
        string Subject { get; set; }
        string Body { get; set; }
        string From { get; set; }
        string To { get; set; }
        bool IsHtml { get; set; }
    }
}
