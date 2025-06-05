using ConectaSOS.Model.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class UsuarioRepository
{
    private readonly string _caminhoArquivo = "data/usuarios.json";
    private List<Usuario> usuarios;

    public UsuarioRepository()
    {
        if (!Directory.Exists("data"))
            Directory.CreateDirectory("data");

        usuarios = CarregarArquivo();
    }

    private List<Usuario> CarregarArquivo()
    {
        try
        {
            if (File.Exists(_caminhoArquivo))
            {
                string json = File.ReadAllText(_caminhoArquivo);
                var lista = JsonSerializer.Deserialize<List<Usuario>>(json);
                return lista ?? new List<Usuario>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao ler usuários do JSON: {ex.Message}");
        }

        return new List<Usuario>();
    }

    private void SalvarArquivo()
    {
        try
        {
            string json = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_caminhoArquivo, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar usuários no JSON: {ex.Message}");
        }
    }

    public void Adicionar(Usuario usuario)
    {
        usuarios.Add(usuario);
        SalvarArquivo();
    }

    public Usuario BuscarPorLogin(string login, string senha)
    {
        return usuarios.FirstOrDefault(u => u.Login.Equals(login, StringComparison.OrdinalIgnoreCase) && u.Senha == senha);
    }

    public bool LoginExiste(string login)
    {
        return usuarios.Any(u => u.Login.Equals(login, StringComparison.OrdinalIgnoreCase));
    }

    public void AlterarSenha(string login, string novaSenha)
    {
        var usuario = usuarios.FirstOrDefault(u => u.Login.Equals(login, StringComparison.OrdinalIgnoreCase));
        if (usuario != null)
        {
            usuario.Senha = novaSenha;
            SalvarArquivo();
        }
    }

    public List<Usuario> ListarTodos()
    {
        return usuarios;
    }
}
