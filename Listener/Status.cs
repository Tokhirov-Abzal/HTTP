

using System.Net;
using System.Text;

namespace Listener
{
    public class Status
    {
        public static void HandleStatusRequests(string resourcePath, HttpListenerResponse response)
        {
            switch (resourcePath.ToLower())
            {
                case "information":
                    SendResponseWithStatusCode(response, "Information: OK", HttpStatusCode.OK);
                    break;
                case "success":
                    SendResponseWithStatusCode(response, "Success: OK", HttpStatusCode.OK);
                    break;
                case "redirection":
                    SendResponseWithStatusCode(response, "Redirection: Redirecting", HttpStatusCode.Redirect);
                    break;
                case "clienterror":
                    SendResponseWithStatusCode(response, "ClientError: Bad Request", HttpStatusCode.BadRequest);
                    break;
                case "servererror":
                    SendResponseWithStatusCode(response, "ServerError: Internal Server Error", HttpStatusCode.InternalServerError);
                    break;
                default:
                    SendResponseWithStatusCode(response, "Not Found", HttpStatusCode.NotFound);
                    break;
            }
        }

        public static void SendResponse(HttpListenerResponse response, string content)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(content);
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
        }

        static void SendResponseWithStatusCode(HttpListenerResponse response, string content, HttpStatusCode statusCode)
        {
            response.StatusCode = (int)statusCode;
            SendResponse(response, content);
        }
    }
}
