﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Karbon.Core.IO;

namespace Karbon.Core
{
    public class EnvironmentContext
    {
        private string _rootDir;
        public virtual string RootDirectory
        {
            get
            {
                if (!String.IsNullOrEmpty(_rootDir))
                {
                    return _rootDir;
                }

                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new Uri(codeBase);
                var path = uri.LocalPath;
                var baseDirectory = Path.GetDirectoryName(path);

                if (baseDirectory != null)
                    _rootDir = baseDirectory.Substring(0, baseDirectory.LastIndexOf("bin") - 1);

                return _rootDir;
            }
        }

        public virtual string MapPath(string path)
        {
            var newPath = path.TrimStart('~', '/').Replace('/', Path.DirectorySeparatorChar);
            var mappedPath = RootDirectory + Path.DirectorySeparatorChar + newPath;
            return mappedPath;
        }
    }
}
