using Happibook.Core;
using Happibook.Core.Infrastructure;
using Happibook.Core.IService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Happibook.Test.Services
{
    [TestClass]
    public class LOVServiceTest
    {
        private ILOVService lovService;
        private ISSHRequestInfo requestInfo;
        
        [TestInitialize]
        public void init()
        {
            requestInfo = IoC.Resolve<ISSHRequestInfo>();
            lovService = IoC.Resolve<ILOVService>();
        }

        [TestMethod]
        public async Task GetAll()
        {
            var context = requestInfo.Context;
            using (var tran = context.Database.BeginTransaction())
            {
                var result = await lovService.GetAllAsync();
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count > 0);
            }
        }
    }
}
