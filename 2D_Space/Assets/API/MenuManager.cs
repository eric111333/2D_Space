using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void Playstart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
