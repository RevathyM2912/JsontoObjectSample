using JsontoObjectSample;
using Newtonsoft.Json;
using RestSharp;

internal class Program
{
    private static void Main(string[] args)
    {
        GetData();
    }
    public static void GetData()
    {
        try
        {
            string url = "https://jsonplaceholder.typicode.com/posts";
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.Get(request);
            if (response.IsSuccessStatusCode)
            {
                string? rawData = response.Content;
                List<JsonPosts>? jsonposts = JsonConvert.DeserializeObject<List<JsonPosts>>(rawData);
                foreach (JsonPosts item in jsonposts)
                {
                    int id = item.Id;
                    string? body = item.Body;
                    string? title = item.Title;
                    Console.WriteLine("Id : " + id);
                    Console.WriteLine("Title : " + title);
                    Console.WriteLine("Body : " + body);
                    Console.WriteLine("----------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Error: Not found");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}