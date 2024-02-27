using DbUp;
using System.Reflection;

var connectionString = args.FirstOrDefault() ?? "Server=localhost,1433;Database=appClean;User ID=app;Password=123@123@;TrustServerCertificate=True";


var upgrader = DeployChanges.To.SqlDatabase(connectionString).WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly()).LogToConsole().Build();

var result = upgrader.PerformUpgrade();


if (!result.Successful)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(result.Error);
    Console.ResetColor();

#if DEBUG
    Console.ReadLine();
#endif

    return -1;
}

Console.ForegroundColor = ConsoleColor.Green;

foreach (var script in result.Scripts)
{
    Console.WriteLine($" Executado: {script.Name}");
}

Console.ResetColor();
return 0;