using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace CodeGeneratorFront.Builders.Components
{
    public class ComponentBuilder
    {
        private readonly string _entityName;
        private readonly string _entityNamePlurel;
        private readonly string _name;
        private readonly string _namePlurel;
        private readonly string _moduleName;
        private readonly string _moduleDir;
        private Type _createDtoType;
        private Type _readDtoType;
        private Type _updateDtoType;
        public ComponentBuilder(
            Type readDtoType,
            Type createDtoType,
            Type updateDtoType,
            string name,
            string moduleName)
        {
            _readDtoType = readDtoType;
            _createDtoType = createDtoType;
            _updateDtoType = updateDtoType;
            _name = name;
            _namePlurel = _name.Plural();
            _entityName = name.FirstCharToUpper();
            _entityNamePlurel = _entityName.Plural();

            //Module
            _moduleName = moduleName;
            _moduleDir = AppConst.FrontPath + $"\\{_moduleName}";
            ModuleBuilder.CreateIfNotExist(moduleName, _moduleDir);
        }

        public void Create()
        {
            var componentDir = _moduleDir + $"\\{_name}";
            if (!Directory.Exists(componentDir))
            {
                Console.WriteLine("Create Directory: " + componentDir);
                Console.WriteLine("Create Directory: " + componentDir + $"\\create-{_name}");
                Console.WriteLine("Create Directory: " + componentDir + $"\\edit-{_name}");

                Directory.CreateDirectory(componentDir);
                Directory.CreateDirectory(componentDir + $"\\create-{_name}");
                Directory.CreateDirectory(componentDir + $"\\edit-{_name}");
            }
            GenerateListStyleFile();
            GenerateListHtmlFile();
            GenerateListTsFile();

            GenerateCreateStyleFile();
            GenerateCreateTsFile();
            GenerateCreateHtmlFile();

            GenerateEditStyleFile();
            GenerateEditTsFile();
            GenerateEditHtmlFile();

            AddToRoutingModule();
            AddToModule();
        }

        #region Create Component
        private void GenerateCreateHtmlFile()
        {
            var fullName = _moduleDir + $"\\{_name}" + $"\\create-{_name}" + $"\\create-{_name}-dialog.component.html";
            if (!Directory.Exists(fullName))
            {
                var path = AppConst.CodePath + "\\xxx\\create-xxx\\create-xxx-dialog.component.html";
                string text = File.ReadAllText(path);
                text = text.Replace("Xxxs", _name.FirstCharToUpper().Plural());
                text = text.Replace("xxxs", _name.Plural());
                text = text.Replace("xxx", _name);
                text = text.Replace("Xxx", _name.FirstCharToUpper());

                //Element
                var spaces = GetSpaces(text, "<!--element endTag-->");
                var builder = new StringBuilder();
                var properties = _createDtoType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(prop => prop.Name.ToLower() != "id");
                var twoColumn = properties.Count() > 5;
                foreach (var propertyInfo in properties)
                {
                    builder.AppendLine(ElementBuilder.CreateHtml(propertyInfo, _name, twoColumn));
                }

                text = text.Replace("<!--element endTag-->", builder.ToString());

                var file = File.Create(fullName);
                file.Close();
                Console.WriteLine("Create File: " + fullName);
                Thread.Sleep(50);
                File.WriteAllText(fullName, text);
            }
        }
        private void GenerateCreateTsFile()
        {
            var fullName = _moduleDir + $"\\{_name}" + $"\\create-{_name}" + $"\\create-{_name}-dialog.component.ts";
            if (!Directory.Exists(fullName))
            {
                var path = AppConst.CodePath + "\\xxx\\create-xxx\\create-xxx-dialog.component.ts";
                string text = File.ReadAllText(path);
                text = text.Replace("Xxxs", _name.FirstCharToUpper().Plural());
                text = text.Replace("xxxs", _name.Plural());
                text = text.Replace("xxx", _name);
                text = text.Replace("Xxx", _name.FirstCharToUpper());

                var properties = _createDtoType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(prop => prop.Name.ToLower() != "id");

                //Import
                var importBuilder = new StringBuilder();
                foreach (var propertyInfo in properties)
                {
                    importBuilder.AppendLine(ElementBuilder.CreateImportTs(propertyInfo));
                }
                var str = importBuilder.ToString().Substring(0, importBuilder.ToString().Length - 1);
                if (!string.IsNullOrEmpty(str))
                {
                    text = text.Replace("//import proxy endTag", "," + str);
                }

                //Declaration
                var declareBuilder = new StringBuilder();
                foreach (var propertyInfo in properties)
                {
                    var declareText = ElementBuilder.CreateDeclareTs(propertyInfo);
                    if(!string.IsNullOrEmpty(declareText))
                        declareBuilder.AppendLine(declareText);
                }
                text = text.Replace("//declare endTag", declareBuilder.ToString());

                //CTOR
                var ctorBuilder = new StringBuilder();
                foreach (var propertyInfo in properties)
                {
                    var ctorText = ElementBuilder.CreateCtorTs(propertyInfo);
                    if(!string.IsNullOrEmpty(ctorText))
                        ctorBuilder.AppendLine(ctorText);
                }
                text = text.Replace("//ctor endTag", ctorBuilder.ToString());

                //On Init
                var initBuilder = new StringBuilder();
                foreach (var propertyInfo in properties)
                {
                    var initText = ElementBuilder.CreateOnInitTs(propertyInfo);
                    if(!string.IsNullOrEmpty(initText))
                        initBuilder.AppendLine(initText);
                }
                text = text.Replace("//init endTag", initBuilder.ToString());

                //func
                var funcBuilder = new StringBuilder();
                foreach (var propertyInfo in properties)
                {
                    var funcText = ElementBuilder.CreateFuncTs(propertyInfo);
                    if(!string.IsNullOrEmpty(funcText))
                        funcBuilder.AppendLine(funcText);
                }
                text = text.Replace("//func endTag", funcBuilder.ToString());

                var file = File.Create(fullName);
                file.Close();
                Console.WriteLine("Create File: " + fullName);
                Thread.Sleep(50);
                File.WriteAllText(fullName, text);
            }
        }
        private void GenerateCreateStyleFile()
        {
            var fullName = _moduleDir + $"\\{_name}" + $"\\create-{_name}" + $"\\create-{_name}-dialog.component.scss";
            if (!Directory.Exists(fullName))
            {
                var path = AppConst.CodePath + "\\xxx\\create-xxx\\create-xxx-dialog.component.scss";
                string text = File.ReadAllText(path);
                text = text.Replace("Xxxs", _name.FirstCharToUpper().Plural());
                text = text.Replace("xxxs", _name.Plural());
                text = text.Replace("xxx", _name);
                text = text.Replace("Xxx", _name.FirstCharToUpper());

                var file = File.Create(fullName);
                file.Close();
                Console.WriteLine("Create File: " + fullName);
                Thread.Sleep(50);
                File.WriteAllText(fullName, text);
            }
        }
        #endregion

        #region Edit Component
        private void GenerateEditHtmlFile()
        {
            var fullName = _moduleDir + $"\\{_name}" + $"\\edit-{_name}" + $"\\edit-{_name}-dialog.component.html";
            if (!Directory.Exists(fullName))
            {
                var path = AppConst.CodePath + "\\xxx\\edit-xxx\\edit-xxx-dialog.component.html";
                string text = File.ReadAllText(path);
                text = text.Replace("Xxxs", _name.FirstCharToUpper().Plural());
                text = text.Replace("xxxs", _name.Plural());
                text = text.Replace("xxx", _name);
                text = text.Replace("Xxx", _name.FirstCharToUpper());

                //Element
                var spaces = GetSpaces(text, "<!--element endTag-->");
                var builder = new StringBuilder();
                var properties = _updateDtoType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(prop => prop.Name.ToLower() != "id");
                var twoColumn = properties.Count() > 5;
                foreach (var propertyInfo in properties)
                {
                    builder.AppendLine(ElementBuilder.CreateHtml(propertyInfo, _name, twoColumn));
                }

                text = text.Replace("<!--element endTag-->", builder.ToString());

                var file = File.Create(fullName);
                file.Close();
                Console.WriteLine("Create File: " + fullName);
                Thread.Sleep(50);
                File.WriteAllText(fullName, text);
            }
        }
        private void GenerateEditTsFile()
        {
            var fullName = _moduleDir + $"\\{_name}" + $"\\edit-{_name}" + $"\\edit-{_name}-dialog.component.ts";
            if (!Directory.Exists(fullName))
            {
                var path = AppConst.CodePath + "\\xxx\\edit-xxx\\edit-xxx-dialog.component.ts";
                string text = File.ReadAllText(path);
                text = text.Replace("Xxxs", _name.FirstCharToUpper().Plural());
                text = text.Replace("xxxs", _name.Plural());
                text = text.Replace("xxx", _name);
                text = text.Replace("Xxx", _name.FirstCharToUpper());

                var properties = _updateDtoType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(prop => prop.Name.ToLower() != "id");

                //Import
                var importBuilder = new StringBuilder();
                foreach (var propertyInfo in properties)
                {
                    importBuilder.AppendLine(ElementBuilder.CreateImportTs(propertyInfo));
                }
                var str = importBuilder.ToString().Substring(0, importBuilder.ToString().Length - 1);
                if (!string.IsNullOrEmpty(str))
                {
                    text = text.Replace("//import proxy endTag", "," + str);
                }

                //Declaration
                var declareBuilder = new StringBuilder();
                foreach (var propertyInfo in properties)
                {
                    var declareText = ElementBuilder.CreateDeclareTs(propertyInfo);
                    if(!string.IsNullOrEmpty(declareText))
                        declareBuilder.AppendLine(declareText);
                }
                text = text.Replace("//declare endTag", declareBuilder.ToString());

                //CTOR
                var ctorBuilder = new StringBuilder();
                foreach (var propertyInfo in properties)
                {
                    var ctorText = ElementBuilder.CreateCtorTs(propertyInfo);
                    if(!string.IsNullOrEmpty(ctorText))
                        ctorBuilder.AppendLine(ctorText);
                }
                text = text.Replace("//ctor endTag", ctorBuilder.ToString());

                //On Init
                var initBuilder = new StringBuilder();
                foreach (var propertyInfo in properties)
                {
                    var initText = ElementBuilder.CreateOnInitTs(propertyInfo);
                    if(!string.IsNullOrEmpty(initText))
                        initBuilder.AppendLine(initText);
                }
                text = text.Replace("//init endTag", initBuilder.ToString());

                //func
                var funcBuilder = new StringBuilder();
                foreach (var propertyInfo in properties)
                {
                    var funcText = ElementBuilder.CreateFuncTs(propertyInfo);
                    if(!string.IsNullOrEmpty(funcText))
                        funcBuilder.AppendLine(funcText);
                }
                text = text.Replace("//func endTag", funcBuilder.ToString());

                var file = File.Create(fullName);
                file.Close();
                Console.WriteLine("Create File: " + fullName);
                Thread.Sleep(50);
                File.WriteAllText(fullName, text);
            }
        }
        private void GenerateEditStyleFile()
        {
            var fullName = _moduleDir + $"\\{_name}" + $"\\edit-{_name}" + $"\\edit-{_name}-dialog.component.scss";
            if (!Directory.Exists(fullName))
            {
                var path = AppConst.CodePath + "\\xxx\\edit-xxx\\edit-xxx-dialog.component.scss";
                string text = File.ReadAllText(path);
                text = text.Replace("Xxxs", _name.FirstCharToUpper().Plural());
                text = text.Replace("xxxs", _name.Plural());
                text = text.Replace("xxx", _name);
                text = text.Replace("Xxx", _name.FirstCharToUpper());

                var file = File.Create(fullName);
                file.Close();
                Console.WriteLine("Create File: " + fullName);
                Thread.Sleep(50);
                File.WriteAllText(fullName, text);
            }
        }
        #endregion

        #region List Component
        private void GenerateListStyleFile()
        {
            var fullName = _moduleDir + $"\\{_name}" + $"\\{_name}.component.scss";
            if (!Directory.Exists(fullName))
            {
                var path = AppConst.CodePath + "\\xxx\\xxx.component.scss";
                string text = File.ReadAllText(path);

                var file = File.Create(fullName);

                file.Close();
                Console.WriteLine("Create File: " + fullName);

                Thread.Sleep(50);
                File.WriteAllText(fullName, text);
            }
        }
        private void GenerateListTsFile()
        {
            var fullName = _moduleDir + $"\\{_name}" + $"\\{_name}.component.ts";
            if (!Directory.Exists(fullName))
            {
                var path = AppConst.CodePath + "\\xxx\\xxx.component.ts";
                string text = File.ReadAllText(path);
                text = text.Replace("Xxxs", _name.FirstCharToUpper().Plural());
                text = text.Replace("xxxs", _name.Plural());
                text = text.Replace("xxx", _name);
                text = text.Replace("Xxx", _name.FirstCharToUpper());

                var file = File.Create(fullName);
                file.Close();
                Console.WriteLine("Create File: " + fullName);
                Thread.Sleep(50);
                File.WriteAllText(fullName, text);
            }
        }
        private void GenerateListHtmlFile()
        {
            var fullName = _moduleDir + $"\\{_name}" + $"\\{_name}.component.html";
            if (!Directory.Exists(fullName))
            {
                var path = AppConst.CodePath + "\\xxx\\xxx.component.html";
                string text = File.ReadAllText(path);
                text = text.Replace("Xxxs", _name.FirstCharToUpper().Plural());
                text = text.Replace("xxxs", _name.Plural());
                text = text.Replace("xxx", _name);
                text = text.Replace("Xxx", _name.FirstCharToUpper());

                //Column
                var spaces = GetSpaces(text, "<!--column endTag-->");
                var builde = new StringBuilder();
                var properties = _readDtoType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(prop => prop.Name.ToLower() != "id");
                foreach (var property in properties)
                {
                    builde.AppendLine(spaces + GenerateColumn(property));
                }
                text = text.Replace(spaces + "<!--column endTag-->", builde.ToString());
                //Save File
                var file = File.Create(fullName);
                file.Close();
                Console.WriteLine("Create File: " + fullName);
                Thread.Sleep(50);
                File.WriteAllText(fullName, text);
            }
        }
        private object GetSpaces(string text, string tag)
        {
            var spaces = "";
            var str = text.Split(tag)[0];
            List<char> chars = new List<char>();
            chars.AddRange(str);
            for (int i = chars.Count - 1; i > 0; i--)
            {
                if (chars[i] == ' ')
                    spaces += " ";
                else
                    break;
            }
            return spaces;
        }
        private string GenerateColumn(PropertyInfo propertyInfo)
        {
            var builder = new StringBuilder();
            builder.Append($"<e-column field=\"{propertyInfo.Name.FirstCharToLower()}\" ");

            var headerText = "headerText=\"{{'" + propertyInfo.Name + "' | localize}}\" ";
            builder.Append(headerText);

            if (
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
                builder.Append("format=\"N\" ");
            }

            builder.Append("textAlign=\"center\"></e-column>");

            return builder.ToString();
        }
        #endregion

        #region Module
        public void AddToModule()
        {
            var module = _moduleDir + $"\\{_moduleName}.module.ts";

            //Import
            var importBuilder = new StringBuilder();
            importBuilder.AppendLine("import { " + _entityName + "Component } " + $"from './{_name}/{_name}.component';");
            importBuilder.AppendLine("import { Create" + _entityName + "DialogComponent } " + $"from './{_name}/create-{_name}/create-{_name}-dialog.component';");
            importBuilder.AppendLine("import { Edit" + _entityName + "DialogComponent } " + $"from './{_name}/edit-{_name}/edit-{_name}-dialog.component';");
            importBuilder.AppendLine("import { " + _entityName + "ServiceProxy } from '@shared/service-proxies/service-proxies';");
            UpdateFileContent(module, "//import endTage", importBuilder.ToString());

            //Declaration
            var declareBuilder = new StringBuilder();
            declareBuilder.AppendLine($"{_entityName}Component,".Tap2());
            declareBuilder.AppendLine($"Create{_entityName}DialogComponent,".Tap2());
            declareBuilder.AppendLine($"Edit{_entityName}DialogComponent,".Tap2());
            UpdateFileContent(module, "//declare endTage", declareBuilder.ToString());

            //Service Proxy
            UpdateFileContent(module, "//Service proxy endTage", $"{_entityName}ServiceProxy,");
        }
        public void AddToRoutingModule()
        {
            var routingModule = _moduleDir + $"\\{_moduleName}-routing.module.ts";

            //Import
            var lineToAdd = "import { " + _entityName + "Component } from './" + _name + "/" + _name + ".component';";
            UpdateFileContent(routingModule, "//import endTage", lineToAdd);

            //Routes
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("{".Tap2());
            stringBuilder.AppendLine(($"path: '{_name}',").Tap3());
            stringBuilder.AppendLine(string.Format("component: {0}Component,", _entityName).Tap3());
            stringBuilder.AppendLine("data: { permission : 'Page.".Tap3() + _entityName + "' },");
            stringBuilder.AppendLine("canActivate: [AppRouteGuard]".Tap3());
            stringBuilder.AppendLine("},".Tap2());

            UpdateFileContent(routingModule, "//route endTage", stringBuilder.ToString());
        }
        public void UpdateFileContent(string fileName, string endTag, string lineToAdd)
        {
            var txtLines = File.ReadAllLines(fileName).ToList();
            var index = 0;
            foreach (var line in txtLines)
            {
                if (line.Contains(endTag))
                    index = txtLines.IndexOf(line);
            }
            txtLines.Insert(index, lineToAdd);
            File.WriteAllLines(fileName, txtLines);
            Console.WriteLine("Update File: " + fileName);
            Thread.Sleep(100);
        }
        #endregion
    }

    public class FieldData
    {
        public string Name { get; set; }
        public MemberTypes MemType { get; set; }
        public Type FieldType { get; set; }

    }
}
