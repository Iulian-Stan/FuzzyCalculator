using System;
using System.Drawing;

namespace Fuzzy
{
    class Operatii
    {
        public static NumarFuzzy Sum(NumarFuzzy A, NumarFuzzy B, Graphics g, Randare gr, double alfa)
        {
            float ml, mr, nl, nr, ql, qr;
            bool draw = false, este = false;
            int i = 0;
            Randare temp = null;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            NumarFuzzy C = null;
            while (i <= 50)
            {
                MN(out ml, out mr, out nl, out nr, A, B, i * 0.02f);

                ql = ml + nl;
                qr = mr + nr;

                if (!draw)
                {
                    temp = new Randare(gr.WindowW, gr.WindowH, ql, qr, 1, gr.Offset);
                    C = new NumarFuzzy(A.C + B.C,ql,qr,gr.Max);
                    C.vect[i] = ql;
                    C.vect[99-i] = qr;
                    Grafics.Sistem(g, temp);
                    draw = !draw;
                }
                else
                {
                    C.vect[i] = ql;
                    C.vect[99 - i] = qr;
                    g.DrawLine(Pens.Aqua, temp.RandeazaW(C.vect[i - 1]), temp.RandeazaH((i - 1) * 0.02f), temp.RandeazaW(ql), temp.RandeazaH(i * 0.02f));
                    g.DrawLine(Pens.Aqua, temp.RandeazaW(C.vect[100 - i]), temp.RandeazaH((i - 1) * 0.02f), temp.RandeazaW(qr), temp.RandeazaH(i * 0.02f));
                    if (alfa < i * 0.02 && !este)
                    {
                        g.DrawLine(Pens.YellowGreen, temp.RandeazaW(C.vect[i - 1]), temp.RandeazaH((i -1) * 0.02f), temp.RandeazaW(C.vect[100 - i]), temp.RandeazaH((i - 1) * 0.02f));
                        g.DrawString(Math.Round(C.vect[i - 1], 1).ToString(), new Font("Tahoma", 10), Brushes.Black, temp.RandeazaW(C.vect[i - 1]) - 25, temp.RandeazaH((i - 1) * 0.02f));
                        g.DrawLine(Pens.YellowGreen, temp.RandeazaW(C.vect[i - 1]), temp.RandeazaH(0), temp.RandeazaW(C.vect[i - 1]), temp.RandeazaH((i - 1) * 0.02f));
                        g.DrawString(Math.Round(C.vect[100 - i], 1).ToString(), new Font("Tahoma", 10), Brushes.Black, temp.RandeazaW(C.vect[100 - i]) + 5, temp.RandeazaH((i - 1) * 0.02f));
                        g.DrawLine(Pens.YellowGreen, temp.RandeazaW(C.vect[100 - i]), temp.RandeazaH(0), temp.RandeazaW(C.vect[100 - i]), temp.RandeazaH((i - 1) * 0.02f));
                        este = !este;
                    }
                }
                ++i;
            }
            return C;
        }

