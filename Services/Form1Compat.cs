using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Botva2025.Services;

namespace Botva2025;

/// <summary>
/// Compatibility shim for Form1 that provides the same public interface
/// as the original WinForms Form1, but backed by AppSettings and LogService.
/// Business logic modules access Form1._Form1 to read labels and log messages.
/// </summary>
public class Form1 : Form
{
    public static Form1? _Form1 { get; set; }
    public static OpenQA.Selenium.IWebDriver? WebCrom { get; set; }

    // Labels (read by business logic for display)
    public Label labelKri { get; } = new();
    public Label labelName { get; } = new();
    public Label labelZoloto { get; } = new();
    public Label labelZelen { get; } = new();
    public Label labelPir { get; } = new();
    public Label labelStatus { get; } = new();
    public Label label1 { get; } = new();
    public Label label2 { get; } = new();
    public Label label3 { get; } = new();
    public Label label4 { get; } = new();
    public Label label5 { get; } = new();
    public Label label10 { get; } = new();
    public Label label11 { get; } = new();
    public Label label12 { get; } = new();
    public Label label13 { get; } = new();
    public Label label14 { get; } = new();
    public Label label15 { get; } = new();
    public Label label16 { get; } = new();
    public Label labelTimeLetun1 { get; } = new();
    public Label labelTimeLetun2 { get; } = new();
    public Label labelTimeLetun3 { get; } = new();
    public Label labelTimeLetun4 { get; } = new();

    // TextBoxes
    public TextBox userName { get; } = new();
    public TextBox userPass { get; } = new();
    public TextBox textBoxConsole { get; } = new();

    // ComboBoxes
    public ComboBox userServer { get; } = new();
    public ComboBox comboBoxAkciiServer1 { get; } = new();
    public ComboBox comboBoxAkciiServer2 { get; } = new();
    public ComboBox comboBoxAkciiAvatar1 { get; } = new();
    public ComboBox comboBoxAkciiAvatar2 { get; } = new();
    public ComboBox comboBoxKarKar { get; } = new();
    public ComboBox comboBoxPodzemPovtor { get; } = new();
    public ComboBox comboBoxPodzemSKokogoMesim { get; } = new();
    public ComboBox comboBoxPodzemKydaIdem { get; } = new();
    public ComboBox comboBoxArenaMax { get; } = new();
    public ComboBox comboBoxBodalkaTime { get; } = new();

