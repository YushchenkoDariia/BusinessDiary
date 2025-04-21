using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Timers;
using System.Drawing;
using System.Collections.Generic;

namespace BusinessDiary
{
    public partial class MainForm : Form
    {
        public CalendarControl calendar;
        public TaskManager taskManager;
        private System.Timers.Timer reminderTimer;
        public NotesManager notesManager;
        private ScheduleForm scheduleForm;
      

        public DateTime CurrentDate { get; set; } = DateTime.Today;
        // Головний список завдань (для сьогоднішніх завдань)

        public MainForm()
        {

            InitializeComponent();

            calendar = new CalendarControl(this);
            taskManager = new TaskManager();
            notesManager = new NotesManager();

            CurrentDate = DateTime.Today;

            //Створення 
            btnAddTask.Click -= btnAddTask_Click_1;
            btnAddNote.Click += btnAddNote_Click_1;
            btnDeleteNote.Click += btnDeleteNote_Click_1;
            btnViewNotes.Click += btnViewNotes_Click_1;

            btnAddTask.Click += btnAddTask_Click_1;
            btnViewTasks.Click += btnViewTasks_Click_1;
            btnDeleteTask.Click += btnDeleteTask_Click_1;
            btnEditTask.Click += btnEditTask_Click_1;

            btnOpenCalendar.Click += BtnOpenCalendar_Click;



            reminderTimer = new System.Timers.Timer(60000); // Перевірка кожну хвилину
            reminderTimer.Elapsed += CheckReminders;
            reminderTimer.Start();


            lstTasks.DrawMode = DrawMode.OwnerDrawFixed;
            lstTasks.ItemHeight = 30;
            lstTasks.DrawItem += LstTasks_DrawItem;

            lstNotes.DrawMode = DrawMode.OwnerDrawFixed;
            lstNotes.ItemHeight = 30;
            lstNotes.DrawItem += LstNotes_DrawItem;

            RefreshTaskList();
            RefreshNotesList();


        }

        

        private void BtnExport_Click(object sender, EventArgs e)
        {
            // If schedule form doesn't exist, create it first
            if (scheduleForm == null || scheduleForm.IsDisposed)
            {
                scheduleForm = new ScheduleForm(this);
            }

            // Show it and bring it to front
            scheduleForm.Show();
            scheduleForm.BringToFront();
        }
        private void LstTasks_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            string text = lstTasks.Items[e.Index].ToString();

