using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.Interfaces
{
    internal interface IPausable
    {
        public void Pause();
        public void Unpause();
    }
}
