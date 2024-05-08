const int DolarLibre = 985;
int dineroMax = int.MinValue, plataAbonada;
double Promedio, CambioADolar, SumaTotal = 0;
string PersonaConMasPlataAbonada = "", persona, nombreABuscar;
char Eleccion = 'a';
List<string> NombreEstudiantes = new List<string>();
List<int> AporteEstudiantes = new List<int>();

do{
    Console.WriteLine("1. Ingresar los importes (dejar el nombre vacío para salir del ingreso de dinero)");
    Console.WriteLine("2. Ver estadísticas");
    Console.WriteLine("3. Consultar cuánta plata puso una persona");
    Console.WriteLine("4. Salir");

    Eleccion = char.Parse(Console.ReadLine());

    switch(Eleccion)
    {
        case '1':
            persona = IngresoStr("Ingrese su nombre");
            if(persona != "")
            {
                do
                {
                    plataAbonada = IngresoInt("Ingrese la cantidad que quiera abonar");
                }while(plataAbonada <= 0);

                NombreEstudiantes.Add(persona);
                AporteEstudiantes.Add(plataAbonada);
            }
            break;
        
        case '2':
            if(NombreEstudiantes.Count != 0)
            {
                for(int i = 0; i < AporteEstudiantes.Count; i++)
                {
                    if(dineroMax < AporteEstudiantes[i])
                    {
                        dineroMax = AporteEstudiantes[i];
                        PersonaConMasPlataAbonada = NombreEstudiantes[i];
                    }

                    SumaTotal += AporteEstudiantes[i];
                }

                Promedio = AporteEstudiantes.Average();

                CambioADolar = SumaTotal / DolarLibre;

                Console.WriteLine($"La persona que mas abono actualmente fue {PersonaConMasPlataAbonada} con un monto de {dineroMax} pesos");
                Console.WriteLine($"Promedio de plata abonada: {Promedio} pesos");
                Console.WriteLine($"Recaudacion total: {SumaTotal} pesos");
                Console.WriteLine($"Estudiantes que participaron en el regalo: {NombreEstudiantes.Count}");
                Console.WriteLine($"Dolares recaudados: {Math.Round(CambioADolar, 3)}");

                Console.WriteLine("");

                SumaTotal = 0; 
                dineroMax = 0;
            }
            else
            {
                Console.WriteLine("No hay ningun valor para mostrar.");
                Console.WriteLine("");
            }
            
            break;

        case '3':
            int posicionAEncontrar = 0;

            if(NombreEstudiantes.Count != 0)
            {
                nombreABuscar = IngresoStr("Ingrese un nombre y le diremos la cantidad de plata abonada");
                if(NombreEstudiantes.Contains(nombreABuscar))
                {
                    posicionAEncontrar = NombreEstudiantes.IndexOf(nombreABuscar);

                    Console.WriteLine($"Nombre: {NombreEstudiantes[posicionAEncontrar]}");
                    Console.WriteLine($"Plata abonada: {AporteEstudiantes[posicionAEncontrar]}");
                }
                else
                {
                    Console.WriteLine("Esa persona no se encuentra entre los alumnos que abonaron.");
                }

                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("No hay ninguna perona ingresada aun.");
                Console.WriteLine("");
            }
            
            break;
    }
    
}while(Eleccion != '4');

static string IngresoStr(string mensaje)
{
    string a;

    Console.WriteLine(mensaje);
    a = Console.ReadLine();

    return a;
}

static int IngresoInt(string mensaje)
{
    int a;

    Console.WriteLine(mensaje);
    a = int.Parse(Console.ReadLine());

    return a;
}
