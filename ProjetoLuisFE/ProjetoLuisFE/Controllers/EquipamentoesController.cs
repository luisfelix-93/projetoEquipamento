using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoLuisFE.Models;

namespace ProjetoLuisFE.Controllers
{
    public class EquipamentoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Equipamentoes
        public ActionResult Index()
        {
            return View(db.Equipamento.ToList());
        }

        // GET: Equipamentoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipamento equipamento = db.Equipamento.Find(id);
            if (equipamento == null)
            {
                return HttpNotFound();
            }
            return View(equipamento);
        }

        // GET: Equipamentoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipamentoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EquipamentoId,EquipamentoNome,Serie")] Equipamento equipamento)
        {
            if (ModelState.IsValid)
            {
                db.Equipamento.Add(equipamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipamento);
        }

        // GET: Equipamentoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipamento equipamento = db.Equipamento.Find(id);
            if (equipamento == null)
            {
                return HttpNotFound();
            }
            return View(equipamento);
        }

        // POST: Equipamentoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EquipamentoId,EquipamentoNome,Serie")] Equipamento equipamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipamento);
        }

        // GET: Equipamentoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipamento equipamento = db.Equipamento.Find(id);
            if (equipamento == null)
            {
                return HttpNotFound();
            }
            return View(equipamento);
        }

        // POST: Equipamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipamento equipamento = db.Equipamento.Find(id);
            db.Equipamento.Remove(equipamento);
            db.SaveChanges();
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
