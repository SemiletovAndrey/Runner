using UnityEngine;
using Zenject;

public class AnimationPlayerHandler : MonoBehaviour
{
    private PlayerModel _model;

    [Inject]
    public void Construct(PlayerModel playerModel)
    {
        _model = playerModel;
    }

    public void EndAnimationJump()
    {
        _model.EndJump();
    }
    
    public void EndAnimationSlide()
    {
        _model.EndSlide();
    }
}
