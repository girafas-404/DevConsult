# CP4 - Consultoria em Desenvolvimento

## Checkpoint 4 — C# Development  
**Curso:** Engenharia de Software | **Professor:** Wellington Cidade Silva | **Turma:** 3ESPS

---

## 👥 Integrantes da Equipe

| Nome | RM |
|------|----|
| Rafael De Almeida Sigoli | RM554019 |
| Giovanna Franco Gaudino Rodrigues | RM553701 |
| [NOME 3] | [RM] |


---

## 📋 Sobre o Projeto

Sistema de **Consultoria em Desenvolvimento de Software** onde:
- Clientes visualizam os cards de serviços disponíveis (nome, descrição, tempo de resposta)
- Ao clicar em "Solicitar Serviço", um modal é exibido para preenchimento de nome e e-mail
- A solicitação é enviada ao **Tech Leader** (Admin) para aprovação
- O Tech Leader pode **aprovar**, **reprovar** ou **encaminhar via WhatsApp** ao dev disponível

---

## 🚀 Tecnologias

- **ASP.NET Core MVC** (.NET 8)
- **C#**
- **Bootstrap 5** + Bootstrap Icons
- **Authentication com Claims** (Cookie Authentication)
- **JavaScript** (Fetch API)

---

## 🔧 Como Executar

```bash
# Clone o repositório
git clone https://github.com/girafas-404/DevConsult

# Navegue até a pasta do projeto
cd cp4-Projeto

# Execute o projeto
dotnet run
```

Acesse: `https://localhost:5001`

---

## 🔑 Credenciais Admin (Demo)

| Usuário | Senha |
|---------|-------|
| `admin` | `admin123` |

---

## 📁 Estrutura do Projeto

```
cp4-Projeto/
├── Controllers/
│   ├── HomeController.cs       # Página principal + solicitações
│   ├── AdminController.cs      # Dashboard Tech Leader (autenticado)
│   └── AccountController.cs   # Login/Logout com Claims
├── Models/
│   ├── Problema.cs             # Modelo de serviço
│   ├── Solicitacao.cs          # Modelo de solicitação
│   └── LoginViewModel.cs       # ViewModel de login
├── Views/
│   ├── Home/Index.cshtml       # Página principal com cards
│   ├── Admin/Dashboard.cshtml  # Painel do Tech Leader
│   ├── Account/Login.cshtml    # Tela de login
│   └── Shared/_Layout.cshtml  # Layout base (verifica autenticação)
├── wwwroot/
│   ├── css/site.css            # Estilos personalizados
│   └── js/site.js              # Scripts
└── Program.cs                  # Configuração de rotas e autenticação
```

---

## ✅ Requisitos Atendidos

- [x] Controller para o Admin
- [x] Claims para autenticação segura
- [x] Layout.cshtml com verificação de login
- [x] Program.cs com rotas e autenticação configurados
- [x] Estilização com Bootstrap
- [x] Layout dinâmico e responsivo
- [x] Cards de problemas com nome, descrição e tempo de resposta
- [x] Modal de solicitação com nome e e-mail
- [x] Alert de confirmação de pedido enviado
- [x] Dashboard do Tech Leader com ações (aprovar/reprovar/WhatsApp)
