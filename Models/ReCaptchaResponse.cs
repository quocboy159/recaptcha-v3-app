namespace reCaptcha_v3_app.Models
{
    public class ReCaptchaResponse
    {
        public bool Success { get; set; }
        public DateTime Challenge_ts { get; set; }
        public string Hostname { get; set; }
        public long Score { get; set; }
    }
}
