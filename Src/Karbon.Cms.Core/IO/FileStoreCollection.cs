﻿using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karbon.Cms.Core.IO
{
    internal class FileStoreCollection : ProviderCollection
    {
        new public FileStore this[string name]
        {
            get { return (FileStore)base[name]; }
        }
    }
}
