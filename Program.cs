using System;
using System.Collections.Generic;

namespace DesafioTransferenciaBancaria
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() !="X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        Console.Clear();
                        Console.WriteLine("         ******************************");
                        Console.WriteLine("         ******* Opção inválida *******");            
                        Console.WriteLine("         ******************************");
                        ObterOpcaoUsuario();
                        throw new ArgumentOutOfRangeException();                                            
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.Clear();
            Console.WriteLine("  ***********************************************************");
            Console.WriteLine("  *****      Obrigado por utilizar nossos serviços!     *****");
            Console.WriteLine("  *****    Adoramos o tempo que você passou conosco!    *****");
            Console.WriteLine("  ***********************************************************");
            Console.ReadLine();
            
        }

        private static void Depositar()
        {
            Console.WriteLine("  Por favor informe os dados da conta para efetuar o depósito: ");
            Console.WriteLine("  ************************************************************");
            Console.WriteLine();

            Console.WriteLine("  Informe o nuemro da conta: ");
            int indiceContaNumero = int.Parse(Console.ReadLine());

            Console.WriteLine("  Informe o valor do depósito: ");
            double valorDoDeposito = double.Parse(Console.ReadLine());
            if (valorDoDeposito <= 0)
            {
                Console.WriteLine("  *******************************");
                Console.WriteLine("  ******  Valor incorreto  ******");     
                Console.WriteLine("  *******************************");
                System.Threading.Thread.Sleep(4000);
                
                return;
            }

            listContas[indiceContaNumero].Depositar(valorDoDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("  Por favor informe os dados da efetuar a saque: ");
            Console.WriteLine("  ***********************************************");
            Console.WriteLine();

            Console.WriteLine("  Inform o número da conta: ");
            int indiceContaNumero = int.Parse(Console.ReadLine());

            Console.WriteLine("  Informe o valor que deseja sacar: ");
            double indiceValorDoSaque = double.Parse(Console.ReadLine());
            if (indiceValorDoSaque <= 0)
            {
                Console.WriteLine("  *******************************");
                Console.WriteLine("  ******  Valor incorreto  ******");     
                Console.WriteLine("  *******************************");
                System.Threading.Thread.Sleep(4000);
                
                return;
            }

            listContas[indiceContaNumero].Sacar(indiceValorDoSaque);
        }

        private static void Transferir()
        {
            Console.WriteLine("  Por favor informe os dados da efetuar a transferência: ");
            Console.WriteLine("  *******************************************************");
            Console.WriteLine();

            Console.WriteLine("  Digite o número da conta de origem: ");
            int indiceContaDeOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("  Digite o número da conta de destino: ");
            int indiceContaDeDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("  Digite o valor que deseja transferir: ");
            double ValorDaTransferencia = double.Parse(Console.ReadLine());
            if (ValorDaTransferencia <= 0)
            {
                Console.WriteLine("  *******************************");
                Console.WriteLine("  ******  Valor incorreto  ******");     
                Console.WriteLine("  *******************************");
                System.Threading.Thread.Sleep(4000);
                
                return;
            }

            listContas[indiceContaDeOrigem].Transferir(ValorDaTransferencia, listContas[indiceContaDeDestino]);

        }

        private static void InserirConta()
        {
            Console.WriteLine("  Insira os dados da nova conta ");
            Console.WriteLine("  ************************************************");
            Console.WriteLine();
            
            Console.WriteLine("  Digite 1 para conta física ou 2 para conta jurídica: ");            
            int entradaTipoDeConta = int.Parse(Console.ReadLine());
            if ((entradaTipoDeConta > 2) || (entradaTipoDeConta == 0))
            {
                Console.WriteLine("  ***************************************");
                Console.WriteLine("  ******  Tipo de conta incorreta  ******");     
                Console.WriteLine("  ***************************************");
                System.Threading.Thread.Sleep(4000);
                
                return;
            }

            Console.WriteLine("  Informe o nome do cliente: ");
            string entradaNomeCliente = Console.ReadLine();

            Console.WriteLine("  Informe o valor do saldo inicial da conta: ");
            double entradaValorSaldoInicial = double.Parse(Console.ReadLine());
            if (entradaValorSaldoInicial <= 0)
            {
                Console.WriteLine("  *******************************");
                Console.WriteLine("  ******  Valor incorreto  ******");     
                Console.WriteLine("  *******************************");
                System.Threading.Thread.Sleep(4000);
                
                return;
            }

            Console.WriteLine("  Informe o valor do cheque especial: ");
            double entradaValorCreditoInicial = double.Parse(Console.ReadLine());
            if (entradaValorCreditoInicial < 0.0)
            {
                Console.WriteLine("  *******************************");
                Console.WriteLine("  ******  Valor incorreto  ******");     
                Console.WriteLine("  *******************************");
                System.Threading.Thread.Sleep(4000);
                
                return;
            }

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoDeConta,
                                        nome: entradaNomeCliente,
                                        saldo: entradaValorSaldoInicial,
                                        credito: entradaValorCreditoInicial);
            
            listContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("           Lista de contas cadastradas: ");
            Console.WriteLine("  ************************************************");
            Console.WriteLine();

            if (listContas.Count == 0)
            {
                Console.WriteLine("  Ainda não existe nenhuma conta cadastrada.");
                Console.WriteLine();
                Console.WriteLine();
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("# {0} - ", i);
                Console.WriteLine(conta);
            }
            Console.WriteLine();

            System.Threading.Thread.Sleep(5000);
        }

        private static string ObterOpcaoUsuario() 
        {           
            Console.WriteLine();
            Console.WriteLine("  ************************************************");
            Console.WriteLine("  *****       Bem vindo ao Banco GS!!!       *****");
            Console.WriteLine("  ***** Ficamos felizes em ver você a bordo! *****");
            Console.WriteLine("  *****  Por favor informe a opção desejada  *****");
            Console.WriteLine("  ************************************************");
            Console.WriteLine();

            Console.WriteLine("  ************************************************");
            Console.WriteLine("  ****** 1 - Lista contas         ****************");
            Console.WriteLine("  ****** 2 - Inserir nova conta   ****************");
            Console.WriteLine("  ****** 3 - Transferir           ****************");
            Console.WriteLine("  ****** 4 - Sacar                ****************");
            Console.WriteLine("  ****** 5 - Depositar            ****************");
            Console.WriteLine("  ****** C - Limpar tela          ****************");
            Console.WriteLine("  ****** X - Sair                 ****************");
            Console.WriteLine("  ************************************************");
            Console.WriteLine();

            string opcacaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcacaoUsuario;
        }
    }
}
