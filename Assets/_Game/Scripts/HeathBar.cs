using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class HeathBar : MonoBehaviour
{
    [SerializeField] private Image imageFill;
    [SerializeField] private Vector3 offset;
    private float hp;
    private float maxHp;
    private Transform taget;

    void Update()
    {
        imageFill.fillAmount = Mathf.Lerp(imageFill.fillAmount, hp / maxHp, Time.deltaTime * 5f);
        transform.position = taget.position + offset;
    }

    public void OnInit(float maxHp, Transform taget)
    {
        this.taget = taget;
        this.maxHp = maxHp;
        hp = maxHp;
        imageFill.fillAmount = 1;
    }

    public void SetNewHp(float hp)
    {
        this.hp = hp;
    }
}
