using System.Windows.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Botva2025.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Botva2025;

public class Pomogashki
{
	private IWebDriver _driver;

	private DateTime LogInDatetime;

	private Form1 _mainForm;

	private long KachMinCena;

	private Control[] arControl;

	private DateTime KachDateTime { get; set; }

	private DateTime AuthenticateDateTime { get; set; }

	public Pomogashki(IWebDriver driver, Form1 mainForm)
	{
		_driver = driver;
		KachDateTime = DateTime.Now;
		AuthenticateDateTime = DateTime.Now;
		LogInDatetime = DateTime.Now;
		_mainForm = mainForm;
		arControl = (Control[])(object)new Control[5]
		{
			(Control)_mainForm.labelName,
			(Control)_mainForm.labelZoloto,
			(Control)_mainForm.labelKri,
			(Control)_mainForm.labelPir,
			(Control)_mainForm.labelZelen
		};
	}

	public void Authenticate()
	{
		if (AuthenticateDateTime > DateTime.Now)
		{
			return;
		}
		try
		{
			_driver.Navigate().GoToUrl("http://" + BotState.UrlLogin[AppSettings.Get("userServer", 0)] + "botva.ru");
			AuthenticateDateTime = DateTime.Now.AddMinutes(10.0);
			Resy();
		}
		catch (WebDriverException)
		{
			string baseDirectory = AppContext.BaseDirectory;
		}
		catch (ObjectDisposedException)
		{
		}
		catch
		{
			AuthenticateDateTime = DateTime.Now.AddMinutes(10.0);
		}
	}

	public IWebElement isFindElement(IWebDriver _driver, By by)
	{
		IWebElement result = null;
		try
		{
			result = _driver.FindElement(by);
			return result;
		}
		catch (NoSuchElementException)
		{
			return result;
		}
	}

