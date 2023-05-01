using CallTracker_Lib;

NoteManager manager = new NoteManager(new List<Note>());

manager.AddNote(new Note("Hello", "This is a test note!"));
manager.AddNote(new Note("Title here", "This is yet another test note!"));
Console.WriteLine(manager.ToString());
Console.WriteLine();

string dbContent = "2756379Hello2756380This is a test note!27563812756379Title here2756380This is yet another test note!2756381";
manager.Parse(dbContent);
List<Note> notes = manager.GetNotes();
foreach (Note note in notes)
{
    Console.WriteLine(note._noteTitle);
    Console.WriteLine(note._noteContent);
}

Console.WriteLine();
Console.WriteLine($"There are {notes.Count} notes.");