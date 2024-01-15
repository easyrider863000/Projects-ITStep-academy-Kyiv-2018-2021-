using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExample.Models
{
    public class StorageProducer : ObservableCollection<Producer>
    {
        public StorageProducer()
        {
            this.Add(new Producer { Id = 1, ProducerName = "IBM", Country = "USA" });
            this.Add(new Producer { Id = 2, ProducerName = "Ba-Ba", Country = "China" });
            this.Add(new Producer { Id = 3, ProducerName = "Hitachi", Country = "Korea" });
        }

    }
}
