using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vendasWebMvc.Services;
using vendasWebMvc.Models;
using vendasWebMvc.Models.ViewModels;
using vendasWebMvc.Services.Exceptions;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace vendasWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        // Dependência para o servicoVendedor
        private readonly VendedorService _vendedorService;
        private readonly DepartamentoService _departamentoService;

        // Criacao do construtor para a Injeção de Dependência
        // Desde modo o servico departamento será injetado no objeto servico vendedor
        public VendedoresController(VendedorService servicoVendedor, DepartamentoService servicoDepartamento)
        {
           _vendedorService = servicoVendedor;
           _departamentoService = servicoDepartamento;
        }

        // Operacao assincrona
        public async Task<IActionResult> Index() //1. O controlador foi chamado
        {
            var list = await _vendedorService.FindAllAsync(); //2. Retorna uma lista de vendedores
            return View(list); //3. Passa a lista como um argumento
        }

        // Operacao assincrona
        public async Task<IActionResult> Create()
        {
            var departamentos = await _departamentoService.FindAllAsync();
            var viewModel = new FormViewModelVendedor { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Operacao assincrona
        public async Task<IActionResult> Create(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = await _departamentoService.FindAllAsync();
                var viewModel = new FormViewModelVendedor { vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }

           await _vendedorService.InsertAsync(vendedor);

            // Retorna para a página index
            return RedirectToAction(nameof(Index));
        }

        // Operacao assincrona
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _vendedorService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        // Indica que a ação é de POST e não de GET
        [HttpPost]
        // Proteção contra ataques CSRF
        [ValidateAntiForgeryToken]
        // Operacao assincrona
        public async Task<IActionResult> Delete(int id)
        {
            await _vendedorService.RemoveAsync(id);

            // Retorna para a página index
            return RedirectToAction(nameof(Index));

        }

        // Operacao assincrona
        public async Task<IActionResult> Details (int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _vendedorService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        // Operacao assincrona
        public async Task<IActionResult> Edit (int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _vendedorService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            List<Departamento> departamentos = await _departamentoService.FindAllAsync();
            FormViewModelVendedor viewModel = new FormViewModelVendedor { vendedor = obj, Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Operacao assincrona
        public async Task<IActionResult> Edit(int id, Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = await _departamentoService.FindAllAsync();
                var viewModel = new FormViewModelVendedor { vendedor = vendedor, Departamentos = departamentos};
                return View(viewModel);
            }

            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Ids não correspondem" });
            }
            
            try
            {
                await _vendedorService.UpdateAsync(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch(ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error (string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                // Pegar o ID interno da requisição Http
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);          
        }
    }
}