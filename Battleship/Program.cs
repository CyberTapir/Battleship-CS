Console.WriteLine("Callum's 2 player Battleship");
Console.WriteLine("Press any key to start");
Console.ReadKey();
gameplay();
static void gameplay()
{
    bool gamewon = false;
    int player1ships = 17;
    int player2ships = 17;
    Console.Clear();
    Console.Write("Enter name for Player 1 > ");
    var player1 = Console.ReadLine();
    if (player1 == null)
    {
        Console.WriteLine("Setting random name");
        player1 = "Jeff";
    }
    Console.WriteLine();
    Console.Write("Enter name for Player 2 > ");
    var player2 = Console.ReadLine();
    if (player2 == null)
    {
        Console.WriteLine("Setting random name");
        player2 = "Geoff";
    }
    Console.WriteLine();
    Console.WriteLine("This game will be " + player1 + " vs " + player2);
    Console.WriteLine("Ready to play? Press any key to start");
    Console.ReadKey();
    string[,] player1owngrid = { 
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
        { ".", "X", ".", ".", ".", "X", "X", "X", "X", "." }, 
        { ".", "X", ".", ".", "X", ".", ".", ".", ".", "." }, 
        { ".", "X", ".", ".", "X", ".", ".", ".", ".", "." }, 
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." }, 
        { ".", ".", ".", ".", ".", ".", "X", "X", "X", "." }, 
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." }, 
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." }, 
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." }, 
        { ".", "X", "X", "X", "X", "X", ".", ".", ".", "." } };
    string[,] player1attackgrid = {
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." } }; 
    string[,] player2owngrid = {
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
        { ".", "X", "X", ".", ".", ".", ".", ".", ".", "." },
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
        { ".", ".", ".", ".", "X", "X", "X", "X", "X", "." },
        { ".", "X", ".", ".", ".", ".", ".", ".", ".", "." },
        { ".", "X", ".", ".", "X", "X", "X", "X", ".", "." },
        { ".", "X", ".", ".", ".", ".", ".", "X", ".", "." },
        { ".", ".", ".", ".", ".", ".", ".", "X", ".", "." },
        { ".", ".", ".", ".", ".", ".", ".", "X", ".", "." },
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." } }; 
    string[,] player2attackgrid = {
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
        { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." } };
    while(!gamewon)
    {
        Console.Clear();
        Console.WriteLine(player1 + ", press to start your turn");
        Console.ReadLine();
        Console.Clear();
        printArray(player1owngrid);
        Console.WriteLine("Here is where your ships are. . is not guessed, X is your battleships, O is a miss, and * is a hit");
        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
        Console.Clear();
        printArray(player1attackgrid);
        Console.WriteLine("Here is your grid for guessing. . is not guessed, O is a miss, and * is a hit");
        Console.Write("Enter the X coordinate of your guess: ");
        var p1strxguess = Console.ReadLine();
        if (p1strxguess == "")
        {
            p1strxguess = "0";
        }
        int p1xguess = Int32.Parse(p1strxguess);
        Console.WriteLine();
        Console.Write("Enter the Y coordinate of your guess: ");
        var p1stryguess = Console.ReadLine();
        if (p1stryguess == "")
        {
            p1stryguess = "0";
        }
        int p1yguess = Int32.Parse(p1stryguess);
        if (p1xguess < 0 || p1xguess > 9 && p1yguess < 0 || p1yguess > 9)
        {
            Console.WriteLine("Invalid location, Press a key to end your turn");
            Console.ReadLine();
        } else {
            if (player2owngrid[p1yguess, p1xguess] == ".")
            {
                player2owngrid[p1yguess, p1xguess] = "O";
                player1attackgrid[p1yguess, p1xguess] = "O";
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Miss");
                printArray(player1attackgrid);
                Console.WriteLine();
                Console.WriteLine("Press a key to end your turn");
                Console.ReadLine();
            } else if (player2owngrid[p1yguess, p1xguess] == "X")
            {
                player2owngrid[p1yguess, p1xguess] = "*";
                player1attackgrid[p1yguess, p1xguess] = "*";
                player2ships -= 1;
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Hit");
                printArray(player1attackgrid);
                Console.WriteLine();
                Console.WriteLine("Press a key to end your turn");
                Console.ReadLine();
            } else
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Already guessed there, skipping your turn");
            }
        }
        checkGameover(player1ships, player2ships, player1, player2);
        Console.Clear();
        Console.WriteLine(player2 + ", press to start your turn");
        Console.ReadLine();
        Console.Clear();
        printArray(player2owngrid);
        Console.WriteLine("Here is where your ships are. . is not guessed, X is your battleships, O is a miss, and * is a hit");
        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
        Console.Clear();
        printArray(player2attackgrid);
        Console.WriteLine("Here is your grid for guessing. . is not guessed, O is a miss, and * is a hit");
        Console.Write("Enter the X coordinate of your guess: ");
        var p2strxguess = Console.ReadLine();
        if (p2strxguess == "")
        {
            p2strxguess = "0";
        }
        int p2xguess = Int32.Parse(p2strxguess);
        Console.WriteLine();
        Console.Write("Enter the Y coordinate of your guess: ");
        var p2stryguess = Console.ReadLine();
        if (p2stryguess == "")
        {
            p2stryguess = "0";
        }
        int p2yguess = Int32.Parse(p2stryguess);
        if (p2xguess < 0 || p2xguess > 9 && p2yguess < 0 || p2yguess > 9)
        {
            Console.WriteLine("Invalid location, Press a key to end your turn");
            Console.ReadLine();
        }
        else
        {
            if (player1owngrid[p2yguess, p2xguess] == ".")
            { 
                player1owngrid[p2yguess, p2xguess] = "O";
                player2attackgrid[p2yguess, p2xguess] = "O";
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Miss");
                printArray(player2attackgrid);
                Console.WriteLine();
                Console.WriteLine("Press a key to end your turn");
                Console.ReadLine();
            }
            else if (player1owngrid[p2yguess, p2xguess] == "X")
            {
                player1owngrid[p2yguess, p2xguess] = "*";
                player2attackgrid[p2yguess, p2xguess] = "*";
                player1ships -= 1;
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Hit");
                printArray(player2attackgrid);
                Console.WriteLine();
                Console.WriteLine("Press a key to end your turn");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Already guessed there, skipping your turn");
            }
        }
        checkGameover(player1ships, player2ships, player1, player2);
    }
}
static void printArray(string[,] array)
{
    Console.Clear();
    Console.WriteLine("  0 1 2 3 4 5 6 7 8 9");
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine(i + " " + array[i, 0] + " " + array[i, 1] + " " + array[i, 2] + " " + array[i, 3] + " " + array[i, 4] + " " + array[i, 5] + " " + array[i, 6] + " " + array[i, 7] + " " + array[i, 8] + " " + array[i, 9]);
    }
    Console.WriteLine();
}
static void checkGameover(int player1ships, int player2ships, string player1, string player2)
{
    if (player1ships == 0)
    {
        Console.WriteLine(player2 + " has won!");
        Environment.Exit(0);
    } else if (player2ships == 0)
    {
        Console.WriteLine(player1 + "has won!");
        Environment.Exit(0);
    }
}