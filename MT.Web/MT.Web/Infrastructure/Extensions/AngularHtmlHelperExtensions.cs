using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using MT.ModelEntities.Enums;
using MT.Web.Infrastructure.Extensions.HtmlElementTypes;
using Newtonsoft.Json;

namespace MT.Web.Infrastructure.Extensions
{
    public static class AngularHtmlHelperExtensions
    {
        public static MvcHtmlString TextBoxDirectiveFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null,
            NgModelPathOptions ngModelPathOptions = null, ControlSizesEnum type = ControlSizesEnum.Medium, bool isTextArea = false)
        {
            var attributes = (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            AttributeManager.AddTitleAttribute(attributes);

            string name = ExpressionHelper.GetExpressionText(expression);
            AttributeManager.AddNgModelAttribute(attributes, name, ngModelPathOptions);

            if (isTextArea)
                return htmlHelper.TextAreaFor(expression, attributes);

            return htmlHelper.TextBoxFor(expression, attributes);
        }

        public static MvcHtmlString ButtonDirective(this HtmlHelper htmlHelper, string text, object htmlAttributes = null, NgModelPathOptions ngModelPathOptions = null,
            ButtonTypesEnum type = ButtonTypesEnum.Submit)
        {
            var attributes = (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            if (!attributes.ContainsKey("ng-click"))
                throw new Exception("There is no ng_click attribute passed to ButtonDirective.");

            AttributeManager.AddButtonClassAttribute(attributes, type);

            attributes.Add("value", text);
            attributes.Add("type", "button");
            var builder = new TagBuilder("input");
            builder.MergeAttributes(attributes);
            return MvcHtmlString.Create(builder.ToString());
        }


        /// <summary>
        /// Контрол формує в HTML розмітці елемент DropDownList з заданого типу Enum із заданими параметрами
        /// </summary>
        /// <param name="name">Ім'я контрола</param>
        /// <param name="enumType">Тип Enum з якого потрібно зформувати DropDownList</param>

        public static MvcHtmlString DropDownListDirective(this HtmlHelper htmlHelper, string name, Enum enumType, object htmlAttributes = null, NgModelPathOptions ngModelPathOptions = null)
        {
            var attributes = (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var accessLevelList = new SelectList(Enum.GetNames(enumType.GetType()));
            return htmlHelper.DropDownList(name, accessLevelList, "Access", attributes);
        }

        /// <summary>
        /// Контрол предназначен для показа сообщения пользователю в виде HTML разметки типа div.
        /// Контрол подключает к себе CSS стили из Bootstrap.css и из MT.css и использует перечисление AlertsEnum для определения стилевого оформления.
        ///  </summary>
        /// <param name="text">Текст, который будет выведен пользователю.</param>
        /// <param name="type">Перечисление типа AlertsEnum задающее стилевое оформление сообщения.</param>

        public static MvcHtmlString AlertDirective(this HtmlHelper helper, string text, object htmlAttributes = null, AlertTypesEnum type = AlertTypesEnum.Warning)
        {
            var alertDiv = new TagBuilder("div");
            var attributes = (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            AttributeManager.AddClassAttribute(attributes, type);
            AttributeManager.AddClassAttribute(attributes, "alert alert-box-width");

            alertDiv.InnerHtml = text;
            alertDiv.MergeAttributes(attributes);
            return new MvcHtmlString(alertDiv.ToString());
        }

        public static HtmlString ToJson(this HtmlHelper helper, object obj)
        {
            return new HtmlString(JsonConvert.SerializeObject(obj));
        }

    }



}

