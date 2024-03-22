using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEstoque {

    [System.Serializable] // permite salvar no arquivo

    class Ebook : Produto, IEstoque {

        public string autor;
        private int vendas;
      

        public Ebook(string nome, float preco, string autor) {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        
        }

        public void AdicionarEntrada() {
            Console.WriteLine("Ebook não possui estoque, material digital");
            Console.ReadLine();
        }

        public void AdicionarSaida() {
            Console.WriteLine($"Adicionar vendas no Ebook {nome}");
            Console.WriteLine("Digite a quantidade de vendas: ");
            int entrada = int.Parse(Console.ReadLine());
            //estoque = estoque + entrada
            vendas += entrada;
            Console.WriteLine("Saída registrada");
            Console.ReadLine();
        }

        public void Exibir() {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vendas: {vendas}");
            Console.WriteLine("============================");
        }
    }
}
