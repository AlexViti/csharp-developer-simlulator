string develActPath = "../../../../developer-activity.txt";


while (true)
{
    Console.Clear();
    string[] tasks = File.ReadAllLines(develActPath);
    List<string> taskList = new List<string>(tasks);
    while (tasks.Length > 0)
    {
        Console.Clear();
        string task = tasks[0];
        Console.WriteLine("Developer is working on {0}", task);
        Thread.Sleep(new Random().Next(3000, 15000));
        tasks = File.ReadAllLines(develActPath);
        File.WriteAllLines(develActPath, tasks.Skip(1).ToArray());
        if (new Random().NextDouble() > 0.5)
            Console.WriteLine("Task completed");
        else
        {
            StreamWriter developerActivities = new StreamWriter(develActPath, true);
            developerActivities.WriteLine(task);
            developerActivities.Close();
        }          
    }
    Console.Clear();
    Console.WriteLine("There are no task. The developer went to take a coffe");
    Thread.Sleep(5000);
}
