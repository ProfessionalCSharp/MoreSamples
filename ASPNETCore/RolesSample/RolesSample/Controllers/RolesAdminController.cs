using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RolesSample.Controllers
{
    [Authorize(Roles = "Admins")]
    public class RolesAdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        // private readonly UserManager<IdentityUser> _userManager;
        public RolesAdminController(RoleManager<IdentityRole> roleManager)
            // , UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            // _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var identityRoles = await _roleManager.Roles.ToListAsync();
            return View(identityRoles);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Tests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name, NormalizedName")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                await _roleManager.CreateAsync(role);

                // sample code how to add the current user to a role
                //var user = await _userManager.GetUserAsync(User);
                //var result = await _userManager.AddToRoleAsync(user, role.Name);

                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }
    }
}
