using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TPIntroRazor.Pages
{
	public class CalculModel : PageModel
	{
		[BindProperty]
		[Required(ErrorMessage = "Le nom est obligatoire.")]
		public string Nom { get; set; } = string.Empty;

		[BindProperty]
		[Range(1900, 2026, ErrorMessage = "Entrez une année valide entre 1900 et 2026.")]
		public int AnneeNaissance { get; set; }

		public string Message { get; set; } = string.Empty;
		public bool EstValide { get; set; } = true;
		public int? AnneeCentenaire { get; set; }
		public string Decennie { get; set; } = string.Empty;

		public void OnGet() { }

		public void OnPost()
		{
			if (!ModelState.IsValid)
			{
				Message = "Veuillez corriger les erreurs du formulaire.";
				EstValide = false;
				return;
			}

			int age = DateTime.Now.Year - AnneeNaissance;

			if (age < 0 || age > 120)
			{
				Message = "Année de naissance invalide !";
				EstValide = false;
			}
			else
			{
				Message = $"Bonjour {Nom}, vous avez environ {age} ans cette année !";
				EstValide = true;
				AnneeCentenaire = AnneeNaissance + 100;
				Decennie = $"{(AnneeNaissance / 10) * 10}s";
			}
		}
	}
}