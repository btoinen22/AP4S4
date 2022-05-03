using System;
using System.Collections.Generic;
using System.Text;

namespace Encheres.Interfaces
{
    public interface MyImageCompressor
    {
        /// <summary>
        /// compresse la taille de l'image
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns> retourne un objet string</returns>
        string ImageCompressor(byte[] bitmap);

    }
}
