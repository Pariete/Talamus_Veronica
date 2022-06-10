using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Talamus_Veronica.Data;
using Talamus_Veronica.Models;

namespace Talamus_Veronica.Pages.KJbcS14fnS7dh1SDA3
{
    public class EditModel : PageModel
    {
        private readonly Talamus_Veronica.Data.TalamusContext _context;

        public EditModel(Talamus_Veronica.Data.TalamusContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PartOfStory PartOfStory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PartOfStory = await _context.PartOfStories.FirstOrDefaultAsync(m => m.Id == id);

            if (PartOfStory == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PartOfStory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartOfStoryExists(PartOfStory.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PartOfStoryExists(int id)
        {
            return _context.PartOfStories.Any(e => e.Id == id);
        }
    }
}
