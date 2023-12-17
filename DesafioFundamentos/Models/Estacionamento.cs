namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();
        private Dictionary<string, decimal> GastosEPLacaDoCliente = new Dictionary<string, decimal>();


        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            veiculos.Add(placa);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                string horasMarcadas = Console.ReadLine();
                int desconto = VerificaDescontoCarro(placa);

                int horas = int.Parse(horasMarcadas);
                decimal valorTotal = (precoInicial + precoPorHora * horas) - (decimal)desconto;

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                Console.WriteLine("Obrigado pela hospedagem manteremos sua placa, para próxima ocorrência você ter um desconto conosco");
                string BancoDeDadosComDesconto = placa;
                DescontoEstacionamento(placa, valorTotal);
                veiculos.Remove(placa);
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
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                foreach(var item in veiculos){
                    Console.WriteLine($"Placa do veículo: {item}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
        public void DescontoEstacionamento(string PlacaDescontoCarros, decimal valorTotal){
            if(!GastosEPLacaDoCliente.ContainsKey(PlacaDescontoCarros)){
                GastosEPLacaDoCliente.Add(PlacaDescontoCarros, valorTotal);
                Console.WriteLine($"Lembrando que você poderá ter desconto, somente nessa placa: {PlacaDescontoCarros}");
            }
            else
            {
                Console.WriteLine("Você tem um desconto hoje");
            }
            //Console.WriteLine("Obrigado pela hospedagem, tenha um ótimo dia !");
            //lógico do desconto é sempre de 10% a menor então se ele gastou 50 nesse hospedagem e gastar 50 na próxima ele terá
            // 10R$ de desconto
        }
        public int VerificaDescontoCarro(string placa){
            if(GastosEPLacaDoCliente.ContainsKey(placa)){
                decimal GastosAnteriores = GastosEPLacaDoCliente[placa];
                double desconto = (double)GastosAnteriores * 0.10;
                
                Console.WriteLine($"Você teve uma passagem conosco, hoje teremos desconto com base na sua passada anterior");
                Console.WriteLine($"A placa é {placa}, você terá direito {desconto}% de desconto");
                return ((int)desconto);
            }
            else
            {
                Console.WriteLine($"Não achamos sua placa no nossa banco de dados, mas na próxima passagem já terá desconto !");
            }
            return(0);
        }
    }
}
