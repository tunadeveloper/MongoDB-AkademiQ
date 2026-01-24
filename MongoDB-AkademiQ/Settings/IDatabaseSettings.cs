namespace MongoDB_AkademiQ.Settings;

public interface IDatabaseSettings
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
    public string ProductCollection { get; set; }
    public string CategoryCollection { get; set; }
    public string NewsletterCollection { get; set; }
    public string FAQCollection { get; set; }
    public string ContactInfoCollection { get; set; }
    public string MessageCollection { get; set; }
    public string TeamCollection { get; set; }
    public string AboutCollection { get; set; }
    public string AdminCollection { get; set; }
    public string ReferenceCollection { get; set; }
}