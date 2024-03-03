using System.Net;
using System.Text;

namespace Listener
{
    public class Program
    {
        static void Main()
        {
            string url = "http://localhost:8888/";
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(url);
            listener.Start();
            Console.WriteLine("Listening for connections on " + url);

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;

                string resourcePath = URL.GetResourcePath(request.Url);
                if (resourcePath.Equals("MyName"))
                {
                    Status.SendResponse(context.Response, "MyName: John");
                }


                else if (resourcePath.Equals("MyNameByHeader"))
                {
                    Header.GetMyNameByHeader(context.Response);
                }


                else if (resourcePath.Equals("MyNameByCookies"))
                {
                    Cookies.GetMyNameByCookies(request.Cookies, context.Response);
                }

                else
                {
                    Status.HandleStatusRequests(resourcePath, context.Response);
                }

                context.Response.Close();
            }
        }

    }
}