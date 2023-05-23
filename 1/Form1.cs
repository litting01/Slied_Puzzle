using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class Form1 : Form
    {
        private GameInfo gameInfo;
        public Form1()
        {
            InitializeComponent();
            gameInfo = new GameInfo();
            gameInfo.g_dif = Difficult.Easy;
            gameInfo.Init();
            gameInfo.g_stage.AddNodes(Controls);
            
            this.KeyDown += Form1_KeyDown;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //키 누르면 방향대로 값 저장
            Point temp = gameInfo.g_stage.SelectNode();
            Point move = new Point(0, 0);
            switch (e.KeyCode)
            {
                case Keys.Left:
                    move.Offset(-1, 0);
                    break;
                case Keys.Right:
                    move.Offset(1, 0);
                    break;
                case Keys.Up:
                    move.Offset(0, -1);
                    break;
                case Keys.Down:
                    move.Offset(0, 1);
                    break;
            }
            if(!(move.X != 0 && move.Y != 0)) //방향키들중 눌렀으면
            {
                //선택된 노드를 move방향으로 움직임
                gameInfo.g_stage.MoveNode(temp.X, temp.Y, move);

                //이동한 곳과 지나간곳 둘다 바뀐값 출력
                gameInfo.g_stage.Print(temp.X, temp.Y);
                gameInfo.g_stage.Print(temp.X+move.X, temp.Y+move.Y);
                if (gameInfo.g_stage.ClearCheck()) //클리어 체크
                {
                    MessageBox.Show("Clear");
                    gameInfo.Reset(Controls);
                }
            }
        }

        private void 쉬움ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameInfo.g_dif = Difficult.Easy;
            gameInfo.Reset(Controls);
        }

        private void 보통ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameInfo.g_dif = Difficult.Nomal;
            gameInfo.Reset(Controls);
        }

        private void 어려움ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameInfo.g_dif = Difficult.Hard;
            gameInfo.Reset(Controls);
        }

        private void 매우어려움ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameInfo.g_dif = Difficult.VeryHard;
            gameInfo.Reset(Controls);
        }
    }
}
