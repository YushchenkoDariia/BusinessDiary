using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BusinessDiary
{
    /// <summary>
    /// Class responsible for exporting and importing schedule data
    /// </summary>
    public class ScheduleExporter
    {
        /// <summary>
        /// Exports the schedule state to a file
        /// </summary>
        public static bool ExportSchedule(Dictionary<int, ScheduleVisualizer.ScheduleSlotState> scheduleState, DateTime date)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Schedule Files (*.schedule)|*.schedule|Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                    Title = "Export Schedule",
                    FileName = $"Schedule_{date.ToString("yyyy-MM-dd")}"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder sb = new StringBuilder();

                    // Write header with date
                    sb.AppendLine($"BUSINESS_DIARY_SCHEDULE|{date.ToString("yyyy-MM-dd")}");

                    // Write each hour's state
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
                MessageBox.Show($"Error exporting schedule: {ex.Message}", "Export Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Imports a schedule state from a file
        /// </summary>
        public static Dictionary<int, ScheduleVisualizer.ScheduleSlotState> ImportSchedule(out DateTime date)
        {
            date = DateTime.Today;
            Dictionary<int, ScheduleVisualizer.ScheduleSlotState> scheduleState =
                new Dictionary<int, ScheduleVisualizer.ScheduleSlotState>();

            try
            {
                OpenFileDialog openDialog = new OpenFileDialog
                {
                    Filter = "Schedule Files (*.schedule)|*.schedule|Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                    Title = "Import Schedule"
                };

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] lines = File.ReadAllLines(openDialog.FileName);

                    if (lines.Length > 0)
                    {
                        // Parse header
                        string[] headerParts = lines[0].Split('|');
                        if (headerParts.Length >= 2 && headerParts[0] == "BUSINESS_DIARY_SCHEDULE")
                        {
                            if (DateTime.TryParse(headerParts[1], out DateTime importDate))
                            {
                                date = importDate;
                            }
                        }

                        // Parse schedule data
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
                MessageBox.Show($"Error importing schedule: {ex.Message}", "Import Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
