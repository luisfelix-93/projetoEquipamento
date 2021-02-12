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
    public class ReservasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Reservas
        public ActionResult Index()
        {
            List<Reserva> ListaReservas = db.Reserva.ToList();
            foreach (var item in ListaReservas)
            {
                if (item.Funcionario_Id != 0)
                {
                    item.Nome = db.Funcionarios.Where(x => x.FuncionarioId == item.Funcionario_Id).ToList().FirstOrDefault().Nome;
                    item.Usuario = db.Funcionarios.Where(x => x.FuncionarioId == item.Funcionario_Id).ToList().FirstOrDefault().Usuario;
                    item.Setor = db.Funcionarios.Where(x => x.FuncionarioId == item.Funcionario_Id).ToList().FirstOrDefault().Setor;
                }




                if (item.Equipamento_Id != 0)
                {
                    item.EquipamentoNome = db.Equipamento.Where(x => x.EquipamentoId == item.Equipamento_Id).ToList().FirstOrDefault().EquipamentoNome;
                }

            }
            return View(ListaReservas);
        }

        // GET: Reservas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // GET: Reservas/Create
        public ActionResult Create()
        {
            ViewBag.Funcionarios = db.Funcionarios.ToList().OrderBy(x => x.FuncionarioId);
            ViewBag.Equipamentos = db.Equipamento.ToList().OrderBy(x => x.EquipamentoId);
            return View();
        }

        // POST: Reservas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservaId,Funcionario_Id,Equipamento_Id")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Reserva.Add(reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservaId,FuncionarioId,EquipamentoId")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reserva reserva = db.Reserva.Find(id);
            db.Reserva.Remove(reserva);
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
