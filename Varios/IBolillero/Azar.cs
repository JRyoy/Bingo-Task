namespace Varios.IBolillero;

public class Azar
{
    public int SacarBolilla(Bolillero bolillero)
    {
        Random random= new (DateTime.Now.Millisecond);
        return random.Next(bolillero.bolillas.Count);
    }
}
