using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WordStack.Web.Models;

namespace WordStack.Web.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;
        private readonly IWordStackClient _context;

        public SelectList WordTypeSL { get; set; }
        [BindProperty]
        public Sentence Sentence { get; set; }

        [BindProperty]
        public Word Word { get; set; }

        public CreateModel(ILogger<CreateModel> logger, IWordStackClient context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            await BindDropDown();
        }

        async Task BindDropDown()
        {
            var wordTypesQuery = await _context.WordTypes();
            WordTypeSL = new SelectList(wordTypesQuery.ToList(), "Id", "StringValue");
        }

        public async Task<IActionResult> OnPostSaveSentenceAsync()
        {
            try
            {
                await _context.AddNewSentence(Sentence);
                return RedirectToPage("./Index");
            }
            catch
            {
                await BindDropDown();
                return Page();
            }
        }
    }
}
