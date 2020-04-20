using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float endX;
    private float startX;
    private float startY;

    float counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        float percentage = counter / 24f;
        float x = Mathf.Lerp(startX, endX, percentage);
        float yVariance = Mathf.PingPong(Time.time*2 * Random.Range(1,1.1f), 0.1f);
        transform.position = new Vector3(x, startY + yVariance, transform.position.z);

        if (percentage > 1)
        {
            //Start game
            SceneChanger.instance.LoadGame();
        }
    }

    public void skipIntro()
    {
        SceneChanger.instance.LoadGame();
    }
}
