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
        public ActionResult Details(int id)
        {
            var UserProfile = _userRepo.Details(id);
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
        public  ActionResult Create(UserProfile entity)
        {
            try
            {
                if(ModelState.IsValid)
                {
                     _userRepo.Create(entity);
                     _userRepo.Save();
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
        public ActionResult Edit(int id)
        {
            var UserProfile = _userRepo.Details(id);
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
                return View(entity);
            }
            catch
            {
                return View();
            }
            return View(entity);
        }

        // GET: UserManagerController/Delete/5
        public ActionResult Delete(int id)
        {
            var userProfile = _userRepo.Details(id);
            return View(userProfile);
        }

        // POST: UserManagerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            try
            {
                _userRepo.Details(id);
                _userRepo.Delete(id);
                _userRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidDataException) 
            {
                return View();
            }
        }
    }
}
