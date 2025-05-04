using System.Collections.Generic;
using UnityEngine;

namespace UIToolkitExamples
{
    [CreateAssetMenu(menuName = "UI Toolkit Examples/GameSwitchList")]
    public class GameSwitchListAsset : ScriptableObject
    {
        public List<GameSwitch> switches;

        public void Reset()
        {
            switches = new()
            {
                new() { name = "Use Local Server", enabled = false },
                new() { name = "Show Debug Menu", enabled = false },
                new() { name = "Show FPS Counter", enabled = true },
            };
        }

        public bool IsSwitchEnabled(string switchName) => switches.Find(s => s.name == switchName).enabled;
    }
}