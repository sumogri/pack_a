using UnityEngine;
using Zenject;

public class GameMainInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var score = new ScoreModel();

        Container.Bind<ScoreModel>()
            .FromInstance(score);
    }
}