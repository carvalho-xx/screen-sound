namespace ScreenSound
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> listaDasBandas = new List<string>();

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

            void SalvarBanda()
            {
                Console.Clear();
                Console.WriteLine("Salvando uma banda...");
                Console.Write("Digite o nome da banda que deseja salvar: ");
                string nomeBanda = Console.ReadLine()!;
                listaDasBandas.Add(nomeBanda);
                Console.WriteLine($"A banda {nomeBanda} foi salva com sucesso!");
                Thread.Sleep(2000);
                Console.Clear();
                ExibirOpcoesDeMenu();
            }

            void ListarBandas()
            {
                Console.Clear();
                Console.WriteLine("Listando todas as bandas");
                if (listaDasBandas.Count == 0)
                {
                    Console.WriteLine("Nenhuma banda cadastrada.");
                }
                else
                {
                    foreach (string banda in listaDasBandas) 
                    {
                        Console.WriteLine($"- {banda}");
                    }
                }
                Console.WriteLine("\nDigite qualquer tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                ExibirOpcoesDeMenu();
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
                        Console.WriteLine("Avaliar uma banda");
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
