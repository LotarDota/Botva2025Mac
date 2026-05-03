using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;

namespace Botva2025;

internal class TorgovayPloshadka
{
	private IWebDriver _driver;

	public DateTime bolshayPolynaDateTime { get; set; }

	public DateTime malenkiePolynaDateTime { get; set; }

	public DateTime RabyKypitDateTime { get; set; }

	public DateTime RabyProdatDateTime { get; set; }

	public DateTime PylProdatDateTime { get; set; }

	public DateTime PylKypitDateTime { get; set; }

	public DateTime MyloKypitDateTime { get; set; }

	public DateTime RtutKypitDateTime { get; set; }

	public DateTime rabyDateTime { get; set; }

	public DateTime YdrenKypitDateTime { get; set; }

	public TorgovayPloshadka(IWebDriver driver)
	{
		_driver = driver;
		bolshayPolynaDateTime = DateTime.Now;
		malenkiePolynaDateTime = DateTime.Now;
		RabyKypitDateTime = DateTime.Now;
		RabyProdatDateTime = DateTime.Now;
		PylKypitDateTime = DateTime.Now;
		PylProdatDateTime = DateTime.Now;
		rabyDateTime = DateTime.Now;
		MyloKypitDateTime = DateTime.Now;
		RtutKypitDateTime = DateTime.Now;
		YdrenKypitDateTime = DateTime.Now;
	}

	public void MainTorgovayPloshadka()
	{
		try
		{
			BolshayPolynaKypit();
		}
		catch
		{
			bolshayPolynaDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			MalenkiePolynaKypit();
		}
		catch
		{
			malenkiePolynaDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			RabyKypit();
		}
		catch
		{
			RabyKypitDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			RabyProdat();
		}
		catch
		{
			RabyProdatDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			PylKypit();
		}
		catch
		{
			PylKypitDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			MyloKypit();
		}
		catch
		{
			PylKypitDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			PylProdat();
		}
		catch
		{
			PylProdatDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			RtutKupit();
		}
		catch
		{
			RtutKypitDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			YdrenKypit();
		}
		catch
		{
			YdrenKypitDateTime = DateTime.Now.AddMinutes(5.0);
		}
	}

	private void UpdateStatus(string text)
	{
		Find.LabelStatus(text);
	}

	private DateTime BolshayPolynaKypit()
	{
		if (bolshayPolynaDateTime > DateTime.Now)
		{
			return bolshayPolynaDateTime;
		}
		if (!AppSettings.Get("checkBoxKypitBolshiePolyny", defaultValue: false))
		{
			return bolshayPolynaDateTime = DateTime.Now.AddMinutes(5.0);
		}
		if (_driver.ResyKri() < 10000)
		{
			return bolshayPolynaDateTime = DateTime.Now.AddMinutes(30.0);
		}
		UpdateStatus("Покупаем Большие поляны");
		string[] array = _driver.IsFindElement(By.XPath("//li[@id=\"i34\"]")).isGetAttribute("outerText").Split('/');
		int[] array2 = new int[2];
		for (int i = 0; i < array.Length; i++)
		{
			int.TryParse(string.Join("", array[i].Where((char c) => char.IsDigit(c))), out array2[i]);
		}
		if ((double)array2[0] < (double)array2[1] * 0.9)
		{
			int num = array2[1] - array2[0] - 2;
			if (num > 50)
			{
				num = 50;
			}
			TorgPloshadkaPokypka("Билет на большую поляну", num);
		}
		UpdateStatus("");
		return bolshayPolynaDateTime = DateTime.Now.AddMinutes(40.0);
	}

	private DateTime MalenkiePolynaKypit()
	{
		if (malenkiePolynaDateTime > DateTime.Now)
		{
			return malenkiePolynaDateTime;
		}
		if (!AppSettings.Get("checkBoxKypitMalenkiePolyny", defaultValue: false))
		{
			return malenkiePolynaDateTime = DateTime.Now.AddMinutes(5.0);
		}
		if (_driver.ResyKri() < 10000)
		{
			return malenkiePolynaDateTime = DateTime.Now.AddMinutes(30.0);
		}
		UpdateStatus("Покупаем Маленькие поляны");
		string[] array = _driver.IsFindElement(By.XPath("//li[@id=\"i33\"]")).isGetAttribute("outerText").Split('/');
		int[] array2 = new int[2];
		for (int i = 0; i < array.Length; i++)
		{
			int.TryParse(string.Join("", array[i].Where((char c) => char.IsDigit(c))), out array2[i]);
		}
		if ((double)array2[0] < (double)array2[1] * 0.9)
		{
			int num = array2[1] - array2[0] - 2;
			if (num > 50)
			{
				num = 50;
			}
			TorgPloshadkaPokypka("Билет на маленькую", num);
		}
		UpdateStatus("");
		return malenkiePolynaDateTime = DateTime.Now.AddMinutes(40.0);
	}

