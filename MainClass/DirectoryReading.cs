using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainClass
{

    public interface DirectoryReading
    {

        long FileSize { get; }

        bool isFileReadOnlyFunc { get; }

        long setRequirementsSizeFile { set; }
        long getRequirementsSizeFile { get; }

        string[] DirectoryTree(string path);

        void LogWrite(string logMessage);

        //Инициализация параметров обработчика
        void init(SortedList<string, object> parameters);

    }

}
