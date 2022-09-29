using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Model
{
    public class Endereco
    {
        public int Id { get; set; }
        public int IdFuncionario { get; set; }
        public string Cep { get; set; }
        public string _Endereco { get; set; } 
        public string Numero { get; set; } 
        public string Complemento { get; set; } 
        public string Bairro { get; set; } 
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string PontoReferencia { get; set; }
        public int Ativo { get; set; }
        public Endereco()
        {
            this.Id = 0;
            this.IdFuncionario = 0;
            this.Cep = "";
            this._Endereco = "";
            this.Numero = "";
            this.Complemento = "";
            this.Bairro = "";
            this.Cidade = "";
            this.Estado = "";
            this.PontoReferencia = "";
            this.Ativo = 0;
        }
    }
}