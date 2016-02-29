using HCPeopleSearchApplication.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HCPeopleSearchApplication.Tests.Controllers
{
    [TestClass]
    public class PersonControllerTest
    {

        //Methdo to Test, whether Index View is returning 
        [TestMethod]
        public void Index()
        {
            PersonController controller = new PersonController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        //Method to test Whether proper Details are retreiving by Json
        //This'll Should fail, as It can't talk to Database in EF Code First.
        [TestMethod]
        public void GetPersonDetails()
        {
            PersonController controller = new PersonController();
            
            var result=controller.GetPersonDetails("Arun") as JsonResult;

            var data = result.Data;

            Assert.IsNotNull(data,"No JsonResult returned from action method");
           // Assert.IsNotNull(result);

        }

        //Method to test, Create Index is returning
        [TestMethod]
        public void Create()
        {
            PersonController controller = new PersonController();
            ViewResult result= controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }      
        
    }
}
