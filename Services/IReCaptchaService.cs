using reCaptcha_v3_app.Models;

namespace reCaptcha_v3_app.Services
{
    public interface IReCaptchaService
    {
        Task<ReCaptchaResponse> TokenVerify(string token);
    }
}
