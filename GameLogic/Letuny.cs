using System.Windows.Forms;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using Botva2025.Services;
using OpenQA.Selenium;

namespace Botva2025;

public class Letuny
{
	private IWebDriver _driver;

	private Form1 _mainForm;

	private bool[] letynEgg = new bool[4] { true, true, true, true };

	private DateTime letynTimer;

	private DateTime[] letynTaymer = new DateTime[4]
	{
		DateTime.Now,
		DateTime.Now,
		DateTime.Now,
		DateTime.Now
	};

	private long[] letynKach = new long[4];

	private Control[] controlTime;

	public DateTime letunRabyDateTime { get; set; } = DateTime.Now;

	public Letuny(IWebDriver driver, Form1 mainForm)
	{
		_driver = driver;
		_mainForm = mainForm;
		controlTime = (Control[])(object)new Control[4]
		{
			(Control)_mainForm.labelTimeLetun1,
			(Control)_mainForm.labelTimeLetun2,
			(Control)_mainForm.labelTimeLetun3,
			(Control)_mainForm.labelTimeLetun4
		};
	}

	public void LetynMain()
	{
		try
		{
			LetynyMain();
		}
		catch
		{
		}
		try
		{
			LetunRaby();
		}
		catch
		{
		}
	}

	public DateTime LetunRaby()
	{
		if (letunRabyDateTime > DateTime.Now)
		{
			return letunRabyDateTime;
		}
		if (!AppSettings.Get("checkBoxLetunRaby", defaultValue: false))
		{
			return letunRabyDateTime = DateTime.Now.AddMinutes(10.0);
		}
		int[] ari = new int[2];
		_driver.ResyRaby(out ari);
		if (ari[0] < 31)
		{
			return letunRabyDateTime = DateTime.Now.AddMinutes(10.0);
		}
		if (!_driver.Url.Contains("botva.ru/castle.php?a=zoo"))
		{
			_driver.isExecuteScriptClick(By.XPath("//div[@id=\"fast\"]//div[contains(@class,\"ico f55 \")]"), "Клик инкубатор");
		}
		_driver.IsFindElement(By.XPath("//div[@id=\"fa_feed\"][not(contains(@class,\"selected\"))]/span")).IsClick("Перейти в fa_feed ");
		for (int i = 0; i < 6; i++)
		{
			_driver.ResyRaby(out ari);
			IWebElement webElement = _driver.IsFindElement(By.XPath("//div[@id=\"not_enought\"]/../input[@type=\"submit\"]"));
			if (webElement == null)
			{
				return letunRabyDateTime = DateTime.Now.AddMinutes(15.0);
			}
			if (ari[0] < 31)
			{
				return letunRabyDateTime = DateTime.Now.AddMinutes(10.0);
			}
			_driver.IsFindElement(By.XPath("//input[@value=\"50010\"]")).IsClick("Клик Рабы");
			webElement.IsClick("Клик кормить рабами");
		}
		return letunRabyDateTime = DateTime.Now.AddMinutes(5.0);
	}

	public void LetynTimerData()
	{
		letynTimer = DateTime.Now;
		letynKach[0] = 1L;
		letynKach[1] = 1L;
		letynKach[2] = 1L;
		letynKach[3] = 1L;
	}

	public DateTime LetynyMain()
	{
		if (letynTimer > DateTime.Now)
		{
			return letynTimer;
		}
		bool[] array = new bool[4]
		{
			AppSettings.Get("checkBoxBolPrik1", defaultValue: false),
			AppSettings.Get("checkBoxBolPrik2", defaultValue: false),
			AppSettings.Get("checkBoxBolPrik3", defaultValue: false),
			AppSettings.Get("checkBoxBolPrik4", defaultValue: false)
		};
		bool[] array2 = new bool[4]
		{
			AppSettings.Get("checkBoxKarKar1", defaultValue: false),
			AppSettings.Get("checkBoxKarKar2", defaultValue: false),
			AppSettings.Get("checkBoxKarKar3", defaultValue: false),
			AppSettings.Get("checkBoxKarKar4", defaultValue: false)
		};
		if (!AppSettings.Get("checkBoxBolshoePrikl", defaultValue: false) && !AppSettings.Get("checkBoxMalPrik", defaultValue: false) && !AppSettings.Get("checkBoxKarKar", defaultValue: false))
		{
			return letynTimer = DateTime.Now.AddMinutes(5.0);
		}
		Find.LabelStatus("Статус: Летуны");
		try
		{
			LetynyEgg();
		}
		catch
		{
		}
		try
		{
			letynyZdorov();
		}
		catch
		{
		}
		try
		{
			LetynyKach();
		}
		catch
		{
		}
		try
		{
			LetunPolet();
		}
		catch
		{
		}
		try
		{
			LetynTaymer();
		}
		catch
		{
		}
		DateTime dateTime = DateTime.MaxValue;
		for (int i = 0; i < 4; i++)
		{
			if ((array[i] || array2[i]) && letynTaymer[i] < dateTime)
			{
				dateTime = letynTaymer[i];
			}
		}
		if (dateTime == DateTime.MaxValue)
		{
			dateTime = DateTime.Now.AddMinutes(5.0);
		}
		for (int j = 0; j < 4; j++)
		{
		}
		Find.LabelStatus("Статус:");
		return letynTimer = dateTime.AddSeconds(60.0);
	}

