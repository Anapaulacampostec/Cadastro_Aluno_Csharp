using System;

using System.Collections.Generic;

using System.Linq;

using System.Security.Cryptography;

using System.Text;

using System.Threading.Tasks;

using CadastroAlunos_Console.Models;

namespace CadastroAlunos_Console.Controller

{

    public class AlunoController

    {

        private List<Aluno> alunos = new();

        private int proximoId = 1;

        public void CadastrarAluno(string nome, string cpf, string curso, DateTime dataNascimento)

        {

            Aluno novoAluno = new(proximoId++, nome, cpf, curso, dataNascimento);

            alunos.Add(novoAluno);

        }
        public List<Aluno> ListaAlunos()
            { 
            return alunos; 
        }

        public bool AtualizarAluno(int id, string nome, string cpf, string curso, DateTime dataNascimento)


        {
            Aluno aluno = alunos.Find(a => a.Id == id);
            if (aluno == null) return false; 

            aluno.Nome = nome;
            aluno.CPF = cpf;
            aluno.Curso = curso;
            aluno.DataNascimento = dataNascimento;
            
            return true;
        }

        public bool ExcluirAluno(int id)
        {
            Aluno aluno = alunos.Find(aluno => aluno.Id == id);
            return aluno != null && alunos.Remove(aluno);
        }

    }

}