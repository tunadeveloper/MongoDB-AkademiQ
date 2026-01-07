namespace MongoDB_AkademiQ.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ProductCollection { get; set; }
        public string CategoryCollection { get; set; }
    }
}
