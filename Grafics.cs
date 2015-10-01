using System;
using System.Drawing;

namespace Fuzzy
{
    class Grafics
    {
        public static void LinieVerticala(Randare gr, Graphics g, float x, float y, Pen p)
        {
            g.DrawLine(p, gr.RandeazaW(x), gr.RandeazaH(0), gr.RandeazaW(x), gr.RandeazaH(y));
        }

        public static void LinieOrizontala(Randare gr, Graphics g, float x1, float x2, float y, Pen p)
        {
            g.DrawLine(p, gr.RandeazaW(x2), gr.RandeazaH(y), gr.RandeazaW(x1), gr.RandeazaH(y));
        }

        public static void Sistem(Graphics g, Randare gr)
        {
            Grafics.LinieOrizontala(gr, g, gr.Min, gr.Max, 0, Pens.Black);
            Grafics.LinieVerticala(gr, g, 0, 1, Pens.Black);
            Font f = new Font("Tahoma", 10);
            g.DrawString("1", f, Brushes.Black, gr.RandeazaW(0) - 5, gr.RandeazaH(1) - 15);
            g.DrawString(gr.Min.ToString(), f, Brushes.Black, gr.RandeazaW(gr.Min) - 10, gr.RandeazaH(0));
            g.DrawString(gr.Max.ToString(), f, Brushes.Black, gr.RandeazaW(gr.Max) - 10, gr.RandeazaH(0));
        }

        public static void Grafic(Graphics g, Randare gr, NumarFuzzy N, Pen p)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            for (int i = 1; i < N.vect.Length; ++i)
            {
                g.DrawLine(p, gr.RandeazaW(i - 1), gr.RandeazaH(N.vect[i - 1]), gr.RandeazaW(i), gr.RandeazaH(N.vect[i]));
            }
            g.DrawString((N.C - N.A).ToString(), new Font("Tahoma", 10), Brushes.Black, gr.RandeazaW(N.C - N.A) - 10, gr.RandeazaH(0));
            g.DrawString((N.C + N.B).ToString(), new Font("Tahoma", 10), Brushes.Black, gr.RandeazaW(N.C + N.B) - 10, gr.RandeazaH(0));
        }

        public static void AlfaCut(Graphics g, Randare gr, NumarFuzzy N, double alfa)
        {
            float x1 = 0, y1 = -1, x2 = 0, y2 = -1;
            for (int i = 0; i < N.vect.Length; ++i)
            {
                if (alfa < N.vect[i] && -1 == y1)
                {
                    x1 = i - 1;
                    y1 = N.vect[i - 1];
                }
                if (alfa > N.vect[i] && -1 != y1 && -1 == y2)
                {
                    x2 = i;
                    y2 = N.vect[i];
                }
            }
            LinieOrizontala(gr, g, x1, x2, y1, Pens.Coral);
            g.DrawString(Math.Round(x1, 0).ToString(), new Font("Tahoma", 10), Brushes.Black, gr.RandeazaW(x1) - 25, gr.RandeazaH(y1));
            LinieVerticala(gr, g, x1, y1, Pens.Coral);
            g.DrawString(Math.Round(x2, 0).ToString(), new Font("Tahoma", 10), Brushes.Black, gr.RandeazaW(x2) + 5, gr.RandeazaH(y2));
            LinieVerticala(gr, g, x2, y1, Pens.Coral);
        }
    }
}
