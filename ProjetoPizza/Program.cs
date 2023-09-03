using ProjetoPizza.Models;

Console.WriteLine("Bem-vindo(a) à Pizzaria!\n");

Console.WriteLine("Escolha as opções:");
Console.WriteLine("1 - Adicionar uma Pizza");
Console.WriteLine("2 - Listar as Pizzas\n");

Console.Write("Escolha sua opção: ");
string opcao = Console.ReadLine();

List<Pizza> listaPizzas = new List<Pizza>();

if (opcao == "1") {
        var pizza = new Pizza();

        Console.Write("Digite o nome da pizza: ");
        pizza.Nome = Console.ReadLine();

        Console.Write("Digite os sabores da sua pizza (separados por vírgula): ");
        pizza.Sabores = Console.ReadLine().Split(",");

        Console.Write("Digite o preço da sua pizza (00,00): ");
        pizza.Preco = double.Parse(Console.ReadLine());
        
        Console.WriteLine("PIZZA CRIADA COM SUCESSO!");
        listaPizzas.Add(pizza);
}

else if (opcao == "2") {
        foreach (var pizza in listaPizzas)
        {
            Console.WriteLine($"Nome: {pizza.Nome}");
            Console.WriteLine($"Sabores: {string.Join(", ", pizza.Sabores)}"); 
            Console.WriteLine($"Preço: R$ {pizza.Preco}");
            Console.WriteLine();
        }
}