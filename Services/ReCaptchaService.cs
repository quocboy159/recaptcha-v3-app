using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using reCaptcha_v3_app.Models;
using reCaptcha_v3_app.Settings;

namespace reCaptcha_v3_app.Services
{
    public class ReCaptchaService: IReCaptchaService
    {
        private readonly RecaptchaSettings _recaptchaSettings;

        public ReCaptchaService(IOptions<RecaptchaSettings> recaptchaSettings)
        {
            _recaptchaSettings = recaptchaSettings.Value;
        }

        public async Task<ReCaptchaResponse> TokenVerify(string token)
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync(string.Format(_recaptchaSettings.VerifyUrl, _recaptchaSettings.SecretKey,token));
            var reCaptcharesponse = JsonConvert.DeserializeObject<ReCaptchaResponse>(response);
            return reCaptcharesponse;
        }
    }
}
