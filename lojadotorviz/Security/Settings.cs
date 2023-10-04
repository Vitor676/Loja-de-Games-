namespace lojadotorviz.Security
{
    public class Settings
    {
        private static string secret = "987905106bff3d3b120143ee8be5460cec6dabd989b37440dfc8a0c1221ceeac";

        public static string Secret { get => secret; set => secret = value; }
    }
}
