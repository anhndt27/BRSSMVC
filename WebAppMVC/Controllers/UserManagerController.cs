using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebAppMVC.Data.Context;
using WebAppMVC.Data.Entities;
using WebAppMVC.Data.Interface;
using WebAppMVC.Data.Repository;
using WebAppMVC.Service.Interface;

namespace WebAppMVC.Controllers
{
    public class UserManagerController : Controller
    {
        //protected readonly IUserService _userService;
        private readonly IUserRepo _userRepo;
        //public UserManagerController(IUserService userService)
        //{ 
        //    _userService = userService;

        //}

        //public UserManagerController(IUserRepo userRepo) => this._userRepo = new UserRepo(new AppDbContext());

        public UserManagerController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }



        // GET: UserManagerController
        [HttpGet("/UserManager/Index")]
        public async Task<IActionResult> Index()
        {
            var _userProfile = await _userRepo.GetAll();
            return View(_userProfile);
        }

        // GET: UserManagerController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var UserProfile = await _userRepo.Details(id);
            return View(UserProfile);
        }

        // GET: UserManagerController/Create
        
        public ActionResult Create()
        {
           
            return View(new UserProfile());
        }

        // POST: UserManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<ActionResult> Create(UserProfile entity)
        {
            try
            {
                if(ModelState.IsValid)
                {
                     await _userRepo.Create(entity);
                     await _userRepo.Save();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
              
            }
            return View(entity);
        }

        // GET: UserManagerController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var UserProfile = await _userRepo.Details(id);
            return View(UserProfile);   
        }

        // POST: UserManagerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserProfile entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepo.Edit(entity);
                    _userRepo.Save();
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(entity);
        }

        // GET: UserManagerController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var userProfile = await _userRepo.Details(id);
            return View(userProfile);
        }

        // POST: UserManagerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                var res = await _userRepo.Details(id);
                await _userRepo.Delete(id);
                await _userRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidDataException) 
            {
                return View();
            }
        }
    }
}
