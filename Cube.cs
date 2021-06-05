using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private bool waiting = false;

    public MeshRenderer Renderer;
    public float colorChangeRate;
    private Color randomColor;

    public float xRange;
    public float yRange;
    public float zRange;
    public float posVelocity;
    private Vector3 randomPos;

    public float rotationSpeed;
    private Quaternion randomRotation;

    public float scaleChangeRate;
    public float maxXScale;
    public float maxYScale;
    public float maxZScale;
    private Vector3 randomScale;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.localScale = Vector3.one * 1.3f;
        
        Material material = Renderer.material;
        
        material.color = new Color(1, 1, 1, 1);
    }
    
    void Update()
    {
        if (!waiting)
        {
            StartCoroutine(LerpCube());
        }
        else
        {
            Renderer.material.color = Color.Lerp(Renderer.material.color, randomColor, Time.deltaTime * colorChangeRate / 100);
            transform.position = Vector3.Lerp(transform.position, randomPos, Time.deltaTime * posVelocity / 100);
            transform.rotation = Quaternion.Lerp(transform.rotation, randomRotation, Time.deltaTime * rotationSpeed / 100);
            transform.localScale = Vector3.Lerp(transform.localScale, randomScale, Time.deltaTime * scaleChangeRate / 100);
        }
    }

    IEnumerator LerpCube()
    {
        randomPos = new Vector3(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange), Random.Range(-zRange, zRange));
        randomRotation = new Quaternion(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        randomColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        randomScale = new Vector3(Random.Range(1.0f, maxXScale), Random.Range(1.0f, maxYScale), Random.Range(1.0f, maxZScale));
        waiting = true;
        yield return new WaitForSeconds(1);
        waiting = false;
    }

}
