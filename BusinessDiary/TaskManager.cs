using System;
using System.Collections.Generic;
using System.Linq;

public class TaskManager
{
    // Словник, який зберігає завдання: ключ – дата, значення – список кортежів (опис, час виконання, час нагадування).
    private Dictionary<DateTime, List<Tuple<string, string, string>>> tasks =
        new Dictionary<DateTime, List<Tuple<string, string, string>>>();
    private Dictionary<DateTime, Dictionary<string, string>> executionTimes;

    /// Додає нове завдання для вказаної дати.
    public void AddTask(DateTime date, string task, string executionTime = null, string reminderTime = null)
    {
        DateTime key = date.Date;
        if (!tasks.ContainsKey(key))
            tasks[key] = new List<Tuple<string, string, string>>();

        tasks[key].Add(Tuple.Create(task, executionTime, reminderTime));
    }

    /// Повертає список завдань для вказаної дати у форматі відображення.
    public List<string> GetTasksForDate(DateTime date)
    {
        List<string> list = new List<string>();
        DateTime key = date.Date;
        if (tasks.ContainsKey(key))
        {
            foreach (var t in tasks[key])
            {
                string display = "";
                if (!string.IsNullOrWhiteSpace(t.Item2))
                    display += t.Item2 + " - ";
                display += t.Item1;
                if (!string.IsNullOrWhiteSpace(t.Item3))
                    display += " (🔔 " + t.Item3 + ")";
                list.Add(display);
            }
        }
        return list;
    }

    /// Повертає всі завдання у вигляді одного рядка (розділяє їх символом нового рядка).
    public string GetAllTasks()
    {
        List<string> allTasks = new List<string>();
        foreach (var kvp in tasks)
        {
            foreach (var t in kvp.Value)
            {
                string display = kvp.Key.ToShortDateString() + ": ";
                if (!string.IsNullOrWhiteSpace(t.Item2))
                    display += t.Item2 + " - ";
                display += t.Item1;
                if (!string.IsNullOrWhiteSpace(t.Item3))
                    display += " (🔔 " + t.Item3 + ")";
                allTasks.Add(display);
            }
        }
        return string.Join("\n", allTasks);
    }


    /// Повертає список завдань (опис), у яких час нагадування збігається з поточним часом, 
    /// при цьому перевіряється лише завдання, заплановані на сьогодні.
    public List<string> GetReminders(string currentTime)
    {
        List<string> reminders = new List<string>();
        DateTime today = DateTime.Today;

        if (tasks.ContainsKey(today))
        {
            foreach (var t in tasks[today])
            {
                if (!string.IsNullOrWhiteSpace(t.Item3) && t.Item3 == currentTime)
                    reminders.Add(t.Item1);
            }
        }
        return reminders;
    }

    /// Редагує завдання для вказаної дати за індексом у списку.
    public void EditTask(DateTime date, int index, string newTask, string newExecutionTime = null, string newReminderTime = null)
    {
        DateTime key = date.Date;
        if (tasks.ContainsKey(key) && index >= 0 && index < tasks[key].Count)
        {
            tasks[key][index] = Tuple.Create(newTask, newExecutionTime, newReminderTime);
        }
    }

    /// Видаляє завдання для заданої дати за індексом.
    public void DeleteTask(DateTime date, int index)
    {
        DateTime key = date.Date;
        if (tasks.ContainsKey(key) && index >= 0 && index < tasks[key].Count)
        {
            tasks[key].RemoveAt(index);
        }
    }
}
