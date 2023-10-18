using UnityEngine;

public class Coin : MonoBehaviour
{
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(-1, 0) * speed * Time.deltaTime);

        if(transform.position.x < -10)
        {
            gameObject.SetActive(false);
        }
    }
}
