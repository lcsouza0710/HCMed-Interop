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

        public string Matricula { get; set; }

        public int IdConselho { get; set; }

        public string MatriculaConselho { get; set; }

        public virtual Especialidade Especialidade { get; set; }
        
        public virtual Conselho Conselho { get; set; }

        public virtual List<Consulta> Consultas { get; set; }

        public virtual List<RelatorioMedico> RelatoriosMedicos { get; set; }

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

        public int IdEstado { get; set; }

        public virtual UF Estado { get; set; }

        public virtual List<ProfissionalSaude> Profissionais { get; set; }

        public Conselho()
        {

        }

        public Conselho(int id, string descricao, string sigla, int idEstado)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.Sigla = sigla;
            this.IdEstado = idEstado;
        }
    }

    public class UF
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public virtual List<Conselho> Conselhos { get; set; }

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