using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System;
using System.Drawing;

namespace gk_p3
{
    internal class FastBitmap : IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        public bool Disposed { get; private set; } = false;
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int N { get; private set; }
        public int Stripe { get; private set; }
        public Int32[] Bits { get; private set; }
        private GCHandle BitsHandle { get; set; }

        public FastBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            N = width * height;
            Stripe = width * 4;

            Bits = new Int32[this.N];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, this.Stripe, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        public void SetPixel(int x, int y, Color color)
        {
            int index = x + (y * Width);
            Bits[index] = color.ToArgb();
        }

        public Color GetPixel(int x, int y)
        {
            int index = x + (y * Width);
            int col = Bits[index];
            Color result = Color.FromArgb(col);

            return result;
        }

        public void Dispose()
        {
            if (this.Disposed) return;
            this.Disposed = true;
            this.BitsHandle.Free();
            this.Bitmap.Dispose();
        }
    }
}
