using Botva2025.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;

namespace Botva2025;

public class Bodalka
{
	public static IWebDriver _driver;

	public Arena _arena;

	public DateTime bodalkaDatetime { get; set; }

	public DateTime bodalkaZorroDatetime { get; set; }

	public DateTime bodalkaStrashilkiDatetime { get; set; }

	public DateTime srajalkaDateTime { get; set; }

	public DateTime dozorDateTime { get; set; }

	public int error { get; set; }

	public Bodalka(IWebDriver driver)
	{
		_driver = driver;
		bodalkaDatetime = DateTime.Now;
		bodalkaZorroDatetime = DateTime.Now;
		bodalkaStrashilkiDatetime = DateTime.Now;
		srajalkaDateTime = DateTime.Now;
		dozorDateTime = DateTime.Now;
		_arena = new Arena(driver);
		error = 0;
	}

	public Bodalka()
	{
	}

	public void BodalkaMain()
	{
		try
		{
			if (_driver.Url.Contains("avatar"))
			{
				if (error > 100)
				{
					error = 0;
					_driver.isExecuteScriptClick(By.Id("m8"), "Клик Бодалка");
				}
				error++;
				Find.Sleep(1000);
				return;
			}
			error = 0;
		}
		catch
		{
		}
		try
		{
			bodalkaDatetime = BodalkaBoy();
		}
		catch
		{
			bodalkaDatetime = DateTime.Now.AddMinutes(2.0);
		}
		try
		{
			bodalkaZorroDatetime = BodalkaZorro();
		}
		catch
		{
			bodalkaZorroDatetime = DateTime.Now.AddMinutes(2.0);
		}
		try
		{
			bodalkaStrashilkiDatetime = BodalkaStrashilki();
		}
		catch
		{
			bodalkaStrashilkiDatetime = DateTime.Now.AddMinutes(2.0);
		}
		_arena.ArenaMain();
		try
		{
			srajalkaDateTime = Srajalka();
		}
		catch
		{
			srajalkaDateTime = DateTime.Now.AddMinutes(2.0);
		}
		try
		{
			dozorDateTime = Dozor();
		}
		catch
		{
			dozorDateTime = DateTime.Now.AddMinutes(2.0);
			dozorDateTime = DateTime.Now.AddMinutes(5.0);
		}
	}

