using System;
namespace DIO.Series
{
    class Program  //colocar
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
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
                    case "C":
                    Console.Clear(); //limpar terminal
                    break;
                    default:
                    throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada ainda");
                return;
            }
            foreach ( var serie in lista ) //criando a variável serie
            {
                var excluido = serie.retornaExcluido();
                System.Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), excluido ? "Excluído" : "");
            }
        }

    private static void InserirSerie()
    {
        System.Console.WriteLine("Inserir nova série");
        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i)); //já devolve o gênero caso haja inclusão
        }
        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o título da série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o ano da série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a descrição da série: ");
        string entradaDescricao = Console.ReadLine();

        Serie novaSerie = new Serie (id: repositorio.ProximoId(), //
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);
        repositorio.Insere(novaSerie);
    }
    
    private static void AtualizarSerie()
    {
        System.Console.Write ("Digite a ID da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i)); //já devolve o gênero caso haja inclusão
        }
        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o título da série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o ano da série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a descrição da série: ");
        string entradaDescricao = Console.ReadLine();

        Serie AtualizarSerie = new Serie (id: indiceSerie,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);
        repositorio.Atualiza(indiceSerie, AtualizarSerie);
    }

    private static void ExcluirSerie()
    {
        Console.Write("Digite o ID da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        repositorio.Exclui(indiceSerie);
    }

    private static void VisualizarSerie()
    {
        Console.Write("Digite o ID da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());
        var serie = repositorio.RetornaPorId(indiceSerie); //retorna a posição da série na coleção
        Console.WriteLine(serie);//retorna as informações do ToString da classe Serie e a marcação da série se foi excluída ou não
    }
    private static string ObterOpcaoUsuario()
    {
        System.Console.WriteLine();
        System.Console.WriteLine("Bem vindo!");
        System.Console.WriteLine("Selecione a opção desejada: ");

        System.Console.WriteLine("1 - Listar Séries");
        System.Console.WriteLine("2 - Inserir Nova Série");
        System.Console.WriteLine("3 - Atualizar Série");
        System.Console.WriteLine("4 - Excluir Série");
        System.Console.WriteLine("5 - Visualizar Séries");
        System.Console.WriteLine("C - Limpar Tela");
        System.Console.WriteLine("X - Sair");
        System.Console.WriteLine();

        string opcaoUsuario = Console.ReadLine().ToUpper();
        System.Console.WriteLine();
        return opcaoUsuario;
    }

    }
}