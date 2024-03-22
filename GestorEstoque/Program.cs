using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GestorEstoque {
    class Program {

        static List<IEstoque> produtos = new List<IEstoque>(); //lista de todos os produtos
        private static float frete;

        enum Menu { Listar = 1, Adicionar = 2, Remover = 3, Entrada = 4, Saida = 5, Sair = 6 }



        static void Main(string[] args) {

            Carregar();


            bool escolheuSair = false;
            while (escolheuSair == false) {

                Console.WriteLine("Sistema de estoque");
                Console.WriteLine("1-Listar\n2-Adicionar\n3-Remover\n4-Registrar entrada\n5-Registrar saída\n6-Sair ");
               string opcao = Console.ReadLine();
                int opint = int.Parse(opcao); //type cast pra converter o tipo de dado que entrou
                Menu escolha = (Menu)opint;


                if(opint > 0 && opint < 7) { //valida a opcao escolhida


                    switch (escolha) {

                        case Menu.Listar:
                            Listagem();
                            break;

                        case Menu.Adicionar:
                            Cadastro();
                            break;

                        case Menu.Remover:
                            Remover();
                            break;

                        case Menu.Entrada:
                            Entrada();
                            break;

                        case Menu.Saida:
                            Saida();
                            break;

                        case Menu.Sair:
                            escolheuSair = true;
                            break;

                    }

                }
                else {
                    escolheuSair = true;
                }


            }



        }


        static void Listagem() {
            Console.WriteLine("Lista de produtos");
            int id = 0;
            foreach (IEstoque produto in produtos) {
                Console.WriteLine("ID: " + id);
                produto.Exibir();
                id++;
            }

            Console.ReadLine();
        }



        static void Remover() {
            Console.WriteLine("Digite o ID do produto que você quer remover");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count) {
                produtos.RemoveAt(id); //remove o elemento com id digitado
                Salvar();
                Console.WriteLine("Produto removido com sucesso!");
            }
            else {
                Console.WriteLine("ID de produto inválido!");
            }
            Console.ReadLine(); // Aguarda ação do usuário antes de continuar
        }


        static void Entrada() {
            Console.WriteLine("Digite o ID do produto que você quer dar entrada");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count) {

                produtos[id].AdicionarEntrada();//add entrada ao elemento com id digitado
                Salvar();
                Console.WriteLine("Entrada registrada");
            }
            else {
                Console.WriteLine("ID de produto inválido!");
            }
            Console.ReadLine(); // Aguarda ação do usuário antes de continuar
        }



        static void Cadastro() {
            Console.WriteLine("Cadastro de produto");
            Console.WriteLine("1-Produto Físico\n2-Ebook\n3-Curso");
            string opc = Console.ReadLine();
            int escolhaint = int.Parse(opc);
            switch (escolhaint) {
                case 1:
                    CadastrarPFisico();
                    break;
                case 2:
                    CadastrarEbook();
                    break;
                case 3:
                    CadastrarCurso();
                    break;
            }

        }

        static void CadastrarPFisico() {

            Console.WriteLine("Cadastrando produto físico: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());

            //polimorfismo
            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf); // adiciona o produto a lista de produtos
            Salvar();


        }

        static void CadastrarEbook() {

            Console.WriteLine("Cadastrando ebook: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            //polimorfismo
            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf); // adiciona o produto a lista de produtos

            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();

        }

        static void CadastrarCurso() {

            Console.WriteLine("Cadastrando curso: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            //polimorfismo
            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf); // adiciona o produto a lista de produtos

            Curso cs = new Curso(nome, preco, autor);
            produtos.Add(cs);
            Salvar();

        }


        static void Salvar() {

            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate); //cria o arquivo para salvar a lista
            BinaryFormatter encoder = new BinaryFormatter();
            encoder.Serialize(stream, produtos); // salva a lista de produtos

        }


        static void Carregar() {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try {
                produtos = (List<IEstoque>)encoder.Deserialize(stream);

                if(produtos == null) {
                    produtos = new List<IEstoque>();
                }



            }
            catch(Exception e){
                produtos = new List<IEstoque>();
            }

            stream.Close();


        }


        static void Saida() {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer dar baixa");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count) {
                produtos[id].AdicionarSaida();
                Salvar();
            }

        }


    }
}
