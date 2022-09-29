using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Model
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; } 
        public string OrgaoEmissor { get; set; } 
        public string TituloEleitor { get; set; } 
        public string Cnh { get; set; } 
        public int Gestor { get; set; }
        public Funcionario()
        {
            this.Id = 0;
            this.Nome = "";
            this.Cpf = "";
            this.Rg = "";
            this.OrgaoEmissor = "";
            this.TituloEleitor = "";
            this.Cnh = "";
            this.Gestor = 0;
        }
    }
}