using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Data
{
    public class Codecast : Entity
    {
        private string title;
        private DateTime publicationDate;

        public string Title { get => title; set => title = value; }
        public DateTime PublicationDate { get => publicationDate; set => publicationDate = value; }

    }
}
