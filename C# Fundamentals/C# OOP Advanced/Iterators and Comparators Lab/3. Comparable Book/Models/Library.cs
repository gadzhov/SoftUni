using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    public Library(params Book[] books)
    {
        this.Books = new SortedSet<Book>(books);
    }

    public SortedSet<Book> Books { get; set; }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.Books);
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    private class LibraryIterator : IEnumerator<Book>
    {
        private readonly List<Book> books;
        private int currentIndex;

        public LibraryIterator(IEnumerable<Book> books)
        {
            this.Reset();
            this.books = new List<Book>(books);
        }

        public void Dispose(){}

        public bool MoveNext() => ++this.currentIndex < this.books.Count;

        public void Reset() => this.currentIndex = -1;

        public Book Current => this.books[this.currentIndex];

        object IEnumerator.Current => this.Current;
    }
}
