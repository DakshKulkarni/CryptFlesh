using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerHealthBar : MonoBehaviour
{
    private float health;
    private float timer;
    public float healthMax = 100;
    public float barSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;
    public TextMeshProUGUI textPrompt;
    void Start()
    {
        health = healthMax;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, healthMax);
        UpdateHealthUI();


    }
    public void UpdateHealthUI()
    {
        //Debug.Log(health);
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFrac = health / healthMax;
        if (fillB > hFrac)
        {
            frontHealthBar.fillAmount = hFrac;
            backHealthBar.color = Color.red;
            timer += Time.deltaTime;
            float percentComplete = timer / barSpeed;
            percentComplete *= percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFrac, percentComplete);
        }
        if (fillF < hFrac)
        {
            backHealthBar.fillAmount = hFrac;
            backHealthBar.color = Color.green;
            timer += Time.deltaTime;
            float percentComplete = timer / barSpeed;
            percentComplete *= percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);

        }
        TextUpdate();
        if(health==0)
        Destroy(gameObject);
    }
    public void Damage(float damage)
    {
        health -= damage;
        timer = 0f;
    }
    public void Restore(float restore)
    {
        health += restore;
        timer = 0f;
    }
    public void TextUpdate()
    {
        textPrompt.text = health.ToString() +"/100";
    }
}
