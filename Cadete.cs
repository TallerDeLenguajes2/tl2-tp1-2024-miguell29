public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private int telefono;
    private List<Pedido> listadoPedidos;

    public Cadete(int id, string nombre, string direccion, int telefono)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        listadoPedidos = new List<Pedido>{};
    }

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos;}

    public void JornalACobrar()
    {
        int total = listadoPedidos.Where(x => x.Estado == Estado.Entregado).Count() * 500;
        Console.WriteLine($"El total a cobrar es: {total}");
    }
    
    public void AgregarPedido(Pedido pedido)
    {
        ListadoPedidos.Add(pedido);
        pedido.Estado = Estado.EnCamino;
    }
    public void EliminarPedido(Pedido pedido)
    {

        if (listadoPedidos.Contains(pedido))
        {
            int indice = listadoPedidos.IndexOf(pedido);
            listadoPedidos[indice].Estado = Estado.Preparado;
            listadoPedidos.RemoveAt(indice);
        }
    }   
}