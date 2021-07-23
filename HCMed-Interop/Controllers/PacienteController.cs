using HCMed_Interop.Data;
using HCMed_Interop.Data.Entities;
using HCMed_Interop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCMed_Interop.Controllers
{
    public class PacienteController : Controller
    {
        private readonly AppContext _context;
        
        public PacienteController(AppContext context)
        {
            _context = context;
        } 

        // GET: Paciente
        public ActionResult Index()
        {
            InicializarDados();


            return View();
        }

        public void InicializarDados()
        {
            UF uf1 = new UF(1, "São Paulo", "SP");

            Conselho conselho1 = new Conselho(1, "Conselho Regional de Medicina", "CRM", 1);
            Conselho conselho2 = new Conselho(2, "Conselho Regional de Enfermagem", "COREN", 1);

            Especialidade especialidade1 = new Especialidade(1, "Clínico Geral", "CLG");
            Especialidade especialidade2 = new Especialidade(2, "Dermatologia", "DMT");
            Especialidade especialidade3 = new Especialidade(3, "Angiologia", "AGL");
            Especialidade especialidade4 = new Especialidade(4, "Cirurgia Geral", "CRG");
            Especialidade especialidade5 = new Especialidade(5, "Enfermaria", "ENF");

            ProfissionalSaude profissional1 = new ProfissionalSaude(1, "Roberto", "Vasquez Marinho", 1, 1, CategoriaProfissional.Doutor, "154986", "23789");
            ProfissionalSaude profissional2 = new ProfissionalSaude(2, "Fernanda", "Martins Ambrósio", 2, 1, CategoriaProfissional.Doutor, "152741", "23174");
            ProfissionalSaude profissional3 = new ProfissionalSaude(3, "Marcus Vinícius", "de Almeida Teles", 4, 1, CategoriaProfissional.Doutor, "153158", "18472");
            ProfissionalSaude profissional4 = new ProfissionalSaude(4, "Márcia", "Fonseca Barbosa", 5, 2, CategoriaProfissional.Enfermeiro, "159342", "17830");
            ProfissionalSaude profissional5 = new ProfissionalSaude(5, "Janaína", "Ribeiro de Oliveira", 5, 2, CategoriaProfissional.Enfermeiro, "159758", "195612");

            Paciente paciente1 = new Paciente(1, "Maria Luiza", "Pereira Fernandes", Genero.Feminino, "7900012B", "paciente1.png");

            Consulta consulta1 = new Consulta(1, 1, 1, new DateTime(2021, 5, 5, 8, 30, 0), StatusConsulta.Realizada);
            Consulta consulta2 = new Consulta(2, 1, 2, new DateTime(2021, 8, 17, 9, 45, 0), StatusConsulta.Aguardando);

            CID cid1 = new CID(1, "G44.8", "Outras Síndromes de Cefaléia Especificadas");
            CID cid2 = new CID(2, "L50.0", "Urticária Alérgica");
            CID cid3 = new CID(3, "I49.9", "Arritmia Cardíaca Não Especificada");

            RelatorioMedico relatorioMedico1 = new RelatorioMedico(1, 1, 1, new DateTime(2021, 5, 5), 1);
            RelatorioMedico relatorioMedico2 = new RelatorioMedico(2, 1, 3, new DateTime(2019, 6, 17), 3);

            Internacao internacao1 = new Internacao(1, 1, new DateTime(2019, 6, 17, 18, 43, 42), new DateTime(2019, 6, 20, 14, 31, 13), StatusInternacao.Finalizada, 3, "Paciente apresentou aceleração nos batimentos cardíacos e outros sintomas comuns de arritmia");

            TransicaoCuidados transicao1 = new TransicaoCuidados(1, 1, 5, new DateTime(2019, 6, 19, 12, 51, 23), "Paciente conduzida à observação por 24 horas, após passar por procedimento cirúrgico");

            _context.EstadosBrasil.Add(uf1);

            _context.Conselho.Add(conselho1);
            _context.Conselho.Add(conselho2);

            _context.Especialidades.Add(especialidade1);
            _context.Especialidades.Add(especialidade2);
            _context.Especialidades.Add(especialidade3);
            _context.Especialidades.Add(especialidade4);
            _context.Especialidades.Add(especialidade5);

            _context.ProfissionaisSaude.Add(profissional1);
            _context.ProfissionaisSaude.Add(profissional2);
            _context.ProfissionaisSaude.Add(profissional3);
            _context.ProfissionaisSaude.Add(profissional4);
            _context.ProfissionaisSaude.Add(profissional5);

            _context.Pacientes.Add(paciente1);

            _context.Consultas.Add(consulta1);
            _context.Consultas.Add(consulta2);

            _context.Diagnosticos.Add(cid1);
            _context.Diagnosticos.Add(cid2);
            _context.Diagnosticos.Add(cid3);

            _context.Relatorios.Add(relatorioMedico1);
            _context.Relatorios.Add(relatorioMedico2);

            _context.Internacoes.Add(internacao1);

            _context.TransicaoCuidados.Add(transicao1);
        }

        public PacienteViewModel IniciarViewModel()
        {
            var vm = new PacienteViewModel();

            vm.Paciente = _context.Pacientes.Where(p => p.Id == 1).FirstOrDefault();
            vm.Consultas = _context.Consultas.Where(c => c.IdPaciente == 1).ToList();
            vm.Internacoes = _context.Internacoes.Where(i => i.IdPaciente == 1).ToList();
            vm.RelatoriosMedico = _context.Relatorios.Where(r => r.IdPaciente == 1).ToList();
            vm.Transicoes = _context.TransicaoCuidados.Where(t => t.IdPaciente == 1).ToList();

            return vm;
        }
    }
}