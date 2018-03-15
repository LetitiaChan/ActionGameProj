using UnityEngine;
using System.Collections;

public class PlayerMiniMapSymbol : MonoBehaviour
{
    private GameObject symbolPlayer;

    void Start()
    {
        symbolPlayer = MiniMap.Instance.GetSymbolPlayer();
    }

    void Update()
    {
        float y = transform.eulerAngles.y;
        symbolPlayer.transform.localEulerAngles = new Vector3(0, 0, -y);
    }
}
