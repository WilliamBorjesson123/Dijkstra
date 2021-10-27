using System;

namespace Västtrafik2._1
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // sets local variables
            var graphStartNode = 0;
            var graphEndNode = 0;
            var graphMiddleNode = 0;
            var input = "";
            var input2 = "";
            var input3 = "";
            var isString = false;
            var distance = 0;
            var dist1 = 0;
            var dist2 = 0;
            var dist3 = 0;
            var isNotFinished = true;
            var wrongInput = true;

            // Askes the user for input.
            // Puts the input trough a "switch to integer method".
            // Sets that input in to a variable
            // Loops til input is valid
            do
            {
                do
                {
                    Console.Write("\n\nVälj en startnod (A-J), tryck sedan på Enter: ");
                    input = Console.ReadLine();
                    isString = Input.CheckIfInputIsString(input);
                    if (isString)
                    {
                        graphStartNode = Input.SwitchInputToInteger(input);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("-----Du har matat in felaktig data, endast bokstäverna (A-J) tack-----");
                    }
                } while (!isString);
                Console.Clear();

                do
                {
                    Console.Write("\n\nVälj en slutnod (A-J), tryck sedan på Enter: ");
                    input2 = Console.ReadLine();
                    isString = Input.CheckIfInputIsString(input2);
                    if (isString)
                    {
                        graphEndNode = Input.SwitchInputToInteger(input2);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("-----Du har matat in felaktig data, endast bokstäverna (A-J) tack-----");
                    }
                } while (!isString);
                Console.Clear();


                do
                {
                    Console.WriteLine("\n\n--------------Vill du sätta in entt delmål på resan[Y/N]--------------");
                    input = Console.ReadLine().ToUpper();

                    isString = Input.CheckIfInputIsStringAZ(input);
                    if (input == "Y" && isString)
                    {
                        Console.Clear();

                        do
                        {
                            Console.Write("\n\nVälj ett delmål (A-J), tryck sedan på Enter.");
                            input3 = Console.ReadLine();
                            isString = Input.CheckIfInputIsString(input3);
                            if (isString)
                            {
                                graphMiddleNode = Input.SwitchInputToInteger(input3);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("-----Du har matat in felaktig data, endast bokstäverna (A-J) tack-----");
                            }
                        } while (!isString);


                        wrongInput = false;
                    }
                    else if (isString && input == "N")
                    {
                        input3 = "";
                        wrongInput = false;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Endast inmatning med Y/N.");
                        isNotFinished = true;
                        wrongInput = true;
                    }
                } while (wrongInput);


                int[,] graph = ShortestPathAlgoritm.TimeTable();

                // Checks if the third input for a middle node contains a choice or not.
                if (!string.IsNullOrEmpty(input3))
                {
                    distance = ShortestPathAlgoritm.dijkstra(graph, graphStartNode, graphMiddleNode);
                    dist1 = distance;
                    distance = ShortestPathAlgoritm.dijkstra(graph, graphMiddleNode, graphEndNode);
                    dist2 = distance;

                    Console.Clear();
                    Console.WriteLine(
                        "\n \nDu har valt att resa från nod "
                        + input
                        + " till nod "
                        + input2
                        + " via nod "
                        + input3
                        + ".\nMellan nod "
                        + input
                        + " och nod "
                        + input3
                        + " är det "
                        + dist1
                        + "minuter, och den resterande resan till nod "
                        + input2
                        + " tar "
                        + dist2
                        + "minuter.\nTotala restiden blir "
                        + (dist1 + dist2)
                        + "minuter.");
                }
                else
                {
                    distance = ShortestPathAlgoritm.dijkstra(graph, graphStartNode, graphEndNode);
                    dist3 = distance;
                    Console.Clear();
                    Console.WriteLine($"Du har valt att resa mellan {input} och {input2}.\nTiden däremellan är {distance}minuter.");
                }
                do
                {
                    Console.WriteLine("\n\n--------------Vill du göra en ny resa [Y/N]--------------");
                    input = Console.ReadLine().ToUpper();

                    isString = Input.CheckIfInputIsStringAZ(input);
                    if (input == "Y" && isString)
                    {
                        Console.Clear();
                        isNotFinished = true;
                        wrongInput = false;
                    }
                    else if (isString && input == "N")
                    {
                        isNotFinished = false;
                        wrongInput = false;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Endast inmatning med Y/N.");
                        isNotFinished = true;
                        wrongInput = true;
                    }
                } while (wrongInput);
            } while (isNotFinished);
        }
    }
}
