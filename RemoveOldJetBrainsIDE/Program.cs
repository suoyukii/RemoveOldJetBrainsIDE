// Get path
var dir_path = Environment.GetEnvironmentVariable("localappdata") + @"\JetBrains";

// Get directory list
var dirs = Directory.GetDirectories(dir_path);
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