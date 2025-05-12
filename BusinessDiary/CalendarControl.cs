using BusinessDiary;
using System;
using System.Windows.Forms;

public class CalendarControl
{
    private DiaryForm mainForm;

    public CalendarControl(DiaryForm form)
    {
        this.mainForm = form;
    }

    public void ShowCalendar()
    {
        using (Form calendarForm = new Form()
        {
            Width = 400,
            Height = 400,
            Text = "Календар"
        })
        {
            MonthCalendar calendar = new MonthCalendar()
            {
                Dock = DockStyle.Fill,
                MaxSelectionCount = 1
            };

            calendar.DateSelected += (sender, e) =>
            {
                DateTime selected = e.Start.Date;
                mainForm.ShowTasksForDate(selected);

                calendarForm.Close();
            };

            calendarForm.Controls.Add(calendar);
            calendarForm.ShowDialog();
        }
    }

}