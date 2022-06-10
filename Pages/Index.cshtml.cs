using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talamus_Veronica.Data;
using Talamus_Veronica.Models;

namespace Talamus_Veronica.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly TalamusContext _context;

        public PartOfStory partOfStory = null;
        public List<PartOfStory> SubsequentParts = null;
        public IndexModel(ILogger<IndexModel> logger, TalamusContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            try
            {
                partOfStory = _context.PartOfStories.FirstOrDefault(i => i.Id == 1);
                string[] subsequent = partOfStory.SubsequentPartsIds.Split(",");

                SubsequentParts = new List<PartOfStory>();
                foreach (string s in subsequent)
                {
                    SubsequentParts.Add(_context.PartOfStories.FirstOrDefault(p => p.Id == Convert.ToInt32(s)));
                }
            }
            catch (Exception e)
            {
                partOfStory = new PartOfStory()
                {
                    Content = "default",
                    Title = "default",
                    SubsequentPartsIds = "1,2"
                };
                SubsequentParts = new List<PartOfStory>();
                SubsequentParts.Add(partOfStory);
            }
            
        }

        public void OnPostById(int id)
        {
            if (id == 0)
            {
                OnGet();
                return;
            }
            try
            {
                partOfStory = _context.PartOfStories.FirstOrDefault(i => i.Id == id);
                string[] subsequent = partOfStory.SubsequentPartsIds.Split(",");
                SubsequentParts = new List<PartOfStory>();

                if(subsequent.Length==1 && subsequent[0] == "0")
                {
                    SubsequentParts.Add(new PartOfStory() { Title = "Конец" });
                    return;
                }
                foreach (string s in subsequent)
                {
                    SubsequentParts.Add(_context.PartOfStories.FirstOrDefault(p => p.Id == Convert.ToInt32(s)));
                }
            }
            catch(Exception e)
            {
                OnGet();
            }
            
        }
    }
}
