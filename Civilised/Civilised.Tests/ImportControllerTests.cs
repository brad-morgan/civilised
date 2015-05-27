using Civilised.Controllers;
using System.Web.Mvc;
using Xunit;

namespace Civilised.Tests
{
   public class ImportControllerTests
    {
       [Fact]
       public void ImportControllerInheritsFromController()
       {
           Assert.IsAssignableFrom<Controller>(new ImportController());
       }
       [Fact]
       public void IndexActionReturnsIndexView()
       {
           var controller = new ImportController();
           var result = controller.Index() as ViewResult;
           Assert.Empty(result.ViewName);

           /*Q: Why does testing that ViewName is empty make any sense when we're looking for a view named Index?
            * 
            * A: Calling Index() instructs the view engine to find the default view for an action (named Index).
            * When this happens outside of the ASP.NET pipeline (when not being run on a web server) ViewName is an empty string,
            * therefore testing for an empty string is a good indication that the default view has been returned 
            * (and thus would be seen by a browser)
            */
       }
    }
}
