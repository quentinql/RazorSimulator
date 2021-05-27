using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPage.Data;
using RazorPage.Models;

namespace RazorPage.Pages
{
    public class Page4Model : PageModel
    {
        private readonly RazorPage.Data.UserContext _context;

        public Page4Model(RazorPage.Data.UserContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }
        [BindProperty]
        public bool DurationLowerOneMonth { get; set; }
        [BindProperty]
        public bool DurationKnown { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var UserToUpdate = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (DurationKnown)
            {
                if (!DurationLowerOneMonth)
                {
                    UserToUpdate.MonthDuration = User.MonthDuration;
                }
                else
                {
                    UserToUpdate.MonthDuration = 0;
                }
                UserToUpdate.DayByMonthDuration = User.DayByMonthDuration;
            }
            else
            {
                UserToUpdate.MonthDuration = 1;
                UserToUpdate.DayByMonthDuration = 0;

            }
            _context.Attach(UserToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(UserToUpdate.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Page5", new { id = UserToUpdate.Id });
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
