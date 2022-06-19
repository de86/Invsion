using System;

namespace Invsion
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Invsion())
                game.Run();
        }
    }
}
