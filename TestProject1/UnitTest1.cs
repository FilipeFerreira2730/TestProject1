using BusinessLogic.Context;
using BusinessLogic.Entities;
using NUnit.Framework;
namespace TestProject1;
using Xunit;


public class Tests
{
    private static ES2DbContext _Context;
    
    [OneTimeSetUp]
    public void Setup()
    {
        _Context = new ES2DbContext();
    }
    [Fact]
    public void Test1()
    {
    }
    
    [TestCase("Gonçalo ","123213", "123456", "rua de baixo","2","gon","gon123", "4755-200", 1)]
    [TestCase("Pedro ","95132326", "7879545", "rua de cima","75","pedro","1234y2", "4100-010", 2)]
    [TestCase("Ana ","876867", "86786677", "rua das coisas","12","anaadmin","ana1234", "3333-333", 3)]
    [TestCase("Filipe ","55555123", "76554443", "rua do picoto","35","filipenadmin","adminfilipe", "4755-179", 3)]
    public async Task TestInsertUtilizador(string Nome, string nif, string ncc, string rua, int n_porta, string username, string pass, string codpostal, int tipouser)
    {
        var user = new Utilizadors
        {
            Nome = Nome,
            nif = nif,
            ncc = ncc,
            rua = rua,
            n_porta = n_porta,
            username = username,
            pass = pass,
            codpostal = codpostal,
            tipoutilizador = tipouser
        };

        _Context.Add(user);
        await _Context.SaveChangesAsync();

    }
    
    [TestCase("8ba74e96-d521-4e1f-b6b9-4a1244a10b96", "Gonçalo Novais", "123213", "123456", "rua de baixo", 2, "gonnov", "novais123", "4755-200", 1)]
    public async Task updateUser(Guid IdUtilizador, string Nome, string nif, string ncc, string rua, int n_porta, string username, string pass, string codpostal, int tipouser)
    {
        var user = new Utilizadors
        {
            IdUtilizador = IdUtilizador,
            Nome = Nome,
            nif = nif,
            ncc = ncc,
            rua = rua,
            n_porta = n_porta,
            username = username,
            pass = pass,
            codpostal = codpostal,
            tipoutilizador = tipouser
        };
        
        _Context.Update(user);
        await _Context.SaveChangesAsync();

    }

    [Test]
    public Task ListUsers()
    {
        var  utilizadores = _Context.Utilizadors.ToList();

        foreach (Utilizadors u in utilizadores){
            Console.WriteLine("---------------------------");
            Console.WriteLine("Nome: " + u.Nome);
            Console.WriteLine("Nif: " + u.nif);
            Console.WriteLine("Ncc: " + u.ncc);
            Console.WriteLine("Rua: " + u.rua);
            Console.WriteLine("Nporta: " + u.n_porta);
            Console.WriteLine("User: " + u.username);
            Console.WriteLine("Pass: " + u.pass);
            Console.WriteLine("Codpostal: " + u.codpostal);
            Console.WriteLine("TipoUser: " + u.tipoutilizador);
            Console.WriteLine("---------------------------");
        }

        return Task.CompletedTask;
    }

    
    [TestCase("12/12/2021", 32, 20, "8ba74e96-d521-4e1f-b6b9-4a1244a10b96")]
    public async Task TestInsertAtivo(DateTime datainicio, int duracao, double taxatimposto, Guid idcliente)
    {
        var ativo = new Ativofinanceiros
        {
            datainicio = datainicio,
            duracao = duracao,
            taxaimposto = taxatimposto,
            idcliente = idcliente
        };

        _Context.Add(ativo);
        await _Context.SaveChangesAsync();
    }
    [TestCase("02/12/2021", 32, 20, "8ba74e96-d521-4e1f-b6b9-4a1244a10b96")]
    public async Task TestUpdateAtivo(DateTime datainicio, int duracao, double taxatimposto, Guid idcliente)
    {
        var ativo = new Ativofinanceiros
        {
            datainicio = datainicio,
            duracao = duracao,
            taxaimposto = taxatimposto,
            idcliente = idcliente
        };

        _Context.Update(ativo);
        await _Context.SaveChangesAsync();
    }
    
