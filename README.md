# Botva2025 — macOS / Linux / Windows

Кроссплатформенная версия бота Botva2025 для игры [botva.ru](https://botva.ru).

Оригинальная версия работала только на Windows (WinForms). Эта версия использует **Avalonia UI** — кроссплатформенный .NET UI фреймворк, который работает на macOS, Linux и Windows.

## Требования

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Google Chrome (для Selenium WebDriver)

## Установка и запуск

```bash
# Клонировать репозиторий
git clone <repo-url>
cd Botva2025Mac

# Собрать
dotnet build

# Запустить
dotnet run
```

## Сборка для macOS (релиз)

```bash
# Собрать автономный исполняемый файл для macOS (arm64)
dotnet publish -c Release -r osx-arm64 --self-contained

# Для macOS (Intel)
dotnet publish -c Release -r osx-x64 --self-contained

# Для Linux
dotnet publish -c Release -r linux-x64 --self-contained

# Для Windows
dotnet publish -c Release -r win-x64 --self-contained
```

Исполняемый файл будет в `bin/Release/net10.0/<rid>/publish/`.

## Функции

- 🎮 Автоматизация всех основных активностей botva.ru
- 🤖 Selenium WebDriver для управления Chrome
- 📊 Настройки через чекбоксы (сохраняются в Config.json)
- 🌐 Поддержка всех серверов (g1, g2, g3, turbo, avatar)
- 💬 Telegram-бот (опционально)
- 📈 Google Sheets (опционально)

## Архитектура

```
Botva2025Mac/
├── GameLogic/       # Бизнес-логика (бодалка, арена, крепость, и т.д.)
├── Models/          # Модели данных
├── Services/        # Сервисы (WebDriver, LogService, AppSettings)
├── ViewModels/      # MVVM ViewModel
├── Views/           # Avalonia UI (XAML)
└── Program.cs       # Точка входа
```

## Изменения по сравнению с оригиналом

1. **UI**: WinForms → Avalonia UI (кроссплатформенный)
2. **Пути Chrome**: Автоматическое определение путей профиля Chrome для каждой ОС
3. **HardwareInfo**: Кроссплатформенная идентификация оборудования (ioreg на macOS, machine-id на Linux)
4. **Совместимость**: WinForms API-совместимый слой для минимальных изменений бизнес-логики
