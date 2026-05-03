using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using Botva2025.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Botva2025;

public class Krepost
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<char, bool> _003C_003E9__55_0;

		public static Func<char, bool> _003C_003E9__55_1;

		public static Func<char, bool> _003C_003E9__62_0;

		public static Func<char, bool> _003C_003E9__64_0;

		public static Func<char, bool> _003C_003E9__64_1;

		public static Func<char, bool> _003C_003E9__65_0;

		public static Func<char, bool> _003C_003E9__66_0;

		public static Func<char, bool> _003C_003E9__68_0;

		public static Func<char, bool> _003C_003E9__71_0;

		public static Func<char, bool> _003C_003E9__71_1;

		public static Func<char, bool> _003C_003E9__71_2;

		public static Func<char, bool> _003C_003E9__73_0;

		public static Func<char, bool> _003C_003E9__77_0;

		public static System.Windows.Forms.MethodInvoker _003C_003E9__78_0;

		public static Func<char, bool> _003C_003E9__78_1;

		internal bool _003CKrepostKatokomby_003Eb__55_0(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CKrepostKatokomby_003Eb__55_1(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CKrepostAkademiyPrikluchencevHram_003Eb__62_0(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CKrepostAkademiyPrikluchencevZamok_003Eb__64_0(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CKrepostAkademiyPrikluchencevZamok_003Eb__64_1(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CKrepostPodzemnyeToneli_003Eb__65_0(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CKrepostKatokomb_003Eb__66_0(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CKrepostTaverna_003Eb__68_0(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CKrepostRazvedka_003Eb__71_0(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CKrepostRazvedka_003Eb__71_1(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CKrepostRazvedka_003Eb__71_2(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CZamok_003Eb__73_0(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CEnergy_003Eb__77_0(char c)
		{
			return char.IsDigit(c);
		}

		internal void _003CHramParyshihIstin_003Eb__78_0()
		{
			((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус:";
		}

		internal bool _003CHramParyshihIstin_003Eb__78_1(char c)
		{
			return char.IsDigit(c);
		}
	}

	private IWebDriver _driver;

	public DateTime krepostBashnyDateTime { get; set; }

	public DateTime krepostRazvedkaDateTime { get; set; }

	public DateTime krepostKladDateTime { get; set; }

	public DateTime krepostTavernaDateTime { get; set; }

	public DateTime krepostDubDateTime { get; set; }

	public DateTime krepostKatakombDateTime { get; set; }

	public DateTime krepostPodzemnyeToneliDateTime { get; set; }

	public DateTime krepostAkademiyPrikluchencevHramDateTime { get; set; }

	public DateTime krepostAkademiyPrikluchencevZamokDateTime { get; set; }

	public DateTime krepostArenaGladiatorDateTime { get; set; }

	public DateTime hramParyshihIstinDateTime { get; set; }

	public DateTime zamokDateTime { get; set; }

	public DateTime krepostKatokombyDateTime { get; set; }

	public Krepost(IWebDriver driver)
	{
		_driver = driver;
		krepostBashnyDateTime = DateTime.Now;
		krepostRazvedkaDateTime = DateTime.Now;
		krepostKladDateTime = DateTime.Now;
		krepostTavernaDateTime = DateTime.Now;
		krepostDubDateTime = DateTime.Now;
		krepostKatakombDateTime = DateTime.Now;
		krepostPodzemnyeToneliDateTime = DateTime.Now;
		krepostAkademiyPrikluchencevHramDateTime = DateTime.Now;
		krepostAkademiyPrikluchencevZamokDateTime = DateTime.Now;
		krepostArenaGladiatorDateTime = DateTime.Now;
		hramParyshihIstinDateTime = DateTime.Now;
		zamokDateTime = DateTime.Now;
		krepostKatokombyDateTime = DateTime.Now;
	}

	public void KrepostMain()
	{
		try
		{
			KrepostBashny();
		}
		catch
		{
		}
		try
		{
			KrepostRazvedka();
		}
		catch
		{
			krepostRazvedkaDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			KrepostKlad();
		}
		catch
		{
			krepostKladDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			KrepostTaverna();
		}
		catch
		{
			krepostTavernaDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			KrepostDub();
		}
		catch
		{
			krepostDubDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			KrepostKatokomb();
		}
		catch
		{
			krepostKatakombDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			KrepostPodzemnyeToneli();
		}
		catch
		{
			krepostPodzemnyeToneliDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			KrepostAkademiyPrikluchencevHram();
		}
		catch
		{
			krepostAkademiyPrikluchencevHramDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			KrepostAkademiyPrikluchencevZamok();
		}
		catch
		{
			krepostAkademiyPrikluchencevZamokDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			KrepostArenaGladiator();
		}
		catch
		{
			krepostArenaGladiatorDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			HramParyshihIstin();
		}
		catch
		{
			hramParyshihIstinDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			Zamok();
		}
		catch
		{
			zamokDateTime = DateTime.Now.AddMinutes(5.0);
		}
	}

	public DateTime KrepostKatokomby()
	{
		if (krepostKatokombyDateTime > DateTime.Now)
		{
			return krepostKatokombyDateTime;
		}
		if (!AppSettings.Get("checkBoxKrepostKatokomby", defaultValue: false))
		{
			return krepostArenaGladiatorDateTime = DateTime.Now.AddMinutes(5.0);
		}
		UpdateStatus("Статус:Крепость Катокомбы");
		_driver.isExecuteScriptClick(By.Id("m4"), "Клик Крепость");
		if (_driver.isExecuteScriptClick(By.XPath("//a[@href=\"fort.php?a=place&type=17\"]"), "Клик Катокомбы"))
		{
			Thread.Sleep(1000);
		}
		long[] array = new long[3];
		for (int i = 1; i < 4; i++)
		{
			string source = _driver.IsFindElement(By.XPath($"(//b[contains(@class,\"icon2 catacomb_unit\")]//..//span[@data-solders])[{i}]"))?.GetAttribute("data-solders") ?? "";
			long.TryParse(string.Join("", source.Where((char c) => char.IsDigit(c))), out array[i - 1]);
		}
		int num = 0;
		for (int num2 = 1; num2 < array.Length; num2++)
		{
			if (array[num2] < 5000)
			{
				return DateTime.Now.AddMinutes(15.0);
			}
			if (array[num2] > array[num])
			{
				num = num2;
			}
		}
		for (int num3 = 0; num3 < 10; num3++)
		{
			if (!AppSettings.Get("checkBoxKrepostKatokomby", defaultValue: false))
			{
				UpdateStatus("Статус: ");
				return DateTime.Now.AddMinutes(15.0);
			}
			if (array[0] != 0L)
			{
				_driver.IsFindElement(By.XPath("//div[@class=\"btn\" and string(.)=\"Походы\"]")).IsClick("Походы");
			}
			int[] array2 = new int[3];
			for (int num4 = 1; num4 < 4; num4++)
			{
				string source2 = _driver.IsFindElement(By.XPath($"(//div[@class=\"catacomb_rooms enemy\"]//div[@class=\"catacomb_room_level\"])[{num4}]"))?.GetAttribute("outerText") ?? "";
				int.TryParse(string.Join("", source2.Where((char c) => char.IsDigit(c))), out array2[num4 - 1]);
			}
			int num5 = 0;
			for (int num6 = 1; num6 < array2.Length; num6++)
			{
				if (array2[num6] < array2[num5])
				{
					num5 = num6;
				}
			}
			if (array2[num5] == 0)
			{
				_driver.isExecuteScriptClick(By.Id("m4"), "Клик Крепость");
				if (_driver.isExecuteScriptClick(By.XPath("//a[@href=\"fort.php?a=place&type=17\"]"), "Клик Катокомбы"))
				{
					Thread.Sleep(1000);
				}
				_driver.IsFindElement(By.XPath("//div[@class=\"btn\" and string(.)=\"Походы\"]")).IsClick("Походы");
				continue;
			}
			_driver.IsFindElement(By.XPath($"(//div[@class=\"catacomb_rooms enemy\"]//div[@class=\"catacomb_room_action\"])[{num5 + 1}]")).IsClick("иду в комнату " + (num5 + 1));
			Actions actions = new Actions(_driver);
			if (array2[num5] == 1)
			{
				_driver.IsFindElement(By.XPath($"(//div[@class=\"catacomb_sortable ui-sortable\"]//div[@class=\"check_area\"])[{num + 1}]")).IsClick("выбираю бойца " + (num + 1));
				ClearJava();
				for (int num7 = 1; num7 < 6; num7++)
				{
					string text = $"(//div[contains(@class,\"popup_my_container\")]//div[contains(@class,\"catacomb_scrolls bgr_2\")]//b[@class=\"modern_amount\"])[{num7}]";
					if (_driver.IsFindElement(By.XPath(text)).isGetAttribute("outerText") == "9")
					{
						IWebElement toElement = _driver.IsFindElement(By.XPath(text + "//.."));
						actions.MoveToElement(toElement).Click().Perform();
					}
				}
				if (_driver.IsFindElement(By.XPath("//div[contains(@class,\"popup_my_container\")]//div[contains(@class,\"button_new\")]/span[string(.)=\"ОТПРАВИТЬ\"]")).IsClick("отправить "))
				{
					UpdateStatus("Статус:Крепость Катокомбы " + (num3 + 1));
					_driver.IsFindElement(By.XPath("//div[@onclick=\"history.back();\"]")).IsClick("Назад ");
				}
			}
			if (array2[num5] == 2)
			{
				_driver.IsFindElement(By.XPath("(//div[@class=\"catacomb_sortable ui-sortable\"]//div[@class=\"check_area\"])[3]")).IsClick("выбираю бойца " + 3);
				_driver.IsFindElement(By.XPath("(//div[@class=\"catacomb_sortable ui-sortable\"]//div[@class=\"check_area\"])[2]")).IsClick("выбираю бойца " + 2);
				ClearJava();
				for (int num8 = 1; num8 < 6; num8++)
				{
					string text2 = $"(//div[contains(@class,\"popup_my_container\")]//div[contains(@class,\"catacomb_scrolls bgr_2\")]//b[@class=\"modern_amount\"])[{num8}]";
					if (_driver.IsFindElement(By.XPath(text2)).isGetAttribute("outerText") == "9")
					{
						IWebElement toElement2 = _driver.IsFindElement(By.XPath(text2 + "//.."));
						actions.MoveToElement(toElement2).Click().Perform();
					}
				}
				if (_driver.IsFindElement(By.XPath("//div[contains(@class,\"popup_my_container\")]//div[contains(@class,\"button_new\")]/span[string(.)=\"ОТПРАВИТЬ\"]")).IsClick("отправить "))
				{
					_driver.IsFindElement(By.XPath("//div[@onclick=\"history.back();\"]")).IsClick("Назад ");
				}
			}
			if (array2[num5] == 3)
			{
				_driver.IsFindElement(By.XPath("(//div[@class=\"catacomb_sortable ui-sortable\"]//div[@class=\"check_area\"])[3]")).IsClick("выбираю бойца " + 3);
				_driver.IsFindElement(By.XPath("(//div[@class=\"catacomb_sortable ui-sortable\"]//div[@class=\"check_area\"])[2]")).IsClick("выбираю бойца " + 2);
				ClearJava();
				for (int num9 = 1; num9 < 6; num9++)
				{
					string text3 = $"(//div[contains(@class,\"popup_my_container\")]//div[contains(@class,\"catacomb_scrolls bgr_2\")]//b[@class=\"modern_amount\"])[{num9}]";
					if (_driver.IsFindElement(By.XPath(text3)).isGetAttribute("outerText") != "0")
					{
						IWebElement toElement3 = _driver.IsFindElement(By.XPath(text3 + "//.."));
						actions.MoveToElement(toElement3).Click().Perform();
					}
				}
				if (_driver.isExecuteScriptClick(By.XPath("//div[contains(@class,\"popup_my_container\")]//div[contains(@class,\"button_new\")]/span[string(.)=\"ОТПРАВИТЬ\"]"), "Клик отправить", 1000))
				{
					_driver.IsFindElement(By.XPath("//div[@onclick=\"history.back();\"]")).IsClick("Назад");
				}
			}
			UpdateStatus("Статус:Крепость Катокомбы " + num3);
		}
		UpdateStatus("Статус: ");
		return DateTime.Now.AddMinutes(15.0);
	}

	private void ClearJava()
	{
		try
		{
			IWebElement webElement = _driver.FindElement(By.XPath("//div[@class='shadow9']"));
			IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)_driver;
			javaScriptExecutor.ExecuteScript("arguments[0].innerHTML = '';", webElement);
		}
		catch
		{
		}
	}

	public DateTime KrepostArenaGladiator()
	{
		if (krepostArenaGladiatorDateTime > DateTime.Now)
		{
			return krepostArenaGladiatorDateTime;
		}
		if (!AppSettings.Get("checkBoxKrepostArenaGladiator", defaultValue: false))
		{
			return krepostArenaGladiatorDateTime = DateTime.Now.AddMinutes(5.0);
		}
		UpdateStatus("Статус:Крепость Арена Гладиаторов");
		_driver.isExecuteScriptClick(By.Id("m4"), "Клик Крепость");
		if (_driver.isExecuteScriptClick(By.XPath("//a[@href=\"fort.php?a=place&type=15\"]"), "Клик Гладиатор"))
		{
			Thread.Sleep(1000);
		}
		Regex regex = new Regex("(?i)(\\d+)/(\\d+)");
		MatchCollection matchCollection = regex.Matches(_driver.IsFindElement(By.XPath("//div[contains(text(),\"Проведено боев\")]")).isGetAttribute("outerText"));
		if (matchCollection[0].Groups[1].Value == matchCollection[0].Groups[2].Value)
		{
			UpdateStatus("Статус:");
			TimeSpan timeSpan = DateTime.Today.AddDays(1.0) - DateTime.Now;
			return krepostArenaGladiatorDateTime = DateTime.Now.AddSeconds(timeSpan.Seconds).AddMinutes(timeSpan.Minutes + 5).AddHours(timeSpan.Hours);
		}
		IJavaScriptExecutor javaScriptExecutor = _driver as IJavaScriptExecutor;
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			Thread.Sleep(500);
			if (num == 20)
			{
				break;
			}
			if (_driver.IsFindElement(By.XPath("//div[contains(@class,\"result0\")][not(contains(@style,\"display\"))]")) != null)
			{
				Thread.Sleep(600);
				i = 0;
				num++;
			}
			else if (_driver.IsFindElement(By.XPath("//div[contains(@onclick,\"fortFight\")][not(contains(@style,\"display\"))]/span")).IsClick("Далее"))
			{
				Thread.Sleep(2000);
				i = 0;
				num++;
			}
		}
		GladiatorOryjieUpgrade();
		GladiatorMonstrUpgrade();
		Regex regex2 = new Regex("(?i) active.*?data-id=.(\\d+).*?data-type=.(\\d)");
		MatchCollection matchCollection2 = regex2.Matches(_driver.IsFindElement(By.XPath("//table[contains(@class,\"default_table\")]")).isGetAttribute("outerHTML"));
		string[,] array = new string[matchCollection2.Count, 2];
		if (matchCollection2.Count != 0)
		{
			for (int j = 0; j < matchCollection2.Count; j++)
			{
				array[j, 0] = matchCollection2[j].Groups[1].Value;
				array[j, 1] = matchCollection2[j].Groups[2].Value;
			}
		}
		Regex regex3 = new Regex("(?i) active.*?data-id=\"(\\d+).*?data-type=\"(\\d)(?s).*?<span.*?УЧАСТВОВАТЬ.*?icon (.*?) ");
		string input = _driver.IsFindElement(By.XPath("//div[contains(@class,\"right_part\")]")).isGetAttribute("outerHTML");
		MatchCollection matchCollection3 = regex3.Matches(input);
		string[,] array2 = new string[matchCollection3.Count, 3];
		if (matchCollection3.Count != 0)
		{
			for (int k = 0; k < matchCollection3.Count; k++)
			{
				array2[k, 0] = matchCollection3[k].Groups[1].Value;
				array2[k, 1] = matchCollection3[k].Groups[2].Value;
				array2[k, 2] = matchCollection3[k].Groups[3].Value;
			}
		}
		IJavaScriptExecutor javaScriptExecutor2 = _driver as IJavaScriptExecutor;
		string text = javaScriptExecutor2.ExecuteScript("return KEY;").ToString();
		for (int l = 0; l < array2.GetLength(0); l++)
		{
			if (array2[l, 2].Contains("ico_coins_lite") || array2[l, 2].Contains("img_money_3_small"))
			{
				continue;
			}
			for (int m = 0; m < array.GetLength(0); m++)
			{
				if (!(array[m, 0] == ""))
				{
					if (array2[l, 0] == "")
					{
						break;
					}
					if (!(array2[l, 1] != array[m, 1]))
					{
						GladiatorPost(array[m, 0], array2[l, 0]);
						LogService.LogConsole("Гладиатор " + array[m, 0] + " " + array2[l, 0]);
						array2[l, 0] = "";
						array[m, 0] = "";
						break;
					}
				}
			}
		}
		if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//div[contains(text(),\"Проведено боев\")]//span[contains(@class,\"js_timer\")]")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result))
		{
			ArenaGladiatorKonec();
			UpdateStatus("Статус:");
			return krepostArenaGladiatorDateTime = DateTime.Now.AddSeconds(result.Second).AddMinutes(result.Minute + 2).AddHours(result.Hour);
		}
		ArenaGladiatorKonec();
		UpdateStatus("Статус:");
		return krepostArenaGladiatorDateTime = DateTime.Now.AddMinutes(5.0);
	}

	private void ArenaGladiatorKonec()
	{
		IWebElement webElement = _driver.IsFindElement(By.XPath("//div[contains(text(),\"Арена гладиаторов\")]"));
		IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)_driver;
		string text = " Зкончено";
		string script = "arguments[0].textContent += arguments[1];";
		javaScriptExecutor.ExecuteScript(script, webElement, text);
	}

	private string GladiatorPost(string _monstr, string _plase)
	{
		IJavaScriptExecutor javaScriptExecutor = _driver as IJavaScriptExecutor;
		javaScriptExecutor.ExecuteScript("$.post('ajax.php?m=patrick&place=fightclub',{},'JSON');");
		Thread.Sleep(250);
		string result = javaScriptExecutor.ExecuteScript("$.post('fort.php?a=place&type=15', { \r\n                                do_cmd: 'participate',\r\n                                place: '" + _plase + "',\r\n                                k: KEY,\r\n                                fighter_id: '" + _monstr + "'\r\n                                },\r\n                                    function(result) \r\n                        \t\t\t{\r\n                                        KEY = result.data.key;\r\n                                    \r\n                                    }, \r\n                                        'JSON');\r\n                                    return KEY;").ToString();
		Thread.Sleep(1000);
		return result;
	}

	private void GladiatorOryjieUpgrade()
	{
		if (AppSettings.Get("checkBoxKrepostArenaGladiator_UpgradeOrujie", defaultValue: false) && _driver.ResyKri() >= 100000 && _driver.IsFindElement(By.XPath("//div[contains(@class,\"can_upgrade\") and contains(@class,\"dark_bgr\")]")).IsClick("Клик вещь Апгрейд"))
		{
			_driver.IsFindElement(By.XPath("//div[contains(@class,\"button_new\")]//b[contains(@class,\"img_money_2_small\")]//..//input[@type=\"submit\"]")).IsClick("Клик вещь внутри Апгрейд");
			_driver.IsFindElement(By.XPath("//div[contains(@onclick,\"doReloadSoft\")]/span")).IsClick("Клик отмена");
		}
	}

	private void GladiatorMonstrUpgrade()
	{
		if (!AppSettings.Get("checkBoxKrepostArenaGladiator_upgradeMonstr", defaultValue: false))
		{
			return;
		}
		IWebElement webElement = _driver.IsFindElement(By.XPath("//div[contains(@class,\"can_upgrade\") and contains(@class,\"fort_fight_club_skill\")]"));
		if (webElement == null)
		{
			return;
		}
		int[] ari = new int[2];
		_driver.ResyPanda(out ari);
		int[] ari2 = new int[2];
		_driver.ResyZPanda(out ari2);
		webElement = _driver.IsFindElement(By.XPath("//div[contains(@class,\"can_upgrade\") and contains(@class,\"skill_1\")]"));
		if (webElement != null && ari[0] >= 35)
		{
			webElement.IsClick("клик Страшилка", 1000);
			if (_driver.IsFindElement(By.XPath("//select[@id=\"fort_fight_club_select\"]/option[@value=\"1\"]")).IsClick("Клик страшилка"))
			{
				Thread.Sleep(500);
				if (_driver.IsFindElement(By.XPath("//div[@id='fort_fight_club_reroll_button_2']//input[@type='submit']")).IsClick("Клик страшилка купить"))
				{
					ari[0] -= 35;
				}
			}
			_driver.IsFindElement(By.XPath("//div[contains(@class,'box_x_button')]")).IsClick("Клик Закрыть");
		}
		webElement = _driver.IsFindElement(By.XPath("//div[contains(@class,\"can_upgrade\") and contains(@class,\"skill_2\")]"));
		if (webElement != null && ari2[0] >= 3)
		{
			webElement.IsClick("клик Монстрик", 1000);
			if (_driver.IsFindElement(By.XPath("//select[@id=\"fort_fight_club_select\"]/option[@value=\"2\"]")).IsClick("Клик монстрик"))
			{
				Thread.Sleep(500);
				if (_driver.IsFindElement(By.XPath("//div[@id='fort_fight_club_reroll_button_2']//input[@type='submit']")).IsClick("Клик монстрик купить"))
				{
					ari2[0] -= 3;
				}
			}
			_driver.IsFindElement(By.XPath("//div[contains(@class,'box_x_button')]")).IsClick("Клик Закрыть");
		}
		webElement = _driver.IsFindElement(By.XPath("//div[contains(@class,\"can_upgrade\") and contains(@class,\"skill_3\")]"));
		if (webElement == null)
		{
			return;
		}
		if (ari2[0] == 0)
		{
			_driver.ResyZPanda(out ari2);
		}
		if (ari[0] == 0)
		{
			_driver.ResyPanda(out ari);
		}
		if (ari2[0] >= 1 && ari[0] >= 25)
		{
			webElement.IsClick("клик тыквоголов", 1000);
			if (_driver.IsFindElement(By.XPath("//select[@id=\"fort_fight_club_select\"]/option[@value=\"3\"]")).IsClick("Клик страшилка"))
			{
				Thread.Sleep(500);
				_driver.IsFindElement(By.XPath("//div[@id='fort_fight_club_reroll_button_2']//input[@type='submit']")).IsClick("Клик страшилка купить");
			}
			_driver.IsFindElement(By.XPath("//div[contains(@class,'box_x_button')]")).IsClick("Клик Закрыть");
		}
	}

	public DateTime KrepostAkademiyPrikluchencevHram()
	{
		if (krepostAkademiyPrikluchencevHramDateTime > DateTime.Now)
		{
			return krepostAkademiyPrikluchencevHramDateTime;
		}
		if (!AppSettings.Get("checkBoxKrepostAkademiyPrikluchencevHram", defaultValue: false))
		{
			return krepostAkademiyPrikluchencevHramDateTime = DateTime.Now.AddMinutes(5.0);
		}
		UpdateStatus("Статус:Крепость Академия Приключенцев храм");
		if (!_driver.Url.Contains("fort.php?a=place&type=14"))
		{
			_driver.isExecuteScriptClick(By.Id("m4"), "Клик Крепость");
			if (_driver.isExecuteScriptClick(By.XPath("//a[@href=\"fort.php?a=place&type=14\"]"), "Клик Академия"))
			{
				Thread.Sleep(1000);
			}
		}
		if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//div[contains(text(),\"Храм парящих истин\")]//..//span[contains(@class,\"js_timer\")]")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result))
		{
			UpdateStatus("Статус:");
			return krepostAkademiyPrikluchencevHramDateTime = DateTime.Now.AddSeconds(result.Second + 20).AddMinutes(result.Minute).AddHours(result.Hour);
		}
		if (AppSettings.Get("checkBoxMaxBoss", defaultValue: false) && _driver.FindElements(By.XPath("//div[contains(@class,\"bar_green_solid\") and contains(string(.),\"Храм парящих истин, парадный вход\")]//..//div[@onmouseover][contains(@class,\"grayscale\")]")).Count != 0)
		{
			UpdateStatus("Статус:");
			return krepostAkademiyPrikluchencevHramDateTime = DateTime.Now.AddMinutes(5.0);
		}
		string[] array = _driver.IsFindElement(By.XPath("//div[contains(text(),\"Отправить людишек\")]")).isGetAttribute("outerText").Split('/');
		int[] array2 = new int[2];
		for (int i = 0; i < array.Length; i++)
		{
			int.TryParse(string.Join("", array[i].Where((char c) => char.IsDigit(c))), out array2[i]);
		}
		if (array2[0] != array2[1])
		{
			if (_driver.IsFindElement(By.XPath("//span[contains(text(),\"Парадный вход\")]//input[@value=\"cmd_dunge\"]")).IsClick("Клик Парадный вход"))
			{
				Thread.Sleep(1000);
			}
		}
		else if (array2[1] != 0)
		{
			UpdateStatus("Статус:");
			TimeSpan timeSpan = DateTime.Today.AddDays(1.0) - DateTime.Now;
			return krepostAkademiyPrikluchencevHramDateTime = DateTime.Now.AddSeconds(timeSpan.Seconds).AddMinutes(timeSpan.Minutes + 5).AddHours(timeSpan.Hours);
		}
		_driver.IsFindElement(By.XPath("//span[contains(string(.),\"УРА!\") or contains(string(.),\"УВЫ!\")]")).IsClick("Клик Ура");
		if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//div[contains(text(),\"Храм парящих истин\")]//..//span[contains(@class,\"js_timer\")]")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out result))
		{
			UpdateStatus("Статус:");
			return krepostAkademiyPrikluchencevHramDateTime = DateTime.Now.AddSeconds(result.Second + 20).AddMinutes(result.Minute).AddHours(result.Hour);
		}
		UpdateStatus("Статус:");
		return krepostAkademiyPrikluchencevHramDateTime = DateTime.Now.AddMinutes(5.0);
	}

	private void UpdateStatus(string text)
	{
		Find.LabelStatus(text);
	}

	public DateTime KrepostAkademiyPrikluchencevZamok()
	{
		if (krepostAkademiyPrikluchencevZamokDateTime > DateTime.Now)
		{
			return krepostAkademiyPrikluchencevZamokDateTime;
		}
		if (!AppSettings.Get("checkBoxKrepostAkademiyPrikluchencevZamok", defaultValue: false))
		{
			return krepostAkademiyPrikluchencevZamokDateTime = DateTime.Now.AddMinutes(5.0);
		}
		UpdateStatus("Статус:Крепость Академия Приключенцев замок");
		int result = 0;
		if (!int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//li[@id=\"i169\"]")).isGetAttribute("outerText")
			where char.IsDigit(c)
			select c), out result))
		{
			LogService.LogHtml("Не вижу количество будок");
			UpdateStatus("Статус:");
			return krepostAkademiyPrikluchencevZamokDateTime = DateTime.Now.AddMinutes(5.0);
		}
		if (result < 1)
		{
			LogService.LogHtml("Kоличество будок " + result);
			UpdateStatus("Статус:");
			return krepostAkademiyPrikluchencevZamokDateTime = DateTime.Now.AddMinutes(5.0);
		}
		if (!_driver.Url.Contains("fort.php?a=place&type=14"))
		{
			_driver.isExecuteScriptClick(By.Id("m4"), "Клик Крепость");
			if (_driver.isExecuteScriptClick(By.XPath("//a[@href=\"fort.php?a=place&type=14\"]"), "Клик Академия"))
			{
				Thread.Sleep(1000);
			}
		}
		if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//span[@title=\"Самостоятельно\"]")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result2))
		{
			UpdateStatus("Статус:");
			return krepostAkademiyPrikluchencevZamokDateTime = DateTime.Now.AddSeconds(result2.Second + 20).AddMinutes(result2.Minute).AddHours(result2.Hour);
		}
		if (AppSettings.Get("checkBoxMaxBoss", defaultValue: false) && _driver.FindElements(By.XPath("//div[contains(@class,\"bar_green_solid\") and contains(string(.),\"Замок Хан Ханопотама\")]//..//div[@onmouseover][contains(@class,\"grayscale\")]")).Count != 0)
		{
			UpdateStatus("Статус:");
			return krepostAkademiyPrikluchencevZamokDateTime = DateTime.Now.AddMinutes(5.0);
		}
		string[] array = _driver.IsFindElement(By.XPath("//div[contains(text(),\"Отправить людишек\")]")).isGetAttribute("outerText").Split('/');
		int[] array2 = new int[2];
		for (int num = 0; num < array.Length; num++)
		{
			int.TryParse(string.Join("", array[num].Where((char c) => char.IsDigit(c))), out array2[num]);
		}
		if (array2[0] != array2[1])
		{
			if (_driver.IsFindElement(By.XPath("//span[contains(text(),\"Самостоятельно\")]//input[@value=\"cmd_dunge\"]")).IsClick("Клик Самостоятельно"))
			{
				Thread.Sleep(1000);
			}
		}
		else if (array2[1] != 0)
		{
			UpdateStatus("Статус:");
			TimeSpan timeSpan = DateTime.Today.AddDays(1.0) - DateTime.Now;
			return krepostAkademiyPrikluchencevZamokDateTime = DateTime.Now.AddSeconds(timeSpan.Seconds).AddMinutes(timeSpan.Minutes + 5).AddHours(timeSpan.Hours);
		}
		_driver.IsFindElement(By.XPath("//span[contains(string(.),\"УРА!\") or contains(string(.),\"УВЫ!\")]")).IsClick("Клик Ура");
		if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//span[@title=\"Самостоятельно\"]")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out result2))
		{
			UpdateStatus("Статус:");
			return krepostAkademiyPrikluchencevZamokDateTime = DateTime.Now.AddSeconds(result2.Second + 20).AddMinutes(result2.Minute).AddHours(result2.Hour);
		}
		UpdateStatus("Статус:");
		return krepostAkademiyPrikluchencevZamokDateTime = DateTime.Now.AddMinutes(5.0);
	}

	public DateTime KrepostPodzemnyeToneli()
	{
		if (krepostPodzemnyeToneliDateTime > DateTime.Now)
		{
			return krepostPodzemnyeToneliDateTime;
		}
		if (!AppSettings.Get("checkBoxKrepostPodzemnyeToneli", defaultValue: false))
		{
			return krepostPodzemnyeToneliDateTime = DateTime.Now.AddMinutes(5.0);
		}
		UpdateStatus("Статус:Крепость ПодземныеТонели");
		_driver.isExecuteScriptClick(By.Id("m4"), "Клик Крепость");
		if (_driver.isExecuteScriptClick(By.XPath("//a[@href=\"fort.php?a=place&type=1\"]"), "Клик ПодземныеТонели"))
		{
			Thread.Sleep(1000);
		}
		if (_driver.isExecuteScriptClick(By.XPath("//input[@value=\"ЗАБРАТЬ ДОБЫЧУ\"]"), "Клик Забрать добычу"))
		{
			Thread.Sleep(2000);
		}
		DateTime dateTime2 = _driver.DateTimeCount("//div[@id=\"fort_tunnels_next_monster\"]");
		if (dateTime2 > DateTime.Now.AddMinutes(10.0))
		{
			UpdateStatus("Статус:");
			return krepostPodzemnyeToneliDateTime = dateTime2.AddMinutes(1.0);
		}
		string[] array = _driver.IsFindElement(By.XPath("//div[contains(text(),\"Походов\")]")).isGetAttribute("outerText").Split('/');
		int[] array2 = new int[2];
		for (int i = 0; i < array.Length; i++)
		{
			int.TryParse(string.Join("", array[i].Where((char c) => char.IsDigit(c))), out array2[i]);
		}
		if (array2[0] != array2[1])
		{
			if (_driver.isExecuteScriptClick(By.XPath("//input[@value=\"ПО ЛЕБЕДКЕ\"]"), "Клик ПодземныеТонели Лебедка"))
			{
				Thread.Sleep(1000);
				UpdateStatus("Статус:");
				return krepostPodzemnyeToneliDateTime = DateTime.Now.AddMinutes(30.0);
			}
		}
		else if (array2[1] != 0)
		{
			UpdateStatus("Статус:");
			TimeSpan timeSpan = DateTime.Today.AddDays(1.0) - DateTime.Now;
			return krepostPodzemnyeToneliDateTime = DateTime.Now.AddSeconds(timeSpan.Seconds).AddMinutes(timeSpan.Minutes + 5).AddHours(timeSpan.Hours);
		}
		UpdateStatus("Статус:");
		return krepostPodzemnyeToneliDateTime = DateTime.Now.AddMinutes(5.0);
	}

	public DateTime KrepostKatokomb()
	{
		if (krepostKatakombDateTime > DateTime.Now)
		{
			return krepostKatakombDateTime;
		}
		if (!AppSettings.Get("checkBoxKatokomb", defaultValue: false))
		{
			return krepostKatakombDateTime = DateTime.Now.AddMinutes(5.0);
		}
		UpdateStatus("Статус:Крепость Катокомбы");
		_driver.isExecuteScriptClick(By.Id("m4"), "Клик Крепость");
		if (_driver.isExecuteScriptClick(By.XPath("//a[contains(@href,\"a=place&type=17\")]"), "Клик Катокомбы"))
		{
			Thread.Sleep(1000);
		}
		if (_driver.IsFindElement(By.XPath("//span[contains(text(),\"ВЫСТАВИТЬ\")]//input[3]")).IsClick("ВЫСТАВИТЬ"))
		{
			Thread.Sleep(1000);
		}
		for (int i = 0; i < 6; i++)
		{
			if (_driver.IsFindElement(By.XPath("//span[contains(text(),\"бесплатно\")]/input[@type=\"submit\"]")).IsClick("Клик Пожеланцы купить Бесплатно"))
			{
				Thread.Sleep(1000);
			}
			if (AppSettings.Get("checkBoxKatokombOchki", defaultValue: false) && _driver.IsFindElement(By.XPath("//b[@title=\"Очки арены\"]/../../input[@type=\"submit\"]")).IsClick("Клик Пожеланцы купить за Рыбу"))
			{
				Thread.Sleep(1000);
			}
			if (AppSettings.Get("checkBoxKatokombPirashi", defaultValue: false) && _driver.IsFindElement(By.XPath("//b[@title=\"Пирашки\"]/../../input[@type=\"submit\"]")).IsClick("Клик Пожеланцы купить за Пирашки"))
			{
				Thread.Sleep(1000);
			}
			if (AppSettings.Get("checkBoxKatokombPyl", defaultValue: false))
			{
				string source = _driver.IsFindElement(By.XPath("//li[@id=\"i165\"]")).isGetAttribute("outerText");
				long.TryParse(string.Join("", source.Where((char c) => char.IsDigit(c))), out var result);
				if (result > 50000 && _driver.IsFindElement(By.XPath("//b[@title=\"Пыль приключенцев\"]/../../input[@type=\"submit\"]")).IsClick("Клик Пожеланцы купить за Пыль"))
				{
					Thread.Sleep(1000);
				}
			}
			if (AppSettings.Get("checkBoxKatokombSyr", defaultValue: false) && _driver.IsFindElement(By.XPath("//b[@title=\"Сыр\"]/../../input[@type=\"submit\"]")).IsClick("Клик Пожеланцы купить за Сыр"))
			{
				Thread.Sleep(1000);
			}
		}
		DateTime dateTime2 = _driver.DateTimeCount("//span[@id=\"fort_catacomb_casket_offers_timer\"]");
		if ((dateTime2 - DateTime.Now).TotalHours > 6.0)
		{
			dateTime2 = DateTime.Now.AddMinutes(30.0);
		}
		dateTime2 = ((!(dateTime2 <= DateTime.Now)) ? dateTime2.AddMinutes(1.0) : DateTime.Now.AddMinutes(5.0));
		UpdateStatus("Статус:");
		return krepostKatakombDateTime = dateTime2;
	}

	public DateTime KrepostDub()
	{
		if (krepostDubDateTime > DateTime.Now)
		{
			return krepostDubDateTime;
		}
		if (!AppSettings.Get("checkBoxKrepostDub", defaultValue: false))
		{
			return krepostDubDateTime = DateTime.Now.AddMinutes(5.0);
		}
		UpdateStatus("Статус:Крепость Дуб");
		_driver.isExecuteScriptClick(By.Id("m4"), "Клик Крепость");
		if (_driver.isExecuteScriptClick(By.XPath("//a[contains(@href,\"a=place&type=18\")]"), "Клик Дуб"))
		{
			Thread.Sleep(1000);
		}
		if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//b[@class=\"modern_price zindex\"]/span")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result))
		{
			UpdateStatus("Статус:");
			return krepostDubDateTime = DateTime.Now.AddSeconds(result.Second + 20).AddMinutes(result.Minute).AddHours(result.Hour);
		}
		int num = 2;
		for (int i = 0; i < 15; i++)
		{
			if (num < 2)
			{
				break;
			}
			num = 0;
			if (_driver.IsFindElement(By.XPath("//span[contains(string(.),\"Напасть\")]")).IsClick("Клик Напасть в дубе"))
			{
				num++;
				Thread.Sleep(1000);
			}
			if (_driver.IsFindElement(By.XPath("//span[contains(string(.),\"Искать недобитых монстров\")]")).IsClick("Клик Искать недобитых монстров"))
			{
				num++;
				Thread.Sleep(1000);
				continue;
			}
			string logMessage = "Великий Дуб победа";
			string logMessage2 = "Великий Дуб проигрыш";
			string text = "//div[contains(@class, 'popup_my_container')]";
			string xpathToFind = text + "//span[contains(text(), 'Я так рад')]";
			string xpathToFind2 = text + "//span[contains(text(), 'Ну что ж')]";
			if (ClickAndLog(By.XPath(xpathToFind), "Клик Я так рад", logMessage))
			{
				num++;
			}
			if (ClickAndLog(By.XPath(xpathToFind2), "Клик Ну что ж", logMessage2))
			{
				num++;
			}
		}
		DateTime dateTime3 = _driver.DateTimeCount("//div[@id=\"fort_oak_pve_timer\"]");
		if ((dateTime3 - DateTime.Now).TotalHours > 2.0)
		{
			dateTime3 = DateTime.Now.AddMinutes(30.0);
		}
		dateTime3 = ((!(dateTime3 <= DateTime.Now)) ? dateTime3.AddMinutes(1.0) : DateTime.Now.AddMinutes(5.0));
		UpdateStatus("Статус:");
		return krepostDubDateTime = dateTime3;
		bool ClickAndLog(By elementXPath, string clickAction, string st)
		{
			if (_driver.IsFindElement(elementXPath).IsClick(clickAction))
			{
				LogService.LogHtml(st);
				Thread.Sleep(700);
				return true;
			}
			return false;
		}
	}

	public DateTime KrepostTaverna()
	{
		if (krepostTavernaDateTime > DateTime.Now)
		{
			return krepostTavernaDateTime;
		}
		if (!AppSettings.Get("checkBoxKrepostTaverna", defaultValue: false))
		{
			return krepostTavernaDateTime = DateTime.Now.AddMinutes(5.0);
		}
		DateTime[] array = new DateTime[3]
		{
			DateTime.Now,
			DateTime.Now,
			DateTime.Now
		};
		UpdateStatus("Статус:Крепость Таверна");
		_driver.isExecuteScriptClick(By.Id("m4"), "Клик Крепость");
		_driver.isExecuteScriptClick(By.XPath("//a[contains(@href,\"a=place&type=6\")]"), "Клик Таверна");
		_driver.IsFindElement(By.XPath("//a[contains(@class,\"btn\")][contains(text(),\"объявление\")][not(contains(@id,\"open\"))]")).IsClick("Клик Объявление");
		DateTime now = DateTime.Now;
		for (int i = 1; i < 4; i++)
		{
			array[i - 1] = _driver.DateTimeCount("//div[@rel][" + i + "]//span[contains(@id,\"fort_post_ad\")]");
		}
		for (int j = 1; j < 4; j++)
		{
			if (array[j - 1] > DateTime.Now || !_driver.IsFindElement(By.XPath("//div[@id=\"advert_tabs\"]//div[contains(@onclick,\"fort_advert_tabs\")][" + j + "]")).IsClick("Клик вкладка " + j))
			{
				continue;
			}
			Thread.Sleep(2000);
			SetSelectValue("//select[contains(@id,\"fort_tavern_hours\")]", AppSettings.Get("pictureBoxTavrnaDney", 0) + 1, "Клик Таверна Время");
			SetSelectValue("//select[contains(@id,\"fort_tavern_type\")]", AppSettings.Get("pictureBoxTavrnaChto", 0) + 1, "Клик Таверна Тип");
			int result = 0;
			if (AppSettings.Get("pictureBoxTavrnaProsent", 0) != 0)
			{
				if (int.TryParse(string.Join("", from c in Regex.Replace(_driver.IsFindElement(By.XPath("//div[@rel][\"" + j + "\"]//label[contains(@for,\"fort_tavern_loot\")]/b")).isGetAttribute("outerHTML"), ".+?>(\\d+)<.*$", "$1", RegexOptions.Singleline)
					where char.IsDigit(c)
					select c), out result))
				{
					_driver.IsFindElement(By.XPath("//input[contains(@id,\"fort_tavern_loot\")]")).IsClear();
					_driver.IsFindElement(By.XPath("//input[contains(@id,\"fort_tavern_loot\")]")).IsSendKeys("9999999999999999999999");
					Thread.Sleep(1000);
				}
			}
			else
			{
				_driver.IsFindElement(By.XPath("//input[contains(@id,\"fort_tavern_loot\")]")).IsClear();
				_driver.IsFindElement(By.XPath("//input[contains(@id,\"fort_tavern_loot\")]")).IsSendKeys("0");
				Thread.Sleep(1000);
			}
			if (AppSettings.Get("pictureBoxTavrnaCena", 0) != 0)
			{
				string value = Regex.Match(_driver.IsFindElement(By.XPath("//div[@class=\"tab\"]/script")).isGetAttribute("outerHTML"), "10\\s*:\\s*(\\d+)", RegexOptions.Singleline).Groups[1].Value;
				_driver.IsFindElement(By.XPath("//input[contains(@id,\"fort_tavern_price\")]")).IsClear();
				if (_driver.IsFindElement(By.XPath("//input[contains(@id,\"fort_tavern_price\")]")).IsSendKeys(value + Keys.Enter))
				{
					Thread.Sleep(2000);
				}
				Thread.Sleep(500);
			}
			else
			{
				_driver.IsFindElement(By.XPath("//input[contains(@id,\"fort_tavern_price\")]")).IsClear();
				if (_driver.IsFindElement(By.XPath("//input[contains(@id,\"fort_tavern_price\")]")).IsSendKeys(DateTime.Now.Second + Keys.Enter))
				{
					Thread.Sleep(2000);
				}
				Thread.Sleep(500);
			}
		}
		for (int num = 1; num < 4; num++)
		{
			array[num - 1] = _driver.DateTimeCount("//div[@rel][" + num + "]//span[contains(@id,\"fort_post_ad\")]");
		}
		now = DateTime.Now;
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			if (!(array[num2] <= DateTime.Now))
			{
				if (now <= DateTime.Now)
				{
					now = array[num2];
				}
				if (now > array[num2])
				{
					now = array[num2];
				}
			}
		}
		if (now <= DateTime.Now)
		{
			now = DateTime.Now.AddMinutes(45.0);
		}
		UpdateStatus("Статус:");
		return krepostTavernaDateTime = now.AddMinutes(2.0);
	}

	public void SetSelectValue(string selectXPath, int optionIndex, string text)
	{
		IWebElement webElement = _driver.IsFindElement(By.XPath(selectXPath + "/option[" + optionIndex + "]"));
		if (webElement != null)
		{
			webElement.IsClick(text);
			IWebElement webElement2 = _driver.IsFindElement(By.XPath(selectXPath));
			IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)_driver;
			javaScriptExecutor.ExecuteScript("  arguments[0].dispatchEvent(new Event('change'));   arguments[0].dispatchEvent(new Event('input')); ", webElement);
		}
	}

	public DateTime KrepostKlad()
	{
		if (krepostKladDateTime > DateTime.Now)
		{
			return krepostKladDateTime;
		}
		if (!AppSettings.Get("checkBoxKrepostShijinaTuristaKlad", defaultValue: false))
		{
			return krepostKladDateTime = DateTime.Now.AddMinutes(5.0);
		}
		krepostRazvedkaDateTime = DateTime.Now;
		KrepostRazvedka();
		UpdateStatus("Статус:Крепость Хижина Туриста");
		if (!_driver.Url.Contains("a=place&type=8"))
		{
			if (!_driver.Url.Contains("fort.php"))
			{
				_driver.isExecuteScriptClick(By.Id("m4"), "Клик Крепость");
			}
			_driver.IsFindElement(By.XPath("//a[contains(@href,\"a=place&type=8\")]")).IsClick("Клик Хижина Туриста");
		}
		DateTime dateTime2 = _driver.DateTimeCount("//div[@id=\"timer_work2\"]");
		if (dateTime2 > DateTime.Now)
		{
			UpdateStatus("Статус:");
			return krepostKladDateTime = dateTime2.AddMinutes(5.0);
		}
		_driver.IsFindElement(By.XPath("//div[contains(@class,\"btn\")][contains(text(),\"Поиск кладов\")][not(contains(@id,\"open\"))]")).IsClick("Клик Хижина Туриста Клад");
		_driver.IsFindElement(By.XPath("//input[@value=\"ПОЛУЧИТЬ КАРТУ\"][not(@disabled)]")).IsClick("Получить карту");
		int num = 0;
		for (int i = 1; i < 5; i++)
		{
			if (_driver.isExecuteScriptClick(By.XPath("//div[@rel=\"2\"]//div[contains(@class,\"rider_exist\")][not(contains(@class,\"selected\"))][not(contains(@class,\"disabled\"))][\"" + i + "\"]"), "Выбрать летуна " + i, 500))
			{
				num++;
			}
			if (num == 2)
			{
				break;
			}
		}
		_driver.IsFindElement(By.XPath("//div[@rel=\"2\"]//input[@value=\"ОТПРАВИТЬ\"][not(contains(@class,\"blocked\"))]")).IsClick("ОТправить за кладом");
		dateTime2 = _driver.DateTimeCount("//div[@id=\"timer_work2\"]");
		if (dateTime2 > DateTime.Now)
		{
			if ((dateTime2 - DateTime.Now).TotalHours > 24.0)
			{
				dateTime2 = DateTime.Now.AddMinutes(30.0);
			}
			krepostKladDateTime = dateTime2.AddMinutes(5.0);
		}
		else
		{
			krepostKladDateTime = DateTime.Now.AddMinutes(5.0);
		}
		UpdateStatus("Статус:");
		return krepostKladDateTime;
	}

	public DateTime KrepostRazvedka()
	{
		if (krepostRazvedkaDateTime > DateTime.Now)
		{
			return krepostRazvedkaDateTime;
		}
		if (!AppSettings.Get("checkBoxKrepostShijinaTuristaRazvedka", defaultValue: false))
		{
			return krepostRazvedkaDateTime = DateTime.Now.AddMinutes(5.0);
		}
		bool flag = true;
		UpdateStatus("Статус:Крепость Хижина Турита Разведка");
		if (!_driver.Url.Contains("a=place&type=8"))
		{
			if (!_driver.Url.Contains("fort.php"))
			{
				_driver.isExecuteScriptClick(By.Id("m4"), "Клик Крепость");
			}
			_driver.isExecuteScriptClick(By.XPath("//a[contains(@href,\"a=place&type=8\")]"), "Клик Хижина Туриста");
		}
		DateTime dateTime2 = _driver.DateTimeCount("//div[@id=\"timer_work\"]");
		if (dateTime2 > DateTime.Now)
		{
			UpdateStatus("Статус:");
			return krepostRazvedkaDateTime = dateTime2.AddMinutes(5.0);
		}
		_driver.IsFindElement(By.XPath("//div[contains(@class,\"btn\")][contains(text(),\"Разведка\")][not(contains(@id,\"open\"))]")).IsClick("Клик Хижина Туриста Разведка");
		int result = 0;
		string source = _driver.IsFindElement(By.XPath("//div[@rel=\"1\"]//div[contains(@class,\"fort_region_item\")][contains(@class,\"selected\")]")).isGetAttribute("data-hardness");
		if (int.TryParse(string.Join("", source.Where((char c) => char.IsDigit(c))), out result))
		{
			string input = _driver.IsFindElement(By.XPath("//div[@class=\"relative tourist_scout\"]/script")).isGetAttribute("outerHTML");
			int[,] array = new int[5, 2];
			for (int num = 0; num < array.GetLength(0); num++)
			{
				if (int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//div[@class=\"relative tourist_scout\"]//div[contains(@class,\"rider_exist\")][not(contains(@class,\"busy\"))][" + (num + 1) + "]")).isGetAttribute("data-id")
					where char.IsDigit(c)
					select c), out var result2))
				{
					array[num, 0] = result2;
					if (int.TryParse(string.Join("", from c in Regex.Replace(input, ".+?" + array[num, 0] + ".*?coolness.*?(\\d+).*$", "$1", RegexOptions.Singleline)
						where char.IsDigit(c)
						select c), out result2))
					{
						array[num, 1] = result2;
					}
				}
			}
			int[,] array2 = new int[23, 5]
			{
				{ 1, 0, 0, 0, 0 },
				{ 1, 2, 0, 0, 0 },
				{ 1, 3, 0, 0, 0 },
				{ 1, 4, 0, 0, 0 },
				{ 1, 5, 0, 0, 0 },
				{ 2, 0, 0, 0, 0 },
				{ 2, 3, 0, 0, 0 },
				{ 2, 4, 0, 0, 0 },
				{ 2, 5, 0, 0, 0 },
				{ 3, 0, 0, 0, 0 },
				{ 3, 4, 0, 0, 0 },
				{ 3, 5, 0, 0, 0 },
				{ 1, 2, 3, 0, 0 },
				{ 1, 2, 4, 0, 0 },
				{ 1, 2, 5, 0, 0 },
				{ 1, 3, 5, 0, 0 },
				{ 2, 3, 4, 0, 0 },
				{ 2, 3, 5, 0, 0 },
				{ 1, 2, 3, 4, 0 },
				{ 1, 2, 3, 5, 0 },
				{ 4, 0, 0, 0, 0 },
				{ 4, 5, 0, 0, 0 },
				{ 5, 0, 0, 0, 0 }
			};
			int[] array3 = new int[array2.GetLength(0)];
			int[] array4 = new int[array2.GetLength(0)];
			int[] array5 = new int[array2.GetLength(0)];
			for (int num2 = 0; num2 < array2.GetLength(0); num2++)
			{
				array5[num2] = num2;
				for (int num3 = 0; num3 < array2.GetLength(1); num3++)
				{
					if (array2[num2, num3] != 0)
					{
						array3[num2] += array[array2[num2, num3] - 1, 1];
						array4[num2] += array[array2[num2, num3] - 1, 1];
						if (num3 == array2.GetLength(1) - 1)
						{
							array3[num2] = array3[num2] * 100 * (num3 + 1);
						}
						continue;
					}
					array3[num2] = array3[num2] * 100 * (num3 + 1);
					break;
				}
			}
			Array.Sort(array3, array5);
			for (int num4 = 0; num4 < array3.Length; num4++)
			{
			}
			int num5 = 70;
			flag = false;
			for (int num6 = 0; num6 < array3.Length; num6++)
			{
				if (array4[array5[num6]] * 100 <= result * num5)
				{
					continue;
				}
				for (int num7 = 0; num7 < array.GetLength(0) && array2[array5[num6], num7] != 0; num7++)
				{
					_driver.isExecuteScriptClick(By.XPath("//div[@rel=\"1\"]//div[@data-id=\"" + array[array2[array5[num6], num7] - 1, 0] + "\"][contains(@class,\"rider_exist\")][not(contains(@class,\"selected\"))]"), "Выбираю летун " + array[array2[array5[num6], num7] - 1, 0]);
					if (array2[array5[num6], num7] != 0)
					{
						_driver.isExecuteScriptClick(By.XPath("//div[@rel=\"1\"]//div[@data-id=\"" + array[array2[array5[num6], num7] - 1, 0] + "\"][contains(@class,\"rider_exist\")][not(contains(@class,\"selected\"))]"), "Выбираю летун " + array[array2[array5[num6], num7] - 1, 0]);
					}
					else
					{
						_driver.isExecuteScriptClick(By.XPath("//div[@rel=\"1\"]//div[@data-id=\"" + array[array2[array5[num6], num7] - 1, 0] + "\"][contains(@class,\"rider_exist\")][contains(@class,\"selected\")]"), "Снимаю летун " + array[array2[array5[num6], num7] - 1, 0]);
					}
					flag = true;
				}
				if (flag)
				{
					_driver.IsFindElement(By.XPath("//div[@rel=\"1\"]//input[@value=\"ОТПРАВИТЬ\"]")).IsClick("Отправить Разведка");
				}
				break;
			}
		}
		dateTime2 = _driver.DateTimeCount("//div[@id=\"timer_work\"]");
		if (dateTime2 > DateTime.Now)
		{
			if ((dateTime2 - DateTime.Now).TotalHours > 24.0)
			{
				krepostRazvedkaDateTime = DateTime.Now.AddMinutes(30.0);
			}
			krepostRazvedkaDateTime = dateTime2.AddMinutes(5.0);
		}
		else if (!flag)
		{
			krepostRazvedkaDateTime = DateTime.Now.AddMinutes(45.0);
		}
		else
		{
			krepostRazvedkaDateTime = DateTime.Now.AddMinutes(5.0);
		}
		UpdateStatus("Статус:");
		return krepostRazvedkaDateTime;
	}

	public DateTime KrepostBashny()
	{
		if (krepostBashnyDateTime > DateTime.Now)
		{
			return krepostBashnyDateTime;
		}
		if (!AppSettings.Get("checkBoxKrepostJalovatsy", defaultValue: false))
		{
			return krepostBashnyDateTime = DateTime.Now.AddMinutes(1.0);
		}
		UpdateStatus("Статус:Крепость Сторожевая башня");
		_driver.isExecuteScriptClick(By.Id("m4"), "Клик Крепость");
		_driver.IsFindElement(By.XPath("//a[contains(@href,\"a=place&type=9\")]")).IsClick("Клик Сторожевая башня");
		_driver.IsFindElement(By.XPath("//div[@class=\"btn\"][text()=\"Организация обороны\"]")).IsClick("Клик Организация обороны");
		_driver.IsFindElement(By.XPath("//input[@value=\"ЖАЛОВАТЬСЯ\"]")).IsClick("Клик Жаловаться");
		krepostBashnyDateTime = _driver.DateTimeCount("//div[@id=\"fort_boost_count\"]");
		if (krepostBashnyDateTime <= DateTime.Now)
		{
			krepostBashnyDateTime = DateTime.Now.AddMinutes(5.0);
		}
		UpdateStatus("Статус:");
		return krepostBashnyDateTime;
	}

	public DateTime Zamok()
	{
		if (zamokDateTime > DateTime.Now)
		{
			return zamokDateTime;
		}
		if (!AppSettings.Get("checkBoxZamok", defaultValue: false))
		{
			return zamokDateTime = DateTime.Now.AddMinutes(30.0);
		}
		UpdateStatus("Статус: Замок");
		Dictionary<string, string> dictionary = new Dictionary<string, string>
		{
			["101"] = "Главные ворота",
			["102"] = "Торговая площадь",
			["103"] = "Алхимическая лавка",
			["104"] = "1.000 мелочей",
			["129"] = "Левый край северной стены",
			["121"] = "Левый край южной стены",
			["130"] = "Северная башня",
			["122"] = "Южная башня",
			["123"] = "Южное заграждение",
			["131"] = "Северное заграждение",
			["128"] = "Центр северной стены",
			["120"] = "Центр южной стены",
			["105"] = "Парадный вход",
			["106"] = "Гардероб",
			["117"] = "Зал ожидания",
			["107"] = "Гостинная",
			["118"] = "Уборная",
			["109"] = "Танцевальный зал",
			["108"] = "Столовая",
			["116"] = "Спальня хранителя ключей",
			["115"] = "Кабинет хранителя ключей",
			["114"] = "Приемная хранителя ключей",
			["119"] = "Зимний сад",
			["133"] = "Задний двор",
			["111"] = "Приемная",
			["110"] = "Кладовая",
			["112"] = "Тронный зал",
			["113"] = "Сокровищница",
			["132"] = "Оружейная",
			["124"] = "Правый край южной стены",
			["127"] = "Правый край северной стены",
			["125"] = "Восточная стена"
		};
		if (_driver.TimerRabota(out var dateTime2) && (dateTime2 > DateTime.Now || !_driver.IsFindElement(By.XPath("//div[@class=\"timers\"]")).isGetAttribute("outerText").Contains("Храм Паряших Истин")))
		{
			UpdateStatus("Статус:");
			return zamokDateTime = DateTime.Now.AddMinutes(1.0);
		}
		if (!int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//li[@id=\"i169\"]")).isGetAttribute("outerText")
			where char.IsDigit(c)
			select c), out var result))
		{
			UpdateStatus("Статус:");
			return zamokDateTime = DateTime.Now.AddMinutes(5.0);
		}
		if (result < 1 && !_driver.IsFindElement(By.XPath("//div[@class=\"timers\"]")).isGetAttribute("outerText").Contains("Храм Паряших Истин"))
		{
			UpdateStatus("Статус:");
			return zamokDateTime = DateTime.Now.AddMinutes(5.0);
		}
		_driver.isExecuteScriptClick(By.XPath("//a[@href=\"/dungeon.php\"]"), "Клик в Будку");
		zamokDateTime = _driver.DateTimeCount("//a[contains(text(),\"САМОСТОЯТЕЛЬНОЕ\")]//..//div[@id=\"enter_counter3\"]");
		if (zamokDateTime > DateTime.Now)
		{
			UpdateStatus("Статус:");
			return zamokDateTime = zamokDateTime.AddMinutes(2.0);
		}
		_driver.IsFindElement(By.XPath("//a[contains(text(),\"САМОСТОЯТЕЛЬНОЕ\")]")).IsClick("САМОСТОЯТЕЛЬНОЕ");
		_driver.IsFindElement(By.XPath("//input[contains(@value,\"Я ГОТОВ К МИССИИ\")]")).IsClick("Я ГОТОВ К МИССИИ IsFindElement");
		if (!Energy())
		{
			_driver.IsFindElement(By.XPath("//a[contains(text(),\"НАПАСТЬ\") or contains(text(),\"ПНУТЬ СУНДУК\")]")).IsClick("Пнуть напасть", 1000);
			IWebElement toElement = _driver.IsFindElement(By.XPath("//a[text()=\"ПОКИНУТЬ ХРАМ\"]"));
			Actions actions = new Actions(_driver);
			actions.MoveToElement(toElement).Click().Perform();
			_driver.IsFindElement(By.XPath("//span[text()=\"Да, конечно\"]")).IsClick("Да, конечно", 1500);
			UpdateStatus("Статус:");
			return zamokDateTime = DateTime.Now.AddMinutes(5.0);
		}
		for (int num = 0; num < 10; num++)
		{
			if (!Energy())
			{
				_driver.IsFindElement(By.XPath("//a[contains(text(),\"НАПАСТЬ\") or contains(text(),\"ПНУТЬ СУНДУК\")]")).IsClick("Пнуть напасть", 1000);
				IWebElement toElement2 = _driver.IsFindElement(By.XPath("//a[text()=\"ПОКИНУТЬ ХРАМ\"]"));
				Actions actions2 = new Actions(_driver);
				actions2.MoveToElement(toElement2).Click().Perform();
				_driver.IsFindElement(By.XPath("//span[text()=\"Да, конечно\"]")).IsClick("Да, конечно", 1500);
				break;
			}
			string pageSource = _driver.PageSource;
			Regex regex = new Regex("room room_(\\d+)");
			MatchCollection matchCollection = regex.Matches(pageSource);
			if (matchCollection.Count <= 0)
			{
				Thread.Sleep(1000);
				continue;
			}
			string value = matchCollection[0].Groups[1].Value;
			if (value == "111" && pageSource.Contains("arrow_locker_112") && pageSource.Contains("#use_1099") && _driver.isExecuteScriptClick(By.XPath("//div[contains(@onclick,\"#use_1099\")]//span[contains(text(),\"СЛОМАТЬ\")]"), "СЛОМАТЬ " + value))
			{
				Thread.Sleep(1000);
			}
			if (value == "111" && pageSource.Contains("arrow_locker_113") && pageSource.Contains("#use_1098") && _driver.isExecuteScriptClick(By.XPath("//div[contains(@onclick,\"#use_1098\")]//span[contains(text(),\"СЛОМАТЬ\")]"), "СЛОМАТЬ " + value))
			{
				Thread.Sleep(1000);
			}
			if (pageSource.Contains("monster/mava_know40s.jpg"))
			{
				_driver.IsFindElement(By.XPath("//a[contains(text(),\"НАПАСТЬ\")]")).IsClick("Напасть Тень ");
				HramZamokSunduk();
				if (_driver.IsFindElement(By.XPath("//a[contains(text(),\"ИСКАТЬ\")]")).IsClick("ИСКАТЬ"))
				{
					Thread.Sleep(500);
					num = 0;
					continue;
				}
			}
			if (pageSource.Contains("monster/mava_know41s.jpg"))
			{
				_driver.isExecuteScriptClick(By.XPath("//div[contains(@onclick,\"#use_890\")]/span[string(.)='СЛОМАТЬ']"), "Дипломатия", 1000);
				if (_driver.IsFindElement(By.XPath("//a[contains(text(),\"ДОГОВОРИТЬСЯ\")]")).IsClick("Договориться Царевич "))
				{
					Thread.Sleep(1000);
					if (_driver.IsFindElement(By.XPath("//a[contains(text(),\"НАПАСТЬ\")]")).IsClick("Напасть Царевич "))
					{
						Thread.Sleep(1000);
					}
					HramZamokSunduk();
					if (_driver.IsFindElement(By.XPath("//a[contains(text(),\"ИСКАТЬ\")]")).IsClick("ИСКАТЬ"))
					{
						Thread.Sleep(500);
						num = 0;
						continue;
					}
				}
			}
			if (pageSource.Contains("monster/mava_know43s.jpg"))
			{
				_driver.IsFindElement(By.XPath("//a[contains(text(),\"НАПАСТЬ\")]")).IsClick("Напасть Ключник ", 1000);
				HramZamokSunduk();
				if (_driver.IsFindElement(By.XPath("//a[contains(text(),\"ИСКАТЬ\")]")).IsClick("ИСКАТЬ"))
				{
					Thread.Sleep(500);
					num = 0;
					continue;
				}
			}
			if ((pageSource.Contains("monster/mava_know44s.jpg") || pageSource.Contains("monster/mava_know45s.jpg")) && _driver.IsFindElement(By.XPath("//a[contains(text(),\"НАПАСТЬ\")]")).IsClick("НАПАСТЬ Ключник "))
			{
				Thread.Sleep(1000);
				HramZamokSunduk();
				if (_driver.IsFindElement(By.XPath("//a[contains(text(),\"ИСКАТЬ\")]")).IsClick("ИСКАТЬ"))
				{
					Thread.Sleep(500);
					num = 0;
					continue;
				}
			}
			if (_driver.isExecuteScriptClick(By.XPath("//a[contains(text(),\"НАПАСТЬ\") or contains(text(),\"ПНУТЬ СУНДУК\")]"), "Пнуть напасть"))
			{
				Thread.Sleep(1000);
				num = 0;
				continue;
			}
			string text = ZamokLogika(pageSource, value);
			if (text != null && _driver.IsFindElement(By.XPath("//select[@name=\"nextroom\"]/option[contains(text(),\"" + dictionary[text] + "\")]")).IsClick("Перейти " + dictionary[text]))
			{
				Thread.Sleep(500);
				if (_driver.IsFindElement(By.XPath("//a[contains(text(),\"ПЕРЕЙТИ\")]")).IsClick("Перейти"))
				{
					Thread.Sleep(500);
					num = 0;
				}
			}
		}
		zamokDateTime = _driver.DateTimeCount("//a[contains(text(),\"САМОСТОЯТЕЛЬНОЕ\")]//..//div[@id=\"enter_counter3\"]");
		if (zamokDateTime <= DateTime.Now)
		{
			zamokDateTime = DateTime.Now.AddMinutes(5.0);
		}
		return zamokDateTime = DateTime.Now.AddMinutes(5.0);
	}

	private void HramZamokSunduk(bool flag = false)
	{
		if (AppSettings.Get("checkBoxSyndykOpen", defaultValue: false))
		{
			_driver.IsFindElement(By.XPath("//a[contains(text(),\"ВЗЛОМАТЬ ЗАМОК\")]")).IsClick("Открыть сундук");
			_driver.IsFindElement(By.XPath("//a[contains(text(),\"РАЗБИТЬ СУНДУК\")]")).IsClick("Разбить сундук");
		}
		_driver.IsFindElement(By.XPath("//a[contains(text(),\"ПНУТЬ СУНДУК\")]")).IsClick("Пнуть сундук");
		_driver.IsFindElement(By.XPath("//a[contains(text(),\"НЕ ХОЧУ РАСТИ, ХОЧУ БЫТЬ ТЫКВОЙ!\")]")).IsClick("НЕ ХОЧУ РАСТИ, ХОЧУ БЫТЬ ТЫКВОЙ!");
	}

	private string ZamokLogika(string _st, string Itut)
	{
		Graph graph = new Graph();
		graph.AddVertex("101");
		graph.AddVertex("102");
		graph.AddVertex("103");
		graph.AddVertex("104");
		graph.AddVertex("105");
		graph.AddVertex("106");
		graph.AddVertex("107");
		graph.AddVertex("108");
		graph.AddVertex("109");
		graph.AddVertex("110");
		graph.AddVertex("111");
		graph.AddVertex("112");
		graph.AddVertex("113");
		graph.AddVertex("114");
		graph.AddVertex("115");
		graph.AddVertex("116");
		graph.AddVertex("117");
		graph.AddVertex("118");
		graph.AddVertex("119");
		graph.AddVertex("120");
		graph.AddVertex("121");
		graph.AddVertex("122");
		graph.AddVertex("123");
		graph.AddVertex("124");
		graph.AddVertex("125");
		graph.AddVertex("126");
		graph.AddVertex("127");
		graph.AddVertex("128");
		graph.AddVertex("129");
		graph.AddVertex("130");
		graph.AddVertex("131");
		graph.AddVertex("132");
		graph.AddVertex("133");
		graph.AddEdge("101", "102", 1);
		graph.AddEdge("102", "103", 1);
		graph.AddEdge("102", "104", 1);
		graph.AddEdge("102", "119", 1);
		graph.AddEdge("102", "133", 1);
		graph.AddEdge("133", "132", 1);
		graph.AddEdge("119", "120", 1);
		graph.AddEdge("119", "133", 1);
		graph.AddEdge("120", "121", 1);
		graph.AddEdge("121", "122", 1);
		graph.AddEdge("122", "123", 1);
		graph.AddEdge("120", "124", 1);
		graph.AddEdge("124", "125", 1);
		graph.AddEdge("125", "127", 1);
		graph.AddEdge("127", "128", 1);
		graph.AddEdge("128", "129", 1);
		graph.AddEdge("129", "130", 1);
		graph.AddEdge("130", "131", 1);
		graph.AddEdge("128", "133", 1);
		graph.AddEdge("102", "105", 1);
		graph.AddEdge("105", "117", 1);
		graph.AddEdge("105", "107", 1);
		graph.AddEdge("105", "106", 1);
		graph.AddEdge("117", "118", 1);
		graph.AddEdge("107", "109", 1);
		graph.AddEdge("107", "108", 1);
		graph.AddEdge("109", "110", 1);
		graph.AddEdge("109", "111", 1);
		graph.AddEdge("109", "114", 1);
		graph.AddEdge("114", "115", 1);
		graph.AddEdge("114", "116", 1);
		graph.AddEdge("111", "113", 1);
		graph.AddEdge("111", "112", 1);
		Dijkstra dijkstra = new Dijkstra(graph);
		if (_st.Contains("monster_70q122"))
		{
			return GetNextRoomFromPath(Itut, "122", dijkstra);
		}
		if (_st.Contains("monster_72125"))
		{
			return GetNextRoomFromPath(Itut, "125", dijkstra);
		}
		if (_st.Contains("monster_71132"))
		{
			return GetNextRoomFromPath(Itut, "132", dijkstra);
		}
		if (_st.Contains("monster_70q130"))
		{
			return GetNextRoomFromPath(Itut, "130", dijkstra);
		}
		if (_st.Contains("monster_73115"))
		{
			return GetNextRoomFromPath(Itut, "115", dijkstra);
		}
		if (_st.Contains("monster_75113") && (!_st.Contains("arrow_locker_113") || _st.Contains("#use_1098")))
		{
			return GetNextRoomFromPath(Itut, "113", dijkstra);
		}
		if (_st.Contains("monster_74112") && (!_st.Contains("arrow_locker_112") || _st.Contains("#use_1099")))
		{
			return GetNextRoomFromPath(Itut, "112", dijkstra);
		}
		if (_driver.IsFindElement(By.XPath("//a[contains(text(),\"ИСКАТЬ\")]")).IsClick("ИСКАТЬ"))
		{
			HramZamokSunduk();
		}
		Random random = new Random();
		string text = dijkstra.FindShortestPath(Itut, random.Next(101, 132).ToString());
		return GetNextRoomFromPath(Itut, random.Next(101, 132).ToString(), dijkstra);
	}

	private string GetNextRoomFromPath(string currentRoom, string targetRoom, Dijkstra hramDijkstra)
	{
		string text = hramDijkstra.FindShortestPath(currentRoom, targetRoom);
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		string[] array = text.Split(',');
		if (array.Length < 2)
		{
			return null;
		}
		return array[1];
	}

	private bool Energy()
	{
		if (int.TryParse(string.Join("", _driver.IsFindElement(By.XPath("//span[@id=\"dungeon_energy\"]")).isGetAttribute("data-energy").TakeWhile((char c) => char.IsDigit(c))
			.ToArray()), out var result) && result > 0)
		{
			return true;
		}
		return false;
	}

	public DateTime HramParyshihIstin()
	{
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Expected O, but got Unknown
		if (hramParyshihIstinDateTime > DateTime.Now)
		{
			return hramParyshihIstinDateTime;
		}
		if (!AppSettings.Get("checkBoxHramParyshihIstin", defaultValue: false))
		{
			return hramParyshihIstinDateTime = DateTime.Now.AddMinutes(30.0);
		}
		UpdateStatus("Статус: Храм Паряших Истин");
		Dictionary<string, string> dictionary = new Dictionary<string, string>
		{
			["35"] = "Профессорская",
			["32"] = "Прогулочный коридор",
			["36"] = "Грибная оранжерея",
			["34"] = "Алхимическая лаборатория",
			["30"] = "Зал памяти",
			["31"] = "Западный Амфитеатр",
			["29"] = "Галерея открытий",
			["6"] = "Западная Анфилада",
			["7"] = "Апартаменты Геннадия",
			["8"] = "Западная комната отдыха",
			["9"] = "Апартаменты Кузнеча",
			["10"] = "Прогулочная аллея",
			["11"] = "Неморгающий сад",
			["12"] = "Книгохранилище",
			["xz"] = "Скрипторий",
			["14"] = "Восточная комната отдыха",
			["13"] = "Апартаменты Попандопулуса",
			["15"] = "Апартаменты Ушканчика",
			["16"] = "Восточная анфилада",
			["17"] = "Кабинет Ректора",
			["20"] = "Восточный балкон",
			["21"] = "Галерея закрытий",
			["22"] = "Танцевальный зал",
			["24"] = "Столовая",
			["23"] = "Восточный Амфитеатр",
			["26"] = "Барная",
			["25"] = "Кабинет Повара",
			["27"] = "Кухня",
			["28"] = "Черный вход",
			["4"] = "Гостинный зал",
			["5"] = "Западный балкон",
			["3"] = "Приемная",
			["2"] = "Главный вестибюль",
			["1"] = "Парадный вход",
			["19"] = "Гардеробная"
		};
		if (_driver.TimerRabota(out var dateTime2) && (dateTime2 > DateTime.Now || !_driver.IsFindElement(By.XPath("//div[@class=\"timers\"]")).isGetAttribute("outerText").Contains("Храм Паряших Истин")))
		{
			Label labelStatus = (Application.OpenForms[0] as Form1).labelStatus;
			object obj = _003C_003Ec._003C_003E9__78_0;
			if (obj == null)
			{
				System.Windows.Forms.MethodInvoker val = delegate
				{
					((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус:";
				};
				_003C_003Ec._003C_003E9__78_0 = val;
				obj = (object)val;
			}
			((Control)labelStatus).Invoke((Delegate)obj);
			return hramParyshihIstinDateTime = DateTime.Now.AddMinutes(1.0);
		}
		int result = 0;
		if (!int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//li[@id=\"i169\"]")).isGetAttribute("outerText")
			where char.IsDigit(c)
			select c), out result))
		{
			LogService.LogHtml("Не вижу количество будок");
			UpdateStatus("Статус:");
			return hramParyshihIstinDateTime = DateTime.Now.AddMinutes(5.0);
		}
		if (result < 1)
		{
			LogService.LogHtml("Kоличество будок " + result);
		}
		if (!_driver.isExecuteScriptClick(By.XPath("//a[@href=\"/dungeon.php\"]"), "Клик в Будку"))
		{
			LogService.LogHtml("Ошибка клик в будку ");
		}
		hramParyshihIstinDateTime = _driver.DateTimeCount("//a[text()=\"ПАРАДНЫЙ ВХОД\"]//..//div[@id=\"enter_counter\"]");
		if (hramParyshihIstinDateTime > DateTime.Now)
		{
			UpdateStatus("Статус:");
			return hramParyshihIstinDateTime = hramParyshihIstinDateTime.AddMinutes(2.0);
		}
		_driver.IsFindElement(By.XPath("//a[text()=\"ПАРАДНЫЙ ВХОД\"]")).IsClick("ПАРАДНЫЙ ВХОД");
		if (!Energy())
		{
			_driver.IsFindElement(By.XPath("//a[contains(text(),\"НАПАСТЬ\") or contains(text(),\"ПНУТЬ СУНДУК\")]")).IsClick("Пнуть напасть", 1000);
			IWebElement toElement = _driver.IsFindElement(By.XPath("//a[text()=\"ПОКИНУТЬ ХРАМ\"]"));
			Actions actions = new Actions(_driver);
			actions.MoveToElement(toElement).Click().Perform();
			_driver.IsFindElement(By.XPath("//span[text()=\"Да, конечно\"]")).IsClick("Да, конечно", 1500);
			UpdateStatus("Статус:");
			return hramParyshihIstinDateTime = DateTime.Now.AddMinutes(5.0);
		}
		for (int num = 0; num < 10; num++)
		{
			if (!Energy())
			{
				_driver.IsFindElement(By.XPath("//a[contains(text(),\"НАПАСТЬ\") or contains(text(),\"ПНУТЬ СУНДУК\")]")).IsClick("Пнуть напасть", 1000);
				IWebElement toElement2 = _driver.IsFindElement(By.XPath("//a[text()=\"ПОКИНУТЬ ХРАМ\"]"));
				Actions actions2 = new Actions(_driver);
				actions2.MoveToElement(toElement2).Click().Perform();
				_driver.IsFindElement(By.XPath("//span[text()=\"Да, конечно\"]")).IsClick("Да, конечно", 1500);
				break;
			}
			string pageSource = _driver.PageSource;
			Regex regex = new Regex("room room_(\\d+)");
			MatchCollection matchCollection = regex.Matches(pageSource);
			if (matchCollection.Count <= 0)
			{
				Thread.Sleep(1000);
				continue;
			}
			string value = matchCollection[0].Groups[1].Value;
			if (value == "32" && pageSource.Contains("arrow_locker_35") && pageSource.Contains("#use_884") && _driver.isExecuteScriptClick(By.XPath("//div[contains(@onclick,\"#use_884\")]//span[contains(text(),\"ОТКРЫТЬ\")]"), "ОТКРЫТЬ " + value))
			{
				Thread.Sleep(1000);
			}
			if (value == "16" && pageSource.Contains("arrow_locker_17") && pageSource.Contains("#use_885") && _driver.isExecuteScriptClick(By.XPath("//div[contains(@onclick,\"#use_885\")]//span[contains(text(),\"ОТКРЫТЬ\")]"), "ОТКРЫТЬ " + value))
			{
				Thread.Sleep(1000);
			}
			if (pageSource.Contains("/monster/mava_know8s.jpg") && _driver.IsFindElement(By.XPath("//a[contains(text(),\"НАПАСТЬ\")]")).IsClick("Напасть Кузнец "))
			{
				Thread.Sleep(1000);
				HramZamokSunduk();
				if (_driver.IsFindElement(By.XPath("//a[contains(text(),\"ИСКАТЬ\")]")).IsClick("ИСКАТЬ"))
				{
					Thread.Sleep(500);
					num = 0;
					continue;
				}
			}
			if (pageSource.Contains("monster/mava_know9s.jpg") && _driver.IsFindElement(By.XPath("//a[contains(text(),\"НАПАСТЬ\")]")).IsClick("Напасть Професор "))
			{
				Thread.Sleep(1000);
				HramZamokSunduk();
				if (_driver.IsFindElement(By.XPath("//a[contains(text(),\"ИСКАТЬ\")]")).IsClick("ИСКАТЬ"))
				{
					Thread.Sleep(500);
					num = 0;
					continue;
				}
			}
			if (_driver.isExecuteScriptClick(By.XPath("//a[contains(text(),\"НАПАСТЬ\")]"), "Напасть"))
			{
				Thread.Sleep(500);
				num = 0;
				continue;
			}
			HramZamokSunduk();
			if (_driver.isExecuteScriptClick(By.XPath("//a[contains(text(),\"НАПАСТЬ\")]"), "Напасть"))
			{
				Thread.Sleep(500);
				num = 0;
				continue;
			}
			HramZamokSunduk();
			string text = HramParyshihIstinLogika(pageSource, value);
			if (text == null)
			{
				Random random = new Random();
				int index = random.Next(0, dictionary.Count);
				text = dictionary.Keys.ElementAt(index);
			}
			if (_driver.IsFindElement(By.XPath("//select[@name=\"nextroom\"]/option[contains(text(),\"" + dictionary[text] + "\")]")).IsClick("Перейти " + dictionary[text]))
			{
				Thread.Sleep(500);
				if (_driver.IsFindElement(By.XPath("//a[contains(text(),\"ПЕРЕЙТИ\")]")).IsClick("Перейти"))
				{
					Thread.Sleep(500);
					num = 0;
				}
			}
		}
		hramParyshihIstinDateTime = _driver.DateTimeCount("//a[text()=\"ПАРАДНЫЙ ВХОД\"]//..//div[@id=\"enter_counter\"]");
		if (hramParyshihIstinDateTime <= DateTime.Now)
		{
			hramParyshihIstinDateTime = DateTime.Now.AddMinutes(5.0);
		}
		return hramParyshihIstinDateTime = DateTime.Now.AddMinutes(5.0);
	}

	private string HramParyshihIstinLogika(string _st, string Itut)
	{
		Graph graph = new Graph();
		graph.AddVertex("1");
		graph.AddVertex("2");
		graph.AddVertex("3");
		graph.AddVertex("4");
		graph.AddVertex("5");
		graph.AddVertex("6");
		graph.AddVertex("7");
		graph.AddVertex("8");
		graph.AddVertex("9");
		graph.AddVertex("10");
		graph.AddVertex("11");
		graph.AddVertex("12");
		graph.AddVertex("13");
		graph.AddVertex("14");
		graph.AddVertex("15");
		graph.AddVertex("16");
		graph.AddVertex("17");
		graph.AddVertex("18");
		graph.AddVertex("19");
		graph.AddVertex("20");
		graph.AddVertex("21");
		graph.AddVertex("22");
		graph.AddVertex("23");
		graph.AddVertex("24");
		graph.AddVertex("25");
		graph.AddVertex("26");
		graph.AddVertex("27");
		graph.AddVertex("28");
		graph.AddVertex("29");
		graph.AddVertex("30");
		graph.AddVertex("31");
		graph.AddVertex("32");
		graph.AddVertex("33");
		graph.AddVertex("34");
		graph.AddVertex("35");
		graph.AddVertex("36");
		graph.AddEdge("1", "2", 0);
		graph.AddEdge("2", "19", 0);
		graph.AddEdge("2", "3", 0);
		graph.AddEdge("3", "4", 0);
		graph.AddEdge("4", "5", 0);
		graph.AddEdge("4", "6", 0);
		graph.AddEdge("6", "7", 0);
		graph.AddEdge("6", "8", 0);
		graph.AddEdge("6", "9", 0);
		graph.AddEdge("6", "29", 0);
		graph.AddEdge("29", "30", 0);
		graph.AddEdge("30", "31", 0);
		graph.AddEdge("30", "32", 0);
		graph.AddEdge("32", "35", 0);
		graph.AddEdge("32", "34", 0);
		graph.AddEdge("32", "33", 0);
		graph.AddEdge("8", "10", 0);
		graph.AddEdge("10", "11", 0);
		graph.AddEdge("10", "12", 0);
		graph.AddEdge("10", "14", 0);
		graph.AddEdge("12", "xz", 0);
		graph.AddEdge("14", "16", 0);
		graph.AddEdge("16", "17", 0);
		graph.AddEdge("17", "20", 0);
		graph.AddEdge("16", "13", 0);
		graph.AddEdge("16", "15", 0);
		graph.AddEdge("16", "21", 0);
		graph.AddEdge("21", "22", 0);
		graph.AddEdge("22", "23", 0);
		graph.AddEdge("22", "24", 0);
		graph.AddEdge("24", "26", 0);
		graph.AddEdge("24", "25", 0);
		graph.AddEdge("26", "24", 0);
		graph.AddEdge("24", "28", 0);
		graph.AddEdge("27", "28", 0);
		graph.AddEdge("27", "24", 0);
		Dijkstra dijkstra = new Dijkstra(graph);
		if (_st.Contains("monster_5519"))
		{
			string text = dijkstra.FindShortestPath(Itut, "19");
			string[] array = text.Split(',');
			return array[1];
		}
		if (_st.Contains("monster_57q7"))
		{
			string text2 = dijkstra.FindShortestPath(Itut, "7");
			string[] array2 = text2.Split(',');
			return array2[1];
		}
		if (_st.Contains("monster_57q9"))
		{
			string text3 = dijkstra.FindShortestPath(Itut, "9");
			string[] array3 = text3.Split(',');
			return array3[1];
		}
		if (_st.Contains("monster_5917") && (!_st.Contains("arrow_locker_17") || _st.Contains("#use_885")))
		{
			string text4 = dijkstra.FindShortestPath(Itut, "17");
			string[] array4 = text4.Split(',');
			return array4[1];
		}
		if (_st.Contains("monster_5835") && (!_st.Contains("arrow_locker_35") || _st.Contains("#use_884")))
		{
			string text5 = dijkstra.FindShortestPath(Itut, "35");
			string[] array5 = text5.Split(',');
			return array5[1];
		}
		if (_st.Contains("monster_57q13"))
		{
			string text6 = dijkstra.FindShortestPath(Itut, "13");
			string[] array6 = text6.Split(',');
			return array6[1];
		}
		if (_st.Contains("monster_57q15"))
		{
			string text7 = dijkstra.FindShortestPath(Itut, "15");
			string[] array7 = text7.Split(',');
			return array7[1];
		}
		if (_st.Contains("monster_5625"))
		{
			string text8 = dijkstra.FindShortestPath(Itut, "25");
			string[] array8 = text8.Split(',');
			return array8[1];
		}
		if (_st.Contains("monster_5426"))
		{
			string text9 = dijkstra.FindShortestPath(Itut, "26");
			string[] array9 = text9.Split(',');
			return array9[1];
		}
		if (Itut == "1")
		{
			string text10 = dijkstra.FindShortestPath(Itut, "2");
			string[] array10 = text10.Split(',');
			if (_driver.IsFindElement(By.XPath("//a[contains(text(),\"ИСКАТЬ\")]")).IsClick("ИСКАТЬ"))
			{
				HramZamokSunduk();
			}
			return array10[1];
		}
		string text11 = dijkstra.FindShortestPath(Itut, "1");
		if (_driver.IsFindElement(By.XPath("//a[contains(text(),\"ИСКАТЬ\")]")).IsClick("ИСКАТЬ"))
		{
			HramZamokSunduk();
		}
		string[] array11 = text11.Split(',');
		if (array11.Length < 2)
		{
			return null;
		}
		return array11[1];
	}
}
