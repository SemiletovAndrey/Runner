using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventBus
{
    public static Action OnRestartGame;
    public static Action OnDeathPlayer;
    public static Action OnRecivedMaxScore;
}
