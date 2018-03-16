using UnityEngine;
using System.Collections;

public class PlayerDress : MonoBehaviour
{

    public SkinnedMeshRenderer headRender;
    public SkinnedMeshRenderer handRender;
    public SkinnedMeshRenderer[] bodyMeshList;

    void Start()
    {
        InitDress();
    }

    void InitDress()
    {
        if (MenuController.Instance == null) return;

        int headMeshIndex = PlayerPrefs.GetInt("HeadMeshIndex");
        int handMeshIndex = PlayerPrefs.GetInt("HandMeshIndex");
        int colorIndex = PlayerPrefs.GetInt("ColorIndex");

        headRender.sharedMesh = MenuController.Instance.headMeshList[headMeshIndex];
        handRender.sharedMesh = MenuController.Instance.handMeshList[handMeshIndex];

        foreach (var body in bodyMeshList)
        {
            body.material.color = MenuController.Instance.colorList[colorIndex];
        }

    }
}
