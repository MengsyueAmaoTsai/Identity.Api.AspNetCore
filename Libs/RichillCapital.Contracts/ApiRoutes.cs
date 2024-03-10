namespace RichillCapital.Contracts;

public static class ApiRoutes
{
    private const string ApiBase = "api";

    public static class V1
    {
        private const string VersionBase = $"{ApiBase}/v1";

        public static class Bots
        {
            private const string Base = $"{VersionBase}/bots";

            public const string List = Base;
            public const string Get = $"{Base}/{{botId}}";
            public const string Delete = $"{Base}/{{botId}}";
        }
    }
}
