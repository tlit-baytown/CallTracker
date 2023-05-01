using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallTracker_Lib
{
    /// <summary>
    /// Manager class responsible for maininting a list of <see cref="Note"/> objects, creating a storable
    /// string, and parsing the string from the database into a list of <see cref="Note"/> objects.
    /// </summary>
    public class NoteManager
    {
        private static readonly Logger Logger = logging.LogManager<NoteManager>.GetLogger();

        /// <summary>
        /// Random hex identifier to mark start of note title.
        /// </summary>
        internal static readonly int TITLE_ID = 0x2A0F1B;

        /// <summary>
        /// Random hex identifier to mark start of note content.
        /// </summary>
        internal static readonly int CONTENT_ID = 0x2A0F1C;

        /// <summary>
        /// Random hex identified to mark the seperation between notes.
        /// </summary>
        internal static readonly int SEPERATOR_ID = 0x2A0F1D;

        private List<Note> _notes = new List<Note>();

        public NoteManager(List<Note> notes) { _notes = notes; }

        /// <summary>
        /// Create a new NoteManager object and parse the given string into a list of Note objects.
        /// </summary>
        /// <param name="dbContent">The string stored in the database.</param>
        public NoteManager(string dbContent)
        {
            _notes = new List<Note>();
            Parse(dbContent);
        }

        /// <summary>
        /// Add a single note to the Notes list.
        /// </summary>
        /// <param name="n">The note to add.</param>
        public void AddNote(Note n) { _notes.Add(n); }

        /// <summary>
        /// Remove, if it exists, a single note from the Notes list.
        /// </summary>
        /// <param name="n">The note to remove.</param>
        public void RemoveNote(Note n)
        {
            if (_notes.Contains(n))
                _notes.Remove(n);
        }

        /// <summary>
        /// Get the list of notes contained in this manager.
        /// </summary>
        /// <returns></returns>
        public List<Note> GetNotes()
        {
            return _notes;
        }

        /// <summary>
        /// Get the string needed for storing the list of notes in the database.
        /// </summary>
        /// <returns>A storable string representing this list of notes.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Note n in _notes)
                sb = sb.Append(n.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// Parses the notes from the single database string.
        /// </summary>
        /// <param name="dbContent">The string stored in the database.</param>
        public void Parse(string dbContent)
        {
            _notes.Clear();
            string[] unparsedNotes = dbContent.Split(SEPERATOR_ID.ToString(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string uNote in unparsedNotes)
            {
                string title = string.Empty;
                string content = string.Empty;

                if (uNote.StartsWith(TITLE_ID.ToString()))
                {
                    title = uNote.Remove(0, TITLE_ID.ToString().Length);
                    if (title.Contains(CONTENT_ID.ToString()))
                        title = title[..title.IndexOf(CONTENT_ID.ToString())];
                    else
                        title = title[..title.IndexOf(SEPERATOR_ID.ToString())];
                }
                if (uNote.Contains(CONTENT_ID.ToString()))
                {
                    content = uNote[uNote.IndexOf(CONTENT_ID.ToString())..];
                    content = content.Remove(content.IndexOf(CONTENT_ID.ToString()), CONTENT_ID.ToString().Length);
                }

                AddNote(new Note(title, content));
            }
        }

    }
}
