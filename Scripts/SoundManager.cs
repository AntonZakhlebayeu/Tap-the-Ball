using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager Instance;
	public AudioSource MyFX;
	public AudioSource BackgroundMusicGame;
	public AudioSource BackgroundMusic;

	public AudioClip ClickFX;

	public AudioSource SoundDFX;
	public AudioClip CollectCoinSound;
	public AudioClip FallingSound;
	public AudioClip CollisionSound;

	private bool _IsFallingSoundPlayed = false;


	private void Awake()
	{

		if (Instance == null)
		{
			Instance = this;
		}
	}

	public void ClickSound()
	{
		if (!UIManager.IsDisEffects) MyFX.PlayOneShot(ClickFX);
	}

	public void CollectCoin()
	{
		if (!UIManager.IsDisEffects) AudioSource.PlayClipAtPoint(CollectCoinSound, transform.position, 0.2f);
	}

	public void DeathByFalling()
	{
		if (!_IsFallingSoundPlayed)
		{
			if (!UIManager.IsDisEffects) SoundDFX.PlayOneShot(FallingSound);
			_IsFallingSoundPlayed = true;
		}
	}

	public void DeathByCollision()
	{
		if (!UIManager.IsDisEffects) SoundDFX.PlayOneShot(CollisionSound);
	}

	public static void BackgroundMusicInMenu()
	{
		Instance.BackgroundMusic.Play(0);
		Instance.BackgroundMusic.mute = false;
		Instance.BackgroundMusicGame.mute = true;
	}

	public static void DisableBackgroundMusicInMenu()
	{
		Instance.BackgroundMusic.mute = true;
		Instance.BackgroundMusicGame.mute = true;
	}

	public static void BackgroundMusicInGame()
	{
		Instance.BackgroundMusicGame.Play(0);
		Instance.BackgroundMusic.mute = true;
		Instance.BackgroundMusicGame.mute = false;
	}

}
