using Common.Library.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Library.AbstractFactory
{
    public abstract class AbstractFactory
    {
        public abstract AbstractFileManager CreateFileManager(string typeOfFileManager);

    }
}
