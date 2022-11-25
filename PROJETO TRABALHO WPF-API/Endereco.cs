using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETOTRABALHOAPI
{
    public class Endereco
    {
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        public string Estado { get; set; }
        string Cep { get; set; }
        public Estado_Info Estado_Info { get; set; }
        public Cidade_Info Cidade_Info { get; set; }
    }

    public class Estado_Info
    {
        public string Area_km2 { get; set; }
        public string Codigo_ibge { get; set; }
        public string Nome { get; set; }
    }

    public class Cidade_Info
    {
        public string Area_km2 { get; set; }
        public string Codigo_ibge { get; set; }
    }
 }
