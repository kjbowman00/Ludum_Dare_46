using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyMonitor : MonoBehaviour
{
    public GameObject gameEndManager;
    public PipeManager pipeManager;
    public float milkDrinkRate;
    public float healthDrainRate;

    public GameObject healthBar;
    public GameObject milkBar;
    static float health;
    static float milk;

    const float MAX_HEALTH = 100;
    const float MAX_MILK = 100;
    private float maxScale;

    // Start is called before the first frame update
    void Start()
    {
        health = MAX_HEALTH;
        milk = MAX_MILK;
        maxScale = healthBar.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        milk -= Time.deltaTime * milkDrinkRate;
        milk += pipeManager.getMilkFlow() * Time.deltaTime;
        milk = Mathf.Clamp(milk, 0, MAX_MILK);
        if (milk <= 0) health -= Time.deltaTime * healthDrainRate;
        updateGraphics();
        if (health <= 0) gameEndManager.GetComponent<GameEndManager>().outOfHealth();
    }

    void updateGraphics()
    {
        float healthP = health / MAX_HEALTH;
        healthBar.transform.localScale = new Vector3(healthBar.transform.localScale.x, maxScale * healthP, healthBar.transform.localScale.z);

        float milkP = milk / MAX_MILK;
        milkBar.transform.localScale = new Vector3(milkBar.transform.localScale.x, maxScale * milkP, milkBar.transform.localScale.z);
    }
}
