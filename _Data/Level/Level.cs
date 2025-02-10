using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : NamMonoBehaviour
{
    [Header("Level")]
    [SerializeField] protected int levelCurrent = 0;
    [SerializeField] protected int levelMax = 99;
    public int LevelCurrent => levelCurrent;
    public int LevelMax => levelMax;

    protected virtual void LevelUp()
    {
        this.levelCurrent += 1;
        this.LimitLevel();
    }
    protected virtual void SetLevel(int newLevel)
    {
        this.levelCurrent = newLevel;
        this.LimitLevel();
    }
    protected virtual void LimitLevel()
    {
        if (this.levelCurrent > this.levelMax) this.levelMax = this.levelCurrent;
        if (this.levelCurrent < 1) this.levelCurrent = 1;
    }
}
