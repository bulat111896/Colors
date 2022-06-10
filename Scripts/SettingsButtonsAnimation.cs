using UnityEngine;

public class SettingsButtonsAnimation : MonoBehaviour
{
    public Transform Music, Sounds, Cubes, Language, Quit, Mode;
    private Vector3 localScale1 = new Vector3(0.016f, 0.016f, 0), localScale2 = new Vector3(0.06f, 0.06f, 0);
    public int a;

    void FixedUpdate()
    {
        if (a == 1)
        {
            Music.localScale += localScale1;
            Sounds.localScale += localScale1;
            Cubes.localScale += localScale1;
            Language.localScale += localScale1;
            Quit.localScale += localScale1;
            Mode.localScale += localScale1;
        }
        else if (a == 2)
        {
            Music.localScale -= localScale2;
            Sounds.localScale -= localScale2;
            Cubes.localScale -= localScale2;
            Language.localScale -= localScale2;
            Quit.localScale -= localScale2;
            Mode.localScale -= localScale2;
        }
    }
}