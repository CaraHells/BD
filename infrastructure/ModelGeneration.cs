using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CinemaApp.infrastructure
{
    public class ModelGeneration
    {
        public void Generation(string sqlCommand)
        {
            try {
                var tables = Entity.GetTables(sqlCommand);
                foreach (var table in tables)
                {
                    string command = string.Format($"SELECT column_name, data_type FROM information_schema.columns WHERE table_name='{table}' and table_schema='Film'");
                    var result = Entity.GetProperties(command);
                    List<string> properties = new List<string>();
                    List<Tuple<string, string>> attributes = new List<Tuple<string, string>>();
                    foreach (var property in result)
                    {
                        //конвертируем типы
                        string type = ConvertType(property.Item2);
                        string name = property.Item1;
                        //приватные поля + конструктор + получение и установка значения
                        properties.Add($"private {type} _{name.ToLower()};");
                        //properties.Add($"public {type} {name}{{get;set;}}");
                        attributes.Add(new Tuple<string,string> (type, name.ToLower()));
                        //properties.Add($"public {type} {name};");

                        
                    }

                    string fileName = table + ".cs";
                    List<string> data = new List<string>()
                {
                    "using System;",
                    "using System.Collections.Generic;",
                    "using System.Linq;",
                    "using System.Text;",
                    "using System.Threading.Tasks;",
                    "",
                    "namespace CinemaApp.models",
                    "{",
                    $"public class {table}",
                    "{"
                };
                    data.AddRange(properties);
                    data.Add($"public {table}()");
                    data.Add("{}");
                    string construct = "";
                    var bodyAttr = "";
                    var publicAttr = "";
                    foreach (var attribute in attributes)
                    {
                        construct += $"{attribute.Item1} {attribute.Item2},";
                        bodyAttr += $"this._{attribute.Item2}={attribute.Item2};\n";
                        publicAttr += $"public {attribute.Item1} {attribute.Item2} {{ get=>_{attribute.Item2}; set => _{attribute.Item2}=value; }} \n";
                    }
                    construct = construct.Substring(0, (construct.Length) - 1);
                    data.Add($"public {table} ({construct}){{ \n {bodyAttr} }}");
                    data.Add(publicAttr);
                    
                    data.Add("}");
                    data.Add("}");
                    var pathFile = AppDomain.CurrentDomain.BaseDirectory;
                    var fullPath = Path.GetFullPath(Path.Combine(pathFile, @"..\..\.."));
                    var models = Path.Combine(fullPath, "models");
                    string file = Path.Combine(models, fileName);
                    File.WriteAllLines(file, data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBconn.SqlConnection.Close();
            }
        }

        public string ConvertType(string type)
        {
            switch(type.ToLower())
            {
                case "integer": return "int";
                case "serial": return "int";
                case "bigint": return "long";
                case "smallint": return "short";
                case "text":
                case "character varying":
                case "varchar": return "string";
                case "json": return "string";
                case "boolean": return "bool";
                case "date": return "DateTime";
                case "timestamp": return "DateTime";
                case "numeric":
                case "decimal": return "decimal";
                case "money": return "decimal";
                case "double precision": return "double";
                case "real": return "float";
                default: return "string";
            }
        }
    }
}
