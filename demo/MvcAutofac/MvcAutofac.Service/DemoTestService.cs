using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcAutofac.Service
{
   public  class DemoTestService:IDemoTestService
    {
        public string GetTestName()
       {
           return typeof(DemoTestService).Name;
        }
    }
}
