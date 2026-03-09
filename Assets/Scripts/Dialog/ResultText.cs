using TMPro;
using UnityEngine;

public class ResultText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private DialogueBox dialogueBox;

    public void Awake()
    {
        text.text += "Your performance has decided the fate of the workers.\n\n";

        int fails = PlayerPrefs.GetInt("fail");

        if (fails >= 4)
        {
            text.text += "You got the bad ending.";
        }

        else
        {
            text.text += "När gryningen långsamt började lysa upp horisonten låg gruvan fortfarande tyst. Den kyliga morgonluften bar med sig en svag doft av jord och sten, och dimman som vilade över dalen började sakta dra sig tillbaka. Långt borta hördes ett dovt ljud från en ensam vagn som rullade över grusvägen, men annars var världen stilla. För många var detta bara ännu en morgon, men för dem som arbetade här var varje dag början på något nytt, något oförutsägbart.\r\n\r\nArbetarna började så småningom samlas vid ingången till gruvan. Några talade lågmält med varandra, andra stod tysta och betraktade berget som reste sig över dem. Det fanns alltid en känsla av både hopp och oro i luften. Ibland hittade man rikliga ådror av mineraler som kunde hålla verksamheten igång i veckor. Andra gånger gick dagarna utan att något av värde hittades alls.\r\n\r\nEn äldre arbetare lutade sig mot sin hacka och såg ut över landskapet. Han hade varit här längre än de flesta kunde minnas, och varje sten i området verkade bära på ett minne. Han visste att arbetet i gruvan inte bara handlade om att bryta sten. Det handlade om tålamod, om samarbete och om att fortsätta framåt även när resultatet inte syntes direkt.\r\n\r\nSolen steg högre på himlen och kastade sitt ljus över gruvans ingång. Snart skulle dagens arbete börja på allvar. Hackor skulle slå mot sten, vagnar skulle fyllas och damm skulle stiga upp i luften. Men just i detta ögonblick, innan allt satte igång, fanns det en kort stund av stillhet.\r\n\r\nDet var i sådana stunder man kunde tänka på allt annat: på städer långt borta, på människor man saknade, eller på drömmar om vad framtiden kanske skulle föra med sig. För även i de djupaste tunnlarna, där ljuset knappt nådde fram, fanns alltid tanken att något värdefullt kunde ligga gömt bara några slag bort.\r\n\r\nOch kanske var det just den tanken som fick dem att återvända hit varje morgon.";
        }
    }

}
