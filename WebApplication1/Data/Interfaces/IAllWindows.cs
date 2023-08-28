using WebApplication1.Data.Models;

namespace WebApplication1.Data
{
    public interface IAllWindows
    {
        //получаем и устанавливаем все окна
        IEnumerable<Window> Windows { get; }
        //получаем и устанавливаем избранные окна
        IEnumerable<Window> GetFavoriteWindows { get; }
        //получение определенного окна
        Window GetObjectWindow(int id);
        Window GetObjectWindowWithFeedBacks(int id);
        void AddWindow(Window window, Category category);
        void RemoveWindow(Window window);
        void UpdateWindow(Window window);
    }
}
