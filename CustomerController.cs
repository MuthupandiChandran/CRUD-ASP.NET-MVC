using System.Web.Mvc;
using Nivi.Models;
using Nivi.Models.Repository;


namespace SatyaMvc4Crud.Controllers
{
    public class CustomerController : Controller
    {
        readonly Dal dal = new Dal();
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(dal.GetDataList());
        }
        public ActionResult Details(int id)
        {
            return View(dal.GetDataList().Find(ur => ur.id == id));
        }
        public ActionResult Create()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]

        public ActionResult Create(Customer ur)
        {
            try
            {
                if (dal.InsertData(ur))
                {
                    ViewBag.Message = "Data Saved";
                    
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            return View(dal.GetDataList().Find(ur => ur.id == id));
        }
        [HttpPost]
        public ActionResult Edit(int id, Customer ur)
        {
            try
            {
                if (dal.UpdateData(ur))
                {
                    ViewBag.Message = "Data Updated";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            return View(dal.GetDataList().Find(ur => ur.id == id));

        }
        [HttpPost]
        public ActionResult Delete(Customer ur )
        {
            try
            {
                if (dal.DeleteData(ur))
                {
                    ViewBag.Message = "Data Deleted";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
