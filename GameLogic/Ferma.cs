using System;
using OpenQA.Selenium;

namespace Botva2025;

public class Ferma
{
	private readonly IWebDriver driver;

	public DateTime fermaDateTime;

	public Ferma(IWebDriver _driver)
	{
		driver = _driver;
		fermaDateTime = DateTime.Now;
	}

	public void FermaGo()
	{
		Find.LabelStatus("Статус: Ферма");
		if (!FermaRabota())
		{
			driver.isExecuteScriptClick(By.Id("m3"), "Клик Деревня", 1000);
			driver.isExecuteScriptClick(By.XPath("//a[contains(@href,\"farm.php\")]"), "Клик Ферма", 1000);
			driver.IsFindElement(By.XPath("//input[@value=\"РАБОТАТЬ\"]")).IsClick("Ферма Работать", 1000);
			if (!FermaRabota())
			{
				Find.LabelStatus("Статус:");
				fermaDateTime = DateTime.Now.AddMinutes(5.0);
			}
		}
	}

	private bool FermaRabota()
	{
		IWebElement webElement = driver.IsFindElement(By.XPath("//div[@id=\"rmenu1\"]/div/a[@class=\"timer link\"]/span"));
		if (webElement != null)
		{
			Find.LabelStatus("Статус:");
			fermaDateTime = DateTime.Now.AddMinutes(1.0);
			return true;
		}
		return false;
	}
}
