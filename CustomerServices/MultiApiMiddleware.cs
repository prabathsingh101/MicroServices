namespace CustomerServices
{
    public class MultiApiMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HttpClient _httpClient;

        public MultiApiMiddleware(RequestDelegate next, HttpClient httpClient)
        {
            _next = next;
            _httpClient = httpClient;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            // First API call
            var response1 = await _httpClient.GetAsync("https://localhost:7149/api/orders/allorder");
            var data1 = await response1.Content.ReadAsStringAsync();

            // Second API call
            var response2 = await _httpClient.GetAsync("https://localhost:7004/api/Products");
            var data2 = await response2.Content.ReadAsStringAsync();

            // Second API call
            //int id = 2;
            //var response3 = await _httpClient.GetAsync($"https://localhost:7004/api/Products?id={id}");
            //var data3 = await response3.Content.ReadAsStringAsync();

            // Optional: Do something with data1 and data2
            context.Items["ApiData1"] = data1;
            context.Items["ApiData2"] = data2;
            //context.Items["ApiData3"] = data3;

            // Call the next middleware
            await _next(context);
        }
      }
    }
