using System;
using System.Collections.Generic;

// Parent class
public class Item
{
    public string Title { get; set; }
    public int Year { get; set; }

    public Item(string title, int year)
    {
        Title = title;
        Year = year;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine("Judul: {0}", Title);
        Console.WriteLine("Tahun: {0}", Year);
    }
}

// Child class
public class Book : Item
{
    public string Author { get; set; }

    public Book(string title, int year, string author) : base(title, year)
    {
        Author = author;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Penulis: {0}", Author);
    }
}

public class Library
{
    private List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void DisplayItems()
    {
        foreach (var item in items)
        {
            item.DisplayInfo();
            Console.WriteLine();
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Library library = new Library();
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("=============================");
            Console.WriteLine("Sistem Informasi Perpustakaan");
            Console.WriteLine("1. Tambah Buku");
            Console.WriteLine("2. Tampilkan Semua Buku");
            Console.WriteLine("3. Keluar");
            Console.WriteLine("=============================");
            Console.WriteLine("");
            Console.Write("Pilih menu: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Judul Buku: ");
                    string title = Console.ReadLine();
                    Console.Write("Tahun Terbit: ");
                    int year = int.Parse(Console.ReadLine());
                    Console.Write("Penulis: ");
                    string author = Console.ReadLine();

                    Book book = new Book(title, year, author);
                    library.AddItem(book);

                    Console.WriteLine("Buku berhasil ditambahkan!");
                    Console.WriteLine("");
                    break;
                case 2:
                    Console.WriteLine("Daftar Buku:");
                    library.DisplayItems();
                    Console.WriteLine("");
                    break;
                case 3:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Pilihan Tidak Ada. Silakan Coba Lagi.");
                    break;
            }
        }
    }
}