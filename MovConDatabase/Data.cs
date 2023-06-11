using Microsoft.Extensions.Configuration;
using System.Data;

namespace MovConDatabase
{
    public abstract class Data
    {
        private IConfiguration _configuration;
        protected Database _database;

        public IDbConnection _conn
        {
            get { return this._database._dbConnection; }
            private set { }
        }

        public Data(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._database = new Database(_configuration);
        }
    }
}
