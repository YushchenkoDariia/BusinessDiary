using System;
using System.Windows.Forms;

namespace BusinessDiary
{
    partial class ScheduleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleForm));
            this.panelSchedule = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnPrevDay = new System.Windows.Forms.Button();
            this.btnNextDay = new System.Windows.Forms.Button();
            this.btnToday = new System.Windows.Forms.Button();
            this.panelControls = new System.Windows.Forms.Panel();
            this.btnExportSchedule = new System.Windows.Forms.Button();
            this.btnImportSchedule = new System.Windows.Forms.Button();
            this.btnClearCustom = new System.Windows.Forms.Button();
            this.btnAddToComparison = new System.Windows.Forms.Button();
            this.lstLoadedSchedules = new System.Windows.Forms.ListBox();
            this.btnClearComparison = new System.Windows.Forms.Button();
            this.btnFindCommonTime = new System.Windows.Forms.Button();
            this.panelLegend = new System.Windows.Forms.Panel();
            this.panelFreeLegend = new System.Windows.Forms.Panel();
            this.lblLegendTitle = new System.Windows.Forms.Label();
            this.lblBusyLegend = new System.Windows.Forms.Label();
            this.lblFreeLegend = new System.Windows.Forms.Label();
            this.lblCustomLegend = new System.Windows.Forms.Label();
            this.panelCustomLegend = new System.Windows.Forms.Panel();
            this.panelBusyLegend = new System.Windows.Forms.Panel();
            this.panelComparison = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lblCurrentSchedule = new System.Windows.Forms.Label();
            this.lblComparisonTitle = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelControls.SuspendLayout();
            this.panelLegend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSchedule
            // 
            this.panelSchedule.AutoScroll = true;
            this.panelSchedule.BackColor = System.Drawing.Color.LavenderBlush;
            this.panelSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSchedule.Location = new System.Drawing.Point(0, 31);
            this.panelSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.panelSchedule.Name = "panelSchedule";
            this.panelSchedule.Size = new System.Drawing.Size(453, 658);
            this.panelSchedule.TabIndex = 0;
            this.panelSchedule.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSchedule_Paint_1);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lblDate);
            this.panelTop.Controls.Add(this.btnPrevDay);
            this.panelTop.Controls.Add(this.btnNextDay);
            this.panelTop.Controls.Add(this.btnToday);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1179, 49);
            this.panelTop.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(280, 12);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(189, 24);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Сьогоднішня дата";
            // 
            // btnPrevDay
            // 
            this.btnPrevDay.Location = new System.Drawing.Point(16, 10);
            this.btnPrevDay.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrevDay.Name = "btnPrevDay";
            this.btnPrevDay.Size = new System.Drawing.Size(107, 31);
            this.btnPrevDay.TabIndex = 1;
            this.btnPrevDay.Text = "< Попередня";
            this.btnPrevDay.Click += new System.EventHandler(this.btnPrevDay_Click);
            // 
            // btnNextDay
            // 
            this.btnNextDay.Location = new System.Drawing.Point(507, 10);
            this.btnNextDay.Margin = new System.Windows.Forms.Padding(4);
            this.btnNextDay.Name = "btnNextDay";
            this.btnNextDay.Size = new System.Drawing.Size(107, 31);
            this.btnNextDay.TabIndex = 2;
            this.btnNextDay.Text = "Наступна >";
            this.btnNextDay.Click += new System.EventHandler(this.btnNextDay_Click);
            // 
            // btnToday
            // 
            this.btnToday.Location = new System.Drawing.Point(160, 10);
            this.btnToday.Margin = new System.Windows.Forms.Padding(4);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(107, 31);
            this.btnToday.TabIndex = 3;
            this.btnToday.Text = "Сьогодні";
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelControls.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelControls.BackgroundImage")));
            this.panelControls.Controls.Add(this.btnExportSchedule);
            this.panelControls.Controls.Add(this.btnImportSchedule);
            this.panelControls.Controls.Add(this.btnClearCustom);
            this.panelControls.Controls.Add(this.btnAddToComparison);
            this.panelControls.Controls.Add(this.lstLoadedSchedules);
            this.panelControls.Controls.Add(this.btnClearComparison);
            this.panelControls.Controls.Add(this.btnFindCommonTime);
            this.panelControls.Controls.Add(this.panelLegend);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControls.Location = new System.Drawing.Point(912, 49);
            this.panelControls.Margin = new System.Windows.Forms.Padding(4);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(267, 689);
            this.panelControls.TabIndex = 1;
            // 
            // btnExportSchedule
            // 
            this.btnExportSchedule.Location = new System.Drawing.Point(8, 31);
            this.btnExportSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportSchedule.Name = "btnExportSchedule";
            this.btnExportSchedule.Size = new System.Drawing.Size(240, 37);
            this.btnExportSchedule.TabIndex = 0;
            this.btnExportSchedule.Text = "Експортувати розклад";
            this.btnExportSchedule.Click += new System.EventHandler(this.btnExportSchedule_Click);
            // 
            // btnImportSchedule
            // 
            this.btnImportSchedule.Location = new System.Drawing.Point(8, 76);
            this.btnImportSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportSchedule.Name = "btnImportSchedule";
            this.btnImportSchedule.Size = new System.Drawing.Size(240, 37);
            this.btnImportSchedule.TabIndex = 1;
            this.btnImportSchedule.Text = "Імпортувати розклад";
            this.btnImportSchedule.Click += new System.EventHandler(this.btnImportSchedule_Click);
            // 
            // btnClearCustom
            // 
            this.btnClearCustom.Location = new System.Drawing.Point(8, 121);
            this.btnClearCustom.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearCustom.Name = "btnClearCustom";
            this.btnClearCustom.Size = new System.Drawing.Size(240, 37);
            this.btnClearCustom.TabIndex = 2;
            this.btnClearCustom.Text = "Очистити вибрані години";
            this.btnClearCustom.Click += new System.EventHandler(this.btnClearCustom_Click);
            // 
            // btnAddToComparison
            // 
            this.btnAddToComparison.Location = new System.Drawing.Point(8, 166);
            this.btnAddToComparison.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddToComparison.Name = "btnAddToComparison";
            this.btnAddToComparison.Size = new System.Drawing.Size(240, 37);
            this.btnAddToComparison.TabIndex = 3;
            this.btnAddToComparison.Text = "Додати до порівняння";
            this.btnAddToComparison.Click += new System.EventHandler(this.btnAddToComparison_Click);
            // 
            // lstLoadedSchedules
            // 
            this.lstLoadedSchedules.FormattingEnabled = true;
            this.lstLoadedSchedules.ItemHeight = 16;
            this.lstLoadedSchedules.Location = new System.Drawing.Point(9, 236);
            this.lstLoadedSchedules.Margin = new System.Windows.Forms.Padding(4);
            this.lstLoadedSchedules.Name = "lstLoadedSchedules";
            this.lstLoadedSchedules.Size = new System.Drawing.Size(239, 132);
            this.lstLoadedSchedules.TabIndex = 4;
            // 
            // btnClearComparison
            // 
            this.btnClearComparison.Location = new System.Drawing.Point(11, 420);
            this.btnClearComparison.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearComparison.Name = "btnClearComparison";
            this.btnClearComparison.Size = new System.Drawing.Size(240, 37);
            this.btnClearComparison.TabIndex = 5;
            this.btnClearComparison.Text = "Очистити порівняння";
            this.btnClearComparison.Click += new System.EventHandler(this.btnClearComparison_Click);
            // 
            // btnFindCommonTime
            // 
            this.btnFindCommonTime.Location = new System.Drawing.Point(12, 465);
            this.btnFindCommonTime.Margin = new System.Windows.Forms.Padding(4);
            this.btnFindCommonTime.Name = "btnFindCommonTime";
            this.btnFindCommonTime.Size = new System.Drawing.Size(240, 37);
            this.btnFindCommonTime.TabIndex = 6;
            this.btnFindCommonTime.Text = "Знайти вільний час";
            this.btnFindCommonTime.Click += new System.EventHandler(this.btnFindCommonTime_Click);
            // 
            // panelLegend
            // 
            this.panelLegend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLegend.Controls.Add(this.panelFreeLegend);
            this.panelLegend.Controls.Add(this.lblLegendTitle);
            this.panelLegend.Controls.Add(this.lblBusyLegend);
            this.panelLegend.Controls.Add(this.lblFreeLegend);
            this.panelLegend.Controls.Add(this.lblCustomLegend);
            this.panelLegend.Controls.Add(this.panelCustomLegend);
            this.panelLegend.Controls.Add(this.panelBusyLegend);
            this.panelLegend.Location = new System.Drawing.Point(13, 530);
            this.panelLegend.Margin = new System.Windows.Forms.Padding(4);
            this.panelLegend.Name = "panelLegend";
            this.panelLegend.Size = new System.Drawing.Size(239, 123);
            this.panelLegend.TabIndex = 7;
            // 
            // panelFreeLegend
            // 
            this.panelFreeLegend.BackColor = System.Drawing.Color.LightGreen;
            this.panelFreeLegend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFreeLegend.Location = new System.Drawing.Point(12, 29);
            this.panelFreeLegend.Margin = new System.Windows.Forms.Padding(4);
            this.panelFreeLegend.Name = "panelFreeLegend";
            this.panelFreeLegend.Size = new System.Drawing.Size(26, 24);
            this.panelFreeLegend.TabIndex = 1;
            // 
            // lblLegendTitle
            // 
            this.lblLegendTitle.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblLegendTitle.Location = new System.Drawing.Point(1, 0);
            this.lblLegendTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLegendTitle.Name = "lblLegendTitle";
            this.lblLegendTitle.Size = new System.Drawing.Size(237, 25);
            this.lblLegendTitle.TabIndex = 0;
            this.lblLegendTitle.Text = "Позначення";
            this.lblLegendTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLegendTitle.Click += new System.EventHandler(this.lblLegendTitle_Click);
            // 
            // lblBusyLegend
            // 
            this.lblBusyLegend.Location = new System.Drawing.Point(46, 60);
            this.lblBusyLegend.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusyLegend.Name = "lblBusyLegend";
            this.lblBusyLegend.Size = new System.Drawing.Size(187, 25);
            this.lblBusyLegend.TabIndex = 4;
            this.lblBusyLegend.Text = "Зайнятий час";
            // 
            // lblFreeLegend
            // 
            this.lblFreeLegend.Location = new System.Drawing.Point(46, 29);
            this.lblFreeLegend.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFreeLegend.Name = "lblFreeLegend";
            this.lblFreeLegend.Size = new System.Drawing.Size(187, 25);
            this.lblFreeLegend.TabIndex = 2;
            this.lblFreeLegend.Text = "Вільний час";
            // 
            // lblCustomLegend
            // 
            this.lblCustomLegend.Location = new System.Drawing.Point(46, 90);
            this.lblCustomLegend.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomLegend.Name = "lblCustomLegend";
            this.lblCustomLegend.Size = new System.Drawing.Size(187, 25);
            this.lblCustomLegend.TabIndex = 6;
            this.lblCustomLegend.Text = "Вибраний час";
            // 
            // panelCustomLegend
            // 
            this.panelCustomLegend.BackColor = System.Drawing.Color.LightBlue;
            this.panelCustomLegend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCustomLegend.Location = new System.Drawing.Point(12, 90);
            this.panelCustomLegend.Margin = new System.Windows.Forms.Padding(4);
            this.panelCustomLegend.Name = "panelCustomLegend";
            this.panelCustomLegend.Size = new System.Drawing.Size(26, 24);
            this.panelCustomLegend.TabIndex = 5;
            // 
            // panelBusyLegend
            // 
            this.panelBusyLegend.BackColor = System.Drawing.Color.LightCoral;
            this.panelBusyLegend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBusyLegend.Location = new System.Drawing.Point(12, 60);
            this.panelBusyLegend.Margin = new System.Windows.Forms.Padding(4);
            this.panelBusyLegend.Name = "panelBusyLegend";
            this.panelBusyLegend.Size = new System.Drawing.Size(26, 24);
            this.panelBusyLegend.TabIndex = 3;
            // 
            // panelComparison
            // 
            this.panelComparison.AutoScroll = true;
            this.panelComparison.BackColor = System.Drawing.Color.LavenderBlush;
            this.panelComparison.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelComparison.Location = new System.Drawing.Point(0, 31);
            this.panelComparison.Margin = new System.Windows.Forms.Padding(4);
            this.panelComparison.Name = "panelComparison";
            this.panelComparison.Size = new System.Drawing.Size(454, 658);
            this.panelComparison.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 49);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panelSchedule);
            this.splitContainer.Panel1.Controls.Add(this.lblCurrentSchedule);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panelComparison);
            this.splitContainer.Panel2.Controls.Add(this.lblComparisonTitle);
            this.splitContainer.Size = new System.Drawing.Size(912, 689);
            this.splitContainer.SplitterDistance = 453;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 0;
            // 
            // lblCurrentSchedule
            // 
            this.lblCurrentSchedule.BackColor = System.Drawing.Color.Pink;
            this.lblCurrentSchedule.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrentSchedule.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentSchedule.Location = new System.Drawing.Point(0, 0);
            this.lblCurrentSchedule.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentSchedule.Name = "lblCurrentSchedule";
            this.lblCurrentSchedule.Size = new System.Drawing.Size(453, 31);
            this.lblCurrentSchedule.TabIndex = 1;
            this.lblCurrentSchedule.Text = "ПОТОЧНИЙ РОЗКЛАД";
            this.lblCurrentSchedule.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblComparisonTitle
            // 
            this.lblComparisonTitle.BackColor = System.Drawing.Color.Pink;
            this.lblComparisonTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblComparisonTitle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblComparisonTitle.Location = new System.Drawing.Point(0, 0);
            this.lblComparisonTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComparisonTitle.Name = "lblComparisonTitle";
            this.lblComparisonTitle.Size = new System.Drawing.Size(454, 31);
            this.lblComparisonTitle.TabIndex = 1;
            this.lblComparisonTitle.Text = "ПОРІВНЯННЯ РОЗКЛАДІВ";
            this.lblComparisonTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 738);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ScheduleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelControls.ResumeLayout(false);
            this.panelLegend.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSchedule;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnPrevDay;
        private System.Windows.Forms.Button btnNextDay;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Button btnExportSchedule;
        private System.Windows.Forms.Button btnImportSchedule;
        private System.Windows.Forms.Button btnClearCustom;
        private System.Windows.Forms.Button btnAddToComparison;
        private System.Windows.Forms.Panel panelComparison;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label lblCurrentSchedule;
        private System.Windows.Forms.Label lblComparisonTitle;
        private System.Windows.Forms.ListBox lstLoadedSchedules;
        private System.Windows.Forms.Button btnClearComparison;
        private System.Windows.Forms.Button btnFindCommonTime;
        private System.Windows.Forms.Panel panelLegend;
        private System.Windows.Forms.Label lblLegendTitle;
        private System.Windows.Forms.Panel panelFreeLegend;
        private System.Windows.Forms.Label lblFreeLegend;
        private System.Windows.Forms.Panel panelBusyLegend;
        private System.Windows.Forms.Label lblBusyLegend;
        private System.Windows.Forms.Panel panelCustomLegend;
        private System.Windows.Forms.Label lblCustomLegend;
    }
}