            // Малюємо прозорий фон
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 0, 0)), e.Bounds);

            // Відображення тексту
            TextRenderer.DrawText(
                e.Graphics,
                text,
                e.Font,
                e.Bounds,
                Color.Maroon,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter
            );

            // Лінії як в зошиті
            e.Graphics.DrawLine(Pens.LightBlue, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);

            e.DrawFocusRectangle();
        }

        private void LstNotes_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            string text = lstNotes.Items[e.Index].ToString();

            // Малюємо прозорий фон
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 0, 0)), e.Bounds);

            // Відображення тексту
            TextRenderer.DrawText(
                e.Graphics,
                text,
                e.Font,
                e.Bounds,
                Color.Maroon,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter
            );

            // Лінії як в зошиті
            e.Graphics.DrawLine(Pens.LightBlue, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);

            e.DrawFocusRectangle();
        }
        public void RefreshTaskList()
        {
            lstTasks.Items.Clear();
            var tasksForDate = taskManager.GetTasksForDate(CurrentDate); // ← Повертаємо CurrentDate
            foreach (var task in tasksForDate)
            {
                lstTasks.Items.Add(task);
            }
        }


        private void CheckReminders(object sender, ElapsedEventArgs e)
        {
            string currentTime = DateTime.Now.ToString("hh:mm");
            var reminders = taskManager.GetReminders(currentTime);
            foreach (var reminder in reminders)
            {
                // Виправляємо доступ до UI через Invoke
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show($"Час виконати задачу: {reminder}", "Нагадування", MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            }
        }

        public void PromptAddTaskForDate(DateTime date)
        {
            try
            {
                string task = Interaction.InputBox("Введіть назву справи:", "Нова задача", "");
                if (string.IsNullOrWhiteSpace(task))
                    return;  // User cancelled or entered nothing

                string executionTime = Interaction.InputBox("На котру годину запланувати (формат hh:mm):", "Час виконання", "");

                bool setReminder = MessageBox.Show("Бажаєте встановити нагадування?", "Нагадування",
                                                 MessageBoxButtons.YesNo) == DialogResult.Yes;

                string reminderTime = "";
                if (setReminder)
                {
                    reminderTime = Interaction.InputBox("Введіть час нагадування (формат hh:mm):",
                                                      "Час нагадування", "");
                }

                if (!string.IsNullOrWhiteSpace(task))  // Final validation
                {
                    taskManager.AddTask(date, task, executionTime, reminderTime);
                    RefreshTaskList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при додаванні задачі: {ex.Message}", "Помилка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Показ завдань для дати, що не є сьогодні, із можливістю додати нову задачу
        public void ShowTasksForDate(DateTime date)
        {
            var tasks = taskManager.GetTasksForDate(date);
            string msg = tasks.Count > 0 ? string.Join("\n", tasks) : "Немає завдань на цей день.";

            DialogResult dr = MessageBox.Show(
                "Завдання на " + date.ToShortDateString() + ":\n" + msg +
                "\n\nБажаєте:\n- Додати задачу (Так)\n- Редагувати задачу (Ні)\n- Вийти (Скасувати)",
                "Завдання на дату",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                PromptAddTaskForDate(date);
            }
            else if (dr == DialogResult.No && tasks.Count > 0)
            {
                // Редагування задачі
                string inputIndex = Interaction.InputBox("Введіть номер завдання для його редагування:", "Редагувати завдання", "1");
                if (int.TryParse(inputIndex, out int index) && index > 0 && index <= tasks.Count)
                {
                    string newTask = Interaction.InputBox("Редагуйте завдання:", "Редагування", tasks[index - 1]);
                    if (!string.IsNullOrWhiteSpace(newTask))
                    {
                        string newExecutionTime = Interaction.InputBox("На котру годину запланувати (формат hh:mm):", "Час виконання", "");
                        string newReminderTime = Interaction.InputBox("Введіть час нагадування (формат hh:mm):", "Час нагадування", "");
                        taskManager.EditTask(date, index - 1, newTask, newExecutionTime, newReminderTime);
                    }
                }
            }
        }


        private void btnAddTask_Click_1(object sender, EventArgs e)
        {
            btnAddTask.Enabled = false;  // Disable button during operation
            try
            {
                PromptAddTaskForDate(DateTime.Today); // ← Додаємо до сьогоднішньої дати
            }
            finally
            {
                btnAddTask.Enabled = true;
            }

        }

        private void btnViewTasks_Click_1(object sender, EventArgs e)
        {
            string tasks = taskManager.GetAllTasks();
            MessageBox.Show(tasks, "Список всіх завдань");

        }

        private void btnDeleteTask_Click_1(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex >= 0)
            {
                int index = lstTasks.SelectedIndex;
                taskManager.DeleteTask(CurrentDate, index);
                RefreshTaskList();
            }
        }

        private void btnEditTask_Click_1(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex >= 0)
            {
                int index = lstTasks.SelectedIndex;
                string newTask = Interaction.InputBox("Редагуйте завдання:", "Редагування", lstTasks.SelectedItem.ToString());
                if (!string.IsNullOrWhiteSpace(newTask))
                {
                    string newExecutionTime = Interaction.InputBox("На котру годину запланувати (формат HH:mm):", "Час виконання", "");
                    bool setReminder = MessageBox.Show("Бажаєте встановити нагадування?", "Нагадування", MessageBoxButtons.YesNo) == DialogResult.Yes;
                    string newReminderTime = "";
                    if (setReminder)
                        newReminderTime = Interaction.InputBox("Введіть час нагадування (формат HH:mm):", "Час нагадування", "");

                    taskManager.EditTask(CurrentDate, index, newTask, newExecutionTime, newReminderTime);
                    RefreshTaskList();
                }
            }
        }

        private void btnMoveTask_Click_1(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex > 0)
            {
                int index = lstTasks.SelectedIndex;
                var item = lstTasks.Items[index];
                lstTasks.Items.RemoveAt(index);
                lstTasks.Items.Insert(index - 1, item);
                lstTasks.SelectedIndex = index - 1;
            }

        }

        private void BtnOpenCalendar_Click(object sender, EventArgs e)
        {
            calendar.ShowCalendar();

        }

        private void RefreshNotesList()
        {
            lstNotes.Items.Clear();
            foreach (var note in notesManager.GetRawNotes()) // новий метод, див. нижче
            {
                lstNotes.Items.Add(note); // додаємо сам об'єкт Note
            }
        }



        private void btnAddNote_Click_1(object sender, EventArgs e)
        {
            string noteContent = Interaction.InputBox("Введіть текст нотатки:", "Нова нотатка", "");
            if (!string.IsNullOrWhiteSpace(noteContent))
            {

                string noteTime = Interaction.InputBox("Задайте час виконання (формат HH:mm):", "Час запису", "");

                bool setReminder = MessageBox.Show("Бажаєте встановити нагадування?", "Нагадування", MessageBoxButtons.YesNo) == DialogResult.Yes;
                string reminderTime = "";
                if (setReminder)
                {
                    reminderTime = Interaction.InputBox("Введіть час нагадування (формат HH:mm):", "Час нагадування", "");
                }

                notesManager.AddNote(noteContent, noteTime, reminderTime);
                RefreshNotesList();
            }
        }


        private void btnDeleteNote_Click_1(object sender, EventArgs e)
        {
            if (lstNotes.SelectedItem is Note selectedNote)
            {
                notesManager.DeleteNote(selectedNote); // ✅ передаємо сам об'єкт Note
                RefreshNotesList();
            }
        }


        private void btnEditNote_Click(object sender, EventArgs e)
        {
            if (lstNotes.SelectedItem is Note selectedNote)
            {
                string newContent = Interaction.InputBox("Редагуйте текст нотатки:", "Редагування", selectedNote.Content);
                if (!string.IsNullOrWhiteSpace(newContent))
                {
                    string newTime = Interaction.InputBox("Задайте новий час (формат HH:mm):", "Час запису", selectedNote.Time);
                    string newReminderTime = Interaction.InputBox("Введіть новий час нагадування (формат HH:mm):", "Час нагадування", selectedNote.ReminderTime);

                    selectedNote.Content = newContent;
                    selectedNote.Time = newTime;
                    selectedNote.ReminderTime = newReminderTime;

                    RefreshNotesList();
                }
            }
        }

        private void btnViewNotes_Click_1(object sender, EventArgs e)
        {
            string allNotes = notesManager.GetAllNotes();
            if (!string.IsNullOrWhiteSpace(allNotes))
            {
                MessageBox.Show(allNotes, "Список нотаток", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Немає жодної нотатки.", "Список нотаток", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void lstNotes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblNotes_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteNote_Click(object sender, EventArgs e)
        {

        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            // Check if form already exists, create if not
            if (scheduleForm == null || scheduleForm.IsDisposed)
            {
                scheduleForm = new ScheduleForm(this);
            }

            // Show the form
            scheduleForm.Show();
            scheduleForm.BringToFront();
        }

        private void BtnExportSchedule_Click(object sender, EventArgs e)
        {
            // If schedule form doesn't exist, create it first
            if (scheduleForm == null || scheduleForm.IsDisposed)
            {
                scheduleForm = new ScheduleForm(this);
            }

            // Show it and bring it to front
            scheduleForm.Show();
            scheduleForm.BringToFront();
        }
    }
}

