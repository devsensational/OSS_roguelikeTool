using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int hp = 3;
    public GameObject heart_1;
    public GameObject heart_2;
    public GameObject heart_3;
    // Start is called before the first frame update
    void Start()
    {
        heart_1.SetActive(true);
        heart_2.SetActive(true);
        heart_3.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(hp == 3){
            heart_1.SetActive(true);
            heart_2.SetActive(true);
            heart_3.SetActive(true);
        }
        else if(hp == 2){
            heart_1.SetActive(true);
            heart_2.SetActive(true);
            heart_3.SetActive(false);
        }
        else if(hp == 1){
            heart_1.SetActive(true);
            heart_2.SetActive(false);
            heart_3.SetActive(false);
        }
    }
}
