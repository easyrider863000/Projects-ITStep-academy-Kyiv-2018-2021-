using System;
namespace _05_ArrayListEvents.Models
{
    class ChangedEventArgs : EventArgs
    {
        public object Item { get; set; }
        public bool Permit { get; set; }       
    }
}
