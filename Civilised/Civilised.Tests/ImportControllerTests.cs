using Civilised.Controllers;
using System.Web.Mvc;
using Xunit;

namespace Civilised.Tests
{
   public class ImportControllerTests
    {
       [Fact(Skip="ImportController needs to inherit from Controller to call View()."]
       public void IndexActionReturnsIndexView()
       {
           var controller = new ImportController();
           var result = controller.Index() as ViewResult;
           Assert.Equal("Index", result.ViewName);
       }
    }
}
