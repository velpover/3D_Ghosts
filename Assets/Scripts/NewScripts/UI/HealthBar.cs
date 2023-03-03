using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image _hpBar;
   
    public void ChangeBar(float hp)
    {
        _hpBar.fillAmount = hp;
    }
}
