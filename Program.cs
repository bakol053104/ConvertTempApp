MainUserInterface();
void MainUserInterface()
{
    var endProgramm = false;
    while (!endProgramm)
    {
        Console.Clear();
        Console.WriteLine($"\n\n\t\t\t   Witamy w programie przeliczania temperatur");
        Console.WriteLine($"\t=======================================================================================\n");
        Console.Write($"\tPodaj temperaturę w Celsius lub Fahrenheit [format xxx,xx C/F] (Q/q- wyjście z programu): ");
        var inputTemperature = Console.ReadLine();

        switch (inputTemperature)
        {
            case "Q":
            case "q":
                endProgramm = true;
                break;
            default:
                try
                {
                    CalculateTemperature(inputTemperature);
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"\n\t{exception.Message}");
                }
                finally
                {
                    WaitForKeyPress();
                }
                break;
        }
    }

    void CalculateTemperature(string temp)
    {
        var sub = temp.Split(" ");
        if (decimal.TryParse(sub[0], out decimal temperature))
        {
            switch (temp[temp.Length - 1])
            {
                case 'C':
                    if (temperature >= (decimal)-273.15)
                    {
                        Console.WriteLine($"\n\t{Math.Round(temperature,2)} °C = {Math.Round(((decimal)(temperature * 9 / 5 + 32)), 2)} °F");
                    }
                    else
                    {
                        throw new FormatException("Podano temperaturę poniżej zera bezwzględnego");
                    }
                    break;
                case 'F':
                    if (temperature >= (decimal)-459.67)
                    {
                        Console.WriteLine($"\n\t{Math.Round(temperature, 2)} °F = {Math.Round(((decimal)(temperature - 32) * 5 / 9), 2)} °C");
                    }
                    else
                    {
                        throw new FormatException("Podano temperaturę poniżej zera bezwzględnego");
                    }
                    break;
                default:
                    throw new FormatException("Podano nieprawidłowy format temperatury");
            }
        }
        else
        {
            throw new FormatException("Podano nieprawidłową liczbę");
        }
    }

    void WaitForKeyPress()
    {
        Console.Write($"\n\tNaciśnij dowolny klawisz ");
        Console.ReadKey();
    }
}