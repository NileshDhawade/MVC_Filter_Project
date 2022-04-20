using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;
namespace MVC_Filters_Project.Models
{
    public class TrackExecutionTime :Attribute, IActionFilter,IResultFilter
    {
        public void GetMesage(string msg)
        {
            File.AppendAllText(Path.GetFullPath(@"C:\Users\HP\source\repos\MVC_Filters_Project\MVC_Filters_Project\Test\Text.txt"), msg);
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string msg = "\nOn action Executed ->" + DateTime.Now.ToString() + "\n";
            GetMesage(msg);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string msg = "\nOn action Executing ->" + DateTime.Now.ToString() + "\n";
            GetMesage(msg);
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            string msg = "On result Executed ->" + context.RouteData.Values["controller"].ToString() +
                "->" + context.RouteData.Values["action"].ToString() + " " + DateTime.Now.ToString() + "\n"; ;
            GetMesage(msg);
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            string msg = "On result Executing->" + context.RouteData.Values["controller"].ToString() +
                "->" + context.RouteData.Values["action"].ToString() + " " + DateTime.Now.ToString() + "\n"; ;
            GetMesage(msg);
        }
    }
}
