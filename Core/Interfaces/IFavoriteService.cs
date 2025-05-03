using Data.Models;

namespace Core.Interfaces;

public interface IFavoriteService
{
    List<int> GetIds();
    List<Team> GetAll();
    void Add(int id);
    void Remove(int id);
    void Clear();
    int GetCount();
}