using System;
using static System.Math;

int Num1, Num2, Num3, Num4, Pos1, Pos2, Pos3, Pos4, menorNumero, dia, mes, año, sumaAño, num1, num2;

int[] detectarPares = {};

string mayorNumero;

/*Num1 = IngresoINT("Ingrese el primer numero");
Num2 = IngresoINT("Ingrese el segundo numero");
Num3 = IngresoINT("Ingrese el tercer numero");
Num4 = IngresoINT("Ingrese el cuarto numero");

menorNumero = TraerMenor(Num1, Num2, Num3, Num4);

Console.WriteLine($"El menor numero es {menorNumero}");

Pos1 = IngresoINT("Ingrese el primer numero");
Pos2 = IngresoINT("Ingrese el segundo numero");
Pos3 = IngresoINT("Ingrese el tercer numero");
Pos4 = IngresoINT("Ingrese el cuarto numero");

mayorNumero = PosicionMayor(Pos1, Pos2, Pos3, Pos4);

Console.WriteLine(mayorNumero);*/

/*dia = IngresoINT("Ingrese el numero del dia");
mes = IngresoINT("Ingrese el numero del mes del año");
año = IngresoINT("Ingrese el año");

sumaAño = CalcularDia(dia, mes, año);

Console.WriteLine($"Total dias: {sumaAño}");*/

num1 = IngresoINT("Ingrese el primer numero");
num2 = IngresoINT("Ingrese el segundo numero");

detectarPares = TraerParesEntre(num1, num2);

if(detectarPares[0] == -1)
{
    Console.WriteLine("Error: No hay ningun numero par entre ambos numeros");
}
else
{
    Console.Write($"Los numeros pares posibles entre {num1} y {num2} es: ");

    for(int i = 0; i < (detectarPares.Length + 1); i++)
    {
        Console.Write(detectarPares[i] + " ");
    }
}


static int IngresoINT(string Mensaje)
{
    int Numero;

    Console.WriteLine(Mensaje);
    Numero = int.Parse(Console.ReadLine());

    return Numero;
}

static int TraerMenor(int Num1, int Num2, int Num3, int Num4)
{
    int menorNumero = int.MaxValue;

    menorNumero = Math.Min(Math.Min(Num1, Num2), Num3);

    return menorNumero;
}

static string PosicionMayor(int Pos1, int Pos2, int Pos3, int Pos4)
{
    int[] GrupoNumeros = new int[4];

    int Maximo = 1, numeroMayor = int.MinValue, PosicionMayor = 0;

    string respuesta;

    GrupoNumeros[0] = Pos1;
    GrupoNumeros[1] = Pos2;
    GrupoNumeros[2] = Pos3;
    GrupoNumeros[3] = Pos4;

    for(int i = 0; i < 4; i++)
    {
        if(GrupoNumeros[i] == GrupoNumeros[i++])
        {
            Maximo++;
        }
    }

    for(int i = 0; i < 5; i++)
    {
        if(Pos1 > numeroMayor && i <= 5)
        {
            numeroMayor = Pos1;
            PosicionMayor = i + 1;
        }
        else if(Pos2 > numeroMayor && i <= 5)
        {
            numeroMayor = Pos2;
            PosicionMayor = i + 1;
        }
        else if(Pos3 > numeroMayor && i <= 5)
        {
            numeroMayor = Pos3;
            PosicionMayor = i + 1;
        }
        else if(Pos4 > numeroMayor && i <= 5)
        {
            numeroMayor = Pos4;
            PosicionMayor = i + 1;
        }
    }

    if(Maximo == 1)
    {
        respuesta = "Mayor: " + numeroMayor;
    }
    else if(Maximo == 2)
    {
        respuesta = "Mayor: " + numeroMayor + " | " + numeroMayor;
    }
    else if(Maximo == 3)
    {
        respuesta = "Mayor: " + numeroMayor + " | " + numeroMayor + " | " + numeroMayor;
    }
    else
    {
        respuesta = "Mayor: " + numeroMayor + " | " + numeroMayor + " | " + numeroMayor + " | " + numeroMayor ;
    }

    return respuesta;
}

static int CalcularDia(int dia, int mes, int año)
{
    int[] DiasAñoNormal = new int[12] {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
    int diasTotal = 0;
    bool esBisiesto;

    if(año % 4 == 0 && año % 100 != 0 || año % 400 == 0)
    {
        esBisiesto = true;
    }
    else{
        esBisiesto = false;
    }

    if(esBisiesto)
    {
        DiasAñoNormal[1] = 29;
    }

    if(mes == 1){
        DiasAñoNormal[0] = 0;
    }

    for(int i = 0; i < (mes - 1); i++)
    {
        diasTotal += DiasAñoNormal[i];
    }

    diasTotal += dia;

    return diasTotal;
}

static int[] TraerParesEntre(int num1, int num2)
{
    int[] TodosNumerosPares = new int[(num2 - num1) / 2 + 1]; 
    int acumuladorPares = -1;
    
    if(num1 == num2 || num1 == (num2 - 1))
    {
        TodosNumerosPares[0] = -1;

        return TodosNumerosPares;
    }
    else
    {
        for(int i=0; i < (num2-num1 + 1); i++)
        {
            if(num1 % 2 == 0)
            {
                acumuladorPares++;
                TodosNumerosPares[acumuladorPares] = num1;
            }

            num1++;
        }

        return TodosNumerosPares;
    }
}

static string CambioLetra(string frase, char letra)
{
    
}