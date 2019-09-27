using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 50f;
    public GameObject floatingTextPrefab;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }

        if (floatingTextPrefab && health > 0)
        {
            var floatTextGo = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
            floatTextGo.GetComponent<TextMesh>().text = amount.ToString();
        }
        
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
