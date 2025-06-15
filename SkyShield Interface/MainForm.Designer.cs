using SkyShield_Interface.Models;
using SkyShield_Interface.Presenters;
using SkyShield_Interface.Views;

namespace SkyShield_Interface
{
    partial class MainForm : Form
    {
        
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            defenseLogs = new DataGridView();
            timeDataGridViewTextColumn = new DataGridViewTextBoxColumn();
            eventDataGridViewTextColumn = new DataGridViewTextBoxColumn();
            btnPlayVideo = new Button();
            mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)defenseLogs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mediaPlayer).BeginInit();
            SuspendLayout();
            // 
            // defenseLogs
            // 
            defenseLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            defenseLogs.Columns.AddRange(new DataGridViewColumn[] { timeDataGridViewTextColumn, eventDataGridViewTextColumn });
            defenseLogs.Location = new Point(26, 390);
            defenseLogs.Name = "defenseLogs";
            defenseLogs.Size = new Size(874, 220);
            defenseLogs.TabIndex = 0;
            // 
            // timeDataGridViewTextColumn
            // 
            timeDataGridViewTextColumn.HeaderText = "Time";
            timeDataGridViewTextColumn.Name = "timeDataGridViewTextColumn";
            timeDataGridViewTextColumn.Width = 400;
            // 
            // eventDataGridViewTextColumn
            // 
            eventDataGridViewTextColumn.HeaderText = "Event";
            eventDataGridViewTextColumn.Name = "eventDataGridViewTextColumn";
            eventDataGridViewTextColumn.Width = 400;
            // 
            // btnPlayVideo
            // 
            btnPlayVideo.Location = new Point(915, 445);
            btnPlayVideo.Name = "btnPlayVideo";
            btnPlayVideo.Size = new Size(142, 105);
            btnPlayVideo.TabIndex = 1;
            btnPlayVideo.Text = "Play Last Defense Scene";
            btnPlayVideo.UseVisualStyleBackColor = true;
            btnPlayVideo.Click += btnPlayVideo_Click;
            // 
            // mediaPlayer
            // 
            mediaPlayer.Enabled = true;
            mediaPlayer.Location = new Point(26, 12);
            mediaPlayer.Name = "mediaPlayer";
            mediaPlayer.OcxState = (AxHost.State)resources.GetObject("mediaPlayer.OcxState");
            mediaPlayer.Size = new Size(1040, 372);
            mediaPlayer.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1095, 622);
            Controls.Add(mediaPlayer);
            Controls.Add(btnPlayVideo);
            Controls.Add(defenseLogs);
            Name = "MainForm";
            Text = "Sky Shield Interface";
            ((System.ComponentModel.ISupportInitialize)defenseLogs).EndInit();
            ((System.ComponentModel.ISupportInitialize)mediaPlayer).EndInit();
            ResumeLayout(false);
        }

        private void btnPlayVideo_Click(object sender, EventArgs e)
        {
            presenter?.PlayLastVideo();
        }

        public void DisplayLog(ThreatLog log)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => DisplayLog(log)));
                return;
            }

            defenseLogs.Rows.Add(
                log.Timestamp,
                log.Event);
        }

        public void SetPresenter(MainPresenter presenter)
        {
            this.presenter = presenter;
        }

        #endregion

        private DataGridView defenseLogs;
        private Button btnPlayVideo;
        public AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
        private DataGridViewTextBoxColumn timeDataGridViewTextColumn;
        private DataGridViewTextBoxColumn eventDataGridViewTextColumn;
    }
}
