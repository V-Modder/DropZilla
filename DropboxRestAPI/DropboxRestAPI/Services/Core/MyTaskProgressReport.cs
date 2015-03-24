using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropboxRestAPI.Services.Core
{
    public class MyTaskProgressReport
    {
        //current progress
        public long? CurrentProgressAmount { get; set; }

        //total progress
        public long? TotalProgressAmount { get; set; }

        //some message to pass to the UI of current progress
        public string CurrentProgressMessage { get; set; }
    }
}
