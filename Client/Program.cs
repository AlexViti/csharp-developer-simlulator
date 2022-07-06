string cAPath = "../../../../client-activity.txt";
string dAPath = "../../../../developer-activity.txt";
string logPath = "../../../../Client/log.txt";

string[] clientActivities = File.ReadAllLines(cAPath);

int index = 0;

if (File.Exists(logPath))
{
    string[] logs = File.ReadAllLines(logPath);
    if (logs.Length > 0)
    {
        index = int.Parse(logs[logs.Length - 1]) + 1;
    }
}

if (index >= clientActivities.Length - 1)
{
    Console.WriteLine("The client activity is over, do you want to restart?");
    char input = Console.ReadKey().KeyChar;
    while (input.Equals('y') || input.Equals('n') || input.Equals('N') || input.Equals('Y'))
    {
        switch (input)
        {
            case 'y':
            case 'Y':
                index = 0;
                break;
            case 'n':
            case 'N':
                break;
            default:
                Console.WriteLine("Please enter y or n");
                input = Console.ReadKey().KeyChar;
                break;
        }
    }
}

StreamWriter log = new StreamWriter(logPath, true);
bool closingApp = false;

for (int i = index; !closingApp && i < clientActivities.Length; i++)
{
    if (!File.ReadAllLines(dAPath).Contains(clientActivities[i]))
    {
        Thread.Sleep(new Random().Next(5000, 10000));
        //closingApp = new Random().NextDouble() > 0.9;
        StreamWriter developerActivities = new StreamWriter(dAPath, true);
        developerActivities.WriteLine(clientActivities[i]);
        developerActivities.Close();
        log.WriteLine(i);
    }
    if (i == clientActivities.Length - 1)
    {
        Console.WriteLine("Activies over");
    }
}

log.Close();
