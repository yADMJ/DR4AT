using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace TurismoApp.Pages
{
    public class ViewNotesModel : PageModel
    {
        private readonly IWebHostEnvironment _env;

        public ViewNotesModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        [BindProperty]
        public string NewNote { get; set; }

        public List<string> Files { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string SelectedFile { get; set; }

        public string SelectedFileContent { get; set; }

        public void OnGet()
        {
            LoadFiles();

            if (!string.IsNullOrEmpty(SelectedFile))
            {
                var filePath = Path.Combine(_env.WebRootPath, "files", SelectedFile);
                if (System.IO.File.Exists(filePath))
                {
                    SelectedFileContent = System.IO.File.ReadAllText(filePath);
                }
            }
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(NewNote))
            {
                ModelState.AddModelError("NewNote", "A anotação não pode estar vazia.");
                LoadFiles();
                return Page();
            }

            // Criar nome do arquivo baseado na data e hora para evitar sobrescrever
            var fileName = $"note_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            var filePath = Path.Combine(_env.WebRootPath, "files", fileName);

            System.IO.File.WriteAllText(filePath, NewNote);

            return RedirectToPage(new { SelectedFile = fileName });
        }

        private void LoadFiles()
        {
            var folderPath = Path.Combine(_env.WebRootPath, "files");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            Files = Directory.GetFiles(folderPath, "*.txt")
                             .Select(Path.GetFileName)
                             .OrderByDescending(f => f)
                             .ToList();
        }
    }
}
