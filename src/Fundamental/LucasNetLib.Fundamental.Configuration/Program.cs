using Microsoft.Extensions.Configuration;

// Build a config object, using env vars and JSON providers.
IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json") //Microsoft.Extensions.Configuration.json;
    .AddEnvironmentVariables() //获取所有环境变量
    .Build();

// Get values from the config given their key and their target type.
Settings? settings = config.GetRequiredSection("Settings").Get<Settings>();

// Write the values to the console.
Console.WriteLine($"KeyOne = {settings?.KeyOne}");
Console.WriteLine($"KeyTwo = {settings?.KeyTwo}");
Console.WriteLine($"KeyThree:Message = {settings?.KeyThree?.Message}");
