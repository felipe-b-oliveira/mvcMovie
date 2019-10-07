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

namespace vendasWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        // Dependência para o servicoVendedor
        private readonly ServicoVendedor _servicoVendedor;
        private readonly ServicoDepartamento _servicoDepartamento;

        // Criacao do construtor para a Injeção de Dependência
        // Desde modo o servico departamento será injetado no objeto servico vendedor
        public VendedoresController(ServicoVendedor servicoVendedor, ServicoDepartamento servicoDepartamento)
        {
            _servicoVendedor = servicoVendedor;
            _servicoDepartamento = servicoDepartamento;
        }

        public IActionResult Index() //1. O controlador foi chamado
        {
            var list = _servicoVendedor.FindAll(); //2. Retorna uma lista de vendedores
            return View(list); //3. Passa a lista como um argumento
        }

        public IActionResult Create()
        {
            var departamentos = _servicoDepartamento.FindAll();
            var viewModel = new FormViewModelVendedor { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = _servicoDepartamento.FindAll();
                var viewModel = new FormViewModelVendedor { vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }

            _servicoVendedor.Insert(vendedor);

            // Retorna para a página index
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = _servicoVendedor.FindById(id.Value);
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
        public IActionResult Delete(int id)
        {
            _servicoVendedor.Remove(id);

            // Retorna para a página index
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Details (int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = _servicoVendedor.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        public IActionResult Edit (int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = _servicoVendedor.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            List<Departamento> departamentos = _servicoDepartamento.FindAll();
            FormViewModelVendedor viewModel = new FormViewModelVendedor { vendedor = obj, Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = _servicoDepartamento.FindAll();
                var viewModel = new FormViewModelVendedor { vendedor = vendedor, Departamentos = departamentos};
                return View(viewModel);
            }

            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Ids não correspondem" });
            }
            
            try
            {
                _servicoVendedor.Update(vendedor);
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