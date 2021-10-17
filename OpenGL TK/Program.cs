using System;
using OpenTK;
namespace OpenGL_TK
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindow window = new GameWindow(300, 300);
            Game gm = new Game(window);
        }

    }
}
