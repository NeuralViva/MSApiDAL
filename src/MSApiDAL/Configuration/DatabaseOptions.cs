namespace MSApiDAL.Configuration
{
    public class DatabaseOptions
    {
        public string EFConnectionString { get; set; }
        public string MongoConnectionString { get; set; }
        public string MongoDatabaseName { get; set; }
        public string MongoCollectionName { get; set; }
        public bool UseEF { get; set; }
    }
}