        public static NumarFuzzy Sub(NumarFuzzy A, NumarFuzzy B, Graphics g, Randare gr, double alfa)
        {
            float ml, mr, nl, nr, ql, qr;
            bool draw = false, este = false;
            int i = 0;
            Randare temp = null;
            NumarFuzzy C = null;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            while (i <= 50)
            {
                MN(out ml, out mr, out nl, out nr, A, B, i * 0.02f);

                ql = ml - nr;
                qr = mr - nl;

                if (!draw)
                {
                    temp = new Randare(gr.WindowW, gr.WindowH, ql, qr, 1, gr.Offset);
                    C = new NumarFuzzy(A.C + B.C, ql, qr, gr.Max);
                    C.vect[i] = ql;
                    C.vect[99 - i] = qr;
                    Grafics.Sistem(g, temp);
                    draw = !draw;
                }
                else
                {
                    C.vect[i] = ql;
                    C.vect[99 - i] = qr;
                    g.DrawLine(Pens.Aqua, temp.RandeazaW(C.vect[i - 1]), temp.RandeazaH((i - 1) * 0.02f), temp.RandeazaW(ql), temp.RandeazaH(i * 0.02f));
                    g.DrawLine(Pens.Aqua, temp.RandeazaW(C.vect[100 - i]), temp.RandeazaH((i - 1) * 0.02f), temp.RandeazaW(qr), temp.RandeazaH(i * 0.02f));
                    if (alfa < i * 0.02 && !este)
                    {
                        g.DrawLine(Pens.YellowGreen, temp.RandeazaW(C.vect[i - 1]), temp.RandeazaH((i - 1) * 0.02f), temp.RandeazaW(C.vect[100 - i]), temp.RandeazaH((i - 1) * 0.02f));
                        g.DrawString(Math.Round(C.vect[i - 1], 1).ToString(), new Font("Tahoma", 10), Brushes.Black, temp.RandeazaW(C.vect[i - 1]) - 25, temp.RandeazaH((i - 1) * 0.02f));
                        g.DrawLine(Pens.YellowGreen, temp.RandeazaW(C.vect[i - 1]), temp.RandeazaH(0), temp.RandeazaW(C.vect[i - 1]), temp.RandeazaH((i - 1) * 0.02f));
                        g.DrawString(Math.Round(C.vect[100 - i], 1).ToString(), new Font("Tahoma", 10), Brushes.Black, temp.RandeazaW(C.vect[100 - i]) + 5, temp.RandeazaH((i - 1) * 0.02f));
                        g.DrawLine(Pens.YellowGreen, temp.RandeazaW(C.vect[100 - i]), temp.RandeazaH(0), temp.RandeazaW(C.vect[100 - i]), temp.RandeazaH((i - 1) * 0.02f));
                        este = !este;
                    }
                }
                ++i;
            }
            return C;
        }

        public static NumarFuzzy Mul(NumarFuzzy A, NumarFuzzy B, Graphics g, Randare gr, double alfa)
        {
            float ml, mr, nl, nr, ql, qr;
            bool draw = false, este = false;
            int i = 0;
            Randare temp = null;
            NumarFuzzy C = null;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            while (i <= 50)
            {
                MN(out ml, out mr, out nl, out nr, A, B, i * 0.02f);

                ql = Math.Min(Math.Min(ml * nl, ml * nr), Math.Min(mr * nl, mr * nr));
                qr = Math.Max(Math.Max(ml * nl, ml * nr), Math.Max(mr * nl, mr * nr));

                if (!draw)
                {
                    temp = new Randare(gr.WindowW, gr.WindowH, ql, qr, 1, gr.Offset);
                    C = new NumarFuzzy(A.C + B.C, ql, qr, gr.Max);
                    C.vect[i] = ql;
                    C.vect[99 - i] = qr;
                    Grafics.Sistem(g, temp);
                    draw = !draw;
                }
                else
                {
                    C.vect[i] = ql;
                    C.vect[99 - i] = qr;
                    g.DrawLine(Pens.Aqua, temp.RandeazaW(C.vect[i - 1]), temp.RandeazaH((i - 1) * 0.02f), temp.RandeazaW(ql), temp.RandeazaH(i * 0.02f));
                    g.DrawLine(Pens.Aqua, temp.RandeazaW(C.vect[100 - i]), temp.RandeazaH((i - 1) * 0.02f), temp.RandeazaW(qr), temp.RandeazaH(i * 0.02f));
                    if (alfa < i * 0.02 && !este)
                    {
                        g.DrawLine(Pens.YellowGreen, temp.RandeazaW(C.vect[i - 1]), temp.RandeazaH((i - 1) * 0.02f), temp.RandeazaW(C.vect[100 - i]), temp.RandeazaH((i - 1) * 0.02f));
                        g.DrawString(Math.Round(C.vect[i - 1], 1).ToString(), new Font("Tahoma", 10), Brushes.Black, temp.RandeazaW(C.vect[i - 1]) - 25, temp.RandeazaH((i - 1) * 0.02f));
                        g.DrawLine(Pens.YellowGreen, temp.RandeazaW(C.vect[i - 1]), temp.RandeazaH(0), temp.RandeazaW(C.vect[i - 1]), temp.RandeazaH((i - 1) * 0.02f));
                        g.DrawString(Math.Round(C.vect[100 - i], 1).ToString(), new Font("Tahoma", 10), Brushes.Black, temp.RandeazaW(C.vect[100 - i]) + 5, temp.RandeazaH((i - 1) * 0.02f));
                        g.DrawLine(Pens.YellowGreen, temp.RandeazaW(C.vect[100 - i]), temp.RandeazaH(0), temp.RandeazaW(C.vect[100 - i]), temp.RandeazaH((i - 1) * 0.02f));
                        este = !este;
                    }
                }
                ++i;
            }
            return C;
        }

