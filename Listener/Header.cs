using System.Net;


namespace Listener
{
    public class Header
    {
        public static void GetMyNameByHeader(HttpListenerResponse response)
        {
            SendResponseWithHeader(response, "MyNameByHeader: John", "X-MyName", "John");
        }

        static void SendResponseWithHeader(HttpListenerResponse response, string content, string headerName, string headerValue)
        {
            response.AddHeader(headerName, headerValue);
            Status.SendResponse(response, content);
        }

    }
}
