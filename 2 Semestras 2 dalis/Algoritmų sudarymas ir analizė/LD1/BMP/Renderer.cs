using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleREngine
{
    internal class Renderer
    {
        public Renderer(string OutputName, ushort Width, ushort Height, uint FillingColor) // Color format is ARGB (to define recomended hex: 0xAARRGGBB), coordinates start from bottom left corner, 1 unit is 1 pixel
        {
            this.Width = Width;
            this.Height = Height;
            Buffer = new uint[Width * Height];

            Array.Fill(Buffer, FillingColor);

            this.OutputName = OutputName;
            if (!OutputName.Contains(".bmp"))
                this.OutputName += ".bmp";
        }


        public void DrawFilledSquare(double X, double Y, double Width, double Height, uint Color = 0)
        {
            for (double SY = 0; SY < Height; SY++)
            {
                for (double SX = 0; SX < Width; SX++)
                {
                    SetPixel(SX + X, SY + Y, Color);
                    Program.sk++;
                }
            }
            Write();
        }


        private void SetPixel(double X, double Y, uint Color)
        {
            int Pixel = GetPixel(X, Y);
            if (Pixel < 0)
                return;
            
            Buffer[Pixel] = Color;
          
        }

        private int GetPixel(double X, double Y)
        {
            int Pixel = ((int)Math.Round(Y) * Width) + (int)Math.Round(X);
            if (Pixel > Buffer.Length)
                return -1;

            if (X < 0)
                return -1;
            else if (X > Width)
                return -1;

            return Pixel;
        }

        public void Write()
        {
            using (FileStream File = new FileStream(OutputName, FileMode.Create, FileAccess.Write))
            {
                File.Write(new byte[] { 0x42, 0x4D }); // BM
                File.Write(BitConverter.GetBytes(Height * Width * sizeof(uint) + 0x1A)); // Size
                File.Write(BitConverter.GetBytes(0)); // Reserved (0s)
                File.Write(BitConverter.GetBytes(0x1A)); // Image Offset (size of the header)
                File.Write(BitConverter.GetBytes(0x0C)); // Header size (size is 12 bytes)
                File.Write(BitConverter.GetBytes(Width)); // Width
                File.Write(BitConverter.GetBytes(Height)); // Height
                File.Write(BitConverter.GetBytes((ushort)1)); // Color plane
                File.Write(BitConverter.GetBytes((ushort)32)); // bits per pixel

                byte[] Converted = new byte[Buffer.Length * sizeof(uint)];

                System.Buffer.BlockCopy(Buffer, 0, Converted, 0, Converted.Length);

                File.Write(Converted);
                File.Close();
            }
        }

        private readonly uint[] Buffer;
        private readonly ushort Width;
        private readonly ushort Height;
        private readonly string OutputName;
    }
}
