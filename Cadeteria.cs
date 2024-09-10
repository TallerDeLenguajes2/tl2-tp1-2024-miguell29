
public class Cadeteria
{
    private string nombre;
    private int telefono;
    private List<Cadete> listadoCadetes;

    public Cadeteria(string nombre, int telefono, List<Cadete> listadoCadetes)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.listadoCadetes = listadoCadetes;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

    public void MostrarInforme()
    {
        Console.WriteLine("Nombre de la cadeteria: " + nombre);
        Console.WriteLine("Cantidad de envios por cadetes:");
        int pedidosEntregados = 0;
        foreach (var item in listadoCadetes)
        {
            int envios = item.ListadoPedidos.Where(x => x.Estado == Estado.Entregado).Count();
            Console.WriteLine($"El cadete: {item.Nombre}, entregó {envios} pedidos");
            pedidosEntregados += envios;
        }
        Console.WriteLine($"Total de envios: {pedidosEntregados}");
        Console.WriteLine($"Promedio de envios por cadete: {pedidosEntregados / listadoCadetes.Count}");
        Console.WriteLine($"Monto ganado: ${pedidosEntregados * 500}");
    }
    public void AsignarPedido(Pedido pedido, Cadete cadete)
    {
        cadete.AgregarPedido(pedido);
    }
    public void ReasignarPedido(Pedido pedido, Cadete cadete1, Cadete cadete2)
    {
        cadete1.EliminarPedido(pedido);
        cadete2.AgregarPedido(pedido);
    }
}
