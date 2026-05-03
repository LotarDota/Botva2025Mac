using System.Windows.Forms;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Botva2025.Services;
using OpenQA.Selenium;

namespace Botva2025;

public class Taverna
{
	private IWebDriver _driver;

	private IWebElement elem;

	private DateTime dateTime;

	public DateTime tavernaVoynyDateTime { get; set; }

	public DateTime tavernaPirashkaDateTime { get; set; }

	public DateTime tavernaBotolsDateTime { get; set; }

	public DateTime tavernaLuchsheHyjeDateTime { get; set; }

	public DateTime tavernaYarmarkaDateTime { get; set; }

	public Taverna(IWebDriver driver)
	{
		tavernaVoynyDateTime = AppSettings.Get("tavernaVoynyDateTime", DateTime.Now);
		tavernaPirashkaDateTime = AppSettings.Get("tavernaPirashkaDateTime", DateTime.Now);
		tavernaBotolsDateTime = AppSettings.Get("tavernaBotolsDateTime", DateTime.Now);
		tavernaLuchsheHyjeDateTime = AppSettings.Get("tavernaLuchsheHyjeDateTime", DateTime.Now);
		tavernaYarmarkaDateTime = DateTime.Now;
		_driver = driver;
	}

	public void MainZvezdopad()
	{
		try
		{
			Ferma();
		}
		catch
		{
			tavernaVoynyDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			Pirashka();
		}
		catch
		{
			tavernaPirashkaDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			TavernaBotols();
		}
		catch
		{
			tavernaBotolsDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			LuchsheHyje();
		}
		catch
		{
			tavernaLuchsheHyjeDateTime = DateTime.Now.AddMinutes(5.0);
		}
		try
		{
			YarmarkaKoleso();
		}
		catch
		{
			tavernaYarmarkaDateTime = DateTime.Now.AddMinutes(5.0);
		}
	}

	public DateTime YarmarkaKoleso()
	{
		if (tavernaYarmarkaDateTime > DateTime.Now)
		{
			return tavernaYarmarkaDateTime;
		}
		if (!AppSettings.Get("checkBoxTavernaYarmarka", defaultValue: false))
		{
			return tavernaYarmarkaDateTime = DateTime.Now.AddMinutes(5.0);
		}
		UpdateStatus("Статус: Ярмарка  Колесо Фартуны");
		if (!_driver.IsFindElement(By.XPath("//div[@class='scroll']//div[@id='event_85']")).IsClick("Крутить Колесо"))
		{
			UpdateStatus("Статус: ");
			return tavernaYarmarkaDateTime = DateTime.Now.AddMinutes(30.0);
		}
		for (int i = 0; i < 10; i++)
		{
			if (_driver.IsFindElement(By.XPath("//div[not(contains(@class,'cmd_blocked'))]/span[contains(text(),'КРУТИСЬ КОЛЕСО!')]")).IsClick("Крутить Колесо! " + (i + 1), 1000))
			{
				_driver.WaitFind(By.XPath("//div[not(@style)]/span[@id='button1_2' and text()='Ура!']"), TimeSpan.FromSeconds(5L));
			}
			_driver.IsFindElement(By.XPath("//div[not(@style)]/span[@id='button1_2' and text()='Ура!']")).IsClick("Ура! " + (i + 1), 1000);
		}
		UpdateStatus("Статус: ");
		return tavernaYarmarkaDateTime = DateTime.Now.AddMinutes(30.0);
	}

