using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenGL_TK
{
    class Game
    {
        int textura;
        double theta = 0.0;
        double eixoX = 10, eixoY = 10, eixoZ = 10;
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

            // Salva o estado da matriz
            GL.PushMatrix();

            // Movido para traz para que possa ser renderizado
            GL.Translate(0.0, 0.0, -45.0);
            GL.Rotate(theta, 1.0, 0.0, 0.0);
            GL.Rotate(theta, 0.0, 0.0, 1.0);

            GL.Scale(1.0, 1.0, 1.0);
            CoordenadasCubo();
            // Possivel desenhar uma matriz dentro
            GL.PopMatrix();


            window.SwapBuffers();

            theta += 1.0;
            if (theta > 360)
                theta -= 360;
        }
        void CoordenadasCubo()
        {
            GL.Begin(BeginMode.Quads);

            GL.Color3(1.0, 1.0, 1.0);

            // Frente
            // Vetor normal, normal vector
            GL.Normal3(0.0, 0.0, 1.0);
            //Especificar a coordena da textura
            GL.TexCoord2(0,0);
            GL.Vertex3(-eixoX, -eixoY, eixoZ);
            GL.TexCoord2(1, 0);
            GL.Vertex3(eixoX, -eixoY, eixoZ);
            GL.TexCoord2(1, 1);
            GL.Vertex3(eixoX, eixoY, eixoZ);
            GL.TexCoord2(0, 1);
            GL.Vertex3(-eixoX, eixoY, eixoZ);

            // Atras
            GL.Normal3(0.0, 0.0, -1.0);
            GL.TexCoord2(0,0);
            GL.Vertex3(eixoX, eixoY, eixoZ);
            GL.TexCoord2(1, 0);
            GL.Vertex3(eixoX, eixoY, -eixoZ);
            GL.TexCoord2(1, 1);
            GL.Vertex3(eixoX, -eixoY, -eixoZ);
            GL.TexCoord2(0, 1);
            GL.Vertex3(eixoX, -eixoY, eixoZ);

            // Topo
            GL.Normal3(0.0, 1.0, 0.0);
            GL.TexCoord2(0,0);
            GL.Vertex3(eixoX, -eixoY, eixoZ);
            GL.TexCoord2(1, 0);
            GL.Vertex3(eixoX, -eixoY, -eixoZ);
            GL.TexCoord2(1, 1);
            GL.Vertex3(-eixoX, -eixoY, -eixoZ);
            GL.TexCoord2(0, 1);
            GL.Vertex3(-eixoX, -eixoY, eixoZ);

            // Base
            GL.Normal3(0.0, -0 + 1, 0.0);
            GL.TexCoord2(0,0);
            GL.Vertex3(eixoX, eixoY, eixoZ);
            GL.TexCoord2(1, 0);
            GL.Vertex3(eixoX, eixoY, -eixoZ);
            GL.TexCoord2(1, 1);
            GL.Vertex3(-eixoX, eixoY, -eixoZ);
            GL.TexCoord2(0, 1);
            GL.Vertex3(-eixoX, eixoY, eixoZ);

            // Direita
            GL.Normal3(1.0, 0.0, 0.0);
            GL.TexCoord2(0,0);
            GL.Vertex3(eixoX, eixoY, -eixoZ);
            GL.TexCoord2(1, 0);
            GL.Vertex3(eixoX, -eixoY, -eixoZ);
            GL.TexCoord2(1, 1);
            GL.Vertex3(-eixoX, -eixoY, -eixoZ);
            GL.TexCoord2(0, 1);
            GL.Vertex3(-eixoX, eixoY, -eixoZ);

            // Esquerda
            GL.Normal3(-1.0, 0.0, 0.0);
            GL.TexCoord2(0,0);
            GL.Vertex3(eixoX, eixoY, eixoZ);
            GL.TexCoord2(1, 0);
            GL.Vertex3(eixoX, -eixoY, eixoZ);
            GL.TexCoord2(1, 1);
            GL.Vertex3(-eixoX, -eixoY, eixoZ);
            GL.TexCoord2(0, 1);
            GL.Vertex3(-eixoX, eixoY, eixoZ);

            GL.End();
        }
        void DrawQuad()
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
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            // Habilita profundidade,
            // caso contrário os objetos desenhados ficam sobrepostos
            GL.Enable(EnableCap.DepthTest);
            
            
            // Iluminação habilitada
            GL.Enable(EnableCap.Lighting);

            float[] luzPosicao = { 20f, 20f, 60f};
            float[] luzDiffuse = { 1.0f, 1.0f, 1.0f };
            float[] luzAmbiente = { 0.5f, 0.5f, 0.5f };
            GL.Light(LightName.Light0, LightParameter.Position, luzPosicao);
            GL.Light(LightName.Light0, LightParameter.Diffuse, luzDiffuse);

            // Luz  de Ambiente
            GL.Light(LightName.Light0, LightParameter.Ambient, luzAmbiente);

            GL.Enable(EnableCap.Light0);

            // Textura
            GL.Enable(EnableCap.Texture2D);
            GL.GenTextures(1, out textura);
            GL.BindTexture(TextureTarget.Texture2D, textura);
            System.Drawing.Imaging.BitmapData texData = Loadimagem(@"C:\Users\André Luiz\Documents\GitHub\Trabalho_Comp_Graf\Textura\Caixa.bmp");
            GL.TexImage2D(TextureTarget.Texture2D, 0, OpenTK.Graphics.OpenGL.PixelInternalFormat.Rgb, texData.Width, texData.Height,
                0,OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        }
        System.Drawing.Imaging.BitmapData Loadimagem(string pastaCaminho)
        {
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(pastaCaminho);

            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height);
            // Extrair o bitmap da imagem
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            bmp.UnlockBits(bmpData);

            return bmpData;
        }
    }
}
