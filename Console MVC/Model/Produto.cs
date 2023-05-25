using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Console_MVC.Model
{
    public class Produto
    {
        // Propriedades.
        public int Codigo { get; set; }

        public string? Nome { get; set; }

        public float Preco { get; set; }

        // Caminho da pasta e do arquivo csv.
        private const string PATH = "Database/Produto.csv";

        public Produto()
        {
            // Criar a lógica para gerar a pasta e o arquivo:

            // Obter o caminho da pasta.
            string pasta = PATH.Split("/")[0];

            // Verificar se no caminho já existe uma pasta.
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }


            // Verificar se no caminho já existe um arquivo.
            if (!File.Exists(PATH))
            {
                File.Create(PATH);
            }

        }
            public List<Produto> Ler()
            {
                
                List<Produto> produtos = new List<Produto>();
                

                string[] linhas = File.ReadAllLines(PATH);


                // Leitura de linhas.
                foreach (var item in linhas)
                {
                   string[] atributos = item.Split(";");

                   Produto p = new Produto();

                   p.Codigo = int.Parse(atributos[0]);
                   p.Nome = atributos[1];
                   p.Preco = float.Parse(atributos[2]);


                   // Adiciona objetos dentro da lista.
                   produtos.Add(p);
                }

                    // Retorna a lista de produtos.
                    return produtos;
            }

            // Método para preparar as linhas a serem inseridas no csv.
            public string PreapararLinhasCsv(Produto p)
            {
                return $"{p.Codigo};{p.Nome};{p.Preco}";
                // Exemplo: 2345, Coca-Cola, 5,99
            }

            // Método para inserir um produto na linha do CSV.

            public void Inserir(Produto p)
            {
                // Array que armazena as linhas obtidas pelo método PrepararLinhasCsv.
                string[] linhas = {PreapararLinhasCsv(p)};

                File.AppendAllLines(PATH, linhas);
            }

    }
}