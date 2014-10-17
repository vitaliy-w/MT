using System.Collections.Generic;

namespace MT.Utility.OtherTools
{
    
    /// <summary>
    /// Represents object contains list of errors, keys and header.
    /// </summary>
    public class ErrorModel
    {
        public IList<string> ErrorMessagesList { get; set; }
        public IList<string> ErrorKeysList { get; set; }

        public string Header { get; set; }

        public ErrorModel(string header, List<string> errorMessagesList, List<string> errorKeysList)
        {
            Header = header;
            ErrorMessagesList = errorMessagesList;
            ErrorKeysList = errorKeysList;
        }


    }
}
