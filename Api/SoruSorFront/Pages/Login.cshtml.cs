using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SoruSorFront.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required]
        public string name { get; set; }

        [BindProperty]
        [Required]
        public string pass { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            UserForAuthenticationDTO login = new UserForAuthenticationDTO()
            {
                password = pass,
                userName = name
            };

            var json = JsonSerializer.Serialize(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            using var client = new HttpClient(handler);
            var response = await client.PostAsync("http://localhost:5012/api/Authentication/login", content);
            Debug.WriteLine("response : "+ response.Content);
            if (response.IsSuccessStatusCode)
            {
                // Gelen JSON içindeki token'i al ve konsola yazdýr
                var responseData = await response.Content.ReadAsStringAsync();
                var responseObject = JsonSerializer.Deserialize<JsonElement>(responseData);

                if (responseObject.TryGetProperty("token", out var token))
                {
                    Debug.WriteLine("Token: " + token.GetString());
                }
                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }
        }
    }
    public class UserForAuthenticationDTO
    {
        public string password { get; set; }
        public string userName { get; set; }
    }
}