using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConstructoraUdc.Mapper.SecurityModule;
using ConstructoraUdc.Models.SecurityModule;
using ConstructoraUdcController.DTO.SecurityModule;
using ConstructoraUdcController.Implementation.SecurityModule;

using ConstructoraUdcModel.Model;

namespace ConstructoraUdc.Controllers.SecurityModule
{
    public class RoleController : Controller
    {
        private ConstructoraUdcController.Implementation.SecurityModule.RoleImpController controller = new ConstructoraUdcController.Implementation.SecurityModule.RoleImpController();

        // GET: Role
        public ActionResult Index(string filter = "")
        {
            return View(controller.RecordList(filter));
        }

        // GET: Role/Details/5
        

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,removed,description")] RoleModel model)
        {
            if (ModelState.IsValid)
            {
                RoleModelMapper mapper = new RoleModelMapper();
                RoleDTO dto = mapper.MapperT2T1(model);
                controller.RecordCreation(dto);
                int response = controller.RecordCreation(dto);
                return RedirectToAction("Index");
            }

            return View(model);
        }
        /*
        // GET: Role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEC_Role sEC_Role = controller.SEC_Role.Find(id);
            if (sEC_Role == null)
            {
                return HttpNotFound();
            }
            return View(sEC_Role);
        }

        // POST: Role/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,removed,description")] SEC_Role sEC_Role)
        {
            if (ModelState.IsValid)
            {
                controller.Entry(sEC_Role).State = EntityState.Modified;
                controller.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sEC_Role);
        }

        // GET: Role/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEC_Role sEC_Role = controller.SEC_Role.Find(id);
            if (sEC_Role == null)
            {
                return HttpNotFound();
            }
            return View(sEC_Role);
        }

        // POST: Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SEC_Role sEC_Role = controller.SEC_Role.Find(id);
            controller.SEC_Role.Remove(sEC_Role);
            controller.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                controller.Dispose();
            }
            base.Dispose(disposing);
        }
        */
    }
}
