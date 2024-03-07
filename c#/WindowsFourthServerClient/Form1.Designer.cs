namespace WindowsFourthServerClient
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
            this.btn_Server_Start = new System.Windows.Forms.Button();
            this.btn_Client_Start = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txt_Msg = new System.Windows.Forms.TextBox();
            this.txt_Chat = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_Client_IP = new System.Windows.Forms.TextBox();
            this.txt_Server_IP = new System.Windows.Forms.TextBox();
            this.txt_NameS = new System.Windows.Forms.TextBox();
            this.txt_ChatS = new System.Windows.Forms.TextBox();
            this.txt_MsgS = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Server_Start
            // 
            this.btn_Server_Start.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Server_Start.Location = new System.Drawing.Point(207, 114);
            this.btn_Server_Start.Name = "btn_Server_Start";
            this.btn_Server_Start.Size = new System.Drawing.Size(103, 61);
            this.btn_Server_Start.TabIndex = 0;
            this.btn_Server_Start.Text = "Server";
            this.btn_Server_Start.UseVisualStyleBackColor = true;
            this.btn_Server_Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Client_Start
            // 
            this.btn_Client_Start.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Client_Start.Location = new System.Drawing.Point(772, 114);
            this.btn_Client_Start.Name = "btn_Client_Start";
            this.btn_Client_Start.Size = new System.Drawing.Size(103, 61);
            this.btn_Client_Start.TabIndex = 1;
            this.btn_Client_Start.Text = "Client";
            this.btn_Client_Start.UseVisualStyleBackColor = true;
            this.btn_Client_Start.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(937, 131);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 61);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txt_Msg
            // 
            this.txt_Msg.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_Msg.Location = new System.Drawing.Point(660, 395);
            this.txt_Msg.Multiline = true;
            this.txt_Msg.Name = "txt_Msg";
            this.txt_Msg.Size = new System.Drawing.Size(380, 33);
            this.txt_Msg.TabIndex = 3;
            this.txt_Msg.Text = "안녕 하세요";
            this.txt_Msg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Msg_KeyPress);
            // 
            // txt_Chat
            // 
            this.txt_Chat.Location = new System.Drawing.Point(578, 198);
            this.txt_Chat.Multiline = true;
            this.txt_Chat.Name = "txt_Chat";
            this.txt_Chat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Chat.Size = new System.Drawing.Size(462, 161);
            this.txt_Chat.TabIndex = 4;
            // 
            // txt_Name
            // 
            this.txt_Name.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_Name.Location = new System.Drawing.Point(578, 395);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(76, 29);
            this.txt_Name.TabIndex = 5;
            this.txt_Name.Text = "99";
            // 
            // txt_Client_IP
            // 
            this.txt_Client_IP.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_Client_IP.Location = new System.Drawing.Point(578, 146);
            this.txt_Client_IP.Name = "txt_Client_IP";
            this.txt_Client_IP.Size = new System.Drawing.Size(145, 29);
            this.txt_Client_IP.TabIndex = 6;
            this.txt_Client_IP.Text = "192.168.0.30";
            // 
            // txt_Server_IP
            // 
            this.txt_Server_IP.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_Server_IP.Location = new System.Drawing.Point(35, 146);
            this.txt_Server_IP.Name = "txt_Server_IP";
            this.txt_Server_IP.Size = new System.Drawing.Size(145, 29);
            this.txt_Server_IP.TabIndex = 10;
            this.txt_Server_IP.Text = "192.168.0.30";
            // 
            // txt_NameS
            // 
            this.txt_NameS.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_NameS.Location = new System.Drawing.Point(35, 395);
            this.txt_NameS.Name = "txt_NameS";
            this.txt_NameS.Size = new System.Drawing.Size(76, 29);
            this.txt_NameS.TabIndex = 9;
            this.txt_NameS.Text = "Server";
            // 
            // txt_ChatS
            // 
            this.txt_ChatS.Location = new System.Drawing.Point(35, 198);
            this.txt_ChatS.Multiline = true;
            this.txt_ChatS.Name = "txt_ChatS";
            this.txt_ChatS.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_ChatS.Size = new System.Drawing.Size(462, 161);
            this.txt_ChatS.TabIndex = 8;
            // 
            // txt_MsgS
            // 
            this.txt_MsgS.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_MsgS.Location = new System.Drawing.Point(117, 395);
            this.txt_MsgS.Multiline = true;
            this.txt_MsgS.Name = "txt_MsgS";
            this.txt_MsgS.Size = new System.Drawing.Size(380, 33);
            this.txt_MsgS.TabIndex = 7;
            this.txt_MsgS.Text = "안녕 하세요";
            this.txt_MsgS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_MsgS_KeyPress);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button4.Location = new System.Drawing.Point(548, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(11, 605);
            this.button4.TabIndex = 11;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(937, 36);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(103, 53);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "IP SAVE";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 623);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txt_Server_IP);
            this.Controls.Add(this.txt_NameS);
            this.Controls.Add(this.txt_ChatS);
            this.Controls.Add(this.txt_MsgS);
            this.Controls.Add(this.txt_Client_IP);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.txt_Chat);
            this.Controls.Add(this.txt_Msg);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btn_Client_Start);
            this.Controls.Add(this.btn_Server_Start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Server_Start;
        private System.Windows.Forms.Button btn_Client_Start;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txt_Msg;
        public  System.Windows.Forms.TextBox txt_Chat;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_Client_IP;
        private System.Windows.Forms.TextBox txt_Server_IP;
        private System.Windows.Forms.TextBox txt_NameS;
        public System.Windows.Forms.TextBox txt_ChatS;
        private System.Windows.Forms.TextBox txt_MsgS;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonSave;
    }
}

