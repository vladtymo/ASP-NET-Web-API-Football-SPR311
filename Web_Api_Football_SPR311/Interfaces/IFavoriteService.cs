using Web_Api_Football_SPR311.Models;

namespace Web_Api_Football_SPR311.Interfaces;

public interface IFavoriteService
{
    List<int> GetIds();
    List<Team> GetAll();
    void Add(int id);
    void Remove(int id);
    void Clear();
    int GetCount();
}