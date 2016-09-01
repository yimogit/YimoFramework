using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemo.Service
{
   public  class DemoTestService:IDemoTestService
    {
        public string GetTestName()
        {
            return "test1";
        }
    }
}
