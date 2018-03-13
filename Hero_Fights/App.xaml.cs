using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HeroFight
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Storyboard_Completed(object sender, EventArgs e)
        {
            Console.WriteLine("---------------------------------------");
        }
    }
}
