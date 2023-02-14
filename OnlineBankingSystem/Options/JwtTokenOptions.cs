namespace OnlineBankingSystem.Options
{
    public class JwtTokenOptions
    {
        public const string JwtToken = "JwtToken";

        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string Key { get; set; }
    }
}
