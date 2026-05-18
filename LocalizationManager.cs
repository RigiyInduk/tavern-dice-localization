using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public enum LocKey
{
    players_turn,
    opponents_turn,
    coin_toss,
    player_won,
    opponent_won,
    draw_reroll,
    player_points,
    opponent_points,  
    head,
    tail,
    curopt_dice,
    curopt_coin,
    throwBut
}

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager ins;
    public string language;

    private Dictionary<LocKey, Dictionary<string, string>> tavern;
    public TextMeshProUGUI txtInfo;

    private void Awake()
    {
        if (ins == null) { ins = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(ins.gameObject); ins = this; }
    }

    private void Start()
    {      
        BuildTable();
        En();        
        if (txtInfo != null) txtInfo.text = "";
    }

    private void BuildTable()
    {
        tavern = new Dictionary<LocKey, Dictionary<string, string>>
        {
            [LocKey.players_turn] = new()
            {
                ["En"] = "Player's turn",
                ["Ru"] = "Ход Игрока",
                ["Zh"] = "玩家回合",
                ["Ja"] = "プレイヤーのターン",
                ["De"] = "Spieler am Zug",
                ["Ko"] = "플레이어의 차례",
                ["Br"] = "Turno do Jogador",
                ["Fr"] = "Tour du Joueur",
                ["Tr"] = "Oyuncunun Sırası",
                ["Pl"] = "Tura gracza",
                ["Es"] = "Turno del Jugador",
                ["It"] = "Turno del Giocatore"
            },
            [LocKey.opponents_turn] = new()
            {
                ["En"] = "Opponent's turn",
                ["Ru"] = "Ход Соперника",
                ["Zh"] = "对手回合",
                ["Ja"] = "相手のターン",
                ["De"] = "Gegner am Zug",
                ["Ko"] = "상대의 차례",
                ["Br"] = "Turno do Oponente",
                ["Fr"] = "Tour de l'Adversaire",
                ["Tr"] = "Rakibin Sırası",
                ["Pl"] = "Tura przeciwnika",
                ["Es"] = "Turno del Oponente",
                ["It"] = "Turno dell'Avversario"
            },
            [LocKey.coin_toss] = new()
            {
                ["En"] = "Coin toss",
                ["Ru"] = "Бросок монеты",
                ["Zh"] = "抛硬币",
                ["Ja"] = "コイントス",
                ["De"] = "Münzwurf",
                ["Ko"] = "동전 던지기",
                ["Br"] = "Lançamento de moeda",
                ["Fr"] = "Pile ou face",
                ["Tr"] = "Yazı Tura",
                ["Pl"] = "Rzut monetą",
                ["Es"] = "Lanzamiento de moneda",
                ["It"] = "Lancio della moneta"
            },
            [LocKey.player_won] = new()
            {
                ["En"] = "You won",
                ["Ru"] = "Вы выиграли",
                ["Zh"] = "你赢了",
                ["Ja"] = "あなたの勝ち",
                ["De"] = "Du hast gewonnen",
                ["Ko"] = "당신이 이겼습니다",
                ["Br"] = "Você venceu",
                ["Fr"] = "Vous avez gagné",
                ["Tr"] = "Kazandınız",
                ["Pl"] = "Wygrana",
                ["Es"] = "Has ganado",
                ["It"] = "Hai vinto"
            },
            [LocKey.opponent_won] = new()
            {
                ["En"] = "Opponent wins\nYou lose",
                ["Ru"] = "Соперник выиграл\nВы проиграли",
                ["Zh"] = "对手赢了\n你输了",
                ["Ja"] = "相手の勝ち\nあなたの負け",
                ["De"] = "Gegner hat gewonnen\nDu verlierst",
                ["Ko"] = "상대가 이겼습니다\n당신은 졌습니다",
                ["Br"] = "Oponente venceu\nVocê perdeu",
                ["Fr"] = "L'adversaire a gagné\nVous avez perdu",
                ["Tr"] = "Rakip kazandı\nKaybettiniz",
                ["Pl"] = "Przeciwnik wygrał\nPrzegrana",
                ["Es"] = "El oponente gana\nTú pierdes",
                ["It"] = "L'avversario vince\nTu perdi"
            },
            [LocKey.draw_reroll] = new()
            {
                ["En"] = "Draw\nReroll",
                ["Ru"] = "Ничья\nПереброс",
                ["Zh"] = "平局\n重新投掷",
                ["Ja"] = "引き分け\n再投",
                ["De"] = "Unentschieden\nNochmal würfeln",
                ["Ko"] = "무승부\n다시 던지기",
                ["Br"] = "Empate\nRejogar",
                ["Fr"] = "Égalité\nRelancer",
                ["Tr"] = "Beraberlik\nTekrar At",
                ["Pl"] = "Remis\nPonowny rzut",
                ["Es"] = "Empate\nVolver a tirar",
                ["It"] = "Pareggio\nRilancia"
            },
            [LocKey.player_points] = new()
            {
                ["En"] = "Player points: {0}",
                ["Ru"] = "Очки Игрока: {0}",
                ["Zh"] = "玩家积分: {0}",
                ["Ja"] = "プレイヤーのポイント: {0}",
                ["De"] = "Spielerpunkte: {0}",
                ["Ko"] = "플레이어 점수: {0}",
                ["Br"] = "Pontos do Jogador: {0}",
                ["Fr"] = "Points du Joueur: {0}",
                ["Tr"] = "Oyuncunun Puanı: {0}",
                ["Pl"] = "Punkty gracza: {0}",
                ["Es"] = "Puntos del Jugador: {0}",
                ["It"] = "Punti del Giocatore: {0}"
            },
            [LocKey.opponent_points] = new()
            {
                ["En"] = "Opponent's points: {0}",
                ["Ru"] = "Очки Соперника: {0}",
                ["Zh"] = "对手积分: {0}",
                ["Ja"] = "相手のポイント: {0}",
                ["De"] = "Punkte des Gegners: {0}",
                ["Ko"] = "상대 점수: {0}",
                ["Br"] = "Pontos do Oponente: {0}",
                ["Fr"] = "Points de l'Adversaire: {0}",
                ["Tr"] = "Rakibin Puanı: {0}",
                ["Pl"] = "Punkty przeciwnika: {0}",
                ["Es"] = "Puntos del Oponente: {0}",
                ["It"] = "Punti dell'Avversario: {0}"
            },
            [LocKey.head] = new()
            {
                ["En"] = "Heads",
                ["Ru"] = "Орел",
                ["Zh"] = "正面",
                ["Ja"] = "表",
                ["De"] = "Kopf",
                ["Ko"] = "앞면",
                ["Br"] = "Cara",
                ["Fr"] = "Face",
                ["Tr"] = "Tura",
                ["Pl"] = "Orzeł",
                ["Es"] = "Cara",
                ["It"] = "Testa"
            },
            [LocKey.tail] = new()
            {
                ["En"] = "Tails",
                ["Ru"] = "Решка",
                ["Zh"] = "反面",
                ["Ja"] = "裏",
                ["De"] = "Zahl",
                ["Ko"] = "뒷면",
                ["Br"] = "Coroa",
                ["Fr"] = "Pile",
                ["Tr"] = "Yazı",
                ["Pl"] = "Reszka",
                ["Es"] = "Cruz",
                ["It"] = "Croce"
            },
            [LocKey.curopt_coin] = new()
            {
                ["En"] = "Coin",
                ["Ru"] = "Монета",
                ["Zh"] = "硬币",
                ["Ja"] = "コイン",
                ["De"] = "Münze",
                ["Ko"] = "동전",
                ["Br"] = "Moeda",
                ["Fr"] = "Pièce",
                ["Tr"] = "Para",
                ["Pl"] = "Moneta",
                ["Es"] = "Moneda",
                ["It"] = "Moneta"
            },
            [LocKey.curopt_dice] = new()
            {
                ["En"] = "Dice",
                ["Ru"] = "Кубики",
                ["Zh"] = "骰子",
                ["Ja"] = "サイコロ",
                ["De"] = "Würfel",
                ["Ko"] = "주사위",
                ["Br"] = "Dados",
                ["Fr"] = "Dés",
                ["Tr"] = "Zar",
                ["Pl"] = "Kości",
                ["Es"] = "Dados",
                ["It"] = "Dadi"
            },
            [LocKey.throwBut] = new()
            {
                ["En"] = "Throw",
                ["Ru"] = "Бросить",
                ["Zh"] = "投掷",
                ["Ja"] = "投げる",
                ["De"] = "Werfen",
                ["Ko"] = "던지기",
                ["Br"] = "Lançar",
                ["Fr"] = "Lancer",
                ["Tr"] = "At",
                ["Pl"] = "Rzuć",
                ["Es"] = "Lanzar",
                ["It"] = "Lanciare"
            }
        };
    }

    public string Get(LocKey key, params object[] args)
    {
        string lang = string.IsNullOrEmpty(language) ? "En" : language;

        if (tavern.TryGetValue(key, out var langs))
        {
            string text = langs.TryGetValue(lang, out string val) ? val : langs["En"];
            return args.Length > 0 ? string.Format(text, args) : text;
        }

        return $"[{key}]";
    }   

    public void SetLanguage(string lang)
    {
        PlayerPrefs.SetString("Language", lang);
        language = lang;
    }

   public void CheckScorePlayer()
{        
    int cb1 = Random.Range(1, 7);
    int cb2 = Random.Range(1, 7);
    int scoresP = cb1 + cb2;
    txtInfo.text = LocalizationManager.ins.Get(LocKey.player_points, cb1+cb2);
}

    //for buttons
    public void En() => SetLanguage("En");
    public void Ru() => SetLanguage("Ru");
    public void ZhCN() => SetLanguage("Zh");
    public void Ja() => SetLanguage("Ja");
    public void PtBr() => SetLanguage("Br");
    public void De() => SetLanguage("De");
    public void Fr() => SetLanguage("Fr");
    public void Tr() => SetLanguage("Tr");
    public void Ko() => SetLanguage("Ko");
    public void Pl() => SetLanguage("Pl");
    public void Es() => SetLanguage("Es");
    public void It() => SetLanguage("It");

}


