namespace Botva2025;

public class Room
{
	public int RoomNumber { get; set; }

	public int Race1Vrag { get; set; }

	public int Race2Drug { get; set; }

	public bool Activ { get; set; }

	public double Summa
	{
		get
		{
			int num = 10;
			if (Race2Drug > Race1Vrag)
			{
				num *= (int)((1.0 + (double)(Race2Drug - Race1Vrag) * 0.1) * 10.0);
			}
			if (Race1Vrag == 0)
			{
				num = 0;
			}
			return num;
		}
	}
}
