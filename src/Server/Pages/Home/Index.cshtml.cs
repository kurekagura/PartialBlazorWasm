using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApp.Pages.Home
{
    public class IndexModel : PageModel
    {
        public List<Deposit> DepositList;

        private readonly IWebHostEnvironment _env;

        public IndexModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<IActionResult> OnGet()
        {
            string jsonPath = Path.Combine(_env.WebRootPath, "data", "deposit.json");

            // JSON �f�[�^�� List<Deposit> �ɋt�V���A����
            var jsonStr = System.IO.File.ReadAllText(jsonPath);
            DepositList = JsonSerializer.Deserialize<List<Deposit>>(jsonStr) ?? new List<Deposit>();

            return Page();
        }
    }

    public class Deposit
    {
        [JsonPropertyName("RegistrationDate")]
        public DateTime RegistrationDate { get; set; }
        [JsonPropertyName("UserID")]
        public required string UserID { get; set; }
        [JsonPropertyName("Name")]
        public required string Name { get; set; }
        [JsonPropertyName("Gender")]
        public string? Gender { get; set; }
        [JsonPropertyName("Age")]
        public int Age { get; set; }
        [JsonPropertyName("Total")]
        public decimal Total { get; set; }
        [JsonPropertyName("Birthday")]
        public DateTime Birthday { get; set; }
    }
}
