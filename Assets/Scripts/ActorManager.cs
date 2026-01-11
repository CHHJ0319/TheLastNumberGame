using Text;
using UnityEngine;

public static class ActorManager
{
    public static Data.EnemyData[] Enemies;

    public static void Initialize()
    {
        Enemies = new Data.EnemyData[4];
    }

    public static void GenerateEnemyProfile()
    {
        Enemies[0] = new Data.EnemyData(
                name: Text.Enemy1.Name,
                startMessage: Text.Enemy1.StartMessage,
                randomMessage1: Text.Enemy1.RandomMessage1,
                randomMessage2: Text.Enemy1.RandomMessage2,
                randomMessage3: Text.Enemy1.RandomMessage3,
                defeatMessage: Text.Enemy1.DefeatMessage,
                winMessage: Text.Enemy1.WinMessage
            );

        Enemies[1] = new Data.EnemyData(
                name: Text.Enemy2.Name,
                startMessage: Text.Enemy2.StartMessage,
                randomMessage1: Text.Enemy2.RandomMessage1,
                randomMessage2: Text.Enemy2.RandomMessage2,
                randomMessage3: Text.Enemy2.RandomMessage3,
                defeatMessage: Text.Enemy2.DefeatMessage,
                winMessage: Text.Enemy2.WinMessage
            );

        Enemies[2] = new Data.EnemyData(
                name: Text.Enemy3.Name,
                startMessage: Text.Enemy3.StartMessage,
                randomMessage1: Text.Enemy3.RandomMessage1,
                randomMessage2: Text.Enemy3.RandomMessage2,
                randomMessage3: Text.Enemy3.RandomMessage3,
                defeatMessage: Text.Enemy3.DefeatMessage,
                winMessage: Text.Enemy3.WinMessage
            );

        Enemies[3] = new Data.EnemyData(
                name: Text.Enemy4.Name,
                startMessage: Text.Enemy4.StartMessage,
                randomMessage1: Text.Enemy4.RandomMessage1,
                randomMessage2: Text.Enemy4.RandomMessage2,
                randomMessage3: Text.Enemy4.RandomMessage3,
                defeatMessage: Text.Enemy4.DefeatMessage,
                winMessage: Text.Enemy4.WinMessage
            );
    }
}
