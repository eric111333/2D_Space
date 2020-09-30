using UnityEngine;

public class creatMet : MonoBehaviour
{
    public GameObject Met;

    private void CreatMeteorite()
    {
        float x = Random.Range(-18, 18);
        float y = Random.Range(-18, 18);
        Vector3 pos = new Vector3(x, y, 0);
        Instantiate(Met, pos, Quaternion.identity);
    }
    private void Start()
    {
        float r = Random.Range(1, 5);
        float s = Random.Range(1, 5);
        InvokeRepeating("CreatMeteorite", r, s);
    }
}
