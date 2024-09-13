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
    public int JornalACobrar(int idCadete)
    {
        var listadoPedidosAsignados = listadoPedidos.Where(x => x.Cadete != null);
        int total = listadoPedidosAsignados.Where(x => x.Cadete.Id == idCadete && x.Estado == Estado.Entregado).Count() * 500;
        return total;
    }


    public bool AsignarCadeteAPedido(int idCadete, int idPedido)
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
            return true;
        }
        else
        {
            return false;
        }
    }
}
