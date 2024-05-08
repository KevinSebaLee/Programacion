string Nombre, Ciudad;
double Velocidad, Fuerza, Peso;
double SkillsSuperHeroe1 = 0, SkillsSuperHeroe2 = 0;
char Eleccion;

Superheroe SuperHeroe1 = new Superheroe("", "", 0, 0, 0);
Superheroe SuperHeroe2 = new Superheroe("", "", 0, 0, 0);

do{
    Eleccion = eleccionOpcion("Ingrese la opcion deseada: \n1. Cargar datos Superheroe 1 \n2. Cargar datos Superheroe 2 \n3. Competir! \n4. Salir\n");
    switch(Eleccion){
        case '1':
            Nombre = IngresoString("Ingrese el nombre del Superheroe 1: ");
            Ciudad = IngresoString("Ingrese la ciudad del Superheroe 1: ");
            Peso = IngresoDouble("Ingrese el peso del Superheroe 1: ");

            do{
                Velocidad = IngresoDouble("Ingrese la velocidad del Superheroe 1: ");
                Fuerza = IngresoDouble("Ingrese la fuerza del Superheroe 1: ");
            }while(siVelocidadYFuerzaMenor100(Velocidad, Fuerza));

            SuperHeroe1 = new Superheroe(Nombre, Ciudad, Peso, Fuerza, Velocidad);

            SkillsSuperHeroe1 = SuperHeroe1.ObtenerSkill(Velocidad, Fuerza);

            break;
        case '2':
            Nombre = IngresoString("Ingrese el nombre del Superheroe 2: ");
            Ciudad = IngresoString("Ingrese la ciudad del Superheroe 2: ");
            Peso = IngresoDouble("Ingrese el peso del Superheroe 2: ");
                
            do{
                Velocidad = IngresoDouble("Ingrese la velocidad del Superheroe 2: ");
                Fuerza = IngresoDouble("Ingrese la fuerza del Superheroe 2: ");
            }while(siVelocidadYFuerzaMenor100(Velocidad, Fuerza));
            SuperHeroe2 = new Superheroe(Nombre, Ciudad, Peso, Fuerza, Velocidad);

            SkillsSuperHeroe2 = SuperHeroe2.ObtenerSkill(Velocidad, Fuerza);
                
            break;
        case '3':
            if(SkillsSuperHeroe1 == 0 || SkillsSuperHeroe2 == 0){
                Console.WriteLine("Debe cargar los datos de los Superheroes primero!");
                break;
            }
            else{
                if(SkillsSuperHeroe1 > SkillsSuperHeroe2){
                    if(SkillsSuperHeroe1 >= SkillsSuperHeroe2 + 30){
                        Console.WriteLine($"Gano {SuperHeroe1.Nombre} por amplia diferencia!");
                    }
                    else if(SkillsSuperHeroe1 >= 10){
                        Console.WriteLine($"Gano {SuperHeroe1.Nombre}. Fue muy parejo!");
                    }
                    else{
                        Console.WriteLine("Gano {SuperHeroe1.Nombre}. ¡No le sobro nada!");
                    }
                }else if(SkillsSuperHeroe1 < SkillsSuperHeroe2){
                    if(SkillsSuperHeroe2 >= SkillsSuperHeroe1 + 30){
                        Console.WriteLine($"Gano {SuperHeroe2.Nombre} por amplia diferencia!");
                    }
                    else if(SkillsSuperHeroe2 >= 10){
                        Console.WriteLine($"Gano {SuperHeroe2.Nombre}. Fue muy parejo!");
                    }
                    else{
                        Console.WriteLine("Gano {SuperHeroe2.Nombre}. ¡No le sobro nada!");
                    }
                }else{
                    Console.WriteLine("Empate!");
                }
            }
            break;
    }
}while(Eleccion != '4');

static bool siVelocidadYFuerzaMenor100(double Velocidad, double Fuerza){
    bool a = false;
    
    if(Velocidad > 100 && Fuerza > 100){
        Console.WriteLine("La velocidad y la fuerza no pueden ser mayores a 100! Ingresa nuevamente los datos.");
        a = true;
    }
    else if(Velocidad > 100){
        Console.WriteLine("La velocidad no puede ser mayor a 100! Ingresa nuevamente los datos.");
        a = true;
    }
    else if(Fuerza > 100){
        Console.WriteLine("La fuerza no puede ser mayor a 100! Ingresa nuevamente los datos.");
        a = true;
    }

    return a;
}

static double IngresoDouble(string mensaje){
    double a;

    Console.WriteLine(mensaje);
    a = double.Parse(Console.ReadLine());

    return a;
}

static string IngresoString(string mensaje){
    string a;

    Console.WriteLine(mensaje);
    a = Console.ReadLine();

    return a;
}

static char eleccionOpcion(string mensaje){
    char a;

    do{
        Console.WriteLine(mensaje);
        a = char.Parse(Console.ReadLine());
    }while(a > 4 && a < 1);

    return a;

    
}