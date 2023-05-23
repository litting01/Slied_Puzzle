using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;

namespace _1
{
    class Node
    {
        public int index;
        public bool n_select = false;
        public Bitmap n_bitmap { get; set; }
        public PictureBox n_pictureBox;

        public void InitNode()
        {
            n_pictureBox = new PictureBox();
            //이벤트 추가
            n_pictureBox.MouseMove += Node_Move;
            n_pictureBox.MouseLeave += Node_Leave;
        }

        
        private void Node_Leave(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            Graphics graphics = control.CreateGraphics();
            graphics.DrawImage(n_bitmap, n_pictureBox.ClientRectangle);//마우스가 떠나면 자신의 비트맵을 다시 그림
            n_select = false;//선택 해제
        }

        private void Node_Move(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            Graphics graphics = control.CreateGraphics();
            Pen pen = new Pen(Color.Red, 3);
            graphics.DrawRectangle(pen, n_pictureBox.ClientRectangle);//마우스가 들어오면 노드 주변에 보이도록 사각형 그림
            n_select = true;//선택
        }

        //자른 비트맵 복사 붙여넣기
        public void SetBitmap(Bitmap p_bitmap)
        {
            n_bitmap = (Bitmap)p_bitmap.Clone();
            n_pictureBox.Image = (Image)n_bitmap.Clone();
        }

        //노드 설정
        public void SetNode(int p_x, int p_y,int m_x,int m_y)
        {
            InitNode();
            Size size = new Size();
            size.Width = 500 / m_x; //500은 크기 제한
            size.Height = 500/ m_y;
            Point pos = new Point();
            pos.X = p_x * size.Width;
            pos.Y = p_y * size.Height + 30;//+30은 메뉴바가 살짝 가려서 밑으로 내림
            SetPictureBox(pos, size);
        }

        //노드의 이미지박스 설정
        public void SetPictureBox(Point p_point, Size p_size)
        {
            n_pictureBox.Name = p_point.ToString();
            n_pictureBox.Location = p_point;
            n_pictureBox.Size = p_size;//최종 크기
            n_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        //삭제
        public void Remove()
        {
            n_bitmap = null;
            n_pictureBox.Dispose();
        }

    }
}