	public bool LogIn(string login, string password, int i)
	{
		if (_driver == null)
		{
			return false;
		}
		Form1 form = Application.OpenForms[0] as Form1;
		if (LogInDatetime > DateTime.Now)
		{
			return false;
		}
		LogInDatetime = DateTime.Now.AddMinutes(1.0);
		try
		{
			SetNotifyIconText(_driver.FindElement(By.ClassName("name")).GetAttribute("innerText"));
			ToggleFormPanels(form, panel1Visible: false);
			Resy();
			return true;
		}
		catch
		{
			try
			{
				_driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20L);
				_driver.FindElement(By.ClassName("sign_in")).Click();
				_driver.IsFindElement(By.XPath("//*[@id='auth_form_email']//option[" + (i + 1) + "]")).IsClick();
				_driver.IsFindElement(By.Name("email")).IsClear();
				_driver.IsFindElement(By.Name("email")).IsSendKeys(login);
				_driver.IsFindElement(By.Name("password")).Clear();
				_driver.IsFindElement(By.Name("password")).SendKeys(password);
				_driver.IsFindElement(By.XPath("//form[@action=\"login.php\"]//input[@value=\"Вход\"]")).IsClick();
				WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5L));
				webDriverWait.Until(ExpectedConditions.ElementExists(By.ClassName("name")));
				_driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5L);
				Resy();
				ToggleFormPanels(form, panel1Visible: false);
				try
				{
					SetNotifyIconText(_driver.FindElement(By.ClassName("name")).GetAttribute("innerText"));
					Resy();
					return true;
				}
				catch
				{
					ToggleFormPanels(form, !((Control)form.panel1).Visible);
					return false;
				}
			}
			catch
			{
				try
				{
					SetNotifyIconText(_driver.FindElement(By.ClassName("name")).GetAttribute("innerText"));
					Resy();
					return true;
				}
				catch
				{
					Authenticate();
					Resy();
					return false;
				}
			}
		}
	}

	private void SetNotifyIconText(string text)
	{
		Form1 form = ((IEnumerable)Application.OpenForms).OfType<Form1>().FirstOrDefault();
		if (form != null)
		{
			form.notifyIcon1.Text = text;
		}
	}

	private void ToggleFormPanels(Form1 mainForm, bool panel1Visible)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		if (mainForm != null)
		{
			((Control)mainForm.panel2).Invoke((Delegate)(System.Windows.Forms.MethodInvoker)delegate
			{
				((Control)mainForm.panel2).Visible = panel1Visible;
			});
			((Control)mainForm.panel1).Invoke((Delegate)(System.Windows.Forms.MethodInvoker)delegate
			{
				((Control)mainForm.panel1).Visible = !panel1Visible;
			});
		}
	}

	public string ResyKri()
	{
		return _driver.ResyKri().ToString();
	}

	public string ResyMoneyString()
	{
		return _driver.ResyZoloto().ToString();
	}

	public int Resy()
	{
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		string[] arString = new string[5]
		{
			arControl[0].Text,
			arControl[1].Text,
			arControl[2].Text,
			arControl[3].Text,
			arControl[4].Text
		};
		try
		{
			arString[0] = _driver.nikName();
			Form1 form = ((IEnumerable)Application.OpenForms).OfType<Form1>().FirstOrDefault();
			if (form == null)
			{
				return 0;
			}
			((Control)form).Invoke((Delegate)(System.Windows.Forms.MethodInvoker)delegate
			{
				if (((Control)form).Text != arString[0] + " Авто кликер Ботва")
				{
					((Control)form).Text = arString[0] + " Авто кликер Ботва";
				}
			});
			arString[2] = ResyKri();
			arString[1] = ResyMoneyString();
			arString[3] = _driver.ResyPiraShki().ToString();
			try
			{
				arString[4] = _driver.IsFindElement(By.Id("green_upd_data")).isGetAttribute("outerText").Replace(".", "")
					.Replace("\r\n", "")
					.Replace("зелень:", "");
			}
			catch
			{
			}
			int i;
			for (i = 0; i < 5; i++)
			{
				arControl[i].Invoke((Delegate)(System.Windows.Forms.MethodInvoker)delegate
				{
					arControl[i].Text = arString[i];
				});
			}
			return 1;
		}
		catch
		{
			Authenticate();
			return 0;
		}
	}

	public void _KachDateTime()
	{
		KachDateTime = DateTime.Now;
		KachMinCena = 0L;
	}

	public void _KachMain()
	{
		try
		{
			Kach();
		}
		catch
		{
			KachDateTime = DateTime.Now.AddMinutes(10.0);
		}
	}

	public void _kachPirashki()
	{
		try
		{
			KachPirashki();
		}
		catch
		{
		}
	}

	private void KachPirashki()
	{
		if (!AppSettings.Get("checkBoxKachPirashki", defaultValue: false))
		{
			return;
		}
		bool[] array = new bool[5]
		{
			AppSettings.Get("checkBoxKach1", defaultValue: false),
			AppSettings.Get("checkBoxKach2", defaultValue: false),
			AppSettings.Get("checkBoxKach3", defaultValue: false),
			AppSettings.Get("checkBoxKach4", defaultValue: false),
			AppSettings.Get("checkBoxKach5", defaultValue: false)
		};
		string[] array2 = new string[5] { "power", "block", "dexterity", "endurance", "charisma" };
		UpdateStatus("Статус: Качать Статы Пирашки");
		if (_driver.TimerRabota(out var _))
		{
			UpdateStatus("Статус:");
			AppSettings.Set("checkBoxKachPirashki", false);
			return;
		}
		if (!_driver.Url.Contains("botva.ru/index.php"))
		{
			_driver.isExecuteScriptClick(By.Id("m1"), "Персонаж");
		}
		_driver.IsFindElement(By.XPath("//div[contains(@class,\"abilities_container\")]//span[@class=\"dlink\"]")).IsClick("Клик характеристики");
		_driver.IsFindElement(By.XPath("//div[contains(@class,\"training_tab_2\")]")).IsClick("Клик пирашки");
		for (int i = 0; i < 1000; i++)
		{
			if (_driver.ResyPiraShki() < 10000)
			{
				AppSettings.Set("checkBoxKachPirashki", false);
				UpdateStatus("Статус:");
				return;
			}
			long[] array3 = new long[5];
			for (int j = 0; j < 5; j++)
			{
				if (array[j])
				{
					string source = _driver.IsFindElement(By.XPath("//span[@id=\"price_" + array2[j] + "\"]")).isGetAttribute("outerText");
					long.TryParse(string.Join("", source.Where((char c) => char.IsDigit(c))), out array3[j]);
				}
			}
			Array.Sort(array3, array2);
			string text = "";
			for (int num = 0; num < 5; num++)
			{
				if (array3[num] != 0L)
				{
					KachMinCena = array3[num];
					text = array2[num];
					break;
				}
			}
			string xpathToFind = "//input[@id='" + text + "']";
			_driver.IsFindElement(By.XPath(xpathToFind)).IsClear();
			_driver.IsFindElement(By.XPath(xpathToFind)).IsSendKeys("99999" + Keys.Enter);
		}
		AppSettings.Set("checkBoxKachPirashki", false);
		UpdateStatus("Статус:");
	}

	private DateTime Kach()
	{
		long num = 4294967295L;
		bool[] array = new bool[5]
		{
			AppSettings.Get("checkBoxKach1", defaultValue: false),
			AppSettings.Get("checkBoxKach2", defaultValue: false),
			AppSettings.Get("checkBoxKach3", defaultValue: false),
			AppSettings.Get("checkBoxKach4", defaultValue: false),
			AppSettings.Get("checkBoxKach5", defaultValue: false)
		};
		string[] array2 = new string[5] { "power", "block", "dexterity", "endurance", "charisma" };
		long[] array3 = new long[5];
		double procent = 0.95;
		if (KachDateTime > DateTime.Now)
		{
			return KachDateTime;
		}
		if (!AppSettings.Get("checkBoxKach", defaultValue: false))
		{
			KachDateTime = DateTime.Now.AddSeconds(10.0);
			return KachDateTime;
		}
		double.TryParse(ResyMoneyString(), out var zolotoSvoe);
		if (zolotoSvoe * procent < (double)KachMinCena)
		{
			KachDateTime = DateTime.Now.AddMinutes(5.0);
			return KachDateTime;
		}
		UpdateStatus("Статус: Качать Статы");
		if (_driver.TimerRabota(out var _))
		{
			UpdateStatus("Статус:");
			return KachDateTime = DateTime.Now.AddMinutes(1.0);
		}
		if (!_driver.Url.Contains("botva.ru/index.php"))
		{
			_driver.isExecuteScriptClick(By.Id("m1"), "Персонаж");
		}
		if (_driver.IsFindElement(By.XPath("//div[contains(@class,\"abilities_container\")]//span[@class=\"dlink\"]")).IsClick("Клик характеристики"))
		{
			_driver.WaitFind(By.XPath("//span[@id=\"path_price_gold_power\"]"), TimeSpan.FromSeconds(3L));
		}
		double num2 = 0.0;
		int num3 = 0;
		while (true)
		{
			double.TryParse(ResyMoneyString(), out zolotoSvoe);
			if (num2 == zolotoSvoe)
			{
				num3++;
			}
			num2 = zolotoSvoe;
			if (num3 > 3)
			{
				break;
			}
			List<(long, string, long)> list = new List<(long, string, long)>();
			for (int i = 0; i < 5; i++)
			{
				if (!array[i])
				{
					continue;
				}
				long result = 0L;
				long.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//span[@id=\"path_price_gold_" + array2[i] + "\"]//..//..//..//td[@class=\"stat_nw font_brown bold\"]")).isGetAttribute("outerText")
					where char.IsDigit(c)
					select c), out result);
				if (result < num)
				{
					string text = _driver.IsFindElement(By.XPath("//span[@id=\"path_price_gold_" + array2[i] + "\"]")).isGetAttribute("outerText");
					if (_driver.IsFindElement(By.XPath("//span[@id=\"path_price_gold_" + array2[i] + "\"]//b[@class=\"icon money_ingots_small\"]")) != null)
					{
						text += "000000";
					}
					if (long.TryParse(string.Join("", text.Where((char c) => char.IsDigit(c))), out var result2) && result2 != 0L)
					{
						list.Add((result2, array2[i], result));
					}
				}
			}
			if (!list.Any())
			{
				num3++;
				continue;
			}
			List<(long, string, long)> source = list.OrderBy<(long, string, long), long>(((long Price, string StatName, long Stat_nw) x) => x.Price).ToList();
			string text2 = "";
			string text3 = "";
			string text4 = "";
			double num4 = 0.0;
			long num5 = 0L;
			long num6 = 0L;
			long num7 = 0L;
			(long, string, long) tuple = source.First();
			KachMinCena = tuple.Item1;
			text2 = tuple.Item2;
			num7 = tuple.Item3;
			(long, string, long) tuple2 = source.LastOrDefault<(long, string, long)>(((long Price, string StatName, long Stat_nw) x) => (double)x.Price <= zolotoSvoe * procent);
			(long, string, long) tuple3 = tuple2;
			if (tuple3.Item1 != 0L || tuple3.Item2 != null || tuple3.Item3 != 0L)
			{
				num4 = tuple2.Item1;
				text3 = tuple2.Item2;
				num6 = tuple2.Item3;
			}
			double num8 = 0.0;
			if (AppSettings.Get("checkBoxKachMax", defaultValue: false) && num4 != 0.0)
			{
				num8 = num4;
				text4 = text3;
				num5 = num6;
			}
			else
			{
				num8 = KachMinCena;
				text4 = text2;
				num5 = num7;
			}
			double num9 = Math.Floor(zolotoSvoe * procent / num8);
			if (num9 == 0.0)
			{
				break;
			}
			if (num9 > 999999.0)
			{
				num9 = 999998.0;
			}
			if (num9 + (double)num5 > (double)num)
			{
				num9 = num - num5;
			}
			if (num8 < zolotoSvoe)
			{
				IWebElement elem = _driver.IsFindElement(By.XPath("//input[@id=\"path_input_gold_" + text4 + "\"]"));
				elem.IsClear();
				elem.IsSendKeys(num9.ToString());
				_driver.IsFindElement(By.XPath("//div[@id=\"buy_block_1\"]")).IsClick("buy_block_1");
				if (_driver.IsFindElement(By.XPath("//span[@id=\"path_gold_total_price\"]")).isGetAttribute("outerText") != "0 ")
				{
					_driver.IsFindElement(By.XPath("//form[@name=\"training_gold_form\"]//input[@value=\"ТРЕНИРОВАТЬСЯ\"]")).IsClick("Качать " + text4 + " " + num9);
				}
			}
		}
		_driver.IsFindElement(By.XPath("//div[@class=\"popup\"]//span[@class=\"close\"]")).IsClick("Закрыть ");
		UpdateStatus("Статус:");
		if (KachMinCena == 0L)
		{
			KachDateTime = DateTime.Now.AddMinutes(10.0);
		}
		else
		{
			KachDateTime = DateTime.Now.AddMinutes(1.0);
		}
		return KachDateTime;
	}

	private void UpdateStatus(string v)
	{
		Find.LabelStatus(v);
	}
}
