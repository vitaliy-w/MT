using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using MT.Web.Infrastructure.Extensions.HtmlElementTypes;

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
        /// Контрол предназначен для показа сообщения пользователю в виде HTML разметки типа div.
        /// Контрол подключает к себе CSS стили из Bootstrap.css и из MT.css и использует перечисление AlertsEnum для определения стилевого оформления.
        ///  </summary>
        /// <param name="helper"></param>
        /// <param name="text">Текст, который будет выведен пользователю.</param>
        /// <param name="type">Перечисление типа AlertsEnum задающее стилевое оформление сообщения.</param>
        /// <returns></returns>

        public static MvcHtmlString AlertDirective(this HtmlHelper helper, string text, AlertsEnum type = AlertsEnum.Warning)
        {
            var alertDiv = new TagBuilder("div");
            var attributes = (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(null);
            attributes.Add("class", "alert alert-width");
            AttributeManager.AddAlertClassAttribute(attributes, type);

            alertDiv.InnerHtml = text;
            alertDiv.MergeAttributes(attributes);
            return new MvcHtmlString(alertDiv.ToString());
        }
    }
    public enum AlertsEnum
    {
        Succes, Warning, Danger
    }

}