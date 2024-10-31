using UnityEngine;
using TMPro;

/// <summary>
/// 
/// Unity 2018.2.16f1 => 6000.0.23f
/// 
/// </summary>

public class InputSystem : MonoBehaviour
{
    // InputField
    [SerializeField] private TMP_InputField hiraganaInputField;


    // Use this for initialization
    private void Start()
    {
        // InputFiledの値が変わった時にローマ字をひらがなに変換
        hiraganaInputField.onValueChanged.AddListener(delegate { ConvertToHiragana(); });
    }


    // ひらがな変換
    private void ConvertToHiragana()
    {
        string letters = hiraganaInputField.text;

        // 草
        if (letters.Contains("ww"))
        {
            int nextIndex = letters.IndexOf("ww") + 2;

            if (nextIndex < letters.Length)
            {
                // 次の文字がwではない場合
                if (letters[nextIndex].ToString() != "w")
                {
                    // 促音に変換
                    letters = letters.Replace("ww", "っw");
                }
            }
        }

        // 記号
        letters = letters.Replace("!", "！");
        letters = letters.Replace("#", "＃");
        letters = letters.Replace("$", "＄");
        letters = letters.Replace("%", "％");
        letters = letters.Replace("&", "＆");
        letters = letters.Replace("'", "’");
        letters = letters.Replace("(", "（");
        letters = letters.Replace(")", "）");
        letters = letters.Replace("=", "＝");
        letters = letters.Replace("-", "ー");
        letters = letters.Replace("~", "～");
        letters = letters.Replace("|", "｜");
        letters = letters.Replace("@", "＠");
        letters = letters.Replace("[", "「");
        letters = letters.Replace("+", "＋");
        letters = letters.Replace(";", "；");
        letters = letters.Replace("*", "＊");
        letters = letters.Replace(":", "：");
        letters = letters.Replace("]", "」");
        letters = letters.Replace("_", "＿");
        letters = letters.Replace("<", "＜");
        letters = letters.Replace(",", "、");
        letters = letters.Replace(">", "＞");
        letters = letters.Replace(".", "。");
        letters = letters.Replace("?", "？");
        letters = letters.Replace("/", "・");

        // 促音
        letters = letters.Replace("ltu", "っ");
        letters = letters.Replace("ltsu", "っ");
        letters = letters.Replace("xtu", "っ");
        letters = letters.Replace("xtsu", "っ");

        letters = letters.Replace("pp", "っp");
        letters = letters.Replace("bb", "っb");
        letters = letters.Replace("dd", "っd");
        letters = letters.Replace("zz", "っz");
        letters = letters.Replace("jj", "っj");
        letters = letters.Replace("gg", "っg");
        letters = letters.Replace("rr", "っr");
        letters = letters.Replace("mm", "っm");
        letters = letters.Replace("tt", "っt");
        letters = letters.Replace("cc", "っc");
        letters = letters.Replace("ss", "っs");
        letters = letters.Replace("kk", "っk");
        letters = letters.Replace("hh", "っh");
        letters = letters.Replace("ff", "っf");
        letters = letters.Replace("yy", "っy");

        // 撥音
        letters = letters.Replace("nn", "ん");

        // 小文字
        letters = letters.Replace("xa", "ぁ");
        letters = letters.Replace("xi", "ぃ");
        letters = letters.Replace("xu", "ぅ");
        letters = letters.Replace("xe", "ぇ");
        letters = letters.Replace("xo", "ぉ");
        letters = letters.Replace("xya", "ゃ");
        letters = letters.Replace("xyi", "ぃ");
        letters = letters.Replace("xyu", "ゅ");
        letters = letters.Replace("xye", "ぇ");
        letters = letters.Replace("xyo", "ょ");
        letters = letters.Replace("nx", "んx");

        letters = letters.Replace("la", "ぁ");
        letters = letters.Replace("li", "ぃ");
        letters = letters.Replace("lu", "ぅ");
        letters = letters.Replace("le", "ぇ");
        letters = letters.Replace("lo", "ぉ");
        letters = letters.Replace("lya", "ゃ");
        letters = letters.Replace("lyi", "ぃ");
        letters = letters.Replace("lyu", "ゅ");
        letters = letters.Replace("lye", "ぇ");
        letters = letters.Replace("lyo", "ょ");
        letters = letters.Replace("nl", "んl");

        // ぱ行
        letters = letters.Replace("pa", "ぱ");
        letters = letters.Replace("pi", "ぴ");
        letters = letters.Replace("pu", "ぷ");
        letters = letters.Replace("pe", "ぺ");
        letters = letters.Replace("po", "ぽ");
        letters = letters.Replace("pya", "ぴゃ");
        letters = letters.Replace("pyu", "ぴゅ");
        letters = letters.Replace("pyo", "ぴょ");
        letters = letters.Replace("np", "んp");

        // ば行
        letters = letters.Replace("ba", "ば");
        letters = letters.Replace("bi", "び");
        letters = letters.Replace("bu", "ぶ");
        letters = letters.Replace("be", "べ");
        letters = letters.Replace("bo", "ぼ");
        letters = letters.Replace("bya", "びゃ");
        letters = letters.Replace("byu", "びゅ");
        letters = letters.Replace("byo", "びょ");
        letters = letters.Replace("nb", "んb");

        // だ行
        letters = letters.Replace("da", "だ");
        letters = letters.Replace("di", "ぢ");
        letters = letters.Replace("du", "づ");
        letters = letters.Replace("de", "で");
        letters = letters.Replace("do", "ど");
        letters = letters.Replace("dya", "ぢゃ");
        letters = letters.Replace("dyi", "ぢぃ");
        letters = letters.Replace("dyu", "ぢゅ");
        letters = letters.Replace("dye", "ぢぇ");
        letters = letters.Replace("dyo", "ぢょ");
        letters = letters.Replace("dha", "でゃ");
        letters = letters.Replace("dhi", "でぃ");
        letters = letters.Replace("dhu", "でゅ");
        letters = letters.Replace("dhe", "でぇ");
        letters = letters.Replace("dho", "でょ");
        letters = letters.Replace("nd", "んd");

        // ざ行
        letters = letters.Replace("za", "ざ");
        letters = letters.Replace("zi", "じ");
        letters = letters.Replace("zu", "ず");
        letters = letters.Replace("ze", "ぜ");
        letters = letters.Replace("zo", "ぞ");
        letters = letters.Replace("zya", "じゃ");
        letters = letters.Replace("zyi", "じぃ");
        letters = letters.Replace("zyu", "じゅ");
        letters = letters.Replace("zye", "じぇ");
        letters = letters.Replace("zyo", "じょ");
        letters = letters.Replace("nz", "んz");

        letters = letters.Replace("ja", "じゃ");
        letters = letters.Replace("ji", "じ");
        letters = letters.Replace("ju", "じゅ");
        letters = letters.Replace("je", "じぇ");
        letters = letters.Replace("jo", "じょ");
        letters = letters.Replace("jya", "じゃ");
        letters = letters.Replace("jyi", "じぃ");
        letters = letters.Replace("jyu", "じゅ");
        letters = letters.Replace("jye", "じぇ");
        letters = letters.Replace("jyo", "じょ");
        letters = letters.Replace("nj", "んj");

        // が行
        letters = letters.Replace("ga", "が");
        letters = letters.Replace("gi", "ぎ");
        letters = letters.Replace("gu", "ぐ");
        letters = letters.Replace("ge", "げ");
        letters = letters.Replace("go", "ご");
        letters = letters.Replace("gya", "ぎゃ");
        letters = letters.Replace("gyi", "ぎぃ");
        letters = letters.Replace("gyu", "ぎゅ");
        letters = letters.Replace("gye", "ぎぇ");
        letters = letters.Replace("gyo", "ぎょ");
        letters = letters.Replace("ng", "んg");

        // わ行
        letters = letters.Replace("wa", "わ");
        letters = letters.Replace("wi", "うぃ");
        letters = letters.Replace("wu", "う");
        letters = letters.Replace("we", "うぇ");
        letters = letters.Replace("wo", "を");
        letters = letters.Replace("wyi", "ゐ");
        letters = letters.Replace("wye", "ゑ");
        letters = letters.Replace("wha", "うぁ");
        letters = letters.Replace("whi", "うぃ");
        letters = letters.Replace("whu", "う");
        letters = letters.Replace("whe", "うぇ");
        letters = letters.Replace("who", "うぉ");
        letters = letters.Replace("nw", "んw");

        // ら行
        letters = letters.Replace("ra", "ら");
        letters = letters.Replace("ri", "り");
        letters = letters.Replace("ru", "る");
        letters = letters.Replace("re", "れ");
        letters = letters.Replace("ro", "ろ");
        letters = letters.Replace("rya", "りゃ");
        letters = letters.Replace("ryi", "りぃ");
        letters = letters.Replace("ryu", "りゅ");
        letters = letters.Replace("rye", "りぇ");
        letters = letters.Replace("ryo", "りょ");
        letters = letters.Replace("nr", "んr");

        // ま行
        letters = letters.Replace("ma", "ま");
        letters = letters.Replace("mi", "み");
        letters = letters.Replace("mu", "む");
        letters = letters.Replace("me", "め");
        letters = letters.Replace("mo", "も");
        letters = letters.Replace("mya", "みゃ");
        letters = letters.Replace("myi", "みぃ");
        letters = letters.Replace("myu", "みゅ");
        letters = letters.Replace("mye", "みぇ");
        letters = letters.Replace("myo", "みょ");
        letters = letters.Replace("nm", "んm");

        // な行
        letters = letters.Replace("na", "な");
        letters = letters.Replace("ni", "に");
        letters = letters.Replace("nu", "ぬ");
        letters = letters.Replace("ne", "ね");
        letters = letters.Replace("no", "の");
        letters = letters.Replace("nya", "にゃ");
        letters = letters.Replace("nyi", "にぃ");
        letters = letters.Replace("nyu", "にゅ");
        letters = letters.Replace("nye", "にぇ");
        letters = letters.Replace("nha", "んは");
        letters = letters.Replace("nhi", "んひ");
        letters = letters.Replace("nhu", "んふ");
        letters = letters.Replace("nhe", "んへ");
        letters = letters.Replace("nho", "んほ");
        letters = letters.Replace("nh", "んh");

        // た行
        letters = letters.Replace("ta", "た");
        letters = letters.Replace("ti", "ち");
        letters = letters.Replace("tu", "つ");
        letters = letters.Replace("te", "て");
        letters = letters.Replace("to", "と");
        letters = letters.Replace("tsa", "つぁ");
        letters = letters.Replace("tsi", "つぃ");
        letters = letters.Replace("tsu", "つ");
        letters = letters.Replace("tse", "つぇ");
        letters = letters.Replace("tso", "つぉ");
        letters = letters.Replace("tya", "ちゃ");
        letters = letters.Replace("tyi", "ちぃ");
        letters = letters.Replace("tyu", "ちゅ");
        letters = letters.Replace("tye", "ちぇ");
        letters = letters.Replace("tyo", "ちょ");
        letters = letters.Replace("tha", "てゃ");
        letters = letters.Replace("thi", "てぃ");
        letters = letters.Replace("thu", "てゅ");
        letters = letters.Replace("the", "てぇ");
        letters = letters.Replace("tho", "てょ");
        letters = letters.Replace("nt", "んt");

        letters = letters.Replace("cya", "ちゃ");
        letters = letters.Replace("cyi", "ちぃ");
        letters = letters.Replace("cyu", "ちゅ");
        letters = letters.Replace("cye", "ちぇ");
        letters = letters.Replace("cyo", "ちょ");
        letters = letters.Replace("cha", "ちゃ");
        letters = letters.Replace("chi", "ち");
        letters = letters.Replace("chu", "ちゅ");
        letters = letters.Replace("che", "ちぇ");
        letters = letters.Replace("cho", "ちょ");
        letters = letters.Replace("nc", "んc");

        // さ行
        letters = letters.Replace("sa", "さ");
        letters = letters.Replace("si", "し");
        letters = letters.Replace("su", "す");
        letters = letters.Replace("se", "せ");
        letters = letters.Replace("so", "そ");
        letters = letters.Replace("sya", "しゃ");
        letters = letters.Replace("syi", "しぃ");
        letters = letters.Replace("syu", "しゅ");
        letters = letters.Replace("sye", "しぇ");
        letters = letters.Replace("syo", "しょ");
        letters = letters.Replace("sha", "しゃ");
        letters = letters.Replace("shi", "し");
        letters = letters.Replace("shu", "しゅ");
        letters = letters.Replace("she", "しぇ");
        letters = letters.Replace("sho", "しょ");
        letters = letters.Replace("ns", "んs");

        // は行
        letters = letters.Replace("ha", "は");
        letters = letters.Replace("hi", "ひ");
        letters = letters.Replace("hu", "ふ");
        letters = letters.Replace("he", "へ");
        letters = letters.Replace("ho", "ほ");
        letters = letters.Replace("hya", "ひゃ");
        letters = letters.Replace("hyi", "ひぃ");
        letters = letters.Replace("hyu", "ひゅ");
        letters = letters.Replace("hye", "ひぇ");
        letters = letters.Replace("hyo", "ひょ");
        letters = letters.Replace("nh", "んh");

        letters = letters.Replace("fa", "ふぁ");
        letters = letters.Replace("fi", "ふぃ");
        letters = letters.Replace("fu", "ふ");
        letters = letters.Replace("fe", "ふぇ");
        letters = letters.Replace("fo", "ふぉ");
        letters = letters.Replace("fya", "ふゃ");
        letters = letters.Replace("fyu", "ふゅ");
        letters = letters.Replace("fyo", "ふょ");
        letters = letters.Replace("nf", "んf");

        // か行
        letters = letters.Replace("ka", "か");
        letters = letters.Replace("ki", "き");
        letters = letters.Replace("ku", "く");
        letters = letters.Replace("ke", "け");
        letters = letters.Replace("ko", "こ");
        letters = letters.Replace("kya", "きゃ");
        letters = letters.Replace("kyi", "きぃ");
        letters = letters.Replace("kyu", "きゅ");
        letters = letters.Replace("kye", "きぇ");
        letters = letters.Replace("kyo", "きょ");
        letters = letters.Replace("nk", "んk");

        // や行
        letters = letters.Replace("ya", "や");
        letters = letters.Replace("yu", "ゆ");
        letters = letters.Replace("ye", "いぇ");
        letters = letters.Replace("yo", "よ");

        // あ行
        letters = letters.Replace("a", "あ");
        letters = letters.Replace("i", "い");
        letters = letters.Replace("u", "う");
        letters = letters.Replace("e", "え");
        letters = letters.Replace("o", "お");

        // 出力
        hiraganaInputField.text = letters;
    }
}