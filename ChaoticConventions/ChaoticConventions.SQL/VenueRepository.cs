using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaoticConventions.Model;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;

namespace ChaoticConventions.SQL
{
    public class VenueRepository : IRepository<Venue>
    {
        private readonly IDbConnection _sqlConnection;

        public VenueRepository(IDbConnection sqlConnection )
        {
            _sqlConnection = sqlConnection;
        }


        public IEnumerable<Venue> Get()
        {
            return  _sqlConnection.GetAll<Venue>();
        }

        public void Save(IEnumerable<Venue> entities)
        {
            throw new NotImplementedException();
        }

        public void Save(Venue entity)
        {
            // this part really should be doing an upsert
            // i.e. like here: https://sqlperformance.com/2020/09/locking/upsert-anti-pattern

            _sqlConnection.Insert(entity);
        }
    }
}
