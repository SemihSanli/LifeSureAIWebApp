namespace LifeSureApp.Models.ViewModels
{
    public class ServiceAIViewModel
    {
        // Kullanıcıdan alınan başlık
        public string ServiceTitle { get; set; }
        // Kullanıcıdan alınan ikon (isteğe bağlı: url, class vs.)
        public string ServiceIcon { get; set; }
        // Kullanıcıdan alınan açıklama (prompt)
        public string ServiceDescription { get; set; }
        // Oluşan görselin sunucu üzerindeki url'i
        public string ServiceImage { get; set; }
    }
} 