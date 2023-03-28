using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    public PlayerState previousState;
    public PlayerState nextState;

    public Sprite stateSprite;
    public int stateLayer;
}
