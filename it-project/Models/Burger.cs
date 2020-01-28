using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace it_project.Models
{
    public class Burger
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Име")]
        public string Ime { get; set; }
        [DisplayName("Цена")]
        public int Cena { get; set; }
        [DisplayName("Опис")]
        public string Opis { get; set; }
        [DisplayName("Слика")]
        public string Pateka { get; set; }

        

        public Burger()
        {
        }
        public Burger(int id)
        {
            Id = id;
        }

        public Burger(int id, string ime, int cena, string opis, string pateka)
        {
            Id = id;
            Ime = ime;
            Cena = cena;
            Opis = opis;
            Pateka = pateka;
        }
    }
}