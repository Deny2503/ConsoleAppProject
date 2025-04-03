using ConsoleAppProject.DAL;
using ConsoleAppProject.DAL.Entities;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var menuService = new MenuService();
            menuService.Show();
        }
    }
}
