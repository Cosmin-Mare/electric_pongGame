using UnityEngine;

public class Player2Control : MonoBehaviour
{
    public float Speed;
    void Start()
    {
        
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.y) <= 5.31f)
        {
            transform.Translate(Input.GetAxis("VerticalWS") * Speed * Time.deltaTime, 0, 0);
        }

        else if (transform.position.y < 0 && Input.GetAxis("VerticalWS") <= 0)
        {
            transform.Translate(Input.GetAxis("VerticalWS") * Speed * Time.deltaTime, 0, 0);
        }

        else if (transform.position.y > 0 && Input.GetAxis("VerticalWS") >= 0)
        {
            transform.Translate(Input.GetAxis("VerticalWS") * Speed * Time.deltaTime, 0, 0);
        }
    }
}
