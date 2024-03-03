using System.Net;


namespace Listener
{
    public class Cookies
    {
        public static void GetMyNameByCookies(CookieCollection cookies, HttpListenerResponse response)
        {
            SendResponseWithCookie(response, "MyNameByCookies: John", "MyName", "John");
        }
        public static void SendResponseWithCookie(HttpListenerResponse response, string content, string cookieName, string cookieValue)
        {
            response.Cookies.Add(new Cookie(cookieName, cookieValue));
            Status.SendResponse(response, content);
        }
    }
}
