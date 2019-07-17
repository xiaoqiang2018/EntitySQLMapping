using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ORMProject.Controllers
{
      public class TestForeach:CollectionBase
     {
        protected List<string> list = new List<string>();
        public void Add(string value)
        {
            list.Add(value);
        }
     }
    public class TestORMController : Controller
    {
     
        public IActionResult Index()
        {
            TestForeach testForeach = new TestForeach();
            testForeach.Add("test1");
            foreach (string a in testForeach)
            {
                Console.WriteLine(a);
            }
            return View();
        }


    }
}