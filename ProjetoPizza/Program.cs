using ProjetoPizza.Models;

Console.WriteLine("Bem-vindo(a) ao Projeto Pizzaria!\n");

int opcao = 0;
List<Pizza> ListaDePizzas = new List<Pizza>();

do
{
    Console.WriteLine("Escolha uma opção: ");
    Console.WriteLine("1 - Adicionar Pizza");
    Console.WriteLine("2 - Listar as Pizzas\n");

    Console.WriteLine("Digite sua opção: ");
    opcao = int.Parse(Console.ReadLine());
    Console.Clear();

    switch (opcao)
    {
        case 1:
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
                Console.Clear();
        break;
        case 2:
                Console.Clear();
                Console.WriteLine("Listar as Pizzas");

                foreach (var pizza in ListaDePizzas)
                {
                        Console.WriteLine($"NOME: {pizza.Nome}");
                        Console.WriteLine($"SABORES: {pizza.Sabores}");

                        double preco = pizza.Preco;
                        preco.ToString("F2");
                        Console.WriteLine($"PREÇO: R$ {preco}\n");
                }

                Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...\n");
                Console.ReadKey();
        break;
    }

} while (opcao > 0 && opcao <= 4);