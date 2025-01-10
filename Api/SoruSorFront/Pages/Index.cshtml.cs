using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SoruSorFront.Pages
{
    public class IndexModel : PageModel
    {
        public List<QuestionDetailsDTO> Questions { get; set; } = new List<QuestionDetailsDTO>();

        public async Task OnGetAsync()
        {
            try
            {
                using var client = new HttpClient();
                var response = await client.GetAsync("http://localhost:5012/api/Questions/user/2/with-likes");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    Questions = JsonSerializer.Deserialize<List<QuestionDetailsDTO>>(json) ?? new List<QuestionDetailsDTO>();
                }
                else
                {
                    Debug.WriteLine($"API hata kodu: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Hata: {ex}");
            }
        }
    }

    public class QuestionDetailsDTO
    {
        public int id { get; set; }
        public string content { get; set; }
        public int askedById { get; set; }
        public int reciveUserId { get; set; }
        public int likeCount { get; set; }
        public int dislikeCount { get; set; }
        public AnswerDTO answer { get; set; }
    }

    public class AnswerDTO
    {
        public int Iid { get; set; }
        public string content { get; set; }
        public int questionId { get; set; }
        public int answeredById { get; set; }
    }
}
