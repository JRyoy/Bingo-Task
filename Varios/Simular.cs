namespace Varios;

public class Simular
{
    public long simularSinHilos(Bolillero bolillero, int CantidadSimulacion, List<int> bolillas)
        => bolillero.JugadaNV(CantidadSimulacion, bolillas);
    public long simularConHilos(Bolillero bolillero, int CantidadSimulacion,List<int> bolillas,long hilos)
    {
        Bolillero bolillero1 = bolillero.Clon(bolillero);
        Task<long>[] tareas = new Task<long>[hilos];
        long resto = CantidadSimulacion%hilos;
        for (long i = 0; i < resto; i++)
        {
            tareas[i] = Task.Run(() => bolillero1.JugadaNV(CantidadSimulacion / hilos, bolillas));
        }
        for (long i = resto; i < hilos; i++)
        {
            tareas[i] = Task.Run(() => bolillero1.JugadaNV(CantidadSimulacion / hilos, bolillas));
        }

        Task.WaitAll(tareas);
        return tareas.Sum(t => t.Result);   
        }
}


