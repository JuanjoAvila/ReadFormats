using Common.Library.Interfaces;
using Common.Library.Util;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Reflection;

namespace Common.Library.AbstractFactory
{
    public class FileFactory : AbstractFactory
    {
        private readonly ILogger Log;
        
        public FileFactory()
        {
            Log = new LogFourNetAdapter();
        }
        public override AbstractFileManager CreateFileManager(string typeOfFileManager)
        {

            XElement root = XElement.Load("RepositoryConfiguration.xml");
            IEnumerable<XElement> repository =
                from element in root.Elements("Type")
                where (string)element.Attribute("id") == typeOfFileManager
                select element;

            var fileType = repository.First().Element("class").Value;
            Type newFileManager = GetCurrentAssembly().GetType(fileType);
            AbstractFileManager instance = null;

            try
            {
                instance = (AbstractFileManager)Activator.CreateInstance(newFileManager);
            }

            #region Try Catch Exceptions
            catch (ArgumentNullException e)
            {
                Log.Error(e.Message);
                Log.Error(e.StackTrace);

                throw new CustomException(Common_Resources.ArgumentNull, e);
            }
            catch (ArgumentException e)
            {
                Log.Error(e.Message);
                Log.Error(e.StackTrace);

                throw new CustomException(Common_Resources.ArgumentException, e);
            }
            catch (TargetException e)
            {
                Log.Error(e.Message);
                Log.Error(e.StackTrace);

                throw new CustomException(Common_Resources.TargetException, e);
            }
            catch (TargetInvocationException e)
            {
                Log.Error(e.Message);
                Log.Error(e.StackTrace);

                throw new CustomException(Common_Resources.TargetInvocationException, e);
            }
            #endregion

            return instance;
        }
        public Assembly GetCurrentAssembly()
        {
            Assembly myAssembly = typeof(FileFactory).Assembly;
            return myAssembly;
        }
    }
}
