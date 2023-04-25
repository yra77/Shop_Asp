namespace Shop_Asp.Domain.Helpers
{
    public static class ExtensionStr
    {
        public static string CutController(this string str)
        {
            return str.Replace("Controller", "");
        }
    }
}
