namespace _1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.난이도ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.쉬움ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.보통ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.어려움ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.매우어려움ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.난이도ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1182, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 난이도ToolStripMenuItem
            // 
            this.난이도ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.쉬움ToolStripMenuItem,
            this.보통ToolStripMenuItem,
            this.어려움ToolStripMenuItem,
            this.매우어려움ToolStripMenuItem});
            this.난이도ToolStripMenuItem.Name = "난이도ToolStripMenuItem";
            this.난이도ToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.난이도ToolStripMenuItem.Text = "난이도";
            // 
            // 쉬움ToolStripMenuItem
            // 
            this.쉬움ToolStripMenuItem.Name = "쉬움ToolStripMenuItem";
            this.쉬움ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.쉬움ToolStripMenuItem.Text = "쉬움";
            this.쉬움ToolStripMenuItem.Click += new System.EventHandler(this.쉬움ToolStripMenuItem_Click);
            // 
            // 보통ToolStripMenuItem
            // 
            this.보통ToolStripMenuItem.Name = "보통ToolStripMenuItem";
            this.보통ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.보통ToolStripMenuItem.Text = "보통";
            this.보통ToolStripMenuItem.Click += new System.EventHandler(this.보통ToolStripMenuItem_Click);
            // 
            // 어려움ToolStripMenuItem
            // 
            this.어려움ToolStripMenuItem.Name = "어려움ToolStripMenuItem";
            this.어려움ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.어려움ToolStripMenuItem.Text = "어려움";
            this.어려움ToolStripMenuItem.Click += new System.EventHandler(this.어려움ToolStripMenuItem_Click);
            // 
            // 매우어려움ToolStripMenuItem
            // 
            this.매우어려움ToolStripMenuItem.Name = "매우어려움ToolStripMenuItem";
            this.매우어려움ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.매우어려움ToolStripMenuItem.Text = "매우 어려움";
            this.매우어려움ToolStripMenuItem.Click += new System.EventHandler(this.매우어려움ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 853);
            this.Controls.Add(this.menuStrip1);
            this.Location = new System.Drawing.Point(1, 1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 난이도ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 쉬움ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 보통ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 어려움ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 매우어려움ToolStripMenuItem;
    }
}

