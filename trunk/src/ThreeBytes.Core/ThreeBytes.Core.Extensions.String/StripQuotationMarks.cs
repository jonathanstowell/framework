namespace ThreeBytes.Core.Extensions.String
{
    public static class StripQuotationMarks
    {
        public static string StripQuotations(this string item)
        {
            return item.Replace("\"", "");
        }
    }
}
