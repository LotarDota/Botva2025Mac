using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;

namespace Botva2025;

public class Alhimiy
{
	private IWebDriver _driver;

	public DateTime alhimiyYchebaDateTime { get; set; }

	public DateTime alhimiyTaraDateTime { get; set; }

	public Alhimiy(IWebDriver driver)
	{
		_driver = driver;
		alhimiyYchebaDateTime = DateTime.Now;
		alhimiyTaraDateTime = DateTime.Now;
	}

	public void MainAlhimiy()
	{
		try
		{
			AlhimiyYcheba();
		}
		catch
		{
			alhimiyYchebaDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			AlhimiyTara();
		}
		catch
		{
			alhimiyTaraDateTime = DateTime.Now.AddMinutes(5.0);
		}
	}

	private DateTime AlhimiyTara()
	{
		if (alhimiyTaraDateTime > DateTime.Now)
		{
			return alhimiyTaraDateTime;
		}
		if (!AppSettings.Get("checkBoxAlhimiyTara", defaultValue: false))
		{
			return alhimiyTaraDateTime = DateTime.Now.AddMinutes(5.0);
		}
		UpdateStatus("Статус:Алхимия Стекляная Тара ");
		string[] array = _driver.IsFindElement(By.XPath("//li[@id=\"i59\"]")).isGetAttribute("outerText").Split('/');
		int[] array2 = new int[2];
		if (!int.TryParse(string.Join("", array[0].Where((char c) => char.IsDigit(c))), out array2[0]) || !int.TryParse(string.Join("", array[1].Where((char c) => char.IsDigit(c))), out array2[1]))
		{
			UpdateStatus("Статус: ");
			return alhimiyTaraDateTime = DateTime.Now.AddMinutes(1.0);
		}
		if (array2[1] != 0 && Convert.ToInt16(array2[0]) >= Convert.ToInt16(array2[1]))
		{
			UpdateStatus("Статус: ");
			return alhimiyTaraDateTime = DateTime.Now.AddMinutes(30.0);
		}
		_driver.isExecuteScriptClick(By.XPath("//li[@id=\"i59\"]/a"), "Клик Стекляная Тара");
		_driver.IsFindElement(By.XPath("//input[@onclick=\"startMake(1);\"]")).IsClick("Клик Расколеное стекло ");
		_driver.IsFindElement(By.XPath("//input[@onclick=\"startMake(2);\"]")).IsClick("Клик Тара ");
		UpdateStatus("Статус:");
		return alhimiyTaraDateTime = DateTime.Now.AddMinutes(16.0);
	}

	private DateTime AlhimiyYcheba()
	{
		if (alhimiyYchebaDateTime > DateTime.Now)
		{
			return alhimiyYchebaDateTime;
		}
		if (!AppSettings.Get("checkBoxAlhimiy", defaultValue: false))
		{
			return alhimiyYchebaDateTime = DateTime.Now.AddMinutes(5.0);
		}
		UpdateStatus("Статус:Алхимия ");
		_driver.IsFindElement(By.XPath("//a[contains(@class,\" guild_31 \")]")).IsClick("Клик Алхимия");
		_driver.IsFindElement(By.XPath("//a[contains(@href,\"a=myguild&id=31&m=potion_2\")]")).IsClick("Клик Обычные зелья");
		_driver.IsFindElement(By.XPath("//a[contains(@href,\"a=myguild&id=31&m=potion_1\")]")).IsClick("Клик Простейшие зелья");
		if (_driver.IsFindElement(By.XPath("//input[@onclick=\"endWork();\"]")).IsClick("Клик Завершить варку "))
		{
			Thread.Sleep(1000);
		}
		_driver.IsFindElement(By.XPath("//input[@onclick=\"startMakeZ();\"]")).IsClick("Клик Варить ");
		for (int i = 0; i < 5; i++)
		{
			if (int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//span[@id=\"alchemy_purity\"]")).isGetAttribute("outerText")
				where char.IsDigit(c)
				select c), out var result) && result < 90 && _driver.ResyKri() > 100 && _driver.IsFindElement(By.XPath("//input[@onclick=\"cleanBoiler();\"]")).IsClick("Клик Чистить Котел "))
			{
				Thread.Sleep(500);
			}
		}
		if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//div[@id=\"alchemy_small_window_text2\"]/span")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result2))
		{
			alhimiyYchebaDateTime = DateTime.Now.AddSeconds(result2.Second + 10).AddMinutes(result2.Minute).AddHours(result2.Hour);
			if ((alhimiyYchebaDateTime - DateTime.Now).TotalMinutes > 5.0)
			{
				alhimiyYchebaDateTime = alhimiyYchebaDateTime.AddMinutes(-2.0);
			}
			if ((alhimiyYchebaDateTime - DateTime.Now).TotalMinutes > 31.0)
			{
				alhimiyYchebaDateTime = DateTime.Now.AddMinutes(31.0);
			}
			UpdateStatus("Статус:");
			return alhimiyYchebaDateTime;
		}
		UpdateStatus("Статус:");
		return alhimiyYchebaDateTime = DateTime.Now.AddMinutes(5.0);
	}

	private void UpdateStatus(string v)
	{
		Find.LabelStatus(v);
	}

	private void AlhimiyTemperatura()
	{
	}

	private int[] AlhimiyRes()
	{
		int[] array = new int[9];
		for (int i = 0; i < 9; i++)
		{
			int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//td[@valign=\"middle\"][" + (i + 1) + "]")).isGetAttribute("outerText")
				where char.IsDigit(c)
				select c), out array[i]);
		}
		return array;
	}
}