	public DateTime Ferma()
	{
		if (tavernaVoynyDateTime > DateTime.Now)
		{
			return tavernaVoynyDateTime;
		}
		if (!AppSettings.Get("checkBoxTavernaVoyna", defaultValue: false))
		{
			return tavernaVoynyDateTime = DateTime.Now.AddMinutes(5.0);
		}
		if (_driver.ResyKri() < 1000)
		{
			return tavernaVoynyDateTime = DateTime.Now.AddMinutes(5.0);
		}
		UpdateStatus("Статус: Таверна Выбери Война");
		if (!_driver.IsFindElement(By.XPath("//a[contains(@href,\"tavern.php\")]")).IsClick("Тверна"))
		{
			Find.WebBrowserLog("Добавить Таверну в верхнее меню");
			UpdateStatus("Статус:");
			return tavernaVoynyDateTime = DateTime.Now.AddMinutes(5.0);
		}
		_driver.IsFindElement(By.XPath("//div[contains(text(),\"Звездопад\")]")).IsClick("Звездопад");
		this.dateTime = _driver.DateTimeCount("//div[@id=\"starfall_game_counter_1\"]");
		if (this.dateTime > DateTime.Now)
		{
			if ((this.dateTime - DateTime.Now).TotalHours > 50.0)
			{
				UpdateStatus("Статус:");
				return tavernaVoynyDateTime = this.dateTime.AddMinutes(1.0);
			}
			AppSettings.Set("tavernaVoynyDateTime", this.dateTime.AddMinutes(1.0));
			UpdateStatus("Статус:");
			return tavernaVoynyDateTime = this.dateTime.AddMinutes(1.0);
		}
		_driver.IsFindElement(By.XPath("//select[@id=\"select_game_1\"]/option[2]")).IsClick("Выбрать 3 за 1000");
		_driver.IsFindElement(By.XPath("//span[@id=\"cost_type_1\"]//..//input[@value=\"ИГРАТЬ\"]")).IsClick("Клик играть 1");
		string text = "";
		bool game_star_bool = true;
		for (int i = 0; i < 30; i++)
		{
			string text2 = Regex.Replace(_driver.IsFindElement(By.XPath("//div[contains(@class,\"need_human type\")]")).isGetAttribute("outerHTML"), ".+?need_human (type\\d).*$", "$1", RegexOptions.Singleline);
			try
			{
				ReadOnlyCollection<IWebElement> readOnlyCollection = _driver.FindElements(By.XPath("//div[contains(@class,\"human no_select " + text2 + "\")]"));
				foreach (IWebElement item in readOnlyCollection)
				{
					item.IsClick(text2, 50);
					if (!game_star_bool)
					{
						Thread.Sleep(1000);
						break;
					}
					Thread thread = new Thread((ThreadStart)delegate
					{
						game_star_bool = Game_star();
					});
					thread.SetApartmentState(ApartmentState.STA);
					thread.Start();
				}
				Thread.Sleep(200);
			}
			catch
			{
			}
			if (_driver.IsFindElement(By.XPath("//span[text()=\"Новая игра\" or text()=\"Отдых\"]")) != null)
			{
				game_star_bool = true;
				for (int num = 0; num < 2; num++)
				{
					if (_driver.IsFindElement(By.XPath("//span[text()=\"Новая игра\"]")).IsClick("Клик Новая игра"))
					{
						Thread.Sleep(1000);
					}
				}
				if (_driver.IsFindElement(By.XPath("//span[text()=\"Отдых\"]")).IsClick("Клик отдых"))
				{
					break;
				}
			}
			if (text2 != text)
			{
				text = text2;
				i = 0;
			}
		}
		UpdateStatus("Статус:");
		return tavernaVoynyDateTime = DateTime.Now.AddMinutes(5.0);
	}

	private void UpdateStatus(string v)
	{
		Find.LabelStatus(v);
	}

	public DateTime Pirashka()
	{
		if (tavernaPirashkaDateTime > DateTime.Now)
		{
			return tavernaPirashkaDateTime;
		}
		if (!AppSettings.Get("checkBoxTavernaPirashka", defaultValue: false))
		{
			return tavernaPirashkaDateTime = DateTime.Now.AddMinutes(5.0);
		}
		if (_driver.ResyKri() < 1000)
		{
			return tavernaPirashkaDateTime = DateTime.Now.AddMinutes(5.0);
		}
		UpdateStatus("Статус: Таверна Пирашки");
		if (!_driver.IsFindElement(By.XPath("//a[contains(@href,\"tavern.php\")]")).IsClick("Тверна"))
		{
			Find.WebBrowserLog("Добавить Таверну в верхнее меню");
			UpdateStatus("Статус:");
			return tavernaPirashkaDateTime = DateTime.Now.AddMinutes(5.0);
		}
		_driver.IsFindElement(By.XPath("//div[contains(text(),\"Звездопад\")]")).IsClick("Звездопад");
		this.dateTime = _driver.DateTimeCount("//div[@id=\"starfall_game_counter_2\"]");
		if (this.dateTime > DateTime.Now)
		{
			if ((this.dateTime - DateTime.Now).TotalHours > 50.0)
			{
				UpdateStatus("Статус:");
				return tavernaPirashkaDateTime = DateTime.Now.AddMinutes(1.0);
			}
			UpdateStatus("Статус:");
			AppSettings.Set("tavernaPirashkaDateTime", this.dateTime.AddMinutes(1.0));
			return tavernaPirashkaDateTime = this.dateTime.AddMinutes(1.0);
		}
		_driver.IsFindElement(By.XPath("//select[@id=\"select_game_2\"]/option[2]")).IsClick("Выбрать 3 за 1000");
		_driver.IsFindElement(By.XPath("//span[@id=\"cost_type_2\"]//..//input[@value=\"ИГРАТЬ\"]")).IsClick("Клик играть 2");
		bool game_star_bool = true;
		for (int i = 0; i < 40; i++)
		{
			if (_driver.IsFindElement(By.XPath("//span[text()=\"Новая игра\" or text()=\"Отдых\"]")) != null)
			{
				game_star_bool = true;
				if (_driver.IsFindElement(By.XPath("//span[text()=\"Новая игра\"]")).IsClick("Клик Новая игра"))
				{
					i = 0;
				}
				if (_driver.IsFindElement(By.XPath("//span[text()=\"Отдых\"]")).IsClick("Клик отдых"))
				{
					break;
				}
			}
			try
			{
				ReadOnlyCollection<IWebElement> readOnlyCollection = _driver.FindElements(By.XPath("//div[contains(@class,\"fish no_select \")]"));
				foreach (IWebElement item in readOnlyCollection)
				{
					item.IsClick("fish no_select", 50);
					if (!game_star_bool)
					{
						Thread.Sleep(2000);
					}
					Thread thread = new Thread((ThreadStart)delegate
					{
						game_star_bool = Game_star();
					});
					thread.Start();
				}
			}
			catch
			{
			}
			Thread.Sleep(300);
		}
		UpdateStatus("Статус:");
		return tavernaPirashkaDateTime = DateTime.Now.AddMinutes(5.0);
	}

