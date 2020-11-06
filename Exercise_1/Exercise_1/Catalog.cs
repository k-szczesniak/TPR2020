namespace Exercise_1
{
    class Catalog
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public bool IsAvailable { get; set; }

        public Catalog(string id, string author, string title, bool isAvailable)
        {
            Id = id;
            Author = author;
            Title = title;
            IsAvailable = isAvailable;
        }
    }
}
