using System.Text.Json.Serialization;
public class Cadeteria
{
    [JsonPropertyName("nombre")]
    public string Nombre { get; set; }

    [JsonPropertyName("telefono")]
    public int Telefono { get; set; }
    private List<Cadete> listadoCadetes;
    private List<Pedido> listadoPedidos = [];

    public Cadeteria(string nombre, int telefono, List<Cadete> listadoCadetes)
    {
        Nombre = nombre;
        Telefono = telefono;
        this.listadoCadetes = listadoCadetes;
    }

    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public void MostrarInforme()
    {
        Console.WriteLine("Nombre de la cadeteria: " + Nombre);
        Console.WriteLine("Cantidad de envios por cadetes:");
        int pedidosEntregados = 0;
        int pedidosSinAsignar = 0;
        foreach (var item in listadoCadetes)
        {
            var listadoPedidosAsignados = listadoPedidos.Where(x => x.Cadete != null);
            pedidosSinAsignar = listadoPedidos.Where(x => x.Cadete == null).Count();
            var envios = listadoPedidosAsignados.Where(x => x.Cadete.Id == item.Id && x.Estado == Estado.Entregado).Count();
            Console.WriteLine($"El cadete: {item.Nombre}, entregó {envios} pedidos");
            pedidosEntregados += envios;
        }
        Console.WriteLine($"Total de pedidos: {listadoPedidos.Count}");

        Console.WriteLine($"Total de envios entregados: {pedidosEntregados}");
        Console.WriteLine($"Promedio de envios por cadete: {(float)pedidosEntregados / listadoCadetes.Count}");
        Console.WriteLine($"Monto ganado: ${pedidosEntregados * 500}");
        Console.WriteLine($"Pedidos sin entregar: {pedidosSinAsignar}");
    }
    public void JornalACobrar(int idCadete)
    {
        int total = ListadoPedidos.Where(x => x.Cadete.Id == idCadete && x.Estado == Estado.Entregado).Count() * 500;
        Console.WriteLine($"El total a cobrar es: {total}");
    }


    public void AsignarCadeteAPedido(int idCadete, int idPedido)
    {
        Cadete cadete = listadoCadetes.FirstOrDefault(cadete => cadete.Id == idCadete);
        Pedido pedido = listadoPedidos.FirstOrDefault(pedido => pedido.Nro == idPedido);
        if (cadete != null && pedido != null)
        {

            if (pedido.Cadete != cadete)
            {
                pedido.Cadete = cadete;
                pedido.Estado = Estado.EnCamino;
            }
        }
        else
        {
            Console.WriteLine("Error - Intente de nuevo");
        }
    }
}
