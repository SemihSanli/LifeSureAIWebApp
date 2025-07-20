using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.IO;
using LifeSureApp.ViewModels;
using LifeSureApp.Models.DataModels;


namespace LifeSureApp.Controllers
{
    public class ServiceAIController : Controller
    {
        DayNightDbEntities db = new DayNightDbEntities();
        // GET: ServiceAI
        public ActionResult Index()
        {
            var values = db.Tbl_Service.OrderByDescending(x => x.ServiceId)
               .Take(4)
               .ToList();
            return View(values);
            
        }

        // GET: ServiceAI/GenerateImage
        [HttpGet]
        public ActionResult GenerateImage()
        {
            return View(new ServiceAIViewModel());
        }

        // POST: ServiceAI/GenerateImage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GenerateImage(ServiceAIViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.ServiceDescription))
            {
                ModelState.AddModelError("ServiceDescription", "Açıklama giriniz.");
                return View(model);
            }

            var apiKey = "YOUR_API_KEY";
            var apiUrl = "YOUR_ENDPOINT";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                var content = new StringContent($"{{\"inputs\": \"{model.ServiceDescription.Replace("\"", "\\\"") }\"}}", System.Text.Encoding.UTF8, "application/json");
                try
                {
                    var response = await client.PostAsync(apiUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var bytes = await response.Content.ReadAsByteArrayAsync();
                        var fileName = $"{Guid.NewGuid()}.png";
                        var relativePath = $"/Content/AiImages/{fileName}";
                        var serverPath = Server.MapPath(relativePath);
                        Directory.CreateDirectory(Path.GetDirectoryName(serverPath));
                        System.IO.File.WriteAllBytes(serverPath, bytes);
                        model.ServiceImage = relativePath;

                        // Veritabanına kaydet
                        using (var db = new LifeSureApp.Models.DataModels.DayNightDbEntities())
                        {
                            var entity = new LifeSureApp.Models.DataModels.Tbl_Service
                            {
                                ServiceDescription = model.ServiceDescription,
                                ServiceImage = model.ServiceImage,
                                ServiceIcon = model.ServiceIcon,
                                ServiceTitle = model.ServiceTitle
                            };
                            db.Tbl_Service.Add(entity);
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ServiceDescription", $"API Hatası: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("ServiceDescription", $"Hata: {ex.Message}");
                }
            }
            return RedirectToAction("Index");
        }
    }
}