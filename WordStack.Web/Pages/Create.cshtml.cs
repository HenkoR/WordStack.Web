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
        public SelectList WordSL { get; set; }
        [BindProperty]
        public Sentence Sentence { get; set; }

        [BindProperty]
        public Word Word { get; set; }

        [BindProperty(SupportsGet = true)]
        public int wordTypeId { get; set; }
        public int wordId { get; set; }

        public CreateModel(ILogger<CreateModel> logger, IWordStackClient context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            await BindWordTypeDropDown();
        }

        public async Task<JsonResult> OnGetWords()
        {
            var s = new JsonResult(await _context.Words(wordTypeId));
            return new JsonResult(await _context.Words(wordTypeId));
        }

        async Task BindWordTypeDropDown()
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
                await BindWordTypeDropDown();
                return Page();
            }
        }
    }
}
