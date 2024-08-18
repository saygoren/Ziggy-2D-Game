using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] ParticleSystem sparksParticle;
    [SerializeField] ParticleSystem smokeParticle;
    [SerializeField] ParticleSystem impactPartical;

    private Quaternion targetRotationPositive = Quaternion.Euler(0, 0, 45);
    private Quaternion targetRotationNegative = Quaternion.Euler(0, 0, -45);
    private float rotationSpeed = .1f;

    

    void Start()
    {
        PlayerManager.instance.PlayerHitground += PlayerManager_PlayerHitGround;
        PlayerController.instance.MouseClikEnable += PlayerController_MouseClickEnable;
        PlayerController.instance.MouseClickDisable += PlayerController_MouseClickDisable;
    }

    private void PlayerController_MouseClickEnable(object sender, System.EventArgs e)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotationPositive, rotationSpeed);
    }

    private void PlayerController_MouseClickDisable(object sender, System.EventArgs e)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotationNegative, rotationSpeed);
    }


    private void PlayerManager_PlayerHitGround(object sendler, System.EventArgs e)
    {
        sparksParticle.Play();
        smokeParticle.Play();
        impactPartical.Play();
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<TrailRenderer>().enabled = false;
        Debug.Log("Çarpýþma");
    }

}
