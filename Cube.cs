using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
	/* Use Lerp and wait to prevent jerky changes */
    private bool waiting = false;
	/* Use Lerp and wait to prevent jerky changes */

	/* Color related variables */
    public MeshRenderer Renderer;
    public float colorChangeRate;
    private Color randomColor;
	/* Color related variables */
	
	/* Position related variables */
    public float xRange;
    public float yRange;
    public float zRange;
    public float posVelocity;
    private Vector3 randomPos;
	/* Position related variables */
	
	/* Rotation related variables */
    public float rotationSpeed;
    private Quaternion randomRotation;
	/* Rotation related variables */
	
	/* Scale related variables */
    public float scaleChangeRate;
    public float maxXScale;
    public float maxYScale;
    public float maxZScale;
    private Vector3 randomScale;
	/* Scale related variables */
	
	/* Start function */
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.localScale = Vector3.one * 1.3f;
        
        Material material = Renderer.material;
        
        material.color = new Color(1, 1, 1, 1);
    }
    
	/* update function */
    void Update()
    {
        if (!waiting)
        {
			/* Get new random values for all 4 states every 1 sec*/
            StartCoroutine(LerpCube());
        }
        else
        {
			/* Lerp to the randomly chosen value for all 4 states for 1 sec*/
            Renderer.material.color = Color.Lerp(Renderer.material.color, randomColor, Time.deltaTime * colorChangeRate / 100);
            transform.position = Vector3.Lerp(transform.position, randomPos, Time.deltaTime * posVelocity / 100);
            transform.rotation = Quaternion.Lerp(transform.rotation, randomRotation, Time.deltaTime * rotationSpeed / 100);
            transform.localScale = Vector3.Lerp(transform.localScale, randomScale, Time.deltaTime * scaleChangeRate / 100);
        }
    }
	
	/* Randmly choose values for all 4 states and wait for 1 sec to lerp before new cycle */
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
