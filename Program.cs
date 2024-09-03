
Console.Clear();
Console.WriteLine("Cargando Datos...");
Thread.Sleep(1000);
Console.Clear();

var listadoCadetes = Datos.GetCadetes();
var Cadeteria = Datos.GetCadeteria();
if (listadoCadetes == null || Cadeteria == null)
{
    Console.WriteLine("No es posible iniciar la aplicacion.");
}else
{
    Console.WriteLine(@"->            BIENVENIDO            <-");
    Menu.Dibujar();
}






Console.ReadKey();