using ConectaSOS.Controller.Controllers;
using ConectaSOS.Model.Entidades;
using ConectaSOS.Repository.Repositorios;
using System;

namespace ConectaSOS.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var historicoRepo = new HistoricoRepository();

            var mensagemController = new MensagemController(historicoRepo);
            var alertaController = new AlertaController(historicoRepo);
            var historicoController = new HistoricoController(historicoRepo);
            var usuarioController = new UsuarioController();
            var relatorioController = new RelatorioController();

            Usuario usuarioLogado = null;

            while (true)
            {
                // Login ou Cadastro
                while (usuarioLogado == null)
                {
                    Console.Clear();
                    Console.WriteLine("==== CONECTA SOS ====");
                    Console.WriteLine("[1] Fazer login");
                    Console.WriteLine("[2] Cadastrar novo usuário");
                    Console.WriteLine("[0] Sair");
                    Console.Write("Escolha uma opção: ");
                    string escolha = Console.ReadLine();

                    switch (escolha)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("==== LOGIN ====");
                            Console.Write("Login: ");
                            string login = Console.ReadLine();
                            Console.Write("Senha: ");
                            string senha = Console.ReadLine();

                            usuarioLogado = usuarioController.Autenticar(login, senha);
                            if (usuarioLogado == null)
                            {
                                Console.WriteLine("Credenciais inválidas. Pressione qualquer tecla para tentar novamente...");
                                Console.ReadKey();
                            }
                            break;

                        case "2":
                            Console.Clear();
                            Console.WriteLine("==== CADASTRO DE NOVO USUÁRIO ====");
                            Console.Write("Nome: ");
                            string nome = Console.ReadLine();
                            Console.Write("Grupo/Comunidade: ");
                            string grupo = Console.ReadLine();
                            Console.Write("Papel (Morador/Voluntário): ");
                            string papel = Console.ReadLine();
                            Console.Write("Login desejado: ");
                            string novoLogin = Console.ReadLine();
                            Console.Write("Senha desejada: ");
                            string novaSenha = Console.ReadLine();

                            usuarioController.CadastrarUsuario(nome, grupo, papel, novoLogin, novaSenha);
                            Console.WriteLine("Cadastro concluído! Pressione qualquer tecla para voltar ao menu inicial...");
                            Console.ReadKey();
                            break;

                        case "0":
                            Console.WriteLine("Encerrando...");
                            return;

                        default:
                            Console.WriteLine("Opção inválida. Pressione qualquer tecla para tentar novamente...");
                            Console.ReadKey();
                            break;
                    }
                }

                // Menu principal
                while (usuarioLogado != null)
                {
                    Console.Clear();
                    Console.WriteLine($"==== BEM-VINDO, {usuarioLogado.Nome.ToUpper()} ====");
                    Console.WriteLine("1. Enviar Mensagem SOS");
                    Console.WriteLine("2. Emitir Alerta Comunitário");
                    Console.WriteLine("3. Visualizar Histórico Criptografado");
                    Console.WriteLine("4. Gerar Relatório de Status");
                    Console.WriteLine("5. Alterar minha senha");
                    Console.WriteLine("6. Trocar de usuário");

                    if (usuarioLogado.Papel.ToLower() == "admin")
                    {
                        Console.WriteLine("7. Cadastrar Novo Usuário (somente Admin)");
                        Console.WriteLine("8. Listar Usuários Cadastrados (somente Admin)");
                        Console.WriteLine("9. Apagar Histórico (somente Admin)");
                    }

                    Console.WriteLine("0. Sair");
                    Console.Write("Escolha uma opção: ");
                    string opcao = Console.ReadLine();

                    switch (opcao)
                    {
                        case "1":
                            Console.WriteLine("\n--- Envio de Mensagem SOS ---");
                            Console.Write("Título: ");
                            string titulo = Console.ReadLine();
                            Console.Write("Conteúdo: ");
                            string conteudo = Console.ReadLine();
                            Console.Write("Localização: ");
                            string local = Console.ReadLine();
                            Console.Write("Prioridade (Alta/Média/Baixa): ");
                            string prioridade = Console.ReadLine();
                            mensagemController.EnviarMensagemSOS(titulo, conteudo, local, prioridade);
                            break;

                        case "2":
                            Console.WriteLine("\n--- Emissão de Alerta ---");
                            Console.Write("Título: ");
                            string tituloA = Console.ReadLine();
                            Console.Write("Conteúdo: ");
                            string conteudoA = Console.ReadLine();
                            Console.Write("Tipo (Urgente/Informativo): ");
                            string tipo = Console.ReadLine();
                            alertaController.EmitirAlerta(tituloA, conteudoA, tipo);
                            break;

                        case "3":
                            Console.WriteLine("\n--- Histórico ---");
                            Console.WriteLine("Escolha o tipo de mensagens para visualizar:");
                            Console.WriteLine("[1] Somente Mensagens SOS");
                            Console.WriteLine("[2] Somente Alertas");
                            Console.WriteLine("[3] Todos");
                            Console.Write("Opção: ");
                            string filtro = Console.ReadLine();

                            string tipoFiltro = "todos";
                            switch (filtro)
                            {
                                case "1":
                                    tipoFiltro = "sos";
                                    break;
                                case "2":
                                    tipoFiltro = "alerta";
                                    break;
                                case "3":
                                    tipoFiltro = "todos";
                                    break;
                                default:
                                    Console.WriteLine("Opção inválida. Exibindo todas as mensagens.");
                                    break;
                            }

                            historicoController.ExibirHistorico(tipoFiltro);
                            break;

                        case "4":
                            Console.WriteLine("\n--- Gerar Relatório ---");
                            Console.Write("Está sem energia? (s/n): ");
                            bool semEnergia = Console.ReadLine().ToLower() == "s";
                            Console.Write("Está sem internet? (s/n): ");
                            bool semInternet = Console.ReadLine().ToLower() == "s";
                            relatorioController.GerarRelatorio(semEnergia, semInternet);
                            break;

                        case "5":
                            Console.WriteLine("\n--- Alterar Senha ---");
                            Console.Write("Digite a nova senha: ");
                            string novaSenhaAlterada = Console.ReadLine();
                            usuarioController.AlterarSenha(usuarioLogado.Login, novaSenhaAlterada);
                            break;

                        case "6":
                            usuarioLogado = null; // logout
                            break;

                        case "7":
                            if (usuarioLogado.Papel.ToLower() != "admin") break;
                            Console.WriteLine("\n--- Cadastro de Novo Usuário ---");
                            Console.Write("Nome: ");
                            string nomeNovo = Console.ReadLine();
                            Console.Write("Grupo/Comunidade: ");
                            string grupoNovo = Console.ReadLine();
                            Console.Write("Papel (Morador/Voluntário): ");
                            string papelNovo = Console.ReadLine();
                            Console.Write("Login desejado: ");
                            string loginNovo = Console.ReadLine();
                            Console.Write("Senha desejada: ");
                            string senhaNovo = Console.ReadLine();
                            usuarioController.CadastrarUsuario(nomeNovo, grupoNovo, papelNovo, loginNovo, senhaNovo);
                            break;

                        case "8":
                            if (usuarioLogado.Papel.ToLower() != "admin") break;
                            usuarioController.ListarUsuarios();
                            break;

                        case "9":
                            if (usuarioLogado.Papel.ToLower() == "admin")
                                historicoController.ApagarHistorico();
                            else
                                Console.WriteLine("Apenas administradores podem apagar o histórico.");
                            break;

                        case "0":
                            Console.WriteLine("Encerrando...");
                            return;

                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }

                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}