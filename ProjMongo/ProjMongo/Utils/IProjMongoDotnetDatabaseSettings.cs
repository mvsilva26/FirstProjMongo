namespace ProjMongo.Service
{
    public interface IProjMongoDotnetDatabaseSettings
    {
        string PersonCollectionName { get; set; }
        string AddressCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }


    }
}