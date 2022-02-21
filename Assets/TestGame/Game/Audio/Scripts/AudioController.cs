using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource backGroundMusic;
    [SerializeField] private AudioSource explosionSound;
    [SerializeField] private AudioSource bombPlantSound;
    [SerializeField] private AudioSource enemyApplyDamageSound;
    [SerializeField] private AudioSource playerApplyDamageSound;
    [SerializeField] private AudioSource exitSound;
    [SerializeField] private AudioSource loseSound;
    [SerializeField] private AudioSource pickItemSound;

    public void PlayBGMusic()
    {
        if (backGroundMusic.isPlaying == false)
            backGroundMusic.Play();
    }

    public void PlayExplosionSound()
    {
        if (explosionSound.isPlaying == false)
            explosionSound.Play();
    }

    public void PlayBombPlantSound()
    {
        if (bombPlantSound.isPlaying == false)
            bombPlantSound.Play();
    }

    public void PlayEnemyApplyDamageSound()
    {
        if (playerApplyDamageSound.isPlaying)
            playerApplyDamageSound.Stop();

        playerApplyDamageSound.Play();
    }

    public void PlayPlayerApplyDamageSound()
    {
        if (enemyApplyDamageSound.isPlaying)
            enemyApplyDamageSound.Stop();

        enemyApplyDamageSound.Play();
    }
    public void PlayExitSound()
    {
        if (exitSound.isPlaying == false)
            exitSound.Play();
    }
    public void PlayLoseSound()
    {
        if (loseSound.isPlaying == false)
            loseSound.Play();
    }

    public void PlayPickItemSound()
    {
        if (pickItemSound.isPlaying)
            pickItemSound.Stop();

        pickItemSound.Play();
    }
}
