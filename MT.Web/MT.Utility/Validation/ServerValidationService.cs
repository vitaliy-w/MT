using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MT.Utility.Json;
using MT.Utility.OtherTools;

namespace MT.Utility.Validation
{
    public class ServerValidationService
    {
        /// <summary>
        /// Creates ErrorModel in JSon format from modelState.
        /// </summary>

        public static string CreateErrorModelViaModelState(IEnumerable<KeyValuePair<string, System.Web.Mvc.ModelState>> modelState)
        {
            var modelIsInvalidError = new ErrorModel(new List<string>(), new List<string>());

            foreach (var item in modelState)
            {
                foreach (var error in item.Value.Errors)
                {
                    modelIsInvalidError.ErrorKeysList.Add(item.Key);
                    modelIsInvalidError.ErrorMessagesList.Add(error.ErrorMessage);
                }
            }

            return modelIsInvalidError.ToJson();
        }
    }
}
