using Microsoft.AspNetCore.Mvc;
using cp4_Projeto.Models;

namespace cp4_Projeto.Controllers
{
    public class HomeController : Controller
    {
        // Simulação de banco de dados em memória
        private static readonly List<Problema> _problemas = new()
        {
            new Problema { Id = 1, Nome = "Bug em Produção", Descricao = "Identificação e correção de erros críticos em ambiente de produção com impacto nos usuários finais.", TempoResposta = "2 horas", Categoria = "Urgente", Preco = 500, Icone = "🔴" },
            new Problema { Id = 2, Nome = "Desenvolvimento de API", Descricao = "Criação de APIs RESTful robustas e documentadas para integração com sistemas externos.", TempoResposta = "5 dias úteis", Categoria = "Desenvolvimento", Preco = 2500, Icone = "⚡" },
            new Problema { Id = 3, Nome = "Otimização de Performance", Descricao = "Análise e melhoria de performance de sistemas lentos, reduzindo tempo de resposta em até 70%.", TempoResposta = "3 dias úteis", Categoria = "Performance", Preco = 1800, Icone = "🚀" },
            new Problema { Id = 4, Nome = "Segurança & Vulnerabilidades", Descricao = "Auditoria de segurança completa, identificação e correção de vulnerabilidades críticas.", TempoResposta = "4 dias úteis", Categoria = "Segurança", Preco = 3000, Icone = "🔒" },
            new Problema { Id = 5, Nome = "Migração de Banco de Dados", Descricao = "Migração segura de dados entre diferentes SGBDs com zero downtime.", TempoResposta = "7 dias úteis", Categoria = "Database", Preco = 4000, Icone = "🗄️" },
            new Problema { Id = 6, Nome = "Integração de Sistemas", Descricao = "Integração entre diferentes plataformas e sistemas legados via APIs e webhooks.", TempoResposta = "10 dias úteis", Categoria = "Integração", Preco = 5500, Icone = "🔗" },
        };

        private static readonly List<Solicitacao> _solicitacoes = new();

        public IActionResult Index()
        {
            return View(_problemas);
        }

        [HttpPost]
        public IActionResult EnviarSolicitacao(int problemaId, string nomeCliente, string emailCliente)
        {
            var problema = _problemas.FirstOrDefault(p => p.Id == problemaId);
            if (problema == null)
                return Json(new { sucesso = false, mensagem = "Serviço não encontrado." });

            if (string.IsNullOrWhiteSpace(nomeCliente) || string.IsNullOrWhiteSpace(emailCliente))
                return Json(new { sucesso = false, mensagem = "Nome e e-mail são obrigatórios." });

            var solicitacao = new Solicitacao
            {
                Id = _solicitacoes.Count + 1,
                NomeCliente = nomeCliente,
                EmailCliente = emailCliente,
                ProblemaId = problemaId,
                ProblemaDescricao = problema.Nome,
                DataSolicitacao = DateTime.Now,
                Status = StatusSolicitacao.Pendente
            };

            _solicitacoes.Add(solicitacao);

            return Json(new { sucesso = true, mensagem = $"✅ Pedido enviado com sucesso! Em breve o Tech Leader entrará em contato pelo e-mail {emailCliente}." });
        }

        // Expor solicitações para o Admin
        public static List<Solicitacao> GetSolicitacoes() => _solicitacoes;
        public static List<Problema> GetProblemas() => _problemas;
    }
}
