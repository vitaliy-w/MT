using System.Collections.Generic;

namespace MT.Utility.OtherTools
{
    
    /// <summary>
    /// Represents object contains list of errors, keys and header.
    /// </summary>
    public class ErrorModel
    {
        public ICollection<string> ErrorMessagesList { get; set; }
        public ICollection<string> ErrorKeysList { get; set; }

        public string Header { get; set; }

        public ErrorModel(string header, ICollection<string> errorMessagesList, ICollection<string> errorKeysList)
        {
            Header = header;
            ErrorMessagesList = errorMessagesList;
            ErrorKeysList = errorKeysList;
        }


    }
}
