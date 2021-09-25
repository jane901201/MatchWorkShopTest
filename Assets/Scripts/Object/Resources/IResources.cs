using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IResources
{
    public abstract GameObject LoadPlayer(string PlayerName);
    public abstract void LoadEffect(string EffectName);
    public abstract Sprite LoadSprite(string SpriteName);
    public abstract Sprite LoadItem(string ItemSpriteName);
    public abstract TextAsset LoadXML(string DataName);
}
