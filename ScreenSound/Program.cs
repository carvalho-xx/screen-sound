using System.Runtime.InteropServices;
using System.Threading.Channels;

namespace ScreenSound
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<string> listaDasBandas = new List<string>();
            Dictionary<string, List<int>> bandasDictionary = new Dictionary<string, List<int>>();
            bandasDictionary.Add("Pink Floyd", new List<int> { 10, 9, 5 });
            bandasDictionary.Add("The Beatles", new List<int>());

            void ExibirLogo()
            {
                Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝

░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
                Console.WriteLine("Seja bem-vindo(a) ao ScreenSound!");
            }

            void ExibirTituloDaOpcao(string tituloDaOpcao)
            {
                int qtdAsterisco = tituloDaOpcao.Length;
                string asterisco = string.Empty.PadLeft(qtdAsterisco, '*');
                Console.WriteLine(asterisco);
                Console.WriteLine(tituloDaOpcao);
                Console.WriteLine(asterisco + "\n");
            }

            void SalvarBanda()
            {
                Console.Clear();
                ExibirTituloDaOpcao("Salvando uma banda");
                Console.Write("Digite o nome da banda que deseja salvar: ");
                string nomeBanda = Console.ReadLine()!;
                bandasDictionary.Add(nomeBanda,new List<int>());
                Console.WriteLine($"A banda {nomeBanda} foi salva com sucesso!");
                Thread.Sleep(2000);
                Console.Clear();
                ExibirOpcoesDeMenu();
            }

            void ListarBandas()
            {
                Console.Clear();
                ExibirTituloDaOpcao("Listando todas as bandas");
                if (bandasDictionary.Keys.Count == 0)
                { 
                    Console.WriteLine("Nenhuma banda cadastrada.");
                }
                else
                {
                    foreach (string banda in bandasDictionary.Keys) 
                    {
                        Console.WriteLine($"- {banda}");
                    }
                }
                Console.WriteLine("\nDigite qualquer tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                ExibirOpcoesDeMenu();
            }

            void AvaliarBanda()
            {
                Console.Clear();
                ExibirTituloDaOpcao("Avaliar banda");
                Console.Write("Digite o nome da banda que você deseja avaliar: ");
                string nomeDaBanda = Console.ReadLine();
                if (bandasDictionary.ContainsKey(nomeDaBanda))
                {
                    Console.Write($"Digite a nota que a banda {nomeDaBanda} merece: ");
                    int nota = int.Parse(Console.ReadLine()!);
                    bandasDictionary[nomeDaBanda].Add(nota);
                    Console.WriteLine($"\nA nota {nota} foi adicionada a banda {nomeDaBanda} com sucesso");
                    Console.WriteLine("Retornando ao menu principal");
                    Thread.Sleep(2000);
                }
                else
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"\nA banda {nomeDaBanda} não foi registrada!");
                    Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal");
                    Console.ReadKey();
                    Console.Clear();
                    ExibirOpcoesDeMenu();
                }
            }

            void ExibirOpcoesDeMenu()
            {
                ExibirLogo();
                Console.WriteLine(@"
Digite 1 para salvar uma banda
Digite 2 para listar todas as bandas
Digite 3 para avaliar uma banda
Digite 4 para exibir média de notas de uma banda
Digite -1 para sair");
                Console.WriteLine("\nDigite a opção desejada: ");
                int opcao = int.Parse(Console.ReadLine()!);
                switch (opcao)
                {
                    case 1:
                        SalvarBanda();
                        break;
                    case 2:
                        ListarBandas();
                        break;
                    case 3:
                        AvaliarBanda();
                        break;
                    case 4:
                        Console.WriteLine("Exibir média de notas de uma banda");
                        break;
                    case -1:
                        Console.WriteLine("Saindo...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        return;
                }
            }
            
            ExibirOpcoesDeMenu();
        }
    }
}
