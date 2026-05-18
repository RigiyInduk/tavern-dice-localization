# Localization for "Tavern Dice" mini-game

## Features
- 12 languages: EN, RU, ZH, JA, DE, FR, KO, PT-BR, TR, PL, ES, IT.
- All texts stored in `Dictionary<LocKey, Dictionary<string, string>>`.
- Supports string formatting (e.g., `"Player points: {0}"`).
- Saves selected language in `PlayerPrefs`.
- Easily extensible: add a new key to `enum LocKey` and fill in the translations.

## How to use
0. Place the `LocalizationManager` script on an empty GameObject in your starting scene. It will persist across scenes via `DontDestroyOnLoad`.
1. Create a TextMeshProUGUI text field in the scene (install the necessary packages if required). The text component is already declared in `LocalizationManager` as `public TextMeshProUGUI txtInfo;`.
2. Drag and drop the TextMeshProUGUI field onto the `txtInfo` slot in the inspector of the `LocalizationManager` script.
3. Call `txtInfo.text = LocalizationManager.ins.Get(LocKey.opponents_turn);` to get plain text, for example when throwing dice.
4. Use `txtInfo.text = LocalizationManager.ins.Get(LocKey.player_points, value1);` to substitute a value into the `{0}` placeholder. (Implemented in the `CheckScorePlayer()` method.)
5. Change the language at any time: `LocalizationManager.ins.SetLanguage("En")` (can be attached to a regular button).

## Note
This is localization code only. The full game is available on Unity Play: [[Tavern Dice](https://play.unity.com/en/games/d3fb1109-ee16-4879-80b7-ce4039da7a0f/tavern-dice)].


# Локализация для мини-игры "Tavern Dice"

## Возможности
- 12 языков: EN, RU, ZH, JA, DE, FR, KO, PT-BR, TR, PL, ES, IT.
- Все тексты хранятся в `Dictionary<LocKey, Dictionary<string, string>>`.
- Поддержка форматирования строк (например, `"Player points: {0}"`).
- Сохранение выбранного языка в `PlayerPrefs`.
- Легко расширяемый: добавьте новый ключ в `enum LocKey` и заполните переводы.

## Как использовать
0. Поместите скрипт `LocalizationManager` на пустой GameObject в вашей стартовой сцене. Он будет сохраняться между сценами через `DontDestroyOnLoad`.
1. Создайте текстовое поле TextMeshProUGUI в сцене (установите необходимые пакеты, если это необходимо). Объявите текстовый компонент в этом же скрипте или любом другом (например, `public TextMeshProUGUI txtInfo;`, уже объявлен в LocalizationManager). 
2. Прикрепите текстовое поле TextMeshProUGUI в поле TextMeshProUGUI txtInfo в инспекторе в скрипте LocalizationManager.
3. Вызовите `txtInfo.text = LocalizationManager.ins.Get(LocKey.opponents_turn);` для получения обычного текста, например при броске кубиков.
4. Используйте `txtInfo.text = LocalizationManager.ins.Get(LocKey.player_points, value1);` для подстановки значения в плейсхолдер `{0}`. (Реализовано в методе CheckScorePlayer();)
5. Смените язык в любой момент: `LocalizationManager.ins.SetLanguage("En")`(можно повесить на обычную кнопку).

## Примечание
Это только код локализации. Полная игра доступна на Unity Play: [[ссылка на Tavern Dice](https://play.unity.com/en/games/d3fb1109-ee16-4879-80b7-ce4039da7a0f/tavern-dice)].