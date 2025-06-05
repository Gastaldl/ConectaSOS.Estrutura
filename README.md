# ConectaSOS

Sistema de comunicação emergencial offline para comunidades afetadas por desastres ou falhas na infraestrutura. Desenvolvido em C# com .NET 8, este sistema simula uma central comunitária que pode enviar mensagens SOS e alertas via rede local, mantendo histórico criptografado e controle de usuários.

## 📌 Finalidade

A proposta do sistema é fornecer uma solução viável de comunicação offline para situações de emergência, como:

- Falta de internet ou energia elétrica
- Catástrofes naturais
- Colapsos de infraestrutura urbana

Usuários do sistema podem enviar **mensagens SOS**, **alertas comunitários**, visualizar **histórico criptografado**, **gerar relatórios**, **cadastrar usuários** e realizar **controle de acesso com login**.

---

## ⚙️ Como executar o projeto

1. **Clone este repositório:**

   ```bash
   git clone https://github.com/Gastaldl/ConectaSOS.Estrutura.git


2. **Abra o projeto no Visual Studio 2022.**

3. **Na solução (`.sln`), clique com o botão direito no projeto `ConectaSOS.UI` e selecione:**

   > `Definir como projeto de inicialização`

   Isso é importante, pois o Visual Studio pode selecionar por padrão outro projeto como inicializador (como `ConectaSOS.Controller`).

4. **Compile e execute a aplicação:**

   * Pressione `Ctrl + F5` ou clique em `Iniciar` (sem depuração).

---

## 👤 Usuários de exemplo

O sistema já vem com dois usuários cadastrados para fins de teste:

| Nome          | Papel   | Login | Senha    |
| ------------- | ------- | ----- | -------- |
| Administrador | Admin   | admin | 1234     |
| João Silva    | Morador | joao  | senha123 |

Esses usuários estão disponíveis por padrão ao iniciar o sistema pela primeira vez.

---

## 📁 Estrutura de Pastas

```
ConectaSOS/
├── ConectaSOS.Model/          # Entidades do sistema (Usuario, Mensagem, Alerta, etc.)
├── ConectaSOS.Repository/     # Repositórios responsáveis por persistência (JSON)
├── ConectaSOS.Controller/     # Lógica de controle entre UI e Repositórios
├── ConectaSOS.UI/             # Interface de Console (responsável pela interação com o usuário)
├── ConectaSOS.Estrutura.sln   # Solução Visual Studio
```

---

## 🧾 Dados persistidos

Os arquivos `.json` usados para armazenar os dados são gerados automaticamente em tempo de execução no seguinte caminho:

```
C:\Users\[SEU_USUÁRIO]\source\repos\ConectaSOS.Estrutura\ConectaSOS.UI\bin\Debug\net8.0\data\
```

* `usuarios.json` → lista de usuários cadastrados
* `historico.json` → histórico de mensagens e alertas enviados

---

## ✅ Funcionalidades principais

* Login para **Administrador** e **Morador**
* Envio de **mensagens SOS** com prioridade (Alta, Média, Baixa)
* Emissão de **alertas comunitários**
* Histórico com:

  * Classificação por prioridade
  * Filtro por tipo (SOS, Alerta ou Todos)
  * Opção de **apagar histórico** (apenas para Administradores)
* Cadastro de novos usuários
* Alteração de senha e troca de usuário
* Geração de relatório de status do sistema
* Persistência em arquivos `.json`

---

## 🛠️ Requisitos

* Visual Studio 2022
* .NET 8 SDK

---

## 📌 Observações finais

* A arquitetura do projeto segue o padrão MVC, com separação clara entre entidades, repositórios, controladores e interface.
* Todo o conteúdo do histórico é armazenado de forma criptografada simulada (tag [CRYPTO]).
* O projeto **não requer banco de dados**, pois toda a persistência é feita em arquivos `.json` locais.
