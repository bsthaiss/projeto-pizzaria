using ProjetoPizza.Models;

Console.WriteLine("Bem-vindo(a) ao Projeto Pizzaria!\n");

int opcao;

static void Menu()
{
        Console.Clear();
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
                Pizza.AdicionarPizza();
        break;
        case 2:
                Pizza.ListarPizza();
        break;
        case 3:
                Pedido.CriarPedido();
        break;
        case 4:
                Pedido.ListarPedidos();
        break;
    }

} while (opcao != 0);