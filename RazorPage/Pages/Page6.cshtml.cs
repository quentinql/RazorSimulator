using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPage.Data;
using RazorPage.Models;

namespace RazorPage.Pages
{
    public class Page6Model : PageModel
    {
        private readonly RazorPage.Data.UserContext _context;

        public Page6Model(RazorPage.Data.UserContext context)
        {
            _context = context;
        }

        public User User { get; set; }
        public Simulator Simulator { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            Simulator = new Simulator(User);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
