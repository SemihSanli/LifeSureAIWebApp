using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using LifeSureApp.Models.DataModels;
using LifeSureApp.ViewModels;
using Newtonsoft.Json;

namespace LifeSureApp.Controllers
{
    public class FAQAIController : Controller
    {
        private readonly DayNightDbEntities db = new DayNightDbEntities();
        private const string OpenAIApiKey = "YOUR_API_KEY";
        private const string OpenAIEndpoint = "YOUR_ENDPOINT";


        public ActionResult FAQAIList()
        {
            var faq = db.Tbl_Question.OrderByDescending(x => x.QuestionId)
               .Take(4)
               .ToList();
            
            return View(faq);
        }


        [HttpGet]
        public ActionResult GenerateAI()
        {
            return View(new FAQAIViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GenerateAI(FAQAIViewModel model, string submitType)
        {
            if (submitType == "SoruOlustur")
            {
                // 1. Prompt'u QuestionTitle olarak kaydet
                var entity = new Tbl_Question { QuestionTitle = model.QuestionTitle };
                db.Tbl_Question.Add(entity);
                db.SaveChanges();

                // 2. OpenAI ile soru oluştur
                var question = await GenerateWithOpenAI(model.QuestionTitle, model);
                model.Question = question;

                // 3. Soru'yu veritabanına kaydet
                entity.Question = question;
                db.SaveChanges();
            }
            else if (submitType == "CevapOlustur")
            {
                // 1. Son kaydı bul
                var entity = db.Tbl_Question.OrderByDescending(x => x.QuestionId).FirstOrDefault();
                if (entity != null)
                {
                    // 2. OpenAI ile cevap oluştur
                    var answer = await GenerateWithOpenAI(entity.Question, model);
                    model.QuestionAnswer = answer;

                    // 3. Cevabı veritabanına kaydet
                    entity.QuestionAnswer = answer;
                    db.SaveChanges();
                }
            }
            ModelState.Clear();
            return View("GenerateAI", model);
        }

        private async Task<string> GenerateWithOpenAI(string prompt, FAQAIViewModel model)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", OpenAIApiKey);
                var requestBody = new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                    {
                        new { role = "user", content = prompt }
                    }
                };
                var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(OpenAIEndpoint, content);
                var json = await response.Content.ReadAsStringAsync();
                model.DebugMessage = $"Status: {response.StatusCode} - Response: {json}";
                if (response.IsSuccessStatusCode)
                {
                    dynamic result = JsonConvert.DeserializeObject(json);
                    return result.choices[0].message.content.ToString();
                }
                else
                {
                    return $"API Hatası: {response.StatusCode}";
                }
            }
        }
    }
}