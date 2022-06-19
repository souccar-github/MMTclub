using Ahc.Club.Attributes;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace CodeGeneratorFront.Builders.Components
{
    public class ElementBuilder
    {
        public static string CreateHtml(PropertyInfo propertyInfo, string name, bool twoColumn)
        {
            if (propertyInfo.PropertyType == typeof(String))
            {
                return GenerateInputText(propertyInfo, name, twoColumn);
            }
            //else if (propertyInfo.PropertyType == typeof(Boolean) || propertyInfo.PropertyType == typeof(Boolean?))
            //{
            //    return GenerateCheck(propertyInfo, name, twoColumn);
            //}
            else if (propertyInfo.PropertyType == typeof(DateTime) || propertyInfo.PropertyType == typeof(DateTime?))
            {
                return GenerateDatepicker(propertyInfo, name, twoColumn);
            }
            else if (
                propertyInfo.PropertyType == typeof(Int32) ||
                propertyInfo.PropertyType == typeof(Int32?) ||
                propertyInfo.PropertyType == typeof(Double) ||
                propertyInfo.PropertyType == typeof(Double?) ||
                propertyInfo.PropertyType == typeof(Decimal) ||
                propertyInfo.PropertyType == typeof(Decimal?) ||
                propertyInfo.PropertyType == typeof(Single) ||
                propertyInfo.PropertyType == typeof(Single?)
                )
            {
                var uiAttr = GetAsmaUiAttributeValues(propertyInfo);
                if (uiAttr != null && (!string.IsNullOrEmpty(uiAttr.IsReference) || !string.IsNullOrEmpty(uiAttr.IsEnum)))
                {
                    return GenerateDropdownlist(propertyInfo, name, twoColumn, uiAttr);
                }
                else
                {
                    return GenerateNumeric(propertyInfo, name, twoColumn);
                }
            }

            return String.Empty;

        }

        #region Html
        private static string GenerateDropdownlist(PropertyInfo propertyInfo, string name, bool twoColumn, AsmaUiAttribute uiAttr)
        {
            string text = "";
            var refType = uiAttr.IsReference;
            var propName = propertyInfo.Name;
            var fileName = twoColumn ? "ejs-dropdownlist-2.html" : "ejs-dropdownlist.html";
            var fullName = AppConst.CodePath + $"\\Widgets\\{fileName}";
            if (File.Exists(fullName))
            {
                text = UpdateFileContent(refType, name, fullName);
            }
            return text;
        }

        private static string GenerateNumeric(PropertyInfo propertyInfo, string name, bool twoColumn)
        {
            string text = "";
            var propName = propertyInfo.Name;
            var fileName = twoColumn ? "ejs-numeric-2.html" : "ejs-numeric.html";
            var fullName = AppConst.CodePath + $"\\Widgets\\{fileName}";
            if (File.Exists(fullName))
            {
                text = UpdateFileContent(propName, name, fullName);
            }
            return text;
        }

        private static string GenerateDatepicker(PropertyInfo propertyInfo, string name, bool twoColumn)
        {
            string text = "";
            var propName = propertyInfo.Name;
            var fileName = twoColumn ? "ejs-datepicker-2.html" : "ejs-datepicker.html";
            var fullName = AppConst.CodePath + $"\\Widgets\\{fileName}";
            if (File.Exists(fullName))
            {
                text = UpdateFileContent(propName, name, fullName);
            }
            return text;
        }

        private static string GenerateInputText(PropertyInfo propertyInfo, string name, bool twoColumn)
        {
            string text = "";
            var propName = propertyInfo.Name;
            var fileName = twoColumn ? "input-2.html" : "input.html";
            var fullName = AppConst.CodePath + $"\\Widgets\\{fileName}";
            if (File.Exists(fullName))
            {
                text = UpdateFileContent(propName, name, fullName);
            }
            return text;
        }

        private static string UpdateFileContent(string propName, string name, string fullName)
        {
            string text = File.ReadAllText(fullName);
            text = text.Replace("fffs", propName.FirstCharToLower().Plural());
            text = text.Replace("Fffs", propName.Plural());
            text = text.Replace("fff", propName.FirstCharToLower());
            text = text.Replace("Fff", propName);
            text = text.Replace("xxx", name);

            return "    " + text;
        }

        public static AsmaUiAttribute GetAsmaUiAttributeValues(PropertyInfo propertyInfo)
        {
            object[] attrs = propertyInfo.GetCustomAttributes(true);
            foreach (object attr in attrs)
            {
                AsmaUiAttribute uiAttr = attr as AsmaUiAttribute;
                if (uiAttr != null)
                {
                    return uiAttr;
                }
            }

            return null;
        }
        #endregion

        #region TS
        public static string CreateFuncTs(PropertyInfo propertyInfo)
        {
            var builder = new StringBuilder();
            var uiAttr = GetAsmaUiAttributeValues(propertyInfo);
            if (uiAttr != null && !string.IsNullOrEmpty(uiAttr.IsReference))
            {
                var refType = uiAttr.IsReference;
                builder.AppendLine("initial" + refType.Plural() + "(){");
                builder.AppendLine($"    this._{refType.FirstCharToLower()}AppService.getAll()");
                builder.AppendLine($"    .subscribe(result => this.{refType.FirstCharToLower().Plural()} = result);");
                builder.AppendLine("}");
            }

            return builder.ToString();
        }
        public static string CreateImportTs(PropertyInfo propertyInfo)
        {
            var uiAttr = GetAsmaUiAttributeValues(propertyInfo);
            if (uiAttr != null && !string.IsNullOrEmpty(uiAttr.IsReference))
            {
                var refType = uiAttr.IsReference;
                if (!string.IsNullOrEmpty(refType))
                    return $" {refType}Dto, {refType}ServiceProxy,";
            }

            return String.Empty;
        }

        public static string CreateDeclareTs(PropertyInfo propertyInfo)
        {
            var uiAttr = GetAsmaUiAttributeValues(propertyInfo);
            var builder = new StringBuilder();
            var name = propertyInfo.Name.FirstCharToLower();
            if (uiAttr != null && !string.IsNullOrEmpty(uiAttr.IsReference))
            {
                var textField = !string.IsNullOrEmpty(uiAttr.RefTextField) ? uiAttr.RefTextField : "name";
                var valurField = !string.IsNullOrEmpty(uiAttr.RefValueField) ? uiAttr.RefValueField : "id";

                var refType = uiAttr.IsReference;
                builder.AppendLine($"{refType.FirstCharToLower().Plural()}: {refType}Dto[] = [];");
                builder.AppendLine("public " + refType.FirstCharToLower() + "Fields: Object = { text: '" + textField + "', value: '" + valurField + "' };");
            }
            else if (uiAttr != null && !string.IsNullOrEmpty(uiAttr.IsEnum))
            {
                builder.AppendLine($"{name.Plural()}: object[] = [];");
                builder.AppendLine("public " + uiAttr.IsEnum.FirstCharToLower() + "Fields: Object = { text: 'name', value: 'id' };");
            }
            else if (uiAttr != null && uiAttr.AutoComplete)
            {
                builder.AppendLine("public " + name + "AutoCompleteFields: Object = { value: 'name' };");
            }

            return builder.ToString();
        }

        public static string CreateCtorTs(PropertyInfo propertyInfo)
        {
            var uiAttr = GetAsmaUiAttributeValues(propertyInfo);
            if (uiAttr != null && !string.IsNullOrEmpty(uiAttr.IsReference))
            {
                var refType = uiAttr.IsReference;
                if (!string.IsNullOrEmpty(refType))
                    return $"private _{refType.FirstCharToLower()}AppService: {refType}ServiceProxy,";
            }

            return String.Empty;
        }

        public static string CreateOnInitTs(PropertyInfo propertyInfo)
        {
            var uiAttr = GetAsmaUiAttributeValues(propertyInfo);
            if (uiAttr != null && !string.IsNullOrEmpty(uiAttr.IsReference))
            {
                var refType = uiAttr.IsReference;
                if (!string.IsNullOrEmpty(refType))
                    return $"this.initial{refType.Plural()}();";
            }

            return String.Empty;
        }
        #endregion
    }
}