	private DateTime RabyKypit()
	{
		if (RabyKypitDateTime > DateTime.Now)
		{
			return RabyKypitDateTime;
		}
		if (!AppSettings.Get("checkBoxRabyKypit", defaultValue: false))
		{
			return RabyKypitDateTime = DateTime.Now.AddMinutes(5.0);
		}
		if (_driver.ResyKri() < 10000)
		{
			return RabyKypitDateTime = DateTime.Now.AddMinutes(30.0);
		}
		UpdateStatus("Покупаем Рабов");
		string[] array = _driver.IsFindElement(By.XPath("//li[@id=\"i70\"]")).isGetAttribute("outerText").Split('/');
		int[] array2 = new int[2];
		for (int i = 0; i < array.Length; i++)
		{
			int.TryParse(string.Join("", array[i].Where((char c) => char.IsDigit(c))), out array2[i]);
		}
		if (array2[0] != 0 && array2[0] < 500 && TorgPloshadkaPokypka("Раб людишко", 500))
		{
			UpdateStatus("");
			return RabyKypitDateTime = DateTime.Now.AddMinutes(30.0);
		}
		UpdateStatus("");
		return RabyKypitDateTime = DateTime.Now.AddMinutes(5.0);
	}

	private DateTime RabyProdat()
	{
		if (RabyProdatDateTime > DateTime.Now)
		{
			return RabyProdatDateTime;
		}
		if (!AppSettings.Get("checkBoxRabyProdat", defaultValue: false))
		{
			return RabyProdatDateTime = DateTime.Now.AddMinutes(5.0);
		}
		if (_driver.ResyKri() < 10000)
		{
			return RabyProdatDateTime = DateTime.Now.AddMinutes(30.0);
		}
		UpdateStatus("Продаем Рабов");
		string[] array = _driver.IsFindElement(By.XPath("//li[@id=\"i70\"]")).isGetAttribute("outerText").Split('/');
		int[] array2 = new int[2];
		for (int i = 0; i < array.Length; i++)
		{
			int.TryParse(string.Join("", array[i].Where((char c) => char.IsDigit(c))), out array2[i]);
		}
		if (array2[0] > 150 && TorgPloshadkaProdat("Раб людишко"))
		{
			UpdateStatus("");
			return RabyKypitDateTime = DateTime.Now.AddMinutes(30.0);
		}
		UpdateStatus("");
		return RabyProdatDateTime = DateTime.Now.AddMinutes(30.0);
	}

	private DateTime PylKypit()
	{
		if (PylKypitDateTime > DateTime.Now)
		{
			return PylKypitDateTime;
		}
		if (!AppSettings.Get("checkBoxPylKypit", defaultValue: false))
		{
			return PylKypitDateTime = DateTime.Now.AddMinutes(5.0);
		}
		if (_driver.ResyKri() < 30000)
		{
			return PylKypitDateTime = DateTime.Now.AddMinutes(30.0);
		}
		UpdateStatus("Покупаем Кристальная пыль");
		if (TorgPloshadkaPokypka("Кристальная пыль", 1000))
		{
			UpdateStatus("");
			return PylKypitDateTime = DateTime.Now.AddMinutes(30.0);
		}
		UpdateStatus("");
		return PylKypitDateTime = DateTime.Now.AddMinutes(5.0);
	}

	private DateTime YdrenKypit()
	{
		if (YdrenKypitDateTime > DateTime.Now)
		{
			return YdrenKypitDateTime;
		}
		if (!AppSettings.Get("checkBoxPokypaemYdren", defaultValue: false))
		{
			return YdrenKypitDateTime = DateTime.Now.AddMinutes(5.0);
		}
		if (_driver.ResyKri() < 30000)
		{
			return YdrenKypitDateTime = DateTime.Now.AddMinutes(30.0);
		}
		UpdateStatus("Статус: Ядреная Смесь");
		if (TorgPloshadkaPokypka("Конс. ядрёная смесь", 50))
		{
			UpdateStatus("Статус: ");
			return YdrenKypitDateTime = DateTime.Now.AddMinutes(30.0);
		}
		UpdateStatus("Статус: ");
		return YdrenKypitDateTime = DateTime.Now.AddMinutes(5.0);
	}

	private DateTime RtutKupit()
	{
		if (RtutKypitDateTime > DateTime.Now)
		{
			return RtutKypitDateTime;
		}
		if (!AppSettings.Get("checkBoxPokypaemRtut", defaultValue: false))
		{
			return RtutKypitDateTime = DateTime.Now.AddMinutes(5.0);
		}
		if (_driver.ResyKri() < 40000)
		{
			return RtutKypitDateTime = DateTime.Now.AddMinutes(30.0);
		}
		UpdateStatus("Статус: Покупаем Ртутный порошок");
		if (TorgPloshadkaPokypka("Ртутный порошок", 50))
		{
			UpdateStatus("Статус: ");
			return RtutKypitDateTime = DateTime.Now.AddMinutes(30.0);
		}
		UpdateStatus("Статус: ");
		return RtutKypitDateTime = DateTime.Now.AddMinutes(5.0);
	}

