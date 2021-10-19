using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoFilter.Filter
{
    public class SampleFilter : IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("-------------" + context.ActionDescriptor.DisplayName + "----------running.");
        }
    }
}
//built-in web server of asp.net core mvc => kestrel