        public static NumarFuzzy Div(NumarFuzzy A, NumarFuzzy B, Graphics g, Randare gr, double alfa)
        {
            float ml, mr, nl, nr, ql, qr;
            bool draw = false, este = false;
            int i = 0;
            Randare temp = null;
            NumarFuzzy C = null;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            while (i <= 50)
            {
                MN(out ml, out mr, out nl, out nr, A, B, i * 0.02f);

                ql = Math.Min(Math.Min(ml / nl, ml / nr), Math.Min(mr / nl, mr / nr));
                qr = Math.Max(Math.Max(ml / nl, ml / nr), Math.Max(mr / nl, mr / nr));

                if (!draw)
                {
                    temp = new Randare(gr.WindowW, gr.WindowH, ql, qr, 1, gr.Offset);
                    C = new NumarFuzzy(A.C + B.C, ql, qr, gr.Max);
                    C.vect[i] = ql;
                    C.vect[99 - i] = qr;
                    Grafics.Sistem(g, temp);
                    draw = !draw;
                }
                else
                {
                    C.vect[i] = ql;
                    C.vect[99 - i] = qr;
                    g.DrawLine(Pens.Aqua, temp.RandeazaW(C.vect[i - 1]), temp.RandeazaH((i - 1) * 0.02f), temp.RandeazaW(ql), temp.RandeazaH(i * 0.02f));
                    g.DrawLine(Pens.Aqua, temp.RandeazaW(C.vect[100 - i]), temp.RandeazaH((i - 1) * 0.02f), temp.RandeazaW(qr), temp.RandeazaH(i * 0.02f));
                    if (alfa < i * 0.02 && !este)
                    {
                        g.DrawLine(Pens.YellowGreen, temp.RandeazaW(C.vect[i - 1]), temp.RandeazaH((i - 1) * 0.02f), temp.RandeazaW(C.vect[100 - i]), temp.RandeazaH((i - 1) * 0.02f));
                        g.DrawString(Math.Round(C.vect[i - 1], 1).ToString(), new Font("Tahoma", 10), Brushes.Black, temp.RandeazaW(C.vect[i - 1]) - 25, temp.RandeazaH((i - 1) * 0.02f));
                        g.DrawLine(Pens.YellowGreen, temp.RandeazaW(C.vect[i - 1]), temp.RandeazaH(0), temp.RandeazaW(C.vect[i - 1]), temp.RandeazaH((i - 1) * 0.02f));
                        g.DrawString(Math.Round(C.vect[100 - i], 1).ToString(), new Font("Tahoma", 10), Brushes.Black, temp.RandeazaW(C.vect[100 - i]) + 5, temp.RandeazaH((i - 1) * 0.02f));
                        g.DrawLine(Pens.YellowGreen, temp.RandeazaW(C.vect[100 - i]), temp.RandeazaH(0), temp.RandeazaW(C.vect[100 - i]), temp.RandeazaH((i - 1) * 0.02f));
                        este = !este;
                    }
                }
                ++i;
            }
            return C;
        }

        public static void Int(NumarFuzzy A, NumarFuzzy B, Graphics g, Randare gr)
        {
            Grafics.Sistem(g, gr);
            float[] vect = new float[gr.Max];
            vect[0] = Math.Max(A.vect[0], B.vect[0]);
            for (int i = 1; i < 100; ++i)
            {
                if (A.vect[i] < B.vect[i])
                {
                    vect[i] = A.vect[i];
                }
                else
                {
                    vect[i] = B.vect[i];
                }
                g.DrawLine(Pens.Aqua, gr.RandeazaW(i - 1), gr.RandeazaH(vect[i - 1]), gr.RandeazaW(i), gr.RandeazaH(vect[i]));
            }
        }

