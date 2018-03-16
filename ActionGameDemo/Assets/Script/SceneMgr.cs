using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    public static SceneMgr Instance;
    public GameObject PanelResult;
    public GameObject ImgWin;
    public GameObject ImgFail;

    [HideInInspector]
    public bool IsPlayerAlive = true;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine("CheckGameEnd");
    }

    IEnumerator CheckGameEnd()
    {
        while (IsPlayerAlive && (SpawnManager.Instance && (!SpawnManager.Instance.IsFinishSpwan || SpawnManager.Instance.enemyList.Count > 0)))
        {
            yield return new WaitForSeconds(1f);
        }

        GameOver(IsPlayerAlive);
    }

    public void GameOver(bool IsWin)
    {
        DisplayResult(IsWin);
        CleanGround();
    }

    public void GameReplay()
    {
        SceneManager.LoadScene("002-Play");
    }

    public void GameExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void CleanGround()
    {
        GameObject[] drops = GameObject.FindGameObjectsWithTag(Tags.dropItem);
        foreach (var drop in drops)
        {
            Destroy(drop);
        }
    }

    public void DisplayResult(bool IsWin)
    {
        PanelResult.SetActive(true);
        ImgWin.SetActive(IsWin);
        ImgFail.SetActive(!IsWin);
    }
}
