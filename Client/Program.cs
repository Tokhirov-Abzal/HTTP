
namespace Client
{
    public class Program
    {
        static async Task Main()
        {

            await GetMyName();


            await GetStatusCodes();


            await GetMyNameByHeader();


            await GetMyNameByCookies();
        }


        static async Task GetMyName()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "http://localhost:8888/MyName/";
                HttpResponseMessage response = await client.GetAsync(url);
                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
            }
        }

        static async Task GetStatusCodes()
        {
            using (HttpClient client = new HttpClient())
            {
                string[] urls = {
                "http://localhost:8888/Information/",
                "http://localhost:8888/Success/",
                "http://localhost:8888/Redirection/",
                "http://localhost:8888/ClientError/",
                "http://localhost:8888/ServerError/"
            };

                foreach (string url in urls)
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    Console.WriteLine($"{url}: {response.StatusCode}");
                }
            }
        }

        static async Task GetMyNameByHeader()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "http://localhost:8888/MyNameByHeader/";
                HttpResponseMessage response = await client.GetAsync(url);
                string result = await response.Content.ReadAsStringAsync();

                if (response.Headers.TryGetValues("X-MyName", out var values))
                {
                    Console.WriteLine($"Header Value: {values}");
                }

                Console.WriteLine(result);
            }
        }
        static async Task GetMyNameByCookies()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "http://localhost:8888/MyNameByCookies/";
                HttpResponseMessage response = await client.GetAsync(url);
                string result = await response.Content.ReadAsStringAsync();

                if (response.Headers.TryGetValues("Set-Cookie", out var values))
                {
                    Console.WriteLine($"Cookie Value: {values}");
                }

                Console.WriteLine(result);
            }
        }
    }
}