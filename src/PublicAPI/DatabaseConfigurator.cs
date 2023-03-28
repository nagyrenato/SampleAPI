namespace PublicAPI
{
    using Microsoft.EntityFrameworkCore;
    using PublicAPI.Context;

    /// <summary>
    /// It configures the database dependencies dynamically based on the configuration files.
    /// </summary>
    public class DatabaseConfigurator
    {
        private DatabaseConfigurator()
        {
        }

        /// <summary>
        /// Set up the database context based on the configuration.
        /// </summary>
        /// <param name="configuration">Given configuration source.</param>
        /// <param name="services">Given services where to add the db settings.</param>
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            bool useOnlyInMemoryDatabase = false;
            if (configuration["UseOnlyInMemoryDatabase"] != null)
            {
                useOnlyInMemoryDatabase = bool.Parse(configuration["UseOnlyInMemoryDatabase"] !);
            }

            if (useOnlyInMemoryDatabase)
            {
                services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            }
            else
            {
                var tdcstr = configuration.GetConnectionString("TodoListConnection");
                /* SqlLocalDB.exe create TodoList
                *  SqlLocalDB.exe start TodoList
                *  From SQL Management studio use the following: (LocalDB)\TodoList
                */
                services.AddDbContext<TodoContext>(c =>
                    c.UseSqlServer(configuration.GetConnectionString("TodoListConnection")));
            }
        }
    }
}