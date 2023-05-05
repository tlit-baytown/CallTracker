using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallTracker_Lib
{
    /// <summary>
    /// Represents a custom Note with a title and rich content.
    /// </summary>
    public class Note
    {
        private static readonly Logger Logger = logging.LogManager<Note>.GetLogger();

        private StringBuilder _note = new StringBuilder();
        public string NoteTitle = string.Empty;
        public string NoteContent = string.Empty;

        /// <summary>
        /// Create a new note with a title and content.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public Note(string title, string content)
        {
            _note = new StringBuilder();
            NoteTitle = title;
            NoteContent = content;
        }

        /// <summary>
        /// Create a new note with content but no title.
        /// </summary>
        /// <param name="title"></param>
        public Note(string content) : this(string.Empty, content) { }

        /// <summary>
        /// Builds the note into a single string with the hex seperators specified in <see cref="NoteManager"/>.
        /// </summary>
        internal void Build()
        {
            _note = new StringBuilder();

            if (NoteTitle.Length > 0)
                _note = _note.Append(NoteManager.TitleId).Append(NoteTitle); //append title seperator and title
            if (NoteContent.Length > 0)
                _note = _note.Append(NoteManager.ContentId).Append(NoteContent); //append content seperator and content
            _note = _note.Append(NoteManager.SeperatorId); //append note seperator
        }

        public override string ToString()
        {
            if (_note.Length <= 0)
                Build();

            return _note.ToString();
        }
    }
}
