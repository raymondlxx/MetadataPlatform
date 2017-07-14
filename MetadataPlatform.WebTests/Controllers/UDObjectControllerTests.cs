using Microsoft.VisualStudio.TestTools.UnitTesting;
using MetadataPlatform.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetadataPlatform.Web.Controllers.Tests
{
    [TestClass()]
    public class UDObjectControllerTests
    {
        [TestMethod()]
        public void GetUDObjectEntitiesTest()
        {
            UDObjectController controller = new UDObjectController();
            var items = controller.GetUDObjectEntities();
            Assert.AreEqual<int>(0, items.Count());
        }
    }
}