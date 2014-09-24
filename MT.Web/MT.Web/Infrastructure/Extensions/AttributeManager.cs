using System;
using System.Collections.Generic;
using System.Linq;
using MT.ModelEntities.Enums;
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

        private static string BuildPath(string name, NgModelPathOptions ngModelPathOptions)
        {
            var jsOpt = ngModelPathOptions ?? new NgModelPathOptions();

            var parts = name.Split('.').Select(s => s.ToCamelCase()).Skip(jsOpt.SkipParts).ToList();

            if (!string.IsNullOrEmpty(jsOpt.Prefix))
                parts.Insert(0, jsOpt.Prefix);

            var path = string.Join(".", parts);
            return path;
        }

        /// <summary>
        /// AddClassAttribute метод для безопасного добавления CSS класса к словарю атрибут-значение.
        /// </summary>
        /// <param name="attributes"> Словарь атрибутов CSS елемента.</param>
        /// <param name="cssClass"> Название CSS класса, которое требуется добавить. </param>
        
        public static void AddClassAttribute(IDictionary<string, object> attributes, string cssClass)
        {
            if (attributes.ContainsKey("class"))
            {
                attributes["class"] += " " + cssClass;
            }
            else
            {
                attributes["class"] = cssClass;
            }
        }

        
        /// <summary>
        /// Перегруженный метод AddClassAttribute для добавления CSS класса в зависимости от значения AlertTypesEnum
        /// </summary>
        
        public static void AddClassAttribute(IDictionary<string, object> attributes, AlertTypesEnum type)
        {

            string htmlClass = String.Empty;
            switch (type)
            {
                case AlertTypesEnum.Danger:
                    htmlClass = "alert-danger";
                    break;
                case AlertTypesEnum.Succes:
                    htmlClass = "alert-success";
                    break;

                case AlertTypesEnum.Warning:
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


    }
}