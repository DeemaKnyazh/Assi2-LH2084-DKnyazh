using Assi2_LH2084_DKnyazh.Controllers;
using Assi2_LH2084_DKnyazh.Data;
using COMP2084_Assignment2_DmitryKnyazhevskiy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assi4_Testing_DmitryKnyazhevskiy
{
    [TestClass]
    public class CampSessionsControllerTests
    {

        ApplicationDbContext _context;
        CampSessionsController controller;

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);

            // add data to in-memory db
            var campSession = new CampSession{campSessionId = 1, maxCampers = 25};
            _context.CampSessions.Add(campSession);

            controller = new CampSessionsController(_context);
        }

        #region delete
        [TestMethod]
        public void DeleteNullIdReturnsErrorView()
        {
            var result = (ViewResult)controller.Delete(null).Result;

            Assert.AreEqual("Error", result.ViewName);
        }
        [TestMethod]
        public void DeleteInvalidIdReturnsErrorView()
        {
            var result = (ViewResult)controller.Delete(2).Result;

            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteIdValidIdReturnsDeleteView()
        {
            var result = (ViewResult)controller.Delete(1).Result;
            //Cant get this to work, the FirstOrDefaultAsync seems to be causing an error in the controller
            Assert.AreEqual("Delete", result.ViewName);
        }

        [TestMethod]
        public void DeletePostRedirectToIndex()
        {//Redirects if the camp session you want to delete doesnt exist
            var result = (RedirectToActionResult)controller.DeleteConfirmed(2).Result;
            
            Assert.AreEqual("Index", result.ActionName);
        }

        [TestMethod]
        public void DeletePostSuccessfulDelete()
        {//Redirects if the camp session you want to delete is successful

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);
            var campSession = new CampSession { campSessionId = 1, maxCampers = 25 };
            _context.CampSessions.Add(campSession);
            controller = new CampSessionsController(_context);
            Assert.IsNotNull(_context.CampSessions.Find(1));
            var result = (RedirectToActionResult)controller.DeleteConfirmed(1).Result;
            Assert.AreEqual("Index", result.ActionName);
            Assert.IsNull(_context.CampSessions.Find(1));
        }

        [TestMethod]
        public void DeletePostErrorCampSessionsNull()
        {//should give an error, but I cant figure out how to make campsessions null
            _context.CampSessions = null;
            var result = (ObjectResult)controller.DeleteConfirmed(1).Result;
            Assert.AreEqual("Entity set 'ApplicationDbContext.CampSessions'  is null.", result.ContentTypes.ToString);
        }
        #endregion
    }
}