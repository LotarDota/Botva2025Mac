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

namespace Botva2025;

internal class Rabota
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<char, bool> _003C_003E9__31_0;

		public static Func<char, bool> _003C_003E9__32_0;

		public static Func<char, bool> _003C_003E9__33_0;

		public static Func<char, bool> _003C_003E9__35_0;

		public static Func<char, bool> _003C_003E9__35_1;

		public static Func<KeyValuePair<int, int>, int> _003C_003E9__41_1;

		public static System.Windows.Forms.MethodInvoker _003C_003E9__48_0;

		public static Func<char, bool> _003C_003E9__48_1;

		public static System.Windows.Forms.MethodInvoker _003C_003E9__49_0;

		public static System.Windows.Forms.MethodInvoker _003C_003E9__49_1;

		public static System.Windows.Forms.MethodInvoker _003C_003E9__49_2;

		public static System.Windows.Forms.MethodInvoker _003C_003E9__49_3;

		public static System.Windows.Forms.MethodInvoker _003C_003E9__49_4;

		public static Func<char, bool> _003C_003E9__49_5;

		internal bool _003CJestinshikiYcheba_003Eb__31_0(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CJestynshikYchebaRascheplenie_003Eb__32_0(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CJestynshikZagovor_003Eb__33_0(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CJestynshikPlavka_003Eb__35_0(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CJestynshikPlavka_003Eb__35_1(char c)
		{
			return char.IsDigit(c);
		}

		internal int _003CJestynshikOchistka_003Eb__41_1(KeyValuePair<int, int> x)
		{
			return x.Key;
		}

		internal void _003CDalnieStrany_003Eb__48_0()
		{
			((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус: Дальнии страны";
		}

		internal bool _003CDalnieStrany_003Eb__48_1(char c)
		{
			return char.IsDigit(c);
		}

		internal void _003CRabotat_003Eb__49_0()
		{
			((Control)(Application.OpenForms[0] as Form1).panelJestynshik).Visible = false;
		}

		internal void _003CRabotat_003Eb__49_1()
		{
			((Control)(Application.OpenForms[0] as Form1).panelJestynshik).Visible = true;
		}

		internal void _003CRabotat_003Eb__49_2()
		{
			((Control)(Application.OpenForms[0] as Form1).panelJestynshik).Visible = false;
		}

		internal void _003CRabotat_003Eb__49_3()
		{
			((Control)(Application.OpenForms[0] as Form1).panelJestynshik).Visible = false;
		}

		internal void _003CRabotat_003Eb__49_4()
		{
			((Control)(Application.OpenForms[0] as Form1).panelJestynshik).Visible = false;
		}

		internal bool _003CRabotat_003Eb__49_5(char c)
		{
			return char.IsDigit(c);
		}
	}

	private IWebDriver _driver;

	private static Random rng = new Random();

	public DateTime rabotaYchebaDatetime { get; set; }

	public DateTime rabotaMainDatetime { get; set; }

	public DateTime rabotaOchistkaDatetime { get; set; }

	public DateTime rabotaPlavkaDatetime { get; set; }

	public DateTime rabotaZagovorDatetime { get; set; }

	public DateTime rabotaVospitalkaDatetime { get; set; }

	public Rabota(IWebDriver driver)
	{
		_driver = driver;
		_RabotaDatetime();
	}

	private void UpdateStatus(string text)
	{
		Find.LabelStatus(text);
	}

	public void _RabotaDatetime()
	{
		rabotaPlavkaDatetime = DateTime.Now;
		rabotaOchistkaDatetime = DateTime.Now;
		rabotaZagovorDatetime = DateTime.Now;
		rabotaYchebaDatetime = DateTime.Now;
		rabotaMainDatetime = DateTime.Now;
		rabotaVospitalkaDatetime = DateTime.Now;
	}

	public void AvtomatikiMain()
	{
		try
		{
			Vospitalka();
		}
		catch
		{
			rabotaVospitalkaDatetime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			Rabotat();
		}
		catch
		{
		}
		try
		{
			JestinshikiYcheba();
		}
		catch
		{
			rabotaYchebaDatetime = DateTime.Now.AddMinutes(5.0);
		}
	}

	private DateTime Vospitalka()
	{
		if (rabotaVospitalkaDatetime > DateTime.Now)
		{
			return rabotaVospitalkaDatetime;
		}
		if (!AppSettings.Get("checkBoxVospitalka", defaultValue: false))
		{
			return rabotaVospitalkaDatetime.AddMinutes(5.0);
		}
		if (!_driver.IsFindElement(By.XPath("//div[@class=\"guilds show_guilds\"]//a[contains(@class,\"guild_2 \")]")).IsDisplayed())
		{
			return rabotaVospitalkaDatetime = DateTime.Now.AddMinutes(10.0);
		}
		UpdateStatus("Статус: Воспиталка");
		if (_driver.TimerRabota(out var dateTime2))
		{
			if ((dateTime2 - DateTime.Now).TotalSeconds > 1.0)
			{
				UpdateStatus("Статус:");
				return rabotaVospitalkaDatetime = DateTime.Now.AddMinutes(1.0);
			}
			string text = _driver.IsFindElement(By.XPath("//div[@class=\"timers\"]")).isGetAttribute("outerText");
			if (!text.Contains("Работа в кузнице") && !text.Contains("Расщепление вещи") && !text.Contains("Наложение заговора"))
			{
				_driver.isExecuteScriptClick(By.XPath("//a[contains(@href,\"smith.php?a=own\")]"), "Клик Свое дело");
			}
		}
		if (!_driver.Url.Contains("botva.ru/index.php") && !_driver.TimerRabota(out dateTime2))
		{
			_driver.isExecuteScriptClick(By.Id("m1"), "Клик м1 Персонаж");
		}
		_driver.IsFindElement(By.XPath("//div[@class=\"btn\"][@id=\"selector_weapons\"]")).IsClick("Одевалка");
		_driver.IsFindElement(By.XPath("//div[contains(@onmouseover, \"1198\")and  contains(@onmouseover,\"Вы выполнили задание\") and contains(string(.),\"СНЯТЬ\")]")).IsClick("Cнять Кастрюльку", 1000);
		_driver.IsFindElement(By.XPath("//div[contains(@onmouseover, \"1205\")and  contains(@onmouseover,\"Вы выполнили задание\") and contains(string(.),\"СНЯТЬ\")]")).IsClick("Cнять Ложку", 1000);
		if (_driver.IsFindElement(By.XPath("//script[contains(string(.),\"Куда класть то будешь?\")]")) != null && _driver.ByePredmet())
		{
			_driver.isExecuteScriptClick(By.Id("m1"), "Клик м1 Персонаж");
			_driver.IsFindElement(By.XPath("//div[contains(@onmouseover, \"1198\")and  contains(@onmouseover,\"Вы выполнили задание\") and contains(string(.),\"СНЯТЬ\")]")).IsClick("Cнять Кастрюльку", 1000);
			_driver.IsFindElement(By.XPath("//div[contains(@onmouseover, \"1205\")and  contains(@onmouseover,\"Вы выполнили задание\") and contains(string(.),\"СНЯТЬ\")]")).IsClick("Cнять Ложку", 1000);
		}
		_driver.isExecuteScriptClick(By.XPath("//div[@id=\"home_item_1198\" and  (contains(@onmouseover,\"Одержать в бодалке\") or contains(@onmouseover,\"миниигр в гнездовице\") or contains(@onmouseover,\"Открыть 70 сундучков Пандоры\") or contains(@onmouseover,\"Одержать 35 побед над любыми боссами\"))]/span[contains(string(.),\"НАДЕТЬ\")]"), "Клик Кастрюлька надеть");
		_driver.isExecuteScriptClick(By.XPath("//div[@id=\"home_item_1205\" and  (contains(@onmouseover,\"Одержать в бодалке\") or contains(@onmouseover,\"миниигр в гнездовице\") or contains(@onmouseover,\"Открыть 70 сундучков Пандоры\") or contains(@onmouseover,\"Одержать 35 побед над любыми боссами\"))]/span[contains(string(.),\"НАДЕТЬ\")]"), "Клик Ложка надеть");
		if (_driver.IsFindElement(By.XPath("//div[contains(@onmouseover, \"1198\") and  contains(@onmouseover,\"Вы выполнили задание\")]")) != null || _driver.IsFindElement(By.XPath("//div[contains(@onmouseover, \"1205\") and  contains(@onmouseover,\"Вы выполнили задание\")]")) != null)
		{
			if (!_driver.isExecuteScriptClick(By.XPath("//a[contains(@href,\"smith.php?a=own\")]"), "Клик Свое дело"))
			{
				Find.WebBrowserLog("Добавить СВОЕ ДЕЛО в верхнее меню");
				UpdateStatus("Статус:");
				return rabotaVospitalkaDatetime = DateTime.Now.AddMinutes(5.0);
			}
			if (_driver.IsFindElement(By.XPath("//a[text()=\"Наковальня\"][contains(@href,\"?a=ownup\")]")).IsClick("Наковальня") && _driver.IsFindElement(By.XPath("//img[contains(@onmouseover,'Вы выполнили задание. Теперь можете отправить предмет на улучшение кузнецам!')]//..//..//a[text()='НА КОВКУ']")).IsClick("На ковку") && _driver.IsFindElement(By.XPath("//input[@value='КОВАТЬ']")).IsClick("Ковать"))
			{
				if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//div[@id=\"gameField\"]//span[@timer]")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out dateTime2))
				{
					dateTime2 = DateTime.Now.AddSeconds(dateTime2.Second + 20).AddMinutes(dateTime2.Minute).AddHours(dateTime2.Hour);
					UpdateStatus("Статус:");
					return rabotaVospitalkaDatetime = dateTime2.AddSeconds(20.0);
				}
				return rabotaVospitalkaDatetime = DateTime.Now.AddMinutes(4.0);
			}
			if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//div[@id=\"gameField\"]//span[@timer]")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out dateTime2))
			{
				dateTime2 = DateTime.Now.AddSeconds(dateTime2.Second + 20).AddMinutes(dateTime2.Minute).AddHours(dateTime2.Hour);
				UpdateStatus("Статус:");
				return rabotaVospitalkaDatetime = dateTime2.AddSeconds(20.0);
			}
		}
		UpdateStatus("Статус:");
		return rabotaVospitalkaDatetime = DateTime.Now.AddMinutes(5.0);
	}

	private DateTime JestinshikiYcheba()
	{
		if (rabotaYchebaDatetime > DateTime.Now)
		{
			return rabotaYchebaDatetime;
		}
		if (!AppSettings.Get("checkBoxRabota", defaultValue: false))
		{
			return rabotaYchebaDatetime.AddMinutes(5.0);
		}
		if (!AppSettings.Get("checkBoxRabotaYcheba", defaultValue: false))
		{
			return rabotaYchebaDatetime.AddMinutes(5.0);
		}
		UpdateStatus("Статус: Жестянщик Учеба");
		if (_driver.TimerRabota(out var dateTime))
		{
			string text = _driver.IsFindElement(By.XPath("//div[@class=\"timers\"]")).isGetAttribute("outerText");
			if (dateTime > DateTime.Now || (!text.Contains("Работа в кузнице") && !text.Contains("Расщепление вещи") && !text.Contains("Наложение заговора")))
			{
				UpdateStatus("Статус:");
				return rabotaYchebaDatetime = DateTime.Now.AddMinutes(1.0);
			}
		}
		if (!_driver.Url.Contains("smith.php?a=traingame") && !_driver.isExecuteScriptClick(By.XPath("//a[contains(@href,\"smith.php?a=train\")]"), "Клик Подмастерье"))
		{
			Find.WebBrowserLog("Добавить Подмастерье в верхнее меню");
			UpdateStatus("Статус:");
			return rabotaYchebaDatetime = DateTime.Now.AddMinutes(5.0);
		}
		if (_driver.IsFindElement(By.XPath("//a[text()=\"ОБРАБОТКА\"][contains(@href,\"start\")]")).IsClick("ОБРАБОТКА") || _driver.IsFindElement(By.XPath("//b[text()=\"Обработка\"]")).IsClick("Обработка"))
		{
			if (_driver.IsFindElement(By.XPath("//b[text()=\"Обработка\"]")).IsDisplayed() && _driver.IsFindElement(By.XPath("//a[text()=\"НАЗАД\"]")).IsClick("НАЗАД"))
			{
				UpdateStatus("Статус:");
				return rabotaYchebaDatetime = DateTime.Now.AddMinutes(5.0);
			}
			UpdateStatus("Статус: Жестянщик Учеба Очистка");
			return rabotaYchebaDatetime = JestynshikOchistka();
		}
		if (_driver.IsFindElement(By.XPath("//a[text()=\"ПЛАВКА\"][contains(@href,\"start\")]")).IsClick("ПЛАВКА") || _driver.IsFindElement(By.XPath("//b[text()=\"Плавка кристаллов\"]")).IsClick("Плавка кристаллов"))
		{
			UpdateStatus("Статус: Жестянщик Учеба Плавка");
			if (_driver.IsFindElement(By.XPath("//b[text()=\"Плавка кристаллов\"]")).IsDisplayed() && _driver.IsFindElement(By.XPath("//a[text()=\"НАЗАД\"]")).IsClick("НАЗАД"))
			{
				UpdateStatus("Статус:");
				return rabotaYchebaDatetime = DateTime.Now.AddMinutes(5.0);
			}
			if (int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//div[@id=\"b_other_2\"]//div[contains(@class,\"inlineb\")][2]")).isGetAttribute("outerText")
				where char.IsDigit(c)
				select c), out var result) && result < 100)
			{
				return rabotaYchebaDatetime = DateTime.Now.AddMinutes(20.0);
			}
			return rabotaYchebaDatetime = JestynshikPlavka();
		}
		if (_driver.IsFindElement(By.XPath("//a[text()=\"КОВКА\"][contains(@href,\"start\")]")).IsClick("КОВКА") || _driver.IsFindElement(By.XPath("//b[text()=\"Кузнечное дело\"]")).IsClick("Кузнечное дело"))
		{
			if (_driver.IsFindElement(By.XPath("//b[text()=\"Кузнечное дело\"]")).IsDisplayed() && _driver.IsFindElement(By.XPath("//a[text()=\"НАЗАД\"]")).IsClick("НАЗАД"))
			{
				UpdateStatus("Статус:");
				return DateTime.Now.AddMinutes(10.0);
			}
			UpdateStatus("Статус: Жестянщик Учеба КОВКА");
			return rabotaYchebaDatetime = JestynshikKovat();
		}
		if (_driver.IsFindElement(By.XPath("//a[text()=\"ЗАГОВОРЫ\"][contains(@href,\"start\")]")).IsClick("ЗАГОВОРЫ") || _driver.IsFindElement(By.XPath("//b[text()=\"Шаманские заговоры\"]")).IsClick("ЗАГОВОРЫ"))
		{
			UpdateStatus("Статус: Жестянщик Учеба ЗАГОВОРЫ");
			if (_driver.IsFindElement(By.XPath("//b[text()=\"Шаманские заговоры\"]")).IsDisplayed() && _driver.IsFindElement(By.XPath("//a[text()=\"НАЗАД\"]")).IsClick("НАЗАД"))
			{
				UpdateStatus("Статус:");
				return DateTime.Now.AddMinutes(5.0);
			}
			return rabotaYchebaDatetime = JestynshikZagovor();
		}
		if (_driver.IsFindElement(By.XPath("//p[contains(text(),\"Поздравляю тебя, мой талантливый ученик\")]")) != null)
		{
			UpdateStatus("Статус: Жестянщик Учеба Расщепление");
			return rabotaYchebaDatetime = JestynshikYchebaRascheplenie();
		}
		UpdateStatus("Статус:");
		rabotaYchebaDatetime = DateTime.Now.AddMinutes(5.0);
		return rabotaYchebaDatetime;
	}

	private DateTime JestynshikYchebaRascheplenie()
	{
		if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//div[@id=\"gameField\"]//span[@timer]")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result))
		{
			result = DateTime.Now.AddSeconds(result.Second + 10).AddMinutes(result.Minute).AddHours(result.Hour);
			UpdateStatus("Статус:");
			return result;
		}
		string[] array = new string[3] { "i4", "i48", "i12" };
		string[] array2 = new string[3] { "Очищеный кристал", "КЯС", "Заговоры" };
		int[] array3 = new int[3];
		for (int i = 0; i < array.Length; i++)
		{
			IWebElement webElement = _driver.IsFindElement(By.XPath("//li[@id='" + array[i] + "']"));
			if (webElement == null)
			{
				Find.WebBrowserLog("добавить " + array2[i] + " в правое меню");
				return DateTime.Now.AddMinutes(5.0);
			}
			int.TryParse(string.Join("", from c in webElement.isGetAttribute("outerText")
				where char.IsDigit(c)
				select c), out array3[i]);
			if (array3[i] < 5)
			{
				UpdateStatus("Статус:");
				return DateTime.Now.AddMinutes(5.0);
			}
		}
		if (!_driver.IsFindElement(By.XPath("//a[contains(@href,\"smith.php?a=own\")]")).IsClick("Клик Свое дело", 1000))
		{
			result = DateTime.Now.AddMinutes(5.0);
			Find.WebBrowserLog("Добавить СВОЕ ДЕЛО в верхнее меню");
			UpdateStatus("Статус:");
			return result;
		}
		if (!_driver.IsFindElement(By.XPath("//a[text()=\"Расщепилька\"][contains(@href,\"a=ownuniq\")]")).IsClick("Расщепилька"))
		{
			UpdateStatus("Статус:");
			return DateTime.Now.AddMinutes(5.0);
		}
		if (_driver.isExecuteScriptClick(By.XPath("//label/img[contains(@src,\"Weap_\")]"), "Weap_"))
		{
			_driver.IsFindElement(By.XPath("//input[@value=\"НАЧАТЬ\"]")).IsClick("НАЧАТЬ");
			string[] array4 = new string[5] { "power", "block", "dexterity", "charisma", "endurance" };
			string[,] array5 = new string[5, 5]
			{
				{ "power", "block", "dexterity", "charisma", "endurance" },
				{ "block", "power", "charisma", "dexterity", "endurance" },
				{ "dexterity", "charisma", "power", "endurance", "block" },
				{ "endurance", "dexterity", "charisma", "block", "power" },
				{ "charisma", "endurance", "block", "power", "dexterity" }
			};
			for (int num = 0; num < array5.GetLength(0); num++)
			{
				Console.WriteLine($"Используем комбинацию {num}:");
				for (int num2 = 0; num2 < array5.GetLength(1); num2++)
				{
					string text = array5[num, num2];
					_driver.IsFindElement(By.XPath("//a[contains(@href,\"updateParamExtremum('" + text + "',1)\")]")).IsClick("Добавить " + text);
					if (_driver.IsFindElement(By.XPath("//span[@id=\"points\"]")).isGetAttribute("innerText") == "0")
					{
						break;
					}
				}
				if (_driver.IsFindElement(By.XPath("//span[@id=\"points\"]")).isGetAttribute("innerText") == "0")
				{
					break;
				}
				for (int num3 = 0; num3 < array5.GetLength(1); num3++)
				{
					string text2 = array5[0, num3];
					_driver.IsFindElement(By.XPath("//a[contains(@href,\"updateParamExtremum('" + text2 + "',-1)\")]")).IsClick("Убрать " + text2);
				}
			}
			if (_driver.IsFindElement(By.XPath("//span[@id=\"points\"]")).isGetAttribute("innerText") != "0")
			{
				UpdateStatus("Статус:");
				return DateTime.Now.AddMinutes(5.0);
			}
			_driver.IsFindElement(By.XPath("//input[@value=\"СОЗДАНИЕ\"]")).IsClick("СОЗДАНИЕ");
			if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//div[@class=\"grbody\"]//span[@timer]")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out result))
			{
				result = DateTime.Now.AddSeconds(result.Second + 10).AddMinutes(result.Minute).AddHours(result.Hour);
				UpdateStatus("Статус:");
				return result;
			}
		}
		else
		{
			if (!_driver.IsFindElement(By.XPath("//a[contains(@href,\"/shop.php\")]")).IsClick("Клик лавка"))
			{
				Find.WebBrowserLog("Добавь лавку в верхнее меню");
			}
			_driver.IsFindElement(By.XPath("//a[contains(@href,\"g=99\")]")).IsClick("Клик лавка продать");
			for (int num4 = 0; num4 < 3; num4++)
			{
				if (_driver.IsFindElement(By.XPath("//div[contains(@data-image,\"Weap_\")]/..//a[text()=\"ВЫБРОСИТЬ\"]")).IsClick("Клик выбросить Weap_" + num4, 1000))
				{
					_driver.IsFindElement(By.XPath("//span[contains(text(),\"Да, конечно\")]")).IsClick("Клик Да, конечно", 1000);
				}
			}
			_driver.IsFindElement(By.XPath("//a[contains(@href,\"g=2\")]")).IsClick("Клик лавка Оружие");
			for (int num5 = 2; num5 > 0; num5--)
			{
				_driver.IsFindElement(By.XPath("//div[@data-image=\"Weap_" + num5 + "\"]/..//input[@value=\"КУПИТЬ\"]")).IsClick("Клик купить Weap_" + num5, 1500);
				if (_driver.IsFindElement(By.XPath("//script[contains(text(), 'Попандопулус не успевает')]")) != null)
				{
					Find.WebBrowserLog("<FONT COLOR=red>ПОпандооплус устал </FONT>");
					return DateTime.Now.AddMinutes(50.0);
				}
			}
		}
		return DateTime.Now.AddMinutes(5.0);
	}

	private DateTime JestynshikZagovor()
	{
		for (int i = 0; i < 20; i++)
		{
			IWebElement webElement = _driver.IsFindElement(By.XPath("//b[text()=\"Шаманские заговоры\"]"));
			if (webElement == null)
			{
				UpdateStatus("Статус:");
				return DateTime.Now.AddMinutes(5.0);
			}
			if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//div[@id=\"gameField\"]//span[@timer]")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result))
			{
				DateTime result2 = DateTime.Now.AddSeconds(result.Second + 10).AddMinutes(result.Minute).AddHours(result.Hour);
				UpdateStatus("Статус:");
				return result2;
			}
			if (_driver.IsFindElement(By.XPath("//a[text()=\"ЕЩЁ РАЗ\"]")).IsClick("ЕЩЕ РАЗ"))
			{
				i = 0;
				continue;
			}
			if (_driver.IsFindElement(By.XPath("//a[text()=\"ОТЛОЖИТЬ\"]")).IsClick("ОТЛОЖИТЬ"))
			{
				i = 0;
				continue;
			}
			string source = _driver.IsFindElement(By.XPath("//img[contains(@src,\"Smith_Figure_\")]")).isGetAttribute("outerHTML");
			source = string.Join("", source.Where((char c) => char.IsDigit(c)));
			string stHTML = _driver.IsFindElement(By.XPath("//table[contains(@class,\"game_field \")]")).isGetAttribute("outerHTML");
			int click = 0;
			Zagovor(stHTML, source, ref click);
			if (_driver.IsFindElement(By.XPath("//td[@id=\"i" + click + "\"]")).IsClick("Клик заговор " + click))
			{
				Thread.Sleep(500);
			}
		}
		return DateTime.Now.AddMinutes(5.0);
	}

	private DateTime JestynshikKovat()
	{
		_driver.IsFindElement(By.XPath("//a[text()=\"РАБОТАТЬ\"]")).IsClick("РАБОТАТЬ");
		if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//div[@id=\"gameField\"]//span[@timer]")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result))
		{
			DateTime result2 = DateTime.Now.AddSeconds(result.Second + 10).AddMinutes(result.Minute).AddHours(result.Hour);
			UpdateStatus("Статус:");
			return result2;
		}
		return DateTime.Now.AddMinutes(5.0);
	}

	private DateTime JestynshikPlavka()
	{
		DateTime now = DateTime.Now;
		for (int i = 0; i < 20; i++)
		{
			IWebElement webElement = _driver.IsFindElement(By.XPath("//b[text()=\"Плавка кристаллов\"]"));
			if (webElement == null)
			{
				UpdateStatus("Статус:");
				return DateTime.Now.AddMinutes(5.0);
			}
			if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//div[@id=\"gameField\"]//span[@timer]")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result))
			{
				now = DateTime.Now.AddSeconds(result.Second + 10).AddMinutes(result.Minute).AddHours(result.Hour);
				UpdateStatus("Статус:");
				return now;
			}
			if (int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//td[@class=\"txt\"][contains(text(),\"Очищенный кристалл\")]")).isGetAttribute("outerText")
				where char.IsDigit(c)
				select c), out var result2) && result2 < 100 && _driver.IsFindElement(By.XPath("//a[text()=\"НАЗАД\" or text()=\"ОБРАБОТАТЬ\"]")).IsClick("ОБРАБОТАТЬ"))
			{
				UpdateStatus("Статус:");
				return DateTime.Now.AddMinutes(1.0);
			}
			if (_driver.IsFindElement(By.XPath("//a[text()=\"ЕЩЁ РАЗ\"]")).IsClick("ЕЩЕ РАЗ"))
			{
				i = 0;
				continue;
			}
			if (_driver.IsFindElement(By.XPath("//a[text()=\"ОТЛОЖИТЬ\"]")).IsClick("ОТЛОЖИТЬ"))
			{
				i = 0;
				continue;
			}
			string input = _driver.IsFindElement(By.XPath("//table[contains(@class,\"game_field \")]")).isGetAttribute("outerHTML");
			Regex regex = new Regex("<td.*?i(\\d+).*?(?:class=(.*?)>)?<\\/td");
			MatchCollection matchCollection = regex.Matches(input);
			if (matchCollection.Count == 0)
			{
				continue;
			}
			int[] array = new int[matchCollection.Count];
			for (int num = 0; num < array.Length; num++)
			{
				array[num] = 9;
				if (matchCollection[num].Groups[2].Value.Contains("c_B_"))
				{
					int.TryParse(string.Join("", matchCollection[num].Groups[2].Value.Where((char c) => char.IsDigit(c))), out array[num]);
				}
			}
			int num2 = JestynshikPlavkaVeroyatnost(array);
			if (_driver.IsFindElement(By.XPath("//td[@id=\"i" + (num2 + 1) + "\"]")).IsClick("Клик плавка " + (num2 + 1)))
			{
				Thread.Sleep(500);
			}
		}
		UpdateStatus("Статус:");
		return DateTime.Now.AddMinutes(1.0);
	}

	private int JestynshikPlavkaVeroyatnost(int[] _stClass)
	{
		(int x, int y) fieldDimensions = GetFieldDimensions(_stClass.Length);
		int item = fieldDimensions.x;
		int item2 = fieldDimensions.y;
		int[,] iClass = new int[item, item2];
		double[,] array = new double[item, item2];
		for (int i = 0; i < item; i++)
		{
			for (int j = 0; j < item2; j++)
			{
				iClass[i, j] = _stClass[i * item + j];
			}
		}
		JestinchikRastavitDesytki(ref iClass);
		JestinchikRastavitBomby(ref iClass);
		JestinchikRastavitDesytki(ref iClass);
		JectinchikConsoleInt(iClass);
		for (int k = 0; k < item; k++)
		{
			for (int l = 0; l < item2; l++)
			{
				if (iClass[k, l] == 10)
				{
					return k * item + l;
				}
			}
		}
		return JestinchikVeroytnostBomby(iClass);
	}

	private void JectinchikConsoleInt(int[,] _iClass)
	{
		int length = _iClass.GetLength(0);
		int length2 = _iClass.GetLength(1);
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length2; j++)
			{
				Console.Write(_iClass[i, j] + " ");
			}
		}
	}

	private int JestinchikVeroytnostBomby(int[,] _iClass)
	{
		int length = _iClass.GetLength(0);
		int length2 = _iClass.GetLength(1);
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		double num5 = 10.0;
		double[,] array = new double[length, length2];
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length2; j++)
			{
				if (_iClass[i, j] == 9)
				{
					num++;
				}
			}
		}
		if (num == length * length2)
		{
			return rng.Next(0, num);
		}
		for (int k = 0; k < length; k++)
		{
			for (int l = 0; l < length2; l++)
			{
				if (_iClass[k, l] < 9)
				{
					array[k, l] = 10.0;
				}
				if (_iClass[k, l] > 8)
				{
					continue;
				}
				num = 0;
				num2 = 0;
				num3 = 0;
				num4 = 0;
				for (int m = -1; m < 2; m++)
				{
					for (int n = -1; n < 2; n++)
					{
						if (k + m >= 0 && l + n >= 0 && k + m <= length - 1 && l + n <= length2 - 1)
						{
							int num6 = k + m;
							int num7 = l + n;
							if (_iClass[num6, num7] > 8)
							{
								num++;
							}
							switch (_iClass[num6, num7])
							{
							case 9:
								num2++;
								break;
							case 10:
								num3++;
								array[num6, num7] = 10.0;
								break;
							case 11:
								num4++;
								array[num6, num7] = 11.0;
								break;
							}
						}
					}
				}
				double num8 = Convert.ToDouble(num - num3 - num4);
				if (num8 == 0.0)
				{
					continue;
				}
				_ = k * length + l;
				_ = 7;
				_ = k * length + l;
				_ = 4;
				_ = k * length + l;
				_ = 2;
				for (int num9 = -1; num9 < 2; num9++)
				{
					for (int num10 = -1; num10 < 2; num10++)
					{
						if (k + num9 >= 0 && l + num10 >= 0 && k + num9 <= length - 1 && l + num10 <= length2 - 1)
						{
							int num11 = k + num9;
							int num12 = l + num10;
							if (_iClass[num11, num12] == 9)
							{
								array[num11, num12] += Convert.ToDouble(_iClass[k, l] - num4 - num3) / num8;
							}
						}
					}
				}
			}
		}
		num = 0;
		num5 = 10.0;
		for (int num13 = 0; num13 < length; num13++)
		{
			for (int num14 = 0; num14 < length2; num14++)
			{
				if (array[num13, num14] == 0.0)
				{
					array[num13, num14] = 0.5;
				}
				if (array[num13, num14] < num5)
				{
					num5 = array[num13, num14];
				}
			}
		}
		for (int num15 = 0; num15 < length; num15++)
		{
			for (int num16 = 0; num16 < length2; num16++)
			{
				if (num5 == array[num15, num16])
				{
					num++;
				}
			}
		}
		int[] array2 = new int[num];
		num = 0;
		for (int num17 = 0; num17 < length; num17++)
		{
			for (int num18 = 0; num18 < length2; num18++)
			{
				if (array[num17, num18] == num5)
				{
					array2[num] = num17 * length + num18;
					num++;
				}
				Console.Write(array[num17, num18].ToString("N2") + " ");
			}
		}
		return array2[rng.Next(0, array2.Length)];
	}

	private int[,] JestinchikRastavitDesytki(ref int[,] iClass)
	{
		int length = iClass.GetLength(0);
		int length2 = iClass.GetLength(1);
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length2; j++)
			{
				if (iClass[i, j] > 8)
				{
					continue;
				}
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				for (int k = -1; k < 2; k++)
				{
					for (int l = -1; l < 2; l++)
					{
						if (i + k >= 0 && j + l >= 0 && i + k <= length - 1 && j + l <= length2 - 1)
						{
							int num4 = i + k;
							int num5 = j + l;
							if (iClass[num4, num5] > 8)
							{
								num++;
							}
							switch (iClass[num4, num5])
							{
							case 10:
								num2++;
								break;
							case 11:
								num3++;
								break;
							}
						}
					}
				}
				_ = i * length + j;
				_ = 3;
				if (iClass[i, j] != num - num2)
				{
					continue;
				}
				_ = i * length + j;
				_ = 3;
				for (int m = -1; m < 2; m++)
				{
					for (int n = -1; n < 2; n++)
					{
						if (i + m >= 0 && j + n >= 0 && i + m <= length - 1 && j + n <= length2 - 1)
						{
							int num6 = i + m;
							int num7 = j + n;
							if (iClass[num6, num7] > 8 && iClass[num6, num7] != 10)
							{
								iClass[num6, num7] = 11;
							}
						}
					}
				}
			}
		}
		return iClass;
	}

	private int[,] JestinchikRastavitBomby(ref int[,] iClass)
	{
		int length = iClass.GetLength(0);
		int length2 = iClass.GetLength(1);
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length2; j++)
			{
				if (iClass[i, j] > 8)
				{
					continue;
				}
				int num = 0;
				for (int k = -1; k < 2; k++)
				{
					for (int l = -1; l < 2; l++)
					{
						if (i + k >= 0 && j + l >= 0 && i + k <= length - 1 && j + l <= length2 - 1)
						{
							int num2 = i + k;
							int num3 = j + l;
							if (iClass[num2, num3] == 11)
							{
								num++;
							}
						}
					}
				}
				if (num != iClass[i, j])
				{
					continue;
				}
				for (int m = -1; m < 2; m++)
				{
					for (int n = -1; n < 2; n++)
					{
						if (i + m >= 0 && j + n >= 0 && i + m <= length - 1 && j + n <= length2 - 1)
						{
							int num4 = i + m;
							int num5 = j + n;
							if (iClass[num4, num5] == 9)
							{
								iClass[num4, num5] = 10;
							}
						}
					}
				}
			}
		}
		return iClass;
	}

	private DateTime JestynshikOchistka()
	{
		DateTime result;
		for (int i = 0; i < 13; i++)
		{
			IWebElement webElement = _driver.IsFindElement(By.XPath("//b[text()=\"Обработка кристаллов\"]"));
			if (webElement == null)
			{
				UpdateStatus("Статус:");
				return DateTime.Now.AddMinutes(5.0);
			}
			if (TryParseTimer(_driver.IsFindElement(By.XPath("//div[@id=\"gameField\"]//span[@timer]")), out result))
			{
				UpdateStatus("Статус:");
				return result;
			}
			if (_driver.IsFindElement(By.XPath("//a[text()=\"ЕЩЁ РАЗ\"]")).IsClick("ЕЩЕ РАЗ", 1000))
			{
				i = 0;
			}
			if (_driver.IsFindElement(By.XPath("//a[text()=\"ОТЛОЖИТЬ\"]")).IsClick("ОТЛОЖИТЬ", 1000))
			{
				i = 0;
			}
			string input = _driver.IsFindElement(By.XPath("//table[contains(@class,\"game_field \")]")).isGetAttribute("outerHTML");
			Regex regex = new Regex("<td.*?i(\\d+).*?(?:class=(.*?)>)?<\\/td");
			MatchCollection matchCollection = regex.Matches(input);
			if (matchCollection.Count == 0)
			{
				continue;
			}
			int[] array = new int[matchCollection.Count];
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = 0;
				if (matchCollection[j].Groups[2].Value.Contains("c_B_"))
				{
					array[j] = 3;
					num3++;
					continue;
				}
				if (matchCollection[j].Groups[2].Value.Contains("c_B"))
				{
					array[j] = 1;
					num2++;
				}
				if (matchCollection[j].Groups[2].Value.Contains("c_C"))
				{
					array[j] = 2;
					num++;
				}
			}
			int[] array2 = new int[num2];
			int[] array3 = new int[num];
			int[] array4 = new int[num3];
			int[] array5 = new int[array.Length - num3 - num - num2];
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			for (int k = 0; k < array.Length; k++)
			{
				switch (array[k])
				{
				case 1:
					array2[num4] = k + 1;
					num4++;
					break;
				case 2:
					array3[num5] = k + 1;
					num5++;
					break;
				case 0:
					array5[num6] = k + 1;
					num6++;
					break;
				}
			}
			if (_driver.IsFindElement(By.XPath("//input[@id=\"ch_open\"][@checked]")) != null)
			{
				if (num == 0 && _driver.IsFindElement(By.XPath("//td[@id=\"i" + array5[rng.Next(0, array5.Length)] + "\"]")).IsClick("Клик iZelenoe=0"))
				{
					Thread.Sleep(500);
				}
				else if (_driver.IsFindElement(By.XPath("//td[@id=\"i" + JestynshikVeroyatnost(array, 2, new int[1] { 3 }) + "\"]")).IsClick("Клик krasnor"))
				{
					Thread.Sleep(500);
				}
				continue;
			}
			if (num == 0 && array2.Length != 0)
			{
				(int x, int y) fieldDimensions = GetFieldDimensions(array.Length);
				int item = fieldDimensions.x;
				int item2 = fieldDimensions.y;
				int value = FindCellWithMostEmptyNeighbors(array2, array, item, item2);
				if (_driver.IsFindElement(By.XPath("//td[@id=\"i" + value + "\"]")).IsClick($"Клик по лучшей зеленой клетке {value}", 700))
				{
					continue;
				}
			}
			if (num > 1)
			{
				(int x, int y) fieldDimensions2 = GetFieldDimensions(array.Length);
				int item3 = fieldDimensions2.x;
				int item4 = fieldDimensions2.y;
				Dictionary<int, int> dictionary = new Dictionary<int, int>();
				int[,] array6 = new int[item3, item4];
				for (int l = 0; l < item3; l++)
				{
					for (int m = 0; m < item4; m++)
					{
						array6[l, m] = array[l * item3 + m];
					}
				}
				int[] array7 = array3;
				foreach (int num7 in array7)
				{
					if (num7 == 0)
					{
						continue;
					}
					int num8 = num7 - 1;
					int num9 = num8 / item3;
					int num10 = num8 % item3;
					int[] array8 = new int[4] { -1, 1, 0, 0 };
					int[] array9 = new int[4] { 0, 0, -1, 1 };
					for (int num11 = 0; num11 < 4; num11++)
					{
						int num12 = num9 + array8[num11];
						int num13 = num10 + array9[num11];
						if (num12 < 0 || num12 >= item3 || num13 < 0 || num13 >= item4)
						{
							continue;
						}
						int num14 = array6[num12, num13];
						if (num14 == 0 || num14 == 1)
						{
							int key = num12 * item3 + num13 + 1;
							if (!dictionary.ContainsKey(key))
							{
								dictionary[key] = CountRedNeighborsForCell(num12, num13, array6, item3, item4);
							}
						}
					}
				}
				if (dictionary.Count > 0)
				{
					int minRedNeighbors = dictionary.Values.Min();
					int[] array10 = (from x in dictionary
						where x.Value == minRedNeighbors
						select x.Key).ToArray();
					int[] array11 = array10;
					foreach (int num16 in array11)
					{
					}
					int value2 = array10[rng.Next(0, array10.Length)];
					if (_driver.IsFindElement(By.XPath($"//td[@id=\"i{value2}\"]")).IsClick($"Клик по соседу красной клетки {value2} (красных соседей: {minRedNeighbors})"))
					{
						continue;
					}
				}
			}
			_driver.IsFindElement(By.XPath("//td[@id=\"i" + JestynshikVeroyatnost(array, 1, new int[1]) + "\"]")).IsClick("Клик arNull");
		}
		if (TryParseTimer(_driver.IsFindElement(By.XPath("//div[@id=\"gameField\"]//span[@timer]")), out result))
		{
			UpdateStatus("Статус:");
			return result;
		}
		Find.LabelStatus("Статус:");
		return DateTime.Now.AddMinutes(10.0);
	}

	private int CountRedNeighborsForCell(int row, int col, int[,] grid, int width, int height)
	{
		int num = 0;
		int[] array = new int[4] { -1, 1, 0, 0 };
		int[] array2 = new int[4] { 0, 0, -1, 1 };
		for (int i = 0; i < 4; i++)
		{
			int num2 = row + array[i];
			int num3 = col + array2[i];
			if (num2 >= 0 && num2 < width && num3 >= 0 && num3 < height && grid[num2, num3] == 2)
			{
				num++;
			}
		}
		return num;
	}

	private int CountEmptyNeighbors(int cellIndex, int[] stClass, int width, int height)
	{
		int num = 0;
		int num2 = cellIndex / width;
		int num3 = cellIndex % width;
		for (int i = -1; i <= 1; i++)
		{
			for (int j = -1; j <= 1; j++)
			{
				if (i == 0 && j == 0)
				{
					continue;
				}
				int num4 = num2 + i;
				int num5 = num3 + j;
				if (num4 >= 0 && num4 < height && num5 >= 0 && num5 < width)
				{
					int num6 = num4 * width + num5;
					if (stClass[num6] == 0)
					{
						num++;
					}
				}
			}
		}
		return num;
	}

	private int FindCellWithMostEmptyNeighbors(int[] greenCells, int[] stClass, int width, int height)
	{
		int result = greenCells[0];
		int num = -1;
		foreach (int num2 in greenCells)
		{
			int num3 = CountEmptyNeighbors(num2 - 1, stClass, width, height);
			if (num3 > num)
			{
				num = num3;
				result = num2;
			}
		}
		return result;
	}

	private bool TryParseTimer(IWebElement timerElement, out DateTime result)
	{
		result = DateTime.Now;
		if (timerElement != null && DateTime.TryParseExact(timerElement.GetAttribute("outerText"), "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result2))
		{
			result = DateTime.Now.AddHours(result2.Hour).AddMinutes(result2.Minute).AddSeconds(result2.Second + 10);
			return true;
		}
		return false;
	}

	private (int x, int y) GetFieldDimensions(int fieldSize)
	{
		return fieldSize switch
		{
			36 => (x: 6, y: 6), 
			25 => (x: 5, y: 5), 
			16 => (x: 4, y: 4), 
			_ => (x: 1, y: 1), 
		};
	}

	private int JestynshikVeroyatnost(int[] _stClass, int c1, int[] c2)
	{
		(int x, int y) fieldDimensions = GetFieldDimensions(_stClass.Length);
		int item = fieldDimensions.x;
		int item2 = fieldDimensions.y;
		int[,] array = new int[item, item2];
		int num = 0;
		for (int i = 0; i < item; i++)
		{
			for (int j = 0; j < item2; j++)
			{
				array[i, j] = _stClass[i * item + j];
				if (array[i, j] == c1)
				{
					num++;
				}
			}
		}
		int[] array2 = new int[num];
		int num2 = 0;
		for (int k = 0; k < item; k++)
		{
			for (int l = 0; l < item2; l++)
			{
				if (array[k, l] == c1)
				{
					array2[num2] = k * item + l;
					num2++;
				}
			}
		}
		int[,] array3 = new int[item, item2];
		for (int m = 0; m < array2.Length; m++)
		{
			int num3 = array2[m] / item;
			int num4 = array2[m] - array2[m] / item * item;
			for (int n = -1; n < 2; n++)
			{
				for (int num5 = -1; num5 < 2; num5++)
				{
					if (n + num5 != -2 && n + num5 != 0 && n + num5 != 2 && num3 + n >= 0 && num4 + num5 >= 0 && num3 + n <= item - 1 && num4 + num5 <= item2 - 1)
					{
						if (c2.Length == 1 && array[num3 + n, num4 + num5] == c2[0])
						{
							array3[num3, num4]++;
						}
						if (c2.Length == 2 && (array[num3 + n, num4 + num5] == c2[0] || array[num3 + n, num4 + num5] == c2[1]))
						{
							array3[num3, num4]++;
						}
					}
				}
			}
		}
		int num6 = 0;
		for (int num7 = 0; num7 < item; num7++)
		{
			for (int num8 = 0; num8 < item2; num8++)
			{
				Console.Write(array3[num7, num8] + " ");
				if (array3[num7, num8] > num6)
				{
					num6 = array3[num7, num8];
				}
			}
		}
		int[] array4 = new int[0];
		for (int num9 = 0; num9 < item; num9++)
		{
			for (int num10 = 0; num10 < item2; num10++)
			{
				if (array3[num9, num10] == num6)
				{
					Array.Resize(ref array4, array4.Length + 1);
					array4[^1] = num9 * item + num10 + 1;
				}
			}
		}
		return array4[rng.Next(0, array4.Length)];
	}

	private DateTime DalnieStrany()
	{
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//b[contains(@class,\"guild_ship \")]/../..//span//span")).GetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result) && (result.Hour != 0 || result.Minute != 0 || result.Second != 0))
		{
			rabotaMainDatetime = DateTime.Now.AddSeconds(result.Second + 2).AddMinutes(result.Minute).AddHours(result.Hour);
			UpdateStatus("Статус:");
			return rabotaMainDatetime;
		}
		Label labelStatus = (Application.OpenForms[0] as Form1).labelStatus;
		object obj = _003C_003Ec._003C_003E9__48_0;
		if (obj == null)
		{
			System.Windows.Forms.MethodInvoker val = delegate
			{
				((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус: Дальнии страны";
			};
			_003C_003Ec._003C_003E9__48_0 = val;
			obj = (object)val;
		}
		((Control)labelStatus).Invoke((Delegate)obj);
		_driver.Fast("f9", "Дальнии страны");
		if (int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//p[contains(text(),\"Законсервированных ядрёных смесей:\")]")).isGetAttribute("outerText")
			where char.IsDigit(c)
			select c), out var result2) && result2 > 20)
		{
			_driver.IsFindElement(By.XPath("//a[contains(text(),\"ПОЛОЖИТЬ ВСЕ\")]")).IsClick("Положить все");
			_driver.IsFindElement(By.XPath("//form[@rel=\"4\"]/input[@value=\"НАНЯТЬ\"]")).IsClick("Линейный голенус");
		}
		rabotaMainDatetime = _driver.DateTimeCount("//div[@id=\"guild_ships_timer\"]");
		if (rabotaMainDatetime > DateTime.Now)
		{
			UpdateStatus("Статус:");
			return rabotaMainDatetime = rabotaMainDatetime.AddSeconds(30.0);
		}
		if (_driver.IsFindElement(By.XPath("//div[contains(text(),\"Вести с корабля вот-вот прибудут\")]")) != null)
		{
			UpdateStatus("Статус:");
			return rabotaMainDatetime = DateTime.Now.AddMinutes(1.0);
		}
		UpdateStatus("Статус:");
		return rabotaMainDatetime = DateTime.Now.AddMinutes(5.0);
	}

	public DateTime Rabotat()
	{
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		//IL_034f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Expected O, but got Unknown
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Expected O, but got Unknown
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cc: Expected O, but got Unknown
		//IL_0446: Unknown result type (might be due to invalid IL or missing references)
		//IL_044b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0451: Expected O, but got Unknown
		if (!AppSettings.Get("checkBoxRabota", defaultValue: false))
		{
			return rabotaMainDatetime.AddMinutes(5.0);
		}
		if (rabotaMainDatetime > DateTime.Now)
		{
			return rabotaMainDatetime;
		}
		DateTime result;
		if (_driver.IsFindElement(By.XPath("//div[@class=\"guilds show_guilds\"]//a[contains(@class,\"guild_3 \")]")).IsDisplayed())
		{
			if (((Control)(Application.OpenForms[0] as Form1).panelJestynshik).Visible)
			{
				Panel panelJestynshik = (Application.OpenForms[0] as Form1).panelJestynshik;
				object obj = _003C_003Ec._003C_003E9__49_0;
				if (obj == null)
				{
					System.Windows.Forms.MethodInvoker val = delegate
					{
						((Control)(Application.OpenForms[0] as Form1).panelJestynshik).Visible = false;
					};
					_003C_003Ec._003C_003E9__49_0 = val;
					obj = (object)val;
				}
				((Control)panelJestynshik).Invoke((Delegate)obj);
			}
			IWebElement webElement = _driver.IsFindElement(By.XPath("//b[contains(@class,\"timer_mine_7\")]/../..//span//span"));
			if (webElement != null && webElement.GetAttribute("outerText") != "00:00:00" && DateTime.TryParseExact(webElement.GetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out result))
			{
				rabotaMainDatetime = DateTime.Now.AddSeconds(result.Second + 2).AddMinutes(result.Minute).AddHours(result.Hour);
				return rabotaMainDatetime;
			}
			Find.LabelStatus("Статус: ДобычаПыль");
			if (_driver.ResyKri() < 100)
			{
				UpdateStatus("Статус:");
				return rabotaMainDatetime = rabotaMainDatetime.AddMinutes(1.0);
			}
			_driver.isExecuteScriptClick(By.XPath("//b[contains(@class,\"timer_mine_7\")]/.."), "timer_mine_7");
			if (_driver.IsFindElement(By.XPath("//div[@class=\"workshop_button\"]//input[@value=\"МОЛОТЬ\"]")).IsClick("Молоть Пыль"))
			{
				LogService.LogHtml("Молоть пыль");
			}
			webElement = _driver.IsFindElement(By.XPath("//div[@class=\"workshop_work_timer\"]//span"));
			if (webElement != null && webElement.Text != "00:00:00")
			{
				DateTime.TryParseExact(webElement.Text, "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out result);
				rabotaMainDatetime = DateTime.Now.AddSeconds(result.Second + 2).AddMinutes(result.Minute).AddHours(result.Hour);
				UpdateStatus("Статус:");
				return rabotaMainDatetime;
			}
		}
		if (_driver.IsFindElement(By.XPath("//div[@class=\"guilds show_guilds\"]//a[contains(@class,\"guild_2 \")]")).IsDisplayed())
		{
			if (!((Control)(Application.OpenForms[0] as Form1).panelJestynshik).Visible)
			{
				Panel panelJestynshik2 = (Application.OpenForms[0] as Form1).panelJestynshik;
				object obj2 = _003C_003Ec._003C_003E9__49_1;
				if (obj2 == null)
				{
					System.Windows.Forms.MethodInvoker val2 = delegate
					{
						((Control)(Application.OpenForms[0] as Form1).panelJestynshik).Visible = true;
					};
					_003C_003Ec._003C_003E9__49_1 = val2;
					obj2 = (object)val2;
				}
				((Control)panelJestynshik2).Invoke((Delegate)obj2);
			}
			return rabotaMainDatetime = JestinshikiRabota();
		}
		if (((Control)(Application.OpenForms[0] as Form1).panelJestynshik).Visible)
		{
			Panel panelJestynshik3 = (Application.OpenForms[0] as Form1).panelJestynshik;
			object obj3 = _003C_003Ec._003C_003E9__49_2;
			if (obj3 == null)
			{
				System.Windows.Forms.MethodInvoker val3 = delegate
				{
					((Control)(Application.OpenForms[0] as Form1).panelJestynshik).Visible = false;
				};
				_003C_003Ec._003C_003E9__49_2 = val3;
				obj3 = (object)val3;
			}
			((Control)panelJestynshik3).Invoke((Delegate)obj3);
		}
		if (_driver.IsFindElement(By.XPath("//div[@class=\"guilds show_guilds\"]//a[contains(@class,\"guild_1 \")]")).IsDisplayed())
		{
			if (((Control)(Application.OpenForms[0] as Form1).panelJestynshik).Visible)
			{
				Panel panelJestynshik4 = (Application.OpenForms[0] as Form1).panelJestynshik;
				object obj4 = _003C_003Ec._003C_003E9__49_3;
				if (obj4 == null)
				{
					System.Windows.Forms.MethodInvoker val4 = delegate
					{
						((Control)(Application.OpenForms[0] as Form1).panelJestynshik).Visible = false;
					};
					_003C_003Ec._003C_003E9__49_3 = val4;
					obj4 = (object)val4;
				}
				((Control)panelJestynshik4).Invoke((Delegate)obj4);
			}
			return rabotaMainDatetime = DalnieStrany();
		}
		if (_driver.IsFindElement(By.XPath("//div[@class=\"guilds show_guilds\"]//a[contains(@class,\"guild_4 \")]")).IsDisplayed())
		{
			if (((Control)(Application.OpenForms[0] as Form1).panelJestynshik).Visible)
			{
				Panel panelJestynshik5 = (Application.OpenForms[0] as Form1).panelJestynshik;
				object obj5 = _003C_003Ec._003C_003E9__49_4;
				if (obj5 == null)
				{
					System.Windows.Forms.MethodInvoker val5 = delegate
					{
						((Control)(Application.OpenForms[0] as Form1).panelJestynshik).Visible = false;
					};
					_003C_003Ec._003C_003E9__49_4 = val5;
					obj5 = (object)val5;
				}
				((Control)panelJestynshik5).Invoke((Delegate)obj5);
			}
			IWebElement webElement = _driver.IsFindElement(By.XPath("//b[contains(@class,\"timer_farm_1\")]/../..//span//span"));
			if (webElement != null && webElement.GetAttribute("outerText") != "00:00:00")
			{
				DateTime.TryParseExact(webElement.GetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out result);
				rabotaMainDatetime = DateTime.Now.AddSeconds(result.Second + 2).AddMinutes(result.Minute).AddHours(result.Hour);
				UpdateStatus("Статус:");
				return rabotaMainDatetime;
			}
			Find.LabelStatus("Статус: ДобычаМыла");
			webElement = _driver.IsFindElement(By.XPath("//li[@id=\"i70\"]"));
			if (webElement != null)
			{
				string[] array = webElement.GetAttribute("outerText").Split('/');
				int result2 = 0;
				int.TryParse(string.Join("", array[0].Where((char c) => char.IsDigit(c))), out result2);
				if (result2 < 20)
				{
					rabotaMainDatetime = DateTime.Now.AddMinutes(5.0);
					UpdateStatus("Статус:");
					return rabotaMainDatetime;
				}
			}
			if (_driver.ResyKri() < 20)
			{
				UpdateStatus("Статус:");
				return rabotaMainDatetime = DateTime.Now.AddMinutes(1.0);
			}
			_driver.isExecuteScriptClick(By.XPath("//b[contains(@class,\"timer_farm_1\")]/.."), "Клик timer_farm_1");
			if (_driver.IsFindElement(By.XPath("//div[@class=\"workshop_button\"]//input[@value=\"ДОБЫВАТЬ\"]")).IsClick("Добыча Мыла"))
			{
				(Application.OpenForms[0] as Form1).webBrowserLog.LogThread("Добыча мыла ");
			}
			webElement = _driver.IsFindElement(By.XPath("//div[@class=\"workshop_work_timer\"]//span"));
			if (webElement != null && webElement.Text != "00:00:00")
			{
				DateTime.TryParseExact(webElement.Text, "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out result);
				rabotaMainDatetime = DateTime.Now.AddSeconds(result.Second + 2).AddMinutes(result.Minute).AddHours(result.Hour);
				UpdateStatus("Статус:");
				return rabotaMainDatetime;
			}
		}
		UpdateStatus("Статус:");
		return rabotaMainDatetime = rabotaMainDatetime.AddMinutes(1.0);
	}

	private DateTime RabotaJestynshikOchistka()
	{
		if (rabotaOchistkaDatetime > DateTime.Now)
		{
			return rabotaOchistkaDatetime;
		}
		UpdateStatus("Статус: Жестянщик Очистка");
		if (_driver.TimerRabota(out var dateTime))
		{
			string text = _driver.IsFindElement(By.XPath("//div[@class=\"timers\"]")).isGetAttribute("outerText");
			if (dateTime > DateTime.Now || (!text.Contains("Работа в кузнице") && !text.Contains("Расщепление вещи") && !text.Contains("Наложение заговора")))
			{
				UpdateStatus("Статус:");
				return DateTime.Now.AddMinutes(1.0);
			}
		}
		DateTime result;
		if (!_driver.isExecuteScriptClick(By.XPath("//a[contains(@href,\"smith.php?a=own\")]"), "Клик Свое дело"))
		{
			result = DateTime.Now.AddMinutes(5.0);
			(Application.OpenForms[0] as Form1).webBrowserLog.LogThread("Добавить СВОЕ ДЕЛО в верхнее меню");
			UpdateStatus("Статус:");
			return result;
		}
		if (_driver.IsFindElement(By.XPath("//a[text()=\"Лупоглаз\"][contains(@href,\"start\")]")).IsClick("Лупоглаз") || _driver.IsFindElement(By.XPath("//b[text()=\"Обработка кристаллов\"]")).IsClick("Обработка кристаллов"))
		{
			return result = JestynshikOchistka();
		}
		return DateTime.Now.AddMinutes(5.0);
	}

	private DateTime RabotaJestynshikZagovor()
	{
		if (rabotaZagovorDatetime > DateTime.Now)
		{
			return rabotaZagovorDatetime;
		}
		UpdateStatus("Статус: Жестянщик Заговор");
		if (_driver.TimerRabota(out var dateTime))
		{
			string text = _driver.IsFindElement(By.XPath("//div[@class=\"timers\"]")).isGetAttribute("outerText");
			if (dateTime > DateTime.Now || (!text.Contains("Работа в кузнице") && !text.Contains("Расщепление вещи") && !text.Contains("Наложение заговора")))
			{
				UpdateStatus("Статус:");
				return DateTime.Now.AddMinutes(1.0);
			}
		}
		DateTime result;
		if (!_driver.IsFindElement(By.XPath("//a[contains(@href,\"smith.php?a=own\")]")).IsClick("Клик Свое дело"))
		{
			result = DateTime.Now.AddMinutes(5.0);
			(Application.OpenForms[0] as Form1).webBrowserLog.LogThread("Добавить СВОЕ ДЕЛО в верхнее меню");
			UpdateStatus("Статус:");
			return result;
		}
		if ((_driver.IsFindElement(By.XPath("//a[text()=\"Ритуальник\"][contains(@href,\"a=ownshaman\")]")).IsClick("Ритуальник") || _driver.IsFindElement(By.XPath("//b[text()=\"Ритуальник\"]")).IsClick("Ритуальник")) && _driver.IsFindElement(By.XPath("//a[text()=\"ДОБЫТЬ\"][contains(@href,\"start\")]")).IsClick("ДОБЫТЬ"))
		{
			return result = JestynshikZagovor();
		}
		UpdateStatus("Статус:");
		return DateTime.Now.AddMinutes(5.0);
	}

	private DateTime RabotaJestynshikPlavka()
	{
		if (rabotaPlavkaDatetime > DateTime.Now)
		{
			return rabotaPlavkaDatetime;
		}
		UpdateStatus("Статус: Жестянщик плавка");
		if (_driver.TimerRabota(out var dateTime))
		{
			string text = _driver.IsFindElement(By.XPath("//div[@class=\"timers\"]")).isGetAttribute("outerText");
			if (dateTime > DateTime.Now || (!text.Contains("Работа в кузнице") && !text.Contains("Расщепление вещи") && !text.Contains("Наложение заговора")))
			{
				UpdateStatus("Статус:");
				return DateTime.Now.AddMinutes(1.0);
			}
		}
		DateTime result;
		if (!_driver.IsFindElement(By.XPath("//a[contains(@href,\"smith.php?a=own\")]")).IsClick("Клик Свое дело"))
		{
			result = DateTime.Now.AddMinutes(5.0);
			(Application.OpenForms[0] as Form1).webBrowserLog.LogThread("Добавить СВОЕ ДЕЛО в верхнее меню");
			UpdateStatus("Статус:");
			return result;
		}
		if (_driver.IsFindElement(By.XPath("//a[text()=\"Гнездовица\"][contains(@href,\"start\")]")).IsClick("Гнездовица") || _driver.IsFindElement(By.XPath("//b[text()=\"Плавка кристаллов\"]")).IsClick("Плавка кристаллов"))
		{
			return result = JestynshikPlavka();
		}
		UpdateStatus("Статус:");
		return DateTime.Now.AddMinutes(5.0);
	}

	private DateTime JestinshikiRabota()
	{
		if (AppSettings.Get("checkBoxRabotaOchistka", defaultValue: false))
		{
			rabotaOchistkaDatetime = RabotaJestynshikOchistka();
		}
		if (AppSettings.Get("checkBoxRabotaPlavka", defaultValue: false))
		{
			rabotaPlavkaDatetime = RabotaJestynshikPlavka();
		}
		if (AppSettings.Get("checkBoxZagovor", defaultValue: false))
		{
			rabotaZagovorDatetime = RabotaJestynshikZagovor();
		}
		DateTime dateTime = DateTime.Now.AddHours(1.0);
		List<DateTime> list = new List<DateTime> { rabotaOchistkaDatetime, rabotaPlavkaDatetime, rabotaZagovorDatetime };
		foreach (DateTime item in list)
		{
			if (item > DateTime.Now && item < dateTime)
			{
				dateTime = item;
			}
		}
		return dateTime;
	}

	public static bool Zagovor(string stHTML, string stFigura, ref int click)
	{
		Regex regex = new Regex("<td.*?i(\\d+).*?(?:class=(.*?)>)?<\\/td");
		MatchCollection matchCollection = regex.Matches(stHTML);
		if (matchCollection.Count == 0)
		{
			return false;
		}
		int[] array = new int[matchCollection.Count];
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = 0;
			if (matchCollection[i].Groups[2].Value.Contains("c_A"))
			{
				array[i] = 11;
				num++;
			}
			if (matchCollection[i].Groups[2].Value.Contains("c_G"))
			{
				array[i] = 1;
				num2++;
			}
		}
		if (num + num2 == 0)
		{
			click = rng.Next(1, array.Length);
			return true;
		}
		if (num2 == 0)
		{
			click = ZagovorVeroyatnost(stFigura, array);
			return true;
		}
		click = ZagovorVeroyatnost(stFigura, array, num2);
		return true;
	}

	private static int ZagovorVeroyatnost(string ris, int[] _stClass, int pro = 0)
	{
		Dictionary<string, int[,]> dictionary = new Dictionary<string, int[,]>();
		dictionary.Add("01", new int[3, 2]
		{
			{ 1, 0 },
			{ 1, 0 },
			{ 1, 1 }
		});
		dictionary.Add("02", new int[4, 1]
		{
			{ 1 },
			{ 1 },
			{ 1 },
			{ 1 }
		});
		dictionary.Add("03", new int[3, 2]
		{
			{ 0, 1 },
			{ 1, 1 },
			{ 1, 0 }
		});
		dictionary.Add("04", new int[3, 3]
		{
			{ 0, 1, 0 },
			{ 1, 1, 1 },
			{ 0, 1, 0 }
		});
		dictionary.Add("05", new int[3, 2]
		{
			{ 1, 1 },
			{ 1, 0 },
			{ 1, 0 }
		});
		dictionary.Add("06", new int[3, 2]
		{
			{ 1, 0 },
			{ 1, 1 },
			{ 0, 1 }
		});
		dictionary.Add("07", new int[2, 2]
		{
			{ 1, 1 },
			{ 1, 1 }
		});
		dictionary.Add("08", new int[3, 2]
		{
			{ 1, 0 },
			{ 1, 1 },
			{ 1, 0 }
		});
		Dictionary<string, int[,]> dictionary2 = dictionary;
		int num = 1;
		int num2 = 1;
		if (_stClass.Length == 36)
		{
			num = 6;
			num2 = 6;
		}
		if (_stClass.Length == 25)
		{
			num = 5;
			num2 = 5;
		}
		if (_stClass.Length == 16)
		{
			num = 4;
			num2 = 4;
		}
		int[,] array = new int[num, num2];
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				array[i, j] = _stClass[i * num + j];
				Console.Write(array[i, j] + " ");
			}
		}
		int[,] array2 = dictionary2[ris];
		int[,] array3 = new int[num, num2];
		for (int k = 0; k < 5; k++)
		{
			array2 = ArraySwap_Rows_Columns(array2);
			for (int l = 0; l < num; l++)
			{
				if (l + array2.GetLength(0) > num)
				{
					continue;
				}
				for (int m = 0; m < num2; m++)
				{
					if (m + array2.GetLength(1) > num2 || !ZagovorProverka(array, l, m, array2, pro))
					{
						continue;
					}
					for (int n = 0; n < array2.GetLength(0); n++)
					{
						for (int num3 = 0; num3 < array2.GetLength(1); num3++)
						{
							if (array2[n, num3] == 1 && array[l + n, m + num3] == 0)
							{
								array3[l + n, m + num3] += array2[n, num3];
							}
						}
					}
				}
			}
		}
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		for (int num7 = 0; num7 < num; num7++)
		{
			for (int num8 = 0; num8 < num2; num8++)
			{
				if (array3[num7, num8] > num4)
				{
					num4 = array3[num7, num8];
					num5 = num7;
					num6 = num8;
				}
				Console.Write(array3[num7, num8] + " ");
			}
		}
		return num5 * num + num6;
	}

	private static bool ZagovorProverka(int[,] iClass, int x, int y, int[,] ar, int pro = 0)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < ar.GetLength(0); i++)
		{
			for (int j = 0; j < ar.GetLength(1); j++)
			{
				if (pro != 0 && iClass[x + i, y + j] == 1)
				{
					num2++;
				}
				if (iClass[x + i, y + j] == 11 && ar[i, j] == 1)
				{
					return false;
				}
				if (iClass[x + i, y + j] == 11 && ar[i, j] == 0)
				{
					num++;
				}
				if (iClass[x + i, y + j] == 1 && ar[i, j] == 1)
				{
					num++;
				}
				if (iClass[x + i, y + j] == 0)
				{
					num++;
				}
			}
		}
		if (num == 0)
		{
			return false;
		}
		if (num2 != pro)
		{
			return false;
		}
		return true;
	}

	private static int[,] ArraySwap_Rows_Columns(int[,] ar)
	{
		int length = ar.GetLength(0);
		int length2 = ar.GetLength(1);
		int[,] array = new int[length2, length];
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length2; j++)
			{
				array[j, length - 1 - i] = ar[i, j];
			}
		}
		return array;
	}
}
