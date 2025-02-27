using Microsoft.Extensions.Configuration;

namespace seaplan.data;

public static class Configuration
{
    public static string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
            try
            {
                var extension = "../seaplan.webapi";
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), extension));
                configurationManager.AddJsonFile("appsettings.json");
            }
            catch
            {
                configurationManager.AddJsonFile("appsettings.json");
            }

            return configurationManager.GetConnectionString("SQLServer");
        }
    }


    public static string ConnectionStringReddis
    {
        get
        {
            ConfigurationManager configurationManager = new();
            try
            {
                var extension = "../seaplan.webapi";
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), extension));
                configurationManager.AddJsonFile("appsettings.json");
            }
            catch
            {
                configurationManager.AddJsonFile("appsettings.json");
            }

            return configurationManager.GetConnectionString("Reddis");
        }
    }
}