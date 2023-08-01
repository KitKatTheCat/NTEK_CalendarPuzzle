using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSounds : MonoBehaviour
{
    [SerializeField] private AudioSource buttonTrigger;
    // Start is called before the first frame update
    public void ButtonSound()
    {
        buttonTrigger.Play();
    }
}
