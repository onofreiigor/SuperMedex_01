using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MedexDbModel;

namespace Medex_gentilella_v1.Controllers
{
    public class VaccinesController : Controller
    {
        private SuperMedex_01Entities db = new SuperMedex_01Entities();

        // GET: Vaccines
        public async Task<ActionResult> Index()
        {
            return View(await db.Vaccines.ToListAsync());
        }

        // GET: Vaccines/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaccine vaccine = await db.Vaccines.FindAsync(id);
            if (vaccine == null)
            {
                return HttpNotFound();
            }
            return View(vaccine);
        }

        // GET: Vaccines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vaccines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VaccineID,Description,TypeID")] Vaccine vaccine)
        {
            if (ModelState.IsValid)
            {
                db.Vaccines.Add(vaccine);
                await db.SaveChangesAsync();
                return RedirectToAction("Create");
            }

            return View(vaccine);
        }

        // GET: Vaccines/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaccine vaccine = await db.Vaccines.FindAsync(id);
            if (vaccine == null)
            {
                return HttpNotFound();
            }
            return View(vaccine);
        }

        // POST: Vaccines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VaccineID,Description,TypeID")] Vaccine vaccine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaccine).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vaccine);
        }

        // GET: Vaccines/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaccine vaccine = await db.Vaccines.FindAsync(id);
            if (vaccine == null)
            {
                return HttpNotFound();
            }
            return View(vaccine);
        }

        // POST: Vaccines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Vaccine vaccine = await db.Vaccines.FindAsync(id);
            db.Vaccines.Remove(vaccine);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
