using TMPro;
using UnityEngine;

public class ResultText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private DialogueBox dialogueBox;

    public void Awake()
    {
        text.text += "Your performance has decided the fate of the workers.\n\n";
        PlayerPrefs.SetInt("fail", 5);

        int fails = PlayerPrefs.GetInt("fail");
        int Edvin = PlayerPrefs.GetInt("Dead");
        int Sharpe = PlayerPrefs.GetInt("Guy Sharpe");
        int Robert = PlayerPrefs.GetInt("Robert Lampard");
        int Elsa = PlayerPrefs.GetInt("Elsa Norden");
        int Jane = PlayerPrefs.GetInt("Jane Layton");

        if (fails >= 4)
        {
            text.text += "At the end of the day, the Higher ups of M.I.N.E. Corp called you in for an assessment.\r\nWhat you found was not a board meeting, not even your boss was there. Instead, Creatures labeled “F10”, “F9”, “F8” all the way down to “F0” waited for you. They took you. Changed you. Before you knew it you were trapped inside a prison of steel. You tried to claw your way out, to regain control. But you are left in pain. On monday you approach a table, your movements not your own, and see a person sitting, where you used to sit. Their nametag: “F13”.\r\n";
        }
        else
        {
            text.text += "At the end of the day, the Higher ups of M.I.N.E. Corp called you in for an assessment. What you found was not a board meeting, not even your boss was there. Instead, Creatures labeled “F10”, “F9”, “F8” all the way down to “F0” waited for you. After a brief, horrifying moment one of the blessed shareholders enters the room to congratulate you. All these creatures are now under your command, and you get promoted to Chief foreman of the excavation site. After a couple of months the D.A.F.C. Arrive. They liberated your workers, burned down everything that M.I.N.E. stood for.  But what the D.A.F.C. did ti you? Only your actions can tell\n.";

        }
        if (Edvin > 0)
        {
            text.text += "Edvin has lost his life to M.I.N.E. Just as his wife had done. What followed could either have been a tale of sorrow or a tale of liberation. But we will never know. At least he is reunited with Cecillia now. And that may be a comfort to some.\n";
        }
        else
        {
            text.text += "Edvin continued his work at M.I.N.E.until finally he and his brother had enough. They started their own resistance internally within M.I.N.E.and when the D.A.F.C.came, they were saluted as heroes.\n";
        }
        if (Sharpe >= 5)
        {
            text.text += "With Guy Sharpe managing to evade working in any other mine than A2 he managed to lay low during the whole D.A.F.C. debacle. When the dust settled the managed to worm himself into a position as the local administrator for the mineshafts. Thus he got what he always wanted. A desk job. \n";
        }
        if (Sharpe >= 3 && Sharpe < 5)
        {
            text.text += "Guy Sharpe did not expect himself to be fighting side by side with his colleagues against M.I.N.E. when the D.A.F.C. arrived. He always thought that he would climb the corporate ladder. Well well, a democracy surely needs a corrupt politician, he thought to himself.\n";
        }
        if (Sharpe < 3)
        {
            text.text += "Guy Sharpe was finally revealed to be the snake he was. When the D.A.F.C. arrived at the M.I.N.E. excavation he tried to sabotage the local resistance. For this he was hanged.\n";
        }
        if (Robert > 0)
        {
            text.text += "The D.A.F.C. had started their attack. The facility lost its power during the fighting, leaving Robert and his wife in the dark. Paralyzed with fear Robert couldn’t move. His wife tried to drag him out of the collapsing building but it was too late. They were both found a week after, their hands clasped. Even in death Robert’s wife wouldn’t leave him.\n";
        }
        else
        {
            text.text += "Robert and his wife managed to be blessed with a child. When the D.A.F.C. arrived they were quickly integrated into the rest of the civilians. Robert never really did get over his fear of the dark. But at least now he was happy.\n";
        }
        if (Edvin > 0)
        {
            text.text += "With the loss of his brother William lost his will. The pressure from above was too much and his sorrow scared his soul. When the D.A.F.C. arrived, they only found a husk of a man, muttering the words \n";
        }
        else
        {
            text.text += "William continued his work at M.I.N.E.until finally he and his brother had enough. They started their own resistance internally within M.I.N.E.and when the D.A.F.C.came, they were saluted as heroes.";
        }
        text.text += "When the D.A.F.C. came and liberated the M.I.N.E. workers, there was sadly nothing to be done for the creatures like F11 or Emma Mardough as she was called in life. The Coalition of Free agencies had ended, but their horrors persisted. Emma was decommissioned as it was the only humane conclusion that could be reached.\n";
        if (Elsa > 0)
        {
            text.text += "Elsa continued working for M.I.N.E. for a couple of weeks until the day of the Heart of Steel came. Then she departed with her sisters, never to return again. One can only hope that the steelhearts belief in Steel Ascendancy were true.";
        }
        else
        {
            text.text += "Elsa continued in M.I.N.E. But after a while she was found out to be a member of the Steelhearts. Fanatic believers in ascension through steel. The day after a new creature emerged ready for duty, this one called “E0”.\r\n";
        }
        if (Jane > 0)
        {
            text.text += "Jane managed to work on her mannerisms, and with it she managed to make some friends among the workers. They helped her hide when the P.L.A. came to find recruits to the war effort against the D.A.F.C.";
        }
        else
        {
            text.text += "With the encroaching D.A.F.C. Jane was recruited to assist in the war by the P.L.A. She lost her life in combat when D.A.F.C. reached the M.I.N.E. complex.";
        }

    }
}