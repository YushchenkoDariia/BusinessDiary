using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BusinessDiary
{
    
    public class ScheduleVisualizer
    {
        
        private const int START_HOUR = 8;
        private const int END_HOUR = 22;
        private const int HOUR_HEIGHT = 30;
        private const int HOUR_WIDTH = 120;
        private const int HOUR_LABEL_WIDTH = 50;

        public static readonly Color FREE_COLOR = Color.LightGreen;
        public static readonly Color BUSY_COLOR = Color.LightCoral;
        public static readonly Color CUSTOM_COLOR = Color.LightBlue;
        public static readonly Color BORDER_COLOR = Color.Gray;
        public static readonly Color TEXT_COLOR = Color.Black;

        private Panel schedulePanel;
        private TaskManager taskManager;
        private Dictionary<int, ScheduleSlotState> scheduleState;


        private Dictionary<int, Button> hourButtons;

        
        public enum ScheduleSlotState
        {
            Free,
            Busy,
            Custom
        }

        public ScheduleVisualizer(Panel panel, TaskManager taskMgr)
        {
            schedulePanel = panel;
            taskManager = taskMgr;
            hourButtons = new Dictionary<int, Button>();
            scheduleState = new Dictionary<int, ScheduleSlotState>();

            for (int hour = START_HOUR; hour < END_HOUR; hour++)
            {
                scheduleState[hour] = ScheduleSlotState.Free;
            }

            InitializeScheduleGrid();
        }

        
        private void InitializeScheduleGrid()
        {
            schedulePanel.Controls.Clear();
            hourButtons.Clear();

            
            for (int hour = START_HOUR; hour < END_HOUR; hour++)
            {

                Label hourLabel = new Label
                {
                    Text = $"{hour}:00-{hour + 1}:00",
                    Location = new Point(0, (hour - START_HOUR) * HOUR_HEIGHT),
                    Size = new Size(75, HOUR_HEIGHT), 
                    TextAlign = ContentAlignment.MiddleRight,
                    Font = new Font("Arial", 9)
                };

                schedulePanel.Controls.Add(hourLabel);

                Button hourSlot = new Button
                {
                    Location = new Point(75, (hour - START_HOUR) * HOUR_HEIGHT),
                    Size = new Size(HOUR_WIDTH, HOUR_HEIGHT),
                    BackColor = FREE_COLOR,
                    FlatStyle = FlatStyle.Flat,
                    Tag = hour,
                    Text = "Вільно"
                };

                hourSlot.FlatAppearance.BorderColor = BORDER_COLOR;
                hourSlot.Click += HourSlot_Click;

                schedulePanel.Controls.Add(hourSlot);
                hourButtons[hour] = hourSlot;
            }
        }

       
        private void HourSlot_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;

            int hour = (int)clickedButton.Tag;

           
            if (scheduleState[hour] != ScheduleSlotState.Busy)
            {
                if (scheduleState[hour] == ScheduleSlotState.Free)
                {
                    scheduleState[hour] = ScheduleSlotState.Custom;
                    clickedButton.BackColor = CUSTOM_COLOR;
                    clickedButton.Text = "Вибрано";
                }
                else
                {
                    scheduleState[hour] = ScheduleSlotState.Free;
                    clickedButton.BackColor = FREE_COLOR;
                    clickedButton.Text = "Вільно";
                }
            }
        }

       
        public void UpdateSchedule(DateTime date)
        {
            
            foreach (int hour in scheduleState.Keys.ToList())
            {
                scheduleState[hour] = ScheduleSlotState.Free;
            }

            
            var tasks = taskManager.GetTasksForDate(date);

            
            foreach (var task in tasks)
            {
                
                List<int> hoursToMark = ExtractTimeRangeFromTask(task);

                foreach (int hour in hoursToMark)
                {
                    if (scheduleState.ContainsKey(hour))
                    {
                        scheduleState[hour] = ScheduleSlotState.Busy;
                    }
                }
            }

            UpdateUI();
        }

       
        private void UpdateUI()
        {
            foreach (int hour in scheduleState.Keys)
            {
                if (hourButtons.ContainsKey(hour))
                {
                    Button button = hourButtons[hour];

                    switch (scheduleState[hour])
                    {
                        case ScheduleSlotState.Free:
                            button.BackColor = FREE_COLOR;
                            button.Text = "Вільно";
                            break;
                        case ScheduleSlotState.Busy:
                            button.BackColor = BUSY_COLOR;
                            button.Text = "Зайнято";
                            break;
                        case ScheduleSlotState.Custom:
                            button.BackColor = CUSTOM_COLOR;
                            button.Text = "Вибрано";
                            break;
                    }
                }
            }
        }


        private List<int> ExtractTimeRangeFromTask(string taskText)
        {
            List<int> affectedHours = new List<int>();

            try
            {
                int bracketIndex = taskText.IndexOf('(');
                if (bracketIndex > 0)
                {
                    taskText = taskText.Substring(0, bracketIndex).Trim();
                }

                System.Text.RegularExpressions.Regex rangeRegex =
                    new System.Text.RegularExpressions.Regex(@"(\d{1,2})[:\.](\d{2})\s*-\s*(\d{1,2})[:\.](\d{2})");
                var rangeMatch = rangeRegex.Match(taskText);

                if (rangeMatch.Success && rangeMatch.Groups.Count >= 5)
                {
                    int startHour = int.Parse(rangeMatch.Groups[1].Value);
                    int startMinute = int.Parse(rangeMatch.Groups[2].Value);
                    int endHour = int.Parse(rangeMatch.Groups[3].Value);
                    int endMinute = int.Parse(rangeMatch.Groups[4].Value);

                    for (int hour = startHour; hour < endHour; hour++)
                    {
                        if (hour >= START_HOUR && hour < END_HOUR && !affectedHours.Contains(hour))
                            affectedHours.Add(hour);
                    }

                    if (endMinute > 0 && endHour >= START_HOUR && endHour < END_HOUR && !affectedHours.Contains(endHour))
                        affectedHours.Add(endHour);

                    return affectedHours;
                }

                System.Text.RegularExpressions.Regex singleTimeRegex =
                    new System.Text.RegularExpressions.Regex(@"(\d{1,2})[:\.](\d{2})");
                var singleMatch = singleTimeRegex.Match(taskText);

                if (singleMatch.Success && singleMatch.Groups.Count >= 3)
                {
                    int hour = int.Parse(singleMatch.Groups[1].Value);
                    int minute = int.Parse(singleMatch.Groups[2].Value);

                    if (hour >= START_HOUR && hour < END_HOUR && !affectedHours.Contains(hour))
                        affectedHours.Add(hour);

                    if (minute >= 45 && hour + 1 < END_HOUR && !affectedHours.Contains(hour + 1))
                        affectedHours.Add(hour + 1);
                }

                return affectedHours;
            }
            catch
            {
                return affectedHours;
            }
        }


        public Dictionary<int, ScheduleSlotState> GetScheduleState()
        {
            return new Dictionary<int, ScheduleSlotState>(scheduleState);
        }

        
        public void SetScheduleState(Dictionary<int, ScheduleSlotState> state)
        {
            scheduleState = new Dictionary<int, ScheduleSlotState>(state);
            UpdateUI();
        }

       
        public void ResetCustomSlots()
        {
            foreach (int hour in scheduleState.Keys.ToList())
            {
                if (scheduleState[hour] == ScheduleSlotState.Custom)
                {
                    scheduleState[hour] = ScheduleSlotState.Free;
                }
            }

            UpdateUI();
        }
    }
}