	private void LetynyEgg()
	{
		if (_driver.IsFindElement(By.XPath("//form//input[@value=\"УХОД\"]")) == null)
		{
			return;
		}
		if (_driver.IsFindElement(By.XPath("//div[@class=\"content\"]//i[@class=\"timer_here\"]/span")).isGetAttribute("outerText").Contains("00:00:00"))
		{
			_driver.isExecuteScriptClick(By.Id("m1"), "Персонаж");
		}
		for (int i = 1; i < 5; i++)
		{
			if (!letynEgg[i - 1])
			{
				continue;
			}
			if (_driver.isExecuteScriptClick(By.XPath("(//div[@class=\"content\"])[" + i + "]//input[@value=\"ЧИСТКА\"]"), "Переход в летуна " + i))
			{
				if (_driver.IsFindElement(By.XPath("//div[@id=\"flying_block\"][contains(string(.),\"Вы можете быть уверены\")]")) != null)
				{
					letynEgg[i - 1] = false;
					continue;
				}
				if (_driver.ResyKri() > 100)
				{
					for (int j = 0; j < 2; j++)
					{
						_driver.IsFindElement(By.XPath("//div[@id=\"flying_block\"]//form//b[@title=\"Кристаллы\"]//..//input[not(@checked)]")).IsClick("Клик кристал " + i);
						_driver.IsFindElement(By.XPath("//div[@id=\"flying_block\"]//form//input[@value=\"ПОЧИСТИТЬ\"]")).IsClick("Ухаживать " + i);
					}
				}
				else if (_driver.ResyPiraShki() > 2000)
				{
					for (int k = 0; k < 2; k++)
					{
						_driver.IsFindElement(By.XPath("//div[@id=\"flying_block\"]//form//b[@title=\"Пирашки\"]//..//input[not(@checked)]")).IsClick("Переход в уход");
						_driver.IsFindElement(By.XPath("//div[@id=\"flying_block\"]//form//input[@value=\"ПОЧИСТИТЬ\"]")).IsClick("Ухаживать " + i);
					}
				}
			}
			if (!int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("(//div[@class=\"content\"])[" + i + "]//span[contains(string(.),\"Состояние\")]")).isGetAttribute("outerText")
				where char.IsDigit(c)
				select c), out var result) || result >= 80)
			{
				continue;
			}
			_driver.isExecuteScriptClick(By.XPath("(//div[@class=\"content\"])[" + i + "]//input[@value=\"УХОД\"]"), "Переход в летуна " + i);
			if (_driver.ResyKri() > 100)
			{
				for (int num = 0; num < 2; num++)
				{
					_driver.IsFindElement(By.XPath("//div[@id=\"flying_block\"]//form//b[@title=\"Кристаллы\"]//..//input[not(@checked)]")).IsClick("Клик кристал " + i);
					_driver.IsFindElement(By.XPath("//div[@id=\"flying_block\"]//form//input[@value=\"УХАЖИВАТЬ\"]")).IsClick("Ухаживать " + i);
				}
			}
			else if (_driver.ResyPiraShki() > 2000)
			{
				for (int num2 = 0; num2 < 2; num2++)
				{
					_driver.IsFindElement(By.XPath("//div[@id=\"flying_block\"]//form//b[@title=\"Пирашки\"]//..//input[not(@checked)]")).IsClick("Переход в уход");
					_driver.IsFindElement(By.XPath("//div[@id=\"flying_block\"]//form//input[@value=\"УХАЖИВАТЬ\"]")).IsClick("Ухаживать " + i);
				}
			}
		}
	}

	private void LetunPolet()
	{
		bool[] array = new bool[4]
		{
			AppSettings.Get("checkBoxBolPrik1", defaultValue: false),
			AppSettings.Get("checkBoxBolPrik2", defaultValue: false),
			AppSettings.Get("checkBoxBolPrik3", defaultValue: false),
			AppSettings.Get("checkBoxBolPrik4", defaultValue: false)
		};
		bool[] array2 = new bool[4]
		{
			AppSettings.Get("checkBoxKarKar1", defaultValue: false),
			AppSettings.Get("checkBoxKarKar2", defaultValue: false),
			AppSettings.Get("checkBoxKarKar3", defaultValue: false),
			AppSettings.Get("checkBoxKarKar4", defaultValue: false)
		};
		try
		{
			LetynTaymer();
		}
		catch
		{
		}
		for (int i = 0; i < 4; i++)
		{
			if (letynTaymer[i] > DateTime.Now || (!array[i] && !array2[i]))
			{
				continue;
			}
			if (!_driver.Url.Contains("botva.ru/castle.php?a=zoo"))
			{
				_driver.isExecuteScriptClick(By.XPath("//div[@id=\"fast\"]//div[contains(@class,\"ico f55 \")]"), "Клик ico f55");
			}
			_driver.IsFindElement(By.XPath("//div[@id=\"flyings\"]/div[contains(@class,\"flying\")][" + (i + 1) + "][not(contains(@class,\"active\"))]")).IsClick("Перейти в Летуна " + i);
			_driver.IsFindElement(By.XPath("//div[@id=\"fa_events\"][not(contains(@class,\"selected\"))]/span")).IsClick("Перейти в приключения " + i);
			if (_driver.IsFindElement(By.XPath("//a[contains(@class,\"chest\")][last()]")).IsClick("Выбрать приз " + i))
			{
				Find.WebBrowserLog($"выбрать приз {i}");
				Find.Sleep(1000);
				_driver.IsFindElement(By.XPath("//div[@id=\"fa_events\"]/span")).IsClick("Перейти в приключения " + i);
			}
			if (AppSettings.Get("checkBoxMalPriklMax", defaultValue: false))
			{
				if (AppSettings.Get("checkBoxMalPriklMax", defaultValue: false))
				{
					_driver.IsFindElement(By.XPath("//select[@name=\"watch_time\"]/option[last()]")).IsClick("Выбрать время полета маленькое приключение " + (i + 1));
				}
				if (_driver.IsFindElement(By.XPath("//input[@value=\"do_small\"]/../input[@value=\"ОТПРАВИТЬ\"]")).IsClick("ОТПРАВИТЬ в Малое приключение " + (i + 1)))
				{
					Find.WebBrowserLog($"МалоеПрикл {i}");
				}
			}
			if (AppSettings.Get("checkBoxBolshoePrikl", defaultValue: false) && array[i] && _driver.IsFindElement(By.XPath("//input[@value=\"do_big\"]/../input[@value=\"ОТПРАВИТЬ\"]")).IsClick("ОТПРАВИТЬ в Большое приключение " + (i + 1)))
			{
				Find.WebBrowserLog($"БольшоеПрикл {i}");
			}
			if (AppSettings.Get("checkBoxKarKar", defaultValue: false) && array2[i] && _driver.IsFindElement(By.XPath("//input[@value=\"ОТПРАВИТЬ\"][contains(@onclick,\"show_flying_mega\")]")).IsClick("ОТПРАВИТЬ в Кар кар " + (i + 1)))
			{
				LogService.LogHtml("КарКар " + i);
				Thread.Sleep(1000);
				Random random = new Random();
				if (_driver.IsFindElement(By.XPath("//div[@rel][contains(@class,\"mbuttons\")][" + random.Next(1, 4) + "]")).IsClick("ОТПРАВИТЬ в Кар кар " + (i + 1)))
				{
					Thread.Sleep(500);
				}
				if (_driver.IsFindElement(By.XPath("//select[contains(@id,\"stage_count\")]/option[" + (AppSettings.Get("comboBoxKarKar", 0) + 1) + "]")).IsClick("Клик Время Кар кар"))
				{
					Thread.Sleep(1000);
				}
				if (_driver.IsFindElement(By.XPath("//div[contains(@class,\"patrickable_karkar\")]")).IsClick("ОТПРАВИТЬ в Кар кар " + (i + 1)))
				{
					Thread.Sleep(1000);
				}
				if (_driver.IsFindElement(By.XPath("//div[@id=\"megablock\"]/div")).IsClick("Закрыть в Кар кар " + (i + 1)))
				{
					Thread.Sleep(500);
				}
			}
		}
	}

	private void letynyZdorov()
	{
		if (!AppSettings.Get("checkBoxLechimLetun", defaultValue: false))
		{
			return;
		}
		for (int i = 0; i < 4; i++)
		{
			if (int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//div[@class=\"flyings\"]/div[@class=\"content\"][" + (i + 1) + "]//a[contains(@href,\"block=feed\")]")).isGetAttribute("outerText")
				where char.IsDigit(c)
				select c), out var result) && result < 75)
			{
				_driver.isExecuteScriptClick(By.XPath("//div[@class=\"flyings\"]/div[@class=\"content\"][" + (i + 1) + "]//a[contains(@href,\"block=feed\")]"), "Переход Летун здоровье " + i);
				_driver.IsFindElement(By.XPath("//div[@id=\"feed_zoo_did\"]//input[@value=\"2\"]")).IsClick("Выбрать Кристалл");
				_driver.IsFindElement(By.XPath("//div[@id=\"feed_zoo_did\"]//input[@value=\"КОРМИТЬ\"]")).IsClick("Выбрать Кристалл");
			}
		}
	}

	private void LetynyKach()
	{
		if (!AppSettings.Get("checkBoxKachLetun", defaultValue: false))
		{
			return;
		}
		long num = 1L;
		string[] array = new string[5] { "power", "block", "dexterity", "endurance", "charisma" };
		long[,] array2 = new long[5, 2]
		{
			{ 0L, 0L },
			{ 1L, 0L },
			{ 2L, 0L },
			{ 3L, 0L },
			{ 4L, 0L }
		};
		for (int i = 0; i < 4; i++)
		{
			if (!long.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//div[@class=\"flyings\"]/div[@class=\"content\"][" + (i + 1) + "]//a[contains(@href,\"block=training\")]")).isGetAttribute("outerText")
				where char.IsDigit(c)
				select c), out var result) || result < letynKach[i])
			{
				continue;
			}
			_driver.isExecuteScriptClick(By.XPath("//div[@class=\"flyings\"]/div[@class=\"content\"][" + (i + 1) + "]//a[contains(@href,\"block=training\")]"), "Кач переход в летуна " + i);
			for (int num2 = 0; num2 < 5; num2++)
			{
				string text = _driver.IsFindElement(By.XPath("//span[@id=\"path_price_gold_" + array[num2] + "\"]")).isGetAttribute("outerText");
				try
				{
					if (_driver.IsFindElement(By.XPath("//span[@id=\"path_price_gold_" + array[num2] + "\"]//b[@class=\"icon money_ingots_small\"]")) != null)
					{
						text += "000000000";
					}
				}
				catch
				{
				}
				long.TryParse(string.Join("", text.Where((char c) => char.IsDigit(c))), out array2[num2, 1]);
			}
			num = array2[0, 1];
			long num3 = 0L;
			for (int num4 = 1; num4 < 5; num4++)
			{
				if (num > array2[num4, 1])
				{
					num = array2[num4, 1];
					num3 = array2[num4, 0];
				}
			}
			letynKach[i] = num;
			if (_driver.IsFindElement(By.XPath("//a[@href=\"javascript:training_gold.setMaxStat('" + array[num3] + "')\"]")).IsClick("качь " + array[num3]))
			{
				_driver.IsFindElement(By.XPath("//input[@value=\"ТРЕНИРОВАТЬСЯ\"]")).IsClick("тренировка", 1000);
			}
		}
	}

	public void LetynyKar()
	{
	}

	public void LetynTaymer()
	{
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected O, but got Unknown
		//IL_0179: Expected O, but got Unknown
		string[] array = new string[4];
		IWebElement webElement = null;
		for (int i = 0; i < 4; i++)
		{
			try
			{
				webElement = _driver.IsFindElement(By.XPath("//div[@class=\"flyings\"]/div[@class=\"content\"][" + (i + 1) + "]//span"));
				if (webElement != null)
				{
					array[i] = webElement.isGetAttribute("outerText");
				}
				else
				{
					array[i] = "";
				}
			}
			catch
			{
				array[i] = "";
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (array[j] != "" && array[j] != "00:00:00")
			{
				if (DateTime.TryParseExact(array[j], "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result))
				{
					letynTaymer[j] = DateTime.Now.AddSeconds(result.Second + 2).AddMinutes(result.Minute).AddHours(result.Hour);
				}
				else
				{
					letynTaymer[j] = DateTime.Now;
				}
			}
			else
			{
				letynTaymer[j] = DateTime.Now;
			}
		}
		int k;
		System.Windows.Forms.MethodInvoker val = default(System.Windows.Forms.MethodInvoker);
		for (k = 0; k < 4; k++)
		{
			Control obj2 = controlTime[k];
			System.Windows.Forms.MethodInvoker obj3 = val;
			if (obj3 == null)
			{
				System.Windows.Forms.MethodInvoker val2 = delegate
				{
					controlTime[k].Text = letynTaymer[k].ToString("HH:mm:ss");
				};
				System.Windows.Forms.MethodInvoker val3 = val2;
				val = val2;
				obj3 = val3;
			}
			obj2.Invoke((Delegate)(object)obj3);
		}
	}
}
