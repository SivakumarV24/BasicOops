using System;
using CollegeDetails;
namespace Application; // File Scoped NameSpace
class Program
{
    public static void Main(string[] args)
    {
        // Default Data calling
        Operations.AddDefaultData();
        // Main menu
        Operations.MainMenu();
    }
}
