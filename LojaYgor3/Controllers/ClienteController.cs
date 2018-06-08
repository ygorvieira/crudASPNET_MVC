using LojaYgor3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaYgor3.Controllers
{
    public class ClienteController : Controller
    {
        LojaContext contexto = new LojaContext();
        
        // GET: Cliente
        public ActionResult Index()
        {
            return View(contexto.Clientes.ToList());
        }

        // GET: Cliente/Details/5
        public ActionResult Detalha(int id)
        {
            return GetCliente(id);
        }        

        // GET: Cliente/Create
        public ActionResult Adiciona()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Adiciona(Cliente cliente)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    contexto.Clientes.Add(cliente);
                    contexto.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Atualiza(int id)
        {
            return GetCliente(id);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Atualiza(int id, Cliente cliente)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    contexto.Entry(cliente).State = EntityState.Modified;
                    contexto.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Remove(int id)
        {
            return GetCliente(id);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Remove(int id, Cliente cliente)
        {
            try
            {
                // TODO: Add delete logic here
                cliente = contexto.Clientes.Find(id);
                contexto.Clientes.Remove(cliente);
                contexto.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        private ActionResult GetCliente(int id)
        {
            var cliente = (from c in contexto.Clientes
                           where c.Id == id
                           select c).First();
            return View(cliente);
        }
    }
}
