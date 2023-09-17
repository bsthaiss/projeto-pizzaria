namespace ProjetoPizza.Models
{
    public class Pedido
    {
        public string Cliente { get; set; }
        public string Telefone { get; set; }
        public List<Pizza> EscolhaPizzas { get; set; } = new List<Pizza>();

        public double Total { get; set; }
        public static List<Pedido> ListaDePedidos = new List<Pedido>();

        public static void CriarPedido()
        {

            Console.WriteLine("Criar  Pedido!");

            var Pedido = new Pedido();

            Console.WriteLine("Quem é o cliente?");
            Pedido.Cliente = Console.ReadLine();
            Console.WriteLine("Qual é o telefone do cliente?");
            Pedido.Telefone = Console.ReadLine();

            int escolha, resposta;

            do
            {
                Console.WriteLine("Escolha uma pizza para adicionar: ");

                for (int i = 0; i < Pizza.ListaDePizzas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {Pizza.ListaDePizzas[i].Nome} - R$ {Pizza.ListaDePizzas[i].Preco:F2}");
                }

                escolha = int.Parse(Console.ReadLine());
                Pedido.EscolhaPizzas.Add(Pizza.ListaDePizzas[escolha - 1]);

                Console.WriteLine("Deseja acrescentar mais alguma pizza? (1 - SIM | 2 - NÃO)");
                resposta = int.Parse(Console.ReadLine());

            } while (resposta == 1);

            double totalPedido = 0;

            foreach (var pizza in Pedido.EscolhaPizzas)
            {
                totalPedido += pizza.Preco;
            }

            Pedido.Total = totalPedido;

            Console.WriteLine("PEDIDO CRIADO!");
            Console.WriteLine($"Total: R$ {totalPedido:F2}");
            ListaDePedidos.Add(Pedido);
        }

        public static void ListarPedidos()
        {

            Console.WriteLine("Listar Pedidos!");

            foreach (var pedido in ListaDePedidos)
            {
                Console.WriteLine($"CLIENTE: {pedido.Cliente}");
                Console.WriteLine($"TELEFONE: {pedido.Telefone}");
                Console.WriteLine("PIZZAS DO PEDIDO:");
                foreach (var pizza in pedido.EscolhaPizzas)
                {
                    Console.WriteLine($"Nome: {pizza.Nome}, Sabor: {pizza.Sabores}, Preço: R$ {pizza.Preco:F2}");
                }

                Console.WriteLine($"TOTAL: R$ {pedido.Total:F2}\n");
            }
        }
    }
}