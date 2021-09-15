using System;

namespace CRUD_Series
{
    class Program
    {
        static SerieRepositorio repo = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoSelecionada = MenuOpcaoUsuario();
            while (!opcaoSelecionada.Equals("0"))
            {
                switch (opcaoSelecionada)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Ocorreu um erro");
                        throw new ArgumentOutOfRangeException();
                }

                opcaoSelecionada = MenuOpcaoUsuario();
            }
        }


        private static string MenuOpcaoUsuario()
        {
            System.Console.WriteLine("Informe a opção desejada: ");

            System.Console.WriteLine("1- Listar séries");
            System.Console.WriteLine("2- Inserir série");
            System.Console.WriteLine("3- Atualizar série");
            System.Console.WriteLine("4- Excluir série");
            System.Console.WriteLine("5- Visualizar série");
            System.Console.WriteLine("6- Limpar Tela");
            System.Console.WriteLine("0- Sair");

            System.Console.WriteLine();

            string opcaoSelecionada = Console.ReadLine();
            System.Console.WriteLine();
            return opcaoSelecionada;
        }

        private static void ExcluirSerie()
        {

            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Deseja mesmo excluir o Id {0} ? s/n", indiceSerie);

            string verificacao = Console.ReadLine().ToUpper();
            if (verificacao.Equals("S"))
            {
                repo.Exclui(indiceSerie);
                System.Console.WriteLine("Série excluída");

            }
            else
            {
                System.Console.WriteLine("Série não excluída");
                return;
            }
        }
        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repo.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repo.Atualiza(indiceSerie, atualizaSerie);
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repo.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.RetornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.RetornaId(), serie.RetornaTitulo(), (excluido ? "Excluído" : ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repo.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repo.Insere(novaSerie);
        }
    }
}
