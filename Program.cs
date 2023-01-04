bool IsTicketDone = false;
int hours = 0;
int minutes = 0;
int allMinutes = 0;
string input = "";
int inputCoin = 0;

Main();

void Main()
{
    PrintWelcome();
    while (IsTicketDone == false)
    {
        EnterCoins();
        AddParkingTime(input, minutes, allMinutes, hours, IsTicketDone);
        PrintParkingTimeAndPrintDonation(IsTicketDone);
    }
}

void PrintWelcome()
{
    System.Console.WriteLine();
    System.Console.WriteLine("Parkscheinautomat mit Mindestparkdauer 30 Min und Höchstparkdauer 1:30 Stunden");
    System.Console.WriteLine("Tarif pro Stunde: 1 Euro");
    System.Console.WriteLine("Zulässige Münzen: 5 (Cents), 10 (Cents), 20 (Cents), 50 (Cents), 1 (Euro), 2 (Euro)");
    System.Console.WriteLine("Parkschein drucken mit d oder D");
    System.Console.WriteLine();
}

void EnterCoins()
{
    System.Console.WriteLine($"Parkzeit bisher {hours}:{minutes}");
    input = Console.ReadLine()!;

    if (input != "d" && input != "D")
    {
        inputCoin = Convert.ToInt32(input);
    }
    minutes += inputCoin;
    allMinutes += (int)(minutes + (double)(inputCoin / 100 * 60));

    if (minutes >= 60)
    {
        int multiplier = minutes / 60;
        minutes = minutes - 60 * multiplier;
        hours *= multiplier;
    }
}

void AddParkingTime(string input, int minutes, int allMinutes, int hours, bool IsTicketDone)
{
    bool enough = false;

    if (minutes >= 30)
    {
        enough = true;
    }
    if (input == "D" || input == "d")
    {
        if (enough)
        {
            Console.WriteLine($"Sie dürfen {hours}:{minutes} parken");
            IsTicketDone = true;
        }
        else
        {
            Console.WriteLine($"Mindesteinwurf 50 Cent, bisher haben Sie {minutes} eingeworfen");
        }
    }
}

void PrintParkingTimeAndPrintDonation(bool IsTicketDone)
{
    if (allMinutes >= 90)
    {
        int cent = allMinutes - 90;
        int euro = cent / 100;
        Console.WriteLine($"Sie dürfen 1:30 Stunden parken");
        Console.WriteLine($"Danke für ihre Spende von {euro} Euro {cent} Cent");
        IsTicketDone = true;
    }
}