    [TestCase("Fundo1", 10000, 0.12, "8ba74e96-d521-4e1f-b6b9-4a1244a10b96")]
    public async Task TestInsertFundo(string nome, double montante, double taxajuro, Guid idativofk)
    {
        var ativo = new Fundos
        {
            nome = nome,
            montante = montante,
            taxajuro = taxajuro,
            idativofk = idativofk
        };

        _Context.Add(ativo);
        await _Context.SaveChangesAsync();
    }

    [TestCase("Fundo1", 9000, 0.12, "8ba74e96-d521-4e1f-b6b9-4a1244a10b96")]
    public async Task TestUpdateFundo(string nome, double montante, double taxajuro, Guid idativofk)
    {
        var ativo = new Fundos
        {
            nome = nome,
            montante = montante,
            taxajuro = taxajuro,
            idativofk = idativofk
        };

        _Context.Update(ativo);
        await _Context.SaveChangesAsync();
    }
    
    [TestCase("Banco1", "Pessoa1", 10000, 0.12, "12356", "8ba74e96-d521-4e1f-b6b9-4a1244a10b96")]
    public async Task TestInsertDeposito(string banco, string titulares, double valor, double taxajuro, string nconta, Guid idativofk)
    {
        var ativo = new Depositos
        {
            banco = banco,
            titulares = titulares,
            valor = valor,
            taxajuro = taxajuro,
            nconta = nconta,
            idativofk = idativofk
        };

        _Context.Add(ativo);
        await _Context.SaveChangesAsync();
    }
    [TestCase("Banco1", "Pessoa2", 10000, 0.12, "12356", "8ba74e96-d521-4e1f-b6b9-4a1244a10b96")]
    public async Task TestUpdateDeposito(string banco, string titulares, double valor, double taxajuro, string nconta, Guid idativofk)
    {
        var ativo = new Depositos
        {
            banco = banco,
            titulares = titulares,
            valor = valor,
            taxajuro = taxajuro,
            nconta = nconta,
            idativofk = idativofk
        };

        _Context.Update(ativo);
        await _Context.SaveChangesAsync();
    }
    
    [TestCase("Casa-t3", 200.0, 500, 100, "rua de cima", "173", "4322", "8ba74e96-d521-4e1f-b6b9-4a1244a10b96")]
    public async Task TestInsertImovel(string nome, double? valorrenda, double valorcondo, double valoresti, string rua, string nporta, string codpostal, Guid idativofk)
    {
        var ativo = new Imovels
        {
            nome = nome,
            valorrenda = valorrenda ?? 0.0,
            valorcondo = valorcondo,
            valoresti = valoresti,
            rua = rua,
            nporta = nporta,
            codpostal = codpostal,
            idativofk = idativofk
        };

        _Context.Add(ativo);
        await _Context.SaveChangesAsync();
    }
    
    [TestCase("Casa-t3", 500.0, 100, 1000, "rua de cima", "173", "4322", "8ba74e96-d521-4e1f-b6b9-4a1244a10b96")]
    public async Task TestUpdateImovel(string nome, double? valorrenda, double valorcondo, double valoresti, string rua, string nporta, string codpostal, string idativofk)
    {
        var ativo = new Imovels
        {
            nome = nome,
            valorrenda = valorrenda ?? 0.0,
            valorcondo = valorcondo,
            valoresti = valoresti,
            rua = rua,
            nporta = nporta,
            codpostal = codpostal,
            idativofk = Guid.Parse(idativofk)
        };


        _Context.Update(ativo);
        await _Context.SaveChangesAsync();
    }
}