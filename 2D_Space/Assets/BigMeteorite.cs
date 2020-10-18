using UnityEngine;

public class BigMeteorite : MonoBehaviour
{
    private float speedx;
    private float speedy;
    private Rigidbody2D rig;
    public GameObject Met;
    private int dieone;
    // Start is called before the first frame update
    private void Awake()
    {
        speedx = Random.Range(-2, 2);
        speedy = Random.Range(-2, 2);
        rig = GetComponent<Rigidbody2D>();
        dieone = 1;
    }
    void Start()
    {
        rig.velocity = new Vector2(speedx, speedy);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Spiked Ball"&& dieone == 1)
        {
            Vector3 pos = new Vector3(gameObject.transform.position.x+Random.Range(-5,5), gameObject.transform.position.y + Random.Range(-5, 5),0);
            Vector3 pos1 = new Vector3(gameObject.transform.position.x + Random.Range(-5, 5), gameObject.transform.position.y + Random.Range(-5, 5), 0);
            Vector3 pos2 = new Vector3(gameObject.transform.position.x + Random.Range(-5, 5), gameObject.transform.position.y + Random.Range(-5, 5), 0);
            Instantiate(Met, pos, Quaternion.identity);
            Instantiate(Met, pos1, Quaternion.identity);
            Instantiate(Met, pos2, Quaternion.identity);
            dieone--;
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
