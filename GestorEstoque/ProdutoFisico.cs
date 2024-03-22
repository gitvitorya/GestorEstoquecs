using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEstoque {

    [System.Serializable] // permite salvar no arquivo

    //vai herdar da classe produto e seguir o contrato da interface IEstoque
    class ProdutoFisico : Produto, IEstoque {

        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float preco, float frete) {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
            
        }

        public void AdicionarEntrada() {
            Console.WriteLine($"Adicionar entrada no estoque do produto {nome}");
            Console.WriteLine("Digite a quantidade da entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            //estoque = estoque + entrada
            estoque += entrada;
            Console.WriteLine("Entrada registrada");
            Console.ReadLine();
        }

        public void AdicionarSaida() {
            Console.WriteLine($"Adicionar saída no estoque do produto {nome}");
            Console.WriteLine("Digite a quantidade da saída: ");
            int entrada = int.Parse(Console.ReadLine());
            //estoque = estoque - entrada
            estoque -= entrada;
            Console.WriteLine("Saída registrada");
            Console.ReadLine();
        }

        public void Exibir() {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Frete: {frete}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Estoque: {estoque}");
            Console.WriteLine("============================");
        }
    }
}
