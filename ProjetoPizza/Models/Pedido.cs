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
        public static void RealizarPagamento()
        {
                Console.WriteLine("Realizar Pagamento");
                Console.WriteLine("Qual o número do pedido? ");

                for (int i = 0; i < ListaDePedidos.Count; i++)
                {
                    if (!ListaDePedidos[i].Pago)
                        Console.WriteLine($"#{i + 1}: Cliente - {ListaDePedidos[i].Cliente}, Total - R$ {ListaDePedidos[i].Total:F2}");
                }

                int numeroPedido = int.Parse(Console.ReadLine());

                while (numeroPedido < 1 || numeroPedido > ListaDePedidos.Count || ListaDePedidos[numeroPedido - 1].Pago)
                {
                    Console.WriteLine("Número de pedido INVÁLIDO ou já foi PAGO. Por favor, tente novamente.");
                }

                var pedidoSelecionado = ListaDePedidos[numeroPedido - 1];
                
                Console.WriteLine($"Pedido selecionado: Cliente - {pedidoSelecionado.Cliente}, Total - R$ {pedidoSelecionado.Total:F2}");

                Console.WriteLine("ESCOLHA A FORMA DE PAGAMENTO:");
                Console.WriteLine("1 - Dinheiro");
                Console.WriteLine("2 - Cartão de Débito");
                Console.WriteLine("3 - Vale-Refeição");

                while (formasPagamento.Count < 2)
                {
                    Console.Write("Opção: ");

                    int opcao = int.Parse(Console.ReadLine());
                    string formaPagamento = "";
                    double valorPago = 0;

                    switch (opcao)
                    {
                        case 1:
                            formaPagamento = "Dinheiro";
                            Console.Write("Valor em dinheiro: R$ ");
                            while (!double.TryParse(Console.ReadLine(), out valorPago) || valorPago < 0)
                            {
                                Console.Write("Valor inválido. Por favor, insira um valor válido: R$ ");
                            }
                        break;

                        case 2:
                            formaPagamento = "Cartão de Débito";
                            valorPago = pedidoSelecionado.Total;
                        break;

                        case 3:
                            formaPagamento = "Vale-Refeição";
                            valorPago = pedidoSelecionado.Total;
                        break;

                        default:
                            Console.WriteLine("Opção inválida. Por favor, tente novamente.");
                        continue;
                    }

                if (formasPagamento.Contains(formaPagamento))
                {  
                    Console.WriteLine("Essa forma de pagamento já foi utilizada para este pedido.");
                }

                else
                {
                    Console.WriteLine("Opção inválida. Por favor, tente novamente.");
                }
                
                formasPagamento.Add(formaPagamento);
                valorPagoTotal += valorPago;

                Console.WriteLine("Forma de pagamento adicionada com sucesso!!!");

                int resposta = 0;
                Console.WriteLine("Deseja adicionar outra forma de pagamento? (1 - SIM | 2 - NÃO)");

                if (resposta == 1)
                {
                    Console.WriteLine("Escolha umas das opções");
                    Console.WriteLine("1 - Dinheiro");
                    Console.WriteLine("2 - Cartão de Débito");
                    Console.WriteLine("3 - Vale-Refeição");

                    Console.ReadKey();
                }

                if (valorPagoTotal < pedidoSelecionado.Total)
                {
                    Console.WriteLine("Pagamento insuficiente. Operação cancelada.");
                } 
                else if (valorPagoTotal > pedidoSelecionado.Total && formasPagamento.Contains("Dinheiro"))
                {
                    Console.WriteLine($"Troco a ser devolvido: R$ {valorPagoTotal - pedidoSelecionado.Total:F2}");
                }

                Console.WriteLine("PAGAMENTO REALIZADO COM SUCESSO!!!");
                pedidoSelecionado.Pago = true;
            }   
        }
    }
}