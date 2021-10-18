using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenGL_TK
{
    class Game
    {
        GameWindow window;
        public Game(GameWindow window)
        {
            this.window = window;
            Start();
        }
        void Start()
        {
            window.Load += loaded;
            window.Resize += resize;
            window.RenderFrame += renderF;
            window.Run(1.0 / 60.0);
        }
        void resize(object ob, EventArgs e)
        {
            GL.Viewport(0, 0, window.Width, window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0.0f, 50.0f, 0.0f, 50.0f, -1.0f, 1.0f);
            GL.MatrixMode(MatrixMode.Modelview);
        }
        void renderF(object o, EventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Begin(BeginMode.Triangles);
            
            // 1° vértice
            GL.Vertex2(1.0, 5.0);
            // 2° vértice
            GL.Vertex2(20.0, 5.0);
            // altura
            GL.Vertex2(10.0, 20.0);
            GL.End();
            window.SwapBuffers();
        }

        void loaded(object o, EventArgs e)
        {
            GL.ClearColor(0.0f,0.0f,0.0f,0.0f);
        }
    }
}
