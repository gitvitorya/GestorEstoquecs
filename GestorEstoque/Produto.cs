using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEstoque {
    [System.Serializable] // permite salvar no arquivo
                          //serve como pai
    abstract class Produto {

        public string nome;
        public float preco; 
   }
}
