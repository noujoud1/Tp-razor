using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TPIntroRazor.Pages
{
    public class IndexModel : PageModel
    {
        public string MessageAccueil { get; set; } = "Bienvenue sur mon application Razor Pages !";

        public List<string> Modules { get; set; } = new List<string>
        {
            "Introduction à ASP.NET Core",
            "Syntaxe Razor",
            "Formulaires et BindProperty",
            "Traitement HTTP GET/POST"
        };

        public List<string> Prerequis { get; set; } = new List<string>
        {
            "Notions de base en C#",
            "Notions de base en HTML/CSS",
            "SDK .NET 8.0 ou supérieur installé"
        };

        public string MessageAccueilDynamique { get; set; } = string.Empty;

        public void OnGet()
        {
            int heure = DateTime.Now.Hour;

            if (heure < 12)
            {
                MessageAccueilDynamique = "Bonjour ! Prêt(e) pour une session productive ?";
            }
            else if (heure < 18)
            {
                MessageAccueilDynamique = "Bon après-midi ! Continuons ce TP.";
            }
            else
            {
                MessageAccueilDynamique = "Bonsoir ! Encore motivé(e) pour coder ?";
            }
        }
    }
}