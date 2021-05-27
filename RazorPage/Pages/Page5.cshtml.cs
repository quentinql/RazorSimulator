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
    public class Page5Model : PageModel
    {
        private readonly RazorPage.Data.UserContext _context;

        public Page5Model(RazorPage.Data.UserContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }
        public enum Civilities
        {
            Mr,
            Mme,
            Mlle,
            Other
        }

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
            UserToUpdate.Civility = User.Civility;
            UserToUpdate.Lastname = User.Lastname;
            UserToUpdate.Firstname = User.Firstname;
            UserToUpdate.Email = User.Email;
            UserToUpdate.Telephone = User.Telephone;
            UserToUpdate.ConfidentialityPoliticAccepted = User.ConfidentialityPoliticAccepted;
            UserToUpdate.MarketingOfferAccepted = User.MarketingOfferAccepted;
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

            return RedirectToPage("./Page6", new { id = UserToUpdate.Id });
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
