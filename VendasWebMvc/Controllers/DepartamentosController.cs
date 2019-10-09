using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using vendasWebMvc.Models;
using vendasWebMvc.Services;

namespace vendasWebMvc.Controllers
{
    public class DepartamentosController : Controller
    {
        // Dependencia da classe de banco
        private readonly DepartamentoService _departamentoService;

        // Controle para injecao de dependência
        public DepartamentosController(DepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        // GET: Departamentos
        public async Task<IActionResult> Index()
        {
            // A classe Departamento não está configurada para os serviços pois foi a primeira do exercício
            // Tentei configurar a mesma, mas parei na parte do argumento Departamento implementado na classe Vendedor
            var list = await _departamentoService.FindAllAsync();
            return View(list);
        }

        // GET: Departamentos/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _departamentoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // GET: Departamentos/Create -> Nova View Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departamentos/Create - > Novo Departamento
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Departamento departamento)
        {
            await _departamentoService.InsertAsync(departamento);
            return RedirectToAction(nameof(Index));
        }

        // GET: Departamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _departamentoService.FindByIdAsync(id.Value);
            if (departamento == null)
            {
                return NotFound();
                //return RedirectToAction(nameof(Error), new { message = "Departamento não encontrado" });
            }
            return View(departamento);
        }

        // POST: Departamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Departamento departamento)
        {
            if (id != departamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _departamentoService.UpdateAsync(departamento);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_departamentoService.DepartamentoExists(departamento.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(departamento);
        }

        // GET: Departamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _departamentoService.FindByIdAsync(id.Value);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _departamentoService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
        
    }
}
