using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_Works.UI
{
    interface IContainer
    {
        public int ComponentIndex { get; }
        public Component FocusComponent { get; }

        public void FocusNext();
        public void FocusPrevious();
    }
}
