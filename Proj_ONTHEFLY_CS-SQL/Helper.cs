using System.Configuration;

namespace Proj_ONTHEFLY_CS_SQL
{
    public class Helper
    {
        public static string ConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}