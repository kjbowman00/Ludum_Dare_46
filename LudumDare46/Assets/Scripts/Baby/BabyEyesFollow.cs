using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyEyesFollow : MonoBehaviour
{
    public GameObject player;
    public float playerMinX, playerMaxX, playerMinY, playerMaxY;
    public float eyesMinX, eyesMaxX, eyesMinY, eyesMaxY;

    private float playerTotalSizeX, playerTotalSizeY;
    private float eyeTotalSizeX, eyeTotalSizeY;

    // Start is called before the first frame update
    void Start()
    {
        playerTotalSizeX = playerMaxX - playerMinX;
        playerTotalSizeY = playerMaxY - playerMinY;
        eyeTotalSizeX = eyesMaxX - eyesMinX;
        eyeTotalSizeY = eyesMaxY - eyesMinY;
    }

    // Update is called once per frame
    void Update()
    {
        float pX = player.transform.position.x;
        float percentageX = (pX - playerMinX) / playerTotalSizeX;
        float pY = player.transform.position.y;
        float percentageY = (pY - playerMinY) / playerTotalSizeY;

        float eyePosX = eyesMinX + eyeTotalSizeX * percentageX;
        float eyePosY = eyesMinY + eyeTotalSizeY * percentageY;
        transform.position = new Vector3(eyePosX, eyePosY, transform.position.z);
    }
}
