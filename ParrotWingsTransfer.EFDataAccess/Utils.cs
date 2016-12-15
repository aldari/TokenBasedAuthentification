using System.IO;
using System.Reflection;

namespace ParrotWingsTransfer.API
{
    public static class Utils
    {
        public static string LoadSqlStatement(string namespacePart, string statementName)
        {
            string sqlStatement = string.Empty;

            string resourceName = namespacePart + "." + statementName;

            using (Stream stm = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stm != null)
                {
                    sqlStatement = new StreamReader(stm).ReadToEnd();
                }
            }

            return sqlStatement;
        }
    }
}