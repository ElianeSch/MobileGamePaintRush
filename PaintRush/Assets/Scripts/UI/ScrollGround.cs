using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollGround : MonoBehaviour
{
    public float speed = 35;
    public Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (PauseManager.gameIsPaused == false)
            renderer.material.mainTextureOffset += new Vector2(0,-speed*Time.deltaTime);
    }
}
