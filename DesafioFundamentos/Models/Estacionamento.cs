using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        public decimal receitaTotal = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // IMPLEMENTADO
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine(); //variavel para guardar a placa na lista
            veiculos.Add(placa); //adicionando na lista
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // IMPLEMENTADO
            string placa = Console.ReadLine(); //armazenando a placa numa variavel, para posteriormente fazer verificações

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // IMPLEMENTADO
                int horas = 0;
                decimal valorTotal = 0; 
                horas = Convert.ToInt32(Console.ReadLine()); //armazenando a quantidade de horas dita pelo usuario na variavel horas, convertendo seu valor para int32 para que seja realizado o calculo posteriormente
                valorTotal = precoInicial + precoPorHora * horas; //calculo do preço
                receitaTotal = receitaTotal + valorTotal; //armazenando a receita de todos os veiculos removidos nessa variavel para o metodo ReceitaTotal() mostrar o lucro total gerado pelo estacionamento

                // TODO: Remover a placa digitada da lista de veículos
                veiculos.Remove(placa);
                // IMPLEMENTADO

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // IMPLEMENTADO
                Console.WriteLine("Os veículos estacionados são:");
                int contador = 0; //o contador será usado apenas para ilustrar a posição dos veiculos
                foreach (string x in veiculos)
                {
                    Console.WriteLine($"Veículo n°{contador + 1} {x}"); //percorre a lista veiculos e escreve cada um dos elementos aqui, o contador está como contador + 1, pois os indices na programação sempre começam em 0, assim, ao fazermos com que o contador comece com +1 geramos uma interface mais amigavel para usuarios
                    contador++; //por fim o contador é incrementado em 1 para mostrar a posição do proximo item na proxima iteração
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public void ReceitaTotal()
        {
            string precoFormatado = receitaTotal.ToString("C"); //convertendo a receita total para string e na moeda local
            Console.WriteLine($"Até o momento a receita total é de {precoFormatado}"); //escrevendo a receita total na tela
        }
    }
}