	private bool Game_star()
	{
		if (_driver.IsFindElement(By.XPath("//div[contains(@class,'game_star') and @rel='5']/div[contains(@style,'none')]")) != null)
		{
			return false;
		}
		return true;
	}

	public DateTime TavernaBotols()
	{
		if (tavernaBotolsDateTime > DateTime.Now)
		{
			return tavernaBotolsDateTime;
		}
		if (!AppSettings.Get("checkBoxTavernaBotols", defaultValue: false))
		{
			return tavernaBotolsDateTime = DateTime.Now.AddMinutes(5.0);
		}
		if (_driver.ResyKri() < 1000)
		{
			return tavernaBotolsDateTime = DateTime.Now.AddMinutes(5.0);
		}
		bool game_star_bool = true;
		UpdateStatus("Статус: Таверна Бар");
		if (!_driver.IsFindElement(By.XPath("//a[contains(@href,\"tavern.php\")]")).IsClick("Тверна"))
		{
			(Application.OpenForms[0] as Form1).webBrowserLog.LogThread("Добавить Таверну в верхнее меню");
			UpdateStatus("Статус:");
			return tavernaBotolsDateTime = DateTime.Now.AddMinutes(5.0);
		}
		_driver.IsFindElement(By.XPath("//div[contains(text(),\"Звездопад\")]")).IsClick("Звездопад");
		DateTime dateTime4 = _driver.DateTimeCount("//div[@id=\"starfall_game_counter_3\"]");
		if (dateTime4 > DateTime.Now)
		{
			if ((dateTime4 - DateTime.Now).TotalHours > 50.0)
			{
				UpdateStatus("Статус:");
				return tavernaBotolsDateTime = DateTime.Now.AddMinutes(1.0);
			}
			UpdateStatus("Статус:");
			AppSettings.Set("tavernaBotolsDateTime", dateTime4.AddMinutes(1.0));
			return tavernaBotolsDateTime = dateTime4.AddMinutes(1.0);
		}
		_driver.IsFindElement(By.XPath("//select[@id=\"select_game_3\"]/option[2]")).IsClick("Выбрать 3 за 1000");
		_driver.IsFindElement(By.XPath("//span[@id=\"cost_type_3\"]//..//input[@value=\"ИГРАТЬ\"]")).IsClick("Клик играть 3");
		string text = "";
		for (int i = 0; i < 10; i++)
		{
			elem = _driver.IsFindElement(By.XPath("//div[@class=\"bottles_bar\"]/div[1]"));
			if (elem.isGetAttribute("outerHTML").Contains("-"))
			{
				Find.Sleep(200);
				continue;
			}
			string text2 = Regex.Replace(elem.isGetAttribute("outerHTML"), ".+?no_select (bottle\\d).*$", "$1", RegexOptions.Singleline);
			_driver.IsFindElement(By.XPath("//div[@class=\"bottles_yours\"]/div[contains(@class,\"" + text2 + "\")]")).IsClick("Клик " + text2, 100);
			if (!game_star_bool)
			{
				Thread.Sleep(2000);
			}
			Thread thread = new Thread((ThreadStart)delegate
			{
				game_star_bool = Game_star();
			});
			thread.Start();
			if (_driver.IsFindElement(By.XPath("//span[text()=\"Новая игра\" or text()=\"Отдых\"]")) != null)
			{
				_driver.IsFindElement(By.XPath("//span[text()=\"Новая игра\"]")).IsClick("Клик Новая игра");
				game_star_bool = true;
				if (_driver.IsFindElement(By.XPath("//span[text()=\"Отдых\"]")).IsClick("Клик отдых"))
				{
					break;
				}
			}
			if (text2 != text)
			{
				text = text2;
				i = 0;
			}
		}
		UpdateStatus("Статус:");
		return tavernaBotolsDateTime = DateTime.Now.AddMinutes(5.0);
	}

