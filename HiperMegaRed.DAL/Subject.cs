using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiperMegaRed.BE;

namespace HiperMegaRed.DAL
{
    public abstract class Subject
    {
        private static List<Iobserver> _observers = new List<Iobserver>();

        public static void AddObserver(Iobserver iobserver)
        {
            _observers.Add(iobserver);
        }

        public static void RemoveObserver(Iobserver iobserver)
        {
            _observers.Remove(iobserver);
        }

        public static void Noptify(Idioma idioma)
        {
            foreach (var observer in _observers)
            {
                observer.Update(idioma);
            }
        }
    }
}
