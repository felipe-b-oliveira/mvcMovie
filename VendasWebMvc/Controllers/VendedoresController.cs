using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vendasWebMvc.Servicos;

namespace vendasWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        //Dependência para o VendedorServico
        private readonly VendedorServico _vendedorServico;
        
        //Criacao do construtor para a Injeção de Dependência
        public VendedoresController(VendedorServico vendedorServico)
        {
            _vendedorServico = vendedorServico;
        }

        public IActionResult Index() //1. O controlador foi chamado
        {
            var list = _vendedorServico.FindAll(); //2. Retorna uma lista de vendedores
            return View(list); //3. Passa a lista como um argumento
        }
    }
}