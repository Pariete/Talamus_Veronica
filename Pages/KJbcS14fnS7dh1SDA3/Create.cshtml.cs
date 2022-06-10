using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Talamus_Veronica.Data;
using Talamus_Veronica.Models;

namespace Talamus_Veronica.Pages.KJbcS14fnS7dh1SDA3
{
    public class CreateModel : PageModel
    {
        private readonly Talamus_Veronica.Data.TalamusContext _context;

        public CreateModel(Talamus_Veronica.Data.TalamusContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PartOfStory PartOfStory { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PartOfStories.Add(PartOfStory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
