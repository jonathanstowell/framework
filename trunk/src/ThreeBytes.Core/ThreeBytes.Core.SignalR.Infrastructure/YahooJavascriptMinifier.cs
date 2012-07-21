using SignalR.Infrastructure;
using Yahoo.Yui.Compressor;

namespace ThreeBytes.Core.SignalR.Infrastructure
{
    public class YahooJavascriptMinifier : IJavaScriptMinifier
    {
        public static readonly YahooJavascriptMinifier Instance = new YahooJavascriptMinifier();

        public string Minify(string source)
        {
            return JavaScriptCompressor.Compress(source);
        }
    }
}
