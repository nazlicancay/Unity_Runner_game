using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameManager gm;
   public float cameraspeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.isGameActive)
        {
            transform.position += new Vector3(0, 0, cameraspeed * Time.deltaTime);

        }



    }

}
