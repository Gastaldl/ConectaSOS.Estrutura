using System;
using ConectaSOS.Model.Entidades;
using ConectaSOS.Repository.Repositorios;
using System.Collections.Generic;

namespace ConectaSOS.Controller.Controllers
{
    public class UsuarioController
    {
        private readonly UsuarioRepository _repo;

        public UsuarioController()
        {
            _repo = new UsuarioRepository();

            // Adiciona apenas se ainda não existirem
            if (!_repo.LoginExiste("admin"))
            {
                var admin = new Usuario("Administrador", "Central", "Admin", "admin", "1234");
                _repo.Adicionar(admin);
            }

            if (!_repo.LoginExiste("joao"))
            {
                var morador = new Usuario("João Silva", "Vila Esperança", "Morador", "joao", "senha123");
                _repo.Adicionar(morador);
            }
        }

        public Usuario Autenticar(string login, string senha)
        {
            try
            {
                var usuario = _repo.BuscarPorLogin(login, senha);
                if (usuario == null)
                    throw new Exception("Login ou senha inválidos.");

                return usuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no login: {ex.Message}");
                return null;
            }
        }

        public void CadastrarUsuario(string nome, string grupo, string papel, string login, string senha)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nome) ||
                    string.IsNullOrWhiteSpace(grupo) ||
                    string.IsNullOrWhiteSpace(papel) ||
                    string.IsNullOrWhiteSpace(login) ||
                    string.IsNullOrWhiteSpace(senha))
                {
                    Console.WriteLine("Todos os campos devem ser preenchidos.");
                    return;
                }

                if (_repo.LoginExiste(login))
                {
                    Console.WriteLine("Já existe um usuário com esse login. Escolha outro.");
                    return;
                }

                var usuario = new Usuario(nome, grupo, papel, login, senha);
                _repo.Adicionar(usuario);
                Console.WriteLine("Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar usuário: {ex.Message}");
            }
        }

        public void ListarUsuarios()
        {
            Console.WriteLine("\n==== USUÁRIOS CADASTRADOS ====");
            var lista = _repo.ListarTodos();
            foreach (var u in lista)
            {
                Console.WriteLine($"- Nome: {u.Nome} | Grupo: {u.Grupo} | Papel: {u.Papel} | Login: {u.Login}");
            }
        }

        public void AlterarSenha(string login, string novaSenha)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(novaSenha))
                {
                    Console.WriteLine("A nova senha não pode estar vazia.");
                    return;
                }

                _repo.AlterarSenha(login, novaSenha);
                Console.WriteLine("Senha atualizada com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao alterar senha: {ex.Message}");
            }
        }
    }
}
