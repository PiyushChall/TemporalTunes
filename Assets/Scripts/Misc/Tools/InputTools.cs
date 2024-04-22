using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Misc.Tools
{
    public static class InputTools
    {
        public static KeyCode GetAnyKeyDown(IEnumerable<KeyCode> keys)
        {
            foreach(KeyCode key in keys)
            {
                if(Input.GetKeyDown(key))
                    return key;
            }
            return KeyCode.None;
        }
    }
}
