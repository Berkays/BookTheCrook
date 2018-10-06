using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderTest : MonoBehaviour
{
    float value = 0f;
    bool increase = true;
    new MeshRenderer renderer;
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }
    void Update()
    {

        renderer.material.SetFloat("Vector1_40886D97", value);

        if (increase)
            value += Time.deltaTime * 0.2f;
        else
            value -= Time.deltaTime * 0.2f;
        if (value >= 0.4f)
            increase = false;
        else if (value <= 0.2f)
            increase = true;

    }
}
