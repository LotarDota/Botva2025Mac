using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;

namespace Botva2025;

public class Ikarus
{
	private IWebDriver _driver;

	private static DateTime[] otdyshDateTime;

	private int priseVannaPirashka = 5000;

	private ulong priseVannaKristal = 1000uL;

	public int ikarusLevelOld;

	public int[,] iBgr_1 = new int[5, 2];

	public Ikarus(IWebDriver driver)
	{
		_driver = driver;
	}

	private void IkarusYmeniy()
	{
		string[] array = new string[15]
		{
			"2_1", "3_2", "4_1", "5_1", "6_2", "7_1", "8_2", "9_2", "10_2", "11_1",
			"12_2", "13_2", "14_2", "15_2", "16_2"
		};
		if (_driver.Url.Contains("avatar"))
		{
			if (AppSettings.Get("pictureBoxIkarus_Avatar", 0) == 1)
			{
				array = new string[15]
				{
					"2_1", "3_2", "4_1", "5_1", "6_2", "7_1", "8_2", "9_2", "10_2", "11_1",
					"12_1", "13_1", "14_1", "15_1", "16_1"
				};
			}
		}
		else if (AppSettings.Get("pictureBoxIkarus", 0) == 1)
		{
			array = new string[15]
			{
				"2_1", "3_2", "4_1", "5_1", "6_2", "7_1", "8_2", "9_2", "10_2", "11_1",
				"12_1", "13_1", "14_1", "15_1", "16_1"
			};
		}
		int result = 0;
		int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//div[@class=\"line_start\"]")).isGetAttribute("outerText")
			where char.IsDigit(c)
			select c), out result);
		if (result == ikarusLevelOld)
		{
			return;
		}
		_driver.IsFindElement(By.XPath("//a[contains(@href,\"/icarus.php?a=skills\")]")).IsClick("Умения Летуна ", 800);
		for (int num = 0; num < array.Length; num++)
		{
			if (_driver.isExecuteScriptClick(By.XPath("//div[contains(@data-skill,\"" + array[num] + "\") and contains(@class,\" active \")]"), "Умения " + array[num], 1000))
			{
				_driver.IsFindElement(By.XPath("//input[@id=\"icarus_skills_send\" and not(@disabled)]")).IsClick("Умения  Сохранить", 1000);
			}
		}
		ikarusLevelOld = result;
	}

	private void IkarusMagazin()
	{
		string[] array = new string[8] { "Касторка", "Чай с мёдом", "Сухпоек «Питательный»", "Вяленный окорок", "Мороженка", "Салат из кофейных листьев", "Тысяча и один миф", "О полётах на Альфа-Сыр-Тавру" };
		string pageSource = _driver.PageSource;
		bool flag = false;
		string[] array2 = array;
		foreach (string str in array2)
		{
			string pattern = Regex.Escape(str) + ".*?\\((\\d+)\\)";
			Match match = Regex.Match(pageSource, pattern);
			if (match.Success && Convert.ToInt16(match.Groups[1].Value.ToString()) < 50)
			{
				flag = true;
				break;
			}
		}
		if (!flag || !_driver.IsFindElement(By.XPath("//a[contains(@href,\"/icarus.php?a=shop\")]")).IsClick("Магазин", 1000))
		{
			return;
		}
		string[] array3 = new string[4] { "icarus_item_book_1 ", "icarus_item_food_1 ", "icarus_item_food_3 ", "icarus_item_health_1 " };
		string[] array4 = new string[4] { "icarus_item_book_2 ", "icarus_item_food_2 ", "icarus_item_food_4 ", "icarus_item_health_2 " };
		for (int j = 0; j < array3.Length; j++)
		{
			ulong num = _driver.ResyKri();
			ulong.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//div[contains(@class,\"" + array3[j] + "\")]")).isGetAttribute("outerText")
				where char.IsDigit(c)
				select c), out var result);
			if (result < 100 && (100 - result) * 200 < num)
			{
				for (ulong num2 = 0uL; num2 < 100 - result; num2++)
				{
					_driver.IsFindElement(By.XPath("//div[contains(@class,\"" + array3[j] + "\")]//..//form/input[@type=\"submit\"]")).IsClick("Купить " + array3[j], 800);
				}
			}
		}
		for (int num3 = 0; num3 < array4.Length; num3++)
		{
			long num4 = _driver.ResyPiraShki();
			long.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//div[contains(@class,\"" + array4[num3] + "\")]")).isGetAttribute("outerText")
				where char.IsDigit(c)
				select c), out var result2);
			if (result2 < 100 && (100 - result2) * 2000 < num4)
			{
				for (long num5 = 0L; num5 < 100 - result2; num5++)
				{
					_driver.IsFindElement(By.XPath("//div[contains(@class,\"" + array4[num3] + "\")]//..//form/input[@type=\"submit\"]")).IsClick("Купить " + array4[num3], 800);
				}
			}
		}
	}

	private DateTime[] IkarusEgg()
	{
		otdyshDateTime = IkarusDatetime();
		if (otdyshDateTime[0] <= DateTime.Now)
		{
			string[] array = _driver.IsFindElement(By.XPath("//div[@class=\"bgr_1 mb10\"]//div[@class=\"text title_is_bind\"]")).isGetAttribute("outerText").Split('/');
			int result = 0;
			if (int.TryParse(string.Join("", array[0].Where((char c) => char.IsDigit(c))), out result))
			{
				if (result > 75)
				{
					IWebElement elem = _driver.IsFindElement(By.XPath("//select[@id=\"icarus_books\"]/option[2]"));
					if (int.TryParse(string.Join("", from c in elem.isGetAttribute("outerText")
						where char.IsDigit(c)
						select c), out result) && result > 0)
					{
						elem.IsClick("Выбираю опыт");
						if (_driver.IsFindElement(By.XPath("//div[contains(@class,\"icarus_book_2\")]//input[@value=\"ПРОЧЕСТЬ\"]")).IsClick("Прочесть книгу 2"))
						{
							Thread.Sleep(1000);
						}
					}
				}
				else
				{
					IWebElement elem2 = _driver.IsFindElement(By.XPath("//select[@id=\"icarus_books\"]/option[1]"));
					if (int.TryParse(string.Join("", from c in elem2.isGetAttribute("outerText")
						where char.IsDigit(c)
						select c), out result) && result > 0)
					{
						elem2.IsClick("Выбираю Настроение");
						if (_driver.IsFindElement(By.XPath("//div[contains(@class,\"icarus_book_1\")]//input[@value=\"ПРОЧЕСТЬ\"]")).IsClick("Прочесть книгу 1"))
						{
							Thread.Sleep(1000);
						}
					}
				}
				if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//div[contains(text(),\"Отдых от литературы\")]/span")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result2))
				{
					otdyshDateTime[0] = DateTime.Now.AddSeconds(result2.Second + 15).AddMinutes(result2.Minute).AddHours(result2.Hour);
				}
			}
			else
			{
				otdyshDateTime[0] = DateTime.Now.AddMinutes(5.0);
			}
		}
		if (int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//div[@class=\"bgr_1\"]//div[@class=\"text title_is_bind\"]")).isGetAttribute("outerText")
			where char.IsDigit(c)
			select c), out var result3) && result3 != 100)
		{
			if (otdyshDateTime[1] <= DateTime.Now)
			{
				IWebElement webElement = _driver.IsFindElement(By.XPath("//div[contains(@class, 'icarus_bath_10')]/span/b[1]"));
				if (int.TryParse(webElement.Text, out var result4))
				{
					priseVannaPirashka = result4;
				}
				if (_driver.ResyPiraShki() > priseVannaPirashka)
				{
					_driver.IsFindElement(By.XPath("//select[@id=\"icarus_baths\"]/option[1]")).IsClick("Выбрать пирашковую ванну");
					_driver.IsFindElement(By.XPath("//div[contains(@class,\"icarus_bath_10\")]//input[@value=\"ПОМЫТЬ\"]")).IsClick("Выбрать пирашковую ванну");
				}
			}
			if (otdyshDateTime[2] <= DateTime.Now)
			{
				IWebElement webElement2 = _driver.IsFindElement(By.XPath("//div[contains(@class, 'icarus_bath_2')]/span/b[1]"));
				if (ulong.TryParse(webElement2.Text, out var result5))
				{
					priseVannaKristal = result5;
				}
				if (_driver.ResyKri() > priseVannaKristal)
				{
					_driver.IsFindElement(By.XPath("//select[@id=\"icarus_baths\"]/option[2]")).IsClick("Выбрать кристальная ванну");
					_driver.IsFindElement(By.XPath("//div[contains(@class,\"icarus_bath_2\")]//input[@value=\"ПОМЫТЬ\"]")).IsClick("Выбрать Кристальная ванну");
				}
			}
		}
		otdyshDateTime = IkarusDatetime();
		return otdyshDateTime;
	}

	private DateTime[] IkarusDatetime()
	{
		DateTime[] array = new DateTime[6]
		{
			DateTime.Now,
			DateTime.Now,
			DateTime.Now,
			DateTime.Now,
			DateTime.Now,
			DateTime.Now
		};
		string[] array2 = new string[6] { "//div[contains(text(),\"Отдых от литературы\")]/span", "//div[contains(@class,\"icarus_bath_10\")]/span", "//div[contains(@class,\"icarus_bath_2\")]/span", "//div[contains(text(),\"Переваривание пищи\")]/span", "//div[contains(text(),\"Отдых от пилюль\")]/span", "//div[contains(text(),\"Вы уложили малыша спать\") or contains(text(),\"Икарус улетел\")]/span" };
		int[] array3 = new int[6] { 45, 15, 45, 15, 45, 0 };
		int[] array4 = new int[6] { 0, 0, 0, 0, 0, 1 };
		for (int i = 0; i < array2.Length; i++)
		{
			if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath(array2[i])).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result))
			{
				array[i] = DateTime.Now.AddSeconds(result.Second + array3[i]).AddMinutes(result.Minute + array4[i]).AddHours(result.Hour);
			}
		}
		return array;
	}

	public DateTime IkarusGo()
	{
		DateTime[] array = IkarusDatetime();
		string[] array2 = new string[5] { "//div[@class=\"icarus_line \"]", "//div[contains(@class,\"bgr_1\")][1]//div[@class=\"text title_is_bind\"]", "//div[contains(@class,\"bgr_1\")][2]//div[@class=\"text title_is_bind\"]", "//div[contains(@class,\"bgr_1\")][3]//div[@class=\"text title_is_bind\"]", "//div[contains(@class,\"bgr_1\")][4]//div[@class=\"text title_is_bind\"]" };
		if (_driver.IsFindElement(By.XPath("//div[contains(@class,\"icarus_book_2\")]//input[@value=\"ПРОЧЕСТЬ\"]")).isGetAttribute("value") != "")
		{
			array = IkarusEgg();
		}
		else
		{
			string[] array3;
			for (int i = 1; i < array2.Length; i++)
			{
				array3 = _driver.IsFindElement(By.XPath(array2[i])).isGetAttribute("outerText").Split('/');
				for (int j = 0; j < array3.Length; j++)
				{
					int.TryParse(string.Join("", array3[j].Where((char c) => char.IsDigit(c))), out iBgr_1[i, j]);
				}
			}
			array3 = _driver.IsFindElement(By.XPath(array2[0])).isGetAttribute("outerText").Split('/');
			if (array3.Length == 2)
			{
				for (int num = 0; num < array3.Length; num++)
				{
					int.TryParse(string.Join("", array3[num].Where((char c) => char.IsDigit(c))), out iBgr_1[0, num]);
				}
			}
			else
			{
				int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath(array2[0])).isGetAttribute("outerText")
					where char.IsDigit(c)
					select c), out iBgr_1[0, 0]);
			}
			if (array[0] <= DateTime.Now)
			{
				IkarusNastroenie();
			}
			if (array[4] <= DateTime.Now)
			{
				IkarusZdorove();
			}
			if (array[3] <= DateTime.Now)
			{
				IkarusSytost();
			}
			if (array[5] <= DateTime.Now)
			{
				IkarusEnergi();
			}
		}
		array = IkarusDatetime();
		DateTime dateTime = DateTime.Now;
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			if (!(array[num2] <= DateTime.Now))
			{
				if (dateTime <= DateTime.Now)
				{
					dateTime = array[num2];
				}
				if (dateTime > array[num2])
				{
					dateTime = array[num2];
				}
			}
		}
		if (dateTime <= DateTime.Now)
		{
			dateTime = DateTime.Now.AddMinutes(45.0);
		}
		IkarusMagazin();
		IkarusYmeniy();
		return dateTime;
	}

	private void IkarusEnergi()
	{
		if (iBgr_1[1, 1] - iBgr_1[1, 0] > 30)
		{
			_driver.IsFindElement(By.XPath("//select[@id=\"energyHours\"]/option[2]")).IsClick();
			if (_driver.IsFindElement(By.XPath("//input[@type=\"submit\"][@value=\"СПАТЬ\"]")).IsClick())
			{
				Thread.Sleep(1000);
			}
		}
	}

	private void IkarusSytost()
	{
		int num = iBgr_1[3, 1] - iBgr_1[3, 0];
		if (num > 30)
		{
			SelectFoodAndFeed(1);
		}
		else if (num > 25)
		{
			SelectFoodAndFeed(2);
		}
		else if (iBgr_1[1, 1] - iBgr_1[1, 0] > iBgr_1[4, 1] - iBgr_1[4, 0])
		{
			SelectFoodAndFeed(4);
		}
		else
		{
			SelectFoodAndFeed(3);
		}
	}

	private void IkarusZdorove()
	{
		if (iBgr_1[2, 1] - iBgr_1[2, 0] > 35)
		{
			SelectMedicineAndHeal(1);
		}
		else
		{
			SelectMedicineAndHeal(2);
		}
	}

	private void IkarusNastroenie()
	{
		if (iBgr_1[4, 1] - iBgr_1[4, 0] > 30)
		{
			SelectBookAndRead(1);
		}
		else
		{
			SelectBookAndRead(2);
		}
	}

	private void SelectFoodAndFeed(int optionIndex)
	{
		_driver.FindElement(By.XPath($"//select[@id=\"icarus_foods\"]/option[{optionIndex}]")).IsClick();
		if (_driver.FindElement(By.XPath("//input[@type=\"submit\"][@value=\"КОРМИТЬ\"]")).IsClick())
		{
			Thread.Sleep(1000);
		}
	}

	private void SelectMedicineAndHeal(int optionIndex)
	{
		_driver.FindElement(By.XPath($"//select[@id=\"icarus_healths\"]/option[{optionIndex}]")).IsClick();
		if (_driver.FindElement(By.XPath("//input[@type=\"submit\"][@value=\"ЛЕЧИТЬ\"]")).IsClick())
		{
			Thread.Sleep(1000);
		}
	}

	private void SelectBookAndRead(int optionIndex)
	{
		_driver.FindElement(By.XPath($"//select[@id=\"icarus_books\"]/option[{optionIndex}]")).IsClick();
		if (_driver.FindElement(By.XPath("//input[@type=\"submit\"][@value=\"ПРОЧЕСТЬ\"]")).IsClick())
		{
			Thread.Sleep(1000);
		}
	}
}
