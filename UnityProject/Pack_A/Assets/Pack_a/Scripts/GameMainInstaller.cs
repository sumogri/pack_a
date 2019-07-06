using UnityEngine;
using Zenject;

public class GameMainInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var score = new ScoreModel();
        var game = new GameModel(score);

        Container.Bind<ScoreModel>()
            .FromInstance(score);
        Container.Bind<GameModel>()
            .FromInstance(game);
    }
}