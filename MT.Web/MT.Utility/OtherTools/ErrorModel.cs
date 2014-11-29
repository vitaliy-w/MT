using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using MT.Utility.Json;

namespace MT.Utility.OtherTools
{

    /// <summary>
    /// Represents object contains list of errors, keys and header.
    /// </summary>
    public class ErrorModel
    {
        public ICollection<string> ErrorMessagesList { get; set; }
        public ICollection<string> ErrorKeysList { get; set; }

        private string Header { get; set; }

        public ErrorModel(string header, ICollection<string> errorMessagesList, ICollection<string> errorKeysList)
        {
            Header = header;
            ErrorMessagesList = errorMessagesList;
            ErrorKeysList = errorKeysList;
        }

        public ErrorModel(ICollection<string> errorMessagesList, ICollection<string> errorKeysList)
        {
            Header = "Error";
            ErrorMessagesList = errorMessagesList;
            ErrorKeysList = errorKeysList;
        }

        public ErrorModel(string errorMessage, string errorKey)
        {
            Header = "Error";
            ErrorMessagesList = new List<string>() { errorMessage };
            ErrorKeysList = new List<string>() { errorKey };
        }

        
        
    }
}
