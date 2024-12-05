
class Program
{
    static string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
    static Dictionary<string, List<int>> bandasRegistradas = new()
    {
        { "Linkin park", new List<int>() },
        { "AC/DC", new List<int> { 10, 10, 10 } },
        { "Guns N' Roses", new List<int> { 10, 10, 10 } }
    };

    static Dictionary<string, int> estoqueBandas = new()
    {
        { "Linkin park", 5 },
        { "AC/DC", 10 },
        { "Guns N' Roses", 7 }
    };

    static Dictionary<string, string> quizBandas = new()
    {
        { "Quem é o vocalista do AC/DC?", "Brian Johnson" },
        { "Quem é o guitarrista do Guns N' Roses?", "Slash" },
        { "Qual banda canta 'In the End'?", "Linkin park" }
    };

    static Dictionary<string, string> usuarios = new()
    {
        { "admin", "1234" },
        { "user", "senha" }
    };

    static void Main()
    {
        if(!FazerLogin())
        {
            Console.WriteLine("Login falhou. Encerrando o programa.");
            return;
        }

        ExibirOpcoesDoMenu();
    }

    static void ExibirOpcoesDoMenu()
    {
        ExibirLogo();
        Console.WriteLine("\nDigite 1 para registrar uma banda");
        Console.WriteLine("Digite 2 para mostrar todas as bandas");
        Console.WriteLine("Digite 3 para avaliar uma banda");
        Console.WriteLine("Digite 4 para exibir a média de uma banda");
        Console.WriteLine("Digite 5 para adicionar ao estoque de uma banda");
        Console.WriteLine("Digite 6 para exibir o estoque de uma banda");
        Console.WriteLine("Digite 7 para jogar o quiz");
        Console.WriteLine("Digite -1 para sair");

        Console.Write("\nDigite a sua opção: ");
        string opcaoEscolhida = Console.ReadLine()!;
        if (!int.TryParse(opcaoEscolhida, out int opcaoEscolhidaNumerica))
        {
            Console.WriteLine("Por favor, insira um número válido.");
            Thread.Sleep(2000);
            Console.Clear();
            ExibirOpcoesDoMenu();
            return;
        }

        switch (opcaoEscolhidaNumerica)
        {
            case 1: RegistrarBanda(); break;
            case 2: MostrarBandasRegistradas(); break;
            case 3: AvaliarUmaBanda(); break;
            case 4: ExibirMediaDeUmaBanda(); break;
            case 5: AdicionarAoEstoque(); break;
            case 6: ExibirEstoque(); break;
            case 7: JogarQuiz(); break;
            case -1: Console.WriteLine("Tchau tchau :)"); return;
            default: Console.WriteLine("Opção inválida"); break;
        }

        Console.Clear();
        ExibirOpcoesDoMenu();
    }

    static void ExibirLogo()
    {
        Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
        Console.WriteLine(mensagemDeBoasVindas);
    }

    static void RegistrarBanda()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Registro de Bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (!bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            bandasRegistradas.Add(nomeDaBanda, new List<int>());
            Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        }
        else
        {
            Console.WriteLine($"A banda {nomeDaBanda} já está registrada.");
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void MostrarBandasRegistradas()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Exibindo todas as bandas registradas");
        foreach (var banda in bandasRegistradas.Keys)
        {
            Console.WriteLine($"Banda: {banda}");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
    }

    static void AvaliarUmaBanda()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Avaliar Banda");
        Console.Write("\nDigite o nome da banda: ");
        var nomeDaBanda = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(nomeDaBanda))
        {
            Console.WriteLine("Nome da banda não pode estar vazio.");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal.");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesDoMenu();
            return;
        }

        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.WriteLine($"Você está avaliando a banda: {nomeDaBanda}");
            Console.Write("Digite sua avaliação (de 0 a 10): ");

            if (int.TryParse(Console.ReadLine(), out int avaliacao) && avaliacao >= 0 && avaliacao <= 10)
            {
                bandasRegistradas[nomeDaBanda].Add(avaliacao);
                Console.WriteLine($"Avaliação {avaliacao} registrada para a banda {nomeDaBanda}.");
            }
            else
            {
                Console.WriteLine("Por favor, insira um número válido entre 0 e 10.");
            }
        }
        else
        {
            Console.WriteLine($"A banda '{nomeDaBanda}' não foi encontrada.");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

    private static void ExibirMediaDeUmaBanda()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Exibir Média de Notas");
        Console.Write("Digite o nome da banda: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            var notas = bandasRegistradas[nomeDaBanda];
            if (notas.Count > 0)
            {
                double media = notas.Average();
                Console.WriteLine($"A média das notas da banda {nomeDaBanda} é {media:F2}.");   
            }
            else
            {
                Console.WriteLine($"Banda '{nomeDaBanda}' não encontrada.");
            }
            Console.WriteLine("Pressione qualquer tecla para voltar.");
            Console.ReadKey();
        }
    }

    private static void AdicionarAoEstoque()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Adicionar ao Estoque");
        Console.Write("Digite o nome da banda: ");
        string nomeDaBanda = Console.ReadLine()!;

        if(estoqueBandas.ContainsKey(nomeDaBanda))
        {
            Console.Write("Digite a quantidade a ser adicionada: ");
            
            if(int.TryParse(Console.ReadLine(), out int quantidade) && quantidade > 0)
            {
                estoqueBandas[nomeDaBanda] += quantidade;
                Console.WriteLine($"Estoque atualizado! {nomeDaBanda} agora tem {estoqueBandas[nomeDaBanda]} álbuns.");
            }
            else
            {
                Console.WriteLine("Quantidade inválida.");
            }
        }
        else
        {
            Console.WriteLine($"Banda '{nomeDaBanda}' não encontrada.");
        }

        Console.WriteLine("Pressione qualquer tecla para voltar.");
        Console.ReadKey();
    }

     private static void ExibirEstoque()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Exibir Estoque");
        Console.Write("Digite o nome da banda: ");
        string nomeDaBanda = Console.ReadLine()!;

        if(estoqueBandas.ContainsKey(nomeDaBanda))
        {
            Console.WriteLine($"A banda {nomeDaBanda} possui {estoqueBandas[nomeDaBanda]} álbuns no estoque.");
        }
        else
        {
            Console.WriteLine($"Banda '{nomeDaBanda}' não encontrada.");
        }

        Console.WriteLine("Pressione qualquer tecla para voltar.");
        Console.ReadKey();
    }

    private static void JogarQuiz()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Quiz Musical");
        foreach(var pergunta in quizBandas)
        {
            Console.WriteLine(pergunta.Key);
            Console.Write("Resposta: ");
            string Resposta = Console.ReadLine()!;

            if(Resposta.Equals(pergunta.Value, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Resposta correta!");
            }
            else
            {
                Console.WriteLine($"Resposta errada! A correta é: {pergunta.Value}");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Pressione qualquer tecla para voltar.");
        Console.ReadKey();
    }

    static bool FazerLogin()
    {
        Console.WriteLine("Login:");
        Console.Write("Usuário: ");
        string usuario = Console.ReadLine()!;
        Console.Write("Senha: ");
        string senha = Console.ReadLine()!;

        if(usuarios.TryGetValue(usuario, out var senhaCorreta) && senha == senhaCorreta)
        {
            Console.WriteLine("Login bem-sucedido!");
            return true;
        }
        else
        {
            Console.WriteLine("Usuário ou senha inválidos.");
            return false;
        }
    }

    static void ExibirTituloDaOpcao(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        string asteriscos = new string('*', quantidadeDeLetras);
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos + "\n");
    }
}
