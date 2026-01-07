using UnityEngine;

public class Inputs : MonoBehaviour
{
    public float Speed, SpeedRot;
    void Start()
    {
        
    }

    void Update()
    {
        // transform.position = transform.position + new Vector3(Input.GetAxis("Horizontal"),
        //  Input.GetAxis("Vertical"), 0) * Speed * Time.deltaTime;

        // transform.Translate(Input.GetAxis("Horizontal") * Speed * Time.deltaTime,
        //   Input.GetAxis("Vertical") * Speed * Time.deltaTime, 0);

        // if (transform.position.y >= 5)
        // {
        //     transform.position = new Vector3(transform.position.x, -5, transform.position.z);
        // }

        // else if (transform.position.y <= -5)
        // {
        //     transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        // }

        // if (transform.position.x >= 9)
        // {
        //     transform.position = new Vector3(-9, transform.position.y, transform.position.z);
        // }

        // else if (transform.position.x <= -9)
        // {
        //     transform.position = new Vector3(9, transform.position.y, transform.position.z);
        // }
        // if (Input.GetMouseButton(0))
        // {
        //     transform.localRotation *= Quaternion.Euler(0, 0, SpeedRot * Input.GetAxis("Mouse X") * Time.deltaTime);

        //     transform.localEulerAngles += new Vector3(0, 0, SpeedRot * Input.GetAxis("Mouse X") * Time.deltaTime);
        // }

        // transform.Translate(0, Input.GetAxis("Vertical") * Speed * Time.deltaTime, 0);

        //print(Input.GetAxis("Mouse ScrollWheel"));


    }
}
