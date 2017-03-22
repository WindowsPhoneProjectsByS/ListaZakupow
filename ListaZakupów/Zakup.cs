using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaZakupów
{
    class Zakup
    {
        private string nazwa;
        private int ilosc;
        private string jednostka;
        private string prefMarak;
        private int cenaMax;

        public String Nazwa
        {

            get { return this.nazwa; }
           
            set
            {
                if (value != this.nazwa)
                {
                    this.nazwa = value;
                    NotifyPropertyChnaged("Nazwa");
                }
            }
        }

        public int Ilosc
        {
            get
            {
                return ilosc;
                
            }
            set
            {
                if (value != this.ilosc)
                {
                    this.ilosc = value;
                    NotifyPropertyChnaged("Ilość");
                }
            }
        }

        public string Jednostka {
            get { return this.jednostka; }

            set
            {

                if (value != this.jednostka)
                {
                    this.jednostka = value;
                    NotifyPropertyChnaged("Jednostka");
                }
            }
        }

        public string PrefMarak
        {
            get { return this.prefMarak; }
            set 
            {
                if (value != this.prefMarak)
                {
                    this.prefMarak = value;
                    NotifyPropertyChnaged("PrefMarak");
                }
            }
    }

        public int CenaMax
        {
            get { return this.cenaMax; }
            set
            {
                if (value != this.cenaMax)
                {
                    cenaMax = value;
                    NotifyPropertyChnaged("CenaMax");
                }
            }
        }

        public Object Clone()
        {
            return this.MemberwiseClone();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChnaged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
