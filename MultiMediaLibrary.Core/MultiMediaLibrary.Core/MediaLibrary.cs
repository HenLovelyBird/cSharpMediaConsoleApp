using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MultiMediaLibrary.Core.MediaLibrary
{
    class MediaLibrary
    {
        #region Fields

        public string Title;
        public int Year;
        public bool Rented;

        #endregion Fields
    }

    {
        /// <summary>
        /// The Array where all our multimedia items are stored
        /// </summary>
        private MultimediaItem[] _mediaDatabase;

    /// <summary>
    /// This is the constructor, called when somebody writes "new MediaDatabase(path)"
    /// </summary>
    public MediaDatabase(string databasePath)
    {
        // Read file contents (as an entire string)
        string fileContent = LoadDatabaseFromDisk(databasePath);

        // Split the string it into single lines
        string[] records = fileContent.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

        // Create empty array
        _mediaDatabase = new MultimediaItem[records.Length];

        // Create each record, one per line that exist on the file
        for (int i = 0; i < records.Length; i++)
            _mediaDatabase[i] = MultimediaItem.ParseMultimediaItem(records[i]);
    }

    public IEnumerable<MultimediaItem> GetElements(string type, string sortingProperty)
    {
        // Converts letter pressed by the user into the name of the class: "a" => "Album"
        type = type.ToLower();
        switch (type)
        {
            case "a": case "album": type = "Album"; break;
            case "m": case "movie": type = "Movie"; break;
            case "b": case "book": type = "Book"; break;
            case "v": case "videogame": type = "Videogame"; break;

            default: return null;
        }


        var result = from media in _mediaDatabase                   // Look at the elements in our _mediaDatabase array...
                     where media.GetType().Name == type             // ...take only the ones whose type is the same we want (IE: "a" => "Album" => take only Album instances)...
                     orderby media.GetProperty(sortingProperty)     // ...and sort them by the property the user has specified
                     select media;

        return result;
    }


    private string LoadDatabaseFromDisk(string databasePath)
    {
        // Utility method provided in System.IO namespace: it does all the work of opening a file stream, reading it and closing it.. in a single line
        return File.ReadAllText(databasePath);
    }
}




    


