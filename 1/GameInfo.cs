using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    enum Difficult
    {
        Easy,
        Nomal,
        Hard,
        VeryHard
    }
    class GameInfo
    {
        public Difficult g_dif { get; set; }
        public Stage g_stage { get; set; }
        List<Bitmap> g_bitmaps; //이미지 리스트
        Random rand = new Random();

        public void Init()
        {
            g_bitmaps = new List<Bitmap>();
            g_bitmaps.Add(Properties.Resources.판타지);
            g_bitmaps.Add(Properties.Resources.토성);

            g_stage = new Stage();
            g_stage.m_bitmap = g_bitmaps[rand.Next(g_bitmaps.Count)];//리스트중 랜덤으로 하나 넘김
            g_stage.CreateStage(g_dif);
            g_stage.Init(g_dif);
            
        }
        //지우고 다시 생성
        public void Reset(Control.ControlCollection c)
        {
            g_bitmaps.Clear();
            g_stage.RemoveStage();
            Init();
            g_stage.AddNodes(c);
        }
    }
}
