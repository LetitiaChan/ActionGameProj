using UnityEngine;
using System.Collections;

public class MiniMap : MonoBehaviour
{
    public static MiniMap Instance;
    public GameObject symbolBoss;
    public GameObject symbolMonster;
    private GameObject symbolPlayer;

    void Awake()
    {
        Instance = this;
        symbolPlayer = transform.FindChild("SymbolPlayer").gameObject;
    }

    public GameObject GetSymbolPlayer()
    {
        return symbolPlayer;
    }

    public GameObject GetSymbolBoss()
    {
        GameObject go = Instantiate(Resources.Load("SymbolBoss")) as GameObject;
        go.transform.SetParent(transform, false);
        //go.transform.SetAsLastSibling();
        return go;
    }

    public GameObject GetSymbolMonster()
    {
        GameObject go = Instantiate(Resources.Load("SymbolMonster")) as GameObject;
        go.transform.SetParent(transform, false);
        return go;
    }
}
