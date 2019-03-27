using System;
using System.Threading.Tasks;

namespace AppEntrevista
{
    public interface IVideoPicker
    {
        Task<string> GetVideoFileAsync();
    }
}
