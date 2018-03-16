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

    private AudioSource asUIEffect;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        asUIEffect = transform.GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    public void OnHeadMeshNext()
    {
        asUIEffect.Play();
        headMeshIndex++;
        headMeshIndex %= headMeshList.Length;
        headMesh.sharedMesh = headMeshList[headMeshIndex];
    }

    public void OnHandMeshNext()
    {
        asUIEffect.Play();
        handMeshIndex++;
        handMeshIndex %= handMeshList.Length;
        handMesh.sharedMesh = handMeshList[handMeshIndex];
    }

    public void OnChangeColorRed()
    {
        asUIEffect.Play();
        colorIndex = 1;
        OnChangeColor(Color.red);
    }
    public void OnChangeColorPurple()
    {
        asUIEffect.Play();
        colorIndex = 2;
        OnChangeColor(Color.magenta);
    }
    public void OnChangeColorBlue()
    {
        asUIEffect.Play();
        colorIndex = 3;
        OnChangeColor(Color.blue);
    }
    public void OnChangeColorCyan()
    {
        asUIEffect.Play();
        colorIndex = 4;
        OnChangeColor(Color.cyan);
    }
    public void OnChangeColorGreen()
    {
        asUIEffect.Play();
        colorIndex = 5;
        OnChangeColor(Color.green);
    }


    public void OnPlay()
    {
        asUIEffect.Play();
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
