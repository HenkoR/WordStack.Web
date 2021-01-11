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
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IWordStackClient _context;

        public IEnumerable<Sentence> Sentences { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IWordStackClient context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Sentences = await _context.Sentences();
        }
    }
}
