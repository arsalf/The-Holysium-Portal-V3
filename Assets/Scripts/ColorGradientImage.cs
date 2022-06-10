using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorGradientImage : MonoBehaviour
{
    [SerializeField] private Gradient AlbedoTint;
    [SerializeField] private float duration = 5f;
    [SerializeField] private Image myImage;

    private float CurrentTime = 0f;

    // Update is called once per frame
    void Update()
    {
        CurrentTime = Mathf.Repeat(CurrentTime + Time.deltaTime, duration);

        var newColor = AlbedoTint.Evaluate(CurrentTime / duration);

        myImage.color = newColor;
        
    }
}
