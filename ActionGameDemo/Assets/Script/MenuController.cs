using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public SkinnedMeshRenderer headMesh;
    public Mesh[] headMeshList;
    private int headMeshIndex = 0;

    public SkinnedMeshRenderer handMesh;
    public Mesh[] handMeshList;
    private int handMeshIndex = 0;

    private int colorIndex = 0;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void OnHeadMeshNext()
    {
        headMeshIndex++;
        headMeshIndex %= headMeshList.Length;
        headMesh.sharedMesh = headMeshList[headMeshIndex];
    }

    public void OnHandMeshNext()
    {
        handMeshIndex++;
        handMeshIndex %= handMeshList.Length;
        handMesh.sharedMesh = handMeshList[handMeshIndex];
    }

    public void OnChangeColorRed()
    {
        colorIndex = 1;
        OnChangeColor(Color.red);
    }
    public void OnChangeColorPurple()
    {
        colorIndex = 2;
        OnChangeColor(Color.magenta);
    }
    public void OnChangeColorBlue()
    {
        colorIndex = 3;
        OnChangeColor(Color.blue);
    }
    public void OnChangeColorCyan()
    {
        colorIndex = 4;
        OnChangeColor(Color.cyan);
    }
    public void OnChangeColorGreen()
    {
        colorIndex = 5;
        OnChangeColor(Color.green);
    }


    public void OnPlay()
    {
        SaveSetting();
        SceneManager.LoadScene(1);
    }


    void OnChangeColor(Color clr)
    {
        headMesh.sharedMaterial.color = clr;
    }

    void SaveSetting()
    {
        PlayerPrefs.SetInt("HeadMeshIndex", headMeshIndex);
        PlayerPrefs.SetInt("HandMeshIndex", handMeshIndex);
        PlayerPrefs.SetInt("ColorIndex", colorIndex);
        Debug.Log(headMeshIndex + "," + handMeshIndex + "," + colorIndex);
        PlayerPrefs.Save();
    }
}
