using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private Player player;

    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Use this for initialization
    void Start()
    {
        UpdateWeapon(weapon);

        HandleEvents(true);
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputs();
    }

    private void OnDestroy()
    {
        HandleEvents(false);
    }

    private void HandleEvents(bool switcher)
    {
        if (switcher)
        {
            EventsManager.OnUpdateWeapon += UpdateWeapon;
        }
        else
        {
            EventsManager.OnUpdateWeapon -= UpdateWeapon;
        }
    }

    public void Shoot()
    {
        Instantiate(weapon.Ammunition, gameObject.transform.position, player.transform.rotation);
    }

    public void UpdateWeapon(Weapon weapon)
    {
        this.weapon = weapon;

        meshFilter.mesh = weapon.Mesh;
        meshRenderer.material = weapon.Material;

        transform.localPosition = weapon.Position;
        transform.localEulerAngles = weapon.Rotation;
    }

    public Weapon ReturnCurrentWeapon()
    {
        return weapon;
    }

    private void HandleInputs()
    {
        if (Input.GetMouseButtonDown(0) && Flags.Instance.GamePlaying)
        {
            Shoot();
        }
    }
}
