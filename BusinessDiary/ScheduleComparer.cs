using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BusinessDiary
{
    public class ScheduleComparer
    {
        private const int START_HOUR = 8;
        private const int END_HOUR = 22;
        private const int HOUR_HEIGHT = 30;
        private const int HOUR_WIDTH = 120;
        private const int HOUR_LABEL_WIDTH = 70; 

        public static readonly Color MATCHING_FREE_COLOR = Color.LightGreen;
        public static readonly Color NOT_MATCHING_COLOR = Color.LightCoral;
        public static readonly Color BORDER_COLOR = Color.Gray;

        private Panel comparisonPanel;
        private List<Dictionary<int, ScheduleVisualizer.ScheduleSlotState>> schedulesToCompare;
        private Dictionary<int, Label> resultLabels;

        
        public ScheduleComparer(Panel panel, ScheduleVisualizer visualizer = null)
        {
            comparisonPanel = panel;
            schedulesToCompare = new List<Dictionary<int, ScheduleVisualizer.ScheduleSlotState>>();
            resultLabels = new Dictionary<int, Label>();

            InitializeComparisonGrid();
        }

        private void InitializeComparisonGrid()
        {
            comparisonPanel.Controls.Clear();
            resultLabels.Clear();

            Label headerLabel = new Label
            {
                Text = "Спільні вільні проміжки часу",
                Location = new Point(0, 0),
                Size = new Size(HOUR_LABEL_WIDTH + HOUR_WIDTH + 5, 25),
                Font = new Font("Arial", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            comparisonPanel.Controls.Add(headerLabel);

            for (int hour = START_HOUR; hour < END_HOUR; hour++)
            {
                Label hourLabel = new Label
                {
                    Text = $"{hour}:00-{hour + 1}:00",
                    Location = new Point(0, 30 + (hour - START_HOUR) * HOUR_HEIGHT),
                    Size = new Size(75, HOUR_HEIGHT),                
                    TextAlign = ContentAlignment.MiddleRight,
                    Font = new Font("Arial", 9)
                };

                comparisonPanel.Controls.Add(hourLabel);

                Label resultLabel = new Label
                {
                    Location = new Point(HOUR_LABEL_WIDTH + 5, 25 + (hour - START_HOUR) * HOUR_HEIGHT),
                    Size = new Size(HOUR_WIDTH, HOUR_HEIGHT),
                    BackColor = MATCHING_FREE_COLOR,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle,
                    Text = "Немає розкладів для порівняння"
                };

                comparisonPanel.Controls.Add(resultLabel);
                resultLabels[hour] = resultLabel;
            }
        }

        public void AddSchedule(Dictionary<int, ScheduleVisualizer.ScheduleSlotState> schedule, Dictionary<int, int> halfHourStates = null)
        {
            schedulesToCompare.Add(new Dictionary<int, ScheduleVisualizer.ScheduleSlotState>(schedule));
            UpdateComparison();
        }

        public void ClearSchedules()
        {
            schedulesToCompare.Clear();
            UpdateComparison();
        }

        private void UpdateComparison()
        {
            if (schedulesToCompare.Count == 0)
            {
                foreach (int hour in resultLabels.Keys)
                {
                    resultLabels[hour].BackColor = MATCHING_FREE_COLOR;
                    resultLabels[hour].Text = "Немає розкладів для порівняння";
                }
                return;
            }

            for (int hour = START_HOUR; hour < END_HOUR; hour++)
            {
                bool isCommonFree = true;
                int busyCount = 0;

                foreach (var schedule in schedulesToCompare)
                {
                    if (schedule.ContainsKey(hour))
                    {
                        if (schedule[hour] != ScheduleVisualizer.ScheduleSlotState.Free)
                        {
                            isCommonFree = false;
                            busyCount++;
                        }
                    }
                }

                if (resultLabels.ContainsKey(hour))
                {
                    if (isCommonFree)
                    {
                        resultLabels[hour].BackColor = MATCHING_FREE_COLOR;
                        resultLabels[hour].Text = "Вільний у всіх розкладах";
                    }
                    else
                    {
                        resultLabels[hour].BackColor = NOT_MATCHING_COLOR;
                        resultLabels[hour].Text = $"Зайнятий у {busyCount} з {schedulesToCompare.Count} розкладів";
                    }
                }
            }
        }

        public List<int> GetCommonFreeHours()
        {
            List<int> commonFreeHours = new List<int>();

            if (schedulesToCompare.Count == 0)
            {
                return commonFreeHours;
            }

            for (int hour = START_HOUR; hour < END_HOUR; hour++)
            {
                bool isCommonFree = true;

                foreach (var schedule in schedulesToCompare)
                {
                    if (schedule.ContainsKey(hour))
                    {
                        if (schedule[hour] != ScheduleVisualizer.ScheduleSlotState.Free)
                        {
                            isCommonFree = false;
                            break;
                        }
                    }
                }

                if (isCommonFree)
                {
                    commonFreeHours.Add(hour);
                }
            }

            return commonFreeHours;
        }

        public List<string> GetCommonFreeTimeRanges()
        {
            List<string> timeRanges = new List<string>();
            List<int> freeHours = GetCommonFreeHours();

            if (freeHours.Count == 0)
            {
                return timeRanges;
            }

            int rangeStart = freeHours[0];
            int rangeEnd = rangeStart;

            for (int i = 1; i < freeHours.Count; i++)
            {
                if (freeHours[i] == rangeEnd + 1)
                {
                    rangeEnd = freeHours[i];
                }
                else
                {
                    timeRanges.Add(FormatTimeRange(rangeStart, rangeEnd));

                    rangeStart = freeHours[i];
                    rangeEnd = rangeStart;
                }
            }

            timeRanges.Add(FormatTimeRange(rangeStart, rangeEnd));

            return timeRanges;
        }

        private string FormatTimeRange(int startHour, int endHour)
        {
            if (startHour == endHour)
            {
                return $"{startHour}:00-{startHour + 1}:00"; 
            }
            else
            {
                return $"{startHour}:00-{endHour + 1}:00";
            }
        }
    }
}