    // CheckBoxes - all backed by AppSettings
    public CheckBox checkBoxBodalka { get; } = new();
    public CheckBox checkBoxKriMax { get; } = new();
    public CheckBox checkBoxBodalkaShtab { get; } = new();
    public CheckBox checkBoxBodalkaZorro { get; } = new();
    public CheckBox checkBoxBodalkaStrashilki { get; } = new();
    public CheckBox checkBoxRabota { get; } = new();
    public CheckBox checkBoxKlassIstorii { get; } = new();
    public CheckBox checkBoxKorablik { get; } = new();
    public CheckBox checkBoxYmeniy { get; } = new();
    public CheckBox checkBoxArena { get; } = new();
    public CheckBox checkBoxGo { get; } = new();
    public CheckBox checkBoxLoad { get; } = new();
    public CheckBox checkBox_Go { get; } = new();
    public CheckBox checkBoxMalPriklMax { get; } = new();
    public CheckBox checkBoxMalPrik { get; } = new();
    public CheckBox checkBoxBolshoePrikl { get; } = new();
    public CheckBox checkBoxKarKar { get; } = new();
    public CheckBox checkBoxKach { get; } = new();
    public CheckBox checkBoxKach1 { get; } = new();
    public CheckBox checkBoxKach2 { get; } = new();
    public CheckBox checkBoxKach3 { get; } = new();
    public CheckBox checkBoxKach4 { get; } = new();
    public CheckBox checkBoxKach5 { get; } = new();
    public CheckBox checkBoxKachMax { get; } = new();
    public CheckBox checkBoxPodzemKriZoloto { get; } = new();
    public CheckBox checkBoxAvatarShaxta { get; } = new();
    public CheckBox checkBoxAvatarBodalka { get; } = new();
    public CheckBox checkBoxAvatarShtabBeliySpisok { get; } = new();
    public CheckBox checkBoxAvatarKorablik { get; } = new();
    public CheckBox checkBoxAvatarZemliSbor { get; } = new();
    public CheckBox checkBoxLetaushayKorova { get; } = new();
    public CheckBox checkBoxPandaProdat { get; } = new();
    public CheckBox checkBoxPandaIspolzovatVse { get; } = new();
    public CheckBox checkBoxPandaOtkryt { get; } = new();
    public CheckBox checkBoxKrepostJalovatsy { get; } = new();
    public CheckBox checkBoxSrajalka { get; } = new();
    public CheckBox checkBoxDozor { get; } = new();
    public CheckBox checkBoxMuzey { get; } = new();
    public CheckBox checkBoxRabotaYcheba { get; } = new();
    public CheckBox checkBoxRabotaOchistka { get; } = new();
    public CheckBox checkBoxRabotaPlavka { get; } = new();
    public CheckBox checkBoxKarera { get; } = new();
    public CheckBox checkBoxAvatarMyzey { get; } = new();
    public CheckBox checkBoxIkarus { get; } = new();
    public CheckBox checkBoxAvatarPolyna { get; } = new();
    public CheckBox checkBoxAvatarStrashilki { get; } = new();
    public CheckBox checkBoxKrepostShijinaTuristaKlad { get; } = new();
    public CheckBox checkBoxKrepostShijinaTuristaRazvedka { get; } = new();
    public CheckBox checkBoxAvatarIkarus { get; } = new();
    public CheckBox checkBoxAvatar_Kach5 { get; } = new();
    public CheckBox checkBoxAvatarKach { get; } = new();
    public CheckBox checkBoxAvatar_Kach1 { get; } = new();
    public CheckBox checkBoxAvatar_Kach2 { get; } = new();
    public CheckBox checkBoxAvatar_Kach3 { get; } = new();
    public CheckBox checkBoxAvatar_Kach4 { get; } = new();
    public CheckBox checkBoxKrepostTaverna { get; } = new();
    public CheckBox checkBoxAvatarTaynyyOrden { get; } = new();
    public CheckBox checkBoxKatokombOchki { get; } = new();
    public CheckBox checkBoxKatokombPyl { get; } = new();
    public CheckBox checkBoxKatokombSyr { get; } = new();
    public CheckBox checkBoxKatokombPirashi { get; } = new();
    public CheckBox checkBoxKatokomb { get; } = new();
    public CheckBox checkBoxAvatarTaynyyOrdenSpusk { get; } = new();
    public CheckBox checkBoxKrepostDub { get; } = new();
    public CheckBox checkBoxKrepostPodzemnyeToneli { get; } = new();
    public CheckBox checkBoxKrepostAkademiyPrikluchencevZamok { get; } = new();
    public CheckBox checkBoxKrepostAkademiyPrikluchencevHram { get; } = new();
    public CheckBox checkBoxFermaAvatar { get; } = new();
    public CheckBox checkBoxFerma { get; } = new();
    public CheckBox checkBoxMaxBoss { get; } = new();
    public CheckBox сheckBoxKrepostKatokomby { get; } = new();
    public CheckBox checkBoxAvatarKachPirashka { get; } = new();
    public CheckBox checkBoxArenaList { get; } = new();
    public CheckBox checkBoxArenaShtab { get; } = new();
    public CheckBox checkBoxRadyjniySundyk { get; } = new();
    public CheckBox checkBoxKrepostArenaGladiator_upgradeMonstr { get; } = new();
    public CheckBox checkBoxKrepostArenaGladiator_UpgradeOrujie { get; } = new();
    public CheckBox checkBoxAvatarBitvaShashta { get; } = new();
    public CheckBox checkBoxZapuskSvernuto { get; } = new();
    public CheckBox checkBoxVospitalka { get; } = new();
    public CheckBox checkBoxZagovor { get; } = new();
    public CheckBox checkBoxTavernaYarmarka { get; } = new();
    public CheckBox checkBoxKachPirashki { get; } = new();
    public CheckBox checkBoxRabyProdat { get; } = new();
    public CheckBox checkBoxPylProdat { get; } = new();
    public CheckBox checkBoxPylKypit { get; } = new();
    public CheckBox checkBoxPokypaemMylo { get; } = new();
    public CheckBox checkBoxPokypaemRtut { get; } = new();
    public CheckBox checkBoxPokypaemYdren { get; } = new();
    public CheckBox checkBoxReloadWebDriver { get; } = new();
    public CheckBox checkBoxSyndykOpen { get; } = new();
    public CheckBox checkBoxKachPirashkiPost { get; } = new();
    public CheckBox checkBoxHramParyshihIstin { get; } = new();
    public CheckBox checkBoxZamok { get; } = new();
    public CheckBox checkBoxTavernaLuchsheHyje { get; } = new();
    public CheckBox checkBoxPodzemkyeZaly { get; } = new();
    public CheckBox checkBoxTavernaBotols { get; } = new();
    public CheckBox checkBoxTavernaVoyna { get; } = new();
    public CheckBox checkBoxAvatarTaynyyOrdenSvitki { get; } = new();

    // WebBrowser (for logging)
    public WebBrowser webBrowserLog { get; } = new();

    // BackgroundWorker
    public BackgroundWorker backgroundWorkerMain { get; } = new();

    // Panels
    public Panel panel1 { get; } = new();
    public Panel panel2 { get; } = new();
    public Panel panel3 { get; } = new();
    public Panel panelPodzem { get; } = new();
    public Panel panelJestynshik { get; } = new();

    // Buttons
    public Button buttonGo { get; } = new();
    public Button buttonBrauzer { get; } = new();

    // ToolTip
    public ToolTip toolTip1 { get; } = new();

    // NotifyIcon
    public NotifyIcon notifyIcon1 { get; } = new();

    // PictureBoxes
    public PictureBox pictureBox1 { get; } = new();

    public Form1()
    {
        _Form1 = this;
        WebCrom = BotState.WebDriver;
        LoadCheckboxStates();
    }

    /// <summary>
    /// Load all checkbox states from AppSettings
    /// </summary>
    private void LoadCheckboxStates()
    {
        var checkboxes = GetType().GetProperties()
            .Where(p => p.PropertyType == typeof(CheckBox));

        foreach (var prop in checkboxes)
        {
            var cb = (CheckBox)prop.GetValue(this)!;
            cb.Name = prop.Name;
            cb.Checked = AppSettings.Get(prop.Name, false);
        }

        userName.Text = AppSettings.Get("userName", "");
        userPass.Text = AppSettings.Get("userPass", "");
        userServer.SelectedIndex = AppSettings.Get("userServer", 0);
    }

    private System.Reflection.PropertyInfo[] GetCheckboxProperties()
    {
        return GetType().GetProperties()
            .Where(p => p.PropertyType == typeof(CheckBox))
            .ToArray();
    }
}
