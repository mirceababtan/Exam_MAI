namespace Exam_MAI_r2_pb2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            
        }

        private void Form1_Load(object sender,PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new(Color.DarkGreen, 2);

            Random random = new Random();

            List<Point> points = new List<Point>();

            int n = 50;

            for (int i = 0; i < n; i++)
            {
                int x = random.Next(20, this.Width - 20);
                int y = random.Next(20, this.Height - 20);

                points.Add(new Point(x, y));

                g.DrawEllipse(pen, points[i].X, points[i].Y, 4, 4);

                      
            }

            float P_Max = 0;
            float A_Min = 1e10f;
            Point[] p_perm = new Point[3];
            Point[] p_arie = new Point[3];


            for (int i = 0; i < n - 2; i++)
            {
                for (int j = i+1; j < n - 1; j++)
                {
                    for(int k=j+1;k<n;k++)
                    {
                        if (P_Max < perm(points[i], points[j], points[k]))
                        {
                            P_Max = perm(points[i], points[j], points[k]);

                            p_perm[0] = points[i];
                            p_perm[1] = points[j];
                            p_perm[2] = points[k];
                        }

                        if (A_Min > aria(points[i], points[j], points[k]))
                        {
                            A_Min = aria(points[i], points[j], points[k]);

                            p_arie[0] = points[i];
                            p_arie[1] = points[j];
                            p_arie[2] = points[k];
                        }
                    }
                }
            }

            g.DrawLine(pen, p_perm[0], p_perm[1]);
            g.DrawLine(pen, p_perm[0], p_perm[2]);
            g.DrawLine(pen, p_perm[1], p_perm[2]);

            g.DrawLine(pen, p_arie[0], p_arie[1]);
            g.DrawLine(pen, p_arie[0], p_arie[2]);
            g.DrawLine(pen, p_arie[1], p_arie[2]);


        }

        float aria(Point A, Point B, Point C)
        {
            float a = dist(B, C);
            float b = dist(A, C);
            float c = dist(A, B);

            float p = perm(A, B, C) / 2;

            return (float)Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        float perm(Point A, Point B, Point C)
        {
            return dist(B, C) + dist(A, C) + dist(A, B);
        }

        float dist(Point A,Point B)
        {
            return (float)Math.Sqrt((B.X - A.X) * (B.X - A.X) + (B.Y - A.Y) * (B.Y - A.Y));
        }

    }
}
