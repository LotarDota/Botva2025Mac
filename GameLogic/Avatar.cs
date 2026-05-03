using Botva2025.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Botva2025;

internal class Avatar
{
	private static IWebDriver _driver;

	private Form1 _mainForm;

	private DateTime AvatarMainDateTime = DateTime.Now;

	private int avatar_Shashta_10 = 10;

	private StatUpgrader _AvatarKach;

	private AkciiServer _AvatarAkcii_1;

	private AkciiServer _AvatarAkcii_2;

	private Muzey _Muzey;

	private Pomogashki _Pomogashki;

	private AvatarBitvaShashta _AvatarBitvaShashta;

	private int avatarEnergi = 25;

	public static DateTime dateTime1;

	private Ikarus _Ikarus;

	private string OlldTimerName = "";

	private Dictionary<int, string> akcii = Akcii.AkciiDictionary();

	private Dictionary<string, DateTime> AvatarDateTime = new Dictionary<string, DateTime>
	{
		["AvatarAkcii_1"] = DateTime.Now,
		["AvatarAkcii_2"] = DateTime.Now,
		["AvatarBodalka"] = DateTime.Now,
		["AvatarKorablik"] = DateTime.Now,
		["AvatarPriz"] = DateTime.Now,
		["AvatarZemliSbor"] = DateTime.Now,
		["AvatarShashta"] = DateTime.Now,
		["AvatarMuzey"] = DateTime.Now,
		["AvatarStrashilki"] = DateTime.Now,
		["AvatarIkarus"] = DateTime.Now,
		["AvatarPolyna"] = DateTime.Now,
		["AvatarTaynyyOrden"] = DateTime.Now,
		["AvatarFerma"] = DateTime.Now,
		["AvatarBitvaShashta"] = DateTime.Now
	};

	public Dictionary<string, List<object>> AvatarData { get; set; }

	public Avatar(IWebDriver driver, Form1 mainForm)
	{
		_driver = driver;
		_mainForm = mainForm;
		_AvatarAkcii_1 = new AkciiServer(driver, "comboBoxAkciiAvatar1", "comboBoxPesochnica1");
		_AvatarAkcii_2 = new AkciiServer(driver, "comboBoxAkciiAvatar2", "comboBoxPesochnica2");
		_Muzey = new Muzey(driver);
		_Pomogashki = new Pomogashki(driver, _mainForm);
		_AvatarBitvaShashta = new AvatarBitvaShashta(driver);
		_Ikarus = new Ikarus(driver);
		_AvatarKach = new StatUpgrader(driver, () => AppSettings.Get("checkBoxAvatarKach", defaultValue: false), () => new bool[5]
		{
			AppSettings.Get("checkBoxAvatar_Kach1", defaultValue: false),
			AppSettings.Get("checkBoxAvatar_Kach2", defaultValue: false),
			AppSettings.Get("checkBoxAvatar_Kach3", defaultValue: false),
			AppSettings.Get("checkBoxAvatar_Kach4", defaultValue: false),
			AppSettings.Get("checkBoxAvatar_Kach5", defaultValue: false)
		});
	}

	public void AvatarMainDataTimeName(string dateName)
	{
		if (AvatarDateTime.ContainsKey(dateName))
		{
			AvatarDateTime[dateName] = DateTime.Now;
			AvatarMainDateTime = DateTime.Now;
		}
	}

	public void AvatarMainDataTime()
	{
		for (int i = 0; i < AvatarDateTime.Count; i++)
		{
			AvatarDateTime[AvatarDateTime.ElementAt(i).Key] = DateTime.Now;
		}
		_AvatarKach.ZolotoForKach = 0;
		AvatarMainDateTime = DateTime.Now;
		_AvatarAkcii_1.SetverTimeData();
		_AvatarAkcii_2.SetverTimeData();
		AvatarBitvaShashta.avatarBitvaShashtaDateTime = DateTime.Now;
	}

	public void AvatarMain01()
	{
		foreach (string key in AvatarData.Keys)
		{
			List<object> list = AvatarData[key];
			bool flag = (bool)list[0];
			DateTime dateTime = (DateTime)list[1];
			Action action = (Action)list[2];
			if (flag)
			{
				try
				{
					action();
				}
				catch (Exception)
				{
				}
			}
		}
	}

	public void AvatarMain()
	{
		if (AvatarMainDateTime > DateTime.Now)
		{
			return;
		}
		AvatarVhod();
		if (_driver.IsFindElement(By.XPath("//b[contains(@class,\"icon2 icon_snowman\")]")).IsClick("Снеговик", 1000))
		{
			_driver.IsFindElement(By.XPath("//span[text()=\"Да, конечно\"]")).IsClick("Да, конечно");
		}
		try
		{
			_AvatarKach.AvatarKach();
		}
		catch
		{
		}
		try
		{
			AvatarZabratPriz();
		}
		catch
		{
		}
		try
		{
			AvatarBitvaShashtaMain();
		}
		catch
		{
		}
		try
		{
			AvatarZemliSbor();
		}
		catch
		{
		}
		try
		{
			AvatarAkcii1();
		}
		catch
		{
		}
		try
		{
			AvatarAkcii2();
		}
		catch
		{
		}
		try
		{
			AvatarPolyna();
		}
		catch
		{
		}
		try
		{
			AvatarZadaniy();
		}
		catch
		{
		}
		try
		{
			AvatarBodalka();
		}
		catch
		{
		}
		try
		{
			AvatarKorablik();
		}
		catch
		{
		}
		try
		{
			AvatarShashta();
		}
		catch
		{
		}
		try
		{
			AvatarMuzey();
		}
		catch
		{
		}
		try
		{
			AvatarStrashilki();
		}
		catch
		{
		}
		try
		{
			AvatarIkarus();
		}
		catch
		{
		}
		try
		{
			_AvatarKach.AvatarKach();
		}
		catch
		{
		}
		try
		{
			AvatarTaynyyOrden();
		}
		catch
		{
		}
		try
		{
			_driver.AvatarSyndykProdat();
		}
		catch
		{
		}
		try
		{
			AvatarFerma();
		}
		catch
		{
		}
		try
		{
			AvatarTaymer();
		}
		catch
		{
		}
		try
		{
			AvatarVyhod();
		}
		catch
		{
		}
	}

