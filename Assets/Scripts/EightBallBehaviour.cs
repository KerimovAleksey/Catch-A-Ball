using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EightBallBehaviour : MonoBehaviour
{
    public float XSpeed;
    public float YSpeed;
    public float ZSpeed;
    public float Multiplier = 0.75F;
    static int BallCount = 0;
    public int ballNumber;
    public int TooFar = 5;

    // Start is called before the first frame update
    void Start()
    {
        BallCount++;
        ballNumber = BallCount;
        ResetBall();
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Time.deltaTime * XSpeed, Time.deltaTime * YSpeed, Time.deltaTime * ZSpeed);
        XSpeed += Multiplier - Random.value * Multiplier * 2;
        YSpeed += Multiplier - Random.value * Multiplier * 2;
        ZSpeed += Multiplier - Random.value * Multiplier * 2;

        if ((Mathf.Abs(transform.position.x) > TooFar) || (Mathf.Abs(transform.position.y) > TooFar) || (Mathf.Abs(transform.position.z) > TooFar))
        {
            ResetBall();
        }

        /*
        Vector3 axis = new Vector3(XRotation, YRotation, ZRotation);
        transform.RotateAround(Vector3.zero, axis, DegreesPerSecond * Time.deltaTime);
        */
    }

	private void OnMouseDown()
	{
        
		GameController  controller = Camera.main.GetComponent<GameController>();
        if (!controller.gameover)
        {
            controller.ClickedOnBall();
            Destroy(gameObject);

        }
	}
    public void ResetBall()
    {
		XSpeed = Random.value * Multiplier;
		YSpeed = Random.value * Multiplier;
		ZSpeed = Random.value * Multiplier;
		transform.position = new Vector3(3 - Random.value * 6, 3 - Random.value * 6, 3 - Random.value * 6);
	}

}
