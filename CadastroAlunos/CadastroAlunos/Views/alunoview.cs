using CadastroAlunos_Console.Controller;
using CadastroAlunos_Console.Models;

namespace CadastroAlunos_Console.Views
{
    public class AlunoView
    {
        private AlunoController controller = new();

        //CRIANDO MENU
        public void MostrarMenu()
        {
            int opcao;
            do
            {
                Console.WriteLine("=== Cadastro do Aluno no SENAC ===");
                Console.WriteLine("1 - Cadastrar Aluno");
                Console.WriteLine("2 - Listar Alunos");
                Console.WriteLine("3 - Atualizar Alunos");
                Console.WriteLine("4 - Excluir Alunos");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("Opção: ");
                opcao = int.Parse(Console.ReadLine());


                switch (opcao)
                {
                    case 1: CadastrarAluno(); break;
                    case 2: ListarAlunos(); break;
                    case 3: AtualizarAlunos(); break;
                    case 4: ExcluirAluno(); break;
                }
                Console.WriteLine("\nPressione Enter para continuar...");
                Console.ReadLine();


            } while (opcao != 0);
        }

      
        private void CadastrarAluno()
        {
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("CPF: ");
            string cpf = Console.ReadLine();
            Console.WriteLine("Curso: ");
            string curso = Console.ReadLine();
            Console.WriteLine("Data de Nascimento: (dd/mm/aaaa): ");
            DateTime data = DateTime.Parse(Console.ReadLine());

            controller.CadastrarAluno(nome, cpf, curso, data);
            Console.WriteLine("Aluno cadastrado com sucesso!");
        }
        private void ListarAlunos()
        {
            List<Aluno> alunos = controller.ListaAlunos();
            Console.WriteLine("\n Lista de alunos: ");
            foreach (var aluno in alunos)
            {
                Console.WriteLine($"ID: {aluno.Id} | Nome: {aluno.Nome} | CPF: {aluno.CPF} | Curso: {aluno.Curso} | Nascimento: {aluno.DataNascimento}");
            }
        }
        public void AtualizarAlunos()
        {
            Console.WriteLine("NDigite o ID do aluno a ser atualizado: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Novo nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Novo CPF: ");
            string cpf = Console.ReadLine();

            Console.WriteLine("Novo Curso: ");
            string curso = Console.ReadLine();

            Console.WriteLine("Data de Nascimento: ");
            DateTime data = DateTime.Parse(Console.ReadLine());

            bool atualizado = controller.AtualizarAluno(id,nome,cpf,curso,data);
            Console.WriteLine(atualizado ? "Aluno cadastrado com sucesso!" : "Aluno não encontrado");
        }
        public void ExcluirAluno()
        {
            Console.WriteLine("Digite o ID do aluno a ser excluído: ");
            int id = int.Parse(Console.ReadLine());

            bool excluido = controller.ExcluirAluno(id);
            Console.WriteLine(excluido ? "Aluno excluído com sucesso!" : "Aluno não excluído!");
        }
    }
}