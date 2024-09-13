
public class Sistema
{
    private Cadeteria cadeteria;
    private List<Pedido> listadoPedidos;
    private int idPedido = 1;

    public Sistema(List<Cadete> listadoCadetes, Cadeteria cadeteria)
    {
        Cadeteria = cadeteria;
        cadeteria.ListadoCadetes = listadoCadetes;
        listadoPedidos = Cadeteria.ListadoPedidos;
    }

    public Cadeteria Cadeteria { get => cadeteria; set => cadeteria = value; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public void Init()
    {
        var salir = false;
        do
        {
            Menu.Dibujar();
            if (!int.TryParse(Console.ReadLine(), out var opcion))
            {
                Console.Clear();
                Console.WriteLine("opcion no válida - intente de nuevo");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    AltaPedido();
                    Console.WriteLine("Pedido dado de alta correctamente");
                    Console.WriteLine("Presione una tecla para continuar");
                    Console.ReadKey(true);
                    break;
                case 2:
                    AsignarPedido();
                    Console.WriteLine("Presione una tecla para continuar");
                    Console.ReadKey(true);
                    break;
                case 3:
                    CambiarEstadoPedido();
                    Console.WriteLine("Presione una tecla para continuar");
                    Console.ReadKey(true);
                    break;
                case 4:
                    ReasignarPedido();
                    Console.WriteLine("Presione una tecla para continuar");
                    Console.ReadKey(true);
                    break;
                case 5:
                    MostrarInforme();
                    Console.WriteLine("Presione una tecla para continuar");
                    Console.ReadKey(true);
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
        var Cliente = AgregarCliente();
        var pedido = new Pedido(idPedido++);
        pedido.Cliente = Cliente;
        listadoPedidos.Add(pedido);
    }
    private void AsignarPedido()
    {
        var pedidosPreparados = listadoPedidos.Where(x => x.Estado == Estado.Preparado).ToList();
        if (pedidosPreparados.Count > 0)
        {
            Console.WriteLine("seleccione el pedido");
            foreach (var item in pedidosPreparados)
            {
                Console.WriteLine($"idPedido: {item.Nro} -- cliente: {item.Cliente.Nombre} -- Estado: {item.Estado}");
            }
            Console.WriteLine("ingrese el id del pedido");
            if (int.TryParse(Console.ReadLine(), out var idPedidoSeleccionado))
            {
                var pedido = pedidosPreparados.FirstOrDefault(x => x.Nro == idPedidoSeleccionado);
                Console.WriteLine("Seleccione al cadete");
                foreach (var item in cadeteria.ListadoCadetes)
                {
                    Console.WriteLine($"id:  {item.Id} -- nombre: {item.Nombre}");
                }
                Console.WriteLine("ingrese el id del cadete");
                if (int.TryParse(Console.ReadLine(), out var idCadeteSeleccionado))
                {
                    var cadete = cadeteria.ListadoCadetes.FirstOrDefault(x => x.Id == idCadeteSeleccionado);
                    if (cadete == null || !cadeteria.AsignarCadeteAPedido(cadete.Id, pedido.Nro))
                    {
                        Console.WriteLine("ocurrio un error, intente de nuevo");
                    }
                }
                else
                {
                    Console.WriteLine("ocurrio un error, intente de nuevo");
                }
            }
            else
            {
                Console.WriteLine("Ocurrio un error intente de nuevo");
            };
        }
        else
        {
            Console.WriteLine("No hay pedidos preparados para asignar a un cadete");
        }
    }
    private void CambiarEstadoPedido()
    {
        if (listadoPedidos.Count > 0)
        {
            Console.WriteLine("Seleccione el pedido");
            foreach (var item in listadoPedidos)
            {
                if (item.Cadete != null)
                {
                    Console.WriteLine($"id: {item.Nro} -- cliente: {item.Cliente.Nombre} -- Estado: {item.Estado} -- Cadete: {item.Cadete.Nombre}");
                }
                else
                {
                    Console.WriteLine($"id: {item.Nro} -- cliente: {item.Cliente.Nombre} -- Estado: {item.Estado}");
                }
            }
            Console.WriteLine("ingrese el id:");
            if (int.TryParse(Console.ReadLine(), out var idPedido))
            {
                Console.Clear();
                var pedido = listadoPedidos.FirstOrDefault(x => x.Nro == idPedido);
                if (pedido != null)
                {
                    Console.WriteLine($"id: {pedido.Nro} -- cliente: {pedido.Cliente.Nombre} -- Estado: {pedido.Estado}");
                    Console.WriteLine("Seleccione el nuevo estado");
                    Console.WriteLine("1. En preparacion");
                    Console.WriteLine("2. Preparado");
                    Console.WriteLine("3. En camino");
                    Console.WriteLine("4. Entregado");
                    Console.WriteLine("ingrese el numero del estado");
                    if (int.TryParse(Console.ReadLine(), out var nuevoEstado))
                    {
                        switch (nuevoEstado)
                        {
                            case 1:
                                pedido.Estado = Estado.EnPreparacion;
                                break;
                            case 2:
                                pedido.Estado = Estado.Preparado;
                                break;
                            case 3:
                                pedido.Estado = Estado.EnCamino;
                                break;
                            case 4:
                                pedido.Estado = Estado.Entregado;
                                break;
                            default:
                                Console.WriteLine("Estado no válido - intente de nuevo");
                                break;
                        }
                        Console.WriteLine("Estado cambiado con exito");
                    }
                    else
                    {
                        Console.WriteLine("ocurrio un error intente de nuevo");
                    }

                }
                else
                {
                    Console.WriteLine("id inválido, intente de nuevo");
                }
            }
            else
            {
                Console.WriteLine("ocurrio un error, intente de nuevo");
            }
        }
        else
        {
            Console.WriteLine("Aún no hay pedidos cargados al sistema");
        }
    }
    private void ReasignarPedido()
    {
        var pedidosAsignados = ListadoPedidos.Where(x => x.Estado == Estado.EnCamino).ToList();
        if (pedidosAsignados.Count > 0)
        {
            Console.WriteLine("Pedidos para reasignar:");
            foreach (var item in pedidosAsignados)
            {
                Console.WriteLine($"idPedido: {item.Nro} -- cliente: {item.Cliente.Nombre} -- Estado: {item.Estado}");
            }
            Console.WriteLine("ingrese el id del pedido.");
            if (int.TryParse(Console.ReadLine(), out var idPedidoSeleccionado))
            {
                var pedido = pedidosAsignados.FirstOrDefault(x => x.Nro == idPedidoSeleccionado);
                var cadete1 = pedido.Cadete;

                Console.WriteLine("Seleccione al cadete que desea reasignar");
                foreach (var item in cadeteria.ListadoCadetes)
                {
                    if (item != cadete1)
                    {
                        Console.WriteLine($"id:  {item.Id} -- nombre: {item.Nombre}");
                    }
                }
                Console.WriteLine("ingrese el id del cadete");
                if (int.TryParse(Console.ReadLine(), out var idCadeteSeleccionado))
                {
                    var cadete2 = cadeteria.ListadoCadetes.FirstOrDefault(x => x.Id == idCadeteSeleccionado);
                    if (cadete2 == null || !cadeteria.AsignarCadeteAPedido(idCadeteSeleccionado, pedido.Nro))
                    {
                        Console.WriteLine("ocurrio un error, intente de nuevo");
                    }
                }
                else
                {
                    Console.WriteLine("Id no válido, intente de nuevo");
                }
            }
            else
            {
                Console.WriteLine("Id no válido, intente de nuevo");
            };
        }
        else
        {
            Console.WriteLine("No hay pedidos para reasignar");
        }
    }
    private Cliente AgregarCliente()
    {
        Console.WriteLine(@"*Datos de cliente*");
        Console.WriteLine("Ingrese el nombre");
        var nombre = Console.ReadLine();
        Console.WriteLine("Ingrese la direccion");
        var direccion = Console.ReadLine();
        Console.WriteLine("Ingrese el telefono");
        if (!int.TryParse(Console.ReadLine(), out var telefono)) Console.WriteLine("error al ingresar el numero");
        Console.WriteLine("Ingrese algun dato de Referencia");
        var datosReferencia = Console.ReadLine();
        return new Cliente(nombre, direccion, telefono, datosReferencia);
    }
    public void MostrarInforme()
    {
        Console.WriteLine("Nombre de la cadeteria: " + cadeteria.Nombre);
        Console.WriteLine("Cantidad de envios por cadetes:");
        int pedidosEntregados = 0;
        int pedidosSinAsignar = 0;
        foreach (var item in cadeteria.ListadoCadetes)
        {
            var listadoPedidosAsignados = listadoPedidos.Where(x => x.Cadete != null);
            pedidosSinAsignar = listadoPedidos.Where(x => x.Cadete == null).Count();
            var envios = listadoPedidosAsignados.Where(x => x.Cadete.Id == item.Id && x.Estado == Estado.Entregado).Count();
            Console.WriteLine($"El cadete: {item.Nombre}, entregó {envios} pedidos");
            pedidosEntregados += envios;
        }
        Console.WriteLine($"Total de pedidos: {listadoPedidos.Count}");

        Console.WriteLine($"Total de envios entregados: {pedidosEntregados}");
        Console.WriteLine($"Promedio de envios por cadete: {(float)pedidosEntregados / cadeteria.ListadoCadetes.Count}");
        Console.WriteLine($"Monto ganado: ${pedidosEntregados * 500}");
        Console.WriteLine($"Pedidos sin entregar: {pedidosSinAsignar}");
    }

}