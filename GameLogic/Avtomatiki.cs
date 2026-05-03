using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using Botva2025.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Botva2025;

public class Avtomatiki
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static System.Windows.Forms.MethodInvoker _003C_003E9__74_0;

		public static System.Windows.Forms.MethodInvoker _003C_003E9__74_1;

		public static Func<IWebElement, bool> _003C_003E9__80_0;

		public static Func<IWebElement, int> _003C_003E9__80_1;

		public static System.Windows.Forms.MethodInvoker _003C_003E9__83_0;

		public static System.Windows.Forms.MethodInvoker _003C_003E9__83_1;

		public static System.Windows.Forms.MethodInvoker _003C_003E9__83_2;

		public static System.Windows.Forms.MethodInvoker _003C_003E9__83_3;

		public static System.Windows.Forms.MethodInvoker _003C_003E9__83_4;

		public static Func<char, bool> _003C_003E9__84_0;

		internal void _003CIkarus_003Eb__74_0()
		{
			((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус: Икарус";
		}

		internal void _003CIkarus_003Eb__74_1()
		{
			((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус:";
		}

		internal bool _003CYchebaMassSkill_003Eb__80_0(IWebElement x)
		{
			int result;
			return int.TryParse(x.Text, out result);
		}

		internal int _003CYchebaMassSkill_003Eb__80_1(IWebElement x)
		{
			return int.Parse(x.Text);
		}

		internal void _003CKlassIstorii_003Eb__83_0()
		{
			((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус: КлассИстории";
		}

		internal void _003CKlassIstorii_003Eb__83_1()
		{
			((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус:";
		}

		internal void _003CKlassIstorii_003Eb__83_2()
		{
			((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус:";
		}

		internal void _003CKlassIstorii_003Eb__83_3()
		{
			((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус:";
		}

		internal void _003CKlassIstorii_003Eb__83_4()
		{
			((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус:";
		}

		internal bool _003CDalnieStrany_003Eb__84_0(char c)
		{
			return char.IsDigit(c);
		}
	}

	private IWebDriver _driver;

	public Ferma Ferma;

	private Muzey Muzey;

	public Ikarus _Ikarus;

	private Random Rng;

	public DateTime KriMaxDatetime { get; set; }

	public DateTime RabotaYchebaDatetime { get; set; }

	public DateTime RabotaMainDatetime { get; set; }

	public DateTime RabotaOchistkaDatetime { get; set; }

	public DateTime RabotaPlavkaDatetime { get; set; }

	public DateTime KlassIstoriiDatetime { get; set; }

	public DateTime KorablikDatetime { get; set; }

	public DateTime YchebaMassSkillDateTame { get; set; }

	public DateTime LetaushayKorovaDateTime { get; set; }

	public DateTime AvtomatikiMuzeyDateTime { get; set; }

	public DateTime AvtomatikiIkarusDateTime { get; set; }

	public DateTime AvtomatikiKaznaDateTime { get; set; }

	public DateTime AvtomatikiKaznaKriDateTime { get; set; }

	public DateTime AvtomatikiKaznaCarkiDateTime { get; set; }

	public DateTime AvtomatikiKaznaZolotoDateTime { get; set; }

	public Avtomatiki(IWebDriver driver)
	{
		_driver = driver;
		Ferma = new Ferma(driver);
		Muzey = new Muzey(driver);
		_Ikarus = new Ikarus(driver);
		Rng = new Random();
		InitializeDateTimeValues();
	}

	private void InitializeDateTimeValues()
	{
		DateTime avtomatikiKaznaZolotoDateTime = (AvtomatikiKaznaKriDateTime = (AvtomatikiKaznaCarkiDateTime = (AvtomatikiKaznaDateTime = (AvtomatikiIkarusDateTime = (AvtomatikiMuzeyDateTime = (LetaushayKorovaDateTime = (YchebaMassSkillDateTame = (KorablikDatetime = (KlassIstoriiDatetime = (RabotaPlavkaDatetime = (RabotaOchistkaDatetime = (RabotaMainDatetime = (RabotaYchebaDatetime = (KriMaxDatetime = DateTime.Now))))))))))))));
		AvtomatikiKaznaZolotoDateTime = avtomatikiKaznaZolotoDateTime;
	}

	public void AvtometikiMuzeyDateTime()
	{
		AvtomatikiMuzeyDateTime = DateTime.Now;
	}

	public void AvtomatikiMain()
	{
		try
		{
			KriMax();
		}
		catch
		{
		}
		try
		{
			KlassIstorii();
		}
		catch
		{
		}
		try
		{
			Korablik();
		}
		catch
		{
		}
		try
		{
			YchebaMassSkill();
		}
		catch
		{
		}
		try
		{
			LetaushayKorova();
		}
		catch
		{
		}
		try
		{
			AvtomatikiMuzey();
		}
		catch
		{
		}
		try
		{
			Ikarus();
		}
		catch
		{
			AvtomatikiIkarusDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			AvtomatikiKazna();
		}
		catch
		{
		}
		try
		{
			AvtomatikiFerma();
		}
		catch
		{
		}
	}

	private void AvtomatikiFerma()
	{
		if (!(Ferma.fermaDateTime > DateTime.Now))
		{
			if (!AppSettings.Get("checkBoxFerma", defaultValue: false))
			{
				Ferma.fermaDateTime = DateTime.Now.AddMinutes(5.0);
			}
			else
			{
				Ferma.FermaGo();
			}
		}
	}

	private DateTime AvtomatikiKaznaZoloto()
	{
		if (AvtomatikiKaznaZolotoDateTime > DateTime.Now)
		{
			return AvtomatikiKaznaZolotoDateTime;
		}
		if (!AppSettings.Get("checkBoxKaznaZoloto", defaultValue: false))
		{
			return AvtomatikiKaznaZolotoDateTime = DateTime.Now.AddMinutes(3.0);
		}
		if (_driver.TimerRabota(out var _))
		{
			string text = _driver.IsFindElement(By.XPath("//div[@class=\"timers\"]")).isGetAttribute("outerText");
			if (text.Contains("Спуск в подземелье"))
			{
				UpdateStatus("Статус:");
				return AvtomatikiKaznaZolotoDateTime = DateTime.Now.AddMinutes(5.0);
			}
		}
		BigInteger bigInteger = _driver.ResyZoloto();
		if (bigInteger > BigInteger.Pow(10, 12))
		{
			if (!_driver.isExecuteScriptClick(By.XPath("//a[contains(@href,\"clan_mod.php?m=treasury\")]"), "Клик Казначейство"))
			{
				(Application.OpenForms[0] as Form1).webBrowserLog.LogThread("Добавить Казначейство в верхнее меню");
				UpdateStatus("Статус:");
				return AvtomatikiKaznaZolotoDateTime = DateTime.Now.AddMinutes(10.0);
			}
			string text2 = (bigInteger - BigInteger.Pow(10, 10)).ToString();
			text2 = text2.Remove(text2.Length - 6);
			_driver.IsFindElement(By.XPath("//input[@name=\"money[5]\"]")).IsClear();
			_driver.IsFindElement(By.XPath("//input[@name=\"money[5]\"]")).IsSendKeys(text2);
			_driver.IsFindElement(By.XPath("//input[@value=\"ВНЕСТИ\"]")).IsClick("Внести", 1000);
		}
		return AvtomatikiKaznaZolotoDateTime = DateTime.Now.AddMinutes(30.0);
	}

	private DateTime AvtomatikiKaznaKri()
	{
		if (AvtomatikiKaznaKriDateTime > DateTime.Now)
		{
			return AvtomatikiKaznaKriDateTime;
		}
		if (!AppSettings.Get("checkBoxKaznaKri", defaultValue: false))
		{
			return AvtomatikiKaznaKriDateTime = DateTime.Now.AddMinutes(3.0);
		}
		if (_driver.TimerRabota(out var _))
		{
			string text = _driver.IsFindElement(By.XPath("//div[@class=\"timers\"]")).isGetAttribute("outerText");
			if (text.Contains("Спуск в подземелье"))
			{
				UpdateStatus("Статус:");
				return AvtomatikiKaznaKriDateTime = DateTime.Now.AddMinutes(5.0);
			}
		}
		ulong num = _driver.ResyKri();
		if (num > 10000000)
		{
			if (!_driver.isExecuteScriptClick(By.XPath("//a[contains(@href,\"clan_mod.php?m=treasury\")]"), "Клик Казначейство"))
			{
				(Application.OpenForms[0] as Form1).webBrowserLog.LogThread("Добавить Казначейство в верхнее меню");
				UpdateStatus("Статус:");
				return AvtomatikiKaznaKriDateTime = DateTime.Now.AddMinutes(10.0);
			}
			_driver.IsFindElement(By.XPath("//input[@name=\"money[2]\"]")).IsClear();
			_driver.IsFindElement(By.XPath("//input[@name=\"money[2]\"]")).IsSendKeys((num - 50000).ToString());
			_driver.IsFindElement(By.XPath("//input[@value=\"ВНЕСТИ\"]")).IsClick("Внести", 1000);
		}
		UpdateStatus("Статус:");
		return AvtomatikiKaznaKriDateTime = DateTime.Now.AddMinutes(5.0);
	}

	private DateTime AvtomatikiKaznaCarki()
	{
		if (AvtomatikiKaznaCarkiDateTime > DateTime.Now)
		{
			return AvtomatikiKaznaCarkiDateTime;
		}
		if (!AppSettings.Get("checkBoxCarki", defaultValue: false))
		{
			return AvtomatikiKaznaCarkiDateTime = DateTime.Now.AddMinutes(5.0);
		}
		ulong num = _driver.ResyKri();
		if (num > 1000000)
		{
			if (!_driver.isExecuteScriptClick(By.XPath("//a[contains(@href,\"king.php\")]"), "Клик Борьба за трон"))
			{
				UpdateStatus("Статус:");
				return AvtomatikiKaznaCarkiDateTime = DateTime.Now.AddMinutes(10.0);
			}
			_driver.IsFindElement(By.XPath("//select[@name=\"buy\"]//option[last()]")).IsClick("Выбрать Макс Царьки");
			ulong num2 = _driver.ResyKri();
			for (int i = 0; i < 2; i++)
			{
				ulong num3 = _driver.ResyKri();
				if (num3 < 100000)
				{
					break;
				}
				_driver.IsFindElement(By.XPath("//span[contains(text(),\"\")]/input[@type=\"submit\"]")).IsClick("Купить Царьки", 300);
				if (num2 != num3)
				{
					i = 0;
				}
				num2 = num3;
			}
		}
		return AvtomatikiKaznaCarkiDateTime = DateTime.Now.AddMinutes(5.0);
	}

	private void AvtomatikiKazna()
	{
		AvtomatikiKaznaKri();
		AvtomatikiKaznaZoloto();
		AvtomatikiKaznaCarki();
	}

	public DateTime Ikarus()
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		if (AvtomatikiIkarusDateTime > DateTime.Now)
		{
			return AvtomatikiIkarusDateTime;
		}
		if (!AppSettings.Get("checkBoxIkarus", defaultValue: false))
		{
			return AvtomatikiIkarusDateTime = DateTime.Now.AddMinutes(5.0);
		}
		Label labelStatus = (Application.OpenForms[0] as Form1).labelStatus;
		object obj = _003C_003Ec._003C_003E9__74_0;
		if (obj == null)
		{
			System.Windows.Forms.MethodInvoker val = delegate
			{
				((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус: Икарус";
			};
			_003C_003Ec._003C_003E9__74_0 = val;
			obj = (object)val;
		}
		((Control)labelStatus).Invoke((Delegate)obj);
		_driver.Fast("f81", "Икарус");
		AvtomatikiIkarusDateTime = _Ikarus.IkarusGo();
		Label labelStatus2 = (Application.OpenForms[0] as Form1).labelStatus;
		object obj2 = _003C_003Ec._003C_003E9__74_1;
		if (obj2 == null)
		{
			System.Windows.Forms.MethodInvoker val2 = delegate
			{
				((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус:";
			};
			_003C_003Ec._003C_003E9__74_1 = val2;
			obj2 = (object)val2;
		}
		((Control)labelStatus2).Invoke((Delegate)obj2);
		return AvtomatikiIkarusDateTime;
	}

	private DateTime AvtomatikiMuzey()
	{
		if (!AppSettings.Get("checkBoxMuzey", defaultValue: false))
		{
			return AvtomatikiMuzeyDateTime;
		}
		if (AvtomatikiMuzeyDateTime > DateTime.Now)
		{
			return AvtomatikiMuzeyDateTime;
		}
		if (_driver.isExecuteScriptClick(By.XPath("//b[@title=\"Коробок Удачи\"]/../../span"), "Коробок Удачи"))
		{
			UpdateStatus("Статус: Коробок удачи");
			Find.Sleep(1000);
			WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5L));
			int num = 0;
			for (int i = 0; i < 2; i++)
			{
				num++;
				if ((_driver.IsFindElement(By.XPath("//b[@id=\"price\"]")).isGetAttribute("outerText").Contains("бесплатно") || _driver.IsFindElement(By.XPath("//b[@id=\"price\"]")).isGetAttribute("outerHTML").Contains("item_1302")) && _driver.IsFindElement(By.XPath("//span[text()=\"МНЕ ПОВЕЗЕТ!\"]")).IsClick("Мне повезет", 1000))
				{
					LogService.LogHtml("Мне повезет!");
					i = 0;
					wait.TryUntil(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()=\"МНЕ ПОВЕЗЕТ!\"]")));
				}
				if (num > 100)
				{
					break;
				}
			}
			_driver.IsFindElement(By.XPath("//span[text()=\"ЗАКРЫТЬ\"]")).IsClick("Мне повезет Закрыть", 1000);
			UpdateStatus("Статус:");
		}
		if (_driver.isExecuteScriptClick(By.XPath("//div[@class=\"scroll\"]//div[@id=\"event_19\"]/a"), "Школьные Поручения"))
		{
			UpdateStatus("Статус: Школьные Поручения");
			WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5L));
			string xpathToFind = "//input[@value=\"ЗАБРАТЬ\"]";
			webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(xpathToFind)));
			_driver.IsFindElement(By.XPath(xpathToFind)).IsClick("Забрать Поручения", 1000);
			UpdateStatus("Статус:");
		}
		if (_driver.isExecuteScriptClick(By.XPath("//img[contains(@src,\"/buildings/man/sloth_man.png\")]//.."), "Мой банк"))
		{
			UpdateStatus("Статус: Мой банк");
			Thread.Sleep(1000);
			UpdateStatus("Статус:");
		}
		Muzey.MuzeyGo();
		UpdateStatus("Статус:");
		return AvtomatikiMuzeyDateTime = DateTime.Now.AddMinutes(10.0);
	}

	public DateTime LetaushayKorova()
	{
		if (LetaushayKorovaDateTime > DateTime.Now)
		{
			return LetaushayKorovaDateTime;
		}
		if (!AppSettings.Get("checkBoxLetaushayKorova", defaultValue: false))
		{
			return LetaushayKorovaDateTime.AddMinutes(1.0);
		}
		Find.LabelStatus("Статус: Корова");
		for (int i = 1; i < 5; i++)
		{
			if (_driver.IsFindElement(By.XPath("//script[contains(string(.),\"m=mass\")]")) == null)
			{
				break;
			}
			if (_driver.isExecuteScriptClick(By.XPath("//a[contains(@href,\"monster.php?a=monsterpve\")]"), "Клик В Корову"))
			{
				if (_driver.IsFindElement(By.XPath("//input[@value=\"ВОЙТИ\"]")).IsClick("Войти в бой корова"))
				{
					Find.LabelStatus("Статус:");
					return LetaushayKorovaDateTime = DateTime.Now.AddMinutes(45.0);
				}
				if (AppSettings.Get("checkBoxLetaushayKorovaMonetka", defaultValue: false) && _driver.IsFindElement(By.XPath("//b[contains(@class,\"item_1304\")]/../..//input[@value=\"Дать взятку\"]")).IsClick("Дать взятку корова"))
				{
					Find.LabelStatus("Статус:");
					return LetaushayKorovaDateTime = DateTime.Now.AddMinutes(45.0);
				}
				Find.LabelStatus("Статус:");
				return LetaushayKorovaDateTime = DateTime.Now.AddMinutes(45.0);
			}
			_driver.isExecuteScriptClick(By.Id("m1"), "Клик Персонаж");
		}
		Find.LabelStatus("Статус:");
		return LetaushayKorovaDateTime = DateTime.Now.AddMinutes(5.0);
	}

	public void _LetaushayKorovaDateTime()
	{
		LetaushayKorovaDateTime = DateTime.Now;
	}

	public void _KlassIstoriiDatetime()
	{
		KlassIstoriiDatetime = DateTime.Now;
	}

	public void _YchebaMassSkillDateTame()
	{
		YchebaMassSkillDateTame = DateTime.Now;
	}

	private DateTime YchebaMassSkill()
	{
		if (!AppSettings.Get("checkBoxYmeniy", defaultValue: false))
		{
			return YchebaMassSkillDateTame;
		}
		if (YchebaMassSkillDateTame > DateTime.Now)
		{
			return YchebaMassSkillDateTame;
		}
		Find.LabelStatus("Статус: Учеба масс Скилл");
		IWebElement webElement = _driver.IsFindElement(By.XPath("//b[contains(@class,\"ico_skill_train\")]/../..//span"));
		if (webElement != null && webElement.GetAttribute("outerText") != "00:00:00" && webElement.GetAttribute("outerText") != "Изучить")
		{
			DateTime.TryParseExact(webElement.GetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result);
			YchebaMassSkillDateTame = DateTime.Now.AddSeconds(result.Second);
			YchebaMassSkillDateTame = YchebaMassSkillDateTame.AddMinutes(result.Minute + 5);
			YchebaMassSkillDateTame = YchebaMassSkillDateTame.AddHours(result.Hour);
			Find.LabelStatus("Статус:");
			return YchebaMassSkillDateTame;
		}
		_driver.isExecuteScriptClick(By.XPath("//b[contains(@class,\"ico_skill_train\")]/../."), "Клик ico_skill_train");
		_driver.IsFindElement(By.XPath("//div[@class=\"commit\"]/a")).IsClick();
		IReadOnlyCollection<IWebElement> source = _driver.FindElements(By.CssSelector(".level"));
		List<IWebElement> source2 = source.Where((IWebElement x) => int.TryParse(x.Text, out var _)).ToList();
		IWebElement el = source2.OrderBy((IWebElement x) => int.Parse(x.Text)).First();
		IWebElement elem = el.IsFindElement(By.XPath("./ancestor::div[contains(@class, 'outer')]"));
		elem.IsClick();
		_driver.isExecuteScriptClick(By.XPath("//div[@class=\"commit\"]/input"), "Нажать Учить");
		Find.LabelStatus("Статус:");
		YchebaMassSkillDateTame = DateTime.Now.AddMinutes(5.0);
		return YchebaMassSkillDateTame;
	}

	public void Korablik()
	{
		if (!AppSettings.Get("checkBoxKorablik", defaultValue: false) || KorablikDatetime > DateTime.Now || _driver.Url.Contains("avatar"))
		{
			return;
		}
		UpdateStatus("Статус: Пирашки");
		IWebElement webElement = _driver.IsFindElement(By.XPath("//span[@title=\"Время до возвращения судна с пирашками\"]/span"));
		DateTime result;
		if (webElement != null && webElement.isGetAttribute("outerText") != "00:00:00")
		{
			DateTime.TryParseExact(webElement.Text, "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out result);
			KorablikDatetime = DateTime.Now.AddSeconds(result.Second).AddMinutes(result.Minute + 5).AddHours(result.Hour);
			UpdateStatus("Статус:");
			return;
		}
		IWebElement webElement2 = _driver.IsFindElement(By.XPath("//div[@id=\"fast\"]//div[contains(@class,\"ico f35 \")]"));
		if (webElement2 != null)
		{
			IJavaScriptExecutor javaScriptExecutor = _driver as IJavaScriptExecutor;
			javaScriptExecutor.ExecuteScript("arguments[0].click();", webElement2);
		}
		_driver.IsFindElement(By.XPath("//div[@class=\"pt10 center send_ship\"]//input[@value=\"ОТПРАВИТЬ\"]")).IsClick("ОТПРАВИТЬ кораблик");
		webElement = _driver.IsFindElement(By.XPath("//div[@id=\"wait_ship\"]//span"));
		if (webElement != null && webElement.isGetAttribute("outerText") != "00:00:00")
		{
			DateTime.TryParseExact(webElement.Text, "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out result);
			KorablikDatetime = DateTime.Now.AddSeconds(result.Second);
			KorablikDatetime = KorablikDatetime.AddMinutes(result.Minute + 5);
			KorablikDatetime = KorablikDatetime.AddHours(result.Hour);
			UpdateStatus("Статус:");
			return;
		}
		webElement = _driver.IsFindElement(By.Id("balert_wrap"));
		if (webElement != null && webElement.isGetAttribute("outerText").Contains("Команда вышла в море за добычей уже 15 раз"))
		{
			TimeSpan timeSpan = DateTime.Today.AddDays(1.0) - DateTime.Now;
			KorablikDatetime = DateTime.Now.AddSeconds(timeSpan.Seconds);
			KorablikDatetime = KorablikDatetime.AddMinutes(timeSpan.Minutes + 5);
			KorablikDatetime = KorablikDatetime.AddHours(timeSpan.Hours);
			UpdateStatus("Статус:");
		}
		else
		{
			UpdateStatus("Статус:");
			KorablikDatetime = DateTime.Now.AddMinutes(5.0);
		}
	}

	private void UpdateStatus(string text)
	{
		Find.LabelStatus(text);
	}

	public void KlassIstorii()
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Expected O, but got Unknown
		//IL_0415: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected O, but got Unknown
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Expected O, but got Unknown
		if (!AppSettings.Get("checkBoxKlassIstorii", defaultValue: false) || KlassIstoriiDatetime > DateTime.Now)
		{
			return;
		}
		Label labelStatus = (Application.OpenForms[0] as Form1).labelStatus;
		object obj = _003C_003Ec._003C_003E9__83_0;
		if (obj == null)
		{
			System.Windows.Forms.MethodInvoker val = delegate
			{
				((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус: КлассИстории";
			};
			_003C_003Ec._003C_003E9__83_0 = val;
			obj = (object)val;
		}
		((Control)labelStatus).Invoke((Delegate)obj);
		if (!_driver.Url.Contains("botva.ru/history.php"))
		{
			_driver.isExecuteScriptClick(By.XPath("//div[@id=\"fast\"]//div[contains(@class,\" f82 \")]"), "КлассИстории");
		}
		IWebElement webElement = _driver.IsFindElement(By.XPath("//span[@class=\"school_history_next_turn_timer\"]"));
		DateTime result;
		if (webElement != null && webElement.Text != "00:00:00" && webElement.Text != "")
		{
			DateTime.TryParseExact(webElement.Text, "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out result);
			KlassIstoriiDatetime = DateTime.Now.AddSeconds(result.Second + 2).AddMinutes(result.Minute).AddHours(result.Hour);
			Label labelStatus2 = (Application.OpenForms[0] as Form1).labelStatus;
			object obj2 = _003C_003Ec._003C_003E9__83_1;
			if (obj2 == null)
			{
				System.Windows.Forms.MethodInvoker val2 = delegate
				{
					((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус:";
				};
				_003C_003Ec._003C_003E9__83_1 = val2;
				obj2 = (object)val2;
			}
			((Control)labelStatus2).Invoke((Delegate)obj2);
			return;
		}
		if (_driver.IsFindElement(By.XPath("//div[@class=\"school_history_lever \"]")).IsClick("Клик Старт", 1000))
		{
			LogService.LogHtml("Класс истории");
			_driver.IsFindElement(By.XPath("//div[@class='box_title']/div[contains(@class,'box_x_button']")).IsClick("Клик Закрыть");
		}
		webElement = _driver.IsFindElement(By.XPath("//span[@class=\"school_history_energy_reload_timer\"]/span"));
		if (webElement != null && webElement.Text != "00:00:00")
		{
			DateTime.TryParseExact(webElement.Text, "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out result);
			KlassIstoriiDatetime = DateTime.Now.AddSeconds(result.Second + 2).AddMinutes(result.Minute).AddHours(result.Hour);
			Label labelStatus3 = (Application.OpenForms[0] as Form1).labelStatus;
			object obj3 = _003C_003Ec._003C_003E9__83_2;
			if (obj3 == null)
			{
				System.Windows.Forms.MethodInvoker val3 = delegate
				{
					((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус:";
				};
				_003C_003Ec._003C_003E9__83_2 = val3;
				obj3 = (object)val3;
			}
			((Control)labelStatus3).Invoke((Delegate)obj3);
			return;
		}
		webElement = _driver.IsFindElement(By.XPath("//span[@class=\"school_history_next_turn_timer\"]"));
		if (webElement != null && webElement.Text != "00:00:00" && webElement.Text != "")
		{
			DateTime.TryParseExact(webElement.Text, "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out result);
			KlassIstoriiDatetime = DateTime.Now.AddSeconds(result.Second + 2).AddMinutes(result.Minute).AddHours(result.Hour);
			Label labelStatus4 = (Application.OpenForms[0] as Form1).labelStatus;
			object obj4 = _003C_003Ec._003C_003E9__83_3;
			if (obj4 == null)
			{
				System.Windows.Forms.MethodInvoker val4 = delegate
				{
					((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус:";
				};
				_003C_003Ec._003C_003E9__83_3 = val4;
				obj4 = (object)val4;
			}
			((Control)labelStatus4).Invoke((Delegate)obj4);
			return;
		}
		if (_driver.IsFindElement(By.XPath("//input[@value=\"УРА!\"][@type=\"submit\"]")).IsClick("Клик УРА"))
		{
			Thread.Sleep(1000);
		}
		if (_driver.ResyPiraShki() > 100000)
		{
			_driver.IsFindElement(By.XPath("//input[@value=\"ВРЕМЯ ПРИКЛЮЧЕНИЙ!\"][@type=\"submit\"]")).IsClick("Клик ВРЕМЯ ПРИКЛЮЧЕНИЙ!");
		}
		Label labelStatus5 = (Application.OpenForms[0] as Form1).labelStatus;
		object obj5 = _003C_003Ec._003C_003E9__83_4;
		if (obj5 == null)
		{
			System.Windows.Forms.MethodInvoker val5 = delegate
			{
				((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус:";
			};
			_003C_003Ec._003C_003E9__83_4 = val5;
			obj5 = (object)val5;
		}
		((Control)labelStatus5).Invoke((Delegate)obj5);
		KlassIstoriiDatetime = DateTime.Now.AddMinutes(5.0);
	}

	private DateTime DalnieStrany()
	{
		if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//b[contains(@class,\"guild_ship \")]/../..//span//span")).GetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result) && (result.Hour != 0 || result.Minute != 0 || result.Second != 0))
		{
			RabotaMainDatetime = DateTime.Now.AddSeconds(result.Second + 2).AddMinutes(result.Minute).AddHours(result.Hour);
			Find.LabelStatus("Статус:");
			return RabotaMainDatetime;
		}
		Find.LabelStatus("Статус: Дальнии страны");
		_driver.Fast("f9", "Дальнии страны");
		if (int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//p[contains(text(),\"Законсервированных ядрёных смесей:\")]")).GetAttribute("outerText")
			where char.IsDigit(c)
			select c), out var result2) && result2 > 20)
		{
			_driver.IsFindElement(By.XPath("//a[contains(text(),\"ПОЛОЖИТЬ ВСЕ\")]")).IsClick("Положить все");
			_driver.IsFindElement(By.XPath("//form[@rel=\"4\"]/input[@value=\"НАНЯТЬ\"]")).IsClick("Линейный голенус");
		}
		RabotaMainDatetime = _driver.DateTimeCount("//div[@id=\"guild_ships_timer\"]");
		if (RabotaMainDatetime > DateTime.Now)
		{
			Find.LabelStatus("Статус:");
			return RabotaMainDatetime = RabotaMainDatetime.AddSeconds(30.0);
		}
		return RabotaMainDatetime = DateTime.Now.AddMinutes(5.0);
	}

	public void KriMax()
	{
		if (!AppSettings.Get("checkBoxKriMax", defaultValue: false))
		{
			KriMaxDatetime = DateTime.Now.AddSeconds(10.0);
		}
		else
		{
			if (KriMaxDatetime > DateTime.Now)
			{
				return;
			}
			string attribute = _driver.IsFindElement(By.Id("crystal")).GetAttribute("outerHTML");
			if (attribute == null)
			{
				return;
			}
			attribute = Regex.Replace(attribute, ".+?max_crystals:\\|(\\d+)\\|.*$", "$1", RegexOptions.Singleline);
			double num = Convert.ToDouble(((Control)(Application.OpenForms[0] as Form1).labelKri).Text);
			double num2 = Convert.ToDouble(Convert.ToInt32(attribute));
			if (num / num2 > 0.9)
			{
				IWebElement webElement = _driver.IsFindElement(By.XPath("//a[@href=\"/kingHram.php\"]"));
				if ((webElement != null) & !_driver.Url.Contains("botva.ru/kingHram.php"))
				{
					_driver.IsFindElement(By.XPath("//div[@name='104']/b")).IsClick();
					Thread.Sleep(1000);
					webElement.IsClick();
				}
				try
				{
					_driver.FindElement(By.XPath("//select[@name='buy']/option[3]"))?.IsClick("buy");
					Thread.Sleep(500);
					for (int i = 0; i < 5; i++)
					{
						if (!AppSettings.Get("checkBoxKriMax", defaultValue: false))
						{
							break;
						}
						webElement = _driver.IsFindElement(By.Id("balert_wrap"));
						if (webElement != null)
						{
							attribute = webElement.Text;
						}
						if (!attribute.Contains("Нужно больше ресурсов!"))
						{
							if (attribute.Contains("УРА"))
							{
								i = 0;
							}
							_driver.FindElement(By.XPath("//form[@class='submit_by_ajax_completed']//input[@type='submit']")).IsClick();
							Thread.Sleep(500);
							continue;
						}
						break;
					}
				}
				catch
				{
				}
				KriMaxDatetime = DateTime.Now.AddMinutes(10.0);
			}
			else
			{
				KriMaxDatetime = DateTime.Now.AddMinutes(5.0);
			}
		}
	}
}
