using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP_SacoCarvao
{
    class Grupo
    {
        public int idGrupo { get;  set; }
        public string nomeGrupo { get; set; }

        public Grupo() { }
        public Grupo(int idGrupo, string nomeGrupo)
        {
            this.idGrupo = idGrupo;
            this.nomeGrupo = nomeGrupo;
        }
    }
}
