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
    public class Page2Model : PageModel
    {
        private readonly RazorPage.Data.UserContext _context;

        public Page2Model(RazorPage.Data.UserContext context)
        {
            _context = context;
        }

        [BindProperty]
        public new User User { get; set; }
        [BindProperty]
        public List<SelectListItem> PriceTypes { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.Users.FindAsync(id);
            if (User == null)
            {
                return NotFound();
            }
            PriceTypes = new List<SelectListItem>()
            {
                new SelectListItem() { Text="J'ai un tarif journalier", Value="DayPrice" },
                new SelectListItem() { Text="J'ai un tarif horaire", Value="HourPrice" },
                new SelectListItem() { Text="J'ai un tarif mensuel", Value="MonthPrice" },
                new SelectListItem() { Text="J'ai un chiffre d'affaire", Value="TurnOver" },
                new SelectListItem() { Text="Je ne connais pas mon tarif", Value="NotKnowPrice" }
            };
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var UserToUpdate = await _context.Users.FindAsync(id);
            if (UserToUpdate == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Console.WriteLine(UserToUpdate.Id);
            Console.WriteLine(UserToUpdate.ResidenceCountry);
            UserToUpdate.PriceType = User.PriceType;
            _context.Attach(UserToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(User.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Page3", new { id = UserToUpdate.Id });
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
