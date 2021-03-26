using System;

namespace DesafioTransferenciaBancaria
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public bool Sacar(double valorDoSaque) 
        {
            if (this.Saldo - valorDoSaque < (this.Credito *-1))
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }

            this.Saldo -= valorDoSaque;
            Console.WriteLine("O saldo atual da conta de {0} é de {1} reais. ", this.Nome, this.Saldo);
            return true;
        }

        public void Depositar(double ValorDoDeposito) 
        {
            this.Saldo += ValorDoDeposito;
            Console.WriteLine("O saldo atual da conta de {0} é de {1} reais. ", this.Nome, this.Saldo);
        }

        public void Transferir(double valorDaTransferencia, Conta contaDeDestino) 
        {
            if (this.Sacar(valorDaTransferencia))
            {
                contaDeDestino.Depositar(valorDaTransferencia);
            }
        }

        public Conta (TipoConta tipoConta, double saldo, double credito, string nome) {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Credito: " + this.Credito;
            return retorno;
        }
    }
}