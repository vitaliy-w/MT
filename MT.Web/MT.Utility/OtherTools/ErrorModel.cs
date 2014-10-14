using System.Collections.Generic;

namespace MT.Utility.OtherTools
{
    public class ErrorModel
    {
        public readonly List<string> ErrorMessagesList = new List<string>();

        public readonly List<string> ErrorKeysList = new List<string>();

        public string Header { get; set; }

        public ErrorModel(string header, List<string> errorMessagesList, List<string> errorKeysList)
        {
            Header = header;
            ErrorMessagesList = errorMessagesList;
            ErrorKeysList = errorKeysList;
        }


    }
}
