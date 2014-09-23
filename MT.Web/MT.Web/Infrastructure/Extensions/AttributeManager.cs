using System;
using System.Collections.Generic;
using System.Linq;
using MT.Utility;
using MT.Web.Infrastructure.Extensions.HtmlElementTypes;

namespace MT.Web.Infrastructure.Extensions
{
    /// <summary>
    /// Represents the functionality to add default attributes to the html element if an user does not specify them.
    /// </summary>
    public static class AttributeManager
    {
        public static void AddNgModelAttribute(IDictionary<string, object> attributes, string name, NgModelPathOptions ngModelPathOptions)
        {
            if (!attributes.ContainsKey("ng-model"))
            {
                var model = BuildPath(name, ngModelPathOptions);
                attributes.Add("ng-model", model);
            }
        }

        public static void AddTitleAttribute(IDictionary<string, object> attributes)
        {
            if (!attributes.ContainsKey("title") && attributes.ContainsKey("maxlength"))
                attributes["title"] = String.Format("Max lenght is {0}", attributes["maxlength"]);
        }

        public static void AddWidthAttribute(IDictionary<string, object> attributes, ControlSizesEnum type)
        {
            if (!attributes.ContainsKey("width"))
                attributes.Add("width", "");
        }

        public static void AddButtonClassAttribute(IDictionary<string, object> attributes, ButtonTypesEnum type)
        {
            string htmlClass = String.Empty;
            switch (type)
            {
                case ButtonTypesEnum.Submit:
                    htmlClass = "btn btn-success";
                    break;
                case ButtonTypesEnum.Cancel:
                    htmlClass = "btn btn-default";
                    break;
            }

            if (attributes.ContainsKey("class"))
            {
                attributes["class"] += " " + htmlClass;
            }
            else
            {
                attributes["class"] = htmlClass;
            }
        }

        /// <summary>
        /// Метод для добавления css класса для AlertDirective в зависимости от AlertsEnum.
        /// </summary>
        /// <param name="attributes"></param>
        /// <param name="type">Перечисление типа AlertsEnum задающее стилевое оформление сообщения.  </param>

        public static void AddAlertClassAttribute(IDictionary<string, object> attributes, AlertsEnum type)
        {

            string htmlClass = String.Empty;
            switch (type)
            {
                case AlertsEnum.Danger:
                    htmlClass = "alert-danger";
                    break;
                case AlertsEnum.Succes:
                    htmlClass = "alert-success";
                    break;

                case AlertsEnum.Warning:
                    htmlClass = "alert-warning";
                    break;

            }

            if (attributes.ContainsKey("class"))
            {
                attributes["class"] += " " + htmlClass;
            }
            else
            {
                attributes["class"] = htmlClass;
            }

        }

        private static string BuildPath(string name, NgModelPathOptions ngModelPathOptions)
        {
            var jsOpt = ngModelPathOptions ?? new NgModelPathOptions();

            var parts = name.Split('.').Select(s => s.ToCamelCase()).Skip(jsOpt.SkipParts).ToList();

            if (!string.IsNullOrEmpty(jsOpt.Prefix))
                parts.Insert(0, jsOpt.Prefix);

            var path = string.Join(".", parts);
            return path;
        }
    }
}