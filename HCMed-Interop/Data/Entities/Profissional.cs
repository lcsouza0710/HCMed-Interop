using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCMed_Interop.Data.Entities
{
    public class ProfissionalSaude
    {
        public int Id { get; set; }

        public string PrimeiroNome { get; set; }

        public string Sobrenome { get; set; }

        public CategoriaProfissional Categoria { get; set; }

        public int IdEspecialidade { get; set; }

        public Especialidade Especialidade { get; set; }

        public string Matricula { get; set; }

        public int IdConselho { get; set; }

        public Conselho Conselho { get; set; }

        public string MatriculaConselho { get; set; }

        public ProfissionalSaude()
        {

        }

        public ProfissionalSaude(
            int id, 
            string primeiroNome, 
            string sobrenome,
            int idEspecialidade,
            int idConselho,
            CategoriaProfissional categoria,
            string matricula,
            string matriculaConselho)
        {
            this.Id = id;
            this.PrimeiroNome = primeiroNome;
            this.Sobrenome = sobrenome;
            this.IdEspecialidade = idEspecialidade;
            this.IdConselho = idConselho;
            this.Categoria = categoria;
            this.Matricula = matricula;
            this.MatriculaConselho = matriculaConselho;
        }

        public ProfissionalSaude(
            int id,
            string primeiroNome,
            string sobrenome,
            CategoriaProfissional categoria,
            int idEspecialidade,
            Especialidade especialidade,
            string matricula,
            int idConselho,
            Conselho conselho,
            string matriculaConselho)
        {
            this.Id = id;
            this.PrimeiroNome = primeiroNome;
            this.Sobrenome = sobrenome;
            this.Categoria = categoria;
            this.IdEspecialidade = idEspecialidade;
            this.Especialidade = especialidade;
            this.Matricula = matricula;
            this.IdConselho = idConselho;
            this.Conselho = conselho;
            this.MatriculaConselho = matriculaConselho;
        }

    }

    public enum CategoriaProfissional
    {
        Doutor,
        Enfermeiro
    }

    public class Especialidade
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public string Sigla { get; set; }

        public virtual List<ProfissionalSaude> Doutores { get; set; }

        public Especialidade()
        {

        }

        public Especialidade(int id, string descricao, string sigla)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.Sigla = sigla;
        }
    }

    public class Conselho
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public string Sigla { get; set; }

        public UF Estado { get; set; }

        public virtual List<ProfissionalSaude> Profissionais { get; set; }

        public Conselho()
        {

        }

        public Conselho(int id, string descricao, string sigla)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.Sigla = sigla;
        }

        public Conselho(int id, string descricao, string sigla, UF uf)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.Sigla = sigla;
            this.Estado = uf;
        }
    }

    public class UF
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public UF()
        {

        }

        public UF(int id, string nome, string sigla)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sigla = sigla;
        }
    }
}