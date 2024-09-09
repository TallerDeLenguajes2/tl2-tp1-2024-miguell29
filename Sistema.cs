using System.Runtime.InteropServices;

public class Sistema
{
    private List<Cadete> listadoCadetes;
    private Cadeteria cadeteria;
    public Sistema(List<Cadete> listadoCadetes, Cadeteria cadeteria)
    {
        ListadoCadetes = listadoCadetes;
        Cadeteria = cadeteria;
    }

    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
    public Cadeteria Cadeteria { get => cadeteria; set => cadeteria = value; }

    public void Init(){
    var salir = false;
    do
    {
        Menu.Dibujar();
        if (!int.TryParse(Console.ReadLine(),out var opcion))
        {
            Console.Clear();
            Console.WriteLine("opcion no válida - intente de nuevo");
            continue;
        }

        switch (opcion)
        {
            case 1:
                AltaPedido();
            break;
            case 2:
                AsignarPedido();
            break;
            case 3:
                CambiarEstadoPedido();
            break;
            case 4:
                ReasignarPedido();
            break;
            case 0:
                Console.WriteLine("Saliendo...");
                salir = true;
                Thread.Sleep(2000);
            break;
        }
        Console.Clear();
    } while (!salir);
    }

    private void AltaPedido()
    {

    }
    private void AsignarPedido()
    {

    }
    private void CambiarEstadoPedido()
    {

    }
    private void ReasignarPedido()
    {

    }
}