	public DateTime Dozor()
	{
		if (dozorDateTime > DateTime.Now)
		{
			return dozorDateTime;
		}
		if (!AppSettings.Get("checkBoxDozor", defaultValue: false))
		{
			return dozorDateTime = DateTime.Now.AddMinutes(1.0);
		}
		Find.LabelStatus("Статус: Дозор");
		IWebElement webElement = _driver.IsFindElement(By.XPath("//div[@id=\"rmenu1\"]/div/a[@class=\"timer link\"]/span"));
		if (webElement != null)
		{
			Find.LabelStatus("Статус:");
			return dozorDateTime = DateTime.Now.AddMinutes(1.0);
		}
		if (AppSettings.Get("checkBoxDozorRaby", defaultValue: false))
		{
			webElement = _driver.IsFindElement(By.XPath("//li[@id=\"i70\"]"));
			if (webElement != null)
			{
				string[] array = webElement.GetAttribute("outerText").Split('/');
				int[] array2 = new int[2] { 1, 1 };
				if (int.TryParse(string.Join("", array[0].Where((char c) => char.IsDigit(c))), out array2[0]))
				{
					int.TryParse(string.Join("", array[1].Where((char c) => char.IsDigit(c))), out array2[1]);
				}
				if ((double)array2[0] > (double)array2[1] * 0.8)
				{
					Find.LabelStatus("Статус:");
					return dozorDateTime = DateTime.Now.AddMinutes(10.0);
				}
			}
		}
		if (!_driver.Url.Contains("botva.ru/dozor.php"))
		{
			_driver.isExecuteScriptClick(By.Id("m8"), "Клик Бодалка");
		}
		_driver.IsFindElement(By.XPath("//span[@id=\"\"]//b[@class=\"reload\"]")).IsClick("Дозор Reload");
		bool flag = false;
		if (AppSettings.Get("checkBoxDozorSbrosit", defaultValue: false))
		{
			webElement = _driver.IsFindElement(By.XPath("//div[@id=\"watch_watch_reset\"]//input[@value=\"СБРОСИТЬ\"]"));
			if (webElement != null)
			{
				if (_driver.ResyKri() > 600)
				{
					_driver.IsFindElement(By.XPath("//div[@id=\"watch_watch_reset\"]//input[@value=\"2\"]")).IsClick("Выбрать кристал");
				}
				if (webElement.IsClick("Сбросить"))
				{
					flag = true;
				}
			}
		}
		if (AppSettings.Get("checkBoxDozorAll", defaultValue: false) && _driver.IsFindElement(By.XPath("//select[@name=\"auto_watch\"]//option[last()]")).IsClick())
		{
			flag = true;
		}
		if (_driver.IsFindElement(By.XPath("//input[contains(@class,\"patrickable_watch\")]")).IsClick())
		{
			flag = true;
			Find.WebBrowserLog("Дозор");
			Thread.Sleep(500);
		}
		Find.LabelStatus("Статус:");
		if (flag)
		{
			dozorDateTime = DateTime.Now.AddSeconds(30.0);
		}
		else
		{
			dozorDateTime = DateTime.Now.AddMinutes(45.0);
		}
		DateTime dateTime4 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1, 0, 0, 30);
		if (dozorDateTime > dateTime4)
		{
			dozorDateTime = dateTime4;
		}
		return dozorDateTime;
	}

	private static string ReplaceKValues(string input)
	{
		Regex regex = new Regex("(\\d+(\\.\\d+)?)([km])", RegexOptions.IgnoreCase);
		return regex.Replace(input, delegate(Match match)
		{
			if (double.TryParse(match.Groups[1].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
			{
				string text = match.Groups[3].Value.ToLower();
				int num;
				if (!(text == "k"))
				{
					if (!(text == "m"))
					{
						return match.Value;
					}
					num = (int)(result * 1000000.0);
				}
				else
				{
					num = (int)(result * 1000.0);
				}
				return num.ToString();
			}
			return match.Value;
		});
	}

	private void SrajalkaKypitMandarinki()
	{
		IWebElement webElement = _driver.IsFindElement(By.XPath("//input[@id=\"fightplacePandarinAmountInput\"]"));
		string text = webElement.isGetAttribute("max");
		if (webElement != null && text != null)
		{
			IJavaScriptExecutor javaScriptExecutor = _driver as IJavaScriptExecutor;
			javaScriptExecutor.ExecuteScript("arguments[0].value = arguments[1];", webElement, text);
			javaScriptExecutor.ExecuteScript("arguments[0].dispatchEvent(new Event('input', { bubbles: true }));", webElement);
			javaScriptExecutor.ExecuteScript("arguments[0].dispatchEvent(new Event('change', { bubbles: true }));", webElement);
			_driver.IsFindElement(By.XPath("//div[@id=\"buyPandarinButton\"]//span")).IsClick("Клик Купить", 1000);
		}
	}

	private DateTime Srajalka()
	{
		if (srajalkaDateTime > DateTime.Now)
		{
			return srajalkaDateTime;
		}
		if (!AppSettings.Get("checkBoxSrajalka", defaultValue: false))
		{
			return srajalkaDateTime = DateTime.Now.AddSeconds(30.0);
		}
		Find.LabelStatus("Статус: Сражалка");
		IWebElement webElement = _driver.IsFindElement(By.XPath("//div[@id=\"rmenu1\"]/div/a[@class=\"timer link\"]/span"));
		if (webElement != null && !AppSettings.Get("checkBoxSnejnyGolem", defaultValue: false))
		{
			Find.LabelStatus("Статус");
			return srajalkaDateTime = DateTime.Now.AddMinutes(1.0);
		}
		if (!_driver.Url.Contains("botva.ru/dozor.php"))
		{
			_driver.isExecuteScriptClick(By.Id("m8"), "Клик Бодалка");
		}
		_driver.isExecuteScriptClick(By.XPath("//a[@href=\"fightplace.php\"][text()=\"Сражалка\"]"), "Клик Сражалка");
		_driver.isExecuteScriptClick(By.XPath("//div[@class=\"btn\"][text()=\"Сражалка\"]"), "Клик Сражалка внутри");
		SrajalkaKypitMandarinki();
		SrajalkaUluchshitStat();
		List<(string Name, long Sila, long Intellekt, long Magiya, long Summa)> list = SortirovkaSrajalkaVragi();
		if (list != null)
		{
			string text = "//a[text()=\"" + list.First().Item1 + "\"]//..//..//../div[4]";
			if (_driver.IsFindElement(By.XPath("//a[text()=\"" + list.First().Item1 + "\"]//..//..//../div[4]")).IsClick("Атаковать " + list.First().Item1, 1000))
			{
				_driver.IsFindElement(By.XPath("//a[text()=\"" + list.First().Item1 + "\"]//..//..//../div[2]")).IsClick("Атаковать " + list.First().Item1, 1000);
				_driver.IsFindElement(By.XPath("//span[text()=\"Пропустить\"]")).IsClick("Пропустить");
				text = _driver.IsFindElement(By.XPath("//div[@class=\"bold uppercase\"]")).isGetAttribute("outerText");
				Find.WebBrowserLog("Сражалка " + text);
				_driver.IsFindElement(By.XPath("//span[text()=\"НАЗАД\"]")).IsClick("НАЗАД", 1000);
			}
		}
		srajalkaDateTime = _driver.DateTimeCount("//div[@id=\"fightplace_remaining\"]");
		if (srajalkaDateTime > DateTime.Now)
		{
			Find.LabelStatus("Статус:");
			if ((srajalkaDateTime - DateTime.Now).TotalMinutes > 20.0)
			{
				return srajalkaDateTime = DateTime.Now.AddMinutes(5.0);
			}
			return srajalkaDateTime = srajalkaDateTime.AddSeconds(10.0);
		}
		Find.LabelStatus("Статус:");
		return srajalkaDateTime = DateTime.Now.AddSeconds(60.0);
	}

	private (int, int, int) SrajalkaMoiStaty()
	{
		string input = _driver.IsFindElement(By.XPath("//div[contains(@class,\"fightplace_stats\")]")).isGetAttribute("outerHTML");
		input = ReplaceKValues(input);
		Regex regex = new Regex("(?ims)>(\\d+)<.*?Сила.*?>(\\d+)<.*?Интеллект.*?>(\\d+)<.*?Магия.*?");
		MatchCollection matchCollection = regex.Matches(input);
		if (matchCollection.Count != 0)
		{
			int item = Convert.ToInt32(matchCollection[0].Groups[1].Value);
			int item2 = Convert.ToInt32(matchCollection[0].Groups[2].Value);
			int item3 = Convert.ToInt32(matchCollection[0].Groups[3].Value);
			return (item, item2, item3);
		}
		return (0, 0, 0);
	}

	private List<(string Name, long Sila, long Intellekt, long Magiya, long Summa)> SortirovkaSrajalkaVragi()
	{
		(int, int, int) tuple = SrajalkaMoiStaty();
		int mySila = tuple.Item1;
		int myIntelekt = tuple.Item2;
		int myMagik = tuple.Item3;
		string input = _driver.IsFindElement(By.XPath("//div[contains(@class,\"fightplace_enemies\")]")).isGetAttribute("outerHTML");
		input = ReplaceKValues(input);
		Regex regex = new Regex("(?ims)fightplace.php.*?profile\">(.*?)<\\/a>.*?Сила.*?>(\\d+)<.*?Интеллект.*?>(\\d+)<.*?Магия.*?>(\\d+)<.*?Побед.*?>(\\d+)<.*?\\/form");
		MatchCollection matchCollection = regex.Matches(input);
		List<(string Name, long Sila, long Intellekt, long Magiya, long Summa)> list = new List<(string Name, long Sila, long Intellekt, long Magiya, long Summa)>();
		if (matchCollection.Count != 0)
		{
			for (int i = 0; i < matchCollection.Count; i++)
			{
				string value = matchCollection[i].Groups[1].Value;
				long num = Convert.ToInt64(matchCollection[i].Groups[2].Value);
				long num2 = Convert.ToInt64(matchCollection[i].Groups[3].Value);
				long num3 = Convert.ToInt64(matchCollection[i].Groups[4].Value);
				long item = num + num2 + num3;
				list.Add((value, num, num2, num3, item));
			}
			List<(string Name, long Sila, long Intellekt, long Magiya, long Summa)> list2 = (from p in list
				where mySila > (long)(1.2 * (double)p.Sila) && myIntelekt > (long)(1.2 * (double)p.Intellekt) && myMagik > (long)(1.2 * (double)p.Magiya)
				orderby p.Summa descending
				select p).ToList();
			List<(string Name, long Sila, long Intellekt, long Magiya, long Summa)> list3 = list.OrderBy<(string Name, long Sila, long Intellekt, long Magiya, long Summa), long>(((string Name, long Sila, long Intellekt, long Magiya, long Summa) p) => p.Summa).ToList();
			if (list2 == null)
			{
				list2 = list3;
			}
			return list2;
		}
		return null;
	}

	private bool SrajalkaUluchshitStat()
	{
		Regex regex = new Regex("(?ims)Улучшить за.*?(\\d+)");
		MatchCollection matchCollection = regex.Matches(_driver.IsFindElement(By.XPath("//div[@class=\"tab\"]")).isGetAttribute("outerHTML"));
		if (matchCollection.Count != 0)
		{
			int[] array = new int[matchCollection.Count];
			long[] array2 = new long[matchCollection.Count];
			for (int i = 0; i < matchCollection.Count; i++)
			{
				array[i] = i + 1;
				array2[i] = Convert.ToInt64(matchCollection[i].Groups[1].Value);
			}
			Array.Sort(array2, array);
			string text = "//div[contains(@class,\"bgr_1\")][" + array[0] + "]";
			if (_driver.IsFindElement(By.XPath(text + "//div[contains(@class,\"max\")]")).isGetAttribute("data-max-available-level") != "0")
			{
				_driver.IsFindElement(By.XPath(text + "//div[contains(@class,\"max\")]")).IsClick("Клик Макс", 1000);
				if (_driver.IsFindElement(By.XPath(text + "/form//div[not(contains(@class,\"disabled\"))]")).IsClick("Улучшить"))
				{
					Find.WebBrowserLog("Сражалка улучшить" + array2[0]);
					return true;
				}
			}
		}
		return false;
	}

	private DateTime BodalkaStrashilki()
	{
		string text = "";
		if (bodalkaStrashilkiDatetime > DateTime.Now)
		{
			return bodalkaStrashilkiDatetime;
		}
		if (!AppSettings.Get("checkBoxBodalkaStrashilki", defaultValue: false))
		{
			return bodalkaStrashilkiDatetime = DateTime.Now.AddSeconds(10.0);
		}
		Find.LabelStatus("Статус: Страшилки");
		IWebElement webElement = _driver.IsFindElement(By.XPath("//div[@id=\"rmenu1\"]/div/a[@class=\"timer link\"]/span"));
		if (webElement != null && !AppSettings.Get("checkBoxSnejnyGolem", defaultValue: false))
		{
			Find.LabelStatus("Статус:");
			return bodalkaStrashilkiDatetime = DateTime.Now.AddMinutes(1.0);
		}
		if (!_driver.Url.Contains("botva.ru/dozor.php") || _driver.Url.Contains("a=log"))
		{
			_driver.isExecuteScriptClick(By.Id("m8"), "Клик м8 БС");
		}
		else
		{
			webElement = _driver.IsFindElement(By.XPath("//tr[2]/td[2]//div[@class=\"watch_no_monster\"]/..//span[@timer]"));
			if (webElement != null && webElement.Text == "00:00:00")
			{
				_driver.isExecuteScriptClick(By.Id("m8"), "Клик м8 БС");
			}
		}
		webElement = _driver.IsFindElement(By.XPath("//tr[2]/td[2]//div[@class=\"watch_no_monster\"]/..//span[@timer]"));
		if (webElement != null && webElement.Text != "00:00:00")
		{
			text = webElement.Text;
			DateTime dateTime3 = DateTime.ParseExact(webElement.Text, "HH:mm:ss", null);
			bodalkaStrashilkiDatetime = DateTime.Now.AddSeconds(dateTime3.Second + 2);
			bodalkaStrashilkiDatetime = bodalkaStrashilkiDatetime.AddMinutes(dateTime3.Minute);
			bodalkaStrashilkiDatetime = bodalkaStrashilkiDatetime.AddHours(dateTime3.Hour);
			Find.LabelStatus("Статус:");
			return bodalkaStrashilkiDatetime;
		}
		if (_driver.ResyKri() > 10)
		{
			if (_driver.IsFindElement(By.XPath("//tr[2]/td[2]//div[@class=\"watch_attack_level\"]//input")).IsClick("Бодалка Страшилки Атака"))
			{
				LogService.LogHtml("Атака Страшилка");
			}
		}
		else if (_driver.IsFindElement(By.XPath("//input[@value=\"ИСКАТЬ СТРАШИЛКУ\"]")).IsClick("Бодалка Страшилки Атака золото"))
		{
			LogService.LogHtml("Атака Страшилка золото");
		}
		Find.LabelStatus("Статус:");
		return bodalkaStrashilkiDatetime = DateTime.Now.AddMinutes(2.0);
	}

	public DateTime BodalkaZorro()
	{
		string text = "";
		if (bodalkaZorroDatetime > DateTime.Now)
		{
			return bodalkaZorroDatetime;
		}
		if (!AppSettings.Get("checkBoxBodalkaZorro", defaultValue: false))
		{
			return DateTime.Now.AddSeconds(10.0);
		}
		Find.LabelStatus("Статус:Зорро");
		IWebElement webElement = _driver.IsFindElement(By.XPath("//div[@id=\"rmenu1\"]/div/a[@class=\"timer link\"]/span"));
		if (webElement != null && !AppSettings.Get("checkBoxSnejnyGolem", defaultValue: false))
		{
			Find.LabelStatus("Статус:");
			return bodalkaZorroDatetime = DateTime.Now.AddMinutes(1.0);
		}
		webElement = _driver.IsFindElement(By.XPath("//div[@id=\"rmenu1\"]/div/a[@class=\"timer attack\"]/span"));
		if (webElement != null && !webElement.Text.Contains("00:00:00"))
		{
			Find.LabelStatus("Статус:");
			return bodalkaZorroDatetime = DateTimeRmenu(webElement);
		}
		if (!_driver.Url.Contains("botva.ru/dozor.php") || _driver.Url.Contains("a=log"))
		{
			_driver.isExecuteScriptClick(By.Id("m8"), "Клик м8 Зорро");
		}
		webElement = _driver.IsFindElement(By.XPath("//tr[2]/td[1]//div[@class=\"watch_no_attack\"]/..//span[@timer]"));
		if (webElement != null && webElement.Text != "00:00:00")
		{
			Find.LabelStatus("Статус:");
			return bodalkaZorroDatetime = DateTimeRmenu(webElement);
		}
		_driver.IsFindElement(By.XPath("//tr[2]//div[@class=\"watch_attack_type\"]//input")).IsClick("Зоро атака по силе");
		_driver.IsFindElement(By.XPath("//tr[2]//div[@class=\"watch_attack_level\"]//input[@value=\"ПОИСК\"]")).IsClick("Зоро Атака по уровню");
		webElement = _driver.IsFindElement(By.Id("balert_wrap"));
		if (webElement != null)
		{
			if (webElement.Text.Contains("Оба-на, никого нэма"))
			{
				LogService.LogHtml("ЗОРРО никого нима");
				bodalkaZorroDatetime = DateTime.Now.AddSeconds(120.0);
				Find.LabelStatus("Статус:");
				return bodalkaZorroDatetime;
			}
			if (webElement.Text.Contains("На вас наложен заговор"))
			{
				Find.WebBrowserLog("ЗОРРО Заговор");
				Find.LabelStatus("Статус:");
				return bodalkaZorroDatetime = DateTime.Now.AddSeconds(420.0);
			}
		}
		webElement = _driver.IsFindElement(By.XPath("//div[@class=\"bar_green_solid center corner3 mb5\"]/span"));
		if (webElement != null)
		{
			LogService.LogHtml("Зорро <FONT COLOR = green>вы победили</FONT>");
		}
		webElement = _driver.IsFindElement(By.XPath("//div[@class=\"bar_red_solid center corner3 mb5\"]/span"));
		if (webElement != null)
		{
			text = webElement.Text;
			LogService.LogHtml("ЗОРРО <FONT COLOR = red>вы проиграли</FONT>");
			if (AppSettings.Get("checkBoxBodalkaShtab", defaultValue: false))
			{
				BodalkaShtab(text);
			}
		}
		int[] array = new int[8] { 10, 30, 60, 120, 300, 600, 1200, 1800 };
		UpdateStatus("Статус:");
		return bodalkaZorroDatetime = DateTime.Now.AddSeconds(array[AppSettings.Get("comboBoxBodalkaTime", 0)]);
	}

	private DateTime DateTimeRmenu(IWebElement _el)
	{
		DateTime.TryParseExact(_el.Text, "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result);
		return DateTime.Now.AddSeconds(result.Second + 2).AddMinutes(result.Minute).AddHours(result.Hour);
	}

	public DateTime BodalkaBoy()
	{
		string text = "";
		if (bodalkaDatetime > DateTime.Now)
		{
			return bodalkaDatetime;
		}
		if (!AppSettings.Get("checkBoxBodalka", defaultValue: false))
		{
			return DateTime.Now.AddSeconds(10.0);
		}
		Find.LabelStatus("Статус: Бодалка");
		IWebElement webElement = _driver.IsFindElement(By.XPath("//div[@id=\"rmenu1\"]/div/a[@class=\"timer link\"]/span"));
		if (webElement != null && !AppSettings.Get("checkBoxSnejnyGolem", defaultValue: false))
		{
			Find.LabelStatus("Статус:");
			return bodalkaDatetime = DateTime.Now.AddMinutes(1.0);
		}
		webElement = _driver.IsFindElement(By.XPath("//div[@id=\"rmenu1\"]/div/a[@class=\"timer attack\"]/span"));
		if (webElement != null && webElement.Text != "00:00:00")
		{
			Find.LabelStatus("Статус:");
			return DateTimeRmenu(webElement);
		}
		if (!_driver.Url.Contains("botva.ru/dozor.php") || _driver.Url.Contains("a=log"))
		{
			IWebElement webElement2 = _driver.IsFindElement(By.Id("m8"));
			if (webElement2 != null)
			{
				IJavaScriptExecutor javaScriptExecutor = _driver as IJavaScriptExecutor;
				javaScriptExecutor.ExecuteScript("arguments[0].click();", webElement2);
			}
		}
		if (_driver.ResyZoloto() > 1000L)
		{
			_driver.IsFindElement(By.XPath("//div[2]/div/input[@value=\"КУПИТЬ\"][not(contains(@class,\"hidden\"))]")).IsClick("Купить бутылку 2");
			_driver.IsFindElement(By.XPath("//div[1]/div/input[@value=\"КУПИТЬ\"][not(contains(@class,\"hidden\"))]")).IsClick("Купить бутылку 1");
		}
		if (_driver.ResyKri() > 100)
		{
			_driver.IsFindElement(By.XPath("//div[3]/div/input[@value=\"КУПИТЬ\"][not(contains(@class,\"hidden\"))]")).IsClick("Купить бутылку 2");
		}
		webElement = _driver.IsFindElement(By.XPath("//div[3]/div/input[@value=\"ВЫПИТЬ\"][not(contains(@class,\"hidden\"))]"));
		if (webElement != null)
		{
			LogService.LogHtml("Выпить будылку 3");
			webElement.IsClick("Выпить 3");
		}
		else
		{
			webElement = _driver.IsFindElement(By.XPath("//div[2]/div/input[@value=\"ВЫПИТЬ\"][not(contains(@class,\"hidden\"))]"));
			if (webElement != null)
			{
				LogService.LogHtml("Выпить бутылку 2");
				webElement.IsClick("Выпить 2");
			}
			else
			{
				webElement = _driver.IsFindElement(By.XPath("//div[1]/div/input[@value=\"ВЫПИТЬ\"][not(contains(@class,\"hidden\"))]"));
				if (webElement != null)
				{
					LogService.LogHtml("Выпить бутылку 1");
					webElement.IsClick("Выпить 1");
				}
			}
		}
		webElement = _driver.IsFindElement(By.XPath("//tr[1]/td[1]//div[@class=\"watch_no_attack\"]/..//span[@timer]"));
		if (webElement != null && webElement.Text != "00:00:00")
		{
			Find.LabelStatus("Статус:");
			return DateTimeRmenu(webElement);
		}
		_driver.IsFindElement(By.XPath("//input[@id=\"watch_find\"]")).IsClick("Атака по силе");
		_driver.IsFindElement(By.XPath("//div[@class=\"watch_attack_level\"]//input[@value=\"ПОИСК\"]")).IsClick("Атака по уровню");
		webElement = _driver.IsFindElement(By.Id("balert_wrap"));
		if (webElement != null)
		{
			Find.WebBrowserLog("Бодалка никого нима");
			if (webElement.Text.Contains("Оба-на, никого нэма"))
			{
				Find.LabelStatus("Статус:");
				return DateTime.Now.AddSeconds(120.0);
			}
			if (webElement.Text.Contains("На вас наложен заговор"))
			{
				Find.LabelStatus("Статус:");
				return DateTime.Now.AddSeconds(300.0);
			}
		}
		webElement = _driver.IsFindElement(By.XPath("//div[@class=\"bar_green_solid center corner3 mb5\"]/span"));
		if (webElement != null)
		{
			text = webElement.Text;
			Find.WebBrowserLog("Бодалка <FONT COLOR = green>вы победили</FONT>");
		}
		webElement = _driver.IsFindElement(By.XPath("//div[@class=\"bar_red_solid center corner3 mb5\"]/span"));
		if (webElement != null)
		{
			Find.WebBrowserLog("Бодалка <FONT COLOR = red>вы проиграли</FONT>");
			text = webElement.Text;
			if (AppSettings.Get("checkBoxBodalkaShtab", defaultValue: false))
			{
				BodalkaShtab(text);
			}
		}
		int[] array = new int[8] { 10, 30, 60, 120, 300, 600, 1200, 1800 };
		UpdateStatus("Статус:");
		return DateTime.Now.AddSeconds(array[AppSettings.Get("comboBoxBodalkaTime", 0)]);
	}

	private void UpdateStatus(string v)
	{
		Find.LabelStatus(v);
	}

	public void BodalkaShtab(string st)
	{
		if (!(st == "Чёртус") && !(st == "Чертиха"))
		{
			_driver.isExecuteScriptClick(By.Id("m9"), "Клик Штаб");
			_driver.IsFindElement(By.XPath("//a[@href=\"shtab.php?m=notes\"]")).IsClick();
			_driver.IsFindElement(By.Name("username")).IsSendKeys(st);
			_driver.IsFindElement(By.XPath("//select[@name=\"group\"]/option[@value=\"4\"]")).IsClick("Белый список");
			_driver.IsFindElement(By.XPath("//table[@class=\"normal_table w100p\"]//input[@value=\"СОХРАНИТЬ\"]")).IsClick("Сохранить");
			Find.WebBrowserLog("Штаб добавлен " + st);
		}
	}
}
