using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Talamus_Veronica.Data;
using Talamus_Veronica.Models;

namespace Talamus_Veronica.Pages.KJbcS14fnS7dh1SDA3
{
    public class IndexModel : PageModel
    {
        private readonly Talamus_Veronica.Data.TalamusContext _context;

        public IndexModel(Talamus_Veronica.Data.TalamusContext context)
        {
            _context = context;
        }

        public IList<PartOfStory> PartOfStory { get;set; }

        public async Task OnGetAsync()
        {
            PartOfStory = await _context.PartOfStories.ToListAsync();
        }
    }
}
