using RemoveOldJetBrainsIDE;

// Load language
var langs = Language.Get();
Console.Title = langs[0];

// Get path
var path = Environment.GetEnvironmentVariable("localappdata") + @"\JetBrains";
Console.WriteLine(langs[1]);

// Get directory list
var dirs = Directory.GetDirectories(path);
var dir_list = (from dir in dirs
    let index = dir.LastIndexOf('\\') + 1
    select (string[]) [dir[index..(index + 5)], dir]).ToList();

// Start remove
var last_prev = "";
var last_dir = "";
foreach (var str_arr in dir_list)
{
    if (last_prev == "")
    {
        last_prev = str_arr[0];
        last_dir = str_arr[1];
        continue;
    }

    if (last_prev == str_arr[0])
    {
        Directory.Delete(last_dir, true);
        last_dir = str_arr[1];
    }
}

Console.WriteLine(langs[2]);
Console.ReadLine();