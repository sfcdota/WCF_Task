using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDLL
{
    /// <summary>
    /// Класс проверки корректности пути        
    /// </summary>
    public sealed class PathChecker
    {
        private bool _RewriteAllowed = false;
        public PathChecker(bool rewriteAllowed)
        {
            _RewriteAllowed = rewriteAllowed;
        }
        /// <summary>
        /// Получение пути файла в соответствии с настройками конфигурации
        /// и с учетом существования файла с таким же названием в указанной директории
        /// </summary>
        /// <param name="path"></param>
        /// <param name="enteredExtension"></param>
        /// <returns></returns>
        public string GetRightPath(string path, string enteredExtension)
        {
            int i = 1;
            string tempPath = path;
            FileInfo info = new FileInfo(path);
            string baseDirectoryName = info.Directory.Name;
            string baseName = Path.GetFileNameWithoutExtension(tempPath);
            if (!_RewriteAllowed)
                while (File.Exists(tempPath))
                {
                    tempPath = Path.Combine(baseDirectoryName, baseName + i + info.Extension);
                    i++;
                }
            return tempPath;
        }
        /*
        public string GetRightPath(string path, string enteredExtension)
        {
            int i = 1;
            string baseName = path;
            path = Path.Combine(baseName + "." + enteredExtension);
            if (!_RewriteAllowed)//true or false value
                while (File.Exists(path))
                {
                    path = Path.Combine(baseName + "-" + i + "." + enteredExtension);
                    i++;
                }
            return path;
            */
        }
    }
}
