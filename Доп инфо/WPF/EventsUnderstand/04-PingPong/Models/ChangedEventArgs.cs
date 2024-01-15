using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_PingPong.Models
{
    class ChangedEventArgs : EventArgs
    {
        public Boolean IsBall { get; set; }
    }
}
