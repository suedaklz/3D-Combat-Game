using TMPro;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public int damage = 3;
    public EnemyHealth _enemyHealth;
    public GameObject bloodEffect;
    public GameObject damageTextGo;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Sword"))
        {
            Debug.Log("Enemy + sword collision");
            _enemyHealth.TakeDamage(damage);
            var text = damageTextGo.GetComponent<TextMeshPro>().text;
            text = '-' + damage.ToString();
            Debug.Log("damage text: " + text);
             
            Vector3 collisionPoint = collider.ClosestPoint(transform.position);
            var blood = Instantiate(bloodEffect, collisionPoint, Quaternion.identity, transform);
            var damageUI = Instantiate(damageTextGo, collisionPoint, Quaternion.identity, transform);
            Destroy(blood, 1f);
        }
    }
}