	public DateTime LuchsheHyje()
	{
		if (tavernaLuchsheHyjeDateTime > DateTime.Now)
		{
			return tavernaLuchsheHyjeDateTime;
		}
		if (!AppSettings.Get("checkBoxTavernatavernaLuchsheHyje", defaultValue: false))
		{
			return tavernaLuchsheHyjeDateTime = DateTime.Now.AddMinutes(5.0);
		}
		if (_driver.ResyKri() < 1000)
		{
			return tavernaLuchsheHyjeDateTime = DateTime.Now.AddMinutes(5.0);
		}
		bool game_star_bool = true;
		UpdateStatus("Статус: Таверна Лучше вс Хуже");
		if (!_driver.IsFindElement(By.XPath("//a[contains(@href,\"tavern.php\")]")).IsClick("Тверна"))
		{
			Find.WebBrowserLog("Добавить Таверну в верхнее меню");
			UpdateStatus("Статус:");
			return tavernaLuchsheHyjeDateTime = DateTime.Now.AddMinutes(5.0);
		}
		_driver.IsFindElement(By.XPath("//div[contains(text(),\"Звездопад\")]")).IsClick("Звездопад");
		_driver.IsFindElement(By.XPath("//select[@id=\"select_game_4\"]/option[2]")).IsClick("Выбрать 3 за 1000");
		_driver.IsFindElement(By.XPath("//span[@id=\"cost_type_4\"]//..//input[@value=\"ИГРАТЬ\"]")).IsClick("Клик играть 4");
		DateTime dateTime4 = _driver.DateTimeCount("//div[@id=\"starfall_game_counter_4\"]");
		if (dateTime4 > DateTime.Now)
		{
			if ((dateTime4 - DateTime.Now).TotalHours > 50.0)
			{
				UpdateStatus("Статус:");
				return tavernaLuchsheHyjeDateTime = DateTime.Now.AddMinutes(1.0);
			}
			UpdateStatus("Статус:");
			AppSettings.Set("tavernaLuchsheHyjeDateTime", dateTime4.AddMinutes(1.0));
			return tavernaLuchsheHyjeDateTime = dateTime4.AddMinutes(1.0);
		}
		for (int i = 0; i < 20; i++)
		{
			Thread.Sleep(600);
			int[] array = new int[2];
			string source = _driver.IsFindElement(By.XPath("//div[@class=\"which_is_better\"]/div[@rel=1]/img")).isGetAttribute("outerHTML");
			string source2 = _driver.IsFindElement(By.XPath("//div[@class=\"which_is_better\"]/div[@rel=2]/img")).isGetAttribute("outerHTML");
			bool flag = _driver.IsFindElement(By.XPath("//div[@class=\"game_type center\"]")).isGetAttribute("outerText").Contains("ЛУЧШЕ");
			int.TryParse(string.Join("", source.Where((char c) => char.IsDigit(c))), out array[0]);
			int.TryParse(string.Join("", source2.Where((char c) => char.IsDigit(c))), out array[1]);
			int num = ((flag ? (array[0] <= array[1]) : (array[0] >= array[1])) ? 1 : 0);
			_driver.IsFindElement(By.XPath($"//div[@class='which_is_better']/div[@rel='{num + 1}']")).IsClick("Клик лучшее хуже " + flag + " " + array[0] + " " + array[1], 100);
			string text = _driver.IsFindElement(By.XPath("//div[@class=\"which_is_better\"]")).isGetAttribute("outerHTML");
			bool flag2 = !text.Contains("bad");
			if (_driver.IsFindElement(By.XPath("//span[text()=\"Новая игра\" or text()=\"Отдых\"]")) != null)
			{
				i = 0;
				if (_driver.IsFindElement(By.XPath("//span[text()=\"Новая игра\"]")).IsClick("Клик Новая игра"))
				{
					game_star_bool = true;
				}
				if (_driver.IsFindElement(By.XPath("//span[text()=\"Отдых\"]")).IsClick("Клик отдых"))
				{
					break;
				}
			}
			if (!game_star_bool)
			{
				Thread.Sleep(2000);
			}
			Thread thread = new Thread((ThreadStart)delegate
			{
				game_star_bool = Game_star();
			});
			thread.Start();
		}
		UpdateStatus("Статус:");
		return tavernaLuchsheHyjeDateTime = DateTime.Now.AddMinutes(5.0);
	}
}
