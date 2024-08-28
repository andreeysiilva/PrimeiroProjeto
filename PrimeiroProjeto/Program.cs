// See https://aka.ms/new-console-template for more information

using System;
using System.Runtime.CompilerServices;

string mensagemDeBoasVindas = "Boas vindas ao Screen Sound!";
// Para iniciar uma lista vazia para receber dados basta deixar com () e para iniciar uma lista com dados basta colocar {"DADO"}.
//List<string> listaDasBandas = new List<string>{"U2", "The Beatles", "Calipso"};

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linkin Park", new List<int> { 10, 8, 6 });
bandasRegistradas.Add("The Beatles", new List<int>());

void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda!");
    Console.WriteLine("Digite 2 para mostrar todas as bandas!");
    Console.WriteLine("Digite 3 para avaliar uma banda!");
    Console.WriteLine("Digite 4 para exibir a média de banda!");
    Console.WriteLine("Digite -1 para sair!");

    Console.Write("\nDigite a opção: ");
    string opcaoEscolhida = Console.ReadLine()!; 
    // ! = sinal para informar que não queremos receber um dado nulo = null.

    // Realizando a conversão de um tipo.
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBanda();
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: AvaliarUmaBanda();
            break;
        case 4: MediaDasBandas();
            break;
        case -1: Console.WriteLine("Você escolheu a opção " + opcaoEscolhidaNumerica);
            break;
        default: Console.WriteLine("Opção Inválida!!!");
            break;
    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro das Bandas!");
    Console.Write("Digite o nome da banda: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda.ToUpper()} foi registrada com sucesso!");
    // Thread = Esperar alguns milesegundos para mostrar as informações.
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo Todas as Bandas Registradas");
    // Realizando um for com o interador i iniciando em 0 e enquanto i for menor que a quantidade de itens dentro da lista ele vai incrementando
    // rodando até que chegue ao final da lista.

        //for (int i = 0; i < listadasbandas.count; i++)
        //{
        //    console.writeline($"banda: {listadasbandas[i]}");
        //}

    //Em resumo, use for quando precisar de controle detalhado sobre a iteração, e foreach quando quiser iterar sobre uma coleção de maneira simples e direta,
    //sem a necessidade de manipular índices ou alterar a coleção durante a iteração.
    foreach (string banda in bandasRegistradas.Keys) 
    {
        Console.WriteLine($"Banda: {banda.ToUpper()}");
    }

    RetornarAoMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar Banda");
    // Digite a banda de avaliação
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    // Verificar se a banda existe
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda.ToUpper()} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        // aqui estamos indexando o e procurando o nome da banda para depois adicionar uma nota ao nome da banda que digitamos
        bandasRegistradas[nomeDaBanda].Add(nota);
    // Atribuir uma nota, se não existir voltar ao menu principal
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda.ToUpper()}!");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    } else 
    {
        Console.WriteLine($"\nA banda {nomeDaBanda.ToUpper()} não foi encontrada!");
        RetornarAoMenu();    
    }
}

void MediaDasBandas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliação Média de Bandas");
    Console.Write("Informe o nome da banda que deseja verificar a média: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.WriteLine($"A banda {nomeDaBanda.ToUpper()} foi selecionada!");
        double mediaBanda = bandasRegistradas[nomeDaBanda].Average();
        Console.WriteLine($"\nA média da banda {nomeDaBanda.ToUpper()} é {mediaBanda.ToString("F1")}!");
        Thread.Sleep(4000);
        RetornarAoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda.ToUpper()} não foi encontrada!");
        RetornarAoMenu();
    }
}

void RetornarAoMenu()
{
    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal!");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

ExibirOpcoesDoMenu();