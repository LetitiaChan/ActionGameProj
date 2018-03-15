using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static MenuController Instance;

    public SkinnedMeshRenderer headMesh;
    public Mesh[] headMeshList;
    private int headMeshIndex = 0;

    public SkinnedMeshRenderer handMesh;
    public Mesh[] handMeshList;
    private int handMeshIndex = 0;

    public SkinnedMeshRenderer[] bodyMeshList;
    [HideInInspector]
    public Color[] colorList = new Color[] { Color.white, Color.red, Color.magenta, Color.blue, Color.cyan, Color.green };
    private int colorIndex = 0;

    void Awake()
    {
        Instance = this;
    }

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
        foreach (var body in bodyMeshList)
        {
            body.material.color = clr;
        }
    }

    void SaveSetting()
    {
        PlayerPrefs.SetInt("HeadMeshIndex", headMeshIndex);
        PlayerPrefs.SetInt("HandMeshIndex", handMeshIndex);
        PlayerPrefs.SetInt("ColorIndex", colorIndex);
        PlayerPrefs.Save();
    }
}
