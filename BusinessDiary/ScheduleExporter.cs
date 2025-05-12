using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BusinessDiary
{
    public class ScheduleExporter
    {
        /// експортування розкладу
        public static bool ExportSchedule(Dictionary<int, ScheduleVisualizer.ScheduleSlotState> scheduleState, DateTime date)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Файли розкладу (*.schedule)|*.schedule|Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                    Title = "Експортувати розклад",
                    FileName = $"Розклад_{date.ToString("yyyy-MM-dd")}"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine($"BUSINESS_DIARY_SCHEDULE|{date.ToString("yyyy-MM-dd")}");

                    foreach (KeyValuePair<int, ScheduleVisualizer.ScheduleSlotState> entry in scheduleState)
                    {
                        sb.AppendLine($"{entry.Key}|{(int)entry.Value}");
                    }

                    File.WriteAllText(saveDialog.FileName, sb.ToString());
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка експортування розкладу {ex.Message}", "Помилка експортування",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// імпортування розкладу з файлів
        public static Dictionary<int, ScheduleVisualizer.ScheduleSlotState> ImportSchedule(out DateTime date)
        {
            date = DateTime.Today;
            Dictionary<int, ScheduleVisualizer.ScheduleSlotState> scheduleState =
                new Dictionary<int, ScheduleVisualizer.ScheduleSlotState>();

            try
            {
                OpenFileDialog openDialog = new OpenFileDialog
                {
                    Filter = "Файл розкладу (*.schedule)|*.schedule|Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                    Title = "Імпортувати розклад"
                };

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] lines = File.ReadAllLines(openDialog.FileName);

                    if (lines.Length > 0)
                    {
                        string[] headerParts = lines[0].Split('|');
                        if (headerParts.Length >= 2 && headerParts[0] == "BUSINESS_DIARY_SCHEDULE")
                        {
                            if (DateTime.TryParse(headerParts[1], out DateTime importDate))
                            {
                                date = importDate;
                            }
                        }


                        for (int i = 1; i < lines.Length; i++)
                        {
                            string[] parts = lines[i].Split('|');
                            if (parts.Length >= 2 && int.TryParse(parts[0], out int hour) &&
                                int.TryParse(parts[1], out int stateValue))
                            {
                                scheduleState[hour] = (ScheduleVisualizer.ScheduleSlotState)stateValue;
                            }
                        }
                    }

                    return scheduleState;
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка імпортування розкладу: {ex.Message}", "Помилка імпорту",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
