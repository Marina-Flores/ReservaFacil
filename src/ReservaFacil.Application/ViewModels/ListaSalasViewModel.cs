using ReservaFacil.Domain.Models;

namespace ReservaFacil.Application.ViewModels;

public class ListaSalasViewModel
{
    private IEnumerable<Sala> _salas = Enumerable.Empty<Sala>();
    public IEnumerable<Sala> Salas
    {
        get => _salas;
        init => _salas = value ?? Enumerable.Empty<Sala>();
    }
    public IEnumerable<Curso> Cursos { get; set; }
    public int PaginaAtiva { get; set; }
    public int QuantidadeSalas { get; set; }
    public int QuantidadePaginas { get; set; }
}