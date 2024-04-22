using Assets.Scripts.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Misc.Tools
{
    
    public static class PhysicTools
    {
        public static List<T> GetComponentsInRadius<T>(Vector2 origin, float radius, Vector2 direction)
        {
            var objsAround = Physics2D.CircleCastAll(origin, radius, direction, distance: 1f);
            List<T> components = new();

            foreach (var obj in objsAround)
            {
                T agebl;
                if (obj.transform.gameObject.TryGetComponent(out agebl))
                    components.Add(agebl);
            }
            return components;
        }
    }
}