	private DateTime MyloKypit()
	{
		if (MyloKypitDateTime > DateTime.Now)
		{
			return MyloKypitDateTime;
		}
		if (!AppSettings.Get("checkBoxPokypaemMylo", defaultValue: false))
		{
			return MyloKypitDateTime = DateTime.Now.AddMinutes(5.0);
		}
		if (_driver.ResyKri() < 30000)
		{
			return MyloKypitDateTime = DateTime.Now.AddMinutes(30.0);
		}
		UpdateStatus("Статус: Покупаем Мыло");
		if (TorgPloshadkaPokypka("Мыльный камень", 1000))
		{
			UpdateStatus("Статус: ");
			return MyloKypitDateTime = DateTime.Now.AddMinutes(30.0);
		}
		UpdateStatus("Статус: ");
		return MyloKypitDateTime = DateTime.Now.AddMinutes(5.0);
	}

	private DateTime PylProdat()
	{
		if (PylProdatDateTime > DateTime.Now)
		{
			return PylProdatDateTime;
		}
		if (!AppSettings.Get("checkBoxPylProdat", defaultValue: false))
		{
			return PylProdatDateTime = DateTime.Now.AddMinutes(5.0);
		}
		if (_driver.ResyKri() < 10000)
		{
			return PylProdatDateTime = DateTime.Now.AddMinutes(30.0);
		}
		UpdateStatus("Продаем Кристальная пыль");
		string source = _driver.IsFindElement(By.XPath("//li[@id=\"i56\"]")).isGetAttribute("outerText");
		long.TryParse(string.Join("", source.Where((char c) => char.IsDigit(c))), out var result);
		if (result > 10000)
		{
			if (_driver.IsFindElement(By.XPath("//div[@id=\"event_61\"]")).isGetAttribute("outerText") != null && TorgPloshadkaProdat("Кристальная пыль"))
			{
				UpdateStatus("");
				return PylProdatDateTime = DateTime.Now.AddMinutes(5.0);
			}
			if (TorgPloshadkaProdat("Кристальная пыль"))
			{
				UpdateStatus("");
				return PylProdatDateTime = DateTime.Now.AddMinutes(30.0);
			}
		}
		UpdateStatus("");
		return PylProdatDateTime = DateTime.Now.AddMinutes(30.0);
	}

	public bool TorgPloshadkaPokypka(string _st, int _i)
	{
		if (!_driver.Url.Contains("?a=market") && !_driver.IsFindElement(By.XPath("//a[contains(@href,\"harbour.php?a=market\")]")).IsClick("Клик Торговая площадка"))
		{
			Find.WebBrowserLog("Добавить Торговая площадка");
			return false;
		}
		if (_driver.IsFindElement(By.XPath("//a[text()=\"ПОКУПКА\"][not(contains(@class,\"open\"))]")).IsClick("Клик Купить"))
		{
			Thread.Sleep(500);
		}
		if (!_driver.IsFindElement(By.XPath("//select[@id=\"want_to_buy\"]/option[contains(text(),\"" + _st + "\")]")).IsClick("Клик " + _st))
		{
			return false;
		}
		IWebElement webElement = _driver.IsFindElement(By.XPath("//input[@id=\"slider_v_1\"]"));
		if (webElement != null)
		{
			IJavaScriptExecutor javaScriptExecutor = _driver as IJavaScriptExecutor;
			javaScriptExecutor.ExecuteScript("arguments[0].value='" + _i + "';", webElement);
		}
		if (_driver.IsFindElement(By.XPath("//input[@value=\"КУПИТЬ\"][contains(@class,\"cmd_large\")]")).IsClick("Клик Купить"))
		{
			Thread.Sleep(500);
		}
		if (_driver.IsFindElement(By.XPath("//div[@id=\"js_message\"]//..//script[contains(text(),\"С покупочкой\")]")) != null)
		{
			return true;
		}
		return false;
	}

	public bool TorgPloshadkaProdat(string _st)
	{
		if (!_driver.Url.Contains("?a=market") && !_driver.IsFindElement(By.XPath("//a[contains(@href,\"harbour.php?a=market\")]")).IsClick("Клик Торговая площадка"))
		{
			Find.WebBrowserLog("Добавить Торговая площадка");
			return false;
		}
		if (_driver.IsFindElement(By.XPath("//a[text()=\"ПРОДАЖА\"][not(contains(@class,\"open\"))]")).IsClick("Клик Продать"))
		{
			Thread.Sleep(500);
		}
		if (_driver.IsFindElement(By.XPath("//div[contains(text(),\"" + _st + "\")]/../../..//a[contains(@href,\"SetMax\")]")).IsClick("Клик SetMax"))
		{
			Thread.Sleep(500);
		}
		if (_driver.IsFindElement(By.XPath("//input[@value=\"ВЫСТАВИТЬ\"][contains(@class,\"cmd_large\")]")).IsClick("Клик ВЫСТАВИТЬ"))
		{
			Thread.Sleep(500);
		}
		if (_driver.IsFindElement(By.XPath("//div[@id=\"js_message\"]//..//script[contains(text(),\"Товар выставлен\")]")) != null)
		{
			return true;
		}
		return false;
	}
}
