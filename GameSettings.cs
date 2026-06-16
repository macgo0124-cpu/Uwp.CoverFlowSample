using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Daño")]
    public float baseDamage = 300f;
    public float shortRangeMultiplier = 2f;
    public float mediumRangeMultiplier = 1.5f;

    [Header("Apuntado")]
    public float aimAssistStrength = 100f;
    public float aimAssistRange = 50f;

    [Header("Retroceso")]
    public float verticalRecoil = 0f;
    public float horizontalRecoil = 0f;

    private void Update()
    {
        ApplySettings();
    }

    private void ApplySettings()
    {
        // Mantener retroceso desactivado
        verticalRecoil = 0f;
        horizontalRecoil = 0f;

        // Aquí puedes aplicar otras configuraciones
        // a tu sistema de disparo, cámara o apuntado.
    }

    public float GetDamage(float distance)
    {
        if (distance <= 10f)
            return baseDamage * shortRangeMultiplier;

        if (distance <= 30f)
            return baseDamage * mediumRangeMultiplier;

        return baseDamage;
    }
}