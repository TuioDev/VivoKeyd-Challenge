using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer buttonSR;
    public Sprite buttonDefault;
    public Sprite buttonPressed;

    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        buttonSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            buttonSR.sprite = buttonPressed;
        }

        if (Input.GetKeyUp(keyToPress))
        {
            buttonSR.sprite = buttonDefault;
        }
    }
}
