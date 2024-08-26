using UnityEngine;

public class EquipmentSystem : MonoBehaviour, IColliderManager
{
    [SerializeField] GameObject weaponHolder;
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject weaponSheath;
    [SerializeField] Collider weaponCollider; // Reference to the weapon's collider

    GameObject currentWeaponInHand;
    GameObject currentWeaponInSheath;

    private void Start()
    {
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
        weaponCollider = currentWeaponInSheath.GetComponentInChildren<Collider>(); // Assuming collider is a child
        weaponCollider.enabled = false; // Initially disable the collider
    }

    public void DrawWeapon()
    {
        if (currentWeaponInHand != null)
        {
            Destroy(currentWeaponInHand);
        }

        currentWeaponInHand = Instantiate(weapon, weaponHolder.transform);
        weaponCollider = currentWeaponInHand.GetComponentInChildren<Collider>(); // Assuming collider is a child
        weaponCollider.enabled = false; // Disable collider until attack
        Destroy(currentWeaponInSheath);
    }

    public void SheathWeapon()
    {
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
        weaponCollider.enabled = false; // Ensure the collider is disabled when sheathed
        Destroy(currentWeaponInHand);
    }

    public void SetColliderActive(bool isActive)
    {
        if (weaponCollider != null)
        {
            weaponCollider.enabled = isActive;
        }
    }
}