        public static void Reu(NumarFuzzy A, NumarFuzzy B, Graphics g, Randare gr)
        {
            Grafics.Sistem(g, gr);
            float[] vect = new float[gr.Max];
            vect[0] = Math.Max(A.vect[0], B.vect[0]);
            for (int i = 1; i < 100; ++i)
            {
                if (A.vect[i] > B.vect[i])
                {
                    vect[i] = A.vect[i];
                }
                else
                {
                    vect[i] = B.vect[i];
                }
                g.DrawLine(Pens.Aqua, gr.RandeazaW(i - 1), gr.RandeazaH(vect[i - 1]), gr.RandeazaW(i), gr.RandeazaH(vect[i]));
            }
        }

        public static void Concentrare(NumarFuzzy A, Graphics g, Randare gr)
        {
            Grafics.Sistem(g, gr);
            float[] vect = new float[gr.Max];
            vect[0] = A.vect[0] * A.vect[0];
            for (int i = 1; i < 100; ++i)
            {
                vect[i] = A.vect[i] * A.vect[i];
                g.DrawLine(Pens.Aqua, gr.RandeazaW(i - 1), gr.RandeazaH(vect[i - 1]), gr.RandeazaW(i), gr.RandeazaH(vect[i]));
            }
        }

        public static void Putere(NumarFuzzy A, double n, Graphics g, Randare gr)
        {
            Grafics.Sistem(g, gr);
            float[] vect = new float[gr.Max];
            vect[0] = (float)Math.Pow(A.vect[0],n);
            for (int i = 1; i < 100; ++i)
            {
                vect[i] = (float)Math.Pow(A.vect[i], n);
                g.DrawLine(Pens.Aqua, gr.RandeazaW(i - 1), gr.RandeazaH(vect[i - 1]), gr.RandeazaW(i), gr.RandeazaH(vect[i]));
            }
        }

        public static void Dilatare(NumarFuzzy A, Graphics g, Randare gr)
        {
            Grafics.Sistem(g, gr);
            float[] vect = new float[gr.Max];
            vect[0] = (float)Math.Round(Math.Sqrt(A.vect[0]));
            for (int i = 1; i < 100; ++i)
            {
                vect[i] = (float)Math.Sqrt(Math.Abs(A.vect[i]));
                g.DrawLine(Pens.Aqua, gr.RandeazaW(i - 1), gr.RandeazaH(vect[i - 1]), gr.RandeazaW(i), gr.RandeazaH(vect[i]));
            }
        }

        public static void Intensificare(NumarFuzzy A, Graphics g, Randare gr)
        {
            Grafics.Sistem(g, gr);
            float[] vect = new float[gr.Max];
            if (A.vect[0] < 0.5)
                vect[0] = 2 * A.vect[0] * A.vect[0];
            else
                vect[0] = 1 - 2 * (1 - A.vect[0]) * ( 1 -  A.vect[0]);
            vect[0] = (float)Math.Round(Math.Sqrt(A.vect[0]));
            for (int i = 1; i < 100; ++i)
            {
                if (A.vect[i] < 0.5)
                    vect[i] = 2 * A.vect[i] * A.vect[i];
                else
                    vect[i] = 1 - 2 * (1 - A.vect[i]) * (1 - A.vect[i]);
                g.DrawLine(Pens.Aqua, gr.RandeazaW(i - 1), gr.RandeazaH(vect[i - 1]), gr.RandeazaW(i), gr.RandeazaH(vect[i]));
            }
        }

        private static void MN(out float ml,out float mr,out float nl,out float nr, NumarFuzzy A, NumarFuzzy B, float a)
        {
            ml = (A.C - A.A) + A.A * a;
            mr = (A.C + A.B) - A.B * a;
            nl = (B.C - B.A) + B.A * a;
            nr = (B.C + B.B) - B.B * a;
        }
    }
}
