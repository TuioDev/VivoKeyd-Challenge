using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float maxHP = 1f;
    private float currentHP;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Can either do damage (giving negative values) or heal (positive values)
    public void ChangeHP(float value)
    {
        currentHP = Mathf.Clamp(currentHP + value, 0f, maxHP);
    }

    public float GetHP()
    {
        return currentHP;
    }

}
