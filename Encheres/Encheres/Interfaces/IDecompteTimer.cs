using Encheres.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Encheres.Interfaces
{
    interface IDecompteTimer
    {
        /// <summary>
        /// lance le décompte
        /// </summary>
        /// <param name="CountdownTime"></param>
        void Start(TimeSpan CountdownTime);

        /// <summary>
        /// arrète le décompte
        /// </summary>
        void Stop();

        /// <summary>
        /// Création d'évènement tictac
        /// </summary>
        event EventHandler<TimerEventArgs> TicTac;

        /// <summary>
        /// création d'évènement complet
        /// </summary>
        event EventHandler Complet;

        /// <summary>
        /// création d'évenement Avorte
        /// </summary>
        event EventHandler Avorte;
    }
}
