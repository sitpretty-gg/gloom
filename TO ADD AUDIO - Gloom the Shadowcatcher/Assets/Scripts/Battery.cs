using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{

    float batteryLife = 0.4f;
    [SerializeField] float drainRate;
    [SerializeField] Transform batteryTransform;

    [SerializeField] LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReduceBatteryLife()
    {
        batteryLife -= drainRate;

        var currentY = batteryLife;
        Vector3 newPos = new Vector3(0.12f, currentY, 0);
        batteryTransform.localScale = newPos;

        if (batteryLife <= 0)
        {
            levelManager.GameOver();
        }
    }
}

