namespace ProjetoPizza.Models
{
    public class Pizza
    {
        public string Nome { get; set; }
        public string Sabores { get; set; }
        public double Preco { get; set; }     
        public static List<Pizza> ListaDePizzas { get; set; } = new List<Pizza>();
        public static void AdicionarPizza()
        {
            var novaPizza = new Pizza();

            Console.WriteLine("Adicionar Pizza!");

            Console.WriteLine("Digite o nome da pizza: ");
            novaPizza.Nome = Console.ReadLine();
            Console.WriteLine("Digite o sabor da pizza separados por vírgulas: ");
            novaPizza.Sabores = Console.ReadLine();
            Console.WriteLine("Digite o preço da pizza no formato (00,00): ");
            novaPizza.Preco = double.Parse(Console.ReadLine());

            Console.WriteLine("PIZZA CRIADA COM SUCESSO!");
            ListaDePizzas.Add(novaPizza);
        }

        public static void ListarPizza()
        {
            Console.WriteLine("Listar as Pizzas");

                foreach (var pizza in ListaDePizzas)
                {
                        Console.WriteLine($"NOME: {pizza.Nome}");
                        Console.WriteLine($"SABORES: {pizza.Sabores}");
                        Console.WriteLine($"PREÇO: R$ {pizza.Preco:F2}\n");
                }

                Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...\n");
                Console.ReadKey();
        }
    }
}