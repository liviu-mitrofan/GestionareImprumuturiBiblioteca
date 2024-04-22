using System;

namespace Imprumuturi_Biblioteca
{
    public class Carte
    {
        private static int ultimulId = 0;

        public int Id { get; }
        public string Titlu { get; set; }
        public string Autor { get; set; }
        public bool EsteDisponibila { get; set; }

        public Carte()
        {
            Id = ++ultimulId;
        }
    }

    public class Membru
    {
        private static int ultimulId = 0;

        public int Id { get; }
        public string Nume { get; set; }
        public string Prenume { get; set; }

        public Membru()
        {
            Id = ++ultimulId;
        }
    }

    public class GestionareImprumuturi
    {
        private Carte[] biblioteca;
        private Membru[] membri;
        private int numarCarti;
        private int numarMembri;

        public GestionareImprumuturi(int dimensiuneBiblioteca, int dimensiuneMembri)
        {
            biblioteca = new Carte[dimensiuneBiblioteca];
            membri = new Membru[dimensiuneMembri];
            numarCarti = 0;
            numarMembri = 0;
        }

        public void AdaugaCarte(Carte carte)
        {
            if (numarCarti < biblioteca.Length)
            {
                biblioteca[numarCarti++] = carte;
            }
            else
            {
                throw new Exception("Biblioteca este plină. Nu se poate adăuga carte.");
            }
        }

        public void AdaugaMembru(Membru membru)
        {
            if (numarMembri < membri.Length)
            {
                membri[numarMembri++] = membru;
            }
            else
            {
                throw new Exception("Numărul maxim de membri a fost atins. Nu se poate adăuga membru.");
            }
        }

        public Carte[] GetBiblioteca()
        {
            return biblioteca;
        }

        public Membru[] GetMembri()
        {
            return membri;
        }
    }
}
