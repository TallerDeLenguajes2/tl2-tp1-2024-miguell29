
public class Cadeteria
{
    private string nombre;
    private int telefono;
    private List<Cadete> listadoCadetes;
    private List<Pedido> listadoPedidos = [];

    public Cadeteria(string nombre, int telefono, List<Cadete> listadoCadetes)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.listadoCadetes = listadoCadetes;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public void MostrarInforme()
    {
        Console.WriteLine("Nombre de la cadeteria: " + nombre);
        Console.WriteLine("Cantidad de envios por cadetes:");
        int pedidosEntregados = 0;
        foreach (var item in listadoCadetes)
        {
            var envios = ListadoPedidos.Where(x => x.Cadete.Id == item.Id && x.Estado == Estado.Entregado).Count();
            Console.WriteLine($"El cadete: {item.Nombre}, entregó {envios} pedidos");
            pedidosEntregados += envios;
        }
        Console.WriteLine($"Total de envios: {pedidosEntregados}");
        Console.WriteLine($"Promedio de envios por cadete: {((float)pedidosEntregados / listadoCadetes.Count):2f}");
        Console.WriteLine($"Monto ganado: ${pedidosEntregados * 500}");
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
