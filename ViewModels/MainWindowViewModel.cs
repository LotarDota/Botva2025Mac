using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Botva2025.Services;
using OpenQA.Selenium;

namespace Botva2025.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    // Login fields
    [ObservableProperty] private string _userName = "";
    [ObservableProperty] private string _userPass = "";
    [ObservableProperty] private int _userServer;
    [ObservableProperty] private string _statusText = "Статус: Ожидание";
    [ObservableProperty] private bool _isRunning;
    [ObservableProperty] private bool _isBotActive;

    // Log
    public ObservableCollection<string> ConsoleLog => LogService.ConsoleLines;
    public ObservableCollection<string> HtmlLog => LogService.HtmlLogLines;

    // Server options
    public string[] ServerOptions { get; } = { "Сервер 1 (g1)", "Сервер 2 (g2)", "Сервер 3 (g3)", "Турбо", "Аватар" };

    // === ОСНОВНОЙ СЕРВЕР Checkboxes ===
    [ObservableProperty] private bool _checkBoxGo;
    [ObservableProperty] private bool _checkBoxLoad;
    [ObservableProperty] private bool _checkBoxBodalka;
    [ObservableProperty] private bool _checkBoxBodalkaShtab;
    [ObservableProperty] private bool _checkBoxBodalkaZorro;
    [ObservableProperty] private bool _checkBoxBodalkaStrashilki;
    [ObservableProperty] private bool _checkBoxRabota;
    [ObservableProperty] private bool _checkBoxKlassIstorii;
    [ObservableProperty] private bool _checkBoxKorablik;
    [ObservableProperty] private bool _checkBoxYmeniy;
    [ObservableProperty] private bool _checkBoxArena;
    [ObservableProperty] private bool _checkBoxSrajalka;
    [ObservableProperty] private bool _checkBoxDozor;
    [ObservableProperty] private bool _checkBoxMuzey;
    [ObservableProperty] private bool _checkBoxIkarus;
    [ObservableProperty] private bool _checkBoxFerma;
    [ObservableProperty] private bool _checkBoxKriMax;
    [ObservableProperty] private bool _checkBoxMaxBoss;
    [ObservableProperty] private bool _checkBoxVospitalka;
    [ObservableProperty] private bool _checkBoxZagovor;

    // === Помогашки/Качалка ===
    [ObservableProperty] private bool _checkBoxKach;
    [ObservableProperty] private bool _checkBoxKach1;
    [ObservableProperty] private bool _checkBoxKach2;
    [ObservableProperty] private bool _checkBoxKach3;
    [ObservableProperty] private bool _checkBoxKach4;
    [ObservableProperty] private bool _checkBoxKach5;
    [ObservableProperty] private bool _checkBoxKachMax;
    [ObservableProperty] private bool _checkBoxKachPirashki;
    [ObservableProperty] private bool _checkBoxKachPirashkiPost;

    // === Работа ===
    [ObservableProperty] private bool _checkBoxRabotaYcheba;
    [ObservableProperty] private bool _checkBoxRabotaOchistka;
    [ObservableProperty] private bool _checkBoxRabotaPlavka;
    [ObservableProperty] private bool _checkBoxKarera;

    // === Летуны ===
    [ObservableProperty] private bool _checkBoxLetaushayKorova;

    // === Крепость ===
    [ObservableProperty] private bool _checkBoxKrepostJalovatsy;
    [ObservableProperty] private bool _checkBoxKrepostTaverna;
    [ObservableProperty] private bool _checkBoxKrepostDub;
    [ObservableProperty] private bool _checkBoxKrepostPodzemnyeToneli;
    [ObservableProperty] private bool _checkBoxKrepostAkademiyPrikluchencevZamok;
    [ObservableProperty] private bool _checkBoxKrepostAkademiyPrikluchencevHram;
    [ObservableProperty] private bool _checkBoxKrepostShijinaTuristaKlad;
    [ObservableProperty] private bool _checkBoxKrepostShijinaTuristaRazvedka;

    // === Таверна ===
    [ObservableProperty] private bool _checkBoxTavernaYarmarka;
    [ObservableProperty] private bool _checkBoxTavernaBotols;
    [ObservableProperty] private bool _checkBoxTavernaVoyna;
    [ObservableProperty] private bool _checkBoxTavernaLuchsheHyje;

    // === Аватар ===
    [ObservableProperty] private bool _checkBoxAvatarShaxta;
    [ObservableProperty] private bool _checkBoxAvatarBodalka;
    [ObservableProperty] private bool _checkBoxAvatarShtabBeliySpisok;
    [ObservableProperty] private bool _checkBoxAvatarKorablik;
    [ObservableProperty] private bool _checkBoxAvatarZemliSbor;
    [ObservableProperty] private bool _checkBoxAvatarMyzey;
    [ObservableProperty] private bool _checkBoxAvatarIkarus;
    [ObservableProperty] private bool _checkBoxAvatarPolyna;
    [ObservableProperty] private bool _checkBoxAvatarStrashilki;
    [ObservableProperty] private bool _checkBoxAvatarKach;
    [ObservableProperty] private bool _checkBoxAvatarKachPirashka;
    [ObservableProperty] private bool _checkBoxAvatarBitvaShashta;
    [ObservableProperty] private bool _checkBoxAvatarTaynyyOrden;
    [ObservableProperty] private bool _checkBoxAvatarTaynyyOrdenSpusk;
    [ObservableProperty] private bool _checkBoxAvatarTaynyyOrdenSvitki;
    [ObservableProperty] private bool _checkBoxFermaAvatar;

    // === Торговля ===
    [ObservableProperty] private bool _checkBoxRabyProdat;
    [ObservableProperty] private bool _checkBoxPylProdat;
    [ObservableProperty] private bool _checkBoxPylKypit;
    [ObservableProperty] private bool _checkBoxPokypaemMylo;
    [ObservableProperty] private bool _checkBoxPokypaemRtut;
    [ObservableProperty] private bool _checkBoxPokypaemYdren;

    // === Панда ===
    [ObservableProperty] private bool _checkBoxPandaProdat;
    [ObservableProperty] private bool _checkBoxPandaIspolzovatVse;
    [ObservableProperty] private bool _checkBoxPandaOtkryt;

    // === Другое ===
    [ObservableProperty] private bool _checkBoxReloadWebDriver;
    [ObservableProperty] private bool _checkBoxSyndykOpen;
    [ObservableProperty] private bool _checkBoxRadyjniySundyk;
    [ObservableProperty] private bool _checkBoxArenaList;
    [ObservableProperty] private bool _checkBoxArenaShtab;
    [ObservableProperty] private bool _checkBoxHramParyshihIstin;
    [ObservableProperty] private bool _checkBoxZamok;
    [ObservableProperty] private bool _checkBoxPodzemkyeZaly;
    [ObservableProperty] private bool _checkBoxKatokomb;
    [ObservableProperty] private bool _checkBoxKatokombOchki;
    [ObservableProperty] private bool _checkBoxKatokombPyl;
    [ObservableProperty] private bool _checkBoxKatokombSyr;
    [ObservableProperty] private bool _checkBoxKatokombPirashi;

    // Resource labels
    [ObservableProperty] private string _labelName = "";
    [ObservableProperty] private string _labelZoloto = "0";
    [ObservableProperty] private string _labelKri = "0";
    [ObservableProperty] private string _labelPir = "0";
    [ObservableProperty] private string _labelZelen = "0";

    private CancellationTokenSource? _botCts;

    public MainWindowViewModel()
    {
        LoadSettings();
    }

    private void LoadSettings()
    {
        UserName = AppSettings.Get("userName", "");
        UserPass = AppSettings.Get("userPass", "");
        UserServer = AppSettings.Get("userServer", 0);

        // Load all checkbox states from AppSettings
        foreach (var prop in GetType().GetProperties())
        {
            if (prop.Name.StartsWith("CheckBox") && prop.PropertyType == typeof(bool) && prop.CanWrite)
            {
                // Convert property name to settings key (first char lowercase)
                string key = char.ToLower(prop.Name[0]) + prop.Name[1..];
                bool val = AppSettings.Get(key, false);
                prop.SetValue(this, val);
            }
        }
    }

    private void SaveSetting(string key, object value)
    {
        AppSettings.Set(key, value);
    }

    partial void OnUserNameChanged(string value) => SaveSetting("userName", value);
    partial void OnUserPassChanged(string value) => SaveSetting("userPass", value);
    partial void OnUserServerChanged(int value) => SaveSetting("userServer", value);

    [RelayCommand]
    private void Login()
    {
        if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserPass))
        {
            LogService.LogConsole("Введите логин и пароль");
            return;
        }
        SaveSetting("userName", UserName);
        SaveSetting("userPass", UserPass);
        SaveSetting("userServer", UserServer);
        LogService.LogConsole($"Авторизация: {UserName} на сервере {ServerOptions[UserServer]}");
    }

    [RelayCommand]
    private void StartBot()
    {
        if (IsRunning)
        {
            StopBot();
            return;
        }

        IsRunning = true;
        StatusText = "Статус: Запуск...";
        LogService.LogConsole("Запуск бота...");

        SaveAllCheckboxStates();

        // Initialize Form1 compat for business logic
        var form1 = new Form1();
        Form1.WebCrom = BotState.WebDriver;
        SyncFormState(form1);

        _botCts = new CancellationTokenSource();
        var ct = _botCts.Token;

        Task.Run(() =>
        {
            try
            {
                // Initialize WebDriver if needed
                if (BotState.WebDriver == null)
                {
                    LogService.LogConsole("Инициализация Chrome...");
                    BotState.WebDriver = WebCrome.InitializeBrowser();
                    if (BotState.WebDriver == null)
                    {
                        LogService.LogConsole("Ошибка: Chrome не запущен");
                        IsRunning = false;
                        return;
                    }
                    Form1.WebCrom = BotState.WebDriver;
                }

                StatusText = "Статус: Работает";
                LogService.LogConsole("Бот запущен");

                // Main bot loop
                while (!ct.IsCancellationRequested)
                {
                    try
                    {
                        SyncFormState(form1);
                        RunBotCycle(form1);
                    }
                    catch (Exception ex)
                    {
                        LogService.LogConsole($"Ошибка цикла: {ex.Message}");
                    }
                    Task.Delay(2000).Wait(ct);
                }
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                LogService.LogConsole($"Ошибка бота: {ex.Message}");
            }
            finally
            {
                IsRunning = false;
                StatusText = "Статус: Остановлен";
                LogService.LogConsole("Бот остановлен");
            }
        }, ct);
    }

    private void StopBot()
    {
        LogService.LogConsole("Остановка бота...");
        _botCts?.Cancel();
    }

    private void SyncFormState(Form1 form1)
    {
        // Sync ViewModel checkbox states to Form1 compat for business logic
        foreach (var prop in GetType().GetProperties())
        {
            if (prop.Name.StartsWith("CheckBox") && prop.PropertyType == typeof(bool))
            {
                string key = char.ToLower(prop.Name[0]) + prop.Name[1..];
                bool val = (bool)prop.GetValue(this)!;
                AppSettings.Set(key, val);
            }
        }
        form1.userName.Text = UserName;
        form1.userPass.Text = UserPass;
        form1.userServer.SelectedIndex = UserServer;
    }

    private void RunBotCycle(Form1 form1)
    {
        // This mirrors Form1.ExecuteAllMethods()
        var driver = BotState.WebDriver;
        if (driver == null) return;

        Action[] actions = new Action[]
        {
            () => { if (CheckBoxLoad) new Pomogashki(driver, form1).LogIn(UserName, UserPass, UserServer); },
            () => { new AkciiServer(driver, "comboBoxAkciiServer1", "").AkciiServerMain(); },
            () => { new AkciiServer(driver, "comboBoxAkciiServer2", "").AkciiServerMain(); },
            () => { new Bodalka(driver).BodalkaMain(); },
            () => { new Pomogashki(driver, form1)._KachMain(); },
            () => { new Avtomatiki(driver).AvtomatikiMain(); },
            () => { new Letuny(driver, form1).LetynMain(); },
            () => { new Krepost(driver).KrepostMain(); },
            () => { new Alhimiy(driver).MainAlhimiy(); },
            () => { new TorgovayPloshadka(driver).MainTorgovayPloshadka(); },
            () => { new Taverna(driver).MainZvezdopad(); },
            () => { new Shashta(driver).ShashtaMain(); },
            () => { new Rabota(driver).AvtomatikiMain(); },
            () => { new Avatar(driver, form1).AvatarMain(); },
        };

        foreach (var action in actions)
        {
            try { action(); }
            catch (Exception) { }
        }
    }

    private void SaveAllCheckboxStates()
    {
        foreach (var prop in GetType().GetProperties())
        {
            if (prop.Name.StartsWith("CheckBox") && prop.PropertyType == typeof(bool))
            {
                string key = char.ToLower(prop.Name[0]) + prop.Name[1..];
                AppSettings.Set(key, prop.GetValue(this)!);
            }
        }
    }

    [RelayCommand]
    private void OpenBrowser()
    {
        WebCrome.BrauzerVisibleNew();
    }
}
