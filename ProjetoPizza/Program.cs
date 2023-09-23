using ProjetoPizza.Models;

Console.WriteLine("Bem-vindo(a) ao Projeto Pizzaria!\n");

int opcao;

static void Menu()
{
        Console.WriteLine("Escolha uma opção: ");
        Console.WriteLine("1 - Adicionar Pizza");
        Console.WriteLine("2 - Listar as Pizzas");
        Console.WriteLine("3 - Criar Novo Pedido");
        Console.WriteLine("4 - Listar Pedidos");
        Console.WriteLine("0 - Sair\n");
        Console.WriteLine("Digite sua opção: ");
}

do
{
    Menu();
    opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 1:
                Console.Clear();
                Pizza.AdicionarPizza();
        break;
        case 2:
                Console.Clear();
                Pizza.ListarPizza();
        break;
        case 3:
                Console.Clear();
                Pedido.CriarPedido();
        break;
        case 4:
                Console.Clear();
                Pedido.ListarPedidos();
        break;
    }

} while (opcao != 0);