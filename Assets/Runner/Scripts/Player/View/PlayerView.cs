using System;
using UnityEngine;

public class PlayerView
{
    private const float _minRunSpeed = 1f;
    private const float _runMaxSpeed = 2f;
    private const float _minJumpSpeed = 1.5f;
    private const float _maxJumpSpeed = 2.5f;
    private const float _minSlideSpeed = 1f;
    private const float _maxSlideSpeed = 2.5f;

    private const float _animationRunSpeedScalingFactor = 15f;
    private const float _animationJumpSpeedScalingFactor = 25f;
    private const float _animationSlideSpeedScalingFactor = 22f;

    private readonly int _runHash = Animator.StringToHash("RunTrigger");
    private readonly int _jumpHash = Animator.StringToHash("JumpTrigger");
    private readonly int _slideHash = Animator.StringToHash("SlideTrigger");
    private readonly int _idleHash = Animator.StringToHash("IdleTrigger");
    private readonly int _deathHash = Animator.StringToHash("DeathTrigger");

    private readonly int _runSpeedHash = Animator.StringToHash("RunSpeed");
    private readonly int _jumpSpeedHash = Animator.StringToHash("JumpSpeed");
    private readonly int _slideSpeedHash = Animator.StringToHash("SlideSpeed");

    

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
    
    public void PlayDeathAnimation()
    {
        PlayDeath();
    }

    public void StopAnimations()
    {
        _animator.ResetTrigger(_runHash);
        _animator.ResetTrigger(_jumpHash);
        _animator.ResetTrigger(_slideHash);
        _animator.SetFloat(_runSpeedHash, _minRunSpeed);
        _animator.SetFloat(_jumpSpeedHash, _minJumpSpeed);
        _animator.SetFloat(_slideSpeedHash, _minSlideSpeed);
    }

    public void UpdateAnimationSpeed(float speed)
    {
        _animator.SetFloat(_runSpeedHash, Mathf.Clamp(speed / _animationRunSpeedScalingFactor, _minRunSpeed, _runMaxSpeed));
        _animator.SetFloat(_jumpSpeedHash, Mathf.Clamp(speed / _animationJumpSpeedScalingFactor, _minJumpSpeed, _maxJumpSpeed));
        _animator.SetFloat(_slideSpeedHash, Mathf.Clamp(speed / _animationSlideSpeedScalingFactor, _minSlideSpeed, _maxSlideSpeed));
    }

    private void PlayRun() => _animator.SetTrigger(_runHash);

    private void PlayJump() => _animator.SetTrigger(_jumpHash);

    private void PlaySlide() => _animator.SetTrigger(_slideHash);

    private void PlayIdle() => _animator.SetTrigger(_idleHash);
    private void PlayDeath() => _animator.SetTrigger(_deathHash);

   
}
