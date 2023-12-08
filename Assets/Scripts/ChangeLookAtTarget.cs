using UnityEngine;
using System.Collections;
using System.Numerics;

public class ChangeLookAtTarget : MonoBehaviour {



	public GameObject target; // the target that the camera should look at
	private AudioSource audioSource; //acessar a propriedade audiosource
	void Start()
	{
		if (target == null)
		{
			target = this.gameObject;
			Debug.Log("ChangeLookAtTarget target not specified. Defaulting to parent GameObject");
		}

		audioSource = target.GetComponent<AudioSource>();
		if (audioSource == null)
		{
			Debug.LogError("ChangeLookAtTarget: AudioSource não encontrado no objeto alvo.");
		}

		//DesligarTodosOsSons();
		audioSource.Play();
	}

    private void DesligarTodosOsSons()
    {
        // Encontre todos os objetos na cena com um componente AudioSource
        AudioSource[] audioSources = FindObjectsByType<AudioSource>(FindObjectsSortMode.InstanceID);

        // Itere por todos os objetos com AudioSource e pare a reprodução
        foreach (AudioSource source in audioSources)
        {
            if (source.isPlaying)
            {
                source.Stop();
            }
        }
    }

    // Called when MouseDown on this gameObject
    void OnMouseDown () {
		// change the target of the LookAtTarget script to be this gameobject.
		LookAtTarget.target = target;
		Camera.main.fieldOfView = 60*target.transform.localScale.x;
        DesligarTodosOsSons();
		PlayMusic();

    }
	void PlayMusic(){
		// Verifica se o componente AudioSource foi encontrado
		if (audioSource != null) {
			
			// Ativa o AudioSource se estiver desativado
			if (!audioSource.enabled) {
				audioSource.enabled = true;
			}
			// Ativa o som
			audioSource.Play();
		} else {
			Debug.LogError("ChangeLookAtTarget: AudioSource não encontrado no objeto alvo. Som não pode ser reproduzido.");
		}
	}
}