public class AccesoCSV : AccesoADatos
{
    public override List<Cadete> GetCadetes()
    {
        try
        {
            var file = "csv/cadetes.csv";
            var pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
            if (File.Exists(pathFile))
            {
                var cadetesCsv = File.ReadAllLines(pathFile);
                if (cadetesCsv.Length == 0)
                {
                    throw new Exception();
                }
                var cadetes = new List<Cadete> { };

                foreach (var cadeteCsv in cadetesCsv)
                {
                    var cadete = cadeteCsv.Split(",");
                    var id = int.Parse(cadete[0]);
                    var nombre = cadete[1];
                    var direccion = cadete[2];
                    var telefono = int.Parse(cadete[3]);

                    cadetes.Add(new Cadete(id, nombre, direccion, telefono));
                }
                return cadetes;
            }
            else
            {
                Console.WriteLine("'cadetes.csv' -> No encontrado");
                return null;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("ERROR AL LEER DATOS DE 'cadete.csv'");
            return null;
        }
    }
    public override Cadeteria GetCadeteria()
    {
        try
        {
            var file = "./csv/cadeteria.csv";
            var pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
            if (File.Exists(pathFile))
            {
                var cadeteriaCsv = File.ReadAllLines(pathFile);
                var cadeteria = cadeteriaCsv[0].Split(",");
                return new Cadeteria(cadeteria[0], int.Parse(cadeteria[1]), null);
            }
            else
            {
                Console.WriteLine("'cadeteria.csv' -> No encontrado");
                return null;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("ERROR AL LEER DATOS DE 'cadeteria.csv'");
            return null;
        }
    }
}