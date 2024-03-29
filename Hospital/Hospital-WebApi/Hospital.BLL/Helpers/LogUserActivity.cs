using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Hospital.BLL.Helpers
{
    public class LogUserActivity:IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();
            var userId = int.Parse(resultContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            //var repo = resultContext.HttpContext.RequestServices.GetService<IAuthRepository>();
            // var user=repo.GetUser(userId);
            // user.lastActivity=DateTime.Now();
            //await  repo.SaveAll();
            // go to startUp class >>>>services.AddScoped<LogUserActivity>();
            // go to controller head >> [ServiceFilter(typeof(LogUserActivity))]
        }
    }
}