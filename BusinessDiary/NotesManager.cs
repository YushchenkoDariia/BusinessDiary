using System.Collections.Generic;
using System;
using System.Linq;

public class Note
{
    public string Content { get; set; }
    public string Time { get; set; }
    public string ReminderTime { get; set; }

    public override string ToString()
    {
        return $"{Content} (🕒 {Time}, 🔔 {ReminderTime})";
    }

}


public class NotesManager
{
    private List<Note> notes = new List<Note>();

    public void AddNote(string content, string noteTime = null, string reminderTime = null)
    {
        notes.Add(new Note
        {
            Content = content,
            Time = noteTime,
            ReminderTime = reminderTime
        });
    }

    public void DeleteNote(Note noteToRemove)
    {
        notes.Remove(noteToRemove);
    }

    public string GetAllNotes()
    {
        return string.Join("\n", notes);
    }
    public List<Note> GetRawNotes()
    {
        return notes;
    }

    public void EditNote(string oldNoteString, string newContent, string newTime, string newReminderTime)
    {
        var existingNote = notes.FirstOrDefault(note => note.ToString() == oldNoteString);
        if (existingNote != null)
        {
            existingNote.Content = newContent;
            if (!string.IsNullOrWhiteSpace(newTime))
                existingNote.Time = newTime;
            if (!string.IsNullOrWhiteSpace(newReminderTime))
                existingNote.ReminderTime = newReminderTime;
        }
    }


    public List<string> GetNotesList()
    {
        return notes.Select(note => note.ToString()).ToList();
    }
}
