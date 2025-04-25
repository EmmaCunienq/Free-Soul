using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public string[] lines;

    private void Start()
    {
        Intro();
    }

    public void Intro()
    {
        lines = new string[] 
        {
            "A l'aide ! Au secours ! Je ne peux m'en aller !",
            "Toi l� tu dois m'aider ! ",
            "Comment tu demande ? Et bien vois-tu, je suis une �me. Et comme toute �me je devrais m'envoler vers l'au del�.",
            "Mais le portail deriere toi sens� me guider est ferm�...",
            "On dirait qu'il n'est plus aliment� par les prismes d'energies.",
            "Je pourrais aller chercher les energies mais les �preuves � traverser sont trop compliqu�es pour moi !",
            "C'est pour cela que j'ai besoin de ton aide. Dit-tu veux bien ?"
        };
    }

    public void IntroYes()
    {
        lines = new string[]
        {
            "Ouais ! Merci mon ami !",
            "Bon alors pour commencer tu vas devoir te d�placer.",
            "Pour cela rien de plus simple, utilise les fl�ches directionnelles.",
            "Et pour sauter utilise la barre espace. Si tu dois sauter encore plus haut utilise ton double saut !",
            "Si tu veux interagir avec quelque chose, assure toi d'�tre suffisemment proche et appuie sur E.",
            "Une derni�re chose ! Si tu vois une bulle apparaitre au desus de ma terre, c'est que j'ai un conseil � te donner !",
            "Appuie sur A pour me parler !",
            "Bon je crois que je t'ai tout dit... C'est parti !"
        };
    }

    public void IntroNo()
    {
        lines = new string[]
        {
            "S'teuplai ! S'teuplai ! S'teuplai ! S'teuplai ! S'teuplai ! S'teuplai !"
        };
    }

    public void FirePrism1st()
    {
        lines = new string[]
        {
            "Ummm...",
            "On dirait que le prisme de feu n'est pas activ�...",
            "On devrait explorer les alentours pour voir ce que l'on peut faire"
        };
    }

    public void FirePrism2cd()
    {
        lines = new string[]
        {
            "Oh le Prisme de Feu est d�sactiv� !",
            "C'est � �a que sert le laser ! C'est pour activer le prisme !"
        };
    }

    public void LazerRay1st()
    {
        lines = new string[]
        {
            "Ummm... Je me demande � quoi sert ce laser...",
            "On doit pouvoir le mener quelque part en jouant avec les miroir, mais o�..."
        };
    }

    public void LazerRay2cd()
    {
        lines = new string[]
        {
            "Oh ! On devrait pouvoir activer le Prisme de Feu avec ce laser !",
            "Mais comment le faire arriver jusque l� bas... Peut-�tre qu'avec les miroirs..."
        };
    }

    public void Waterfall()
    {
        lines = new string[]
        {
            "Ah ! Aide moi je ne peux pas traverser l'eau, �a me fait trop peur !"
        };
    }

    public void Prism()
    {
        lines = new string[]
        {
            "Ok on est devant un prisme d'energie. Approche toi et appuie sur E pour que je r�cup�re son energie."
        };
    }

    public void Portal()
    {
        lines = new string[]
        {
            "Maintenant il ne me reste plus qu'� remettre lenergie � la bonne place dans le portail. Appuie sur E pour m'y envoyer !"
        };
    }

    public void Outro()
    {
        lines = new string[]
        {
            "Bon et bien �a y est. Le portail a retrouv� son energie. Je vais pouvoir enfin retrouver ma place.",
            "Merci mille fois pour ton aide mon ami !",
            "J'espere te revoir bient�t ! Enfin pas trop non plus !",
            "Au revoir !"
        };
    }

}
