using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tester.Web.Helpers
{
    public class Credential
    {
         public static string Key = Environment.GetEnvironmentVariable("paystackkey");
    }
}