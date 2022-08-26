//namespace MoviesProj.Services
//{
//    public static class ApiCall 
//    {
//        private static readonly HttpClient _client = new();
//        public static async Task ProcessRepositories(string uri)
//        {
//            _client.BaseAddress = new Uri("https://localhost:7153/api/");
//            _client.DefaultRequestHeaders.Accept.Clear();
//            //_client.DefaultRequestHeaders.Accept.Add(
//            //  new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
//            //_client.DefaultRequestHeaders.Add();
//            var stringTask = await _client.GetAsync(uri);

//        }
//    }
//}