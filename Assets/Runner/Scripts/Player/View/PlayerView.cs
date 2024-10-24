using System;
using UnityEngine;

public class PlayerView
{
    private readonly int _runHash = Animator.StringToHash("RunTrigger");
    private readonly int _jumpHash = Animator.StringToHash("JumpTrigger");
    private readonly int _slideHash = Animator.StringToHash("SlideTrigger");
    private readonly int _idleHash = Animator.StringToHash("IdleTrigger");

    private Animator _animator;

    public PlayerView(Animator animator)
    {
        _animator = animator;
    }

    public void PlayJumpAnimation()
    {
        PlayJump();
    }

    public void PlayRunAnimation()
    {
        PlayRun();
    }

    public void PlaySlideAnimation()
    {
        PlaySlide();
    }

    public void PlayIdleAnimation()
    {
        PlayIdle();
    }

    private void PlayRun() => _animator.SetTrigger(_runHash);

    private void PlayJump() => _animator.SetTrigger(_jumpHash);

    private void PlaySlide() => _animator.SetTrigger(_slideHash);

    private void PlayIdle() => _animator.SetTrigger(_idleHash);

    internal void StopAnimations()
    {
        _animator.enabled = false;
    }
}
