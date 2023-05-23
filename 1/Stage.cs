using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{  

    class Stage
    {
        Random rand = new Random();
        Node[,] nodes;
        Bitmap[] bitmaps;
        int[,] m_base;
        int[,] m_sub;
        Size m_size;
        int SizeH;
        int SizeW;
        public Point m_SelectPoint { get; set; }
        public Bitmap m_bitmap { get;set; } //스테이지 매니저에 갈수도

        //스테이지 생성
        public void CreateStage(Difficult p_dif)
        {
            //난이도에 맞춰 칸수 조절
            switch (p_dif)
            {
                case Difficult.Easy:
                    SizeH = 3; SizeW = 3;
                    break;
                case Difficult.Nomal:
                    SizeH = 5; SizeW = 5;
                    break;
                case Difficult.Hard:
                    SizeH = 7; SizeW = 7;
                    break;
                case Difficult.VeryHard:
                    SizeH = 10; SizeW = 10;
                    break;
            }
            nodes = new Node[SizeH, SizeW];
            m_base = new int[SizeH, SizeW];
            m_sub = new int[SizeH, SizeW];
            CutBitmap(m_bitmap);
            for (int y = 0; y < SizeH; y++)
            {
                for (int x = 0; x < SizeW; x++)
                {
                    nodes[y, x] = new Node();
                    int index = x + y * SizeW; //자른 비트맵을 불러올 인덱스
                    nodes[y, x].index = index;
                    nodes[y, x].SetNode(x, y, SizeW, SizeH);
                    m_base[y, x] = index;
                    m_sub[y, x] = m_base[y, x]; //원본 인덱스를 섞을 배열로 복사
                }
            }
        }
        public void Init(Difficult dif)
        { 
            m_sub[rand.Next(SizeH), rand.Next(SizeW)] = -1;
            SuffleNode(dif);
        }
        
        //노드 섞기
        public void SuffleNode(Difficult p_dif)
        {
            int count = 0; //몇번 섞을지 정함
            Point[] node = new Point[4];//빈칸주변 4칸 저장
            Point[] move = new Point[4];//빈칸주변 4칸이 움직일 방향
            switch (p_dif)
            {
                case Difficult.Easy:
                    count = 30;
                    break;
                case Difficult.Nomal:
                    count = 100;
                    break;
                case Difficult.Hard:
                    count = 300;
                    break;
                case Difficult.VeryHard:
                    count = 500;
                    break;
            }
            while(count>0)
            {
                //movenode(움직일수 있는 노드중 랜덤,그 노드가 움직일수 있는 방향)
                //움직일수 있는 노드중 하나를 랜덤으로 선택후 그 노드를 움직임
                //움직이면 카운트 감소
                CanMoveNode(ref node, ref move);
                int temp = rand.Next(4);
                if (MoveNode(node[temp].X, node[temp].Y, move[temp])) 
                {
                    count--;
                }
            }
        }

        //원본과 섞인 배열 비교해서 같은 위치에 같은 인덱스가 있으면 카운트 증가
        public bool ClearCheck()
        {
            int count = 0;
            for(int y = 0; y < SizeH; y++)
            {
                for(int x = 0; x < SizeW; x++)
                {
                    if (m_base[y, x] == m_sub[y,x])
                        count++;
                }
            }
            if (count == SizeH*SizeW-1) //빈칸을 제외한 모든 칸이 같으면 클리어
                return true;
            return false;
        }

        //기준을 중심으로 주변 4칸에서 움직일수 있는 노드를 찾음
        public void CanMoveNode(ref Point[] p_node,ref Point[] p_move)
        {
            int count = 0;
            int tx=0, ty=0;
            //기준이 되는 노드 찾기
            for(int y = 0; y < SizeH;y++)
            {
                for(int x= 0; x < SizeW; x++)
                {
                    if (m_sub[y, x] == -1)
                    {
                        tx = x;
                        ty = y;
                    }      
                }
            }
            //움직일수 있는 노드 찾기
            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    if ((x != y) && (x == 0 || y == 0) && MoveCheck(tx + x, ty + y))
                    {
                        p_node[count] = new Point(tx + x, ty + y);
                        p_move[count] = new Point(-x, -y);
                        if (count < 4)
                            count++;
                    }
                }
            }
        }

        //맵밖으로 나가는지 체크
        public bool MoveCheck(int x, int y)
        {
            if(x<0||x>=SizeH) return false;
            if(y<0||y>=SizeW) return false;
            return true;
        }

        //노드를 움직임
        public bool MoveNode(int x,int y, Point p_move)
        {
            int ex = x + p_move.X;
            int ey = y + p_move.Y;
            if(MoveCheck(ex, ey)&& m_sub[ey, ex] == -1)
            {
                int temp = m_sub[y, x];
                m_sub[y, x] = m_sub[ey, ex];
                m_sub[ey, ex] = temp;

                return true;
            }
            return false;
        }

        //선택된 노드의 배열의x,y값을 반환
        public Point SelectNode()
        {
            Point temp = new Point(-1, -1);
            for(int y=0; y<SizeH; y++)
            {
                for(int x =0; x<SizeW; x++)
                {
                    if (nodes[y, x].n_select)
                    {
                        temp.X = x;
                        temp.Y = y;
                    }        
                }
            }
            return temp;
        }

        //노드들 전부 컨트롤 추가
        public void AddNodes(Control.ControlCollection c)
        {            
            for (int y = 0; y < SizeH; y++)
            {
                for (int x = 0; x < SizeW; x++)
                {
                    //자신이 가진 인덱스에 맞게 비트맵 출력
                    if(m_sub[y, x]!=-1) 
                        nodes[y, x].SetBitmap(bitmaps[m_sub[y, x]]);
                    else
                        nodes[y, x].SetBitmap(Properties.Resources.빈칸);
                    c.Add(nodes[y, x].n_pictureBox);
                }
            }
        }
        
        //삭제
        public void RemoveStage()
        {
            for(int y = 0; y < SizeH; y++)
            {
                for(int x=0; x < SizeW; x++)
                {
                    nodes[y, x].Remove();

                }
            }
            bitmaps = null;
            m_base = null;
            m_sub = null;
        }

        //자신의 인덱스에 맞는 비트맵 받고 해당 노드만 다시그림
        public void Print(int x,int y)
        {
            if (!MoveCheck(x, y)) return;
            if (m_sub[y, x] != -1)
                nodes[y, x].SetBitmap(bitmaps[m_sub[y, x]]);
            else
                nodes[y, x].SetBitmap(Properties.Resources.빈칸);
            nodes[y, x].n_pictureBox.Invalidate();
        }

        //자신의 사이즈에 맞게 원본 비트맵을 잘라서 저장
        public void CutBitmap(Bitmap p_bitmap)
        {
            Size size = new Size();
            Point pos = new Point();
            bitmaps = new Bitmap[SizeH * SizeW];
            size.Width = p_bitmap.Width / SizeW;
            size.Height = p_bitmap.Height / SizeH;
            for(int y=0; y < SizeH; y++)
            {
                for(int x= 0; x < SizeW; x++)
                {
                    int index = x + y * SizeH;
                    pos.X = x * size.Width;
                    pos.Y = y * size.Height;
                    Rectangle rect = new Rectangle(pos, size);
                    bitmaps[index] = new Bitmap(100, 100); //노드 하나당 크기 정할수 잇음
                    bitmaps[index] = p_bitmap.Clone(rect, PixelFormat.DontCare);
                }
            }
        }
    }
}
