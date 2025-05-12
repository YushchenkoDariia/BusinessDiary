using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BusinessDiary
{
    public partial class ScheduleForm : Form
    {
        private DiaryForm mainForm;
        private ScheduleVisualizer scheduleVisualizer;
        private ScheduleComparer scheduleComparer;
        private DateTime currentViewDate;
        private List<Dictionary<int, ScheduleVisualizer.ScheduleSlotState>> loadedSchedules;

        public ScheduleForm(DiaryForm main)
        {
            InitializeComponent();

            mainForm = main;
            currentViewDate = DateTime.Today;
            loadedSchedules = new List<Dictionary<int, ScheduleVisualizer.ScheduleSlotState>>();

            scheduleVisualizer = new ScheduleVisualizer(panelSchedule, mainForm.taskManager);
            scheduleComparer = new ScheduleComparer(panelComparison);

            UpdateDateDisplay();
            RefreshSchedule();
        }
        public void RefreshSchedule()
        {
            scheduleVisualizer.UpdateSchedule(currentViewDate);
            lblCurrentSchedule.Text = $"Розклад на {currentViewDate.ToShortDateString()}";
        }

        private void UpdateDateDisplay()
        {
            lblDate.Text = currentViewDate.ToLongDateString();
        }

        private void btnPrevDay_Click(object sender, EventArgs e)
        {
            currentViewDate = currentViewDate.AddDays(-1);
            UpdateDateDisplay();
            RefreshSchedule();
        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
            currentViewDate = currentViewDate.AddDays(1);
            UpdateDateDisplay();
            RefreshSchedule();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            currentViewDate = DateTime.Today;
            UpdateDateDisplay();
            RefreshSchedule();
        }

        private void btnExportSchedule_Click(object sender, EventArgs e)
        {
            var scheduleState = scheduleVisualizer.GetScheduleState();
            bool exported = ScheduleExporter.ExportSchedule(scheduleState, currentViewDate);

            if (exported)
            {
                MessageBox.Show("Розклад успішно експортовано.", "Експорт",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnImportSchedule_Click(object sender, EventArgs e)
        {
            var importedSchedule = ScheduleExporter.ImportSchedule(out DateTime importDate);

            if (importedSchedule != null)
            {
                DialogResult result = MessageBox.Show(
                    $"Бажаєте переглянути імпортований розклад на {importDate.ToShortDateString()}?",
                    "Імпорт розкладу",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    currentViewDate = importDate;
                    UpdateDateDisplay();
                    scheduleVisualizer.SetScheduleState(importedSchedule);
                    lblCurrentSchedule.Text = $"Імпортований розклад на {currentViewDate.ToShortDateString()}";
                }
                else
                {
                    AddScheduleToComparison(importedSchedule, importDate);
                }
            }
        }

        private void btnClearCustom_Click(object sender, EventArgs e)
        {
            scheduleVisualizer.ResetCustomSlots();
        }

        private void btnAddToComparison_Click(object sender, EventArgs e)
        {
            var scheduleState = scheduleVisualizer.GetScheduleState();
            AddScheduleToComparison(scheduleState, currentViewDate);
        }

        private void btnClearComparison_Click(object sender, EventArgs e)
        {
            scheduleComparer.ClearSchedules();
            loadedSchedules.Clear();
            lstLoadedSchedules.Items.Clear();
        }

        private void AddScheduleToComparison(Dictionary<int, ScheduleVisualizer.ScheduleSlotState> schedule, DateTime date)
        {
            loadedSchedules.Add(schedule);
            scheduleComparer.AddSchedule(schedule);
            lstLoadedSchedules.Items.Add($"Розклад на {date.ToShortDateString()}");
        }

        private void btnFindCommonTime_Click(object sender, EventArgs e)
        {
            List<string> commonFreeTimeRanges = scheduleComparer.GetCommonFreeTimeRanges();

            if (commonFreeTimeRanges.Count == 0)
            {
                MessageBox.Show("Спільних вільних проміжків часу не знайдено.", "Пошук вільного часу",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string freeTimeSlots = string.Join("\n", commonFreeTimeRanges);
                MessageBox.Show($"Спільні вільні проміжки часу:\n\n{freeTimeSlots}", "Пошук вільного часу",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    


private void ScheduleForm_Load(object sender, EventArgs e)
        {

        }

        private void panelSchedule_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblLegendTitle_Click(object sender, EventArgs e)
        {

        }

        private void panelSchedule_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}