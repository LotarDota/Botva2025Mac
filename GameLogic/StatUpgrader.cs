using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Botva2025;

public class StatUpgrader
{
	private static IWebDriver _driver;

	private string[] stats = new string[5] { "power", "block", "dexterity", "endurance", "charisma" };

	private readonly Func<bool[]> _getEnabledStats;

	private readonly Func<bool> _getStatsStop;

	public BigInteger ZolotoForKach = 0;

	private bool[] enabledStats;

	private const long StatMaxValue = 4294967295L;

	private const int MaxErrorCount = 3;

	public StatUpgrader(IWebDriver driver, Func<bool> getStatsStop, Func<bool[]> getEnabledStats)
	{
		_driver = driver;
		_getStatsStop = getStatsStop;
		_getEnabledStats = getEnabledStats;
		enabledStats = Array.Empty<bool>();
	}

	public void UpgradeStats()
	{
		bool flag = _getStatsStop();
	}

	public void AvatarKach()
	{
		if (!_getStatsStop())
		{
			return;
		}
		BigInteger bigInteger = _driver.ResyZoloto();
		BigInteger bigInteger2 = 0;
		if (ZolotoForKach * 10 > bigInteger * 8)
		{
			return;
		}
		Find.LabelStatus("Статус:Аватар Качалка");
		enabledStats = _getEnabledStats();
		int num = 0;
		_driver.isExecuteScriptClick(By.Id("m1"), "Клик Персонаж");
		IWebElement webElement = null;
		try
		{
			webElement = _driver.IsFindElement(By.XPath("//div[@onclick=\"avatar_training_tabs_handler.click(1001)\"][@class=\"btn\"]"));
			if (webElement != null && webElement.IsClick("Тренировка"))
			{
				Thread.Sleep(500);
			}
		}
		catch (Exception)
		{
		}
		bool flag = _getStatsStop();
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		string xpathToFind = "//div[contains(@class,\"button_power\")  or contains(@class,\"button_block\") or contains(@class,\"button_dexterity\") or contains(@class,\"button_endurance\") or contains(@class,\"button_charisma\")][not(contains(@class,\"cmd_blocked\"))]";
		if (_driver.IsFindElement(By.XPath(xpathToFind)) == null)
		{
			flag = false;
		}
		for (; flag && !(stopwatch.Elapsed.TotalHours >= 1.0); flag = _getStatsStop())
		{
			_driver.WaitFind(By.XPath(xpathToFind), TimeSpan.FromSeconds(5L));
			try
			{
				bigInteger = _driver.ResyZoloto();
				num = ((bigInteger2 == bigInteger) ? (num + 1) : 0);
				if (num >= 3)
				{
					break;
				}
				bigInteger2 = bigInteger;
				string text = _driver.IsFindElement(By.XPath("//div[@rel=\"1001\"][@class=\"tab\"]"))?.GetAttribute("outerHTML")?.Replace(".", "") ?? "";
								var list = stats.Select<string, _003C_003Ef__AnonymousType6<string, long, long>?>((text2, idx) =>
				{
					try
					{
						if (!enabledStats[idx])
						{
							return null;
						}
						string s = _driver.FindElement(By.XPath("//div[@class=\"ability_hud_container\"]/div[contains(@class,'avatar_stat_" + text2 + "')]"))?.Text.Replace(".", "");
						if (!long.TryParse(s, out var result))
						{
							return null;
						}
						string text3 = _driver.FindElement(By.XPath("//div[@rel=\"1001\"]//span[contains(@class,'avatar_price_" + text2 + "')]"))?.Text ?? "";
						if (_driver.FindElements(By.XPath("//div[@rel=\"1001\"]//span[contains(@class,'avatar_price_" + text2 + "')]//b[@class=\"icon money_ingots_small\"]")).Any())
						{
							text3 += "000";
						}
						if (long.TryParse(new string(text3.Where(char.IsDigit).ToArray()), out var result2))
						{
							return new _003C_003Ef__AnonymousType6<string, long, long>(text2, result, result2);
						}
						return null;
					}
					catch (Exception)
					{
						return null;
					}
				})
				.Where(x => x != null)
				.OrderBy(x => x!.Price)
				.ToList();
				if (list.Count == 0)
				{
					break;
				}
				var anon = list.First();
				ZolotoForKach = anon.Price;
				string stat = anon.Stat;
				if (ZolotoForKach > bigInteger)
				{
					Find.LabelStatus("Статус:");
					return;
				}
				BigInteger trainingAmount = bigInteger / ZolotoForKach;
				_driver.WaitFind(By.XPath("//div[contains(@class,\"button_power\")][not(contains(@class,\"cmd_blocked\"))]"), TimeSpan.FromSeconds(5L));
				TrainStat(stat, trainingAmount);
				continue;
			}
			catch (Exception)
			{
				num++;
				if (num >= 3)
				{
					break;
				}
				continue;
			}
		}
		Find.LabelStatus("Статус:");
	}

