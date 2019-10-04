using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vendasWebMvc.Services;
using vendasWebMvc.Models;
using vendasWebMvc.Models.ViewModels;

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
            _servicoVendedor.Insert(vendedor);

            // Retorna para a página index
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _servicoVendedor.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
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
    }
}