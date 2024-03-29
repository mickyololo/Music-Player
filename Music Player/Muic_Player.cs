﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerInCSharp
{
    class MusicPlayer
    {
        private List<string> playlist = new List<string>();

        // Display the menu options
        public void DisplayMenu()
        {
            Console.WriteLine("\n===== Music Player Menu =====");
            Console.WriteLine("1. Add song to playlist");
            Console.WriteLine("2. Delete song from playlist");
            Console.WriteLine("3. Play playlist");
            Console.WriteLine("4. Shuffle playlist");
            Console.WriteLine("5. Sort playlist");
            Console.WriteLine("6. Display playlist");
            Console.WriteLine("7. Exit");
        }

        // Add a song to the playlist
        public void AddSong()
        {
            Console.Write("Enter the name of the song: ");
            string song = Console.ReadLine();
            playlist.Add(song);
            Console.WriteLine($"{song} added to the playlist.");
        }

        // Delete a song from the playlist
        public void DeleteSong()
        {
            if (playlist.Count == 0)
            {
                Console.WriteLine("Playlist is empty.");
                return;
            }

            Console.WriteLine("\nCurrent Playlist:");
            DisplayPlaylist();

            Console.Write("Enter the index of the song to delete: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < playlist.Count)
            {
                string deletedSong = playlist[index];
                playlist.RemoveAt(index);
                Console.WriteLine($"{deletedSong} deleted from the playlist.");
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }

        // Play all songs in the playlist
        public void PlayPlaylist()
        {
            if (playlist.Count == 0)
            {
                Console.WriteLine("Playlist is empty.");
                return;
            }

            Console.WriteLine("\nPlaying Playlist:");
            foreach (string song in playlist)
            {
                Console.WriteLine($"Now playing: {song}");
            }
        }

        // Shuffle the songs in the playlist
        public void ShufflePlaylist()
        {
            Random random = new Random();
            playlist = playlist.OrderBy(x => random.Next()).ToList();
            Console.WriteLine("Playlist shuffled.");
        }

        // Sort the songs in the playlist
        public void SortPlaylist()
        {
            playlist.Sort();
            Console.WriteLine("Playlist sorted.");
        }

        // Display all songs in the playlist
        public void DisplayPlaylist()
        {
            if (playlist.Count == 0)
            {
                Console.WriteLine("Playlist is empty.");
            }
            else
            {
                for (int i = 0; i < playlist.Count; i++)
                {
                    Console.WriteLine($"{i}. {playlist[i]}");
                }
            }
        }

        // Main method to run the music player
        public void Run()
        {
            while (true)
            {
                DisplayMenu();
                Console.Write("\nEnter your choice (1-7): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddSong();
                        break;
                    case "2":
                        DeleteSong();
                        break;
                    case "3":
                        PlayPlaylist();
                        break;
                    case "4":
                        ShufflePlaylist();
                        break;
                    case "5":
                        SortPlaylist();
                        break;
                    case "6":
                        DisplayPlaylist();
                        break;
                    case "7":
                        Console.WriteLine("Exiting music player. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 7.");
                        break;
                }
            }
        }
    }
}
