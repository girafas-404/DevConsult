using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using cp4_Projeto.Models;

namespace cp4_Projeto.Controllers
{
    [Authorize(Roles = "TechLider")]
    public class AdminController : Controller
    {
        // Dashboard - lista todas as solicitações pendentes
        public IActionResult Dashboard()
        {
            var solicitacoes = HomeController.GetSolicitacoes();
            return View(solicitacoes);
        }

        // Aprovar solicitação
        [HttpPost]
        public IActionResult Aprovar(int id)
        {
            var solicitacoes = HomeController.GetSolicitacoes();
            var s = solicitacoes.FirstOrDefault(x => x.Id == id);
            if (s != null)
            {
                s.Status = StatusSolicitacao.Aprovada;
                s.Observacao = "Solicitação aprovada pelo Tech Leader.";
                TempData["Mensagem"] = $"✅ Solicitação #{id} de {s.NomeCliente} foi APROVADA.";
            }
            return RedirectToAction("Dashboard");
        }

        // Reprovar solicitação
        [HttpPost]
        public IActionResult Reprovar(int id)
        {
            var solicitacoes = HomeController.GetSolicitacoes();
            var s = solicitacoes.FirstOrDefault(x => x.Id == id);
            if (s != null)
            {
                s.Status = StatusSolicitacao.Reprovada;
                s.Observacao = "Solicitação reprovada pelo Tech Leader.";
                TempData["Mensagem"] = $"❌ Solicitação #{id} de {s.NomeCliente} foi REPROVADA.";
            }
            return RedirectToAction("Dashboard");
        }

        // Encaminhar para WhatsApp do dev disponível
        [HttpPost]
        public IActionResult EnviarWhatsApp(int id)
        {
            var solicitacoes = HomeController.GetSolicitacoes();
            var s = solicitacoes.FirstOrDefault(x => x.Id == id);
            if (s != null)
            {
                s.Status = StatusSolicitacao.EnviadaWhatsApp;
                s.Observacao = "Encaminhado ao desenvolvedor disponível via WhatsApp.";
                TempData["Mensagem"] = $"📱 Solicitação #{id} encaminhada ao dev via WhatsApp.";
            }
            return RedirectToAction("Dashboard");
        }
    }
}
