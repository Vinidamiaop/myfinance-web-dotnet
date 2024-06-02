
using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet.Controllers
{
    [Route("[controller]")]
    public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;
        private readonly IPlanoContaService _planoContaService;


        public PlanoContaController(ILogger<PlanoContaController> logger, IPlanoContaService planoContaService)
        {
            _logger = logger;
            _planoContaService = planoContaService;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            var listaPlanoContas = _planoContaService.ListarRegistros();
            List<PlanoContaModel> listaPlanoContasModel = new List<PlanoContaModel>();
            listaPlanoContasModel.AddRange(listaPlanoContas.Select(x => new PlanoContaModel
            {
                Id = x.Id,
                Descricao = x.Descricao,
                Tipo = x.Tipo
            }));

            ViewBag.ListaPlanoConta = listaPlanoContasModel;

            return View();
        }

        [HttpGet("Cadastrar/{Id?}/")]
        public IActionResult Cadastrar(int? Id)
        {
            if (Id != null)
            {
                var planoConta = _planoContaService.RetornarRegistro((int)Id);
                var planoContaModel = new PlanoContaModel
                {
                    Id = planoConta.Id,
                    Descricao = planoConta.Descricao,
                    Tipo = planoConta.Tipo
                };

                return View(planoContaModel);
            }

            return View();
        }

        [HttpPost("Cadastrar/{Id?}/")]
        public IActionResult Cadastrar(PlanoContaModel model)
        {
            // if (!ModelState.IsValid)
            // {
            //     return View();
            // }
            
            var planoConta = new PlanoConta()
            {
                Id = model.Id,
                Descricao = model.Descricao,
                Tipo = model.Tipo
            };

            _planoContaService.Cadastrar(planoConta);

            return RedirectToAction("Index");
        }

        [HttpGet("Excluir/{Id}/")]
        public IActionResult Excluir(int Id)
        {
            _planoContaService.Excluir(Id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}