	private BigInteger GetEnduranceStatCount(By by)
	{
		try
		{
			IWebElement webElement = _driver.FindElement(by);
			if (webElement == null)
			{
				return BigInteger.Zero;
			}
			string text = webElement.Text;
			if (string.IsNullOrEmpty(text))
			{
				return BigInteger.Zero;
			}
			string value = text.Replace(".", "");
			if (BigInteger.TryParse(value, out var result))
			{
				return result;
			}
			return BigInteger.Zero;
		}
		catch (NoSuchElementException)
		{
			return BigInteger.Zero;
		}
		catch (Exception)
		{
			return BigInteger.Zero;
		}
	}

	private void TrainStat(string statToTrain, BigInteger trainingAmount)
	{
		BigInteger enduranceStatCount = GetEnduranceStatCount(By.XPath("//div[contains(@class,'avatar_stat_" + statToTrain + "')]"));
		BigInteger bigInteger = new BigInteger(4294967295L);
		if (enduranceStatCount + trainingAmount > bigInteger)
		{
			trainingAmount = bigInteger - enduranceStatCount;
			if (trainingAmount <= 0L)
			{
				int num = Array.IndexOf(stats, statToTrain);
				if (num >= 0 && num < enabledStats.Length)
				{
					enabledStats[num] = false;
				}
				return;
			}
		}
		if (trainingAmount < 99999L && enduranceStatCount + trainingAmount < bigInteger)
		{
			if (!SelectStat(statToTrain))
			{
				return;
			}
			PerformTraining(statToTrain, 5);
			if (trainingAmount > 20L && _driver.PageSource.Contains("Нужно больше ресурсов!"))
			{
				SelectStat(statToTrain);
				for (int i = 0; i < 10; i++)
				{
					_driver.IsFindElement(By.XPath("//i[contains(@onclick,\"" + statToTrain + "\")][@class='iconx minus']"))?.IsClick("Выбираю минус " + statToTrain);
				}
				PerformTraining(statToTrain, 5);
			}
		}
		else
		{
			Kach_Post(statToTrain, trainingAmount);
		}
	}

