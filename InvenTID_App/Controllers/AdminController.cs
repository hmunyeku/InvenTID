using Microsoft.AspNet.Identity.EntityFramework;
using InvenTID_App;
using InvenTID_App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using PagedList;

namespace InvenTID_App.Controllers
{
    [RBAC]
    public class AdminController : Controller
    {
        private RBACDbContext database = new RBACDbContext();

        #region USERS
        // GET: Admin
        public ActionResult Index()
        {            
            return View(ApplicationUserManager.GetUsers());
        }

        public ViewResult UserDetails(int id)
        {
            ApplicationUser user = ApplicationUserManager.GetUser(id);
            SetViewBagData(id);
            return View(user);
        }

        [HttpGet]
        public ActionResult UserEdit(int id)
        {
            ApplicationUser user = ApplicationUserManager.GetUser(id);
            SetViewBagData(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult UserEdit(UserViewModel user)
        {
          bool retval =  ApplicationUserManager.UpdateUser(user);

            ApplicationUser _user = ApplicationUserManager.GetUser(user.Id);
            if (retval)
                AuditHelpers.AppEventInfo("", String.Format("Success editing User \"{0}\"<{1}>", _user.UserName, _user.Email));
            else
                AuditHelpers.AppEventInfo("", String.Format("Error editing User \"{0}\"<{1}>", _user.UserName, _user.Email));
            
            return RedirectToAction("UserDetails", new RouteValueDictionary(new { id = user.Id }));
        }

        [HttpPost]
        public ActionResult UserDetails(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser _user = ApplicationUserManager.GetUserByName(user.UserName);
                //database.Entry(_user).Entity.Inactive = user.Inactive;
                database.Entry(_user).Entity.LastModified = System.DateTime.Now;
                database.Entry(_user).State = EntityState.Modified;
                database.SaveChanges();
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult DeleteUserRole(int id, int userId)
        {
            ApplicationUserManager.RemoveUser4Role(userId, id);
            return RedirectToAction("Details", "USER", new { id = userId });
        }

        [HttpGet]
        public PartialViewResult filter4Users(string _surname)
        {
            return PartialView("_ListUserTable", GetFilteredUserList(_surname));
        }

        [HttpGet]
        public PartialViewResult filterReset()
        {
            return PartialView("_ListUserTable", ApplicationUserManager.GetUsers());
        }

        [HttpGet]
        public PartialViewResult DeleteUserReturnPartialView(int userId)
        {
            ApplicationUserManager.DeleteUser(userId);
            
            ApplicationUser _user = ApplicationUserManager.GetUser(userId);
            
            AuditHelpers.AppEventInfo(AppSession.Profile.Id.ToString(), String.Format("Delete User \"{0}\"<{1}>", _user.UserName, _user.Email));

            return this.filterReset();
        }

        private IEnumerable<ApplicationUser> GetFilteredUserList(string _surname)
        {
            IEnumerable<ApplicationUser> _ret = null;
            try
            {
                if (string.IsNullOrEmpty(_surname))
                {
                    _ret = ApplicationUserManager.GetUsers();
                }
                else
                {
                    _ret = ApplicationUserManager.GetUsers4Surname(_surname);
                }
            }
            catch
            {
            }
            return _ret;
        }

        protected override void Dispose(bool disposing)
        {
            database.Dispose();
            base.Dispose(disposing);
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult DeleteUserRoleReturnPartialView(int id, int userId)
        {
            ApplicationUserManager.RemoveUser4Role(userId, id);
            SetViewBagData(userId);

            ApplicationUser _user = ApplicationUserManager.GetUser(userId);
            ApplicationRole _role = database.Roles.Where(p => p.Id == id).FirstOrDefault();
            AuditHelpers.AppEventInfo(AppSession.Profile.Id.ToString(), String.Format("Remove User <{0}> from Role <{1}>", _user.UserName, _role.Name));
            
            return PartialView("_ListUserRoleTable", ApplicationUserManager.GetUser(userId));
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult AddUserRoleReturnPartialView(int id, int userId)
        {

            ApplicationUserManager.AddUser2Role(userId, id);
            
            SetViewBagData(userId);
            return PartialView("_ListUserRoleTable", ApplicationUserManager.GetUser(userId));
        }

        private void SetViewBagData(int _userId)
        {
            SetViewBagData(_userId.ToString());
        }

        private void SetViewBagData(string _userId)
        {
            ViewBag.UserId = _userId;
            ViewBag.List_boolNullYesNo = this.List_boolNullYesNo();
            ViewBag.RoleId = new SelectList(ApplicationRoleManager.GetRoles4SelectList(), "Id", "Name");            
        }

        public List<SelectListItem> List_boolNullYesNo()
        {
            var _retVal = new List<SelectListItem>();
            try
            {
                _retVal.Add(new SelectListItem { Text = "Not Set", Value = null });
                _retVal.Add(new SelectListItem { Text = "Yes", Value = bool.TrueString });
                _retVal.Add(new SelectListItem { Text = "No", Value = bool.FalseString });
            }
            catch { }
            return _retVal;
        }
        #endregion

        #region ROLES
        public ActionResult RoleIndex()
        {          
            List<ApplicationRole> _roles = ApplicationRoleManager.GetRoles();
            return View(_roles);
        }

        public ViewResult RoleDetails(int id)
        {

            ApplicationRole _role = ApplicationRoleManager.GetRole(id);
            RoleViewModel model = new RoleViewModel();
            if (_role != null)
            {
                model.Id = _role.Id;
                model.RoleName = _role.Name;
                model.RoleDescription = _role.RoleDescription;
            }  
            // USERS combo
            ViewBag.UserId = new SelectList(ApplicationUserManager.GetUsers4SelectList(), "Id", "UserName");
            ViewBag.RoleId = id;

            // Rights combo
            ViewBag.PermissionId = new SelectList(ApplicationRoleManager.GetPermissions4SelectList(), "PermissionId", "PermissionDescription");
            ViewBag.List_boolNullYesNo = this.List_boolNullYesNo();

            return View(model);
        }

        public ActionResult RoleCreate()
        {
            ViewBag.List_boolNullYesNo = this.List_boolNullYesNo();
            return View();
        }

        [HttpPost]
        public ActionResult RoleCreate(RoleViewModel _role)
        {
            if (ModelState.IsValid)
            {
                //if (_role.RoleDescription == null)
                //{
                //    ModelState.AddModelError("Role Description", "Role Description must be entered");
                //}

                ApplicationRole role = new ApplicationRole(_role.RoleName, _role.RoleDescription);
                role.IsSysAdmin = _role.IsSysAdmin;


                ApplicationRoleManager.CreateRole(role);
                return RedirectToAction("RoleIndex");
            }
            ViewBag.List_boolNullYesNo = this.List_boolNullYesNo();
            return View(_role);
        }


        public ActionResult RoleEdit(int id)
        {                           
            ApplicationRole _role = ApplicationRoleManager.GetRole(id);
            RoleViewModel model = new RoleViewModel();
            if (_role != null)
            {
                model.Id = _role.Id;
                model.RoleName = _role.Name;
                model.RoleDescription = _role.RoleDescription;
            }  
 
            // USERS combo
            ViewBag.UserId = new SelectList(ApplicationUserManager.GetUsers4SelectList(), "Id", "Username");
            ViewBag.RoleId = id;

            // Rights combo
            ViewBag.PermissionId = new SelectList(ApplicationRoleManager.GetPermissions4SelectList(), "PermissionId", "PermissionDescription");
            ViewBag.List_boolNullYesNo = this.List_boolNullYesNo();

            return View(model);
        }

        [HttpPost]
        public ActionResult RoleEdit(RoleViewModel _role)
        {
            if (ModelState.IsValid)
            {
                //if (string.IsNullOrEmpty(_role.RoleDescription))
                //{
                //    ModelState.AddModelError("Role Description", "Role Description must be entered");
                //}


                if (ApplicationRoleManager.UpdateRole(_role))
                    return RedirectToAction("RoleDetails", new RouteValueDictionary(new { id = _role.Id }));
            }
            // USERS combo
            ViewBag.UserId = new SelectList(ApplicationUserManager.GetUsers4SelectList(), "Id", "UserName");

            // Rights combo
            ViewBag.PermissionId = new SelectList(ApplicationRoleManager.GetPermissions4SelectList(), "PermissionId", "PermissionDescription");
            ViewBag.List_boolNullYesNo = this.List_boolNullYesNo();
            return View(_role);
        }


        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult DeleteUserFromRoleReturnPartialView(int id, int userId)
        {
            ApplicationUserManager.RemoveUser4Role(userId, id);
            return PartialView("_ListUsersTable4Role", ApplicationRoleManager.GetRole(id));
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult AddUser2RoleReturnPartialView(int id, int userId)
        {
            ApplicationUserManager.AddUser2Role(userId, id);            
            return PartialView("_ListUsersTable4Role", ApplicationRoleManager.GetRole(id));
        }

        public ActionResult RoleDelete(int id)
        {            
            ApplicationRoleManager.DeleteRole(id);
            return RedirectToAction("RoleIndex");
        }

        #endregion

        #region PERMISSIONS

        public ViewResult PermissionIndex()
        {            
            return View(ApplicationRoleManager.GetPermissions());
        }

        public ViewResult PermissionDetails(int id)
        {            
            return View(ApplicationRoleManager.GetPermission(id));
        }

        public ActionResult PermissionCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PermissionCreate(PERMISSION _permission)
        {
            if (_permission.PermissionDescription == null)
            {
                ModelState.AddModelError("Permission Description", "Permission Description must be entered");
            }

            if (ModelState.IsValid)
            {
                ApplicationRoleManager.AddPermission(_permission);
                return RedirectToAction("PermissionIndex");
            }
            return View(_permission);
        }

        public ActionResult PermissionEdit(int id)
        {
            PERMISSION _permission = ApplicationRoleManager.GetPermission(id);
            ViewBag.RoleId = new SelectList(ApplicationRoleManager.GetRoles4SelectList(), "Id", "Name");
            return View(_permission);
        }

        [HttpPost]
        public ActionResult PermissionEdit(PERMISSION _permission)
        {
            if (ModelState.IsValid)
            {
                ApplicationRoleManager.UpdatePermission(_permission);
                return RedirectToAction("PermissionDetails", new RouteValueDictionary(new { id = _permission.PermissionId }));
            }
            return View(_permission);
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult DeletePermissionReturnPartialView(int id)
        {
            ApplicationRoleManager.DeletePermission(id);
            return PartialView("_ListPermissionsTable", ApplicationRoleManager.GetPermissions());
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult AddPermission2RoleReturnPartialView(int id, int permissionId)
        {
            ApplicationRoleManager.AddPermission2Role(id, permissionId);
            return PartialView("_ListPermissions", ApplicationRoleManager.GetRole(id));
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult AddAllPermissions2RoleReturnPartialView(int id)
        {
            ApplicationRoleManager.AddAllPermissions2Role(id);
            return PartialView("_ListPermissions", ApplicationRoleManager.GetRole(id));
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult DeletePermissionFromRoleReturnPartialView(int id, int permissionId)
        {
            ApplicationRoleManager.RemovePermission4Role(id, permissionId);
            return PartialView("_ListPermissions", ApplicationRoleManager.GetRole(id));
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult DeleteRoleFromPermissionReturnPartialView(int id, int permissionId)
        {
            ApplicationRoleManager.RemovePermission4Role(id, permissionId);
            return PartialView("_ListRolesTable4Permission", ApplicationRoleManager.GetPermission(permissionId));
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult AddRole2PermissionReturnPartialView(int permissionId, int roleId)
        {
            ApplicationRoleManager.AddPermission2Role(roleId, permissionId);
            return PartialView("_ListRolesTable4Permission", ApplicationRoleManager.GetPermission(permissionId));
        }

        public ActionResult PermissionsImport()
        {
            var _controllerTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t != null
                    && t.IsPublic
                    && t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)
                    && !t.IsAbstract
                    && typeof(IController).IsAssignableFrom(t));

            var _controllerMethods = _controllerTypes.ToDictionary(controllerType => controllerType,
                    controllerType => controllerType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                    .Where(m => typeof(ActionResult).IsAssignableFrom(m.ReturnType)));

            foreach (var _controller in _controllerMethods)
            {
                string _controllerName = _controller.Key.Name;
                foreach (var _controllerAction in _controller.Value)
                {
                    string _controllerActionName = _controllerAction.Name;
                    if (_controllerName.EndsWith("Controller"))
                    {
                        _controllerName = _controllerName.Substring(0, _controllerName.LastIndexOf("Controller"));
                    }

                    string _permissionDescription = string.Format("{0}-{1}", _controllerName, _controllerActionName);
                    PERMISSION _permission = database.PERMISSIONS.Where(p => p.PermissionDescription == _permissionDescription).FirstOrDefault();
                    if (_permission == null)
                    {
                        if (ModelState.IsValid)
                        {
                            PERMISSION _perm = new PERMISSION();
                            _perm.PermissionDescription = _permissionDescription;

                            database.PERMISSIONS.Add(_perm);
                            database.SaveChanges();
                        }
                    }
                }
            }
            return RedirectToAction("PermissionIndex");
        }

        private bool ExistingActionController()
        {
            bool retval = false;
            var _controllerTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => t != null
            && t.IsPublic
            && t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)
            && !t.IsAbstract
            && typeof(IController).IsAssignableFrom(t));

            var _controllerMethods = _controllerTypes.ToDictionary(controllerType => controllerType,
                    controllerType => controllerType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                    .Where(m => typeof(ActionResult).IsAssignableFrom(m.ReturnType)));


                    
            return retval;
        }
        #endregion    

        #region SETTINGS
        public class ParamNameValue
        {
            public String Name { get; set; }
            public String Value { get; set; }
            public String Type { get; set; }
        }

        public ActionResult SettingsIndex()
        {
            var Model = database.PARAMETERS.ToList();
            return View("SettingsIndex", Model);
        }

        public ActionResult SaveSettings(List<ParamNameValue> ParamNameValues)
        {
            List<ParamNameValue> WrongParams = new List<ParamNameValue>();

            foreach (ParamNameValue Param in ParamNameValues)
            {
                if (Param.Name == null || Param.Name.Length == 0)
                    continue;

                PARAMETER Parameter = database.PARAMETERS.FirstOrDefault(s => s.Name ==  Param.Name);

                string oldValue = Parameter.Value;
                Param.Value = Param.Value == null ? "" : Param.Value;

                if (Parameter.TypeID == ParameterType.Bool)
                {
                    if (Param.Value.ToLower() == "true")
                        Param.Value = Parameter.Value = "true";
                    else
                        Param.Value = Parameter.Value = "false";
                }
                else if (Parameter.TypeID == ParameterType.SmallInteger || Parameter.TypeID == ParameterType.RadioInteger)
                {
                    long value = -1;
                    bool result = long.TryParse(Param.Value, out value);
                    Parameter.Value = result ? Param.Value : Parameter.Value;

                    if (!result)
                        WrongParams.Add(Param);
                }
                else
                {
                    Parameter.Value = Param.Value;
                }

                if (oldValue != Param.Value)
                {
                    database.Entry(Parameter).Entity.Modified = System.DateTime.Now;
                    database.Entry(Parameter).State = EntityState.Modified;
                    database.SaveChanges();
                }
            }
            ApplicationParameters AppParams = new ApplicationParameters();
            AppParams.RefreshAppParameters();

            //return RedirectToAction("SettingsIndex");
            return Json(new
            {
                Message = "Mise à jour des paramètres effectuée !",
                Html = "",
                Status = 0
            }, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region AUDITS
        public ActionResult AuditsIndex(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_asc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var audits = from s in database.AUDITS
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                audits = audits.Where(s => s.Description.ToUpper().Contains(searchString.ToUpper())
                                       || s.MemberEmail.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    audits = audits.OrderByDescending(s => s.MemberEmail);
                    break;
                case "Date":
                    audits = audits.OrderBy(s => s.Created);
                    break;
                case "date_asc":
                    audits = audits.OrderBy(s => s.Created);
                    break;
                default:  // Name descending 
                    audits = audits.OrderByDescending(s => s.Created);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View("AuditsIndex", audits.ToPagedList(pageNumber, pageSize));


            //var Model = database.AUDITS.ToList();
            //return View("AuditsIndex", Model);
        }
        public JsonResult RemoveAuditEvents(List<int> Items)
        {
            string Message = "";
            if (Items != null)
            {
                foreach (int Item in Items)
                {
                    AUDITEVENT _audit = database.AUDITS.Where(p => p.EventID == Item).FirstOrDefault();
                    database.Entry(_audit).State = EntityState.Deleted;
                }
                database.SaveChanges();
                Message = "Selected audit items have been removed successfully.";
            }
            else
            {
                foreach (var entity in database.AUDITS)
                    database.AUDITS.Remove(entity);
                database.SaveChanges();
                Message = "All audit items have been removed successfully.";
            }

            return Json(new
            {
                Message
            }, JsonRequestBehavior.AllowGet);
        }
	    #endregion
    }
}