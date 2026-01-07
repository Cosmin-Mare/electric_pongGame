using UnityEngine;
using System;
using TMPro;


public class PongManager : MonoBehaviour
{
    //Variables needed
    public GameObject Sphere;
    public float Speed, Z_Rot;
    public float BottomLimit, LeftLimit;
    public bool TouchedUp, TouchedDown, TouchedLeft, TouchedRight;
    public GameObject Player1, Player2;
    public float TimerUp, TimerDown, RespawnTimer, TimerRight, TimerLeft;
    public GameObject Canvas;
    public bool StartIngition;
    public bool RightLeftTouch;
    public float blinkTimer;
    public TextMeshProUGUI ArrayText;
    public int Score;

    // Adjustment Variables
    public float Adjustment;
    public float DectectingDistance;
    public float RotationFactor;
    void Start()
    {
        Ignition();
    }

    void Update()
    {
        Sphere.transform.localEulerAngles = new Vector3(0, 0, Z_Rot);
        Sphere.transform.Translate(Speed * Time.deltaTime, 0, 0);

        if ((Mathf.DeltaAngle(0, Z_Rot) > 70 && Mathf.DeltaAngle(0, Z_Rot) < 110) ||
         (Mathf.DeltaAngle(0, Z_Rot) < -70 && Mathf.DeltaAngle(0, Z_Rot) > -110))
        {
            StartIngition = true;
        }



        TouchLimit(val => val <= LeftLimit, 180 - Z_Rot, Adjustment, 0, Sphere.transform.position.x, ref TouchedLeft);
        TouchLimit(val => val >= -LeftLimit, 180 - Z_Rot, -Adjustment, 0, Sphere.transform.position.x, ref TouchedRight);
        TouchLimit(val => val <= BottomLimit, -Z_Rot, 0, Adjustment, Sphere.transform.position.y, ref TouchedDown);
        TouchLimit(val => val >= -BottomLimit, -Z_Rot, 0, -Adjustment, Sphere.transform.position.y, ref TouchedUp);

        ArrayText.text = "            Score " + Score;

        TouchConsequenses(ref TouchedLeft, 7, ref TimerLeft, "Player 2");
        TouchConsequenses(ref TouchedRight, 6, ref TimerRight, "Player 1");

        if (!RightLeftTouch)
        {
            TouchConsequenses(ref TouchedUp, 1, ref TimerUp, "");
            TouchConsequenses(ref TouchedDown, 3, ref TimerDown, "");
        }

        PlayerBounce(Player1, 0.5f);
        PlayerBounce(Player2, -0.5f);

        RespawnTheBall();




    }

    public void Ignition()
    {
        int tempint = UnityEngine.Random.Range(1, 3);

        if (tempint == 1)
        {
            Z_Rot = UnityEngine.Random.Range(-45, 46);
        }

        else
        {
            Z_Rot = UnityEngine.Random.Range(135, 226);
        }

        Sphere.transform.position = new Vector3(0, 0, Sphere.transform.position.z);
    }

    public void TouchLimit(Func<float, bool> condition, float NewZ_Rot, float Adjustment1, float Adjustment2, float Position, ref bool Touched)
    {
        if (condition(Position))
        {
            Sphere.transform.position = new Vector3(Sphere.transform.position.x + Adjustment1,
             Sphere.transform.position.y + Adjustment2, Sphere.transform.position.z);
            Touched = true;
            Z_Rot = NewZ_Rot;
        }
    }

    public void TouchConsequenses(ref bool Touched, int MyInt, ref float Timer, string Player)
    {
        if (Touched)
        {
            if (TouchedLeft || TouchedRight)
            {
                RightLeftTouch = true;
            }
            Timer = 0;
            Canvas.transform.GetChild(MyInt).gameObject.SetActive(false);
            Touched = false;
            
        }

        if (Timer <= 5)
        {
            Timer = Timer + Time.deltaTime;

            if (RightLeftTouch)
            {
                blinkTimer += Time.deltaTime;
                Speed = 1;
                ArrayText.text = Player + " wins";
                Score = 0;

                if (blinkTimer <= 0.3f)
                {
                    Canvas.transform.GetChild(1).gameObject.SetActive(false);
                    Canvas.transform.GetChild(3).gameObject.SetActive(false);
                }

                else if (blinkTimer <= 0.6f)
                {
                    Canvas.transform.GetChild(1).gameObject.SetActive(true);
                    Canvas.transform.GetChild(3).gameObject.SetActive(true);
                }

                else
                {
                    blinkTimer = 0;
                }
            }
        }

        else if (Timer > 5 && TimerLeft > 5 && TimerRight > 5)
        {
            Canvas.transform.GetChild(MyInt).gameObject.SetActive(true);
            if (RightLeftTouch)
            {
                Speed = 5;
                Ignition();
                Sphere.gameObject.GetComponent<TrailRenderer>().Clear();
            }
            RightLeftTouch = false;
        }

    }

    public void PlayerBounce(GameObject Player, float Adjustment2)
    {
        for (int i = 0; i < Player.transform.childCount; i++)
        {
            //print(Vector3.Distance(Sphere.transform.position, Player1.transform.GetChild(i).position) + "   " + Player1.transform.GetChild(i).name);
            if (Vector3.Distance(Sphere.transform.position, Player.transform.GetChild(i).position) < DectectingDistance)
            {
                Z_Rot = 180 - Z_Rot - RotationFactor * int.Parse(Player.transform.GetChild(i).name);

                Sphere.transform.position = new Vector3(Sphere.transform.position.x + Adjustment2, Sphere.transform.position.y,
                 Sphere.transform.position.z);

                Score++;

            }
        }
    }

    public void RespawnTheBall()
    {
        if (StartIngition && RespawnTimer < 5)
        {
            RespawnTimer = RespawnTimer + Time.deltaTime;
            Sphere.gameObject.GetComponent<TrailRenderer>().enabled = false;
        }

        if (RespawnTimer >= 5 - 0.001f)
        {
            Ignition();
            StartIngition = false;
            RespawnTimer = 0;
            Sphere.gameObject.GetComponent<TrailRenderer>().enabled = true;
        }

        
    }
}
