using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormSettings.Shared
{
    public class SortableFormSectionModel
    {
        public bool Required { get; set; } = false;
        public bool Visible { get; set; } = true;
        public int Index { get; set; }
        public string ElementId { get; set; }
        public string InputType { get; set; }
        public string Label { get; set; }
    }
}
