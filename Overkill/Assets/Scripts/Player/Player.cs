using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Skin PlayerSkin;
    public GameObject CharacterGFX;

    [SerializeField] private float rotateFullSpeed;
    [SerializeField] private bool rotateLeft;

    [SerializeField] private float maxRotationPoint = 0.5f;

    [SerializeField] private PlayerStats playerStats;

    // Use this for initialization
    void Start()
    {
        HandleEvents(true);

        CreateCharacter(PlayerSkin);
    }

    // Update is called once per frame
    void Update()
    {
        if (Flags.Instance.GamePlaying)
        {
            CheckRotation();
            RotateCharacter();
        }
        else
        {
            RotateFull();
        }
    }

    private void OnDestroy()
    {
        HandleEvents(false);
    }

    private void HandleEvents(bool switcher)
    {
        if (switcher)
        {
            EventsManager.OnGameStateChange += ResetRotation;
            EventsManager.OnSkinUpdate += CreateCharacter;
        }
        else
        {
            EventsManager.OnGameStateChange -= ResetRotation;
            EventsManager.OnSkinUpdate -= CreateCharacter;
        }
    }

    private void ResetRotation(bool playGame)
    {
        if (playGame)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }

    public void RotateCharacter()
    {
        if (rotateLeft)
        {
            transform.Rotate(0f, -playerStats.rotateSpeed * Time.deltaTime, 0f);
        }
        else
        {
            transform.Rotate(0f, playerStats.rotateSpeed * Time.deltaTime, 0f);
        }
    }

    private void RotateFull()
    {
        transform.Rotate(0f, rotateFullSpeed * Time.deltaTime, 0f);
    }

    private void CheckRotation()
    {
        Quaternion currentRotation = transform.rotation;

        if (currentRotation.y >= maxRotationPoint)
        {
            rotateLeft = true;
        }
        else if (currentRotation.y <= -maxRotationPoint)
        {
            rotateLeft = false;
        }
    }

    public void CreateCharacter(Skin skin)
    {
        PlayerSkin = skin;

        if (CharacterGFX != null)
        {
            Destroy(CharacterGFX);
        }

        CharacterGFX = Instantiate(PlayerSkin.SkinPrefab, transform.position + PlayerSkin.Position, transform.rotation);

        CharacterGFX.transform.SetParent(this.transform, true);
    }
}
