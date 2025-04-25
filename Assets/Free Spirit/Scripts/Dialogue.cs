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
            "Toi là tu dois m'aider ! ",
            "Comment tu demande ? Et bien vois-tu, je suis une âme. Et comme toute âme je devrais m'envoler vers l'au delà.",
            "Mais le portail deriere toi sensé me guider est fermé...",
            "On dirait qu'il n'est plus alimenté par les prismes d'energies.",
            "Je pourrais aller chercher les energies mais les épreuves à traverser sont trop compliquées pour moi !",
            "C'est pour cela que j'ai besoin de ton aide. Dit-tu veux bien ?"
        };
    }

    public void IntroYes()
    {
        lines = new string[]
        {
            "Ouais ! Merci mon ami !",
            "Bon alors pour commencer tu vas devoir te déplacer.",
            "Pour cela rien de plus simple, utilise les flèches directionnelles.",
            "Et pour sauter utilise la barre espace. Si tu dois sauter encore plus haut utilise ton double saut !",
            "Si tu veux interagir avec quelque chose, assure toi d'être suffisemment proche et appuie sur E.",
            "Une dernière chose ! Si tu vois une bulle apparaitre au desus de ma terre, c'est que j'ai un conseil à te donner !",
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
            "On dirait que le prisme de feu n'est pas activé...",
            "On devrait explorer les alentours pour voir ce que l'on peut faire"
        };
    }

    public void FirePrism2cd()
    {
        lines = new string[]
        {
            "Oh le Prisme de Feu est désactivé !",
            "C'est à ça que sert le laser ! C'est pour activer le prisme !"
        };
    }

    public void LazerRay1st()
    {
        lines = new string[]
        {
            "Ummm... Je me demande à quoi sert ce laser...",
            "On doit pouvoir le mener quelque part en jouant avec les miroir, mais où..."
        };
    }

    public void LazerRay2cd()
    {
        lines = new string[]
        {
            "Oh ! On devrait pouvoir activer le Prisme de Feu avec ce laser !",
            "Mais comment le faire arriver jusque là bas... Peut-être qu'avec les miroirs..."
        };
    }

    public void Waterfall()
    {
        lines = new string[]
        {
            "Ah ! Aide moi je ne peux pas traverser l'eau, ça me fait trop peur !"
        };
    }

    public void Prism()
    {
        lines = new string[]
        {
            "Ok on est devant un prisme d'energie. Approche toi et appuie sur E pour que je récupère son energie."
        };
    }

    public void Portal()
    {
        lines = new string[]
        {
            "Maintenant il ne me reste plus qu'à remettre lenergie à la bonne place dans le portail. Appuie sur E pour m'y envoyer !"
        };
    }

    public void Outro()
    {
        lines = new string[]
        {
            "Bon et bien ça y est. Le portail a retrouvé son energie. Je vais pouvoir enfin retrouver ma place.",
            "Merci mille fois pour ton aide mon ami !",
            "J'espere te revoir bientôt ! Enfin pas trop non plus !",
            "Au revoir !"
        };
    }

}
