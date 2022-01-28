using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using BlogApplication.Data;

namespace BlogApplication.Controllers
{
    [Authorize/*(Roles ="Admin")*/]
    public class AdminPanelController : Controller
    {
        private readonly BlogDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AdminPanelController(BlogDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var UserModel = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (UserModel == null)
            {
                return NotFound();
            }

            return View(UserModel);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var UserModel = await _context.Users.FindAsync(id);
            _context.Users.Remove(UserModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserModelExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
