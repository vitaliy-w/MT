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
            NgModelPathOptions ngModelPathOptions = null, ControlSizesEnum type = ControlSizesEnum.Medium,
            bool isTextArea = false)
        {
            var attributes = (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            AttributeManager.AddTitleAttribute(attributes);

            string name = ExpressionHelper.GetExpressionText(expression);
            AttributeManager.AddNgModelAttribute(attributes, name, ngModelPathOptions);

            if (isTextArea)
                return htmlHelper.TextAreaFor(expression, attributes);

            return htmlHelper.TextBoxFor(expression, attributes);
        }

        public static MvcHtmlString ButtonDirective(this HtmlHelper htmlHelper, string text, object htmlAttributes = null, 
            NgModelPathOptions ngModelPathOptions = null, ButtonTypesEnum type = ButtonTypesEnum.Submit)
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

        public static MvcHtmlString DropDownListDirective(this HtmlHelper htmlHelper, string name, Enum enumType, 
            object htmlAttributes = null, NgModelPathOptions ngModelPathOptions = null)
        {
            var attributes = (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var accessLevelList = new SelectList(Enum.GetNames(enumType.GetType()));
            return htmlHelper.DropDownList(name, accessLevelList, "Access", attributes);
        }

        /// <summary>
        /// Перегруженный метод DropDownListDirective. Принимает имя, которые должно показываться пользователю при инициализации списка.
        /// Но, вместо этого, показывает только enum и пустое место. Нужно гармонизировать обе версии метода. Один сделать для отображения только enum.
        /// Второй, для отображения enum и дополнительного сообщения.
        /// </summary>
        /// <param name="dispalyName"></param>
        public static MvcHtmlString DropDownListDirective(this HtmlHelper htmlHelper, string name, Enum enumType, string dispalyName, object htmlAttributes = null, NgModelPathOptions ngModelPathOptions = null)
        {
            var attributes = (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var listOfOptions = new SelectList(Enum.GetNames(enumType.GetType()));
            return htmlHelper.DropDownList(name, listOfOptions, dispalyName, attributes);
        }

        /// <summary>
        /// Контрол предназначен для показа сообщения пользователю в виде HTML разметки типа div.
        /// Контрол подключает к себе CSS стили из Bootstrap.css и из MT.css и использует перечисление AlertsEnum для определения стилевого оформления.
        ///  </summary>
        /// <param name="text">Текст, который будет выведен пользователю.</param>
        /// <param name="type">Перечисление типа AlertsEnum задающее стилевое оформление сообщения.</param>

        public static MvcHtmlString AlertDirective(this HtmlHelper helper, string text, object htmlAttributes = null,
            AlertTypesEnum type = AlertTypesEnum.Warning)
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


        public static MvcHtmlString TagsInputDirectiveFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null, NgModelPathOptions ngModelPathOptions = null)
        {
            return DirectiveFor(htmlHelper, expression, "mt-tags-input", htmlAttributes, ngModelPathOptions);
        }

        public static MvcHtmlString DirectiveFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TProperty>> expression, string directiveName, object htmlAttributes = null, 
            NgModelPathOptions ngModelPathOptions = null, string tagName = "div")
        {
            var attributes = (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            string name = ExpressionHelper.GetExpressionText(expression);
            string containerName = String.Format("{0}.{1}", directiveName, name);

            AttributeManager.AddNgModelAttribute(attributes, name, ngModelPathOptions);

            var tagBuilder = new TagBuilder(tagName);
            tagBuilder.MergeAttribute(directiveName, "");
            tagBuilder.MergeAttribute("name", containerName);
            tagBuilder.MergeAttributes(attributes);

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            tagBuilder.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(containerName, metadata));

            return MvcHtmlString.Create(tagBuilder.ToString());
        }

        /// <summary>
        /// Creates links accepting parametrs and css-class
        /// </summary>
        public static HtmlString ActionLinkDirective(this HtmlHelper helper, string text, string action = "index", string controller = "home", string area = null, object htmlAttributes = null, string css_class = null)
        {
            var link = new TagBuilder("a") { InnerHtml = text };
            if (!String.IsNullOrEmpty(css_class)) link.AddCssClass(css_class);
            var attributes = (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            if (!attributes.ContainsKey("href")) { attributes.Add("href", !String.IsNullOrEmpty(area) ? String.Format(@"/{0}/{1}/{2}", area, controller, action) : String.Format(@"/{0}/{1}", controller, action)); }
            link.MergeAttributes(attributes);

            return new MvcHtmlString(link.ToString());
        }


        public static MvcHtmlString LabelForDirective<TModel, TValue>(this HtmlHelper<TModel> helper,Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            return helper.LabelFor(expression, htmlAttributes);
        }
        

    }



}

