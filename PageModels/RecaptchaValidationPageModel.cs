using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using reCaptcha_v3_app.Models;
using reCaptcha_v3_app.Services;

namespace reCaptcha_v3_app.PageModels
{
    public class RecaptchaValidationPageModel: PageModel
    {
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (context.HandlerMethod.HttpMethod != "Get")
            {
                var model = ((IReCaptchaModel)context.HandlerInstance);
                if (model == null)
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
}
