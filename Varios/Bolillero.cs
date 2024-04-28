namespace Varios;

public class Bolillero
{
    public List<int> bolillas { get; set; }
    public List<int> Acertadas { get; set; }
    public Iazar iazar { get; set; }
    public Bolillero(int CantidadBolillas)
    {
        for (int i = 0; i < CantidadBolillas; i++) { bolillas.Add(i); }
    }
    //Para clonar
    public Bolillero Clon(Bolillero original)
    {
        this.Acertadas = new(original.Acertadas);
        this.bolillas=new(original.bolillas);
        return original;
    }
    public int SacarBolilla()
    {
        var index = iazar.ObtenerIndice(this);
        int bolillaSacada = bolillas[index];
        Acertadas.Add(bolillaSacada);
        bolillas.RemoveAt(index);
        return bolillaSacada;
    }
    public bool Jugada(List<int> bolillas)
    {
        Restablecer();
        foreach (var bolilla in bolillas)
        {
            if (SacarBolilla() != bolilla) { return false; }
        }
        return true;
    }
    public long JugadaNV(long CantidadJugada, List<int> bolillas)
    {
        long Aciertos = 0;
        for (int i = 0; i < CantidadJugada; i++)
        { Jugada(bolillas); Aciertos += 1; }
        return Aciertos;
    }
    public void Restablecer()
    {
        bolillas.AddRange(Acertadas);
        Acertadas.Clear();
    }
}
