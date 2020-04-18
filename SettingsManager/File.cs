using System;
using System.Collections.Generic;
using System.Text;

namespace SettingsManager
{
    public class SettingFile
    {
        public bool InUse { get; set; }
        public string Description { get; set; }
        public string FileLocation { get; set; }
    }
}
