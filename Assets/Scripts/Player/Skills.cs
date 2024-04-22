using Assets.Scripts.Misc.Tools;
using Assets.Scripts.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Player
{
    internal static class Skills
    {

        private static readonly OrganBehaviour player = OrganBehaviour.Instance;

        #region Ageing skill
        public static readonly Skill Age = new()
        {
            Name = "Age",
            Description = "Age all possible objects arround you",
            triggerNotes = "ddu",
        };

        private static void AgeSkillFunction()
        {

            List<IAgebl> agebls =
                PhysicTools.GetComponentsInRadius<IAgebl>(
                    player.transform.position,
                    5,
                    player.transform.right
                );

            agebls.ForEach(a => a.AddAge());
        }
        #endregion

        #region Unageing skill
        public static readonly Skill Unage = new()
        {
            Name = "Unage",
            Description = "Unage all possible objects arround you",
            triggerNotes = "uud",
        };
        private static void UnageSkillFunction()
        {

            List<IAgebl> agebls =
                PhysicTools.GetComponentsInRadius<IAgebl>(
                    player.transform.position,
                    3f,
                    player.transform.right
                );

            agebls.ForEach(a => a.SubtractAge());
        }
        #endregion

        #region Pause skill
        static List<IPausable> pausedObjects = new();

        public static readonly Skill Pause = new()
        {
            Name = "Pause",
            Description = "Pause all possible objects arround you",
            triggerNotes = "rdl",
            loopNotes = "lr",
            isLoop = true
        };

        private static void PauseSkillLoop()
        {
            List<IPausable> pausables =
                PhysicTools.GetComponentsInRadius<IPausable>(
                    player.transform.position,
                    3,
                    player.transform.right
                );

            pausedObjects
                .Except(pausables)
                .ToList()
                .ForEach(o => 
                { 
                    o.Unpause(); 
                    pausedObjects.Remove(o); 
                });

            pausables
                .Except(pausedObjects)
                .ToList()
                .ForEach(o =>
                {
                    o.Pause();
                    pausedObjects.Add(o);
                });
        }



        private static void PauseSkillEnd()
        {
            pausedObjects.ForEach(p => p.Unpause());
            pausedObjects.Clear();
        }
        #endregion

        static Skills()
        {
            Age.start.AddListener(AgeSkillFunction);
            Unage.start.AddListener(UnageSkillFunction);
            Pause.loop.AddListener(PauseSkillLoop);
            Pause.end.AddListener(PauseSkillEnd);
        }
    }
}
