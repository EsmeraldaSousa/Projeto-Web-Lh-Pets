namespace projeto_lh_pets;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        _ = app.MapGet("/", () => "Projeto_Lh_Pets");

        _ = app.UseStaticFiles();
        _ = app.MapGet("/index", (HttpContext contexto) =>
        {
            contexto.Response.Redirect("index.html", false);
        });

        Banco dba=new Banco();
        _ = app.MapGet("/listaClientes", (HttpContext contexto) =>
        {

            contexto.Response.WriteAsync(dba.GetListaString);
        });

        app.Run();
    }
}

internal class Banco
{
#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere adicionar o modificador "obrigatório" ou declarar como anulável.
    public Banco()
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere adicionar o modificador "obrigatório" ou declarar como anulável.
    {
    }

    public string GetListaString { get; internal set; }
}