	private void AvatarBitvaShashtaMain()
	{
		AvatarDateTime["AvatarBitvaShashta"] = _AvatarBitvaShashta.AvatarBitvaShashtaMain();
	}

	private void AvatarAkcii1()
	{
		AvatarDateTime["AvatarAkcii_1"] = _AvatarAkcii_1.AkciiServerMain();
	}

	private void AvatarAkcii2()
	{
		AvatarDateTime["AvatarAkcii_2"] = _AvatarAkcii_2.AkciiServerMain();
	}

	private void AvatarZadaniy()
	{
		if (!AppSettings.Get("checkBoxZadaniy", defaultValue: false))
		{
			return;
		}
		if (_driver.IsFindElement(By.XPath("//div[@id='accordion']//div[@name='108'][contains(string(.),'Наложить любой заговор ')]")) != null)
		{
			if (_driver.IsFindElement(By.XPath("//div[@id='accordion']//div[@name='108'][contains(string(.),'Наложить любой заговор')]//span[@class='js_timer ']")) != null)
			{
				return;
			}
			_driver.isExecuteScriptClick(By.XPath("//a[@class='alink'][contains(@onclick,'ajax.php?m=daily_quests')]"), "внутрь задания");
			_driver.isExecuteScriptClick(By.XPath("//form[contains(@action,'ajax.php?m=daily_quests')]//div[contains(string(.),'ЗАМЕНИТЬ ЗАДАНИЕ')]"), "заменить");
			_driver.isExecuteScriptClick(By.XPath("//div[contains(@class,'button_solid')][contains(string(.),'Точно?')]/input"), "заменить");
		}
		if (_driver.IsFindElement(By.XPath("//div[@id='accordion']//div[@name='108'][contains(string(.),'Посетить Битвы за земли за Зверя')]")) != null)
		{
			if (!_driver.Url.Contains("botva.ru/conflict.php"))
			{
				_driver.isExecuteScriptClick(By.Id("m44"), "Битва за земли");
			}
			_driver.IsFindElement(By.XPath("//a[@class='btn btn_lobby']")).IsClick("Выбор умений");
			_driver.IsFindElement(By.XPath("//div[@data-type='1'][not(contains(@class,'active'))]")).IsClick("Выбор Зверя");
		}
		if (_driver.IsFindElement(By.XPath("//div[@id='accordion']//div[@name='108'][contains(string(.),'Посетить Битвы за земли за Лекаря')]")) != null)
		{
			if (!_driver.Url.Contains("botva.ru/conflict.php"))
			{
				_driver.isExecuteScriptClick(By.Id("m44"), "Битва за земли");
			}
			_driver.IsFindElement(By.XPath("//a[@class='btn btn_lobby']")).IsClick("Выбор умений");
			_driver.IsFindElement(By.XPath("//div[@data-type='2'][not(contains(@class,'active'))]")).IsClick("Выбор Лекаря");
		}
		if (_driver.IsFindElement(By.XPath("//div[@id='accordion']//div[@name='108'][contains(string(.),'Посетить Битвы за земли за Танка')]")) != null)
		{
			if (!_driver.Url.Contains("botva.ru/conflict.php"))
			{
				_driver.isExecuteScriptClick(By.Id("m44"), "Битва за земли");
			}
			_driver.IsFindElement(By.XPath("//a[@class='btn btn_lobby']")).IsClick("Выбор умений");
			_driver.IsFindElement(By.XPath("//div[@data-type='3'][not(contains(@class,'active'))]")).IsClick("Выбор Танка");
		}
		if (_driver.IsFindElement(By.XPath("//div[@id='accordion']//div[@name='108'][contains(string(.),'Посетить Битвы за земли за Ниндзю')]")) != null)
		{
			if (!_driver.Url.Contains("botva.ru/conflict.php"))
			{
				_driver.isExecuteScriptClick(By.Id("m44"), "Битва за земли");
			}
			_driver.IsFindElement(By.XPath("//a[@class='btn btn_lobby']")).IsClick("Выбор умений");
			_driver.IsFindElement(By.XPath("//div[@data-type='4'][not(contains(@class,'active'))]")).IsClick("Выбор Ниндзю");
		}
		if (_driver.IsFindElement(By.XPath("//div[@id='accordion']//div[@name='108'][contains(string(.),'Удачно создать предметы в Мастерской')]")) != null)
		{
			if (!_driver.Url.Contains("botva.ru/conflict.php"))
			{
				_driver.isExecuteScriptClick(By.Id("m44"), "Битва за земли");
			}
			_driver.IsFindElement(By.XPath("//a[@class='btn btn_craft btn3']")).IsClick("Мастерская");
			int[] array = new int[2];
			int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//div[@data-item='9']")).isGetAttribute("outerText")
				where char.IsDigit(c)
				select c), out array[0]);
			int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//div[@data-item='1655']")).isGetAttribute("outerText")
				where char.IsDigit(c)
				select c), out array[0]);
			if (array[0] > array[1])
			{
				_driver.IsFindElement(By.XPath("//div[@data-item='1655'][not(contains(@class,'chosen'))] ")).IsClick("Выбераю 1655");
			}
			else
			{
				_driver.IsFindElement(By.XPath("//div[@data-item='9'][not(contains(@class,'chosen'))] ")).IsClick("Выбираю 9");
			}
			_driver.IsFindElement(By.XPath("//div[@class='conflictcraft_process']//span[string(.)='СОЗДАТЬ']")).IsClick("Создать");
			string xpathToFind = "//div[contains(@class,'confirm_content_box')]//span[string(.)='СОЗДАТЬ ЕЩЕ!']";
			for (int num = 0; num < 10; num++)
			{
				if (_driver.IsFindElement(By.XPath("//div[@id='accordion']//div[@name='108'][contains(string(.),'Удачно создать предметы в Мастерской')]")) == null)
				{
					break;
				}
				_driver.WaitFind(By.XPath(xpathToFind), TimeSpan.FromSeconds(3L));
				if (!_driver.IsFindElement(By.XPath("//div[contains(@class,'confirm_content_box')]//span[string(.)='СОЗДАТЬ ЕЩЕ!']")).IsClick("Создать еще " + num))
				{
					break;
				}
			}
		}
		if (_driver.IsFindElement(By.XPath("//div[@id='accordion']//div[@name='108'][contains(string(.),'Совершить 10 удачных копок в шахте')]")) != null && AvatarEnergy() > 25)
		{
			_driver.isExecuteScriptClick(By.Id("m6"), "Клик Шахта");
			for (int num2 = 0; num2 < 7; num2++)
			{
				if (AvatarEnergy() < 25)
				{
					break;
				}
				IWebElement elem = _driver.IsFindElement(By.XPath("//div[contains(@class,\"work_in_mine_tutorial\")]//span"));
				if (elem.IsClick("АватарРаботать"))
				{
					Thread.Sleep(5000);
				}
				_driver.IsFindElement(By.XPath("//div[contains(@class,\"work_in_mine_tutorial\")]//a[contains(text(),\"ДОБЫТЬ\")]")).IsClick("Добыть");
			}
		}
		if (_driver.IsFindElement(By.XPath("//div[@id='accordion']//div[@name='108'][contains(string(.),'Победить в битвах за славу')]")) == null)
		{
			return;
		}
		_driver.isExecuteScriptClick(By.Id("m8"), "Клик Бодалка");
		_driver.IsFindElement(By.XPath("//div[@class='btn'][string(.)='Битвы за славу']")).IsClick("Битва за славу>", 800);
		List<(string Name, long Power, int Glory, int Level)> list = new List<(string Name, long Power, int Glory, int Level)>();
		string input = _driver.IsFindElement(By.XPath("//div[@class='tab'][@rel='1']")).isGetAttribute("outerHTML").Replace(".", "");
		Regex regex = new Regex("(?ims)form.*?char_id.*?value=.(\\d+).*?avatar_rating_enemy_stat.*?>(\\d+).*?>(\\d+).*?(\\d+)\\s*место");
		MatchCollection matchCollection = regex.Matches(input);
		foreach (Match item4 in matchCollection)
		{
			if (item4.Groups.Count >= 5)
			{
				string value = item4.Groups[1].Value;
				long item = long.Parse(item4.Groups[2].Value.Replace(".", ""));
				int item2 = int.Parse(item4.Groups[3].Value.Replace(".", ""));
				int item3 = int.Parse(item4.Groups[4].Value);
				list.Add((value, item, item2, item3));
			}
		}
		List<(string Name, long Power, int Glory, int Level)> list2 = (from p in list
			orderby p.Power, p.Glory
			select p).ToList();
		foreach (var item5 in list2)
		{
		}
		_driver.isExecuteScriptClick(By.XPath("//input[@name='char_id'][@value='" + list2[0].Item1 + "']//..//div[@class='avatar_rating_enemy_action active']"), "Атаковать " + list2[0].Item1);
	}

	private void AvatarFerma()
	{
		if (!AppSettings.Get("checkBoxFermaAvatar", defaultValue: false))
		{
			AvatarDateTime["AvatarFerma"] = DateTime.Now.AddMinutes(60.0);
		}
		else
		{
			if (AvatarDateTime["AvatarFerma"] > DateTime.Now)
			{
				return;
			}
			UpdateStatus("Статус: Аватар Ферма");
			if (TimerRabota(out var dateTime))
			{
				AvatarDateTime["AvatarFerma"] = DateTime.Now.Add(dateTime.TimeOfDay).AddSeconds(20.0);
				UpdateStatus("Статус:");
				return;
			}
			_driver.isExecuteScriptClick(By.Id("m3"), "Клик Деревня");
			WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15L));
			_driver.IsFindElement(By.XPath("//a[contains(@href,\"farm.php\")]")).IsClick("Ферма", 1000);
			_driver.IsFindElement(By.XPath("//input[@value=\"РАБОТАТЬ\"]")).IsClick("Ферма Работать", 1000);
			if (TimerRabota(out dateTime))
			{
				AvatarDateTime["AvatarFerma"] = DateTime.Now.Add(dateTime.TimeOfDay).AddSeconds(20.0);
				UpdateStatus("Статус:");
			}
			else
			{
				UpdateStatus("Статус:");
				AvatarDateTime["AvatarFerma"] = DateTime.Now.AddMinutes(5.0);
			}
		}
	}

	private void AvatarTaynyyOrden()
	{
		if (!AppSettings.Get("checkBoxAvatarTaynyyOrden", defaultValue: false))
		{
			AvatarDateTime["AvatarTaynyyOrden"] = DateTime.Now.AddMinutes(60.0);
		}
		else
		{
			if (AvatarDateTime["AvatarTaynyyOrden"] > DateTime.Now)
			{
				return;
			}
			if (_driver.ResyKri() < 1000)
			{
				AvatarDateTime["AvatarTaynyyOrden"] = DateTime.Now.AddMinutes(30.0);
				return;
			}
			UpdateStatus("Статус: Аватар Тайный Орден");
			if (TimerRabota(out var dateTime))
			{
				AvatarDateTime["AvatarTaynyyOrden"] = DateTime.Now.Add(dateTime.TimeOfDay).AddSeconds(20.0);
				UpdateStatus("Статус:");
				return;
			}
			WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5L));
			_driver.isExecuteScriptClick(By.Id("m6"), "Клик Шахта");
			if (AppSettings.Get("checkBoxAvatarTaynyyOrdenSvitki", defaultValue: false))
			{
				_driver.IsFindElement(By.XPath("//b[contains(@class,\"ico_arcane_scroll\")]//..//form/input[@type=\"submit\"]")).IsClick("Начать спуск", 1000);
			}
			if (TimerRabotaOrden(out dateTime))
			{
				AvatarDateTime["AvatarTaynyyOrden"] = DateTime.Now.Add(dateTime.TimeOfDay).AddSeconds(20.0);
				UpdateStatus("Статус:");
				return;
			}
			bool flag = AppSettings.Get("checkBoxAvatarTaynyyOrdenSpusk", defaultValue: false);
			_driver.IsFindElement(By.XPath("//span[contains(text(),\"НАЧАТЬ СПУСК\")]//input[@type=\"submit\"]")).IsClick("Начать спуск", 1000);
			int num = 0;
			int num2 = 200;
			for (int i = 0; i < num2; i++)
			{
				if (num >= 10)
				{
					break;
				}
				try
				{
					_driver.WaitFind(By.XPath("//span[contains(text(), \"Напасть\")]//input[@type=\"submit\"] | //span[contains(text(), \"Спуститься\")]//input[@type=\"submit\"]"), TimeSpan.FromSeconds(1L));
					if (flag)
					{
						if (!_driver.IsFindElement(By.XPath("//span[contains(text(),\"Спуститься\")]//input[@type=\"submit\"]")).IsClick("Спуститься") && !_driver.IsFindElement(By.XPath("//span[contains(text(),\"Напасть\")]//input[@type=\"submit\"]")).IsClick("Напасть"))
						{
							num++;
						}
					}
					else if (!_driver.IsFindElement(By.XPath("//span[contains(text(),\"Напасть\")]//input[@type=\"submit\"]")).IsClick("Напасть") && !_driver.IsFindElement(By.XPath("//span[contains(text(),\"Спуститься\")]//input[@type=\"submit\"]")).IsClick("Спуститься"))
					{
						num++;
					}
					if (_driver.IsFindElement(By.XPath("//span[contains(text(),\"На воздух!\")]")).IsClick("На воздух!"))
					{
						_driver.WaitFind(By.XPath("//span[contains(text(),\"Да, конечно\")]"), TimeSpan.FromSeconds(5L));
						if (_driver.IsFindElement(By.XPath("//span[contains(text(),\"Да, конечно\")]")).IsClick("Да, конечно", 1000))
						{
							break;
						}
					}
				}
				catch
				{
				}
			}
			if (_driver.IsFindElement(By.XPath("//span[contains(text(),\"На воздух!\")]")).IsClick("На воздух!"))
			{
				_driver.WaitFind(By.XPath("//span[contains(text(),\"Да, конечно\")]"), TimeSpan.FromSeconds(5L));
				_driver.IsFindElement(By.XPath("//span[contains(text(),\"Да, конечно\")]")).IsClick("Да, конечно", 2000);
			}
			if (TimerRabota(out dateTime))
			{
				AvatarDateTime["AvatarTaynyyOrden"] = DateTime.Now.Add(dateTime.TimeOfDay).AddSeconds(20.0);
				UpdateStatus("Статус:");
			}
			else if (AppSettings.Get("checkBoxAvatarTaynyyOrdenSvitki", defaultValue: false) && _driver.IsFindElement(By.XPath("//b[contains(@class,\"ico_arcane_scroll\")]//..//form/input[@type=\"submit\"]")) != null)
			{
				AvatarDateTime["AvatarTaynyyOrden"] = DateTime.Now.AddMinutes(5.0);
				UpdateStatus("Статус:");
			}
			else if (TimerRabotaOrden(out dateTime))
			{
				AvatarDateTime["AvatarTaynyyOrden"] = DateTime.Now.Add(dateTime.TimeOfDay).AddSeconds(20.0);
				UpdateStatus("Статус:");
			}
			else
			{
				UpdateStatus("Статус:");
				AvatarDateTime["AvatarTaynyyOrden"] = DateTime.Now.AddMinutes(5.0);
			}
		}
	}

	private bool TryGetTimeFromElement(string xpath, out DateTime dateTime)
	{
		IWebElement webElement = _driver.IsFindElement(By.XPath(xpath));
		if (webElement != null)
		{
			string s = webElement.isGetAttribute("outerText");
			return DateTime.TryParseExact(s, "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out dateTime);
		}
		dateTime = default(DateTime);
		return false;
	}

	private void UpdateStatus(string text)
	{
		Find.LabelStatus(text);
	}

	private void AvatarTaymer()
	{
		if (AvatarDateTime == null || AvatarDateTime.Count == 0)
		{
			AvatarMainDateTime = DateTime.Now.AddMinutes(2.0);
			return;
		}
		List<KeyValuePair<string, DateTime>> list = AvatarDateTime.OrderBy((KeyValuePair<string, DateTime> pair) => pair.Value).ToList();
		foreach (KeyValuePair<string, DateTime> item in list)
		{
		}
		KeyValuePair<string, DateTime> keyValuePair = AvatarDateTime.OrderBy((KeyValuePair<string, DateTime> pair) => pair.Value).FirstOrDefault((KeyValuePair<string, DateTime> pair) => pair.Value > DateTime.Now);
		if (keyValuePair.Key != null)
		{
			AvatarMainDateTime = keyValuePair.Value;
			OlldTimerName = $"Вход аватар: {keyValuePair.Key} в {keyValuePair.Value}";
		}
		else
		{
			AvatarMainDateTime = DateTime.Now.AddMinutes(2.0);
			OlldTimerName = "Вход Нет доступных аватаров в будущем. Установлено время: " + AvatarMainDateTime;
		}
	}

	private bool TimerRabota(out DateTime dateTime)
	{
		if (TryGetTimeFromElement("//div[@class=\"rmenu1_avatar_wrap\"]//a[contains(@class,\"timer link\")]/span[@class=\"js_timer \"]", out dateTime))
		{
			return true;
		}
		return false;
	}

	private bool TimerRabotaOrden(out DateTime dateTime)
	{
		if (TryGetTimeFromElement("//span[contains(string(.),\"В ОРДЕН\")]//..//..//span[contains(@class,\"js_timer\")]", out dateTime))
		{
			return true;
		}
		return false;
	}

	private void AvatarStrashilki()
	{
		if (!AppSettings.Get("checkBoxAvatarStrashilki", defaultValue: false) || AvatarDateTime["AvatarStrashilki"] > DateTime.Now)
		{
			return;
		}
		Find.LabelStatus("Статус:Аватар Страшилка");
		if (!AppSettings.Get("checkBoxSnejnyGolem", defaultValue: false) && TryGetTimeFromElement("//div[@class=\"rmenu1_avatar_wrap\"]//a[contains(@class,\"timer link\")]/span[@class=\"js_timer \"]", out dateTime1))
		{
			AvatarDateTime["AvatarStrashilki"] = DateTime.Now.Add(dateTime1.TimeOfDay).AddSeconds(20.0);
			UpdateStatus("Статус:");
			return;
		}
		_driver.isExecuteScriptClick(By.Id("m8"), "Клик Бодалка");
		if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//div[contains(@class,\"button_new cmd_blocked small_sl\")]//span[contains(@class,\"js_timer\")]")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out dateTime1))
		{
			AvatarDateTime["AvatarStrashilki"] = DateTime.Now.AddSeconds(dateTime1.Second + 20).AddMinutes(dateTime1.Minute).AddHours(dateTime1.Hour);
			Find.LabelStatus("Статус:");
			return;
		}
		if (_driver.IsFindElement(By.XPath("//div[@class=\"btn\"][text()=\"Поиск страшилок\"]")).IsClick("Поиск страшилок"))
		{
			Thread.Sleep(500);
		}
		if (_driver.IsFindElement(By.XPath("//span[contains(text(),\"Найти других\")]//input[@type=\"submit\"]")).IsClick("Найти других"))
		{
			Thread.Sleep(1000);
		}
		Actions actions = new Actions(_driver);
		for (int i = 1; i < 5; i++)
		{
			IWebElement elem = _driver.IsFindElement(By.XPath("//div[" + i + "]/div[@class=\"button_solid\"][contains(text(),\"НАПАСТЬ\")]//input[@type=\"submit\"]"));
			if (elem.IsClick("Напасть страшилка " + i))
			{
				LogService.LogHtml("Аватар страшилка " + i);
				Thread.Sleep(500);
				_driver.IsFindElement(By.XPath("//a[@href=\"dozor.php\"]/span[text()=\"НАЗАД\"]//..")).IsClick("Назад");
			}
		}
		if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//div[contains(@class,\"button_new cmd_blocked small_sl\")]//span[contains(@class,\"js_timer\")]")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out dateTime1))
		{
			AvatarDateTime["AvatarStrashilki"] = DateTime.Now.AddSeconds(dateTime1.Second + 20).AddMinutes(dateTime1.Minute).AddHours(dateTime1.Hour);
		}
		Find.LabelStatus("Статус:");
		if (AvatarDateTime["AvatarStrashilki"] <= DateTime.Now)
		{
			AvatarDateTime["AvatarStrashilki"] = DateTime.Now.AddMinutes(30.0);
		}
	}

	private void AvatarPolyna()
	{
		if (!AppSettings.Get("checkBoxAvatarPolyna", defaultValue: false) || AvatarDateTime["AvatarPolyna"] > DateTime.Now)
		{
			return;
		}
		bool flag = false;
		Find.LabelStatus("Статус:Аватар Поляна");
		if (TimerRabota(out dateTime1))
		{
			AvatarDateTime["AvatarPolyna"] = DateTime.Now.Add(dateTime1.TimeOfDay).AddSeconds(20.0);
			UpdateStatus("Статус:");
			return;
		}
		_driver.isExecuteScriptClick(By.Id("m6"), "Клик Шахта");
		string[] array = _driver.IsFindElement(By.XPath("//b[contains(@class,\"ico_ticket1\")]/..")).isGetAttribute("outerText").Split('/');
		int[] array2 = new int[2];
		for (int i = 0; i < array.Length; i++)
		{
			int.TryParse(string.Join("", array[i].Where((char c) => char.IsDigit(c))), out array2[i]);
		}
		if (array2[0] * 100 > array2[1] * 75)
		{
			Find.LabelStatus("Статус:Поляна Маленькая");
			if (_driver.IsFindElement(By.XPath("//a[contains(text(),\"МАЛЕНЬКАЯ\")]")).IsClick("МАЛЕНЬКАЯ"))
			{
				flag = true;
			}
			PolynaClick();
		}
		array = _driver.IsFindElement(By.XPath("//b[contains(@class,\"ico_ticket2\")]/..")).isGetAttribute("outerText").Split('/');
		array2[0] = 0;
		array2[1] = 0;
		for (int num = 0; num < array.Length; num++)
		{
			int.TryParse(string.Join("", array[num].Where((char c) => char.IsDigit(c))), out array2[num]);
		}
		if (array2[0] * 100 > array2[1] * 75)
		{
			Find.LabelStatus("Статус:Поляна БОЛЬШАЯ");
			if (_driver.IsFindElement(By.XPath("//a[contains(text(),\"БОЛЬШАЯ\")]")).IsClick("БОЛЬШАЯ"))
			{
				flag = true;
			}
			PolynaClick();
		}
		for (int num2 = 0; num2 < 2; num2++)
		{
			if (_driver.IsFindElement(By.XPath("//a[contains(text(),\"ВСЛЕПУЮ\")]")).IsClick("ВСЛЕПУЮ"))
			{
				Thread.Sleep(500);
			}
			_driver.IsFindElement(By.XPath("//div[contains(@class,\"timers\")]//a[@href=\"mine.php?a=mine\"]")).IsClick("БилетСправа");
			Thread.Sleep(500);
		}
		Find.LabelStatus("Статус:");
		if (flag)
		{
			AvatarDateTime["AvatarPolyna"] = DateTime.Now.AddMinutes(10.0);
		}
		else
		{
			AvatarDateTime["AvatarPolyna"] = DateTime.Now.AddMinutes(120.0);
		}
	}

	private void PolynaClick()
	{
		int num = 0;
		WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2L));
		int num2 = 0;
		int num3 = 0;
		int result = 0;
		for (int i = 0; i < 2; i++)
		{
			num++;
			if (num2 <= 5)
			{
				if (_driver.IsFindElement(By.XPath("//a[contains(text(),\"ВСЛЕПУЮ\")]")).IsClick("ВСЛЕПУЮ"))
				{
					i = 0;
					_driver.WaitFind(By.XPath("//a[contains(text(),\"ПОПРОБОВАТЬ ЕЩЁ\")]"), TimeSpan.FromSeconds(5L));
				}
				if (_driver.IsFindElement(By.XPath("//a[contains(text(),\"ПОПРОБОВАТЬ ЕЩЁ\")]")).IsClick("ПОПРОБОВАТЬ ЕЩЁ"))
				{
					i = 0;
					_driver.WaitFind(By.XPath("//a[contains(text(),\"ВСЛЕПУЮ\")]"), TimeSpan.FromSeconds(5L));
				}
				int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//td[contains(@class, 'pt3 pb3 pl10 border') and .//b[contains(@title,' поляну')]]")).isGetAttribute("outerText")
					where char.IsDigit(c)
					select c), out result);
				num2 = ((result == num3) ? (num2 + 1) : 0);
				num3 = result;
				continue;
			}
			break;
		}
	}

	private void AvatarMuzey()
	{
		if (!(AvatarDateTime["AvatarMuzey"] > DateTime.Now) && AppSettings.Get("checkBoxAvatarMyzey", defaultValue: false))
		{
			Find.LabelStatus("Статус: Аватар Музей");
			_Muzey.MuzeyGo();
			Find.LabelStatus("Статус:");
			AvatarDateTime["AvatarMuzey"] = DateTime.Now.AddMinutes(60.0);
		}
	}

	public void AvatarIkarus()
	{
		if (AvatarDateTime["AvatarIkarus"] > DateTime.Now)
		{
			return;
		}
		if (!AppSettings.Get("checkBoxAvatarIkarus", defaultValue: false))
		{
			AvatarDateTime["AvatarIkarus"] = DateTime.Now.AddMinutes(60.0);
			return;
		}
		Find.LabelStatus("Статус: Аватар Икарус");
		_driver.isExecuteScriptClick(By.Id("m3"), "Деревня");
		if (_driver.IsFindElement(By.XPath("//a[@href=\"icarus.php\"]")).IsClick("Икарус"))
		{
			Thread.Sleep(1000);
		}
		AvatarDateTime["AvatarIkarus"] = _Ikarus.IkarusGo();
		Find.LabelStatus("Статус:");
	}

	private void AvatarZemliSbor()
	{
		if (AvatarDateTime["AvatarZemliSbor"] > DateTime.Now || !AppSettings.Get("checkBoxAvatarZemliSbor", defaultValue: false))
		{
			return;
		}
		Find.LabelStatus("Статус: Аватар Собрать Ресы");
		if (!_driver.Url.Contains("botva.ru/conflict.php"))
		{
			_driver.isExecuteScriptClick(By.Id("m44"), "Битва за земли");
		}
		_driver.IsFindElement(By.XPath("//div[contains(@class,\"popup_my_container\")]//span[contains(string(.),\"ДОЖДАТЬСЯ НАГРАДЫ!\")]")).IsClick("ДОЖДАТЬСЯ НАГРАДЫ!", 1000);
		_driver.IsFindElement(By.XPath("//div[contains(@class,\"popup_my_container\")]//span[contains(string(.),\"ДОЖДАТЬСЯ НАГРАДЫ!\")]")).IsClick("ДОЖДАТЬСЯ НАГРАДЫ!", 1000);
		if (_driver.IsFindElement(By.XPath("//a[contains(@class,\"button_prepare has_chest\")]")).IsClick("Забрать Приз"))
		{
			Thread.Sleep(1000);
			if (_driver.IsFindElement(By.XPath("//span[contains(text(),\"Забрать награду\")]")).IsClick("Забрать награду"))
			{
				LogService.LogHtml("Аватар Забрать Награду ");
				_driver.isExecuteScriptClick(By.Id("m44"), "Битва за земли");
				Thread.Sleep(1000);
			}
		}
		if (_driver.IsFindElement(By.XPath("//input[@value=\"СОБРАТЬ ВСЁ\"]")).IsClick("СОБРАТЬ ВСЕ", 1000))
		{
			LogService.LogHtml("Аватар СОБРАТЬ ВСЕ ");
			if (_driver.IsFindElement(By.XPath("//input[@value=\"СОБРАТЬ ВСЁ\"]")).IsClick("СОБРАТЬ ВСЕ", 1000))
			{
				LogService.LogHtml("Аватар СОБРАТЬ ВСЕ 2 ");
			}
		}
		int num = 0;
		for (int i = 0; i < 2; i++)
		{
			if (_driver.IsFindElement(By.XPath("//div[contains(@class,\"conflict_res active title_is_bind\")]")).IsClick("ЗабратьРесурс"))
			{
				num++;
				Thread.Sleep(500);
				i = 0;
			}
		}
		string source = _driver.IsFindElement(By.XPath("//div[contains(@class,\"conflict_res\")][contains(@class,\"circle_progress\")]")).isGetAttribute("data-duration");
		if (int.TryParse(string.Join("", source.Where((char c) => char.IsDigit(c))), out var result))
		{
			AvatarDateTime["AvatarZemliSbor"] = DateTime.Now.AddSeconds(result / 1000);
		}
		else
		{
			AvatarDateTime["AvatarZemliSbor"] = DateTime.Now.AddMinutes(15.0);
		}
		if (num != 0)
		{
			LogService.LogHtml("Аватар Собрано " + num + " полей");
		}
		Find.LabelStatus("Статус:");
	}

	private void AvatarResyZizny()
	{
		if (_driver.ResyZizny() == 0 && _driver.ResyKri() > 20 && _driver.isExecuteScriptClick(By.XPath("//a[contains(@href,\"doPotions\")]"), "Открыть бутылки"))
		{
			Thread.Sleep(1000);
			if (_driver.isExecuteScriptClick(By.XPath("//a[contains(@href,\"doDrinkEx(3, true\")]"), "Выпить бутылку"))
			{
				Thread.Sleep(500);
			}
			if (_driver.isExecuteScriptClick(By.XPath("//a[contains(@href,\"doBuyPotionEx(3, true\")]"), "Купить мах бутылку"))
			{
				Thread.Sleep(500);
			}
		}
	}

	private void AvatarZabratPriz()
	{
		if (AvatarDateTime["AvatarPriz"] > DateTime.Now)
		{
			return;
		}
		if (_driver.IsFindElement(By.XPath("//div[@id=\"uptime_get_prize\"]//div[text()=\"Забрать\"]")).IsClick("ЗабратьПриз0"))
		{
			if (_driver.IsFindElement(By.XPath("//span[contains(text(),\"Забрать\")]//input")).IsClick("ЗабратьПриз1"))
			{
				LogService.LogHtml("Аватар Забрать Приз ");
			}
			_driver.isExecuteScriptClick(By.Id("m1"), "Клик Профиль");
		}
		if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//span[contains(@timer,\"uptime_prize_timer\")]")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result))
		{
			AvatarDateTime["AvatarPriz"] = DateTime.Now.AddSeconds(result.Second + 20).AddMinutes(result.Minute).AddHours(result.Hour);
		}
		else
		{
			AvatarDateTime["AvatarPriz"] = DateTime.Now.AddMinutes(5.0);
		}
	}

	private void AvatarKorablik()
	{
		if (AvatarDateTime["AvatarKorablik"] > DateTime.Now || !AppSettings.Get("checkBoxAvatarKorablik", defaultValue: false))
		{
			return;
		}
		Find.LabelStatus("Статус:Аватар Кораблик");
		if (_driver.IsFindElement(By.XPath("//div[@id=\"event_126\"]//span")).IsClick("Кораблик Эвент"))
		{
			_driver.IsFindElement(By.XPath("//form[@action=\"harbour.php?a=pier\"]//input[@value=\"ОТПРАВИТЬ\"]")).IsClick("Кораблик Отправить");
		}
		if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//div[@id=\"wait_ship\"]//span")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result))
		{
			AvatarDateTime["AvatarKorablik"] = DateTime.Now.AddSeconds(result.Second).AddMinutes(result.Minute + 2).AddHours(result.Hour);
			Find.LabelStatus("Статус:");
			return;
		}
		IWebElement webElement = _driver.IsFindElement(By.Id("balert_wrap"));
		if (webElement != null && webElement.isGetAttribute("outerText").Contains("Команда вышла в море за добычей уже 15 раз"))
		{
			TimeSpan timeSpan = DateTime.Today.AddDays(1.0) - DateTime.Now;
			AvatarDateTime["AvatarKorablik"] = DateTime.Now.AddSeconds(timeSpan.Seconds).AddMinutes(timeSpan.Minutes + 5).AddHours(timeSpan.Hours);
			Find.LabelStatus("Статус:");
		}
		else
		{
			Find.LabelStatus("Статус:");
			AvatarDateTime["AvatarKorablik"] = DateTime.Now.AddMinutes(30.0);
		}
	}

	private int AvatarEnergy()
	{
		int result = 0;
		if (!int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//span[@class=\"energy_now\"]")).isGetAttribute("outerText")
			where char.IsDigit(c)
			select c), out result))
		{
			result = 0;
		}
		return result;
	}

	public bool AvatarVhod()
	{
		try
		{
			if (_driver.Url.Contains("avatar"))
			{
				return true;
			}
			if (!AppSettings.Get("checkBoxAvatar", defaultValue: true))
			{
				return true;
			}
			UpdateStatus("Статус::Аватар вход ");
			if (_driver.isExecuteScriptClick(By.XPath("//a[@href=\"/avatara.php?a=jump\"][contains(@class,\"portal_avatarum\")]"), "Аватар Вход 1"))
			{
				Find.Sleep(1000);
				UpdateStatus("Статус:");
				_Pomogashki.Resy();
			}
			if (_driver.isExecuteScriptClick(By.XPath("//a[@href=\"/avatara.php?a=jump\"][contains(@class,\"portal_avatarum\")]"), "Аватар Вход 1"))
			{
				Find.Sleep(1000);
				UpdateStatus("Статус:");
				_Pomogashki.Resy();
			}
			if (_driver.Url.Contains("avatar"))
			{
				return true;
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	private void AvatarShashta_10()
	{
		if (TryGetTimeFromElement("//div[@class=\"rmenu1_avatar_wrap\"]//a[contains(@class,\"timer link\")]/span[@class=\"js_timer \"]", out dateTime1))
		{
			return;
		}
		UpdateStatus("Статус:Аватар шахта 10");
		_driver.isExecuteScriptClick(By.Id("m6"), "Клик Шахта");
		WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15L));
		for (int i = 0; i < 2; i++)
		{
			IWebElement elem = _driver.IsFindElement(By.XPath("//div[contains(@class,\"work_in_mine_tutorial\")]//span"));
			if (int.TryParse(string.Join("", from c in elem.isGetAttribute("outerText")
				where char.IsDigit(c)
				select c), out var result) && result == 0 && elem.IsClick("АватарРаботать"))
			{
				try
				{
					webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath("//a[contains(text(),\"ДОБЫТЬ\")]")));
				}
				catch
				{
				}
			}
			if (_driver.IsFindElement(By.XPath("//div[contains(@class,\"work_in_mine_tutorial\")]//a[contains(text(),\"ДОБЫТЬ\")]")).IsClick("Добыть0"))
			{
				i = 0;
			}
			if (_driver.IsFindElement(By.XPath("//a[contains(text(),\"ДОБЫТЬ\")]")).IsClick("Добыть1"))
			{
				i = 0;
			}
		}
		UpdateStatus("Статус:");
	}

	private void AvatarShashta()
	{
		if (!AppSettings.Get("checkBoxAvatarShaxta", defaultValue: false))
		{
			AvatarDateTime["AvatarShashta"] = DateTime.Now.AddMinutes(30.0);
			return;
		}
		if (TryGetTimeFromElement("//div[@class=\"rmenu1_avatar_wrap\"]//a[contains(@class,\"timer link\")]/span[@class=\"js_timer \"]", out dateTime1) && dateTime1.TimeOfDay != TimeSpan.Zero)
		{
			AvatarDateTime["AvatarShashta"] = DateTime.Now.Add(dateTime1.TimeOfDay).AddSeconds(20.0);
			UpdateStatus("Статус:");
			return;
		}
		if (avatar_Shashta_10 > 9)
		{
			AvatarBodalka_10();
			avatar_Shashta_10 = 0;
		}
		if (AvatarEnergy() < 25)
		{
			AvatarDateTime["AvatarShashta"] = DateTime.Now.AddMinutes(30.0);
			return;
		}
		UpdateStatus("Статус:Аватар Шахта");
		_driver.isExecuteScriptClick(By.Id("m6"), "Клик Шахта");
		for (int i = 0; i < 2; i++)
		{
			if (AvatarEnergy() < 25)
			{
				break;
			}
			IWebElement elem = _driver.IsFindElement(By.XPath("//div[contains(@class,\"work_in_mine_tutorial\")]//span"));
			if (elem.IsClick("АватарРаботать"))
			{
				Thread.Sleep(5000);
			}
			if (_driver.IsFindElement(By.XPath("//div[contains(@class,\"work_in_mine_tutorial\")]//a[contains(text(),\"ДОБЫТЬ\")]")).IsClick("Добыть"))
			{
				i = 0;
				avatar_Shashta_10++;
			}
		}
		UpdateStatus("Статус:");
		AvatarDateTime["AvatarShashta"] = DateTime.Now.AddMinutes(12.0);
	}

	private void AvatarBodalka_10()
	{
		if (TryGetTimeFromElement("//div[@class=\"rmenu1_avatar_wrap\"]//a[contains(@class,\"timer link\")]/span[@class=\"js_timer \"]", out dateTime1))
		{
			return;
		}
		UpdateStatus("Статус:Аватар Бодалка 10");
		for (int i = 0; i < 1; i++)
		{
			_driver.isExecuteScriptClick(By.Id("m8"), "Клик Бодалка");
			if (_driver.IsFindElement(By.XPath("//div[contains(@class,\"work_in_mine_tutorial\")]//a[contains(text(),\"ДОБЫТЬ\")]")).IsClick("Добыть", 2000))
			{
				_driver.isExecuteScriptClick(By.Id("m8"), "Клик Бодалка");
			}
			_driver.IsFindElement(By.XPath("//div[@id=\"watch_find\"]//input[@value=\"ПОИСК\"]")).IsClick("Атака по силе");
			_driver.IsFindElement(By.XPath("//div[@class=\"watch_attack_level\"]//input[@value=\"ПОИСК\"]")).IsClick("Атака по уровню");
			if (int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//form[@id=\"attack_form\"]//span")).isGetAttribute("outerText")
				where char.IsDigit(c)
				select c), out var result) && result == 0 && _driver.IsFindElement(By.XPath("//form[@id=\"attack_form\"]//input[@value=\"НАПАСТЬ\"]")).IsClick("НАПАСТЬ"))
			{
				Thread.Sleep(1000);
				i = 0;
			}
		}
		UpdateStatus("Статус:");
		AvatarDateTime["AvatarBodalka"] = DateTime.Now.AddMinutes(30.0);
	}

	private void AvatarBodalka()
	{
		if (!AppSettings.Get("checkBoxSnejnyGolem_Avatar", defaultValue: false) && TryGetTimeFromElement("//div[@class=\"rmenu1_avatar_wrap\"]//a[contains(@class,\"timer link\")]/span[@class=\"js_timer \"]", out dateTime1))
		{
			AvatarDateTime["AvatarBodalka"] = DateTime.Now.Add(dateTime1.TimeOfDay).AddSeconds(20.0);
			return;
		}
		if (avatar_Shashta_10 > 9)
		{
			AvatarShashta_10();
			avatar_Shashta_10 = 0;
		}
		if (!AppSettings.Get("checkBoxAvatarBodalka", defaultValue: false))
		{
			AvatarDateTime["AvatarBodalka"] = DateTime.Now.AddMinutes(30.0);
			return;
		}
		bool flag = false;
		for (int i = 0; i < 2; i++)
		{
			if (AvatarEnergy() < avatarEnergi)
			{
				if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//a[@class=\"timer halloween\"]//span")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result))
				{
					AvatarDateTime["AvatarBodalka"] = DateTime.Now.AddSeconds(result.Second + 20).AddMinutes(result.Minute).AddHours(result.Hour);
					Find.LabelStatus("Статус:");
				}
				else
				{
					Find.LabelStatus("Статус:");
					AvatarDateTime["AvatarBodalka"] = DateTime.Now.AddMinutes(30.0);
				}
				return;
			}
			AvatarResyZizny();
			Find.LabelStatus("Статус:Аватар Бодалка");
			if (!_driver.Url.Contains("botva.ru/dozor.php") || _driver.Url.Contains("a=log"))
			{
				_driver.isExecuteScriptClick(By.Id("m8"), "Клик м8");
			}
			if (_driver.IsFindElement(By.XPath("//div[contains(@class,\"work_in_mine_tutorial\")]//a[contains(text(),\"ДОБЫТЬ\")]")).IsClick("Добыть"))
			{
				_driver.isExecuteScriptClick(By.Id("m8"), "Клик м8");
			}
			_driver.IsFindElement(By.XPath("//div[@id=\"watch_find\"]//input[@value=\"ПОИСК\"]")).IsClick("Атака по силе");
			_driver.IsFindElement(By.XPath("//div[@class=\"watch_attack_level\"]//input[@value=\"ПОИСК\"]")).IsClick("Атака по уровню");
			if (_driver.IsFindElement(By.XPath("//form[@id=\"attack_form\"]//input[@value=\"НАПАСТЬ\"]")).IsClick("НАПАСТЬ"))
			{
				avatar_Shashta_10++;
				i = 0;
				Thread.Sleep(500);
				flag = true;
			}
			if (_driver.IsFindElement(By.XPath("//a[@id=\"avatar_log_button\"][contains(@class,\"green\")]")) != null)
			{
				Find.WebBrowserLog("Аватар Бодалка <FONT COLOR = green> вы победили</FONT>");
				Thread.Sleep(1000);
			}
			else
			{
				if (_driver.IsFindElement(By.XPath("//a[@id=\"avatar_log_button\"][contains(@class,\"red\")]")) == null)
				{
					continue;
				}
				IWebElement webElement = _driver.IsFindElement(By.XPath("//div[@id=\"avatar_log_name_2\"]/a[contains(@class,\"profile\")]"));
				if (webElement != null)
				{
					string text = webElement.isGetAttribute("outerText");
					Find.WebBrowserLog("Аватар Бодалка <FONT COLOR = red>вы проиграли</FONT> " + text);
					if (AppSettings.Get("checkBoxAvatarShtabBeliySpisok", defaultValue: false))
					{
						Bodalka bodalka = new Bodalka();
						bodalka.BodalkaShtab(text);
					}
				}
			}
		}
		Find.LabelStatus("Статус:");
		if (flag)
		{
			AvatarDateTime["AvatarBodalka"] = DateTime.Now.AddMinutes(45.0);
		}
		else
		{
			AvatarDateTime["AvatarBodalka"] = DateTime.Now.AddSeconds(60.0);
		}
	}

	private bool AvatarVyhod()
	{
		if (!AppSettings.Get("checkBoxOsnova", defaultValue: true))
		{
			return true;
		}
		UpdateStatus("Статус:Аватар Выход");
		if (!_driver.Url.Contains("avatar"))
		{
			UpdateStatus("Статус:");
			_Pomogashki.Resy();
			return true;
		}
		_driver.isExecuteScriptClick(By.XPath("//a[@href=\"/avatara.php?a=jump\"][contains(@class,\"portal_botva\")]"), "Аватар Выход 1");
		if (_driver.Url.Contains("avatar"))
		{
			Find.Sleep(5000);
			_driver.isExecuteScriptClick(By.XPath("//a[@href=\"/avatara.php?a=jump\"][contains(@class,\"portal_botva\")]"), "Аватар Выход 2");
		}
		if (!_driver.Url.Contains("avatar"))
		{
			UpdateStatus("Статус:");
			_Pomogashki.Resy();
			return true;
		}
		UpdateStatus("Статус:");
		return false;
	}
}