	private bool SelectStat(string statToTrain)
	{
		try
		{
			return _driver.IsFindElement(By.XPath("//a[contains(@onclick,\"setMaxStatAvatar('" + statToTrain + "\")]"))?.IsClick("Выбираю " + statToTrain) ?? false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private void PerformTraining(string statToTrain, int sleep)
	{
		try
		{
			_driver.WaitFind(By.XPath("//div[contains(@class,\"button_power\")][not(contains(@class,\"cmd_blocked\"))]"), TimeSpan.FromSeconds(sleep));
			if (_driver.IsFindElement(By.XPath("//div[contains(@class,'button_" + statToTrain + "')][not(contains(@class,'cmd_blocked'))]")).IsClick("Тренирую " + statToTrain, 1000))
			{
				_driver.WaitFind(By.XPath("//div[contains(@class,\"button_power\")][not(contains(@class,\"cmd_blocked\"))]"), TimeSpan.FromSeconds(sleep));
			}
		}
		catch (Exception)
		{
		}
	}

	private bool Kach_Post(string statToTrain, BigInteger trainingAmount)
	{
		List<(BigInteger, int, int)> limits = new List<(BigInteger, int, int)>
		{
			(24999999, 120, 8),
			(9999999, 60, 7),
			(999999, 30, 6),
			(99999, 10, 5)
		};
		var (value, num, num2) = GetTrainingLimits(limits, trainingAmount);
		Find.WebBrowserLog("Качаю Post " + statToTrain + " " + value);
		string initialGoldValue = _driver.IsFindElement(By.Id("gold_upd_data")).Text;
		IJavaScriptExecutor javaScriptExecutor = _driver as IJavaScriptExecutor;
		string script = $"\r\n    $.post('index.php?a=basic', {{ \r\n        k: KEY,\r\n        gold_{statToTrain}: '{value}',\r\n        cmd: 'do_upgrade_gold_fast',\r\n        do_content_as_json: '1'\r\n    }},\r\n    function(result) {{\r\n\r\n        // Обновляем отображение золота на странице\r\n        var goldElement = document.getElementById('gold_upd_data');\r\n        if (goldElement) {{\r\n            var newValue = result.update.gold.data; // Предполагаем, что сервер возвращает новое значение\r\n            goldElement.textContent = newValue.toLocaleString(); // Форматируем с разделителями\r\n            var valueWithoutDots = newValue.toString().replace(/\\./g, ''); // Удаляем все точки\r\n            goldElement.setAttribute('data-value', valueWithoutDots);\r\n        }}\r\n\r\n        // Проверяем, что ответ сервера содержит данные\r\n        if (result.update && result.update.body && result.update.body.data) {{\r\n            try {{\r\n                // Создаем временный элемент для парсинга HTML\r\n                const tempDiv = document.createElement('div');\r\n                tempDiv.innerHTML = result.update.body.data;\r\n\r\n                // Ищем элемент, содержащий статы\r\n                const statElement = tempDiv.querySelector('.avatar_stat_{statToTrain}');       \r\n                if (statElement) {{\r\n                    // Находим элемент на странице, куда будем вставлять стат\r\n                    var avatar_stat = document.querySelector('.avatar_stat_{statToTrain}');\r\n                    if (avatar_stat) {{\r\n                        // Обновляем содержимое элемента\r\n                        avatar_stat.innerHTML = statElement.innerHTML; // Исправлено на innerHTML\r\n                    }} else {{\r\n                        console.error('Элемент для обновления стата не найден на странице');\r\n                    }}\r\n                }} else {{\r\n                    console.error('Не удалось найти элемент с статами в HTML');\r\n                }}\r\n            }} catch (e) {{\r\n                console.error('Ошибка при парсинге HTML:', e);\r\n            }}\r\n\r\n                const tempDiv = document.createElement('div');\r\n                tempDiv.innerHTML = result.update.body.data;\r\n\r\n\r\n            // Ищем элемент, содержащий цены\r\n            const priceElement = tempDiv.querySelector('.ability_price.avatar_price_{statToTrain}');       \r\n            if (priceElement) {{\r\n                // Находим элемент на странице, куда будем вставлять цену\r\n                var avatar_price = document.querySelector('.ability_price.avatar_price_{statToTrain}');\r\n                if (avatar_price) {{\r\n                    // Обновляем содержимое элемента\r\n                    avatar_price.innerHTML = priceElement.innerHTML; // Исправлено на innerHTML\r\n                }} else {{\r\n                    console.error('Элемент для обновления цены не найден на странице');\r\n                }}\r\n            }} else {{\r\n                console.error('Не удалось найти элемент с ценами в HTML');\r\n            }}\r\n        }} else {{\r\n            console.error('Некорректная структура ответа сервера');\r\n        }}\r\n\r\n        KEY = result.data.key;\r\n\r\n    }},\r\n    'JSON');\r\n    return KEY;";
		string text = javaScriptExecutor.ExecuteScript(script).ToString();
		WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(num));
		webDriverWait.Until(delegate(IWebDriver driver)
		{
			try
			{
				IWebElement webElement = driver.FindElement(By.Id("gold_upd_data"));
				string text2 = webElement.Text;
				return !string.IsNullOrEmpty(text2) && text2 != initialGoldValue;
			}
			catch
			{
				return false;
			}
		});
		Thread.Sleep(1000);
		return true;
	}

	private (BigInteger appliedMax, int sleepTime, int maxLength) GetTrainingLimits(List<(BigInteger MaxTraining, int SleepMs, int MaxLength)> limits, BigInteger trainingAmount)
	{
		BigInteger bigInteger = trainingAmount;
		int num = 0;
		int num2 = 0;
		foreach (var (bigInteger2, num3, num4) in limits)
		{
			if (trainingAmount > bigInteger2)
			{
				bigInteger = bigInteger2;
				num = num3;
				num2 = num4;
				break;
			}
		}
		if (trainingAmount < bigInteger)
		{
			bigInteger = trainingAmount;
		}
		if (num == 0 || num2 == 0)
		{
			num2 = 5;
			bigInteger = trainingAmount;
		}
		return (appliedMax: bigInteger, sleepTime: num, maxLength: num2);
	}

	private int SetTrainingAmount(string statToTrain, BigInteger trainingAmount)
	{
		List<(BigInteger, int, int)> limits = new List<(BigInteger, int, int)>
		{
			(9999999, 180, 7),
			(999999, 50, 6),
			(99999, 10, 5)
		};
		(BigInteger appliedMax, int sleepTime, int maxLength) trainingLimits = GetTrainingLimits(limits, trainingAmount);
		BigInteger item = trainingLimits.appliedMax;
		int item2 = trainingLimits.sleepTime;
		int item3 = trainingLimits.maxLength;
		string xpathToFind = "//input[@class=\"stat\"][@id=\"" + statToTrain + "\"]";
		IWebElement webElement = _driver.IsFindElement(By.XPath(xpathToFind));
		if (webElement != null)
		{
			try
			{
				WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(item2));
				webElement = webDriverWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpathToFind)));
				_driver.ExecuteJavaScript($"document.getElementById('{statToTrain}').setAttribute('maxlength', '{item3}');");
				webElement.IsClear();
				webElement.IsSendKeys(item.ToString());
				Thread.Sleep(1000);
				webElement = webDriverWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpathToFind)));
			}
			catch (Exception)
			{
				WebDriverWait webDriverWait2 = new WebDriverWait(_driver, TimeSpan.FromSeconds(item2));
				webElement = webDriverWait2.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpathToFind)));
			}
		}
		return item2;
	}
}
