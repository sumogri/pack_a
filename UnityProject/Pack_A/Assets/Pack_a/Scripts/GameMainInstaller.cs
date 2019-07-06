using UnityEngine;
using Zenject;

public class GameMainInstaller : MonoInstaller
{
    [SerializeField] private int maxScore = 15;
    public override void InstallBindings()
    {
        var score = new ScoreModel(maxScore);
        var game = new GameModel(score);

        Container.Bind<ScoreModel>()
            .FromInstance(score);
        Container.Bind<GameModel>()
            .FromInstance(game);
    }
}