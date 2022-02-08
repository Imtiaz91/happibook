using Happibook.Core;
using Happibook.Core.IService;
using Happibook.Test.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Happibook.Test.Services
{
    [TestClass]
    public class RoleServiceTest
    {
        private IRoleService _roleService;

        [TestInitialize]
        public void init()
        {
            _roleService = IoC.Resolve<IRoleService>();
        }

        [TestMethod]
        public async Task GetAll_Success()
        {
            var result = await _roleService.GetAllAsync();
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public async Task GetAll_Fail()
        {
            var result = await _roleService.GetAllAsync();
            Assert.IsFalse(result == null);
        }
    }
}
