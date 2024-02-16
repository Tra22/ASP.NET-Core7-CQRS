
using CQRS.Data;

namespace CQRS.Queries
{
    public class QueryRepository<T> : IQueryRepository<T> where T : class
    {
        protected readonly DapperContext _context;

        public QueryRepository(DapperContext context)
        {
            _context = context;
        }
    }
}