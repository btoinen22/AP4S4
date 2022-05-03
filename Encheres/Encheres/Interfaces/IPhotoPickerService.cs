using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Encheres.Interfaces
{
    public interface IPhotoPickerService
    {
        /// <summary>
        /// lance le fonction task situé dans le projet .android
        /// servant à l'introdction d'iamge
        /// </summary>
        /// <returns>retourne une image de type task<stream> </returns>
        Task<Stream> GetImageStreamAsync();

    }
}
