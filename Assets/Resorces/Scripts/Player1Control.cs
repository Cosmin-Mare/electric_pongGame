using UnityEngine;

public class Player1Control : MonoBehaviour
{
    public float Speed;
    void Start()
    {
        
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.y) <= 5.31f)
        {
            transform.Translate(Input.GetAxis("VerticalArrows") * Speed * Time.deltaTime, 0, 0);
        }

        else if (transform.position.y < 0 && Input.GetAxis("VerticalArrows") >= 0)
        {
            transform.Translate(Input.GetAxis("VerticalArrows") * Speed * Time.deltaTime, 0, 0);
        }

        else if (transform.position.y > 0 && Input.GetAxis("VerticalArrows") <= 0)
        {
            transform.Translate(Input.GetAxis("VerticalArrows") * Speed * Time.deltaTime, 0, 0);
        }
        
    }
}
