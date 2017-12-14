using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonData;

namespace DataAccess
{
    public interface IPortalContextFactory
    {
        PortalContext Create();
        AsyncLazy<PortalContext> CreateAsyncLazy();
    }

    [DependencyRegister]
    public sealed class PortalContextFactory : IPortalContextFactory
    {
        private readonly string _connectionString;

        public PortalContextFactory() : this(null)
        {

        }

        public PortalContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        PortalContext IPortalContextFactory.Create()
        {
            return _connectionString == null ? new PortalContext() : new PortalContext(_connectionString);
        }

        AsyncLazy<PortalContext> IPortalContextFactory.CreateAsyncLazy()
        {
            return new AsyncLazy<PortalContext>(
                () => 
                RetryHelper.Retry(((IPortalContextFactory) this).Create));
        }
    }
}
