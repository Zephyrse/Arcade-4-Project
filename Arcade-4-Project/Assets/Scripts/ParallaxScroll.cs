using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroll : MonoBehaviour
{
    private float _length, _startpos;
    public GameObject cameraObject;
    public float parallaxEffect;
    

    // Start is called before the first frame update
    private void Start()
    {
        var position = cameraObject.transform.position;
        _startpos = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    private void Update()
    {
        var position = cameraObject.transform.position;
        var temp = (position.x * (1 - parallaxEffect));
        var dist = (position.x * parallaxEffect);

        transform.position = new Vector3(_startpos + dist, transform.position.y, transform.position.z);

        if (temp > _startpos + _length) { 
            _startpos += _length; 
        }
        else if (temp < _startpos - _length) { 
            _startpos -= _length; 
        };
    }
}
