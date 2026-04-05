namespace Kemkas.Web.Config;

public class MailgunOptions
{
    public const string Section = "Email";

    public string ApiKey { get; set; } = string.Empty;
    
    public string DomainName { get; set; } = string.Empty;
}