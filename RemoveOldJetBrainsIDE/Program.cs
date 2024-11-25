using RemoveOldJetBrainsIDE;

// Load language
var langs = Language.Get();
Console.Title = langs[0];

Console.WriteLine(langs[1]);
// C:\Users\{username}\AppData\Local\JetBrains
RemoveLocalAppdata();
// C:\Program Files\JetBrains
RemoveProgramFiles();

Console.WriteLine(langs[2]);
Console.ReadLine();
return;

void RemoveLocalAppdata()
{
    // Get path
    var path = Environment.GetEnvironmentVariable("localappdata") + @"\JetBrains";

    // Get directory list
    var dirs = Directory.GetDirectories(path);
    var dir_list = (from dir in dirs
        let index = dir.LastIndexOf('\\') + 1
        select (string[]) [dir[index..(index + 5)], dir]).ToList();
    StartRemove(dir_list);
}

void RemoveProgramFiles()
{
    // Get path
    var path = Environment.GetEnvironmentVariable("programfiles") + @"\JetBrains";

    // Get directory list
    var dirs = Directory.GetDirectories(path);
    var dir_list = (from dir in dirs
        let index = dir.LastIndexOf('\\') + 1
        let last_space_index = dir.LastIndexOf(' ')
        let last_index = last_space_index > index ? last_space_index : dir.Length - 1
        select (string[]) [dir[index..last_index], dir]).ToList();
    StartRemove(dir_list);
}

void StartRemove(List<string[]> dir_list)
{
    // Start remove
    var last_prev = "";
    var last_dir = "";
    foreach (var str_arr in dir_list)
    {
        if (last_prev == "")
        {
            last_prev = str_arr[0];
            Console.WriteLine(last_prev);
            last_dir = str_arr[1];
            continue;
        }

        if (last_prev != str_arr[0]) continue;
        Directory.Delete(last_dir, true);
        last_dir = str_arr[1];
    }
}