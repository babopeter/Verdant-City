using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private float growthRate;

    private float maxScale;
    [Range(0.001f, 0.15f)] public float environmentalEffect;
    // Start is called before the first frame update
    void Start()
    {
        HandleEnvironment.newEnvironmentHealth = HandleEnvironment.newEnvironmentHealth - environmentalEffect;
        growthRate = Random.Range(0.02f, 0.07f);
        maxScale = Random.Range(0.8f, 1.3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale =
            Vector3.Lerp(transform.localScale, new Vector3(maxScale, maxScale, maxScale), growthRate * Time.deltaTime);
    }
}
