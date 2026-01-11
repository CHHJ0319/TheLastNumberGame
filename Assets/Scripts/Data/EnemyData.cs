using UnityEditor.AssetImporters;
using UnityEngine;

namespace Data
{
    public class EnemyData
    {
        public string Name;
        public string StartMessage;
        public string RandomMessage1;
        public string RandomMessage2;
        public string RandomMessage3;
        public string DefeatMessage;
        public string WinMessage;

        public EnemyData(string name, string startMessage, string randomMessage1, string randomMessage2, string randomMessage3, string defeatMessage, string winMessage)
        {
            Name = name;
            StartMessage = startMessage;
            RandomMessage1 = randomMessage1;
            RandomMessage2 = randomMessage2;
            RandomMessage3 = randomMessage3;
            DefeatMessage = defeatMessage;
            WinMessage = winMessage;
        }
    }
}
