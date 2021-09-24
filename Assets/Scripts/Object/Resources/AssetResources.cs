using UnityEngine;

public class AssetResources : IResources
{

    private const string PlayerPath = "Characters/Player/";
    private const string EffectPath = "Effects/";
    private const string SpritePath = "Sprites/";
    private const string SaveDataPath = "SaveData/";
    private const string ItemPath = "Sprites/Item/";

    public override GameObject LoadPlayer(string PlayerName)
    {
        UnityEngine.Object res = LoadGameObjectFromResourcePath(PlayerPath + PlayerName);
        if (res == null)
            return null;
        return res as GameObject;
    }

    public override void LoadEffect(string EffectName)
    {
        UnityEngine.Object res = LoadGameObjectFromResourcePath(EffectPath + EffectName);
    }

    public override Sprite LoadSprite(string SpriteName)
    {
        //Sprite res = Resources.Load<Sprite>(SpritePath + SpriteName);
        Sprite res = Resources.Load<Sprite>(SpritePath + SpriteName);

        if (res == null)
        {
            Debug.Log("無法載入路徑" + SpritePath + SpriteName);
            return null;
        }
        return res;
    }

    public UnityEngine.Object LoadGameObjectFromResourcePath(string AssetPath)
    {
        UnityEngine.Object res = Resources.Load(AssetPath);
        if (res == null)
        {
            Debug.LogWarning("無法載入路徑[" + AssetPath + "]上的Asset");
            return null;
        }
        return res;
    }

    public override Sprite LoadItem(string ItemSpriteName)
    {
        Sprite res = Resources.Load<Sprite>(ItemPath + ItemSpriteName);

        if (res == null)
        {
            Debug.Log("無法載入路徑" + ItemPath + ItemSpriteName);
            return null;
        }

        return res;
    }
}

