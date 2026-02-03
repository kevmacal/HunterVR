using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CuboController: MonoBehaviour, IInteractable
{
    [SerializeField] HealthSystem HealthManager;
    [SerializeField] ScoreSystem ScoreManager;
    public void MouseClickSelect()
    {
        String miTag=gameObject.tag;
        if (miTag.Equals("CuboVerde"))
        {
            HealthManager.Heal(20);
            //Debug.Log("Soy un cubo verde");
        }
        if (miTag.Equals("CuboRojo"))
        {
            HealthManager.TakeDamage(15);
            //Debug.Log("Soy un cubo rojo");
        }
        if (miTag.Equals("CuboAzul"))
        {
            ScoreManager.AddScore(10);
            //Debug.Log("Soy un cubo azul");
        }
    }
    void Start()
    {
        HealthManager = HealthSystem.FindFirstObjectByType<HealthSystem>();
        ScoreManager = ScoreSystem.FindFirstObjectByType<ScoreSystem>();
    }
}

internal interface IInteractable
{
    void MouseClickSelect();
}