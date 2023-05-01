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
        public string _noteTitle = string.Empty;
        public string _noteContent = string.Empty;

        /// <summary>
        /// Create a new note with a title and content.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public Note(string title, string content)
        {
            _note = new StringBuilder();
            _noteTitle = title;
            _noteContent = content;
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

            if (_noteTitle.Length > 0)
                _note = _note.Append(NoteManager.TITLE_ID).Append(_noteTitle); //append title seperator and title
            if (_noteContent.Length > 0)
                _note = _note.Append(NoteManager.CONTENT_ID).Append(_noteContent); //append content seperator and content
            _note = _note.Append(NoteManager.SEPERATOR_ID); //append note seperator
        }

        public override string ToString()
        {
            if (_note.Length <= 0)
                Build();

            return _note.ToString();
        }
    }
}
