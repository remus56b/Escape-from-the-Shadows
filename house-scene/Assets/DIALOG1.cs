using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIALOG1 : MonoBehaviour
{
    public AudioSource sound1; // Prima sursă audio
    public AudioSource sound2; // A doua sursă audio
    public AudioSource sound3; // A treia sursă audio
    public AudioSource sound4; // A patra sursă audio
    public AudioSource sound5; // A cincea sursă audio
    public AudioSource sound6; // A șasea sursă audio

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlaySounds());
    }

    IEnumerator PlaySounds()
    {
        yield return new WaitForSeconds(2f); // Așteaptă 3 secunde

        sound1.Play(); // Pornește primul sunet

        yield return new WaitForSeconds(sound1.clip.length + 2f); // Așteaptă lungimea sunetului 1 + 3 secunde

        sound2.Play(); // Pornește al doilea sunet după ce se termină primul sunet

        yield return new WaitForSeconds(sound2.clip.length + 2f); // Așteaptă lungimea sunetului 2 + 2 secunde

        sound3.Play(); // Pornește al treilea sunet după ce se termină al doilea sunet

        yield return new WaitForSeconds(sound3.clip.length + 2f); // Așteaptă lungimea sunetului 3 + 3 secunde

        sound4.Play(); // Pornește al patrulea sunet după ce se termină al treilea sunet

        yield return new WaitForSeconds(sound4.clip.length + 2f); // Așteaptă lungimea sunetului 4 + 2 secunde

        sound5.Play(); // Pornește al cincilea sunet după ce se termină al patrulea sunet

        yield return new WaitForSeconds(sound5.clip.length + 2f); // Așteaptă lungimea sunetului 5 + 2 secunde

        sound6.Play(); // Pornește al șaselea sunet după ce se termină al cincilea sunet
    }

    // Update is called once per frame
    void Update()
    {

    }
}
