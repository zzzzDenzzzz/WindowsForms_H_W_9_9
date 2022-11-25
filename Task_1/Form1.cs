using System.Drawing;
using System.Windows.Forms;

/*Создайте приложение, которое будет рисовать шахматную до-
ску и шахматные фигуры на клиентской области формы. Для ка-
ждой фигуры должно отображаться контекстное меню. */

namespace Task_1
{
    public partial class Form1 : Form
    {
        Image chessSprites;
        public int[,] map =
        {
            {25,24,23,22,21,23,24,25 },
            {26,26,26,26,26,26,26,26 },
            {0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0 },
            {16,16,16,16,16,16,16,16 },
            {15,14,13,12,11,13,14,15 },
        };

        public Form1()
        {
            InitializeComponent();

            chessSprites = new Bitmap(@"C:\Users\Professional\Desktop\chess.png");
            Image part = new Bitmap(50, 50);
            Graphics g = Graphics.FromImage(part);
            g.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 0, 0, 150, 150, GraphicsUnit.Pixel);
            Init();
        }

        public void Init()
        {
            CreateMap();
        }

        public void CreateMap()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    Button butt = new Button();
                    butt.Size = new Size(50, 50);
                    butt.Location = new Point(j * 50, i * 50);

                    switch (map[i, j] / 10)
                    {
                        case 1:
                            Image part = new Bitmap(50, 50);
                            Graphics g = Graphics.FromImage(part);
                            g.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 0 + 150 * (map[i, j] % 10 - 1), 0, 150, 150, GraphicsUnit.Pixel);
                            butt.BackgroundImage = part;
                            break;
                        case 2:
                            Image part1 = new Bitmap(50, 50);
                            Graphics g1 = Graphics.FromImage(part1);
                            g1.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 0 + 150 * (map[i, j] % 10 - 1), 150, 150, 150, GraphicsUnit.Pixel);
                            butt.BackgroundImage = part1;
                            break;
                    }
                    if (j % 2 == 0 && i % 2 == 0)
                    {
                        butt.BackColor = Color.White;
                    }
                    else
                    {
                        butt.BackColor = Color.Gray;
                    }
                    Controls.Add(butt);
                }
            }
        }
    }
}
