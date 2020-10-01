using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text Mettext;
    public static float Metcount;
    private void Awake()
    {
        Metcount = 10;

    }
    private void Update()
    {
        Mettext.text = "摧毀隕石: "+Metcount;
    }
}
