using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public GameObject bottomLayer;
    public GameObject middleLayer;
    public GameObject topLayer;

    [SerializeField] private float bottomLayerSpeed = 10f;
    [SerializeField] private float middleLayerSpeed = 15f;
    [SerializeField] private float topLayerSpeed = 20f;

    private Vector3 startPosition;
    
    // Start is called before the first frame update
    private void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        MoveLayer(middleLayer, middleLayerSpeed);
    }

    private void MoveLayer(GameObject layer, float speed)
    {
        float newPosition = Mathf.Repeat(Time.time * speed, 5);
        transform.position = startPosition + Vector3.forward * newPosition;
    }

    public void SetSpeed(float bottomLayerSpeed, float middleLayerSpeed, float topLayerSpeed)
    {
        this.bottomLayerSpeed = bottomLayerSpeed;
        this.middleLayerSpeed = middleLayerSpeed;
        this.topLayerSpeed = topLayerSpeed;
    }

    public void SetBottomLayerSpeed(float bottomLayerSpeed)
    {
        this.bottomLayerSpeed = bottomLayerSpeed;
    }

    public void SetMiddleLayerSpeed(float middleLayerSpeed)
    {
        this.middleLayerSpeed = middleLayerSpeed;
    }

    public void SetTopLayerSpeed(float topLayerSpeed)
    {
        this.topLayerSpeed = topLayerSpeed;
    }
}
