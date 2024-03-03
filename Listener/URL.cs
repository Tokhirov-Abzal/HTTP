

namespace Listener
{
    public class URL
    {
        public static string GetResourcePath(Uri url)
        {
            return url.Segments[url.Segments.Length - 1].TrimEnd('/');
        }
    }
}
