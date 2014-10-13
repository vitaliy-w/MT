using System.Collections.Generic;

namespace MT.Utility.OtherTools
{
    public class ErrorModel
    {
        private readonly List<string> _errorMessagesList = new List<string>() { "Model is invalid" };

        private readonly List<string> _errorKeysList = new List<string>() { "Model" };

        public string ErrorMessage { get; set; }

        public string ErrorKey { get; set; }

        public string Header { get; set; }

        public ErrorModel(string header, int errorNumber)
        {
            Header = header;
            ErrorMessage = _errorMessagesList[errorNumber];
            ErrorKey = _errorKeysList[errorNumber];
        }


    }
}
