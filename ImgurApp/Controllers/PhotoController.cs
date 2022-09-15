using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImgurApp.Models;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace ImgurApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {

        static HttpClient client = new HttpClient();
        string path = "http://api.imgur.com/3";

        [HttpGet]
        public async Task<List<ImgurApp.Models.Image>> Get()
        {

            List<ImgurApp.Models.Image> images = null;

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                images = JsonSerializer.Deserialize<List<ImgurApp.Models.Image>>(jsonResponse);

            }
            return images;

        }

        [HttpPost]
        public async Task<Uri> Post(ImgurApp.Models.Image image)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                 "/upload", image);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }



        [HttpDelete("{id}")]
        public async Task<Uri> Delete(int id)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                 "/delete", id);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }


    }
}
