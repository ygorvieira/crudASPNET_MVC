using LojaYgor3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaYgor3.Controllers
{
    public class ProdutoController : Controller
    {
        LojaContext contexto = new LojaContext();

        // GET: Produto
        public ActionResult Index()
        {
            var produtos = contexto.Produtos.Include(produto => produto.Cliente);
            return View(produtos.ToList());
        }

        // GET: Produto/Details/5
        public ActionResult Detalha(int id)
        {
            return GetProduto(id);
        }

        private ActionResult GetProduto(int id)
        {
            var produto = (from p in contexto.Produtos.Include(p => p.Cliente)
                           where p.Id == id
                           select p).First();
            return View(produto);
        }

        // GET: Produto/Create
        public ActionResult Adiciona()
        {
            ViewBag.ClienteId = new SelectList(contexto.Clientes, "Id", "Nome");
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        public ActionResult Adiciona(Produto produto)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    contexto.Produtos.Add(produto);
                    contexto.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.ClienteId = new SelectList(contexto.Clientes, "Id", "Nome", produto.ClienteId);
                return View(produto);
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Atualiza(int id)
        {
            return GetProdutoPorId(id);
        }


        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Atualiza(int id, Produto produto)
        {
            try
            {
                // TODO: Add update logic here
                contexto.Entry(produto).State = EntityState.Modified;
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Remove(int id)
        {
            return GetProdutoPorId(id);
        }

        // POST: Produto/Delete/5
        [HttpPost]
        public ActionResult Remove(int id, Produto produto)
        {
            try
            {
                // TODO: Add delete logic here
                produto = contexto.Produtos.Find(id);
                contexto.Produtos.Remove(produto);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private ActionResult GetProdutoPorId(int id)
        {
            var produto = (from p in contexto.Produtos.Include(p => p.Cliente)
                           where p.Id == id
                           select p).First();
            ViewBag.ClienteId = new SelectList(contexto.Clientes, "Id", "Nome", produto.ClienteId);
            return View(produto);
        }
    }
}
