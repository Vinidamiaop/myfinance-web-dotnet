
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet.Controllers
{
    [Route("[controller]")]
    public class TransacaoController : Controller
    {
        private readonly ILogger<TransacaoController> _logger;
        private readonly ITransacaoService _transacaoService;
        private readonly IPlanoContaService _planoContaService;


        public TransacaoController(
            ILogger<TransacaoController> logger, 
            ITransacaoService transacaoService,
            IPlanoContaService planoContaService)
        {
            _logger = logger;
            _transacaoService = transacaoService;
            _planoContaService = planoContaService;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            var listaTransacao = _transacaoService.ListarRegistros();
            List<TransacaoModel> listaTransacaoModel = new List<TransacaoModel>();
            listaTransacaoModel.AddRange(listaTransacao.Select(x => new TransacaoModel
            {
                Id = x.Id,
                Valor = x.Valor,
                Data = x.Data,
                Historico = x.Historico,
                PlanoContaId = x.PlanoContaId,
                PlanoConta = x.PlanoConta
            }));

            ViewBag.ListaTransacao = listaTransacaoModel;

            return View();
        }

        [HttpGet("Cadastrar/{Id?}/")]
        public IActionResult Cadastrar(int? Id)
        {
            var listaPlanoContas = new SelectList(_planoContaService.ListarRegistros(), "Id", "Descricao");
            var transacaoModel = new TransacaoModel()
            {
                Data = DateTime.Now,
                ListaPlanoContas = listaPlanoContas
            };
            if (Id != null)
            {
                var transacao = _transacaoService.RetornarRegistro((int)Id);

                transacaoModel.Id = transacao.Id;
                transacaoModel.Valor = transacao.Valor;
                transacaoModel.Data = transacao.Data;
                transacaoModel.Historico = transacao.Historico;
                transacaoModel.PlanoContaId = transacao.PlanoContaId;
            }

            return View(transacaoModel);
        }

        [HttpPost("Cadastrar/{Id?}/")]
        public IActionResult Cadastrar(TransacaoModel model)
        {
            // if (!ModelState.IsValid)
            // {
            //     return View();
            // }

            var transacao = new Transacao
            {
                Id = model.Id,
                Valor = model.Valor,
                Data = model.Data,
                Historico = model.Historico,
                PlanoContaId = model.PlanoContaId
            };

            _transacaoService.Cadastrar(transacao);

            return RedirectToAction("Index");
        }

        [HttpGet("Excluir/{Id}/")]
        public IActionResult Excluir(int Id)
        {
            _transacaoService.Excluir(Id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}