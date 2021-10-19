﻿using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenGL_TK
{
    class Game
    {
        double theta = 0.0;
        double eixoX = 5, eixoY = 5, eixoZ = 5;

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
            window.Run(1.0, 60.0);
        }
        void resize(object ob, EventArgs e)
        {
            GL.Viewport(0, 0, window.Width, window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            Matrix4 matrix = Matrix4.Perspective(45.0f, window.Width / window.Height, 1.0f, 100.0f);
            GL.LoadMatrix(ref matrix);
            GL.MatrixMode(MatrixMode.Modelview);
        }
        void renderF(object o, EventArgs e)
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Movido para traz para que possa ser renderizado
            GL.Translate(0.0, 0.0, -45.0);
            GL.Rotate(theta, 1.0, 0.0, 0.0);
            GL.Rotate(theta, 0.0, 0.0, 1.0);

            GL.Begin(BeginMode.Quads);
            CoordenadasCubo();

            GL.End();
            window.SwapBuffers();

            theta += 1.0;
            if (theta > 360)
                theta -= 360;
        }
        void CoordenadasCubo()
        {
            GL.Color3(1.0, 1.0, 0.0);
            GL.Vertex3(-eixoX, eixoY, eixoZ);
            GL.Vertex3(-eixoX, eixoY, -eixoZ);
            GL.Vertex3(-eixoX, -eixoY, -eixoZ);
            GL.Vertex3(-eixoX, -eixoY, eixoZ);

            GL.Color3(1.0, 0.0, 1.0);
            GL.Vertex3(eixoX, eixoY, eixoZ);
            GL.Vertex3(eixoX, eixoY, -eixoZ);
            GL.Vertex3(eixoX, -eixoY, -eixoZ);
            GL.Vertex3(eixoX, -eixoY, eixoZ);

            GL.Color3(0.0, 1.0, 1.0);
            GL.Vertex3(eixoX, -eixoY, eixoZ);
            GL.Vertex3(eixoX, -eixoY, -eixoZ);
            GL.Vertex3(-eixoX, -eixoY, -eixoZ);
            GL.Vertex3(-eixoX, -eixoY, eixoZ);

            GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex3(eixoX, eixoY, eixoZ);
            GL.Vertex3(eixoX, eixoY, -eixoZ);
            GL.Vertex3(-eixoX, eixoY, -eixoZ);
            GL.Vertex3(-eixoX, eixoY, eixoZ);

            GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex3(eixoX, eixoY, -eixoZ);
            GL.Vertex3(eixoX, -eixoY, -eixoZ);
            GL.Vertex3(-eixoX, -eixoY, -eixoZ);
            GL.Vertex3(-eixoX, eixoY, -eixoZ);

            GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex3(eixoX, eixoY, eixoZ);
            GL.Vertex3(eixoX, -eixoY, eixoZ);
            GL.Vertex3(-eixoX, -eixoY, eixoZ);
            GL.Vertex3(-eixoX, eixoY, eixoZ);

        }
        void DrawQuad()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.Rotate(theta, 0.0, 0.0, 1.0);
            GL.Begin(BeginMode.Quads);
            DrawCube();
            
            //GL.Begin(BeginMode.Triangles);
            //DrawTriangle();
            GL.End();
            window.SwapBuffers();

            theta += 1.0;
            if (theta > 360)
                theta -= 360;
        }
        void DrawCube()
        {
            GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex2(20.0, 20.0);
            GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex2(-20.0, 20.0);
            GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex2(-20.0, -20.0);
            GL.Color3(1.0, 1.0, 0.0);
            GL.Vertex2(20.0, -20.0);
        }
        void DrawTriangle()
        {
            GL.Color3(1.0, 0.0, 0.0);
            // 1° vértice
            GL.Vertex2(1.0, 5.0);
            // 2° vértice
            GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex2(40.0, 5.0);
            // altura
            GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex2(20.0, 40.0);
        }
        void loaded(object o, EventArgs e)
        {
            GL.ClearColor(0.0f,0.0f,0.0f,0.0f);

            // Habilita profundidade,
            // caso contrário os objetos desenhados ficam sobrepostos
            GL.Enable(EnableCap.DepthTest);
        }
    }
}
