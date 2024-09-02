using System.Runtime.InteropServices;

class Cadeteria
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

    }
    public void AsignarPedido(Pedido pedido, Cadete cadete)
    {

    }
    public void ReasignarPedido(Pedido pedido, Cadete cadete)
    {

    }
}
