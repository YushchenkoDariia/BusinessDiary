namespace BusinessDiary
{
    partial class DiaryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiaryForm));
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnViewTasks = new System.Windows.Forms.Button();
            this.btnAddNote = new System.Windows.Forms.Button();
            this.btnOpenCalendar = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.btnDeleteNote = new System.Windows.Forms.Button();
            this.lblTasks = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lstTasks = new System.Windows.Forms.ListBox();
            this.lstNotes = new System.Windows.Forms.ListBox();
            this.btnEditTask = new System.Windows.Forms.Button();
            this.btnEditNote = new System.Windows.Forms.Button();
            this.tblDaySchedule = new System.Windows.Forms.TableLayoutPanel();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddTask
            // 
            this.btnAddTask.BackColor = System.Drawing.Color.Ivory;
            this.btnAddTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddTask.Location = new System.Drawing.Point(11, 190);
            this.btnAddTask.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(165, 40);
            this.btnAddTask.TabIndex = 0;
            this.btnAddTask.Text = "Додати справу";
            this.btnAddTask.UseVisualStyleBackColor = false;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click_1);
            // 
            // btnViewTasks
            // 
            this.btnViewTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnViewTasks.Location = new System.Drawing.Point(13, 66);
            this.btnViewTasks.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewTasks.Name = "btnViewTasks";
            this.btnViewTasks.Size = new System.Drawing.Size(215, 50);
            this.btnViewTasks.TabIndex = 1;
            this.btnViewTasks.Text = "Переглянути всі справи";
            this.btnViewTasks.UseVisualStyleBackColor = true;
            this.btnViewTasks.Click += new System.EventHandler(this.btnViewTasks_Click_1);
            // 
            // btnAddNote
            // 
            this.btnAddNote.BackColor = System.Drawing.Color.Ivory;
            this.btnAddNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddNote.Location = new System.Drawing.Point(601, 190);
            this.btnAddNote.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddNote.Name = "btnAddNote";
            this.btnAddNote.Size = new System.Drawing.Size(182, 40);
            this.btnAddNote.TabIndex = 2;
            this.btnAddNote.Text = "Додати нотатку";
            this.btnAddNote.UseVisualStyleBackColor = false;
            this.btnAddNote.Click += new System.EventHandler(this.btnAddNote_Click_1);
            // 
            // btnOpenCalendar
            // 
            this.btnOpenCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOpenCalendar.Location = new System.Drawing.Point(13, 13);
            this.btnOpenCalendar.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenCalendar.Name = "btnOpenCalendar";
            this.btnOpenCalendar.Size = new System.Drawing.Size(215, 45);
            this.btnOpenCalendar.TabIndex = 4;
            this.btnOpenCalendar.Text = "Відкрити календар";
            this.btnOpenCalendar.UseVisualStyleBackColor = true;
            this.btnOpenCalendar.Click += new System.EventHandler(this.btnOpenCalendar_Click_1);
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnDeleteTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteTask.Location = new System.Drawing.Point(11, 238);
            this.btnDeleteTask.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(165, 40);
            this.btnDeleteTask.TabIndex = 5;
            this.btnDeleteTask.Text = "Видалити справу";
            this.btnDeleteTask.UseVisualStyleBackColor = false;
            // 
            // btnDeleteNote
            // 
            this.btnDeleteNote.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnDeleteNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteNote.Location = new System.Drawing.Point(601, 238);
            this.btnDeleteNote.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteNote.Name = "btnDeleteNote";
            this.btnDeleteNote.Size = new System.Drawing.Size(182, 40);
            this.btnDeleteNote.TabIndex = 6;
            this.btnDeleteNote.Text = "Видалити нотатку";
            this.btnDeleteNote.UseVisualStyleBackColor = false;
            this.btnDeleteNote.Click += new System.EventHandler(this.btnDeleteNote_Click);
            // 
            // lblTasks
            // 
            this.lblTasks.AutoSize = true;
            this.lblTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblTasks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTasks.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTasks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTasks.Location = new System.Drawing.Point(200, 148);
            this.lblTasks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTasks.Name = "lblTasks";
            this.lblTasks.Size = new System.Drawing.Size(174, 39);
            this.lblTasks.TabIndex = 7;
            this.lblTasks.Text = "Ваші справи";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblNotes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNotes.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNotes.Location = new System.Drawing.Point(801, 148);
            this.lblNotes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(185, 39);
            this.lblNotes.TabIndex = 8;
            this.lblNotes.Text = "Ваші нотатки";
            this.lblNotes.Click += new System.EventHandler(this.lblNotes_Click);
            // 
            // lstTasks
            // 
            this.lstTasks.FormattingEnabled = true;
            this.lstTasks.ItemHeight = 20;
            this.lstTasks.Location = new System.Drawing.Point(200, 191);
            this.lstTasks.Margin = new System.Windows.Forms.Padding(4);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(355, 464);
            this.lstTasks.TabIndex = 9;
            // 
            // lstNotes
            // 
            this.lstNotes.FormattingEnabled = true;
            this.lstNotes.ItemHeight = 20;
            this.lstNotes.Location = new System.Drawing.Point(797, 191);
            this.lstNotes.Margin = new System.Windows.Forms.Padding(4);
            this.lstNotes.Name = "lstNotes";
            this.lstNotes.Size = new System.Drawing.Size(355, 464);
            this.lstNotes.TabIndex = 10;
            this.lstNotes.SelectedIndexChanged += new System.EventHandler(this.lstNotes_SelectedIndexChanged);
            // 
            // btnEditTask
            // 
            this.btnEditTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEditTask.Location = new System.Drawing.Point(11, 286);
            this.btnEditTask.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditTask.Name = "btnEditTask";
            this.btnEditTask.Size = new System.Drawing.Size(165, 40);
            this.btnEditTask.TabIndex = 11;
            this.btnEditTask.Text = "Редагувати";
            this.btnEditTask.UseVisualStyleBackColor = true;
            // 
            // btnEditNote
            // 
            this.btnEditNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEditNote.Location = new System.Drawing.Point(601, 286);
            this.btnEditNote.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditNote.Name = "btnEditNote";
            this.btnEditNote.Size = new System.Drawing.Size(182, 40);
            this.btnEditNote.TabIndex = 13;
            this.btnEditNote.Text = "Редагувати";
            this.btnEditNote.UseVisualStyleBackColor = true;
            this.btnEditNote.Click += new System.EventHandler(this.btnEditNote_Click);
            // 
            // tblDaySchedule
            // 
            this.tblDaySchedule.AutoScroll = true;
            this.tblDaySchedule.AutoSize = true;
            this.tblDaySchedule.ColumnCount = 1;
            this.tblDaySchedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDaySchedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDaySchedule.Dock = System.Windows.Forms.DockStyle.Right;
            this.tblDaySchedule.Location = new System.Drawing.Point(1179, 0);
            this.tblDaySchedule.Name = "tblDaySchedule";
            this.tblDaySchedule.RowCount = 24;
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDaySchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDaySchedule.Size = new System.Drawing.Size(0, 738);
            this.tblDaySchedule.TabIndex = 14;
            // 
            // btnSchedule
            // 
            this.btnSchedule.Location = new System.Drawing.Point(937, 12);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(215, 45);
            this.btnSchedule.TabIndex = 15;
            this.btnSchedule.Text = "Відкрити розклад";
            this.btnSchedule.UseVisualStyleBackColor = true;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // DiaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1179, 738);
            this.Controls.Add(this.btnSchedule);
            this.Controls.Add(this.tblDaySchedule);
            this.Controls.Add(this.btnEditNote);
            this.Controls.Add(this.btnEditTask);
            this.Controls.Add(this.lstNotes);
            this.Controls.Add(this.lstTasks);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblTasks);
            this.Controls.Add(this.btnDeleteNote);
            this.Controls.Add(this.btnDeleteTask);
            this.Controls.Add(this.btnOpenCalendar);
            this.Controls.Add(this.btnAddNote);
            this.Controls.Add(this.btnViewTasks);
            this.Controls.Add(this.btnAddTask);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DiaryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Business Diary";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnViewTasks;
        private System.Windows.Forms.Button btnAddNote;
        private System.Windows.Forms.Button btnOpenCalendar;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.Button btnDeleteNote;
        private System.Windows.Forms.Label lblTasks;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.ListBox lstTasks;
        private System.Windows.Forms.ListBox lstNotes;
        private System.Windows.Forms.Button btnEditTask;
        private System.Windows.Forms.Button btnEditNote;
        private System.Windows.Forms.TableLayoutPanel tblDaySchedule;
        private System.Windows.Forms.Button btnSchedule;
    }
}

