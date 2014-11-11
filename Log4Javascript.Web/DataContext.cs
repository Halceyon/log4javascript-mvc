using System.Data.Entity;

namespace Log4Javascript.Web
{
    public class DataContext : DbContext
    {
        public DataContext(string connectionNameOrConnectionString)
            : base(connectionNameOrConnectionString)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
        }

        public DataContext()
            : base("name=DefaultConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
        }

        public IDbSet<Entities.ClientLog> ClientLogs { get; set; }
         
    }
}