using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models
{
    public class Event
    {
        public int Id { get; set; }
    
        public string Name { get; set; }

        public string UserId { get; set; } //Autor

        public  System.DateTime? DateEvent { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime? DateUpdate { get; set; }

        public int AccessId { get; set; }

        public int GroupId { get; set; }

        public string StatusEvent { get; set; }

        public string Description { get; set; }

        [DefaultValueAttribute(0)]
        public int IsEnded { get; set; }




    }
}