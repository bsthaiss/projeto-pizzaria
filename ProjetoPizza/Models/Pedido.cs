namespace ProjetoPizza.Models
{
    public class Pedido
    {
        public string Cliente { get; set; }
        public string Telefone { get; set; }
        public List<Pizza> EscolhaPizzas { get; set; } = new List<Pizza>();
        public double Total => EscolhaPizzas.Sum(pizza => pizza.Preco);
        public static List<Pedido> ListaDePedidos { get; } = new List<Pedido>();
        public bool Pago { get; set; } = false;
        private static List<string> formasPagamento = new List<string>();
        private static double valorPagoTotal = 0;

        public static void CriarPedido()
        {
            Console.WriteLine("Criar Pedido!");

            var pedido = new Pedido();

            Console.WriteLine("Quem é o cliente?");
            pedido.Cliente = Console.ReadLine();
            Console.WriteLine("Qual é o telefone do cliente?");
            pedido.Telefone = Console.ReadLine();

            do
            {
                Console.WriteLine("Escolha uma pizza para adicionar: ");

                for (int i = 0; i < Pizza.ListaDePizzas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {Pizza.ListaDePizzas[i].Nome} - R$ {Pizza.ListaDePizzas[i].Preco:F2}");
                }

                if (int.TryParse(Console.ReadLine(), out int escolha) && escolha >= 1 && escolha <= Pizza.ListaDePizzas.Count)
                {
                    pedido.EscolhaPizzas.Add(Pizza.ListaDePizzas[escolha - 1]);
                }
                else
                {
                    Console.WriteLine("Opção inválida. Escolha um número válido.");
                }

                Console.WriteLine("Deseja acrescentar mais alguma pizza? (1 - SIM | 2 - NÃO)");
            } while (Console.ReadLine() == "1");

            Console.WriteLine("PEDIDO CRIADO!");
            Console.WriteLine($"Total: R$ {pedido.Total:F2}");
            ListaDePedidos.Add(pedido);
        }

        public static void ListarPedidos()
        {
            Console.WriteLine("LISTA DE PEDIDOS: ");

            for (int i = 0; i < ListaDePedidos.Count; i++)
            {
                var pedido = ListaDePedidos[i];
                Console.WriteLine($"Número do Pedido: {i + 1}");
                Console.WriteLine("Cliente: " + pedido.Cliente);
                Console.WriteLine("Telefone: " + pedido.Telefone);
                Console.WriteLine("Pizzas do Pedido:");

                foreach (var pizza in pedido.EscolhaPizzas)
                {
                    Console.WriteLine($"Nome da pizza: {pizza.Nome} - R$ {pizza.Preco:F2}");
                }

                Console.WriteLine($"Total: R$ {pedido.Total:F2}");

                if (pedido.Pago)
                {
                    Console.WriteLine("Status do Pagamento: Pago");
                }
                else
                {
                    Console.WriteLine("Status do Pagamento: Pagamento Pendente");
                }

                Console.WriteLine();
            }
        }
    }
}