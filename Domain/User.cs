﻿using System.Collections.Generic;

namespace Lab9.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Book> Books { get; set; }
    }
}