string apellido, nombre, mail, verificarLongitudDNI = "";
char eleccion;
int dni = 0, personaValidaParaVotar = 0, edadTotal = 0, ingresoDNI, dniPedido, ubicacionDNI, edadPersonaPedida;
double promedio;
DateTime fecha = new DateTime(1, 1, 1);
List<int> listaDNI = new List<int>();
List<DateTime> listaNacimientos = new List<DateTime>();
List<Persona> listaPersona = new List<Persona>();

do{
    eleccion = Eleccion();
    switch(eleccion){
        case '1':
            nombre = IngresoString("Ingrese su nombre: ");
            apellido = IngresoString("Ingrese su apellido: ");

            do{
                dni = IngresoINT("Ingrese su DNI: ");
                verificarLongitudDNI = dni.ToString();

                if(listaDNI.Contains(dni)){
                    Console.WriteLine("Este DNI ya esta en el padron, no es valido.");
                }
                else if(verificarLongitudDNI.Length != 8){
                    if(verificarLongitudDNI.Length > 8){
                        Console.WriteLine("Este DNI no es valido, tiene mas de 8 digitos");
                    }
                    else{
                        Console.WriteLine("Este DNI no es valido, tiene menos de 8 digitos");
                    }
                }
            }while(!listaDNI.Contains(dni) && verificarLongitudDNI.Length != 8);

            fecha = IngresoFecha("Ingrese su fecha de nacimiento: ");
            
            do{
                mail = IngresoString("Ingrese su mail:");
                if(!mail.Contains("@gmail.com")){
                    Console.Write("Error: ");
                }
            }while(!mail.Contains("@gmail.com"));
            
            listaNacimientos.Add(fecha);
            listaDNI.Add(dni);
            listaPersona.Add(new Persona(dni, apellido, nombre, fecha, mail));
            
            break;
        
        case '2':
            if(listaPersona.Count > 0){
                for(int i = 0; i < listaPersona.Count; i++){
                    if(Persona.PuedeVotar(Persona.ObtenerEdad(listaNacimientos[i]))){
                        personaValidaParaVotar += 1;
                    }
                    
                    edadTotal = Persona.ObtenerEdad(listaNacimientos[i]);
                }

                promedio = edadTotal / listaPersona.Count;

                Console.WriteLine("Estadisticas del Censo:");
                Console.WriteLine($"Cantidad de personas: {listaPersona.Count}");
                Console.WriteLine($"Cantidad de Personas habilitadas para votar: {personaValidaParaVotar}");
                Console.WriteLine($"Edad promedio: {promedio}");
            }
            else{
                Console.WriteLine("Aún no se ingresaron personas en el censo");
            }
            break;
        
        case '3':
            ingresoDNI = IngresoINT("Ingrese un DNI: ");

            if(listaDNI.Contains(ingresoDNI)){
                ubicacionDNI = listaDNI.IndexOf(ingresoDNI);
                dniPedido = ingresoDNI;
                edadPersonaPedida = Persona.ObtenerEdad(listaPersona[ubicacionDNI].FechaNacimiento);
                
                Console.WriteLine($"DNI pedido: {dniPedido}");
                
                Console.WriteLine("");

                Console.WriteLine($"Nombre: {listaPersona[ubicacionDNI].Nombre}");
                Console.WriteLine($"Apellido: {listaPersona[ubicacionDNI].Apellido}");
                Console.WriteLine($"Edad: {edadPersonaPedida}");
                Console.WriteLine($"Fecha de Nacimiento: {listaPersona[ubicacionDNI].FechaNacimiento.ToShortTimeString}");
                Console.WriteLine($"Mail: {listaPersona[ubicacionDNI].Email}");

                if(Persona.PuedeVotar(edadPersonaPedida)){
                    Console.WriteLine("Puede votar en las siguientes elecciones");
                }
                else{
                    Console.WriteLine("No puede votar en las siguientes elecciones");
                }
            }
            else{
                Console.WriteLine("No se encontro ninguna persona con ese DNI");
            }
            
            break;

        case '4':
            ingresoDNI = IngresoINT("Ingrese un DNI: ");
            ubicacionDNI = listaDNI.IndexOf(ingresoDNI);

            if(listaDNI.Contains(ingresoDNI)){
                listaPersona[ubicacionDNI].Email = IngresoString("Ingrese su nuevo mail.");
            }
            else{
                Console.WriteLine("No se encontro ninguna persona con ese DNI");
            }
            break;
    }
    
    if(eleccion != '2' && eleccion != '3'){
        Console.Clear();
    }

}while(eleccion != '5');

static char Eleccion(){
    char a;

    Console.WriteLine("1. Cargar nueva persona");
    Console.WriteLine("2. Obtener estadisticas del censo");
    Console.WriteLine("3. Buscar persona");
    Console.WriteLine("4. Modificar mail de una persona");
    Console.WriteLine("5. Salir");

    do{
        Console.Write("Ingrese una de las siguientes opciones: ");
        a = char.Parse(Console.ReadLine());

        if(a > 5 && a < 1){
            Console.Write("Error: ");
        }
    }while(a > 5 && a < 1);

    return a;
}

static int IngresoINT(string mensaje){
    int a;

    Console.Write(mensaje);
    a = int.Parse(Console.ReadLine());

    return a;
}

static string IngresoString(string mensaje){
    string a;

    Console.Write(mensaje);
    a = Console.ReadLine();

    return a;
}

static DateTime IngresoFecha(string mensaje){
    DateTime a;

    Console.Write(mensaje);
    a = DateTime.Parse(Console.ReadLine());

    return a;
}