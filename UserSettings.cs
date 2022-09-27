using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace Hangman
{
    public class UserSettings : ApplicationSettingsBase
    {
        [UserScopedSetting()]
        public string FilePath
        {
            get
            {
                return (string)this["FilePath"];
            }
            set
            {
                this["FilePath"] = value;
            }
        }
    }
}
