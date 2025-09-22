using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CasinoLight : MonoBehaviour
{
    public Light lightOB;
    public AudioSource lightSound;
    public float minTime;
    public float maxTime;
    public float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = Random.Range(minTime, maxTime);
    }
    // Update is called once per frame
    void Update()
    {
            if (timer > 0)
                timer -= Time.deltaTime;
            if (timer<=0)
            {
                lightOB.enabled = !lightOB.enabled;
                timer = Random.Range(minTime, maxTime);
            
            }
    }
}
