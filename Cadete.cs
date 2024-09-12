public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private int telefono;
    

    public Cadete(int id, string nombre, string direccion, int telefono)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
    }

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }

    
    
    /*public void AgregarPedido(Pedido pedido)
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
    }*/   
}