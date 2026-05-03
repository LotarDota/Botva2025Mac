using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Botva2025.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Botva2025;

public class Shashta
{
	private IWebDriver _driver;

	private WebDriverWait wait;

	private ulong pandoraCena;

	public DateTime polynaBolshaiDateTime { get; set; }

	public DateTime polynaMalenkaiDateTime { get; set; }

	private DateTime shashtaPodzemDateTime { get; set; }

	private DateTime pandoraDateTime { get; set; }

	public DateTime kareraDateTime { get; set; }

	public DateTime podzemkyeZalyDateTime { get; set; }

	public DateTime podzemkyeDobychaKriDateTime { get; set; }

	public DateTime radyjniySundykDateTime { get; set; }

	public Shashta(IWebDriver driver)
	{
		_driver = driver;
		polynaBolshaiDateTime = DateTime.Now;
		polynaMalenkaiDateTime = DateTime.Now;
		shashtaPodzemDateTime = DateTime.Now;
		pandoraDateTime = DateTime.Now;
		kareraDateTime = DateTime.Now;
		podzemkyeZalyDateTime = DateTime.Now;
		podzemkyeDobychaKriDateTime = DateTime.Now;
		radyjniySundykDateTime = DateTime.Now;
		wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5L));
	}

	public List<(string displayName, List<(string settingName, string tooltip)>)> ShashtaNastroyki(string server)
	{
		List<(string, List<(string, string)>)> list = new List<(string, List<(string, string)>)>();
		list.Add(("Спуск из шахты", new List<(string, string)>
		{
			("checkBoxPodzemTaymer_00", "00"),
			("checkBoxPodzemTaymer_05", "05"),
			("checkBoxPodzemTaymer_10", "10"),
			("checkBoxPodzemTaymer_15", "15"),
			("checkBoxPodzemTaymer_20", "20"),
			("checkBoxPodzemTaymer_25", "25"),
			("checkBoxPodzemTaymer_30", "30"),
			("checkBoxPodzemTaymer_35", "35"),
			("checkBoxPodzemTaymer_40", "40"),
			("checkBoxPodzemTaymer_45", "45"),
			("checkBoxPodzemTaymer_50", "50"),
			("checkBoxPodzemTaymer_55", "55")
		}));
		list.Add(("Начать атаки (-2мин +3мин)", new List<(string, string)>
		{
			("checkBoxPodzemTaymer_00_Go", "00"),
			("checkBoxPodzemTaymer_05_Go", "05"),
			("checkBoxPodzemTaymer_10_Go", "10"),
			("checkBoxPodzemTaymer_15_Go", "15"),
			("checkBoxPodzemTaymer_20_Go", "20"),
			("checkBoxPodzemTaymer_25_Go", "25"),
			("checkBoxPodzemTaymer_30_Go", "30"),
			("checkBoxPodzemTaymer_35_Go", "35"),
			("checkBoxPodzemTaymer_40_Go", "40"),
			("checkBoxPodzemTaymer_45_Go", "45"),
			("checkBoxPodzemTaymer_50_Go", "50"),
			("checkBoxPodzemTaymer_55_Go", "55")
		}));
		return list;
	}

	public void ShashtaMain()
	{
		try
		{
			if (_driver.Url.Contains("avatar"))
			{
				return;
			}
		}
		catch
		{
		}
		try
		{
			polynaBolshaiDateTime = PolynaBolshay();
		}
		catch
		{
			polynaBolshaiDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			polynaMalenkaiDateTime = PolynaMalenkai();
		}
		catch
		{
			polynaMalenkaiDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			pandoraDateTime = PandoraMain();
		}
		catch
		{
		}
		try
		{
			radyjniySundykDateTime = RadyjniySundyk();
		}
		catch
		{
		}
		try
		{
			kareraDateTime = ShashtaKarera();
		}
		catch
		{
		}
		try
		{
			podzemkyeZalyDateTime = PodzemkyeZaly();
		}
		catch
		{
		}
		try
		{
			shashtaPodzemDateTime = ShashtaPodzem();
		}
		catch
		{
		}
		try
		{
			podzemkyeDobychaKriDateTime = ShashtaDobychaKri();
		}
		catch
		{
		}
	}

	public DateTime RadyjniySundyk()
	{
		if (radyjniySundykDateTime > DateTime.Now)
		{
			return radyjniySundykDateTime;
		}
		if (!AppSettings.Get("checkBoxRadyjniySundyk", defaultValue: false))
		{
			return DateTime.Now.AddMinutes(1.0);
		}
		string[,] array = new string[3, 2]
		{
			{ "i44", "Золотой сундук" },
			{ "i46", "Серебряный сундук" },
			{ "i42", "Бронзовый сундук" }
		};
		int result = 0;
		int[] array2 = new int[3];
		WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2L));
		webDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
		UpdateStatus("Статус: Радужный сундук");
		for (int i = 0; i < array.GetLength(0); i++)
		{
			if (!int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//li[@id=\"" + array[i, 0] + "\"]")).isGetAttribute("outerText")
				where char.IsDigit(c)
				select c), out array2[i]))
			{
				LogService.LogHtml("<FONT COLOR = red>Не вижу " + array[i, 1] + "с права</FONT>");
				UpdateStatus("Статус:");
				return DateTime.Now.AddMinutes(5.0);
			}
			result += array2[i];
		}
		if (result < 6)
		{
			UpdateStatus("Статус:");
			return DateTime.Now.AddMinutes(5.0);
		}
		if (!_driver.isExecuteScriptClick(By.XPath("//div[@class=\"guilds show_guilds\"]//a[3]"), "Клик Гильдия"))
		{
			LogService.LogHtml("<FONT COLOR = red>Не вижу Гильдию</FONT>");
			UpdateStatus("Статус:");
			return DateTime.Now.AddMinutes(5.0);
		}
		webDriverWait.TryUntil(ExpectedConditions.ElementExists(By.XPath("//div[contains(text(),\"Радужные сундучки\")]")));
		_driver.IsFindElement(By.XPath("//a[contains(text(),\"ИСПОЛЬЗОВАТЬ ВСЕ\")]")).IsClick("Использовать Все");
		int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//a[contains(text(),\"ВЗЛОМАТЬ ВСЁ\")]")).isGetAttribute("outerText")
			where char.IsDigit(c)
			select c), out result);
		if (result > _driver.ResyPiraShki())
		{
			UpdateStatus("Статус:");
			return DateTime.Now.AddMinutes(30.0);
		}
		_driver.IsFindElement(By.XPath("//a[contains(text(),\"ВЗЛОМАТЬ ВСЁ\")]")).IsClick("Взломать Все");
		_driver.isExecuteScriptClick(By.XPath("//a[contains(@href,\"pandora=\") and contains(text(),\"Открыть\")]"), "Открыть");
		webDriverWait.TryUntil(ExpectedConditions.ElementExists(By.XPath("//div[contains(text(),\"РАДУЖНЫЙ СУНДУЧОК\")]")));
		for (int num = 0; num < 9; num++)
		{
			_driver.IsFindElement(By.XPath("//input[@value=\"ОТКРЫТЬ\"]")).IsClick("Открыть");
			_driver.IsFindElement(By.XPath("//a[contains(text(),\"ЕЩЕ ОДИН\")]")).IsClick("ЕЩЕ ОДИН");
		}
		UpdateStatus("Статус:");
		return DateTime.Now.AddMinutes(10.0);
	}

	public DateTime ShashtaDobychaKri()
	{
		if (podzemkyeDobychaKriDateTime > DateTime.Now)
		{
			return podzemkyeDobychaKriDateTime;
		}
		if (!AppSettings.Get("checkBoxDobychaKri", defaultValue: false))
		{
			return DateTime.Now.AddMinutes(1.0);
		}
		bool flag = false;
		UpdateStatus("Статус: Добыча кристаллов");
		if (_driver.TimerRabota(out var dateTime))
		{
			if (!_driver.IsFindElement(By.XPath("//div[@id=\"rmenu1\"]/div[@class=\"timers\"]")).isGetAttribute("innerText").Contains("Работа в карьере"))
			{
				UpdateStatus("Статус:");
				return podzemkyeDobychaKriDateTime = DateTime.Now.AddSeconds(30.0);
			}
			if ((dateTime - DateTime.Now).TotalSeconds > 2.0)
			{
				UpdateStatus("Статус:");
				return podzemkyeDobychaKriDateTime = dateTime.AddSeconds(3.0);
			}
		}
		if (!_driver.Url.Contains("mine.php?a=open") && _driver.IsFindElement(By.XPath("//div[@class=\"timers\"]/a[contains(@href,\"mine.php?a=open\")]")).IsClick("Добыть через таймер"))
		{
			Thread.Sleep(1000);
		}
		if (!_driver.Url.Contains("botva.ru/mine.php") && !_driver.Url.Contains("mine.php?a=open"))
		{
			_driver.isExecuteScriptClick(By.Id("m6"), "Клик Шахта");
		}
		if (!_driver.Url.Contains("mine.php?a=open") && _driver.IsFindElement(By.XPath("//a[@href=\"mine.php?a=open\"]")).IsClick("Смотреть"))
		{
			Thread.Sleep(1000);
		}
		if (_driver.IsFindElement(By.XPath("//input[@type=\"submit\" and @value=\"РАБОТАТЬ\"]")).IsClick("Работать"))
		{
			flag = true;
			Thread.Sleep(1000);
		}
		for (int i = 0; i < 2; i++)
		{
			if (_driver.IsFindElement(By.XPath("//a[contains(@href,\"mine.php\") and contains(@href,\"m=dig\") and text()=\"ДОБЫТЬ\"]")).IsClick("Добыть"))
			{
				flag = true;
				Thread.Sleep(2000);
			}
		}
		UpdateStatus("Статус:");
		if (_driver.TimerRabota(out dateTime) && dateTime != DateTime.Now)
		{
			return podzemkyeDobychaKriDateTime = dateTime.AddSeconds(3.0);
		}
		if (flag)
		{
			return DateTime.Now.AddSeconds(30.0);
		}
		return DateTime.Now.AddMinutes(30.0);
	}

	public DateTime PodzemkyeZaly()
	{
		if (!AppSettings.Get("checkBoxPodzemkyeZaly", defaultValue: false))
		{
			return DateTime.Now.AddMinutes(1.0);
		}
		if (podzemkyeZalyDateTime > DateTime.Now)
		{
			return podzemkyeZalyDateTime;
		}
		UpdateStatus("Статус: Подземные залы!");
		if (_driver.TimerRabota(out var _))
		{
			UpdateStatus("Статус:");
			return podzemkyeZalyDateTime = DateTime.Now.AddMinutes(1.0);
		}
		int result = 0;
		if (!int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//li[@id=\"i173\"]")).isGetAttribute("outerText")
			where char.IsDigit(c)
			select c), out result))
		{
			(Application.OpenForms[0] as Form1).webBrowserLog.LogThread("НЕ вижу ключей Разрывателя");
			UpdateStatus("Статус:");
			return podzemkyeZalyDateTime = DateTime.Now.AddMinutes(5.0);
		}
		if (result < 2)
		{
			UpdateStatus("Статус:");
			return podzemkyeZalyDateTime = DateTime.Now.AddMinutes(5.0);
		}
		if (_driver.IsFindElement(By.XPath("//div[@id=\"event_100\"]")) == null)
		{
			UpdateStatus("Статус:");
			return podzemkyeZalyDateTime = DateTime.Now.AddMinutes(5.0);
		}
		if (_driver.isExecuteScriptClick(By.XPath("//li[@id=\"i173\"]/a"), "Подземные залы"))
		{
			Thread.Sleep(1000);
		}
		if (_driver.IsFindElement(By.XPath("//input[@value=\"ОТКРЫТЬ\"]")).IsClick("ОТКРЫТЬ"))
		{
			Thread.Sleep(1000);
		}
		if (_driver.IsFindElement(By.XPath("//b[contains(@class,'item_1298')]/../..//span[contains(text(),'ОТПРАВИТЬ')]")).IsClick("ОТПРАВИТЬ В НЕДРА"))
		{
			Thread.Sleep(1000);
			if (_driver.isExecuteScriptClick(By.XPath("//div[@id='l_popup']//label[contains(@class,'drillhall_program_3')]//div[@class='border']"), "Выбрать Артифакт"))
			{
				Thread.Sleep(1000);
				if (_driver.isExecuteScriptClick(By.XPath("//span[contains(text(),'ОТПРАВИТЬ') and @id='button1_2']"), "ОТПРАВИТЬ Артифакт"))
				{
					Thread.Sleep(1000);
				}
			}
		}
		UpdateStatus("Статус:");
		return podzemkyeZalyDateTime = DateTime.Now.AddMinutes(5.0);
	}

	private void UpdateStatus(string v)
	{
		Find.LabelStatus(v);
	}

	public void PandoraDateTime()
	{
		pandoraDateTime = DateTime.Now;
	}

	public DateTime ShashtaKarera()
	{
		if (!AppSettings.Get("checkBoxKarera", defaultValue: false))
		{
			return DateTime.Now.AddMinutes(1.0);
		}
		if (kareraDateTime > DateTime.Now)
		{
			return kareraDateTime;
		}
		ulong num = _driver.ResyKri();
		if (num < 10000)
		{
			return kareraDateTime = DateTime.Now.AddMinutes(5.0);
		}
		Find.LabelStatus("Статус: Карьера!");
		_driver.IsFindElement(By.XPath("//a[contains(@class,\" guild_11 \")]")).IsClick("Устрашатели", 1000);
		_driver.IsFindElement(By.XPath("//a[text()=\"Воинская карьера\"][@class=\"btn\"]")).IsClick("Воинская карьера", 1000);
		ReadOnlyCollection<IWebElement> readOnlyCollection = _driver.FindElements(By.XPath("//div[@id='rank_container']/div[contains(@class,'rank_block')][not(contains(@class,'timer'))][not(contains(@class,'locked'))]"));
		Console.WriteLine("Карьера Elements " + readOnlyCollection.Count);
		for (int i = 1; i < 4; i++)
		{
			IWebElement webElement = _driver.IsFindElement(By.XPath("//div[@id='rank_container']/div[contains(@class,'rank_block')][" + i + "]"));
			if (webElement == null)
			{
				continue;
			}
			string attribute = webElement.GetAttribute("outerHTML");
			if (attribute.Contains(" timer") || attribute.Contains(" locked"))
			{
				continue;
			}
			Regex regex = new Regex("(?ims) active.*?data-skill=.(\\d+)..*?>(\\d+)\\/100");
			MatchCollection matchCollection = regex.Matches(attribute);
			int num2 = 0;
			if (matchCollection.Count != 0)
			{
				int[] array = new int[matchCollection.Count];
				int[] array2 = new int[matchCollection.Count];
				Console.WriteLine(array.Length + " " + array2.Length);
				for (int j = 0; j < matchCollection.Count; j++)
				{
					array[j] = Convert.ToInt16(matchCollection[j].Groups[1].Value);
					array2[j] = Convert.ToInt16(matchCollection[j].Groups[2].Value);
				}
				Array.Sort(array2, array);
				for (int num3 = array2.Length - 1; num3 > -1; num3--)
				{
					if (num > 200000 && array2[num3] != 100)
					{
						num2 = array[num3];
						break;
					}
					if (array2[num3] < 99)
					{
						num2 = array[num3];
						break;
					}
				}
			}
			else
			{
				Console.WriteLine("Карьера matchedAuthors1.Count == 0");
			}
			if (num2 != 0)
			{
				Console.WriteLine(num2);
				if (_driver.isExecuteScriptClick(By.XPath("//div[@data-skill=\"" + num2 + "\"]/span[text()=\"ИЗУЧИТЬ\"]"), "Изучить"))
				{
					Thread.Sleep(1000);
				}
				if (_driver.IsFindElement(By.XPath("//div[@data-skill=\"" + num2 + "\"][@data-tab=\"1\"]")).IsClick("Кристал"))
				{
					Thread.Sleep(500);
				}
				if (num > 100000)
				{
					_driver.IsFindElement(By.XPath("//div[@class=\"tab tab_1 skill_" + num2 + "\"]//span[contains(text(),\"Тренер\")]/input[@type=\"submit\"]")).IsClick("Тренер", 1000);
				}
				else
				{
					_driver.IsFindElement(By.XPath("//div[@class=\"tab tab_1 skill_" + num2 + "\"]//span[contains(text(),\"Самоучитель\")]//input[@type=\"submit\"]")).IsClick("Самоучитель", 1000);
				}
			}
			else
			{
				Console.WriteLine("dataSkill " + num2);
			}
		}
		kareraDateTime = DateTime.MinValue;
		ReadOnlyCollection<IWebElement> readOnlyCollection2 = _driver.FindElements(By.XPath("//div[@id=\"rank_container\"]//span[contains(@class,\"js_timer\")]"));
		foreach (IWebElement item in readOnlyCollection2)
		{
			string attribute2 = item.GetAttribute("outerText");
			if (DateTime.TryParseExact(attribute2, "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result))
			{
				DateTime dateTime2 = DateTime.Now.AddHours(result.Hour).AddMinutes(result.Minute + 2).AddSeconds(result.Second);
				if (kareraDateTime == DateTime.MinValue || dateTime2 < kareraDateTime)
				{
					kareraDateTime = dateTime2;
				}
				Console.WriteLine("Найден таймер: " + dateTime2);
			}
		}
		if (kareraDateTime != DateTime.MinValue)
		{
			Console.WriteLine("Минимальный таймер карьеры: " + kareraDateTime);
			Find.LabelStatus("Статус:");
			return kareraDateTime;
		}
		Console.WriteLine("Таймеры не найдены");
		Find.LabelStatus("Статус:");
		return kareraDateTime = DateTime.Now.AddMinutes(30.0);
	}

	private DateTime PandoraMain()
	{
		if (pandoraDateTime > DateTime.Now)
		{
			return pandoraDateTime;
		}
		if (_driver.ResyKri() < pandoraCena)
		{
			return DateTime.Now.AddMinutes(5.0);
		}
		_driver.OtkrytZolotayPanda();
		Find.LabelStatus("Статус: Панды");
		if (AppSettings.Get("checkBoxPandaIspolzovatVse", defaultValue: false))
		{
			IWebElement webElement = _driver.IsFindElement(By.XPath("//li[@id=\"i36\"]"));
			if (webElement != null)
			{
				string[] array = webElement.GetAttribute("outerText").Split('/');
				int[] array2 = new int[2] { 1, 1 };
				ulong result = 0uL;
				if (int.TryParse(string.Join("", array[0].Where((char c) => char.IsDigit(c))), out array2[0]))
				{
					int.TryParse(string.Join("", array[1].Where((char c) => char.IsDigit(c))), out array2[1]);
				}
				if (array2[0] * 100 > array2[1] * 45)
				{
					_driver.isExecuteScriptClick(By.XPath("//li[@id=\"i36\"]//a"), "Переход в панды");
					_driver.IsFindElement(By.XPath("//a[contains(text(),\"ИСПОЛЬЗОВАТЬ ВСЕ\")]")).IsClick("Использовать все");
					if (ulong.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//a[contains(text(),\"ВЗЛОМАТЬ В\")]")).isGetAttribute("outerText")
						where char.IsDigit(c)
						select c), out result))
					{
						if (_driver.ResyKri() > result)
						{
							_driver.IsFindElement(By.XPath("//a[contains(text(),\"ВЗЛОМАТЬ В\")]")).IsClick("Взломать все");
							pandoraCena = 0uL;
						}
						else
						{
							pandoraCena = result;
						}
					}
					if (AppSettings.Get("checkBoxPandaOtkryt", defaultValue: false))
					{
						_driver.IsFindElement(By.XPath("//a[contains(text(),\"МАССОВОЕ ОТКРЫТИЕ\")]")).IsClick("Массовое открытие");
						if (ulong.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//a[contains(text(),\"БЕЗ НЕГАТИВНЫХ\")]")).isGetAttribute("outerText")
							where char.IsDigit(c)
							select c), out result))
						{
							if (_driver.ResyKri() > result)
							{
								_driver.IsFindElement(By.XPath("//a[contains(text(),\"БЕЗ НЕГАТИВНЫХ\")]")).IsClick("Без негативных");
								pandoraCena = 0uL;
							}
							else
							{
								pandoraCena = result;
							}
						}
					}
					AppSettings.Get("checkBoxPandaProdat", defaultValue: false);
				}
			}
		}
		Find.LabelStatus("Статус:");
		return DateTime.Now.AddMinutes(15.0);
	}

	public void ShashtaPodzemDateTime()
	{
		shashtaPodzemDateTime = DateTime.Now;
	}

	public DateTime PolynaBolshay()
	{
		if (polynaBolshaiDateTime > DateTime.Now)
		{
			return polynaBolshaiDateTime;
		}
		if (!AppSettings.Get("checkBoxBolshay", defaultValue: false))
		{
			return polynaBolshaiDateTime = DateTime.Now.AddMinutes(3.0);
		}
		UpdateStatus("Статус: Большая поляна");
		if (_driver.TimerRabota(out var _) && !_driver.IsFindElement(By.XPath("//div[@class=\"timers\"]")).isGetAttribute("outerText").Contains("Открытие поляны"))
		{
			UpdateStatus("Статус:");
			return polynaBolshaiDateTime = DateTime.Now.AddMinutes(1.0);
		}
		string[] array = _driver.IsFindElement(By.XPath("//li[@id=\"i34\"]")).isGetAttribute("outerText").Split('/');
		int[] array2 = new int[2];
		for (int i = 0; i < array.Length; i++)
		{
			int.TryParse(string.Join("", array[i].Where((char c) => char.IsDigit(c))), out array2[i]);
		}
		if (array2[0] * 100 > array2[1] * 45)
		{
			UpdateStatus("Статус:Поляна Большая");
			_driver.isExecuteScriptClick(By.Id("m6"), "Клик Шахта");
			_driver.IsFindElement(By.XPath("//a[contains(text(),\"БОЛЬШАЯ\")]")).IsClick("Большая");
			PolynaClick("Поляна Большая");
		}
		for (int num = 0; num < 2; num++)
		{
			_driver.IsFindElement(By.XPath("//a[contains(text(),\"ВСЛЕПУЮ\")]")).IsClick("ВСЛЕПУЮ", 1000);
			_driver.IsFindElement(By.XPath("//div[@class=\"timers\"]//a[@href=\"mine.php?a=mine\"]")).IsClick("БилетСправа", 1000);
		}
		UpdateStatus("Статус:");
		return polynaBolshaiDateTime = DateTime.Now.AddMinutes(5.0);
	}

	private bool ClickBlindButton()
	{
		if (_driver.IsFindElement(By.XPath("//a[contains(text(),\"ВСЛЕПУЮ\")]")).IsClick("ВСЛЕПУЮ"))
		{
			_driver.WaitFind(By.XPath("//a[contains(text(),\"ПОПРОБОВАТЬ ЕЩЁ\")]"), TimeSpan.FromSeconds(5L));
			return true;
		}
		return false;
	}

	private bool ClickTryAgainButton()
	{
		if (_driver.IsFindElement(By.XPath("//a[contains(text(),\"ПОПРОБОВАТЬ ЕЩЁ\")]")).IsClick("ПОПРОБОВАТЬ ЕЩЁ"))
		{
			_driver.WaitFind(By.XPath("//a[contains(text(),\"ВСЛЕПУЮ\")]"), TimeSpan.FromSeconds(5L));
			return true;
		}
		return false;
	}

	private void PolynaClick(string st)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int result = 0;
		for (int i = 0; i < 2; i++)
		{
			num++;
			if (num2 <= 5)
			{
				if (ClickBlindButton())
				{
					i = 0;
				}
				if (ClickTryAgainButton())
				{
					i = 0;
				}
				UpdateStatus("Статус:" + st + " " + num);
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

	public DateTime PolynaMalenkai()
	{
		if (polynaMalenkaiDateTime > DateTime.Now)
		{
			return polynaMalenkaiDateTime;
		}
		if (!AppSettings.Get("checkBoxMalinkay", defaultValue: false))
		{
			return polynaMalenkaiDateTime = DateTime.Now.AddMinutes(3.0);
		}
		UpdateStatus("Статус: МАЛЕНЬКАЯ поляна");
		if (_driver.TimerRabota(out var _) && !_driver.IsFindElement(By.XPath("//div[@class=\"timers\"]")).isGetAttribute("outerText").Contains("Открытие поляны"))
		{
			UpdateStatus("Статус: ");
			return polynaMalenkaiDateTime = DateTime.Now.AddMinutes(1.0);
		}
		string[] array = _driver.IsFindElement(By.XPath("//li[@id=\"i33\"]")).isGetAttribute("outerText").Split('/');
		int[] array2 = new int[2];
		for (int i = 0; i < array.Length; i++)
		{
			int.TryParse(string.Join("", array[i].Where((char c) => char.IsDigit(c))), out array2[i]);
		}
		if ((double)array2[0] > (double)array2[1] * 0.75)
		{
			UpdateStatus("Статус:Поляна Маленькая");
			_driver.isExecuteScriptClick(By.Id("m6"), "Клик Шахта");
			_driver.IsFindElement(By.XPath("//a[contains(text(),\"МАЛЕНЬКАЯ\")]")).IsClick("Маленькая");
			PolynaClick("Поляна Маленькая");
		}
		for (int num = 0; num < 2; num++)
		{
			_driver.IsFindElement(By.XPath("//a[contains(text(),\"ВСЛЕПУЮ\")]")).IsClick("ВСЛЕПУЮ", 1000);
			_driver.IsFindElement(By.XPath("//div[@class=\"timers\"]//a[@href=\"mine.php?a=mine\"]")).IsClick("БилетСправа", 1000);
		}
		UpdateStatus("Статус: ");
		return polynaMalenkaiDateTime = DateTime.Now.AddMinutes(5.0);
	}

	public DateTime ShashtaPodzem()
	{
		if (shashtaPodzemDateTime > DateTime.Now)
		{
			return shashtaPodzemDateTime;
		}
		if (!AppSettings.Get("checkBoxPodzemGo", defaultValue: false))
		{
			return shashtaPodzemDateTime;
		}
		int[] array = new int[7] { 0, 10, 30, 45, 60, 75, 120 };
		bool[] array2 = new bool[12]
		{
			AppSettings.Get("checkBoxPodzemTaymer_00", defaultValue: false),
			AppSettings.Get("checkBoxPodzemTaymer_05", defaultValue: false),
			AppSettings.Get("checkBoxPodzemTaymer_10", defaultValue: false),
			AppSettings.Get("checkBoxPodzemTaymer_15", defaultValue: false),
			AppSettings.Get("checkBoxPodzemTaymer_20", defaultValue: false),
			AppSettings.Get("checkBoxPodzemTaymer_25", defaultValue: false),
			AppSettings.Get("checkBoxPodzemTaymer_30", defaultValue: false),
			AppSettings.Get("checkBoxPodzemTaymer_35", defaultValue: false),
			AppSettings.Get("checkBoxPodzemTaymer_40", defaultValue: false),
			AppSettings.Get("checkBoxPodzemTaymer_45", defaultValue: false),
			AppSettings.Get("checkBoxPodzemTaymer_50", defaultValue: false),
			AppSettings.Get("checkBoxPodzemTaymer_55", defaultValue: false)
		};
		bool[] array3 = new bool[12]
		{
			AppSettings.Get("checkBoxPodzemTaymer_00_Go", defaultValue: false),
			AppSettings.Get("checkBoxPodzemTaymer_05_Go", defaultValue: false),
			AppSettings.Get("checkBoxPodzemTaymer_10_Go", defaultValue: false),
			AppSettings.Get("checkBoxPodzemTaymer_15_Go", defaultValue: false),
			AppSettings.Get("checkBoxPodzemTaymer_20_Go", defaultValue: false),
			AppSettings.Get("checkBoxPodzemTaymer_25_Go", defaultValue: false),
			AppSettings.Get("checkBoxPodzemTaymer_30_Go", defaultValue: false),
			AppSettings.Get("checkBoxPodzemTaymer_35_Go", defaultValue: false),
			AppSettings.Get("checkBoxPodzemTaymer_40_Go", defaultValue: false),
			AppSettings.Get("checkBoxPodzemTaymer_45_Go", defaultValue: false),
			AppSettings.Get("checkBoxPodzemTaymer_50_Go", defaultValue: false),
			AppSettings.Get("checkBoxPodzemTaymer_55_Go", defaultValue: false)
		};
		Find.LabelStatus("Статус: Шахта Подзем");
		IWebElement webElement = _driver.IsFindElement(By.XPath("//div[@id=\"rmenu1\"]/div/a[@class=\"timer link\"]/span"));
		if (webElement != null && webElement.Text != "00:00:00")
		{
			if (DateTime.TryParseExact(webElement.Text, "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result))
			{
				shashtaPodzemDateTime = DateTime.Now.AddSeconds(result.Second + 10).AddMinutes(result.Minute).AddHours(result.Hour);
			}
			Find.LabelStatus("Статус:");
			return shashtaPodzemDateTime;
		}
		webElement = _driver.IsFindElement(By.XPath("//b[contains(@class,\"ico_dungeon\")]/../..//span[contains(@title,\"похода в подземелье\")]"));
		if (webElement != null && !webElement.GetAttribute("outerText").Contains("00:00:00") && !webElement.GetAttribute("outerText").Contains("Спуститься"))
		{
			if (DateTime.TryParseExact(webElement.GetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result2))
			{
				shashtaPodzemDateTime = DateTime.Now.AddSeconds(result2.Second + 10).AddMinutes(result2.Minute).AddHours(result2.Hour);
			}
			Find.LabelStatus("Статус:");
			return shashtaPodzemDateTime;
		}
		if (AppSettings.Get("checkBoxPodzemTaymer", defaultValue: false) && _driver.IsFindElement(By.XPath("//div[@id=\"rmenu1\"]/div[@class=\"timers\"][contains(string(.),\"Спуск в подземелье\")]")) == null)
		{
			bool flag = false;
			int minute = DateTime.Now.Minute;
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i])
				{
					int num = i * 5;
					int num2 = num + 3;
					if (minute >= num && minute <= num2)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				Find.LabelStatus("Статус:");
				return shashtaPodzemDateTime = DateTime.Now.AddMinutes(1.0);
			}
		}
		if (!_driver.Url.Contains("botva.ru/mine.php") && !_driver.Url.Contains("botva.ru/monster.php?a=working") && !_driver.Url.Contains("botva.ru/fight_logHram.php?"))
		{
			_driver.isExecuteScriptClick(By.Id("m6"), "Клик Шахта");
		}
		if (_driver.IsFindElement(By.XPath("//input[contains(@value,\"КУПИТЬ\")]")).IsClick("Купить ключ"))
		{
			Thread.Sleep(1000);
		}
		int[] array4 = new int[15]
		{
			1, 2, 3, 4, 5, 6, 7, 8, 10, 11,
			15, 16, 17, 18, 19
		};
		if (_driver.IsFindElement(By.XPath("//div[@id=\"rmenu1\"]/div[@class=\"timers\"][contains(string(.),\"Спуск в подземелье\")]")) == null && _driver.IsFindElement(By.XPath("//select[@name=\"mmtype\"]/option[@value=\"" + array4[AppSettings.Get("comboBoxPodzemKydaIdem", 0)] + "\"]")).IsClick("Куда идем", 1000) && _driver.IsFindElement(By.XPath("//input[contains(@class,\"patrickable_monster\")][@value=\"СПУСТИТЬСЯ\"]")).IsClick("Спустится", 1500))
		{
			webElement = _driver.IsFindElement(By.XPath("//div[@id=\"rmenu1\"]/div/a[@class=\"timer link\"]/span"));
			if (webElement != null && webElement.Text != "00:00:00" && DateTime.TryParseExact(webElement.Text, "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result3))
			{
				Find.LabelStatus("Статус:");
				return shashtaPodzemDateTime = DateTime.Now.AddSeconds(result3.Second + 10).AddMinutes(result3.Minute).AddHours(result3.Hour);
			}
		}
		string[] array5 = new string[4] { "ИСКАТЬ СОКРОВИЩЕ", "ИДТИ ДАЛЬШЕ", "НАПАСТЬ", "НА ВОЗДУХ" };
		string text = string.Join(" or ", array5.Select((string text4) => "contains(@value, \"" + text4 + "\")"));
		string xpathToFind = "//input[" + text + "]";
		for (int num3 = 0; num3 < array5.Length * 2; num3++)
		{
			IWebElement webElement2 = _driver.IsFindElement(By.XPath(xpathToFind));
			webElement2?.IsClick(webElement2.isGetAttribute("value"), 1000);
		}
		if (_driver.IsFindElement(By.XPath(xpathToFind)) != null)
		{
			Find.LabelStatus("Статус:");
			return shashtaPodzemDateTime = DateTime.Now.AddSeconds(10.0);
		}
		if (AppSettings.Get("checkBoxPodzemTaymer", defaultValue: false) && _driver.IsFindElement(By.XPath("//input[@value=\"НАЧАТЬ\"]")) != null)
		{
			bool flag2 = false;
			int minute2 = DateTime.Now.Minute;
			int num4 = int.MaxValue;
			for (int num5 = 0; num5 < array3.Length; num5++)
			{
				if (array3[num5])
				{
					int num6 = num5 * 5 % 60;
					int num7 = (num6 - 1 + 60) % 60;
					int num8 = (num6 + 2 + 60) % 60;
					if ((minute2 - num7 + 60) % 60 <= (num8 - num7 + 60) % 60)
					{
						flag2 = true;
						break;
					}
					int num9 = (num7 - minute2 + 60) % 60;
					if (num9 < num4)
					{
						num4 = num9;
					}
				}
			}
			if (!flag2)
			{
				Find.LabelStatus("Статус:");
				if (num4 != int.MaxValue)
				{
					return shashtaPodzemDateTime = DateTime.Now.AddMinutes(num4);
				}
				return shashtaPodzemDateTime = DateTime.Now.AddMinutes(1.0);
			}
		}
		webElement = _driver.IsFindElement(By.XPath("//input[@value=\"НАЧАТЬ\"]"));
		if (webElement != null && webElement.IsClick("Начать", 1000))
		{
			_driver.IsFindElement(By.XPath("//span[text()=\"Да, конечно\"]")).IsClick("Да, конечно");
		}
		webElement = _driver.IsFindElement(By.XPath("//input[@name=\"room\"]"));
		if (webElement != null)
		{
			if (AppSettings.Get("checkBoxPodzemTaymer", defaultValue: false))
			{
				string[] array6 = new string[5] { "15", "16", "17", "18", "19" };
				string attribute = webElement.GetAttribute("value");
				if (array6.Contains(attribute))
				{
					bool flag3 = false;
					int minute3 = DateTime.Now.Minute;
					int num10 = int.MaxValue;
					for (int num11 = 0; num11 < array3.Length; num11++)
					{
						if (array3[num11])
						{
							int num12 = num11 * 5 % 60;
							int num13 = (num12 - 8 + 60) % 60;
							int num14 = (num12 - 4 + 60) % 60;
							if ((minute3 - num13 + 60) % 60 <= (num14 - num13 + 60) % 60)
							{
								flag3 = true;
								break;
							}
							int num15 = (num13 - minute3 + 60) % 60;
							if (num15 < num10)
							{
								num10 = num15;
							}
						}
					}
					if (!flag3)
					{
						Find.LabelStatus("Статус:");
						if (num10 != int.MaxValue)
						{
							return shashtaPodzemDateTime = DateTime.Now.AddMinutes(num10);
						}
						return shashtaPodzemDateTime = DateTime.Now.AddMinutes(1.0);
					}
				}
			}
			int[,] array7 = new int[15, 10]
			{
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
				{ 2, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
				{ 3, 3, 3, 3, 3, 3, 3, 3, 2, 1 },
				{ 4, 4, 4, 4, 4, 4, 4, 3, 2, 1 },
				{ 5, 5, 5, 5, 5, 5, 4, 3, 2, 1 },
				{ 6, 6, 6, 6, 6, 5, 4, 3, 2, 1 },
				{ 7, 7, 7, 7, 6, 5, 4, 3, 2, 1 },
				{ 8, 8, 8, 7, 6, 5, 4, 3, 2, 1 },
				{ 10, 10, 8, 7, 6, 5, 4, 3, 2, 1 },
				{ 11, 11, 8, 7, 6, 5, 4, 3, 2, 1 },
				{ 15, 10, 8, 7, 6, 5, 4, 3, 2, 1 },
				{ 16, 10, 8, 7, 6, 5, 4, 3, 2, 1 },
				{ 17, 11, 8, 7, 6, 5, 4, 3, 2, 1 },
				{ 18, 11, 8, 7, 6, 5, 4, 3, 2, 1 },
				{ 19, 11, 8, 7, 6, 5, 4, 3, 2, 1 }
			};
			int num16 = array4[AppSettings.Get("comboBoxPodzemSKokogoMesim", 0)];
			int num17 = AppSettings.Get("comboBoxPodzemKydaIdem", 0);
			string text2 = "@value=\"" + array7[num17, 0] + "\"";
			for (int num18 = 1; num18 < 10; num18++)
			{
				text2 = text2 + " or @value=\"" + array7[num17, num18] + "\"";
			}
			string text3 = "//input[@name=\"room\"][" + text2 + "]";
			if (Convert.ToInt16(webElement.GetAttribute("value")) >= num16)
			{
				_driver.IsFindElement(By.XPath("//input[contains(@value,\"БРОДИТЬ\")]")).IsClick("БРОДИТЬ");
				_driver.IsFindElement(By.XPath("//input[contains(@value,\"ПОДЗЕМИТЬ\")]")).IsClick("Подземить");
			}
			if (AppSettings.Get("checkBoxPodzemKriZoloto", defaultValue: false))
			{
				if (_driver.IsFindElement(By.XPath(text3 + "/..//input[@value=\"ПО ЛЕБЕДКЕ\"]")).IsClick("Опуск по лебедке Value "))
				{
					Thread.Sleep(1000);
				}
			}
			else if (_driver.IsFindElement(By.XPath(text3 + "/..//input[@value=\"ПО ВЕРЕВКЕ\"]")).IsClick("Опуск по веревке Value "))
			{
				Thread.Sleep(1000);
			}
		}
		if (AppSettings.Get("checkBoxPodzemKriZoloto", defaultValue: false))
		{
			if (_driver.IsFindElement(By.XPath("//input[@value=\"ПО ЛЕБЕДКЕ\"]")).IsClick("Опуск по лебедке"))
			{
				Thread.Sleep(1000);
			}
		}
		else if (_driver.IsFindElement(By.XPath("//input[@value=\"ПО ВЕРЕВКЕ\"]")).IsClick("Опуск по веревке"))
		{
			Thread.Sleep(1000);
		}
		if (_driver.IsFindElement(By.XPath("//input[contains(@value,\"НА ВОЗДУХ\")]")).IsClick("НА ВОЗДУХ"))
		{
			LogService.LogHtml("Подзем На Воздух");
			Find.LabelStatus("Статус:");
			if (AppSettings.Get("checkBoxPodzemTaymer", defaultValue: false))
			{
				return shashtaPodzemDateTime = DateTime.Now.AddMinutes(1.0);
			}
			return shashtaPodzemDateTime = DateTime.Now.AddMinutes(array[AppSettings.Get("ComboBoxPodzemPovtor", 0)]);
		}
		if (_driver.FindElements(By.XPath("//div[@class='members']/div[@data-player]")).Count < 2 && _driver.IsFindElement(By.XPath("//input[contains(@value,\"ПОКИНУТЬ ПОДЗЕМЕЛЬЕ\"  or contains(@value,\"ВЫЙТИ ИЗ ПОДЗЕМЕЛЬЯ\")]")).IsClick("НА ВОЗДУХ"))
		{
			LogService.LogHtml("Подзем На Воздух");
			Find.LabelStatus("Статус:");
			if (AppSettings.Get("checkBoxPodzemTaymer", defaultValue: false))
			{
				return shashtaPodzemDateTime = DateTime.Now.AddMinutes(1.0);
			}
			return shashtaPodzemDateTime = DateTime.Now.AddMinutes(array[AppSettings.Get("ComboBoxPodzemPovtor", 0)]);
		}
		if (_driver.FindElements(By.XPath("//div[@class='message'][contains(string(.),\"Только хорошо подготовленный клан может\")]")).Count == 1 && _driver.IsFindElement(By.XPath("//input[contains(@value,\"ВЫЙТИ ИЗ ПОДЗЕМЕЛЬЯ\")]")).IsClick("НА ВОЗДУХ"))
		{
			if (_driver.IsFindElement(By.XPath("//input[contains(@value,\"ТОЧНО ВЫЙТИ?\")]")).IsClick("ТОЧНО ВЫЙТИ?"))
			{
				LogService.LogHtml("Подзем На Воздух");
			}
			Find.LabelStatus("Статус:");
			if (AppSettings.Get("checkBoxPodzemTaymer", defaultValue: false))
			{
				return shashtaPodzemDateTime = DateTime.Now.AddMinutes(1.0);
			}
			return shashtaPodzemDateTime = DateTime.Now.AddMinutes(array[AppSettings.Get("ComboBoxPodzemPovtor", 0)]);
		}
		if (_driver.FindElements(By.XPath("//div[@class='message'][contains(string(.),\"Нет отряда в этой комнате.\")]")).Count == 1 && _driver.IsFindElement(By.XPath("//input[contains(@value,\"ПОКИНУТЬ ПОДЗЕМЕЛЬЕ\") ]")).IsClick("ПОКИНУТЬ ПОДЗЕМЕЛЬЕ"))
		{
			LogService.LogHtml("Подзем На Воздух");
			Find.LabelStatus("Статус:");
			if (AppSettings.Get("checkBoxPodzemTaymer", defaultValue: false))
			{
				return shashtaPodzemDateTime = DateTime.Now.AddMinutes(1.0);
			}
			return shashtaPodzemDateTime = DateTime.Now.AddMinutes(array[AppSettings.Get("ComboBoxPodzemPovtor", 0)]);
		}
		webElement = _driver.IsFindElement(By.XPath("//div[@id=\"rmenu1\"]/div/a[@class=\"timer link\"]/span"));
		if (webElement != null && webElement.Text != "00:00:00")
		{
			if (DateTime.TryParseExact(webElement.Text, "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result4))
			{
				shashtaPodzemDateTime = DateTime.Now.AddSeconds(result4.Second + 10).AddMinutes(result4.Minute).AddHours(result4.Hour);
			}
			Find.LabelStatus("Статус:");
			return shashtaPodzemDateTime;
		}
		Find.LabelStatus("Статус:");
		return shashtaPodzemDateTime = DateTime.Now.AddMinutes(1.0);
	}
}
