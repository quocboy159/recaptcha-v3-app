using Microsoft.AspNetCore.Mvc.Filters;
using reCaptcha_v3_app.Models;
using reCaptcha_v3_app.Services;

namespace reCaptcha_v3_app.Attributes
{
    public class RecaptchaValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var model = context.ActionArguments.Values.FirstOrDefault(x => x is IReCaptchaModel) as IReCaptchaModel;
            if(model == null)
            {
                throw new Exception("Please enter model");
            }

            var reCaptchaService = context.HttpContext.RequestServices.GetRequiredService<IReCaptchaService>();
            var reCaptcharesult = reCaptchaService.TokenVerify(model.Token);
            if (!reCaptcharesult.Result.Success && reCaptcharesult.Result.Score <= 0.5)
            {
                context.ModelState.AddModelError(string.Empty, "You are not a human.");
            }
        }
    }
}
