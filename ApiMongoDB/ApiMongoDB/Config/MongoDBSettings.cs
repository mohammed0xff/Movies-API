namespace ApiMongoDB.Config
{
    public class MongoDBConfig
    {
        public string Database_Name { get; set; }
        public string Movies_Collection_Name { get; set; }
        public string Connection_String { get; set; } // Value is configured From user-secrets
        // To add yours:
        //              $ dotnet user-secrets set "Connection_String" "your connection string"
    }
}
