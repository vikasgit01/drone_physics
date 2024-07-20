using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This component is attached to the GameManager GameObject
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //Input Variables
    [Space(10),Header("=====Player Input=====")]
    public KeyCode forwardMovement = KeyCode.W;
    public KeyCode backwardMovement = KeyCode.S;
    public KeyCode leftMovement = KeyCode.A;
    public KeyCode rightMovement = KeyCode.D;
    public KeyCode upMovement = KeyCode.UpArrow;
    public KeyCode downMovement = KeyCode.DownArrow;

    public KeyCode leftRotate = KeyCode.Q;
    public KeyCode rightRotate = KeyCode.E;

    public KeyCode engineStartStop = KeyCode.F;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(instance);

    }

    private void Start()
    {
        
    }

    private void Update()
    {
       
    }


}
