using System.Diagnostics;

public class LeanWork
{
    private const int UM_MILHAO = 1000000;
    public static void Main()
    {
        //Estava em duvida em qual metodo seria mais eficaz para a resolução do problema, com um range de 1 milhão de numeros,
        //se mostrou mais rapido salvar os valores ja calculados em um dictionary e varrer ele a cada laço, do que calcular as operações novamente.
        ProblemaDeCollatzComDictionary();
        ProblemaDeCollatz();
        VerificarArrayComNumerosImparesLinq();
        SepararArrays();
    }


    private static void ProblemaDeCollatzComDictionary()
    {
        Console.WriteLine("Exercicio 1.1 Problema de Collatz utilizando Dictionary");
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        int NumeroDaMaiorSequencia = 0;
        int MaiorSequencia = 0;

        // Para evitar repetições de operações ja calculadas, criei um dictionary para salvar o valor do numero que ja foi calculado
        // e sua quantidade de repetições
        Dictionary<long, int> ValoresJaCalculados = new Dictionary<long, int>();

        for (int i = 1; i <= UM_MILHAO; i++)
        {
            long numero = i;
            int tamanhoSequencia = 0;

            //Aqui mudamos a condição, para caso esse valor ja tenha sido calculado, nao calcule novamente
            while (numero != 1 && !ValoresJaCalculados.ContainsKey(numero))
            {
                if (numero % 2 == 0)
                {
                    numero = numero / 2;
                }
                else
                {
                    numero = 3 * numero + 1;
                }
                tamanhoSequencia++;
            }

            //Atribui o tamanho da sequencia com o valor da sequencia que esta presente no dictionary
            if (ValoresJaCalculados.ContainsKey(numero))
            {
                tamanhoSequencia += ValoresJaCalculados[numero];
            }

            //Alimenta o Dictionary com o a sequencia do numero atual
            ValoresJaCalculados[i] = tamanhoSequencia;

            if (tamanhoSequencia > MaiorSequencia)
            {
                MaiorSequencia = tamanhoSequencia;
                NumeroDaMaiorSequencia = i;
            }
        }

        Console.WriteLine("Maior sequencia de numeros gerados: " + MaiorSequencia);
        Console.WriteLine("Número que gerou a maior sequencia: " + NumeroDaMaiorSequencia);
        stopwatch.Stop();

        Console.WriteLine("Tempo decorrido: {0}ms", stopwatch.ElapsedMilliseconds);
    }
    private static void ProblemaDeCollatz()
    {
        Console.WriteLine("Exercicio 1.1 Problema de Collatz sem Dictionary");
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start(); int NumeroDaMaiorSequencia = 0;

        int MaiorSequencia = 0;

        for (int i = 1; i <= UM_MILHAO; i++)
        {
            //Foi utilizado o tipo long para a variavel numero, pois alguns valores excediam os limites do int32,
            //após os teste o int64(long) foi o suficiente para a realização deste caso
            long numero = i;
            int tamanhoSequencia = 0;
            while (numero != 1)
            {
                if (numero % 2 == 0)
                {
                    numero = numero / 2;
                }
                else
                {
                    numero = 3 * numero + 1;
                }
                tamanhoSequencia++;
            }

            if (tamanhoSequencia > MaiorSequencia)
            {
                MaiorSequencia = tamanhoSequencia;
                NumeroDaMaiorSequencia = i;
            }

        }
        Console.WriteLine("Maior sequencia de numeros gerados: " + MaiorSequencia);
        Console.WriteLine("Número que gerou a maior sequencia: " + NumeroDaMaiorSequencia);

        stopwatch.Stop();

        Console.WriteLine("Tempo decorrido: {0}ms", stopwatch.ElapsedMilliseconds);
    }
    private static void VerificarArrayComNumerosImparesLinq()
    {
        Console.WriteLine("Exercicio 1.2 Verificar numeros impares");
        int[] numeros = { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };

        //Optei pela utilização do Any ao inves do All pois caso algum numero atenda a condição o valor ja é retornado, enquanto o All iria comparar
        //todos os valores mesmo a condição ja tendo sido atendida.
        if (numeros.Any(n => n % 2 == 0))
        {
            Console.WriteLine("Nem todos os numeros são impares");
            foreach (var numero in numeros.Where(n => n % 2 == 0))
            {
                Console.WriteLine(numero);
            }
        }
        else
        {
            Console.WriteLine("Todos os numeros são impares");
        };
    }

    private static void SepararArrays()
    {
        Console.WriteLine("Exercicio 1.3 separar Arrays");
        int[] primeiroArray = { 1, 3, 7, 29, 42, 98, 234, 93 };
        int[] segundoArray = { 4, 6, 93, 7, 55, 32, 3 };

        var numerosUnicos = primeiroArray.Where(x => !segundoArray.Contains(x));

        foreach (var numero in numerosUnicos)
        {
            Console.WriteLine(numero);
        }
    }


}

