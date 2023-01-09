// See https://aka.ms/new-console-template for more information
using IntroEFCore.Data;
using IntroEFCore.Model;
using IntroEFCore.ValueObjects;



static void InserirDados() {
    Produto produto = new Produto {
        Descricao = "Produto Teste",
        CodigoDeBarras = "1233445123245",
        Valor = 10m,
        TipoProduto = TipoProduto.MercadoriaParaRevenda,
        Ativo = true,
    };

    ApplicationContext db = new ApplicationContext();
    db.Produtos.Add(produto);
    var registros = db.SaveChanges();
    Console.WriteLine(registros);
}

InserirDadosEmMassa();

static void InserirDadosEmMassa()
{
    Produto produto = new Produto
    {
        Descricao = "Produto Teste",
        CodigoDeBarras = "1233445123245",
        Valor = 10m,
        TipoProduto = TipoProduto.MercadoriaParaRevenda,
        Ativo = true,
    };
    Cliente cliente= new Cliente
    {
        Nome = "Fulano",
        CEP = "99999999",
        Cidade = "Itabaina",
        Estado = "SE",
        Telefone = "23432",
    };

    var db = new ApplicationContext();
    db.AddRange(produto, cliente);
    var registros = db.SaveChanges();
    Console.WriteLine(registros);
}